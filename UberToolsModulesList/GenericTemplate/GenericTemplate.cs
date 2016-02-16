using System;


using UberTools.Modules.GenericTemplate.Forms;
using  DamirM.Modules;

namespace UberTools.Modules.GenericTemplate
{
    [Module]
    public class GenericTemplate : ModuleClassBase, IModule
    {
        public const string constModuleDataFolder = "GenericTemplates";
        public const string constTemplateFolder = "Templates";
        public const string constDataObjectsFolder = "DataObjects";
        public const string constTagsXMLFileName = "tags.xml";
        public const string DEFAULT_TEMPLATE_NAME = "default-template.xml";
        public const string constModuleName = "Generic template";
        //public static UberToolsPluginParams uberToolsPluginParams;
        public event ModuleManager.delModule Unload;

        public GenericTemplate()
        {
            ModuleLog.CreateStaticInstance();


            AppDomain.CurrentDomain.UnhandledException += new UnhandledExceptionEventHandler(CurrentDomain_UnhandledException);
            //Application.ThreadException += new ThreadExceptionEventHandler(Application_ThreadException);
        }

        //void Application_ThreadException(object sender, ThreadExceptionEventArgs e)
        //{
        //    ModuleLog.Write(e.Exception, this, "Application_ThreadException", Log.LogType.ERROR);
        //}

        void CurrentDomain_UnhandledException(object sender, UnhandledExceptionEventArgs e)
        {
            ModuleLog.Write(e.ExceptionObject, this, "CurrentDomain_UnhandledException", ModuleLog.LogType.ERROR);
        }

        public ModuleMainFormBase ShowDialog(System.Windows.Forms.Form owner, bool isMDIChild)
        {
            ModuleMainForm formToStart = new ModuleMainForm();
            formToStart.FormClosed += new System.Windows.Forms.FormClosedEventHandler(formToStart_FormClosed);
            return base.ShowDialog(owner, formToStart, isMDIChild, constModuleName);
        }

        void formToStart_FormClosed(object sender, System.Windows.Forms.FormClosedEventArgs e)
        {
            Unload(this);
        }


        public override System.Drawing.Icon Icon
        {
            get 
            {
                System.Drawing.Icon icon = null;
                try
                {
                    icon = global::UberTools.Modules.GenericTemplate.Properties.Resources.WindowsTable;
                }
                catch (Exception ex)
                {
                    ModuleLog.Write(ex, this, "Icon", ModuleLog.LogType.ERROR);
                }
                return icon;
            }
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
