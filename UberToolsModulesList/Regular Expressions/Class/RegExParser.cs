using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

using DamirM.CommonLibrary;

namespace UberTools.Modules.RegularExpressions
{
    class RegExParser
    {
        RegexOptions regexOptions;

        string regExExpresion;
        string text;

        public RegExParser(string regEx, string text, RegexOptions regexOptions)
        {
            this.regexOptions = regexOptions;
            this.regExExpresion = regEx;
            this.text = text;
        }
        public RegExParser(RegexOptions regexOptions)
        {
            this.regexOptions = regexOptions;
            this.regExExpresion = "";
            this.text = "";
        }

        public string GetMatches()
        {
            MatchCollection matches = null;
            Regex regEx;

            string result = "Syntax error";

            try
            {

                regEx = new Regex(this.regExExpresion, regexOptions);
                matches = regEx.Matches(this.text);

                result = "";
                foreach (Match match in matches)
                {
                    result = string.Concat(result, match.Value, Environment.NewLine);
                }

            }
            catch (Exception ex)
            {
                Log.Write(ex, this, "GetMatch", Log.LogType.ERROR);
            }
            return result;
        }


        public string RegExExpresion
        {
            set
            {
                this.regExExpresion = value;
            }
        }

        public string Text
        {
            set
            {
                this.text = value;
            }
        }

        public RegexOptions RegexOptions
        {
            set
            {
                this.regexOptions = value;
            }
        }

    }
}
