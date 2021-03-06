﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Yoti.Auth.Properties {
    using System;
    using System.Reflection;
    
    
    /// <summary>
    ///   A strongly-typed resource class, for looking up localized strings, etc.
    /// </summary>
    // This class was auto-generated by the StronglyTypedResourceBuilder
    // class via a tool like ResGen or Visual Studio.
    // To add or remove a member, edit your .ResX file then rerun ResGen
    // with the /str option, or rebuild your VS project.
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Resources.Tools.StronglyTypedResourceBuilder", "16.0.0.0")]
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    internal class Resources {
        
        private static global::System.Resources.ResourceManager resourceMan;
        
        private static global::System.Globalization.CultureInfo resourceCulture;
        
        [global::System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        internal Resources() {
        }
        
        /// <summary>
        ///   Returns the cached ResourceManager instance used by this class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        internal static global::System.Resources.ResourceManager ResourceManager {
            get {
                if (object.ReferenceEquals(resourceMan, null)) {
                    global::System.Resources.ResourceManager temp = new global::System.Resources.ResourceManager("Yoti.Auth.Properties.Resources", typeof(Resources).GetTypeInfo().Assembly);
                    resourceMan = temp;
                }
                return resourceMan;
            }
        }
        
        /// <summary>
        ///   Overrides the current thread's CurrentUICulture property for all
        ///   resource lookups using this strongly typed resource class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        internal static global::System.Globalization.CultureInfo Culture {
            get {
                return resourceCulture;
            }
            set {
                resourceCulture = value;
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Unsupported/invalid data entry.
        /// </summary>
        internal static string DataEntryError {
            get {
                return ResourceManager.GetString("DataEntryError", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Failed to parse data entry.
        /// </summary>
        internal static string DataEntryParsingFail {
            get {
                return ResourceManager.GetString("DataEntryParsingFail", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Invalid Document Details value: multiple consecutive spaces.
        /// </summary>
        internal static string DocDetailsMultipleConsecutiveSpaces {
            get {
                return ResourceManager.GetString("DocDetailsMultipleConsecutiveSpaces", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Empty value is invalid for non-string content types.
        /// </summary>
        internal static string EmptyValueInvalid {
            get {
                return ResourceManager.GetString("EmptyValueInvalid", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to EndpointMustBeginWithSlash.
        /// </summary>
        internal static string EndpointMustBeginWithSlash {
            get {
                return ResourceManager.GetString("EndpointMustBeginWithSlash", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to does not match expected format:.
        /// </summary>
        internal static string FormatMismatch {
            get {
                return ResourceManager.GetString("FormatMismatch", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Unable to cast to DateTime.
        /// </summary>
        internal static string InvalidCastDateTime {
            get {
                return ResourceManager.GetString("InvalidCastDateTime", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Invalid DocumentDetails value.
        /// </summary>
        internal static string InvalidDocumentDetails {
            get {
                return ResourceManager.GetString("InvalidDocumentDetails", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to ThirdPartyAttribute issuance token is missing.
        /// </summary>
        internal static string IssuanceTokenMissing {
            get {
                return ResourceManager.GetString("IssuanceTokenMissing", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Cannot add a content header to a HTTP Request Message when content has not been set.
        /// </summary>
        internal static string NullHTTPContent {
            get {
                return ResourceManager.GetString("NullHTTPContent", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to The content of the response is null.
        /// </summary>
        internal static string NullOrEmptyResponseContent {
            get {
                return ResourceManager.GetString("NullOrEmptyResponseContent", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to The receipt of the parsed response is null.
        /// </summary>
        internal static string NullParsedResponse {
            get {
                return ResourceManager.GetString("NullParsedResponse", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Unsupported image type.
        /// </summary>
        internal static string UnsupportedImageType {
            get {
                return ResourceManager.GetString("UnsupportedImageType", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to The path must not be an Absolute URI, use Relative (UriKind.Relative).
        /// </summary>
        internal static string UseRelativePath {
            get {
                return ResourceManager.GetString("UseRelativePath", resourceCulture);
            }
        }
    }
}
