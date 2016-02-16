using System;
using System.Collections.Generic;
using System.Collections;
using System.Text;

namespace UberTools.Plugin.TemplatesFiller.Class
{
    class VarObjectStruct
    {
        private ArrayList list; 
        private string name;
        private Type type;
        private int index;


        public enum Type
        {
            Single, Array
        }

        public VarObjectStruct(string name, Type type)
        {
            this.name = name;
            this.type = type;
            this.list = new ArrayList();
            this.index = -1;
        }
        public void Add(string text)
        {
            if (this.type == Type.Single)
            {
                // Update text
                if (list.Count == 0)
                {
                    list.Add(text);
                }
                else
                {
                    list[0] = text;
                }
            }
            else
            {
                // Add text
                list.Add(text);
            }
        }

        public void AddOnce(string text)
        {
            if (this.type == Type.Single)
            {
                // Update text
                if (list.Count == 0)
                {
                    list.Add(text);
                }
                else
                {
                    list[0] = text;
                }
            }
            else
            {
                // Add text once
                bool isUnique = true;
                foreach (string item in list)
                {
                    if (item == text)
                    {
                        isUnique = false;
                        break;
                    }
                }
                if (isUnique)
                {
                    list.Add(text);
                }
            }
        }

        public Array ToArray()
        {
            return list.ToArray();
        }

        public string Fetch()
        {
            string result = "";

            if (list.Count > 0)
            {
                if (index == -1)
                {
                    index = 0;
                }
                result = list[this.index].ToString();
            }
            return result;
        }

        public string FetchNext()
        {
            index++;
            if (index >= list.Count)
            {
                index = 0;
            }
            return list[this.index].ToString();
        }

        public string Name
        {
            get
            {
                return name;
            }
        }
    }
}
