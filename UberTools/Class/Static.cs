using System;
using System.Collections.Generic;
using System.Collections;
using System.Text;

namespace NTHTools
{
    class Static
    {
        public const string constSettingFileName = "settings.xml";
        public const string conConnectionString = @"Data Source=C:\Documents and Settings\Damir\My Documents\Visual Studio 2008\Projects\NTHTools\NTHTools\db.sdf";
        public const string conUpdateURL = "http://update.ubertools.net/";
        //public const string conUpdateURL = "http://update.local/";
        public const string conProductName = "ubertools";
        public const string conUsername = "ubertools";
        public const string conPassword = "ub3rt0015642";
        //public const string conConnectionString = @"Data Source=|DataDirectory|\db.sdf";

        /// <summary>
        /// NIJE U FUNKCIJI
        /// </summary>
        /// <param name="stringData"></param>
        /// <param name="deleminators"></param>
        /// <param name="returnDeleminator"></param>
        /// <returns></returns>
        public static string GetUniqueList(string stringData, char[] deleminators, string returnDeleminator)
        {
            string result = returnDeleminator;
            ArrayList list = new ArrayList();
            bool flag = false;
            string[] split = stringData.Split(deleminators, StringSplitOptions.RemoveEmptyEntries);
            foreach (string id in split)
            {
                flag = false;
                foreach (string listID in list)
                {
                    if (listID == id)
                    {
                        result += id;
                        flag = true;
                    }
                }
                if (!flag)
                {
                    list.Add(id);
                }
            }
            foreach (string id in list)
            {
                result += "id" + returnDeleminator;
            }
            result = result.Substring(0, result.Length - returnDeleminator.Length);
            return result;
        }

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
