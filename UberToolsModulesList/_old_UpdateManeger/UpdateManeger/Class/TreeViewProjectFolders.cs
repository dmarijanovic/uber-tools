using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

using DamirM.Dll.CommonLibrary.Forms;

namespace UberTools.Plugin.UpdateManager.Class
{
    class TreeViewProjectFolders
    {
        ProjectFolder productFolder;
        TreeNode treeNode;

        public TreeViewProjectFolders(TreeNode treeNode, ProjectFolder productFolder)
        {
            this.treeNode = treeNode;
            this.productFolder = productFolder;
            this.productFolder.LinkReference = treeNode;
        }
        public void CreateTree()
        {
            try
            {
                BrowserProductFolder(this.treeNode, this.productFolder);
            }
            catch (Exception ex)
            {
                Log.Write(ex, this, "CreateTree", Log.LogType.ERROR);
            }
        }


        private void BrowserProductFolder(TreeNode treeNode, ProjectFolder projectFolder)
        {
            TreeNode node;

            foreach (ProjectFolder pf in (IEnumerable<ProjectFolder>)projectFolder)
            {
                node = new TreeNode(pf.Name);
                pf.LinkReference = node;
                treeNode.Nodes.Add(node);
                BrowserProductFolder(node, pf);
            }
        }
    }
}
