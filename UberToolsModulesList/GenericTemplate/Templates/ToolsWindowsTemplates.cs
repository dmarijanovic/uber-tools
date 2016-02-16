using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

using UberTools.Modules.GenericTemplate.Forms;
using  DamirM.Modules;
using DamirM.Class;
using DamirM.Controls;
using DamirM.CommonLibrary;
using UberTools.Modules.GenericTemplate.Class;

namespace UberTools.Modules.GenericTemplate.Controls
{
    public partial class ToolsWindowsTemplates : UserControlBase
    {
        TemplatesManager templatesMenager;

        public ToolsWindowsTemplates()
        {
            InitializeComponent();
            this.templatesMenager = null;
        }

        private void tvTree_MouseDown(object sender, MouseEventArgs e)
        {
            // Get the tree.
            TreeView treeView = (TreeView)sender;

            // Get the node underneath the mouse.
            TreeNode node = treeView.GetNodeAt(e.X, e.Y);
            treeView.SelectedNode = node;

            // Start the drag-and-drop operation with a cloned copy of the node.
            if (node != null)
            {
                if (node.Name == "file")
                {
                    treeView.DoDragDrop(node, DragDropEffects.Move);
                }
            }
        }

        private void tvTree_DragOver(object sender, DragEventArgs e)
        {
            // Get the tree.
            TreeView tree = (TreeView)sender;

            // Drag and drop denied by default.
            e.Effect = DragDropEffects.None;

            // Is it a valid format?
            if (e.Data.GetData(typeof(TreeNode)) != null)
            {
                // Get the screen point.
                Point pt = new Point(e.X, e.Y);

                // Convert to a point in the TreeView's coordinate system.
                pt = tree.PointToClient(pt);

                // Is the mouse over a valid node?
                TreeNode node = tree.GetNodeAt(pt);
                if (node != null)
                {
                    if (node.Name == "folder" || node.Name == "desktop")
                    {
                        node.Expand();
                        e.Effect = DragDropEffects.Move;
                        tree.SelectedNode = node;
                    }
                }
            }
        }

        private void tvTree_DragDrop(object sender, DragEventArgs e)
        {
            TreeNode sourceNode;
            TreeNode destinationNode;
            bool result;

            // Get the tree.
            TreeView tree = (TreeView)sender;

            // Get the screen point.
            Point pt = new Point(e.X, e.Y);

            // Convert to a point in the TreeView's coordinate system.
            pt = tree.PointToClient(pt);

            // Get the node underneath the mouse.
            destinationNode = tree.GetNodeAt(pt);
            sourceNode = (TreeNode)e.Data.GetData(typeof(TreeNode));

            result = templatesMenager.Copy(sourceNode, destinationNode);

            if (result == true)
            {
                // Add a child node.
                destinationNode.Nodes.Add((TreeNode)sourceNode.Clone());

                // Show the newly added node if it is not already visible.
                destinationNode.Expand();
                tvTree.Nodes.Remove(sourceNode);
                templatesMenager.LoadAll();
            }
        }

        private void tsbLoad_Click(object sender, EventArgs e)
        {
            try
            {
                templatesMenager.Load();
            }
            catch (Exception ex)
            {
                ModuleLog.Write(ex, this, "tsbLoad_Click", ModuleLog.LogType.ERROR);
            }
        }
        private void tsbSave_Click(object sender, EventArgs e)
        {
            try
            {
                templatesMenager.Save();
            }
            catch (Exception ex)
            {
                ModuleLog.Write(ex, this, "tsbSave_Click", ModuleLog.LogType.ERROR);
            }
        }
        private void tsbNewFolder_Click(object sender, EventArgs e)
        {
            InputBox inputBox = new InputBox("Folder name", "Enter the name of the folder");

            inputBox.ShowDialog(Application.OpenForms[0]);

            if (inputBox.DialogResult == DialogResult.OK)
            {
                templatesMenager.NewFolder(inputBox.InputTekst);
            }
            templatesMenager.LoadAll();
        }
        private void tsbDelete_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult;
            if (templatesMenager.ActiveNodeType == TemplatesManager.FolderType.Folder)
            {
                dialogResult = MessageBox.Show("Delete selected category", "Confirm delete", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            }
            else if (templatesMenager.ActiveNodeType == TemplatesManager.FolderType.File)
            {
                dialogResult = MessageBox.Show("Delete selected template", "Confirm delete", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            }
            else
            {
                dialogResult = DialogResult.Cancel;
            }

            if (dialogResult == DialogResult.OK)
            {
                templatesMenager.Delete();
                templatesMenager.LoadAll();
            }
        }

        private void tsbRefresh_Click(object sender, EventArgs e)
        {
            templatesMenager.LoadAll();
        }

        public TreeView TreeViewControl
        {
            get
            {
                return tvTree;
            }
            set
            {
                tvTree = value;
            }
        }
        public ImageList ImageListControl
        {
            set
            {
                this.tvTree.ImageList = value;
                tsbNew.Image = value.Images["newfile"];
                tsbLoad.Image = value.Images["load"];
                tsbSave.Image = value.Images["save"];
                tsbNewFolder.Image = value.Images["newfolder"];
                tsbDelete.Image = value.Images["delete"];
                tsbRefresh.Image = value.Images["refresh"];
            }
            get
            {
                return this.tvTree.ImageList;
            }
        }
        public TemplatesManager TemplatesMenager
        {
            set
            {
                this.templatesMenager = value;
            }
            get
            {
                return this.templatesMenager;
            }
        }

        private void tvTree_NodeMouseDoubleClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            tsbLoad_Click(null, null);
        }

        private void tvTree_Click(object sender, EventArgs e)
        {
            tvTree.SelectedNode = null;
        }

        private void tsbNew_Click(object sender, EventArgs e)
        {
            templatesMenager.Load(Common.BuildPath(GenericTemplate.moduleParams.DataPath, GenericTemplate.constModuleDataFolder) + GenericTemplate.DEFAULT_TEMPLATE_NAME);
        }
    }
}
