﻿using System;
using System.Diagnostics;
using System.IO;
using System.Net.Http;
using System.Text;
using DocScanExample.Models;
using Microsoft.AspNetCore.Mvc;
using Yoti.Auth;
using Yoti.Auth.DocScan;
using Yoti.Auth.DocScan.Session.Create;
using Yoti.Auth.DocScan.Session.Create.Check;
using Yoti.Auth.DocScan.Session.Create.Task;

namespace DocScanExample.Controllers
{
    public class HomeController : Controller
    {
        private readonly DocScanClient _client;

        private readonly string _baseUrl = "https://localhost:5001";
        private readonly Uri _apiUrl;

        public HomeController()
        {
            _apiUrl = GetApiUrl();
            _client = GetDocScanClient(_apiUrl);
        }

        public IActionResult Index()
        {
            var sessionSpec = new SessionSpecificationBuilder()
                .WithClientSessionTokenTtl(600)
                .WithResourcesTtl(90000)
                .WithUserTrackingId("some-user-tracking-id")
                .WithRequestedCheck(
                  new RequestedDocumentAuthenticityCheckBuilder()
                    .Build()
                )
                .WithRequestedCheck(
                  new RequestedLivenessCheckBuilder()
                    .ForZoomLiveness()
                    .Build()
                )
                .WithRequestedCheck(
                  new RequestedFaceMatchCheckBuilder()
                    .WithManualCheckNever()
                    .Build()
                )
                .WithRequestedTask(
                  new RequestedTextExtractionTaskBuilder()
                    .WithManualCheckNever()
                    .WithChipDataDesired()
                    .Build()
                )
                .WithSdkConfig(
                  new SdkConfigBuilder()
                    .WithAllowsCameraAndUpload()
                    .WithPrimaryColour("#2d9fff")
                    .WithSecondaryColour("#FFFFFF")
                    .WithFontColour("#FFFFFF")
                    .WithLocale("en-GB")
                    .WithPresetIssuingCountry("GBR")
                    .WithSuccessUrl(Path.Combine(_baseUrl, "idverify/success"))
                    .WithErrorUrl(Path.Combine(_baseUrl, "idverify/error"))
                    .Build()
                  )
                  .Build();

            CreateSessionResult createSessionResult = _client.CreateSession(sessionSpec);
            string sessionId = createSessionResult.SessionId;

            string path = $"web/index.html?sessionID={sessionId}&sessionToken={createSessionResult.ClientSessionToken}";
            Uri uri = new Uri(_apiUrl, path);

            ViewBag.iframeUrl = uri.ToString();

            TempData["sessionId"] = sessionId;
            return View(createSessionResult);
        }

        [Route("media")]
        public IActionResult Media(string mediaId, string sessionId, int? base64zip)
        {
            MediaValue media = _client.GetMediaContent(sessionId, mediaId);

            var contentType = media.GetMIMEType();
            var content = media.GetContent();

            if (contentType == "application/octet-stream" && base64zip == 1)
            {
                string base64Media = Encoding.ASCII.GetString(content);
                byte[] mediaBytes = Convert.FromBase64String(base64Media);

                return File(mediaBytes, "application/zip", $"{mediaId}.zip");
            }

            return File(content, contentType);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        internal static DocScanClient GetDocScanClient(Uri apiUrl = null)
        {
            if (apiUrl == null)
                apiUrl = GetApiUrl();

            StreamReader privateKeyStream = System.IO.File.OpenText(Environment.GetEnvironmentVariable("YOTI_KEY_FILE_PATH"));
            var key = CryptoEngine.LoadRsaKey(privateKeyStream);

            string clientSdkId = Environment.GetEnvironmentVariable("YOTI_CLIENT_SDK_ID");

            return new DocScanClient(clientSdkId, key, new HttpClient(), apiUrl);
        }

        internal static Uri GetApiUrl()
        {
            string apiUrl = Environment.GetEnvironmentVariable("YOTI_DOC_SCAN_API_URL");
            if (string.IsNullOrEmpty(apiUrl))
            {
                return Yoti.Auth.Constants.Api.DefaultYotiDocsUrl;
            }

            if (!apiUrl.EndsWith("/", StringComparison.Ordinal))
                apiUrl += "/";

            return new Uri(apiUrl);
        }
    }
}