using System;
using DamirM.Module.ModuleManager;
using UberToolsModuleTemplate.Forms;

namespace UberToolsModuleTemplate
{
    [Module]
    public class ModuleName : ModuleClassBase, IModule
    {
        private const string constModuleDataFolder = "UberToolsModuleTemplate";
        private const string constModuleName = "Default module name";

        public ModuleName()
        {
            // This will enable loging in main application
            ModuleLog.CreateStaticInstance();
        }

        /// <summary>
        /// Override module name
        /// </summary>
        /// <returns></returns>
        public new string GetPluginName()
        {
            return constModuleName;
        }

        /// <summary>
        /// This will open main module form from main application
        /// </summary>
        /// <param name="owner">Main program will be owner of form</param>
        /// <param name="isMDIChild">Show as MDI child window</param>
        /// <returns></returns>
        public System.Windows.Forms.Form ShowDialog(System.Windows.Forms.Form owner, bool isMDIChild)
        {
            Main frm = new Main();
            return base.ShowDialog(owner, frm, isMDIChild, constModuleName);
        }
    }
}
