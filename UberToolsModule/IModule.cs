using System;

namespace DamirM.Modules
{
    public interface IModule
    {
        ModuleMainFormBase ShowDialog(System.Windows.Forms.Form owner, bool isMDIChild);
        /// <summary>
        /// Module params set by host application
        /// </summary>
        ModuleParams ModuleParams { get; set; }
        ModuleLog GetModuleLog { get; set; }
        string Name { get; }
        string DataFolder { get;  }
        System.Drawing.Icon Icon { get; }


        event ModuleManager.delModule Unload;
        //string ModuleObject { get; set; }
    }
}