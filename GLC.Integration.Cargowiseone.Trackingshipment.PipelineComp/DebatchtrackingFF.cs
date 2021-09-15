using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.BizTalk.Component.Interop;
using Microsoft.BizTalk.Message.Interop;
using System.IO;
using System.Xml;

namespace GLC.Integration.Cargowiseone.Trackingshipment.PipelineComp
{
    [Serializable]
    [ComponentCategory(CategoryTypes.CATID_PipelineComponent)]
    [ComponentCategory(CategoryTypes.CATID_Any)]
    [System.Runtime.InteropServices.Guid("1A6FAD7C-DF5F-4106-8B9D-C6DC2EA6BFCD")]


    public class DebatchtrackingFF : IBaseComponent, IComponent, IComponentUI
    {
        #region IBaseComponent

        /// <summary>
        /// Name of the component.
        /// </summary>
        //[Browsable(false)]
        public string Name
        {
            get { return "DebatchTracking"; }
        }

        /// <summary>
        /// Version of the component.
        /// </summary>
        //[Browsable(false)]
        public string Version
        {
            get { return "1.0"; }
        }

        /// <summary>
        /// Description of the component.
        /// </summary>
        // [Browsable(false)]
        public string Description
        {
            get { return "Debatching Tracking Flat Files"; }
        }

        #endregion
        #region IComponentUI
        public IntPtr Icon
        {
            get
            {
                return new System.IntPtr();
            }
        }

        public System.Collections.IEnumerator Validate(object projectSystem)
        {
            return null;
        }
        #endregion
        #region IComponent

        public Microsoft.BizTalk.Message.Interop.IBaseMessage Execute(Microsoft.BizTalk.Component.Interop.IPipelineContext pc, Microsoft.BizTalk.Message.Interop.IBaseMessage inmsg)
        {
            IBaseMessageContext messageContext = inmsg.Context;
            Stream originalStream = inmsg.BodyPart.GetOriginalDataStream();
            StreamReader strmread = new StreamReader(originalStream);
            string data = strmread.ReadToEnd();
            string data1 = data;

            data = data.Replace(@"http://GLC.Integration.Cargowiseone.Trackingshipment.Schemas.TrackingFFSchema", "");
            string strxml = "";

            var shipcode = new List<string>();
            //var ponum = new List<string>();
            //string inmsg = File.ReadAllText(@"C:\Users\shashi\AppData\Local\Temp\_SchemaData\HL_Jcurve_FF_output.xml");
            XmlDocument xdoc = new XmlDocument();
            xdoc.LoadXml(data);

            //XmlNamespaceManager xmn = new XmlNamespaceManager(xdoc.NameTable);
            //xmn.AddNamespace("xmlns2", "http://GLC.Integration.Cargowiseone.HealthLab.Schemas.HL_Jcurve_FF");

            XmlNodeList xmlnode = xdoc.SelectNodes("TrackingDetails/TrackingDetails_Child2");


            foreach (XmlNode node in xmlnode)
            {
                var strcod = node.SelectSingleNode("TrackingDetails_Child2_Child6").InnerText;
                shipcode.Add(strcod);
            }
            List<string> mylist = shipcode.Distinct().ToList();


            string filepath;
            int cnt = mylist.Count();
            string strxml1 = "";
            string strfinalxml = "";
            for (int i = 0; i < cnt; i++)
            {
                string codeval = mylist[i];
                string headerxml = "";
                int flag = 0;
                foreach (XmlNode node in xmlnode)
                {

                   
                   
                    string id = node.SelectSingleNode("TrackingDetails_Child2_Child6").InnerText;
                    

                    if (codeval == id)
                    {

                        strxml1 = strxml1 + node.OuterXml.ToString();
                    }

                }

                strfinalxml = "<Debatch_Tracking>" + headerxml + strxml1 + " </Debatch_Tracking>";
                filepath = @"C:\Tracking_Shipment\" + codeval + "_" + DateTime.Now.ToString("ddMMyyyyHHmmss") + ".xml";
                strxml1 = "";
                File.WriteAllText(filepath, strfinalxml);
            }


            byte[] bytearray = Encoding.UTF8.GetBytes(data1);
            MemoryStream strm = new MemoryStream(bytearray);
            originalStream = strm;
            originalStream.Seek(0, SeekOrigin.Begin);
            inmsg.BodyPart.Data = originalStream;
            inmsg.Context = messageContext;
            return inmsg;
        }
        #endregion

    }
}

