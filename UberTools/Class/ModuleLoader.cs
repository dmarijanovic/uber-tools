using System;
using System.Collections.Generic;
using System.Text;
using System.Reflection;
using System.IO;

namespace UberTools.Class
{
    public class ModuleLoader : MarshalByRefObject
    {
        public Assembly LoadAssambly(string file)
        {
            Assembly assembly;
            byte[] rawAssembly = loadFile(file);
            //assembly = Assembly.LoadFrom(file);
            assembly = Assembly.Load(rawAssembly);
            return assembly;
        }
        public Assembly ReflectionOnlyLoadAssambly(string file)
        {
            Assembly assembly;
            byte[] rawAssembly = loadFile(file);
            //assembly = Assembly.LoadFrom(file);
            assembly = Assembly.ReflectionOnlyLoad(rawAssembly);
            return assembly;
        }
        static byte[] loadFile(string filename)
        {

            FileStream fs = new FileStream(filename, FileMode.Open);

            byte[] buffer = new byte[(int)fs.Length];

            fs.Read(buffer, 0, buffer.Length);

            fs.Close();

            return buffer;

        }//End loadFile
    }
}
