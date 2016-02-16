using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DamirM.Modules
{
    public class ModuleParams
    {
        private string dataPath;
        public ModuleParams()
        {
        }
        public string DataPath
        {
            set { this.dataPath = value; }
            get { return this.dataPath; }
        }

    }
}
