using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Xml;
using System.IO;

using System.Threading;
using DamirM.Modules;
using DamirM.Controls;
using DamirM.Class;
using DamirM.CommonLibrary;

namespace UberTools.Modules.GenericTemplate.Forms
{
    public partial class TagsBuilder : Form
    {
        XmlDocument xmlDoc;
        TagControl tagControlLastTmp = null;


        public TagsBuilder()
        {
            InitializeComponent();
            treeView1.NodeMouseClick += new TreeNodeMouseClickEventHandler(treeView1_NodeMouseClick);
            LoadXML(Common.BuildPath(GenericTemplate.moduleParams.DataPath, GenericTemplate.constModuleDataFolder) + GenericTemplate.constTagsXMLFileName);
        }

        void treeView1_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            // xmlDoc.SelectSingleNode("package/components/component[@name='" + node.Attributes["name"].Value + "']/gui-model/small-icon");
            lblExample.Text = "todo";
            string xPathTmp;
            string xPath = ReverseBuildXPath(e.Node, "/");

            if(xPath != "")
            {
                xPathTmp = "/tags/" + xPath;
                XmlNode node = xmlDoc.SelectSingleNode(xPathTmp);
                if (node != null)
                {
                    LoadXMLChild(null, node);
                }
                else
                {
                    tbSyntax.Text = "NEMA";
                }


                //xPathTmp = "/tags/" + xPath + "/syntax";
                //XmlNode node = xmlDoc.SelectSingleNode(xPathTmp);
                //if (node != null)
                //{
                //    tbSyntax.Text = node.InnerText;
                //}
                //else
                //{
                //    tbSyntax.Text = "";
                //}
                //xPathTmp = "/tags/" + xPath + "/example";
                //node = xmlDoc.SelectSingleNode(xPathTmp);
                //if (node != null)
                //{
                //    lblExample.Text = "Example: " + node.InnerText;
                //}
                //else
                //{
                //    lblExample.Text = "Example: ";
                //}
                //xPathTmp = "/tags/" + xPath + "/result";
                //node = xmlDoc.SelectSingleNode(xPathTmp);
                //if (node != null)
                //{
                //    lblResult.Text = "Result: " + node.InnerText;
                //}
                //else
                //{
                //    lblResult.Text = "Result: ";
                //}
            }
            else
            {
                tbSyntax.Text = "";
            }
        }

        private void LoadXML(string xmlFile)
        {
            ModuleLog.Write(xmlFile, this, "LoadXML", ModuleLog.LogType.DEBUG);
            if (string.Empty != xmlFile)
            {
                //FileInfo fInfo = new FileInfo(xmlFile);
                //DirectoryInfo dInfo = new DirectoryInfo(string.Concat(fInfo.Directory.FullName, "/", "icons/"));
                //if (dInfo.Exists)
                //{
                //    JobStatus.Write("Loading images..");
                //    imageList1.Images.Clear();
                //    FileInfo[] imgList = dInfo.GetFiles("*.gif");
                //    foreach (FileInfo file in imgList)
                //    {
                //        Image image = Image.FromFile(file.FullName);
                //        imageList1.Images.Add("icons/" + file.Name, image);
                //    }
                //    treeView1.ImageList = imageList1;
                //}
                //JobStatus.Write("Opening xml...");
                xmlDoc = new XmlDocument();
                try
                {
                    TreeNode rootNode = new TreeNode("Root");
                    xmlDoc.Load(xmlFile);
                    LoadXMLChild(rootNode, xmlDoc.SelectSingleNode("tags"));
                    treeView1.Nodes.Add(rootNode);
                    //LoadActions();
                }
                catch (XmlException err)
                {
                    //SetStatus("Error opening xml file");
                    MessageBox.Show(err.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                catch (Exception e)
                {
                    ModuleLog.Write(e, this, "LoadXML", ModuleLog.LogType.ERROR, false);
                }

                JobProgress.Ready();
            }
            
        }

        private void LoadActions()
        {
            XmlNodeList nodeList = xmlDoc.SelectNodes("tags/tag");
            TreeNode treeNode;
            TreeNode treeNodeChild;
            treeView1.Nodes.Clear();
            foreach (XmlNode node in nodeList)
            {
                if (treeView1.Nodes[node.Attributes["group"].Value] == null)
                {
                    treeNode = new TreeNode(node.Attributes["group"].Value);
                    treeNode.Name = node.Attributes["group"].Value;
                    treeView1.Nodes.Add(treeNode);
                }
                else
                {
                    treeNode = treeView1.Nodes[node.Attributes["group"].Value];
                }
                treeNodeChild = new TreeNode(node.Attributes["name"].Value);
                treeNodeChild.Name = node.Attributes["name"].Value;
                XmlNode picNode = xmlDoc.SelectSingleNode("package/components/component[@name='" + node.Attributes["name"].Value + "']/gui-model/small-icon");
                treeNodeChild.ImageKey = picNode.Attributes["file"].Value;
                treeNode.Nodes.Add(treeNodeChild);
                treeNode.Text = string.Concat(treeNode.Name, "(", treeNode.Nodes.Count, ")");

            }
        }
        private void LoadXMLChild(TreeNode treeNode, XmlNode xmlNode)
        {
            TreeNode newTreeNode;
            foreach (XmlNode node in xmlNode.ChildNodes)
            {
                if (node.NodeType == XmlNodeType.Element)
                {
                    if (node.Name == "tag")
                    {
                        if (node.Attributes["type"] != null)
                        {
                            // check if node is type of object
                            if (node.Attributes["type"].Value == "object")
                            {
                                if (treeNode != null)
                                {
                                    // if treeNode not null then build contorl nodes
                                    newTreeNode = new TreeNode(node.Attributes["name"].Value);
                                    newTreeNode.Name = node.Attributes["name"].Value;
                                    treeNode.Nodes.Add(newTreeNode);
                                    if (node.HasChildNodes)
                                    {
                                        LoadXMLChild(newTreeNode, node);
                                    }
                                }
                            }
                            else
                            {
                                Tag tag = new Tag(node.Attributes["name"].Value, "");
                                TagControl tagControl = TagControl.GetControlInstance(pParametars, tag, tagControlLastTmp, null);
                                tagControlLastTmp = tagControl;
                                if (node.HasChildNodes)
                                {
                                    LoadXMLChild(treeNode, node);
                                }
                            }
                        }
                        else
                        {
                            ModuleLog.Write("Bad xml format \r\n" + node.InnerXml, this, "LoadXMLChild", ModuleLog.LogType.WARNING);
                        }
                    }
                    else if (node.Name == "syntax")
                    {
                        tbSyntax.Text = node.InnerText;
                    }
                    else if (node.Name == "result")
                    {
                        lblResult.Text = "Result: " + node.InnerText;
                    }
                    else if (node.Name == "example")
                    {
                        lblExample.Text = "Example: " + node.InnerText;
                    }
                    else
                    {
                        if (node.HasChildNodes)
                        {
                            LoadXMLChild(treeNode, node);
                        }
                    }
                }
            }
        }

        private string ReverseBuildXPath(TreeNode treeNode, string xPath)
        {
            if (treeNode.Parent != null)
            {
                xPath = ReverseBuildXPath(treeNode.Parent, string.Concat("tag[@name='",treeNode.Name, "']/", xPath));
            }
            if (xPath.EndsWith("/"))
            {
                xPath = xPath.Substring(0, xPath.Length - 1);
            }
            return xPath;
        }

        private void DoEvents2(int millisec)
        {
            for (int i = 0; i < millisec; i = i + 100)
            {
                Application.DoEvents();
                Thread.Sleep(100);
            }
        }

        private void btnAction_Click(object sender, EventArgs e)
        {
            TreeNode node = treeView1.SelectedNode;
            if (node != null)
            {
                if (node != null && node.Parent == null)  // Group 
                {

                    XmlNodeList xmlNodeList = xmlDoc.SelectNodes("package/components/component[@group='" + node.Name + "']");
                    for (int i = 0; i < xmlNodeList.Count; i++)
                    {
                        //xmlNodeList[i].Attributes["group"].Value = cmbGroup.Text;
                    }
                    LoadActions();
                }
                else   //    Action
                {
                    //string gruop = cmbGroup.Items[cmbGroup.SelectedIndex].ToString();
                    XmlNode xmlNode = xmlDoc.SelectSingleNode("package/components/component[@name='" + node.Name + "']");
                    //xmlNode.Attributes["group"].Value = gruop;
                    LoadActions();
                }
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            //saveFileDialog1.FileName = txbFile.Text;
            saveFileDialog1.Filter = " XML file(*.xml)|*.xml|All files (*.*)|*.*";
            DialogResult res = saveFileDialog1.ShowDialog(this);
            
            
            if (DialogResult.OK == res)
            {
                XmlWriterSettings xmlSettings = new XmlWriterSettings();
                //xmlSettings.NewLineHandling = NewLineHandling.None;
                xmlSettings.Indent = true;
                XmlWriter xmlWriter = XmlWriter.Create(saveFileDialog1.FileName, xmlSettings);
                xmlDoc.WriteTo(xmlWriter);
                xmlWriter.Flush();
                xmlWriter.Close();
            }
        }
    }
}
