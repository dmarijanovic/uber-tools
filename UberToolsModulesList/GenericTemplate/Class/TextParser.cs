using System;
using System.Collections.Generic;
using System.Collections;
using System.Text;
using System.Text.RegularExpressions;
using UberTools.Plugin.TemplatesFiller.Class;
using DamirM.Module.ModuleManager;

namespace UberTools.Plugin.TemplatesFiller.Class
{
    class TextParser
    {
        RowCollectionMenager rowCollectionMenager;
        public TextParser(RowCollectionMenager rowCollectionMenager)
        {
            this.rowCollectionMenager = rowCollectionMenager;
        }
        public void AutomaticAddToRowCollectionMenager_ClipboardSource(string regexSpliterColumn, string regexSpliterRow)
        {
            int counter = 0;
            string[] lineList = TextParser.SplitRow(System.Windows.Forms.Clipboard.GetText(), regexSpliterRow);

            if (System.Windows.Forms.Clipboard.ContainsText())
            {
                foreach (string line in lineList)
                {
                    rowCollectionMenager.AddRow(new ObjectRow(null, TextParser.SplitRow(line, regexSpliterColumn)));
                    if ((counter++ % 1000) == 0)
                    {
                        System.Windows.Forms.Application.DoEvents();
                    }
                }
            }
        }

        public static string[] SplitRow(string text, string regexSpliter)
        {
            ArrayList list;
            Regex regex;
            string[] result;
            try
            {
                list = new ArrayList();
                regex = new Regex(regexSpliter);
                result = regex.Split(text);
            }
            catch (Exception ex)
            {
                ModuleLog.Write(ex, typeof(TextParser), "SplitRow", ModuleLog.LogType.ERROR, true);
                ModuleLog.Write(text + "\r\n" + regexSpliter, typeof(TextParser), "SplitRow", ModuleLog.LogType.DEBUG);
                result = null;
            }
            return result;
        }
        public void AutomaticAddToRowCollectionMenager(string input, string regexSpliterColumn, string regexSpliterRow)
        {
            int counter = 0;
            string[] lineList = TextParser.SplitRow(input, regexSpliterRow);

            foreach (string line in lineList)
            {
                rowCollectionMenager.AddRow(new ObjectRow(null, TextParser.SplitRow(line, regexSpliterColumn)));
                if ((counter++ % 1000) == 0)
                {
                    System.Windows.Forms.Application.DoEvents();
                }
            }
        }

    }
}
