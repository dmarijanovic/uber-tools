using System;
using System.Collections.Generic;
using System.Text;

namespace DamirM.Modules
{
    public class ModuleObject
    {
        string path;
        string name;
        bool active;
        IModule instance;
        AppDomain appDomain;

        ModuleManager.delModuleObject OnActivateModule;

        public ModuleObject(string path, string name, ModuleManager.delModuleObject OnActivateModule)
        {
            this.path = path;
            this.name = name;
            this.active = false;
            this.OnActivateModule = OnActivateModule;
        }
        public void Activeite(object sender, EventArgs e)
        {
            this.active = true;
            OnActivateModule(this);
        }

        public string Path
        {
            get { return this.path; }
        }
        public string Name
        {
            get { return this.name; }
        }
        public bool Active
        {
            get { return this.active; }
            set { this.active = value; }
        }

        public IModule Instance
        {
            set
            {
                this.instance = value;
            }
            get
            {
                return this.instance;
            }
        }

        public AppDomain AppDomain
        {
            set
            {
                this.appDomain = value;
            }
            get
            {
                return this.appDomain;
            }
        }
    }
}
