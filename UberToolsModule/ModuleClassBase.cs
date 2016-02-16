using System;
using System.Collections.Generic;
using System.Text;

namespace DamirM.Modules
{
    public abstract class ModuleClassBase
    {
        System.Windows.Forms.Form startForm = null;
        private const string constPluginName = "Default module name";
        private ModuleObject moduleObject;
        private bool isMDIChild = true;
        public static ModuleParams moduleParams;
        public ModuleLog log;


        public ModuleMainFormBase ShowDialog(System.Windows.Forms.Form owner, ModuleMainFormBase formToStart, bool isMDIChild, string formName)
        {
            if (ModuleClassBase.moduleParams == null)
            {
                throw new Exception("Parametri nisu definirani");
            }
            if (isMDIChild)
            {
                formToStart.MdiParent = owner;
            }
            formToStart.Show();
            formToStart.Text = formName;
            this.isMDIChild = isMDIChild;
            return formToStart;
        }

        public abstract System.Drawing.Icon Icon{ get; }

        public bool IsMDIChild
        {
            set { this.isMDIChild = value; }
        }
        public ModuleLog GetModuleLog
        {
            get { return ModuleLog.moduleLog; }
            set { ModuleLog.moduleLog = value; }
        }

        /// <summary>
        /// Module params set by host application
        /// </summary>
        public ModuleParams ModuleParams
        {
            get { return moduleParams; }
            set { moduleParams = value; }
        }


        //public string ModuleObject
        //{
        //    get
        //    {
        //        return "";
        //    }
        //    set
        //    {
        //        string s = value;
        //    }
        //}
    }
}
