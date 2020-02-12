// <auto-generated>
//     Generated by the protocol buffer compiler.  DO NOT EDIT!
//     source: IssuingAttributes.proto
// </auto-generated>
#pragma warning disable 1591, 0612, 3021
#region Designer generated code

using pb = global::Google.Protobuf;
using pbc = global::Google.Protobuf.Collections;
using pbr = global::Google.Protobuf.Reflection;
using scg = global::System.Collections.Generic;
namespace Yoti.Auth.ProtoBuf.Share {

  /// <summary>Holder for reflection information generated from IssuingAttributes.proto</summary>
  public static partial class IssuingAttributesReflection {

    #region Descriptor
    /// <summary>File descriptor for IssuingAttributes.proto</summary>
    public static pbr::FileDescriptor Descriptor {
      get { return descriptor; }
    }
    private static pbr::FileDescriptor descriptor;

    static IssuingAttributesReflection() {
      byte[] descriptorData = global::System.Convert.FromBase64String(
          string.Concat(
            "ChdJc3N1aW5nQXR0cmlidXRlcy5wcm90bxIOc2hhcmVwdWJhcGlfdjEiWQoR",
            "SXNzdWluZ0F0dHJpYnV0ZXMSEwoLZXhwaXJ5X2RhdGUYASABKAkSLwoLZGVm",
            "aW5pdGlvbnMYAiADKAsyGi5zaGFyZXB1YmFwaV92MS5EZWZpbml0aW9uIhoK",
            "CkRlZmluaXRpb24SDAoEbmFtZRgBIAEoCUK3AQokY29tLnlvdGkuYXBpLmNs",
            "aWVudC5zcGkucmVtb3RlLnByb3RvQhZJc3N1aW5nQXR0cmlidXRlc1Byb3Rv",
            "Wg55b3RpcHJvdG9zaGFyZaoCGFlvdGkuQXV0aC5Qcm90b0J1Zi5TaGFyZcoC",
            "EFlvdGlcU2hhcmVwdWJhcGniAhxZb3RpXFNoYXJlcHViYXBpXEdQQk1ldGFk",
            "YXRh6gIZWW90aS5Qcm90b2J1Zi5TaGFyZXB1YmFwaWIGcHJvdG8z"));
      descriptor = pbr::FileDescriptor.FromGeneratedCode(descriptorData,
          new pbr::FileDescriptor[] { },
          new pbr::GeneratedClrTypeInfo(null, new pbr::GeneratedClrTypeInfo[] {
            new pbr::GeneratedClrTypeInfo(typeof(global::Yoti.Auth.ProtoBuf.Share.IssuingAttributes), global::Yoti.Auth.ProtoBuf.Share.IssuingAttributes.Parser, new[]{ "ExpiryDate", "Definitions" }, null, null, null),
            new pbr::GeneratedClrTypeInfo(typeof(global::Yoti.Auth.ProtoBuf.Share.Definition), global::Yoti.Auth.ProtoBuf.Share.Definition.Parser, new[]{ "Name" }, null, null, null)
          }));
    }
    #endregion

  }
  #region Messages
  public sealed partial class IssuingAttributes : pb::IMessage<IssuingAttributes> {
    private static readonly pb::MessageParser<IssuingAttributes> _parser = new pb::MessageParser<IssuingAttributes>(() => new IssuingAttributes());
    private pb::UnknownFieldSet _unknownFields;
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public static pb::MessageParser<IssuingAttributes> Parser { get { return _parser; } }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public static pbr::MessageDescriptor Descriptor {
      get { return global::Yoti.Auth.ProtoBuf.Share.IssuingAttributesReflection.Descriptor.MessageTypes[0]; }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    pbr::MessageDescriptor pb::IMessage.Descriptor {
      get { return Descriptor; }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public IssuingAttributes() {
      OnConstruction();
    }

    partial void OnConstruction();

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public IssuingAttributes(IssuingAttributes other) : this() {
      expiryDate_ = other.expiryDate_;
      definitions_ = other.definitions_.Clone();
      _unknownFields = pb::UnknownFieldSet.Clone(other._unknownFields);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public IssuingAttributes Clone() {
      return new IssuingAttributes(this);
    }

    /// <summary>Field number for the "expiry_date" field.</summary>
    public const int ExpiryDateFieldNumber = 1;
    private string expiryDate_ = "";
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public string ExpiryDate {
      get { return expiryDate_; }
      set {
        expiryDate_ = pb::ProtoPreconditions.CheckNotNull(value, "value");
      }
    }

    /// <summary>Field number for the "definitions" field.</summary>
    public const int DefinitionsFieldNumber = 2;
    private static readonly pb::FieldCodec<global::Yoti.Auth.ProtoBuf.Share.Definition> _repeated_definitions_codec
        = pb::FieldCodec.ForMessage(18, global::Yoti.Auth.ProtoBuf.Share.Definition.Parser);
    private readonly pbc::RepeatedField<global::Yoti.Auth.ProtoBuf.Share.Definition> definitions_ = new pbc::RepeatedField<global::Yoti.Auth.ProtoBuf.Share.Definition>();
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public pbc::RepeatedField<global::Yoti.Auth.ProtoBuf.Share.Definition> Definitions {
      get { return definitions_; }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public override bool Equals(object other) {
      return Equals(other as IssuingAttributes);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public bool Equals(IssuingAttributes other) {
      if (ReferenceEquals(other, null)) {
        return false;
      }
      if (ReferenceEquals(other, this)) {
        return true;
      }
      if (ExpiryDate != other.ExpiryDate) return false;
      if(!definitions_.Equals(other.definitions_)) return false;
      return Equals(_unknownFields, other._unknownFields);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public override int GetHashCode() {
      int hash = 1;
      if (ExpiryDate.Length != 0) hash ^= ExpiryDate.GetHashCode();
      hash ^= definitions_.GetHashCode();
      if (_unknownFields != null) {
        hash ^= _unknownFields.GetHashCode();
      }
      return hash;
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public override string ToString() {
      return pb::JsonFormatter.ToDiagnosticString(this);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public void WriteTo(pb::CodedOutputStream output) {
      if (ExpiryDate.Length != 0) {
        output.WriteRawTag(10);
        output.WriteString(ExpiryDate);
      }
      definitions_.WriteTo(output, _repeated_definitions_codec);
      if (_unknownFields != null) {
        _unknownFields.WriteTo(output);
      }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public int CalculateSize() {
      int size = 0;
      if (ExpiryDate.Length != 0) {
        size += 1 + pb::CodedOutputStream.ComputeStringSize(ExpiryDate);
      }
      size += definitions_.CalculateSize(_repeated_definitions_codec);
      if (_unknownFields != null) {
        size += _unknownFields.CalculateSize();
      }
      return size;
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public void MergeFrom(IssuingAttributes other) {
      if (other == null) {
        return;
      }
      if (other.ExpiryDate.Length != 0) {
        ExpiryDate = other.ExpiryDate;
      }
      definitions_.Add(other.definitions_);
      _unknownFields = pb::UnknownFieldSet.MergeFrom(_unknownFields, other._unknownFields);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public void MergeFrom(pb::CodedInputStream input) {
      uint tag;
      while ((tag = input.ReadTag()) != 0) {
        switch(tag) {
          default:
            _unknownFields = pb::UnknownFieldSet.MergeFieldFrom(_unknownFields, input);
            break;
          case 10: {
            ExpiryDate = input.ReadString();
            break;
          }
          case 18: {
            definitions_.AddEntriesFrom(input, _repeated_definitions_codec);
            break;
          }
        }
      }
    }

  }

  public sealed partial class Definition : pb::IMessage<Definition> {
    private static readonly pb::MessageParser<Definition> _parser = new pb::MessageParser<Definition>(() => new Definition());
    private pb::UnknownFieldSet _unknownFields;
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public static pb::MessageParser<Definition> Parser { get { return _parser; } }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public static pbr::MessageDescriptor Descriptor {
      get { return global::Yoti.Auth.ProtoBuf.Share.IssuingAttributesReflection.Descriptor.MessageTypes[1]; }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    pbr::MessageDescriptor pb::IMessage.Descriptor {
      get { return Descriptor; }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public Definition() {
      OnConstruction();
    }

    partial void OnConstruction();

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public Definition(Definition other) : this() {
      name_ = other.name_;
      _unknownFields = pb::UnknownFieldSet.Clone(other._unknownFields);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public Definition Clone() {
      return new Definition(this);
    }

    /// <summary>Field number for the "name" field.</summary>
    public const int NameFieldNumber = 1;
    private string name_ = "";
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public string Name {
      get { return name_; }
      set {
        name_ = pb::ProtoPreconditions.CheckNotNull(value, "value");
      }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public override bool Equals(object other) {
      return Equals(other as Definition);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public bool Equals(Definition other) {
      if (ReferenceEquals(other, null)) {
        return false;
      }
      if (ReferenceEquals(other, this)) {
        return true;
      }
      if (Name != other.Name) return false;
      return Equals(_unknownFields, other._unknownFields);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public override int GetHashCode() {
      int hash = 1;
      if (Name.Length != 0) hash ^= Name.GetHashCode();
      if (_unknownFields != null) {
        hash ^= _unknownFields.GetHashCode();
      }
      return hash;
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public override string ToString() {
      return pb::JsonFormatter.ToDiagnosticString(this);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public void WriteTo(pb::CodedOutputStream output) {
      if (Name.Length != 0) {
        output.WriteRawTag(10);
        output.WriteString(Name);
      }
      if (_unknownFields != null) {
        _unknownFields.WriteTo(output);
      }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public int CalculateSize() {
      int size = 0;
      if (Name.Length != 0) {
        size += 1 + pb::CodedOutputStream.ComputeStringSize(Name);
      }
      if (_unknownFields != null) {
        size += _unknownFields.CalculateSize();
      }
      return size;
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public void MergeFrom(Definition other) {
      if (other == null) {
        return;
      }
      if (other.Name.Length != 0) {
        Name = other.Name;
      }
      _unknownFields = pb::UnknownFieldSet.MergeFrom(_unknownFields, other._unknownFields);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public void MergeFrom(pb::CodedInputStream input) {
      uint tag;
      while ((tag = input.ReadTag()) != 0) {
        switch(tag) {
          default:
            _unknownFields = pb::UnknownFieldSet.MergeFieldFrom(_unknownFields, input);
            break;
          case 10: {
            Name = input.ReadString();
            break;
          }
        }
      }
    }

  }

  #endregion

}

#endregion Designer generated code