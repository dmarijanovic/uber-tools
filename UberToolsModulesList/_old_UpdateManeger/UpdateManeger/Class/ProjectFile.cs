using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace UberTools.Plugin.UpdateManager.Class
{
    public class ProjectFile
    {
        int id;
        string name;
        string path;
        bool publish;
        string md5;

        public ProjectFile(string name, string path)
        {
            this.name = name;
            this.path = path;

        }


        public string Name
        {
            get
            {
                return this.name;
            }
        }
        public string Path
        {
            get
            {
                return this.path;
            }
        }
        public bool Publish
        {
            get
            {
                return this.publish;
            }
        }
    }
}
