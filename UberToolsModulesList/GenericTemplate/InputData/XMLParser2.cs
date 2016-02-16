using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;
using System.Collections;

using  DamirM.Modules;
using UberTools.Modules.GenericTemplate.Controls;
using UberTools.Modules.GenericTemplate.RowCollectionNS;

namespace UberTools.Modules.GenericTemplate.InputData
{
    class XMLParser2
    {
        private RowCollectionMenager rowCollectionMenager;
        private static XMLParser xmlObject;
        private XmlDocument xmlDoc;

        int startDepth;

        public XMLParser2(RowCollectionMenager rowCollectionMenager, string xmlPath, int startDepth)
        {
            this.rowCollectionMenager = rowCollectionMenager;
            this.startDepth = startDepth;
        }

        public XMLParser2(RowCollectionMenager rowCollectionMenager, string xmlPath, string xpath)
        {
            try
            {
                ModuleLog.Write("Loading xml file\r\n" + xmlPath, this, "XMLParser", ModuleLog.LogType.DEBUG);
                xmlDoc = new XmlDocument();
                xmlDoc.Load(xmlPath);

                this.rowCollectionMenager = rowCollectionMenager;
                this.startDepth = 0;

                ProcessXML(xmlDoc.SelectNodes(xpath), null);
            }
            catch (Exception ex)
            {
                ModuleLog.Write(ex, this, "XMLParser", ModuleLog.LogType.ERROR);
            }
        }
        public static void CreateInstance(string path)
        {
            xmlObject = new XMLParser(path);
        }
        public string GetXPathAttributeValue(string xPath, string attribute)
        {
            string result = "";
            XmlNode xmlNode;
            xmlNode = xmlDoc.SelectSingleNode(xPath);
            if (xmlNode != null)
            {
                result = xmlNode.Attributes[attribute].Value;
            }
            else
            {
                result = "";
            }

            return result;
        }

        public static XMLParser XMLObject
        {
            get
            {
                return xmlObject;
            }
        }

        private string[] GetAllAttribites(XmlNode node)
        {
            Array buff = Array.CreateInstance(typeof(string), node.Attributes.Count);
            for (int i = 0; i < node.Attributes.Count; i++)
			{
                buff.SetValue(node.Attributes[i].Value, i);
            }
            string[] buff2 = new string[node.Attributes.Count];
            Array.Copy(buff, buff2, node.Attributes.Count);
            return buff2;
        }
        private string[] MargeArrays(ArrayList list, int depth)
        {
            ArrayList arrayList = new ArrayList();
            string[] tmp;
            for (int i = 0; i <= depth; i++)
            {
                tmp = (string[])list[i];
                if (tmp != null)
                {
                    arrayList.AddRange(tmp);
                }

                //Array.Copy(tmp, 0, buff, buff.Length, tmp.Length);
            }
            tmp = new string[arrayList.Count];

            arrayList.CopyTo(tmp);
            return tmp;

        }

        private void ProcessXML(XmlNodeList xmlNodeList, UberTools.Modules.GenericTemplate.RowCollectionNS.RowCollection parentRowCollection)
        {
            RowCollection rowCollection = null;
            RowCollectionRow objectRow;
            string rowCollectionName = null;
            foreach (XmlNode node in xmlNodeList)
            {
                if (node.NodeType == XmlNodeType.Element)
                {
                    
                    rowCollectionName = FindXPath(node);
                    rowCollection = rowCollectionMenager[rowCollectionName];
                    if (rowCollection == null)
                    {
                        rowCollection = rowCollectionMenager.CreateRowCollection(node.Attributes.Count, rowCollectionName);
                    }

                    // check if parent row collection is not null, only first call is null
                    if (parentRowCollection != null)
                    {
                        // add this row collection to parent chilld list
                        parentRowCollection.AddChild(rowCollection);
                    }

                    // make new instance of ObjectRow object
                    objectRow = new RowCollectionRow(rowCollection, GetAllAttribites(node));
                    // if node have inner text
                    if (node.InnerText != "")
                    {
                        // add extra columnt to objectRow object
                        objectRow.AddColl(new RowCollectionColumn(node.InnerText));
                    }
                    // add new row to row collection
                    rowCollection.Rows.Add(objectRow);

                    //ModuleLog.Write(GetAllAttribites(node), this, "ProcessXML", ModuleLog.LogType.INFO);

                    // recurse chilld
                    ProcessXML(node.ChildNodes, rowCollection);
                }
            }
        }









        static string FindXPath(XmlNode node)
        {
            StringBuilder builder = new StringBuilder();
            while (node != null)
            {
                switch (node.NodeType)
                {
                    case XmlNodeType.Attribute:
                        builder.Insert(0, "/@" + node.Name);
                        node = ((XmlAttribute)node).OwnerElement;
                        break;
                    case XmlNodeType.Element:
                        int index = FindElementIndex((XmlElement)node);
                        //builder.Insert(0, "/" + node.Name + "[" + index + "]");
                        builder.Insert(0, "/" + node.Name);
                        node = node.ParentNode;
                        break;
                    case XmlNodeType.Document:
                        return builder.ToString();
                    default:
                        return "Only elements and attributes are supported";
                }
            }
            throw new ArgumentException("Node was not in a document");
        }

        static int FindElementIndex(XmlElement element)
        {
            XmlNode parentNode = element.ParentNode;
            if (parentNode is XmlDocument)
            {
                return 1;
            }
            XmlElement parent = (XmlElement)parentNode;
            int index = 1;
            foreach (XmlNode candidate in parent.ChildNodes)
            {
                if (candidate is XmlElement && candidate.Name == element.Name)
                {
                    if (candidate == element)
                    {
                        return index;
                    }
                    index++;
                }
            }
            throw new ArgumentException("Couldn't find element within parent");
        }



















    }
}
