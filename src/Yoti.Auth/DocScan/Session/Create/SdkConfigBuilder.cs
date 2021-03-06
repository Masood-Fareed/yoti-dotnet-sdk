﻿using Yoti.Auth.Constants;

namespace Yoti.Auth.DocScan.Session.Create
{
    public class SdkConfigBuilder
    {
        private string _allowedCaptureMethods;
        private string _primaryColour;
        private string _secondaryColour;
        private string _fontColour;
        private string _locale;
        private string _presetIssuingCountry;
        private string _successUrl;
        private string _errorUrl;

        /// <summary>
        /// Sets the allowed capture method to "CAMERA"
        /// </summary>
        /// <returns>The <see cref="SdkConfigBuilder"/></returns>
        public SdkConfigBuilder WithAllowsCamera()
        {
            return WithAllowedCaptureMethods(DocScanConstants.Camera);
        }

        /// <summary>
        /// Sets the allowed capture method to "CAMERA_AND_UPLOAD"
        /// </summary>
        /// <returns>The <see cref="SdkConfigBuilder"/></returns>
        public SdkConfigBuilder WithAllowsCameraAndUpload()
        {
            return WithAllowedCaptureMethods(DocScanConstants.CameraAndUpload);
        }

        /// <summary>
        /// Sets the allowed capture method
        /// </summary>
        /// <param name="allowedCaptureMethods">capture method</param>
        /// <returns>The <see cref="SdkConfigBuilder"/></returns>
        public SdkConfigBuilder WithAllowedCaptureMethods(string allowedCaptureMethods)
        {
            _allowedCaptureMethods = allowedCaptureMethods;
            return this;
        }

        /// <summary>
        /// Sets the primary colour to be used by the web/native client
        /// </summary>
        /// <param name="primaryColour">the primary colour, hexadecimal value e.g. #ff0000</param>
        /// <returns>The <see cref="SdkConfigBuilder"/></returns>
        public SdkConfigBuilder WithPrimaryColour(string primaryColour)
        {
            _primaryColour = primaryColour;
            return this;
        }

        /// <summary>
        /// Sets the secondary colour to be used by the web/native client (used on the button)
        /// </summary>
        /// <param name="secondaryColour">the secondary colour, hexadecimal value e.g. #ff0000</param>
        /// <returns>The <see cref="SdkConfigBuilder"/></returns>
        public SdkConfigBuilder WithSecondaryColour(string secondaryColour)
        {
            _secondaryColour = secondaryColour;
            return this;
        }

        /// <summary>
        /// Sets the font colour to be used by the web/native client (used on the button)
        /// </summary>
        /// <param name="fontColour">the font colour, hexadecimal value e.g. #ff0000</param>
        /// <returns>The <see cref="SdkConfigBuilder"/></returns>
        public SdkConfigBuilder WithFontColour(string fontColour)
        {
            _fontColour = fontColour;
            return this;
        }

        /// <summary>
        /// Sets the language locale used by the web/native client
        /// </summary>
        /// <param name="locale">the locale, e.g. "en"</param>
        /// <returns>The <see cref="SdkConfigBuilder"/></returns>
        public SdkConfigBuilder WithLocale(string locale)
        {
            _locale = locale;
            return this;
        }

        /// <summary>
        /// Sets the preset issuing country used by the web/native client
        /// </summary>
        /// <param name="presetIssuingCountry">the preset issuing country, 3 letter ISO code e.g. "GBR"</param>
        /// <returns>The <see cref="SdkConfigBuilder"/></returns>
        public SdkConfigBuilder WithPresetIssuingCountry(string presetIssuingCountry)
        {
            _presetIssuingCountry = presetIssuingCountry;
            return this;
        }

        /// <summary>
        /// Sets the success URL for the redirect that follows the web/native client uploading documents successfully
        /// </summary>
        /// <param name="successUrl">The success URL</param>
        /// <returns>The <see cref="SdkConfigBuilder"/></returns>
        public SdkConfigBuilder WithSuccessUrl(string successUrl)
        {
            _successUrl = successUrl;
            return this;
        }

        /// <summary>
        /// Sets the error URL for the redirect that follows the web/native client uploading documents unsuccessfully
        /// </summary>
        /// <param name="errorUrl">The error URL</param>
        /// <returns>The <see cref="SdkConfigBuilder"/></returns>
        public SdkConfigBuilder WithErrorUrl(string errorUrl)
        {
            _errorUrl = errorUrl;
            return this;
        }

        /// <summary>
        /// Builds the <see cref="SdkConfig"/> based on values supplied to the builder
        /// </summary>
        /// <returns>The built <see cref="SdkConfig"/></returns>
        public SdkConfig Build()
        {
            return new SdkConfig(
                _allowedCaptureMethods,
                _primaryColour,
                _secondaryColour,
                _fontColour,
                _locale,
                _presetIssuingCountry,
                _successUrl,
                _errorUrl);
        }
    }
}