using System;
using System.Collections.Generic;

using System.Text;
using System.Xml.Serialization;
using NPOI.OpenXml4Net.Util;
using System.IO;
using System.Xml;

namespace NPOI.OpenXmlFormats.Spreadsheet
{
    /// <summary>
    /// Rich Text Run container.
    /// </summary>
    [Serializable]
    [XmlType(Namespace = "http://schemas.openxmlformats.org/spreadsheetml/2006/main")]
    public class CT_RElt
    {

        private CT_RPrElt rPrField = null; // optional field 

        private string tField = string.Empty; // required field 

        public static CT_RElt Parse(XmlNode node, XmlNamespaceManager namespaceManager)
        {
            if (node == null)
                return null;
            CT_RElt ctObj = new CT_RElt();
            ctObj.t = XmlHelper.ReadString(node.Attributes["t"]);
            //foreach (XmlNode childNode in node.ChildNodes)
            //{
            //    if (childNode.LocalName == "rPr")
            //        ctObj.rPr = CT_RPrElt.Parse(childNode, namespaceManager);
            //}
            return ctObj;
        }



        internal void Write(StreamWriter sw, string nodeName)
        {
            sw.Write(string.Format("<{0}", nodeName));
            XmlHelper.WriteAttribute(sw, "t", this.t);
            sw.Write(">");
            //if (this.rPr != null)
            //    this.rPr.Write(sw, "rPr");
            sw.Write(string.Format("</{0}>", nodeName));
        }


        public CT_RPrElt AddNewRPr()
        {
            this.rPrField = new CT_RPrElt();
            return rPrField;
        }

        /// <summary>
        /// Run Properties
        /// </summary>
        [XmlElement("rPr")]
        public CT_RPrElt rPr
        {
            get
            {
                return this.rPrField;
            }
            set
            {
                this.rPrField = value;
            }
        }

        /// <summary>
        /// Text
        /// </summary>
        [XmlElement("t")]
        public string t
        {
            get
            {
                return this.tField;
            }
            set
            {
                this.tField = value;
            }
        }
    }
}
