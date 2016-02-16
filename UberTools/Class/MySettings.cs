using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Xml;
using System.Xml.XPath;

namespace NTHTools
{
    class MySettings
    {
        private string service;
        private string fileName;
        XmlDocument xmlDoc;
        public MySettings(string service, string fileName)
        {
            this.service = service;
            this.fileName = fileName;
        }
        public void Write(string name, string data, string subservice)
        {
            xmlDoc = this.GetDocument;
            this.ServiceCheck(xmlDoc);
            XmlNode xmlService = xmlDoc.SelectSingleNode("services/" + this.service);
            //XPathNavigator navigator = xmlService.CreateNavigator();
            XmlNode newNode = xmlDoc.CreateNode(XmlNodeType.Element, subservice, "");
            XmlAttribute attr1 = xmlDoc.CreateAttribute("name");
            XmlAttribute attr2 = xmlDoc.CreateAttribute("time");
            attr1.Value = name;
            attr2.Value = DateTime.Now.ToString();
            newNode.Attributes.Append(attr1);
            newNode.Attributes.Append(attr2);
            newNode.InnerText = data;
            xmlService.AppendChild(newNode);
        }
        public System.Collections.Generic.IEnumerator<string> GetEnumerator()
        {

            yield return default(string);
        }
        public void DeleteSubservice(string subservice)
        {
            xmlDoc = this.GetDocument;
            XmlNode xmlService = xmlDoc.SelectSingleNode("services/" + this.service);
            if (xmlService != null)
            {
                xmlService.RemoveAll();
            }
            this.Save();
        }
        private void ServiceCheck(XmlDocument xmlDoc)
        {
            XmlNode mainNode = xmlDoc.SelectSingleNode("services");
            if (mainNode == null)
            {
                xmlDoc.AppendChild(xmlDoc.CreateNode("", "services", ""));
            }
            XmlNode serviceNode = mainNode.SelectSingleNode(this.service);
            if (serviceNode == null)
            {
                mainNode.AppendChild(xmlDoc.CreateNode(XmlNodeType.Element, this.service, ""));
                xmlDoc.AppendChild(mainNode);
            }
        }
        public void Save()
        {
            xmlDoc.Save(this.GetFilePath);
        }
        private string GetFilePath
        {
            get
            {
                string path = System.Windows.Forms.Application.StartupPath;
                path = path.EndsWith("\\") ? path : path + "\\";
                return path + fileName;
            }
        }
        private bool FileExists
        {
            get
            {
                return File.Exists(this.GetFilePath);
            }
        }
        private XmlDocument GetDocument
        {
            get
            {
                XmlDocument xmlDoc = new XmlDocument();
                if (!FileExists)
                {
                    try
                    {
                        xmlDoc.CreateElement("services");
                        XmlNode decNode = xmlDoc.CreateXmlDeclaration("1.0", "UTF-8", null);
                        XmlNode node = xmlDoc.CreateElement("services");
                        xmlDoc.AppendChild(decNode);
                        xmlDoc.AppendChild(node);
                        xmlDoc.Save(GetFilePath);
                    }
                    catch (Exception e)
                    {
                        //TODO: LogError();
                        System.Windows.Forms.MessageBox.Show(e.Message);
                    }
                }
                else
                {
                    xmlDoc.Load(GetFilePath);
                }
                return xmlDoc;
            }
        }
    }
}
