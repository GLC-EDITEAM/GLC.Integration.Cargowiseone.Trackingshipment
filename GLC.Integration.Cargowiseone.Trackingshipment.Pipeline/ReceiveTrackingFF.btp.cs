namespace GLC.Integration.Cargowiseone.Trackingshipment.Pipeline
{
    using System;
    using System.Collections.Generic;
    using Microsoft.BizTalk.PipelineOM;
    using Microsoft.BizTalk.Component;
    using Microsoft.BizTalk.Component.Interop;
    
    
    public sealed class ReceiveTrackingFF : Microsoft.BizTalk.PipelineOM.ReceivePipeline
    {
        
        private const string _strPipeline = "<?xml version=\"1.0\" encoding=\"utf-16\"?><Document xmlns:xsi=\"http://www.w3.org/2001/XMLSchema-instanc"+
"e\" xmlns:xsd=\"http://www.w3.org/2001/XMLSchema\" MajorVersion=\"1\" MinorVersion=\"0\">  <Description /> "+
" <CategoryId>f66b9f5e-43ff-4f5f-ba46-885348ae1b4e</CategoryId>  <FriendlyName>Receive</FriendlyName>"+
"  <Stages>    <Stage>      <PolicyFileStage _locAttrData=\"Name\" _locID=\"1\" Name=\"Decode\" minOccurs=\""+
"0\" maxOccurs=\"-1\" execMethod=\"All\" stageId=\"9d0e4103-4cce-4536-83fa-4a5040674ad6\" />      <Component"+
"s />    </Stage>    <Stage>      <PolicyFileStage _locAttrData=\"Name\" _locID=\"2\" Name=\"Disassemble\" "+
"minOccurs=\"0\" maxOccurs=\"-1\" execMethod=\"FirstMatch\" stageId=\"9d0e4105-4cce-4536-83fa-4a5040674ad6\" "+
"/>      <Components>        <Component>          <Name>Microsoft.BizTalk.Component.FFDasmComp,Micros"+
"oft.BizTalk.Pipeline.Components, Version=3.0.1.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35</"+
"Name>          <ComponentName>Flat file disassembler</ComponentName>          <Description>Streaming"+
" flat file disassembler component</Description>          <Version>1.0</Version>          <Properties"+
">            <Property Name=\"HeaderSpecName\" />            <Property Name=\"DocumentSpecName\">       "+
"       <Value xsi:type=\"xsd:string\">GLC.Integration.Cargowiseone.Trackingshipment.Schemas.TrackingFF"+
"Schema, GLC.Integration.Cargowiseone.Trackingshipment.Schemas, Version=1.0.0.0, Culture=neutral, Pub"+
"licKeyToken=db5dae54634e61c6</Value>            </Property>            <Property Name=\"TrailerSpecNa"+
"me\" />            <Property Name=\"PreserveHeader\">              <Value xsi:type=\"xsd:boolean\">false<"+
"/Value>            </Property>            <Property Name=\"ValidateDocumentStructure\">              <"+
"Value xsi:type=\"xsd:boolean\">false</Value>            </Property>            <Property Name=\"Recover"+
"ableInterchangeProcessing\">              <Value xsi:type=\"xsd:boolean\">false</Value>            </Pr"+
"operty>          </Properties>          <CachedDisplayName>Flat file disassembler</CachedDisplayName"+
">          <CachedIsManaged>true</CachedIsManaged>        </Component>      </Components>    </Stage"+
">    <Stage>      <PolicyFileStage _locAttrData=\"Name\" _locID=\"3\" Name=\"Validate\" minOccurs=\"0\" maxO"+
"ccurs=\"-1\" execMethod=\"All\" stageId=\"9d0e410d-4cce-4536-83fa-4a5040674ad6\" />      <Components>     "+
"   <Component>          <Name>GLC.Integration.Cargowiseone.Trackingshipment.PipelineComp.Debatchtrac"+
"kingFF,GLC.Integration.Cargowiseone.Trackingshipment.PipelineComp, Version=1.0.0.0, Culture=neutral,"+
" PublicKeyToken=db5dae54634e61c6</Name>          <ComponentName>DebatchTracking</ComponentName>     "+
"     <Description>Debatching Tracking Flat Files</Description>          <Version>1.0</Version>      "+
"    <Properties />          <CachedDisplayName>DebatchTracking</CachedDisplayName>          <CachedI"+
"sManaged>true</CachedIsManaged>        </Component>      </Components>    </Stage>    <Stage>      <"+
"PolicyFileStage _locAttrData=\"Name\" _locID=\"4\" Name=\"ResolveParty\" minOccurs=\"0\" maxOccurs=\"-1\" exec"+
"Method=\"All\" stageId=\"9d0e410e-4cce-4536-83fa-4a5040674ad6\" />      <Components />    </Stage>  </St"+
"ages></Document>";
        
        private const string _versionDependentGuid = "7c221393-651a-4303-b6bb-cb5141dd7b3e";
        
        public ReceiveTrackingFF()
        {
            Microsoft.BizTalk.PipelineOM.Stage stage = this.AddStage(new System.Guid("9d0e4105-4cce-4536-83fa-4a5040674ad6"), Microsoft.BizTalk.PipelineOM.ExecutionMode.firstRecognized);
            IBaseComponent comp0 = Microsoft.BizTalk.PipelineOM.PipelineManager.CreateComponent("Microsoft.BizTalk.Component.FFDasmComp,Microsoft.BizTalk.Pipeline.Components, Version=3.0.1.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35");;
            if (comp0 is IPersistPropertyBag)
            {
                string comp0XmlProperties = "<?xml version=\"1.0\" encoding=\"utf-16\"?><PropertyBag xmlns:xsi=\"http://www.w3.org/2001/XMLSchema-inst"+
"ance\" xmlns:xsd=\"http://www.w3.org/2001/XMLSchema\">  <Properties>    <Property Name=\"HeaderSpecName\""+
" />    <Property Name=\"DocumentSpecName\">      <Value xsi:type=\"xsd:string\">GLC.Integration.Cargowis"+
"eone.Trackingshipment.Schemas.TrackingFFSchema, GLC.Integration.Cargowiseone.Trackingshipment.Schema"+
"s, Version=1.0.0.0, Culture=neutral, PublicKeyToken=db5dae54634e61c6</Value>    </Property>    <Prop"+
"erty Name=\"TrailerSpecName\" />    <Property Name=\"PreserveHeader\">      <Value xsi:type=\"xsd:boolean"+
"\">false</Value>    </Property>    <Property Name=\"ValidateDocumentStructure\">      <Value xsi:type=\""+
"xsd:boolean\">false</Value>    </Property>    <Property Name=\"RecoverableInterchangeProcessing\">     "+
" <Value xsi:type=\"xsd:boolean\">false</Value>    </Property>  </Properties></PropertyBag>";
                PropertyBag pb = PropertyBag.DeserializeFromXml(comp0XmlProperties);;
                ((IPersistPropertyBag)(comp0)).Load(pb, 0);
            }
            this.AddComponent(stage, comp0);
            stage = this.AddStage(new System.Guid("9d0e410d-4cce-4536-83fa-4a5040674ad6"), Microsoft.BizTalk.PipelineOM.ExecutionMode.all);
            IBaseComponent comp1 = Microsoft.BizTalk.PipelineOM.PipelineManager.CreateComponent("GLC.Integration.Cargowiseone.Trackingshipment.PipelineComp.DebatchtrackingFF,GLC.Integration.Cargowiseone.Trackingshipment.PipelineComp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=db5dae54634e61c6");;
            if (comp1 is IPersistPropertyBag)
            {
                string comp1XmlProperties = "<?xml version=\"1.0\" encoding=\"utf-16\"?><PropertyBag xmlns:xsi=\"http://www.w3.org/2001/XMLSchema-inst"+
"ance\" xmlns:xsd=\"http://www.w3.org/2001/XMLSchema\">  <Properties /></PropertyBag>";
                PropertyBag pb = PropertyBag.DeserializeFromXml(comp1XmlProperties);;
                ((IPersistPropertyBag)(comp1)).Load(pb, 0);
            }
            this.AddComponent(stage, comp1);
        }
        
        public override string XmlContent
        {
            get
            {
                return _strPipeline;
            }
        }
        
        public override System.Guid VersionDependentGuid
        {
            get
            {
                return new System.Guid(_versionDependentGuid);
            }
        }
    }
}
