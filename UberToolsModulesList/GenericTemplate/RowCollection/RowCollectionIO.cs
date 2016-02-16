using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;

using DamirM.Modules;

namespace UberTools.Modules.GenericTemplate.RowCollectionNS
{
    class RowCollectionIO
    {
        const string XPATH_SELECT_NAME = "/DataObject/Name";
        const string XPATH_SELECT_COLUMNS_INFO = "/DataObject/Columns";
        const string XPATH_SELECT_COLUMNS = "/DataObject/Columns/Column";
        const string XPATH_SELECT_ROWS = "/DataObject/Rows/Row";

        RowCollectionMenager rowCollectionMenager;
        string path;

        public RowCollectionIO(RowCollectionMenager rowCollectionMenager, string path)
        {
            this.rowCollectionMenager = rowCollectionMenager;
            this.path = path;
        }
        public RowCollectionIO(string path)
        {
            this.rowCollectionMenager = null;
            this.path = path;
        }

        public void Load()
        {
            RowCollection rowCollection;
            RowCollectionRow rowCollectionRow;
            XmlDocument xmlDocument;
            XmlNodeList xmlNodeList;
            XmlNode xmlNode;

            string name;
            int columnCount;
            string[] columnNames;
            string[] columnValues;


            try
            {
                ModuleLog.Write(new string[] { "Loading data object...", this.path }, this, "Load", ModuleLog.LogType.DEBUG);

                xmlDocument = new XmlDocument();
                xmlDocument.Load(this.path);

                // Get data object name
                xmlNode = xmlDocument.SelectSingleNode(XPATH_SELECT_NAME);
                name = xmlNode.InnerText;

                // Get columns count
                xmlNode = xmlDocument.SelectSingleNode(XPATH_SELECT_COLUMNS_INFO);
                columnCount = int.Parse(xmlNode.Attributes["count"].Value);
                columnNames = new string[columnCount];

                // create new rowCollection
                rowCollection = this.rowCollectionMenager.GetRowCollectionObjectFromCellNumber(columnCount, true);


                // get column names
                xmlNodeList = xmlDocument.SelectNodes(XPATH_SELECT_COLUMNS);
                for (int i = 0; i < xmlNodeList.Count; i++)
                {
                    rowCollection.Columns[i] = xmlNodeList[i].InnerText;
                }


                // select all rows
                xmlNodeList = xmlDocument.SelectNodes(XPATH_SELECT_ROWS);
                columnValues = new string[columnCount];
                foreach (XmlNode xmlRow in xmlNodeList)
                {
                    // select all columns values from this row
                    for (int i = 0; i < xmlRow.ChildNodes.Count; i++)
                    {
                        columnValues[i] = xmlRow.ChildNodes[i].InnerText;
                    }
                    rowCollectionRow = new RowCollectionRow(rowCollection, columnValues);

                    rowCollection.Rows.Add(rowCollectionRow);
                }
            }
            catch (Exception ex)
            {
                ModuleLog.Write(ex, this, "Load", ModuleLog.LogType.ERROR);
            }
        }

        public void Save(RowCollection rowCollection)
        {
            XmlDocument xmlDocument = new XmlDocument();
            XmlDeclaration xmlDeclaration;
            XmlElement rootNode;
            XmlElement nameElement;
            XmlElement columnsNamesNode;
            XmlElement rowsNode;
            XmlElement rowNode;

            XmlElement columnNameElement;
            XmlElement columnValueElement;

            try
            {
                ModuleLog.Write(new string[] { "Saving data object...", this.path, rowCollection.LabelName }, this, "Save", ModuleLog.LogType.DEBUG);

                xmlDeclaration = xmlDocument.CreateXmlDeclaration("1.0", "UTF-8", "yes");
                xmlDocument.InsertBefore(xmlDeclaration, xmlDocument.DocumentElement);

                // create root element and add it to xml document
                rootNode = xmlDocument.CreateElement("DataObject");
                xmlDocument.AppendChild(rootNode);

                // create Name element
                nameElement = xmlDocument.CreateElement("Name");
                nameElement.InnerText = rowCollection.LabelName;
                rootNode.AppendChild(nameElement);

                // create column names node and add all names
                columnsNamesNode = xmlDocument.CreateElement("Columns");
                columnsNamesNode.SetAttribute("count", rowCollection.Columns.Count.ToString());
                for (int i = 0; i < rowCollection.Columns.Count; i++)
                {
                    columnNameElement = xmlDocument.CreateElement("Column");
                    columnNameElement.InnerText = rowCollection.Columns[i];
                    columnsNamesNode.AppendChild(columnNameElement);
                }
                rootNode.AppendChild(columnsNamesNode);

                // add rows
                rowsNode = xmlDocument.CreateElement("Rows");
                rowsNode.SetAttribute("count", rowCollection.Rows.Count.ToString());
                foreach (RowCollectionRow row in rowCollection.Rows)
                {
                    rowNode = xmlDocument.CreateElement("Row");
                    // add columns value to row

                    for (int i = 0; i < rowCollection.Columns.Count; i++)
                    {
                        columnValueElement = xmlDocument.CreateElement("Column");
                        columnValueElement.InnerText = row[i].Value;
                        rowNode.AppendChild(columnValueElement);
                    }
                    rowsNode.AppendChild(rowNode);
                }
                rootNode.AppendChild(rowsNode);

                xmlDocument.Save(this.path);

            }
            catch (Exception ex)
            {
                ModuleLog.Write(ex, this, "Save", ModuleLog.LogType.ERROR);
            }
        }
    }
}
