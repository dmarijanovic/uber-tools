using System;
using System.Collections.Generic;
using System.Collections;
using System.Text;
using System.IO;

using DamirM.CommonLibrary;

namespace UberTools.Modules.QuickTags
{
    public static class Static
    {

        /// <summary>
        /// TODO: wtf radi ova funkcija 
        /// </summary>
        /// <param name="stringData"></param>
        /// <param name="deleminators"></param>
        /// <param name="returnDeleminator"></param>
        /// <param name="retrunForCount"></param>
        /// <returns></returns>
        public static string GetCountEquls(string stringData, char[] deleminators, string returnDeleminator, int retrunForCount)
        {
            string result = "";
            ArrayList list = new ArrayList();
            bool flag = false;
            string[] split = stringData.Split(deleminators, StringSplitOptions.RemoveEmptyEntries);
            foreach (string line in split)
            {
                flag = false;
                foreach (DataHandle data in list)
                {
                    if (data.name == line)
                    {
                        data.count++;
                        flag = true;
                    }
                }
                if (!flag)
                {
                    list.Add(new DataHandle(line, 1));
                }
            }
            foreach (DataHandle data in list)
            {
                if (data.count == retrunForCount)
                {
                    result += data.name + returnDeleminator;
                }
            }
            if (result.EndsWith(returnDeleminator))
            {
                result = result.Substring(0, result.Length - returnDeleminator.Length);
            }
            return result;
        }

        public static void CheckDB_SDF()
        {
            string empty_db_path;
            string destination_db_path;

            empty_db_path = DataFolderPath + "db_empty.sdf";
            destination_db_path = GetDBPath_SDF;

            if (File.Exists(destination_db_path) == false)
            {
                Log.Write(new string[] { "No database file found (SQL Server Compact Edition Database File)", GetDBPath_SDF }, typeof(Log), "CheckDB_SDF", Log.LogType.DEBUG);
                if (File.Exists(empty_db_path) == true)
                {
                    Log.Write("Creating new empty database", typeof(Log), "CheckDB_SDF", Log.LogType.DEBUG);
                    File.Copy(empty_db_path, destination_db_path);
                }
                else
                {
                    Log.Write(new string[] { "Empty database not found", "Source: " + empty_db_path }, typeof(Log), "CheckDB_SDF", Log.LogType.DEBUG);
                }
            }

        }

        public static string ConnectionString
        {
            get
            {
                return string.Format("Data Source={0}", GetDBPath_SDF);
            }
        }
        /// <summary>
        /// SQL Server Compact Edition Database File
        /// </summary>
        public static string GetDBPath_SDF
        {
            get
            {
                return DataFolderPath + "db.sdf";
            }
        }


        public static string DataFolderPath
        {
            get{
                return Common.BuildPath(QuickTags.moduleParams.DataPath, QuickTags.constModuleDataFolder);
            }
        }
    }

    class DataHandle
    {
        public string name;
        public int count;
        public DataHandle(string name, int count)
        {
            this.name = name;
            this.count = count;
        }
    }
}
