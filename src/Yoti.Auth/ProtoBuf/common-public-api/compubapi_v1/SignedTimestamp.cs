// <auto-generated>
// Generated by the protocol buffer compiler.  DO NOT EDIT!
// source: SignedTimestamp.proto
// </auto-generated>

#region Designer generated code

using pb = global::Google.Protobuf;
using pbr = global::Google.Protobuf.Reflection;

namespace CompubapiV1
{
    /// <summary>Holder for reflection information generated from SignedTimestamp.proto</summary>
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
    public static partial class SignedTimestampReflection
    {
        #region Descriptor

        /// <summary>File descriptor for SignedTimestamp.proto</summary>
        public static pbr::FileDescriptor Descriptor
        {
            get { return descriptor; }
        }

        private static pbr::FileDescriptor descriptor;

        static SignedTimestampReflection()
        {
            byte[] descriptorData = global::System.Convert.FromBase64String(
                string.Concat(
                  "ChVTaWduZWRUaW1lc3RhbXAucHJvdG8SDGNvbXB1YmFwaV92MSKbAQoPU2ln",
                  "bmVkVGltZXN0YW1wEg8KB3ZlcnNpb24YASABKAUSEQoJdGltZXN0YW1wGAIg",
                  "ASgEEhYKDm1lc3NhZ2VfZGlnZXN0GAMgASgMEhQKDGNoYWluX2RpZ2VzdBgE",
                  "IAEoDBIaChJjaGFpbl9kaWdlc3Rfc2tpcDEYBSABKAwSGgoSY2hhaW5fZGln",
                  "ZXN0X3NraXAyGAYgASgMQi0KFWNvbS55b3RpLmNvbXB1YmFwaV92MUIUU2ln",
                  "bmVkVGltZXN0YW1wUHJvdG9iBnByb3RvMw=="));
            descriptor = pbr::FileDescriptor.FromGeneratedCode(descriptorData,
                new pbr::FileDescriptor[] { },
                new pbr::GeneratedClrTypeInfo(null, new pbr::GeneratedClrTypeInfo[] {
            new pbr::GeneratedClrTypeInfo(typeof(global::CompubapiV1.SignedTimestamp), global::CompubapiV1.SignedTimestamp.Parser, new[]{ "Version", "Timestamp", "MessageDigest", "ChainDigest", "ChainDigestSkip1", "ChainDigestSkip2" }, null, null, null)
                }));
        }

        #endregion Descriptor
    }

    #region Messages

    /// <summary>
    ///  SignedTimestamp is a timestamp associated with a message that has a
    ///  cryptographic signature proving that it was issued by the correct authority.
    /// </summary>
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
    public sealed partial class SignedTimestamp : pb::IMessage<SignedTimestamp>
    {
        private static readonly pb::MessageParser<SignedTimestamp> _parser = new pb::MessageParser<SignedTimestamp>(() => new SignedTimestamp());
        public static pb::MessageParser<SignedTimestamp> Parser { get { return _parser; } }

        public static pbr::MessageDescriptor Descriptor
        {
            get { return global::CompubapiV1.SignedTimestampReflection.Descriptor.MessageTypes[0]; }
        }

        pbr::MessageDescriptor pb::IMessage.Descriptor
        {
            get { return Descriptor; }
        }

        public SignedTimestamp()
        {
            OnConstruction();
        }

        partial void OnConstruction();

        public SignedTimestamp(SignedTimestamp other) : this()
        {
            version_ = other.version_;
            timestamp_ = other.timestamp_;
            messageDigest_ = other.messageDigest_;
            chainDigest_ = other.chainDigest_;
            chainDigestSkip1_ = other.chainDigestSkip1_;
            chainDigestSkip2_ = other.chainDigestSkip2_;
        }

        public SignedTimestamp Clone()
        {
            return new SignedTimestamp(this);
        }

        /// <summary>Field number for the "version" field.</summary>
        public const int VersionFieldNumber = 1;

        private int version_;

        /// <summary>
        ///  Version indicates how the digests within this object are calculated.
        /// </summary>
        public int Version
        {
            get { return version_; }
            set
            {
                version_ = value;
            }
        }

        /// <summary>Field number for the "timestamp" field.</summary>
        public const int TimestampFieldNumber = 2;

        private ulong timestamp_;

        /// <summary>
        ///  Timestamp is the time this SignedTimestamp was issued. It is in UTC,
        ///  as µseconds elapsed since the epoch (µs from 1970-01-01T00:00:00Z).
        /// </summary>
        public ulong Timestamp
        {
            get { return timestamp_; }
            set
            {
                timestamp_ = value;
            }
        }

        /// <summary>Field number for the "message_digest" field.</summary>
        public const int MessageDigestFieldNumber = 3;

        private pb::ByteString messageDigest_ = pb::ByteString.Empty;

        /// <summary>
        ///  MessageDigest is the digest of the message this timestamp is
        ///  associated with. The first step in verifying the timestamp is
        ///  ensuring the MessageDigest matches the original message data.
        ///
        ///  For version 1 objects, the message digest algorithm is SHA-512/224.
        /// </summary>
        public pb::ByteString MessageDigest
        {
            get { return messageDigest_; }
            set
            {
                messageDigest_ = pb::ProtoPreconditions.CheckNotNull(value, "value");
            }
        }

        /// <summary>Field number for the "chain_digest" field.</summary>
        public const int ChainDigestFieldNumber = 4;

        private pb::ByteString chainDigest_ = pb::ByteString.Empty;

        /// <summary>
        ///  ChainDigest is the digest of the previous SignedTimestamp message
        ///  in the chain. The second step in verifying the timestamp is walking
        ///  back over the chain and checking each SignedTimestamp's ChainDigest
        ///  field. The SignedTimestamp at the beginning of the chain has this
        ///  field set to a specific, publish value.
        ///
        ///  For version 1 objects, the chain digest algorithm is HMAC-SHA-512/224,
        ///  with the secret being equal to the MessageDigest field.
        /// </summary>
        public pb::ByteString ChainDigest
        {
            get { return chainDigest_; }
            set
            {
                chainDigest_ = pb::ProtoPreconditions.CheckNotNull(value, "value");
            }
        }

        /// <summary>Field number for the "chain_digest_skip1" field.</summary>
        public const int ChainDigestSkip1FieldNumber = 5;

        private pb::ByteString chainDigestSkip1_ = pb::ByteString.Empty;

        /// <summary>
        ///  ChainDigestSkip1 is only populated once every 500 nodes. It is the
        ///  ChainDigest value of the timestamp 500 nodes previously.
        /// </summary>
        public pb::ByteString ChainDigestSkip1
        {
            get { return chainDigestSkip1_; }
            set
            {
                chainDigestSkip1_ = pb::ProtoPreconditions.CheckNotNull(value, "value");
            }
        }

        /// <summary>Field number for the "chain_digest_skip2" field.</summary>
        public const int ChainDigestSkip2FieldNumber = 6;

        private pb::ByteString chainDigestSkip2_ = pb::ByteString.Empty;

        /// <summary>
        ///  ChainDigestSkip2 is only populated once every 250000 nodes (or once
        ///  every 500 nodes that have ChainDigestSkip1 populated). It is the
        ///  ChainDigest value of the timestamp 250000 nodes previously.
        /// </summary>
        public pb::ByteString ChainDigestSkip2
        {
            get { return chainDigestSkip2_; }
            set
            {
                chainDigestSkip2_ = pb::ProtoPreconditions.CheckNotNull(value, "value");
            }
        }

        public override bool Equals(object other)
        {
            return Equals(other as SignedTimestamp);
        }

        public bool Equals(SignedTimestamp other)
        {
            if (ReferenceEquals(other, null))
            {
                return false;
            }
            if (ReferenceEquals(other, this))
            {
                return true;
            }
            if (Version != other.Version) return false;
            if (Timestamp != other.Timestamp) return false;
            if (MessageDigest != other.MessageDigest) return false;
            if (ChainDigest != other.ChainDigest) return false;
            if (ChainDigestSkip1 != other.ChainDigestSkip1) return false;
            if (ChainDigestSkip2 != other.ChainDigestSkip2) return false;
            return true;
        }

        public override int GetHashCode()
        {
            int hash = 1;
            if (Version != 0) hash ^= Version.GetHashCode();
            if (Timestamp != 0UL) hash ^= Timestamp.GetHashCode();
            if (MessageDigest.Length != 0) hash ^= MessageDigest.GetHashCode();
            if (ChainDigest.Length != 0) hash ^= ChainDigest.GetHashCode();
            if (ChainDigestSkip1.Length != 0) hash ^= ChainDigestSkip1.GetHashCode();
            if (ChainDigestSkip2.Length != 0) hash ^= ChainDigestSkip2.GetHashCode();
            return hash;
        }

        public override string ToString()
        {
            return pb::JsonFormatter.ToDiagnosticString(this);
        }

        public void WriteTo(pb::CodedOutputStream output)
        {
            if (Version != 0)
            {
                output.WriteRawTag(8);
                output.WriteInt32(Version);
            }
            if (Timestamp != 0UL)
            {
                output.WriteRawTag(16);
                output.WriteUInt64(Timestamp);
            }
            if (MessageDigest.Length != 0)
            {
                output.WriteRawTag(26);
                output.WriteBytes(MessageDigest);
            }
            if (ChainDigest.Length != 0)
            {
                output.WriteRawTag(34);
                output.WriteBytes(ChainDigest);
            }
            if (ChainDigestSkip1.Length != 0)
            {
                output.WriteRawTag(42);
                output.WriteBytes(ChainDigestSkip1);
            }
            if (ChainDigestSkip2.Length != 0)
            {
                output.WriteRawTag(50);
                output.WriteBytes(ChainDigestSkip2);
            }
        }

        public int CalculateSize()
        {
            int size = 0;
            if (Version != 0)
            {
                size += 1 + pb::CodedOutputStream.ComputeInt32Size(Version);
            }
            if (Timestamp != 0UL)
            {
                size += 1 + pb::CodedOutputStream.ComputeUInt64Size(Timestamp);
            }
            if (MessageDigest.Length != 0)
            {
                size += 1 + pb::CodedOutputStream.ComputeBytesSize(MessageDigest);
            }
            if (ChainDigest.Length != 0)
            {
                size += 1 + pb::CodedOutputStream.ComputeBytesSize(ChainDigest);
            }
            if (ChainDigestSkip1.Length != 0)
            {
                size += 1 + pb::CodedOutputStream.ComputeBytesSize(ChainDigestSkip1);
            }
            if (ChainDigestSkip2.Length != 0)
            {
                size += 1 + pb::CodedOutputStream.ComputeBytesSize(ChainDigestSkip2);
            }
            return size;
        }

        public void MergeFrom(SignedTimestamp other)
        {
            if (other == null)
            {
                return;
            }
            if (other.Version != 0)
            {
                Version = other.Version;
            }
            if (other.Timestamp != 0UL)
            {
                Timestamp = other.Timestamp;
            }
            if (other.MessageDigest.Length != 0)
            {
                MessageDigest = other.MessageDigest;
            }
            if (other.ChainDigest.Length != 0)
            {
                ChainDigest = other.ChainDigest;
            }
            if (other.ChainDigestSkip1.Length != 0)
            {
                ChainDigestSkip1 = other.ChainDigestSkip1;
            }
            if (other.ChainDigestSkip2.Length != 0)
            {
                ChainDigestSkip2 = other.ChainDigestSkip2;
            }
        }

        public void MergeFrom(pb::CodedInputStream input)
        {
            uint tag;
            while ((tag = input.ReadTag()) != 0)
            {
                switch (tag)
                {
                    default:
                        input.SkipLastField();
                        break;

                    case 8:
                        {
                            Version = input.ReadInt32();
                            break;
                        }
                    case 16:
                        {
                            Timestamp = input.ReadUInt64();
                            break;
                        }
                    case 26:
                        {
                            MessageDigest = input.ReadBytes();
                            break;
                        }
                    case 34:
                        {
                            ChainDigest = input.ReadBytes();
                            break;
                        }
                    case 42:
                        {
                            ChainDigestSkip1 = input.ReadBytes();
                            break;
                        }
                    case 50:
                        {
                            ChainDigestSkip2 = input.ReadBytes();
                            break;
                        }
                }
            }
        }
    }

    #endregion Messages
}

#endregion Designer generated code