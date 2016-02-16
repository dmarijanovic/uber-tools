using System;
using System.Collections.Generic;
using System.Collections;
using System.Text;

using System.ComponentModel;
using System.Data;

using System.Windows.Forms;


namespace DamirM.Modules
{

    public class ModuleManager
    {
        private ArrayList list;
        public delegate void delModule(IModule module);
        public delegate void delModuleObject(ModuleObject moduleObject);
        public event delModuleObject OnActivateModule;

        public ModuleManager()
        {
            list = new ArrayList();
        }
        public ModuleObject Add(string path, string name)
        {
            ModuleObject moduleObject = new ModuleObject(path, name, OnActivateModule);
            list.Add(moduleObject);
            return moduleObject;
        }
        public void Remove(IModule module)
        {
            ModuleObject moduleObject;
            for (int i = 0; i < list.Count; i++)
            {
                moduleObject = (ModuleObject)list[i];
                if (moduleObject.Instance != null)
                {
                    if (moduleObject.Instance.Equals(module))
                    {
                        ModuleLog.Write("unloading module:" + moduleObject.Name, this, "Remove", ModuleLog.LogType.DEBUG);
                        list.Remove(moduleObject);
                        moduleObject = null;
                    }
                }
            }
        }

        public bool IsActive(IModule module)
        {
            foreach (ModuleObject moduleObject in list)
            {
                if (moduleObject.Instance != null)
                {
                    if (moduleObject.Instance.Equals(module))
                    {
                        return true;
                    }
                }
            }
            return false;
        }


    }
}
