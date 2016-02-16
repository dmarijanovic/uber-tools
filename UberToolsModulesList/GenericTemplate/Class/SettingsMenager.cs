using System;
using System.Collections.Generic;
using System.Collections;
using System.Text;
using System.Xml;

namespace DamirM.Class
{
    class SettingsMenager
    {
        ArrayList list;
        private string path;
        private string groupOf;

        public SettingsMenager(string path, string groupOf)
        {
            list = new ArrayList();
            this.path = path;
            this.groupOf = groupOf;
        }
        public void Add(System.Windows.Forms.Control control)
        {
            //if (typeof(System.Windows.Forms.TextBox).Equals(control.GetType()))
            list.Add(new SettingsMenagerStructure(control));
        }
        public void Add(string text)
        {
            list.Add(text);
        }
        public void SaveSettings()
        {
            XmlWriterSettings writerSettings = new XmlWriterSettings();
            writerSettings.Indent = true;
            XmlWriter xmlWriter = XmlWriter.Create(this.path, writerSettings);
            xmlWriter.WriteStartDocument();
            xmlWriter.WriteStartElement("Templates");
            xmlWriter.WriteStartElement("Template");
            // Add new attribute
            xmlWriter.WriteStartAttribute("Name");
            xmlWriter.WriteString(this.groupOf);
            xmlWriter.WriteEndAttribute();
            foreach (SettingsMenagerStructure node in list)
            {
                // Template element
                xmlWriter.WriteStartElement("Data");
                // Add new attribute
                xmlWriter.WriteStartAttribute("Type");
                xmlWriter.WriteString(node.type.ToString());
                xmlWriter.WriteEndAttribute();
                // Add new attribute
                xmlWriter.WriteStartAttribute("Name");
                xmlWriter.WriteString(node.name);
                xmlWriter.WriteEndAttribute();
                // Add new attribute
                xmlWriter.WriteStartAttribute("Description");
                xmlWriter.WriteString("");
                xmlWriter.WriteEndAttribute();
                // Add body text to elemnt
                xmlWriter.WriteString(node.text);
                xmlWriter.WriteEndElement();

            }
            xmlWriter.WriteEndElement();
            xmlWriter.WriteEndElement();


            xmlWriter.WriteEndDocument();
            xmlWriter.Close();
        }
        public void LoadSettings()
        {
            XmlDocument xmlDoc = new XmlDocument();
            XmlNodeList nodeList = xmlDoc.SelectNodes("Templates/Template/Data");
            xmlDoc.Load(path);
            foreach (XmlNode node in nodeList)
            {
                foreach (SettingsMenagerStructure item in list)
                {
                    if (node.Attributes["Name"].Value == item.name)
                    {
                        item.control.Text = node.InnerText;
                    }
                }
            }
        }
    }
    class SettingsMenagerStructure
    {
        public Type type;
        public string name;
        public string text;
        public System.Windows.Forms.Control control;
        public SettingsMenagerStructure(System.Windows.Forms.Control control)
        {
            this.type = control.GetType();
            this.name = control.Name;
            this.text = control.Text;
            this.control = control;
        }
    }
}
