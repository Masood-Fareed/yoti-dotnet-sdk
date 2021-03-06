﻿using Google.Protobuf;
using Yoti.Auth.ProtoBuf.Attribute;

namespace Yoti.Auth.Tests.TestTools
{
    internal static class Attributes
    {
        public static ProtoBuf.Attribute.Attribute CreateProtobufAttributeFromRawAnchor(string rawAnchor)
        {
            byte[] attributeBytes = Conversion.Base64ToBytes(rawAnchor);
            return ProtoBuf.Attribute.Attribute.Parser.ParseFrom(attributeBytes);
        }

        public static ProtoBuf.Attribute.Attribute CreateMultiValueAttribute(string multiValueAttributeName, ContentType innerContentType, ByteString value)
        {
            var outerValue = new MultiValue.Types.Value
            {
                ContentType = innerContentType,
                Data = value
            };

            var multiValue = new MultiValue();
            multiValue.Values.Add(outerValue);

            var attribute = new ProtoBuf.Attribute.Attribute
            {
                Name = multiValueAttributeName,
                ContentType = ContentType.MultiValue,
                Value = multiValue.ToByteString()
            };
            return attribute;
        }
    }
}