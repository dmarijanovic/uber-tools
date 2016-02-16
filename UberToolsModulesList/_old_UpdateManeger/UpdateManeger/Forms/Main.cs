using System;
using System.Collections.Generic;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using DamirM.Dll.CommonLibrary.Forms;
using DamirM.AutoUpdate;
using UberTools.Plugin.UpdateManager.Class;

namespace UberTools.Plugin.UpdateManager.Forms
{
    public partial class Main : Form
    {
        private ProjectManager projectManager;

        private Project project; // tmp

        public Main()
        {
            InitializeComponent();
        }

        private void splitContainer1_Panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void tsbConnect_Click(object sender, EventArgs e)
        {
            //return "DRIVER={MySQL ODBC 5.1 Driver};SERVER=mobilis.hr;PORT=3306;DATABASE=mobilis_pretplata;UID=mobilis_appbaza;PWD=ed7R7b#C7,IX;OPTION=3";
            //string connectionString = "DRIVER={MySQL ODBC 5.1 Driver};SERVER=localhost;PORT=3306;DATABASE=autoupdate;UID=root;PWD=dambaa;OPTION=3";
            //LoginForm frm = new LoginForm(connectionString);
            //frm.ShowDialog(this);
            //Log.Write(frm.UserID.ToString());


            projectManager = new ProjectManager();
            projectManager.GetProjectList();

            tvProductList.Nodes.Clear();
            TreeViewProjectList tvpl = new TreeViewProjectList(tvProductList, projectManager.ProjectList);
            tvpl.CreateTree();
            
            

        }

        private void ShowProject()
        {
            project = new Project("C:\\extras");
            project.ScanProject();

            TreeNode rootNode = new TreeNode("Project root folder");
            TreeViewProjectFolders tvpf = new TreeViewProjectFolders(rootNode, project.GetRootFolder);
            tvpf.CreateTree();
            tvProjectFolders.Nodes.Clear();
            tvProjectFolders.Nodes.Add(rootNode);
        }


        private void tvProductList_NodeMouseDoubleClick(object sender, TreeNodeMouseClickEventArgs e)
        {

            ShowProject();
        }

        private void UploadProject()
        {
            //MessageBox.Show(e.Node.Text);

            System.Collections.Specialized.NameValueCollection nvc = new System.Collections.Specialized.NameValueCollection();

            WebCalls webCalls = WebCalls.Create();
            try
            {
                webCalls.UploadFiles("http://update.local/upload.php", new string[] { "c:\\test.rar" }, nvc);
            }
            catch (Exception ex)
            {
                Log.Write(ex, this, "tvProductList_NodeMouseDoubleClick", Log.LogType.ERROR);
            }
        }

        private void tvProjectFolders_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            ProjectFolder pf = project.GetProductFolderFromLinkReference(e.Node);
            lvProjectFiles.Items.Clear();
            ListViewProjectFiles lvpf = new ListViewProjectFiles(lvProjectFiles, pf);
            lvpf.Fill();
        }
    }
}
