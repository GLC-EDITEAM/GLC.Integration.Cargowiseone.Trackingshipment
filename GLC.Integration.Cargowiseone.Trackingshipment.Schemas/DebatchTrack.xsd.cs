namespace GLC.Integration.Cargowiseone.Trackingshipment.Schemas {
    using Microsoft.XLANGs.BaseTypes;
    
    
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.BizTalk.Schema.Compiler", "3.0.1.0")]
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    [SchemaType(SchemaTypeEnum.Document)]
    [Schema(@"",@"Debatch_Tracking")]
    [System.SerializableAttribute()]
    [SchemaRoots(new string[] {@"Debatch_Tracking"})]
    public sealed class DebatchTrack : Microsoft.XLANGs.BaseTypes.SchemaBase {
        
        [System.NonSerializedAttribute()]
        private static object _rawSchema;
        
        [System.NonSerializedAttribute()]
        private const string _strSchema = @"<?xml version=""1.0"" encoding=""utf-16""?>
<xs:schema xmlns:b=""http://schemas.microsoft.com/BizTalk/2003"" attributeFormDefault=""unqualified"" elementFormDefault=""qualified"" xmlns:xs=""http://www.w3.org/2001/XMLSchema"">
  <xs:element name=""Debatch_Tracking"">
    <xs:complexType>
      <xs:sequence>
        <xs:element maxOccurs=""unbounded"" name=""TrackingDetails_Child2"">
          <xs:complexType>
            <xs:sequence>
              <xs:element name=""TrackingDetails_Child2_Child1"" type=""xs:string"" />
              <xs:element name=""TrackingDetails_Child2_Child2"" type=""xs:double"" />
              <xs:element name=""TrackingDetails_Child2_Child3"" type=""xs:string"" />
              <xs:element name=""TrackingDetails_Child2_Child4"" type=""xs:string"" />
              <xs:element name=""TrackingDetails_Child2_Child5"" type=""xs:string"" />
              <xs:element name=""TrackingDetails_Child2_Child6"" type=""xs:string"" />
              <xs:element name=""TrackingDetails_Child2_Child7"" type=""xs:string"" />
              <xs:element name=""TrackingDetails_Child2_Child8"" type=""xs:string"" />
            </xs:sequence>
          </xs:complexType>
        </xs:element>
      </xs:sequence>
    </xs:complexType>
  </xs:element>
</xs:schema>";
        
        public DebatchTrack() {
        }
        
        public override string XmlContent {
            get {
                return _strSchema;
            }
        }
        
        public override string[] RootNodes {
            get {
                string[] _RootElements = new string [1];
                _RootElements[0] = "Debatch_Tracking";
                return _RootElements;
            }
        }
        
        protected override object RawSchema {
            get {
                return _rawSchema;
            }
            set {
                _rawSchema = value;
            }
        }
    }
}
