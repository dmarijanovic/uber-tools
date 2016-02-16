using System;

using DamirM.Modules;
using UberTools.Modules.QuickTags.Forms;

namespace UberTools.Modules.QuickTags
{
    [Module]
    public class QuickTags: ModuleClassBase, IModule
    {
        private const string constModuleName = "Quick Tags";
        public const string constModuleDataFolder = "Quick Tags";

        public event ModuleManager.delModule Unload;

        public ModuleMainFormBase ShowDialog(System.Windows.Forms.Form owner, bool isMDIChild)
        {
            ModuleMainForm formToStart = new ModuleMainForm();
            formToStart.FormClosed += new System.Windows.Forms.FormClosedEventHandler(formToStart_FormClosed);
            return base.ShowDialog(owner, formToStart, isMDIChild, constModuleName);
        }

        public override System.Drawing.Icon Icon
        {
            get
            {
                return null;
            }
        }

        void formToStart_FormClosed(object sender, System.Windows.Forms.FormClosedEventArgs e)
        {
            Unload(this);
        }

        public string Name
        {
            get
            {
                return constModuleName;
            }
        }
        public string DataFolder
        {
            get
            {
                return constModuleDataFolder;
            }
        }
    }
}
