using System;
using System.Collections.Generic;
using System.Collections;
using System.Text;
using System.Windows.Forms;

using DamirM.AutoUpdate;
using DamirM.Dll.CommonLibrary.Forms;

namespace UberTools.Plugin.UpdateManager.Class
{
    class TreeViewProjectList
    {
        TreeView treeView;
        ArrayList projectList;

        public TreeViewProjectList(TreeView treeView, ArrayList projectList)
        {
            this.treeView = treeView;
            this.projectList = projectList;
        }
        public void CreateTree()
        {
            try
            {
                ShowProductList();
            }
            catch (Exception ex)
            {
                Log.Write(ex, this, "CreateTree", Log.LogType.ERROR);
            }
        }

        public void ShowProductList()
        {
            treeView.Nodes.Clear();
            foreach (Product product in projectList)
            {
                treeView.Nodes.Add(product.ToString());
            }
        }
    }
}
