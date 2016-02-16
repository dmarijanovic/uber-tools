using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DamirM.Class
{
    public class Tag
    {
        private Tag tags;
        private string name;
        private string value;

        public Tag(string name, string value)
        {
            this.name = name;
            this.value = value;
            if (!value.Equals(""))
            {
                this.tags = ParseValue(value);
            }
        }
        private Tag ParseValue(string value)
        {
            //string[] valueList = value.Split('.');
            //if (valueList.Length >= 2)
            //{
            //    //0123456.89
            //    // 10 - 7
            //    return new Tag(valueList[0], value.Substring(valueList[0].Length + 1, (value.Length - valueList[0].Length) - 1));
            //}

            // {=string.indexof." . ".test text}
            // 
            int indexofFirstDot = 0;
            int indexofFirstQuotes = 0;
            int indexofSecondQuotes = 0;

            indexofFirstDot = value.IndexOf('.');
            indexofFirstQuotes = IndexOf("\"", 0, value, '\\');
            indexofSecondQuotes = IndexOf("\"", indexofFirstQuotes + 1, value, '\\');

            // if frist dot is before first quotes
            if (indexofFirstQuotes == -1 || (indexofFirstDot < indexofFirstQuotes))
            {
                return new Tag(value.Substring(0, indexofFirstDot != -1 ? indexofFirstDot : 0), value.Substring(indexofFirstDot != -1 ? indexofFirstDot + 1 : 0, indexofFirstDot != -1 ? ((value.Length - indexofFirstDot) - 1) : 0));
            }
            else
            {
                // if first dot is before secend quotes
                if (indexofFirstDot < indexofSecondQuotes)
                {
                    indexofFirstDot = value.IndexOf('.', indexofSecondQuotes + 1);
                    if (indexofFirstDot > 0)
                    {
                        return new Tag(value.Substring(0, indexofFirstDot), value.Substring(indexofFirstDot + 1, (value.Length - indexofFirstDot) - 1));
                    }
                }
                else
                {
                    return new Tag(value.Substring(0, indexofFirstDot), value.Substring(indexofFirstDot + 1, (value.Length - indexofFirstDot) - 1));
                }
            }


            return null;
        }

        private string UnEscape(string text)
        {
            string result = "";
            result = text.Replace("<*D*>", ".");
            if (text.StartsWith("\"") && text.EndsWith("\"") && text.Length > 1)
            {
                result = (text.Substring(1, text.Length - 1)).Substring(0, text.Length - 2);
            }

            return result;
        }

        /// <summary>
        /// Same like String.IndexOf method but this method will ignore search text if chast is escaped
        /// </summary>
        /// <param name="search"></param>
        /// <param name="start"></param>
        /// <param name="text"></param>
        /// <param name="escapeChar"></param>
        /// <returns></returns>
        private int IndexOf(string search, int start, string text, char escapeChar)
        {
            int indexOf = 0;

            do
            {
                // reguler indexof search
                indexOf = text.IndexOf(search, start);

                // if char is found
                if (indexOf != -1)
                {
                    // check if indexof is greater of 1 so if we can check if search text is escaped
                    if (indexOf > 0)
                    {
                        // if search text is not escaped
                        if (text[indexOf - 1] != escapeChar)
                        {
                            // index OK, exit
                            break;
                        }
                    }
                    else
                    {
                        // indexof is zero so it can not be escaped
                        break;
                    }
                    start = indexOf + 1;
                }
            } while (indexOf != -1);

            return indexOf;
        }

        public Tag Tags
        {
            get { return this.tags; }
        }
        public string Name
        {
            get { return UnEscape(this.name); }
        }
        public string Value
        {
            get { return UnEscape(this.value); }
            set { this.value = value; }
        }
        public override string ToString()
        {
            return UnEscape(this.name);
        }
    }
}
