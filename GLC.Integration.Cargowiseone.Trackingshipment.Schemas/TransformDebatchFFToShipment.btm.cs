namespace GLC.Integration.Cargowiseone.Trackingshipment.Schemas {
    
    
    [Microsoft.XLANGs.BaseTypes.SchemaReference(@"GLC.Integration.Cargowiseone.Trackingshipment.Schemas.DebatchTrack", typeof(global::GLC.Integration.Cargowiseone.Trackingshipment.Schemas.DebatchTrack))]
    [Microsoft.XLANGs.BaseTypes.SchemaReference(@"GLC.Integration.CargowiseoneInboundCommon.Schemas.UniversalShipment", typeof(global::GLC.Integration.CargowiseoneInboundCommon.Schemas.UniversalShipment))]
    public sealed class TransformDebatchFFToShipment : global::Microsoft.XLANGs.BaseTypes.TransformBase {
        
        private const string _strMap = @"<?xml version=""1.0"" encoding=""utf-16""?>
<xsl:stylesheet xmlns:xsl=""http://www.w3.org/1999/XSL/Transform"" xmlns:msxsl=""urn:schemas-microsoft-com:xslt"" xmlns:var=""http://schemas.microsoft.com/BizTalk/2003/var"" exclude-result-prefixes=""msxsl var userCSharp"" version=""1.0""  xmlns:ns0=""http://www.cargowise.com/Schemas/Universal/2011/11""  xmlns:userCSharp=""http://schemas.microsoft.com/BizTalk/2003/userCSharp"">
  <xsl:output omit-xml-declaration=""yes"" method=""xml"" version=""1.0"" />
  <xsl:template match=""/"">
    <xsl:apply-templates select=""/Debatch_Tracking"" />
  </xsl:template>
  <xsl:template match=""/Debatch_Tracking"">
    <xsl:variable name=""var:v1"" select=""userCSharp:StringConcat(&quot;GDS&quot;)"" />
    <xsl:variable name=""var:v2"" select=""userCSharp:StringConcat(&quot;US&quot;)"" />
    <!--<xsl:variable name=""var:v3"" select=""userCSharp:StringConcat(&quot;GLCGDSTRN&quot;)"" />-->
    <!--PROD Value-->
    <xsl:variable name=""var:v3"" select=""userCSharp:StringConcat(&quot;GLCLAXLAX&quot;)"" />
    <xsl:variable name=""var:v4"" select=""userCSharp:StringConcat(&quot;GLC&quot;)"" />
    <!--<xsl:variable name=""var:v5"" select=""userCSharp:StringConcat(&quot;TRN&quot;)"" />-->
    <!--PROD Value-->
    <xsl:variable name=""var:v5"" select=""userCSharp:StringConcat(&quot;LAX&quot;)"" />
    <xsl:variable name=""var:v6"" select=""userCSharp:StringConcat(&quot;WarehouseOrder&quot;)"" />
    
    <xsl:variable name=""vartrackdocketid"">
      <xsl:for-each select=""TrackingDetails_Child2"">
        <xsl:if test=""userCSharp:getvalue()='0'"">
          <xsl:value-of select=""TrackingDetails_Child2_Child6/text()""/>
          <xsl:value-of select=""userCSharp:setvalue()""/>
        </xsl:if>        
      </xsl:for-each>
    </xsl:variable>

    <xsl:value-of select =""userCSharp:resetvalue()""/>
    
     <xsl:variable name=""vartrackorderNo"">
      <xsl:for-each select=""TrackingDetails_Child2"">
        <xsl:if test=""userCSharp:getvalue()='0'"">
          <xsl:value-of select=""TrackingDetails_Child2_Child1/text()""/>
          <xsl:value-of select=""userCSharp:setvalue()""/>
        </xsl:if>        
      </xsl:for-each>
    </xsl:variable>
   
    <xsl:value-of select =""userCSharp:resetvalue()""/>
    <ns0:UniversalShipment>
      <ns0:Shipment>
        <ns0:DataContext>
                   
          <ns0:Company>
            <ns0:Code>
              <xsl:value-of select=""$var:v1"" />
            </ns0:Code>
            <ns0:Country>
              <ns0:Code>
                <xsl:value-of select=""$var:v2"" />
              </ns0:Code>
            </ns0:Country>
          </ns0:Company>
          <ns0:DataProvider>
            <xsl:value-of select=""$var:v3"" />
          </ns0:DataProvider>
          <ns0:EnterpriseID>
            <xsl:value-of select=""$var:v4"" />
          </ns0:EnterpriseID>
          <EventBranch>
            <Code>LOS</Code>
          </EventBranch>
          <ns0:ServerID>
            <xsl:value-of select=""$var:v5"" />
          </ns0:ServerID>
          <ns0:DataTargetCollection>
            <ns0:DataTarget>
              <ns0:Type>WarehouseOrder</ns0:Type>
              <ns0:Key>
                <xsl:value-of select=""$vartrackdocketid""/>
            </ns0:Key>
            </ns0:DataTarget>
          </ns0:DataTargetCollection>
        </ns0:DataContext>
        
        <ns0:Order>

          <ns0:OrderNumber>
            <xsl:value-of select=""$vartrackorderNo""/>
            </ns0:OrderNumber>
          <ns0:Type>
            <ns0:Code>ORD</ns0:Code>
            <ns0:Description>ORDER</ns0:Description>
          </ns0:Type>
          <xsl:variable name=""var:v9"" select=""userCSharp:StringConcat(&quot;RED&quot;)"" />
          <ns0:Warehouse>
            <ns0:Code>
              <xsl:value-of select=""$var:v9"" />
            </ns0:Code>
            <ns0:Name>RED</ns0:Name>
          </ns0:Warehouse>
          <ns0:OrderLineCollection>
            <xsl:variable name=""var:v10"" select=""userCSharp:StringConcat(&quot;Complete&quot;)"" />
            <xsl:attribute name=""Content"">
              <xsl:value-of select=""$var:v10"" />
            </xsl:attribute>
            <xsl:for-each select=""TrackingDetails_Child2"">
              <ns0:OrderLine>
                <ns0:LineComment>
                  <xsl:value-of select=""TrackingDetails_Child2_Child2/text()"" />
                </ns0:LineComment>
                
                <ns0:OrderedQty>
                <xsl:value-of select=""TrackingDetails_Child2_Child7/text()"" />
                </ns0:OrderedQty>
                
                <ns0:Product>
                  <ns0:Code>
                    <xsl:value-of select=""TrackingDetails_Child2_Child5/text()"" />
                  </ns0:Code>
                </ns0:Product>
                
               <ns0:CustomizedFieldCollection>                     
                      <ns0:CustomizedField>
                        <ns0:Key>NETSUITEIDVN</ns0:Key>
                        <ns0:DataType>String</ns0:DataType>
                        <ns0:Value>
                          <xsl:value-of select=""TrackingDetails_Child2_Child8/text()"" />
                        </ns0:Value>
                      </ns0:CustomizedField>                      
                      
                    </ns0:CustomizedFieldCollection>
               
              </ns0:OrderLine>
            </xsl:for-each>

          </ns0:OrderLineCollection>
        </ns0:Order>

       
      </ns0:Shipment>


    </ns0:UniversalShipment>
  </xsl:template>
  <msxsl:script language=""C#"" implements-prefix=""userCSharp"">
    <![CDATA[     
  
  public int a=0;
  
  public string getvalue()
  {
    return a.ToString();
  }

  public void setvalue()
    {
      a=1;
      }
  public void resetvalue()
    {
      a=0;
      }
  
  public string Replacefun(string strin)    {     strin=strin.Replace("","","""");     return strin;    }    public string StringConcat(string param0){   return param0;}
  public string DateimeConversion(string strin)            
  {                        DateTime strdatetime = new DateTime();
                           string strin1 = strin.Substring(2, 2) + ""/"" + strin.Substring(0, 2) + ""/"" + strin.Substring(4, 4);
                          strdatetime = DateTime.Parse(strin1);            
                          strin = strdatetime.ToString(""yyyy-MM-ddTHH:mm:ss"");            
                          return strin;             
                          }
                          public bool LogicalEq(string val1, string val2){bool ret = false;double d1 = 0;double d2 = 0;if (IsNumeric(val1, ref d1) && IsNumeric(val2, ref d2)){ret = d1 == d2;}else{ret = String.Compare(val1, val2, StringComparison.Ordinal) == 0;}return ret;}public bool IsNumeric(string val){if (val == null){return false;}double d = 0;return Double.TryParse(val, System.Globalization.NumberStyles.AllowThousands | System.Globalization.NumberStyles.Float, System.Globalization.CultureInfo.InvariantCulture, out d);}public bool IsNumeric(string val, ref double d){if (val == null){return false;}return Double.TryParse(val, System.Globalization.NumberStyles.AllowThousands | System.Globalization.NumberStyles.Float, System.Globalization.CultureInfo.InvariantCulture, out d);}
  ]]>
  </msxsl:script>
</xsl:stylesheet>";
        
        private const int _useXSLTransform = 0;
        
        private const string _strArgList = @"<ExtensionObjects />";
        
        private const string _strSrcSchemasList0 = @"GLC.Integration.Cargowiseone.Trackingshipment.Schemas.DebatchTrack";
        
        private const global::GLC.Integration.Cargowiseone.Trackingshipment.Schemas.DebatchTrack _srcSchemaTypeReference0 = null;
        
        private const string _strTrgSchemasList0 = @"GLC.Integration.CargowiseoneInboundCommon.Schemas.UniversalShipment";
        
        private const global::GLC.Integration.CargowiseoneInboundCommon.Schemas.UniversalShipment _trgSchemaTypeReference0 = null;
        
        public override string XmlContent {
            get {
                return _strMap;
            }
        }
        
        public override int UseXSLTransform {
            get {
                return _useXSLTransform;
            }
        }
        
        public override string XsltArgumentListContent {
            get {
                return _strArgList;
            }
        }
        
        public override string[] SourceSchemas {
            get {
                string[] _SrcSchemas = new string [1];
                _SrcSchemas[0] = @"GLC.Integration.Cargowiseone.Trackingshipment.Schemas.DebatchTrack";
                return _SrcSchemas;
            }
        }
        
        public override string[] TargetSchemas {
            get {
                string[] _TrgSchemas = new string [1];
                _TrgSchemas[0] = @"GLC.Integration.CargowiseoneInboundCommon.Schemas.UniversalShipment";
                return _TrgSchemas;
            }
        }
    }
}
