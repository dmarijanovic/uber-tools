using System;
using System.Collections.Generic;
using System.Collections;
using System.Text;

using DamirM.AutoUpdate;

namespace UberTools.Plugin.UpdateManager.Class
{
    class ProjectManager
    {
        ArrayList projectList;

        public ProjectManager()
        {

        }

        public void GetProjectList()
        {
            FormProductList fpl = new FormProductList("http://update.local/");
            
            fpl.ShowDialog(System.Windows.Forms.Application.OpenForms[0]);
            this.projectList = fpl.GetProductList;
        }


        public ArrayList ProjectList
        {
            get
            {
                return this.projectList;
            }
        }

    }
}
