using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;
using System.Collections;
using DamirM.Module.ModuleManager;

namespace UberTools.Plugin.TemplatesFiller.Class
{
    class XMLParser
    {
        private RowCollectionMenager rowCollectionMenager;
        private static XMLParser xmlObject;
        private XmlDocument xmlDoc;

        int startDepth;

        public XMLParser(RowCollectionMenager rowCollectionMenager, string xmlPath, int startDepth)
        {
            this.rowCollectionMenager = rowCollectionMenager;
            this.startDepth = startDepth;
            ParseXML(xmlPath);
        }

        public XMLParser(string path)
        {
            try
            {
                ModuleLog.Write("Loading xml file\r\n" + path, this, "XMLParser", ModuleLog.LogType.DEBUG);
                xmlDoc = new XmlDocument();
                xmlDoc.Load(path);
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

        public void ParseXML(string requestURL)
        {
            ArrayList list = new ArrayList();
            string[] columns;
            XmlTextReader reader = null;
            try
            {
                reader = new XmlTextReader(requestURL);
                while (reader.Read())
                {
                    if (reader.NodeType == XmlNodeType.Element && reader.Depth >= this.startDepth)
                    {
                        if (reader.HasAttributes)
                        {
                            columns = new string[reader.AttributeCount];
                            columns = GetAllAttribites(ref reader);
                            if (reader.Depth > list.Count)
                            {
                                do
                                {
                                    list.Add(null);
                                } while (list.Count <= reader.Depth);
                            }
                            list.Insert(reader.Depth, columns);
                            rowCollectionMenager.AddRow(new ObjectRow(null, MargeArrays(list, reader.Depth)));
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                ModuleLog.Write(ex, this, "ParseXML", ModuleLog.LogType.ERROR);
            }
            finally
            {
                reader.Close();
            }
        }
        private string[] GetAllAttribites(ref XmlTextReader reader)
        {
            Array buff = Array.CreateInstance(typeof(string), reader.AttributeCount);
            for (int i = 0; i < reader.AttributeCount; i++)
            {
                buff.SetValue(reader.GetAttribute(i), i);
                //buff = reader.GetAttribute(i);
            }
            string[] buff2 = new string[reader.AttributeCount];
            Array.Copy(buff, buff2, reader.AttributeCount);
            return buff2;
        }
        private string[] MargeArrays(ArrayList list, int depth)
        {
            ArrayList arrayList= new ArrayList();
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

    }
}
