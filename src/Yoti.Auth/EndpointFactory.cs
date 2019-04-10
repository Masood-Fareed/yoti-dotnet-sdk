﻿using System;
using System.Globalization;
using System.Net.Http;

namespace Yoti.Auth
{
    internal class EndpointFactory
    {
        public static string CreateProfileEndpoint(HttpMethod httpMethod, string path, string token, string sdkId)
        {
            return $"/{path}/{token}?nonce={CryptoEngine.GenerateNonce()}&timestamp={GetTimestamp()}&appId={sdkId}";
        }

        public static string CreateAmlEndpoint(HttpMethod httpMethod, string appId)
        {
            return $"/aml-check?appId={appId}&timestamp={GetTimestamp()}&nonce={CryptoEngine.GenerateNonce()}";
        }

        private static string GetTimestamp()
        {
            var milliseconds = (long)(DateTime.UtcNow.Subtract(new DateTime(1970, 1, 1))).TotalMilliseconds;

            return milliseconds.ToString(CultureInfo.InvariantCulture);
        }
    }
}