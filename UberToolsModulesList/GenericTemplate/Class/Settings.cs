using System;
using System.Collections.Generic;
using System.Text;

using DamirM.CommonLibrary;
using DamirM.Modules;

namespace UberTools.Modules.GenericTemplate
{
    public static class Settings
    {
        public const string FILE_NAME = "settings.xml";
        private static SettingsMenager2 settings;

        public enum SettingName
        {
            ActiveTemplateName,
        }

        public static void Init()
        {
            if (settings == null)
            {
                settings = new SettingsMenager2(GenericTemplate.constModuleName, "UberToolsModule", "1.0.0.0");
            }
        }

        public static SettingsMenager2 Setting
        {
            get 
            {
                if (settings != null)
                {
                    return settings;
                }
                else
                {
                    ModuleLog.Write("Call Init method before accessing settings", typeof(Settings), "Setting", ModuleLog.LogType.ERROR);
                    return null;
                }

            }
        }
    }
}
