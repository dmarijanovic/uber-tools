using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DamirM.Modules
{
    public class ModuleLog
    {
        public enum LogType
        {
            ALL, DEBUG, INFO, ERROR, WARNING, UNKNOWEN
        }
        public static ModuleLog moduleLog;
        public delegate void delLog(object text, object from, string action, object logType, bool showMessage);
        public event delLog OnLog;
        public ModuleLog()
        {
        }
        public static void CreateStaticInstance()
        {
            if (moduleLog == null)
            {
                ModuleLog.moduleLog = new ModuleLog();
            }
        }
        public static void Write(object text)
        {
            moduleLog.OnLog(text, typeof(ModuleLog), "Write", LogType.DEBUG, false);
        }
        public static void Write(object text, object from, string action, LogType logType, bool showMessage)
        {
            moduleLog.OnLog(text, from, action, logType.ToString(), showMessage);
        }
        public static void Write(object text, object from, string action, LogType logType)
        {
            moduleLog.OnLog(text, from, action, logType.ToString(), false);
        }
    }
}
