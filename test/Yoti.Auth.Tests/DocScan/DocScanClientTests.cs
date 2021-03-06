﻿using System;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Newtonsoft.Json;
using Org.BouncyCastle.Crypto;
using Yoti.Auth.DocScan;
using Yoti.Auth.DocScan.Session.Create;
using Yoti.Auth.Exceptions;
using Yoti.Auth.Tests.Common;

namespace Yoti.Auth.Tests.DocScan
{
    [TestClass]
    public class DocScanClientTests
    {
        private const string _sdkId = "sdkId";

        private const string _someSessionId = "someSessionId";
        private const string _someMediaId = "someMediaId";

        private AsymmetricCipherKeyPair _keyPair;

        [TestInitialize]
        public void Startup()
        {
            _keyPair = Tests.Common.KeyPair.Get();
        }

        [TestMethod]
        public void ShouldFailForNullSdkId()
        {
            var exception = Assert.ThrowsException<InvalidOperationException>(() =>
            {
                new DocScanClient(null, _keyPair);
            });

            Assert.IsTrue(exception.Message.Contains("sdkId"));
        }

        [TestMethod]
        public void ShouldFailForNullKeyPair()
        {
            var exception = Assert.ThrowsException<ArgumentNullException>(() =>
            {
                new DocScanClient(_sdkId, keyPair: null);
            });

            Assert.IsTrue(exception.Message.Contains("keyPair"));
        }

        [TestMethod]
        public void ShouldFailForInvalidKeyPair()
        {
            Assert.ThrowsException<FormatException>(() =>
            {
                new DocScanClient(_sdkId, KeyPair.GetInvalidFormatKeyStream());
            });
        }

        [TestMethod]
        public void CreateSessionShouldSucceed()
        {
            string clientSessionToken = "e8b1c85f-f9e7-405b-88eb-f1c318371f16";
            int clientSessionTokenTtl = 500;
            string sessionId = "4edd81c4-c612-4b0c-b385-7c90f0de6845";

            CreateSessionResult createSessionResult = new CreateSessionResult
            {
                ClientSessionToken = clientSessionToken,
                ClientSessionTokenTtl = clientSessionTokenTtl,
                SessionId = sessionId
            };

            string jsonResponse = JsonConvert.SerializeObject(createSessionResult);

            var successResponse = new HttpResponseMessage
            {
                StatusCode = HttpStatusCode.OK,
                Content = new StringContent(jsonResponse),
            };

            Mock<HttpMessageHandler> handlerMock = Auth.Tests.Common.Http.SetupMockMessageHandler(successResponse);
            var httpClient = new HttpClient(handlerMock.Object);

            DocScanClient docScanClient = new DocScanClient(_sdkId, _keyPair, httpClient);

            CreateSessionResult result = docScanClient.CreateSession(
                new SessionSpecificationBuilder().Build());

            Assert.AreEqual(clientSessionToken, result.ClientSessionToken);
            Assert.AreEqual(clientSessionTokenTtl, result.ClientSessionTokenTtl);
            Assert.AreEqual(sessionId, result.SessionId);
        }

        [DataTestMethod]
        [DataRow(HttpStatusCode.BadRequest)]
        [DataRow(HttpStatusCode.Unauthorized)]
        [DataRow(HttpStatusCode.InternalServerError)]
        [DataRow(HttpStatusCode.RequestTimeout)]
        [DataRow(HttpStatusCode.NotFound)]
        [DataRow(HttpStatusCode.Forbidden)]
        public void CreateSessionShouldThrowForNonSuccessStatusCode(HttpStatusCode httpStatusCode)
        {
            DocScanClient docScanClient = SetupDocScanClientResponse(httpStatusCode);

            var aggregateException = Assert.ThrowsException<AggregateException>(() =>
            {
                CreateSessionResult result = docScanClient.CreateSession(
                    new SessionSpecificationBuilder().Build());
            });

            Assert.IsTrue(TestTools.Exceptions.IsExceptionInAggregateException<DocScanException>(aggregateException));
        }

        [DataTestMethod]
        [DataRow(HttpStatusCode.BadRequest)]
        [DataRow(HttpStatusCode.Unauthorized)]
        [DataRow(HttpStatusCode.InternalServerError)]
        [DataRow(HttpStatusCode.RequestTimeout)]
        [DataRow(HttpStatusCode.NotFound)]
        [DataRow(HttpStatusCode.Forbidden)]
        public void DeleteMediaContentShouldThrowForNonSuccessStatusCode(HttpStatusCode httpStatusCode)
        {
            DocScanClient docScanClient = SetupDocScanClientResponse(httpStatusCode);

            var aggregateException = Assert.ThrowsException<AggregateException>(() =>
            {
                docScanClient.DeleteMediaContent("someSessionId", "someMediaId");
            });

            Assert.IsTrue(TestTools.Exceptions.IsExceptionInAggregateException<DocScanException>(aggregateException));
        }

        [DataTestMethod]
        [DataRow(HttpStatusCode.BadRequest)]
        [DataRow(HttpStatusCode.Unauthorized)]
        [DataRow(HttpStatusCode.InternalServerError)]
        [DataRow(HttpStatusCode.RequestTimeout)]
        [DataRow(HttpStatusCode.NotFound)]
        [DataRow(HttpStatusCode.Forbidden)]
        public void DeleteMediaContentAsyncShouldThrowForNonSuccessStatusCode(HttpStatusCode httpStatusCode)
        {
            DocScanClient docScanClient = SetupDocScanClientResponse(httpStatusCode);

            Assert.ThrowsExceptionAsync<DocScanException>(async () =>
            {
                await docScanClient.DeleteMediaContentAsync("someSessionId", "someMediaId");
            });
        }

        [DataTestMethod]
        [DataRow(HttpStatusCode.BadRequest)]
        [DataRow(HttpStatusCode.Unauthorized)]
        [DataRow(HttpStatusCode.InternalServerError)]
        [DataRow(HttpStatusCode.RequestTimeout)]
        [DataRow(HttpStatusCode.NotFound)]
        [DataRow(HttpStatusCode.Forbidden)]
        public void DeleteSessionShouldThrowForNonSuccessStatusCode(HttpStatusCode httpStatusCode)
        {
            DocScanClient docScanClient = SetupDocScanClientResponse(httpStatusCode);

            var aggregateException = Assert.ThrowsException<AggregateException>(() =>
            {
                docScanClient.DeleteSession("someSessionId");
            });

            Assert.IsTrue(TestTools.Exceptions.IsExceptionInAggregateException<DocScanException>(aggregateException));
        }

        [DataTestMethod]
        [DataRow(HttpStatusCode.BadRequest)]
        [DataRow(HttpStatusCode.Unauthorized)]
        [DataRow(HttpStatusCode.InternalServerError)]
        [DataRow(HttpStatusCode.RequestTimeout)]
        [DataRow(HttpStatusCode.NotFound)]
        [DataRow(HttpStatusCode.Forbidden)]
        public void DeleteSessionAsyncShouldThrowForNonSuccessStatusCode(HttpStatusCode httpStatusCode)
        {
            DocScanClient docScanClient = SetupDocScanClientResponse(httpStatusCode);

            Assert.ThrowsExceptionAsync<DocScanException>(async () =>
            {
                await docScanClient.DeleteSessionAsync("someSessionId");
            });
        }

        [DataTestMethod]
        [DataRow(HttpStatusCode.BadRequest)]
        [DataRow(HttpStatusCode.Unauthorized)]
        [DataRow(HttpStatusCode.InternalServerError)]
        [DataRow(HttpStatusCode.RequestTimeout)]
        [DataRow(HttpStatusCode.NotFound)]
        [DataRow(HttpStatusCode.Forbidden)]
        public void GetMediaContentShouldThrowForNonSuccessStatusCode(HttpStatusCode httpStatusCode)
        {
            DocScanClient docScanClient = SetupDocScanClientResponse(httpStatusCode);

            var aggregateException = Assert.ThrowsException<AggregateException>(() =>
            {
                docScanClient.GetMediaContent("someSessionId", "someMediaId");
            });

            Assert.IsTrue(TestTools.Exceptions.IsExceptionInAggregateException<DocScanException>(aggregateException));
        }

        [DataTestMethod]
        [DataRow(HttpStatusCode.BadRequest)]
        [DataRow(HttpStatusCode.Unauthorized)]
        [DataRow(HttpStatusCode.InternalServerError)]
        [DataRow(HttpStatusCode.RequestTimeout)]
        [DataRow(HttpStatusCode.NotFound)]
        [DataRow(HttpStatusCode.Forbidden)]
        public void GetSessionShouldThrowForNonSuccessStatusCode(HttpStatusCode httpStatusCode)
        {
            DocScanClient docScanClient = SetupDocScanClientResponse(httpStatusCode);

            var aggregateException = Assert.ThrowsException<AggregateException>(() =>
            {
                docScanClient.GetSession("someSessionId");
            });

            Assert.IsTrue(TestTools.Exceptions.IsExceptionInAggregateException<DocScanException>(aggregateException));
        }

        [TestMethod]
        public void GetMediaContentShouldReturnMedia()
        {
            string contentTypeImageJpeg = "image/jpeg";

            byte[] imageBytes = Encoding.UTF8.GetBytes("image-body");
            var successResponse = new HttpResponseMessage
            {
                StatusCode = HttpStatusCode.OK,
                Content = new ByteArrayContent(imageBytes),
            };
            successResponse.Content.Headers.Add(Constants.Api.ContentTypeHeader, contentTypeImageJpeg);

            Mock<HttpMessageHandler> handlerMock = Auth.Tests.Common.Http.SetupMockMessageHandler(successResponse);
            var httpClient = new HttpClient(handlerMock.Object);

            DocScanClient docScanClient = new DocScanClient(_sdkId, _keyPair, httpClient);

            MediaValue mediaValue = docScanClient.GetMediaContent(_someSessionId, _someMediaId);

            Assert.IsTrue(imageBytes.SequenceEqual(mediaValue.GetContent()));
            Assert.AreEqual(contentTypeImageJpeg, mediaValue.GetMIMEType());
        }

        private DocScanClient SetupDocScanClientResponse(HttpStatusCode httpStatusCode)
        {
            var response = new HttpResponseMessage
            {
                StatusCode = httpStatusCode,
                Content = new StringContent("{}"),
            };

            Mock<HttpMessageHandler> handlerMock = Auth.Tests.Common.Http.SetupMockMessageHandler(response);
            var httpClient = new HttpClient(handlerMock.Object);

            return new DocScanClient(_sdkId, _keyPair, httpClient);
        }
    }
}