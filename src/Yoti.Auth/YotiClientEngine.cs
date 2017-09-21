﻿using System;
using System.Collections.Generic;
using System.Globalization;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using AttrpubapiV1;
using Newtonsoft.Json;
using Org.BouncyCastle.Crypto;
using Yoti.Auth.DataObjects;

namespace Yoti.Auth
{
    internal class YotiClientEngine
    {
        private const string _apiUrl = @"https://api.yoti.com/api/v1"; // TODO: Make this configurable

        private readonly IHttpRequester _httpRequester;

        public YotiClientEngine(IHttpRequester httpRequester)
        {
            _httpRequester = httpRequester;
        }

        /// <summary>
        /// Request a <see cref="ActivityDetails"/>  using the encrypted token provided by yoti during the login process.
        /// </summary>
        /// <param name="encryptedToken">The encrypted returned by Yoti after successfully authenticating.</param>
        /// <returns>The account details of the logged in user as a <see cref="ActivityDetails"/>. </returns>
        public ActivityDetails GetActivityDetails(string encryptedToken, string sdkId, AsymmetricCipherKeyPair keyPair)
        {
            Task<ActivityDetails> task = Task.Run<ActivityDetails>(async () => await GetActivityDetailsAsync(encryptedToken, sdkId, keyPair));

            return task.Result;
        }

        /// <summary>
        /// Asynchronously request a <see cref="ActivityDetails"/>  using the encrypted token provided by yoti during the login process.
        /// </summary>
        /// <param name="encryptedToken">The encrypted returned by Yoti after successfully authenticating.</param>
        /// <returns>The account details of the logged in user as a <see cref="ActivityDetails"/>. </returns>
        public async Task<ActivityDetails> GetActivityDetailsAsync(string encryptedConnectToken, string sdkId, AsymmetricCipherKeyPair keyPair)
        {
            // query parameters
            var token = CryptoEngine.DecryptToken(encryptedConnectToken, keyPair);
            var nonce = CryptoEngine.GenerateNonce();
            var timestamp = GetTimestamp();

            // create http endpoint
            var endpoint = GetEndpoint(token, nonce, timestamp, sdkId);

            // create request headers
            var authKey = CryptoEngine.GetAuthKey(keyPair);
            var authDigest = GetAuthDigest(endpoint, keyPair);

            Dictionary<string, string> headers = new Dictionary<string, string>();

            headers.Add("X-Yoti-Auth-Key", authKey);
            headers.Add("X-Yoti-Auth-Digest", authDigest);

            var response = await _httpRequester.DoRequest(
                new HttpClient(),
                new Uri(_apiUrl + endpoint),
                headers);

            if (response.Success)
            {
                return HandleSuccessfulResponse(keyPair, response);
            }
            else
            {
                ActivityOutcome outcome = ActivityOutcome.Failure;
                switch (response.StatusCode)
                {
                    case (int)HttpStatusCode.NotFound:
                        {
                            outcome = ActivityOutcome.ProfileNotFound;
                        }
                        break;
                }

                return new ActivityDetails
                {
                    Outcome = outcome
                };
            }
        }

        private ActivityDetails HandleSuccessfulResponse(AsymmetricCipherKeyPair keyPair, Response response)
        {
            var parsedResponse = JsonConvert.DeserializeObject<ProfileDO>(response.Content);

            if (parsedResponse.receipt == null)
            {
                return new ActivityDetails
                {
                    Outcome = ActivityOutcome.Failure
                };
            }
            else if (parsedResponse.receipt.sharing_outcome != "SUCCESS")
            {
                return new ActivityDetails
                {
                    Outcome = ActivityOutcome.SharingFailure
                };
            }
            else
            {
                var receipt = parsedResponse.receipt;

                var attributes = CryptoEngine.DecryptCurrentUserReceipt(
                    parsedResponse.receipt.wrapped_receipt_key,
                    parsedResponse.receipt.other_party_profile_content,
                    keyPair);

                var profile = new YotiUserProfile
                {
                    Id = parsedResponse.receipt.remember_me_id
                };

                AddAttributesToProfile(attributes, profile);

                return new ActivityDetails
                {
                    Outcome = ActivityOutcome.Success,
                    UserProfile = profile
                };
            }
        }

        private static void AddAttributesToProfile(AttributeList attributes, YotiUserProfile profile)
        {
            foreach (var attribute in attributes.Attributes)
            {
                var data = attribute.Value.ToByteArray();
                switch (attribute.Name)
                {
                    case "selfie":

                        switch (attribute.ContentType)
                        {
                            case ContentType.Jpeg:
                                profile.Selfie = new Image
                                {
                                    Type = ImageType.Jpeg,
                                    Data = data
                                };
                                break;

                            case ContentType.Png:
                                profile.Selfie = new Image
                                {
                                    Type = ImageType.Png,
                                    Data = data
                                };
                                break;
                        }
                        break;

                    case "given_names":
                        profile.GivenNames = Conversion.BytesToUtf8(data);
                        break;

                    case "family_name":
                        profile.FamilyName = Conversion.BytesToUtf8(data);
                        break;

                    case "phone_number":
                        profile.MobileNumber = Conversion.BytesToUtf8(data);
                        break;

                    case "email_address":
                        profile.EmailAddress = Conversion.BytesToUtf8(data);
                        break;

                    case "date_of_birth":
                        {
                            DateTime date;
                            if (DateTime.TryParseExact(Conversion.BytesToUtf8(data), "yyyy-MM-dd", CultureInfo.InvariantCulture, System.Globalization.DateTimeStyles.None, out date))
                            {
                                profile.DateOfBirth = date;
                            }
                        }
                        break;

                    case "postal_address":
                        profile.Address = Conversion.BytesToUtf8(data);
                        break;

                    case "gender":
                        profile.Gender = Conversion.BytesToUtf8(data);
                        break;

                    case "nationality":
                        profile.Nationality = Conversion.BytesToUtf8(data);
                        break;

                    default:
                        HandleOtherAttributes(profile, attribute, data);
                        break;
                }
            }
        }

        private static void HandleOtherAttributes(YotiUserProfile profile, AttrpubapiV1.Attribute attribute, byte[] data)
        {
            switch (attribute.ContentType)
            {
                case ContentType.Date:
                    profile.OtherAttributes.Add(
                        attribute.Name,
                        new YotiAttributeValue(YotiAttributeValue.TypeEnum.Date, data));
                    break;

                case ContentType.String:
                    profile.OtherAttributes.Add(
                        attribute.Name,
                        new YotiAttributeValue(YotiAttributeValue.TypeEnum.Text, data));
                    break;

                case ContentType.Jpeg:
                    profile.OtherAttributes.Add(
                        attribute.Name,
                        new YotiAttributeValue(YotiAttributeValue.TypeEnum.Jpeg, data));
                    break;

                case ContentType.Png:
                    profile.OtherAttributes.Add(
                        attribute.Name,
                        new YotiAttributeValue(YotiAttributeValue.TypeEnum.Png, data));
                    break;

                case ContentType.Undefined:
                    // do not return attributes with undefined content types
                    break;

                default:
                    break;
            }
        }

        private string GetEndpoint(string token, string nonce, string timestamp, string sdkId)
        {
            return string.Format("/profile/{0}?nonce={1}&timestamp={2}&appId={3}", token, nonce, timestamp, sdkId);
        }

        private string GetAuthDigest(string endpoint, AsymmetricCipherKeyPair keyPair)
        {
            byte[] digestBytes = Conversion.UtfToBytes("GET&" + endpoint);

            byte[] signedDigestBytes = CryptoEngine.SignDigest(digestBytes, keyPair);

            return Conversion.BytesToBase64(signedDigestBytes);
        }

        private string GetTimestamp()
        {
            // get unix style timestamp but in milliseconds
            long milliseconds = (long)(DateTime.UtcNow.Subtract(new DateTime(1970, 1, 1))).TotalMilliseconds;

            return milliseconds.ToString();
        }
    }
}