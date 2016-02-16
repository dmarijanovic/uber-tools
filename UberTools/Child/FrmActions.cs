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

namespace NTHTools
{
    public partial class FrmActions : ChildBase
    {
        XmlDocument xmlDoc;
        public FrmActions()
        {
            InitializeComponent();
            treeView1.NodeMouseClick += new TreeNodeMouseClickEventHandler(treeView1_NodeMouseClick);
        }

        void treeView1_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            if (e.Node.Parent == null) // Group click
            {
                lblType.Text = "Group";
                cmbGroup.Text = e.Node.Name;
                cmbGroup.DropDownStyle = ComboBoxStyle.Simple;
                btnAction.Text = "&Rename";
            }
            else
            {
                lblType.Text = "Action";
                btnAction.Text = "&Set group";
                cmbGroup.DropDownStyle = ComboBoxStyle.DropDownList;
                for (int i = 0; i < cmbGroup.Items.Count - 1; i++)
                {
                    if (cmbGroup.Items[i].ToString() == e.Node.Parent.Name)
                    {
                        cmbGroup.SelectedIndex = i;
                        break;
                    }
                }
            }
            lblName.Text = e.Node.Name;
        }

        private void btnOpen_Click(object sender, EventArgs e)
        {
            DialogResult res = openFileDialog1.ShowDialog(this);
            if (res == DialogResult.OK)
            {
                txbFile.Text = openFileDialog1.FileName;
                btnRefresh.PerformClick();
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            string xmlFile = txbFile.Text.Trim();
            if (string.Empty != xmlFile)
            {
                FileInfo fInfo = new FileInfo(xmlFile);
                DirectoryInfo dInfo = new DirectoryInfo(string.Concat(fInfo.Directory.FullName, "/", "icons/"));
                if (dInfo.Exists)
                {
                    SetStatus("Loading images..");
                    imageList1.Images.Clear();
                    FileInfo[] imgList = dInfo.GetFiles("*.gif");
                    foreach (FileInfo file in imgList)
                    {
                        Image image = Image.FromFile(file.FullName);
                        imageList1.Images.Add("icons/" + file.Name, image);
                    }
                    treeView1.ImageList = imageList1;
                }
                SetStatus("Opening xml...");
                xmlDoc = new XmlDocument();
                try
                {
                    xmlDoc.Load(xmlFile);
                    LoadActions();
                }
                catch (XmlException err)
                {
                    SetStatus("Error opening xml file");
                    MessageBox.Show(err.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                SetStatus();
            }
            
        }

        private void LoadActions()
        {
            XmlNodeList nodeList = xmlDoc.SelectNodes("package/components/component");
            TreeNode treeNode;
            TreeNode treeNodeChild;
            treeView1.Nodes.Clear();
            cmbGroup.Items.Clear();
            foreach (XmlNode node in nodeList)
            {
                if (treeView1.Nodes[node.Attributes["group"].Value] == null)
                {
                    treeNode = new TreeNode(node.Attributes["group"].Value);
                    treeNode.Name = node.Attributes["group"].Value;
                    treeView1.Nodes.Add(treeNode);
                    cmbGroup.Items.Add(node.Attributes["group"].Value);
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
                        xmlNodeList[i].Attributes["group"].Value = cmbGroup.Text;
                    }
                    LoadActions();
                }
                else   //    Action
                {
                    string gruop = cmbGroup.Items[cmbGroup.SelectedIndex].ToString();
                    XmlNode xmlNode = xmlDoc.SelectSingleNode("package/components/component[@name='" + node.Name + "']");
                    xmlNode.Attributes["group"].Value = gruop;
                    LoadActions();
                }
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            saveFileDialog1.FileName = txbFile.Text;
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

        private void treeView1_NodeMouseClick_1(object sender, TreeNodeMouseClickEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                menuXMLEdit.Show((TreeView)sender, e.X, e.Y);
            }
        }
    }
}
