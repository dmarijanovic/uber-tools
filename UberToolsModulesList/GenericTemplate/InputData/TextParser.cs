using System;
using System.Collections.Generic;
using System.Collections;
using System.Text;
using System.Text.RegularExpressions;

using UberTools.Modules.GenericTemplate.Class;
using DamirM.Modules;
using UberTools.Modules.GenericTemplate.RowCollectionNS;

namespace UberTools.Modules.GenericTemplate.InputData
{
    class TextParser
    {
        RowCollectionMenager rowCollectionMenager;
        public TextParser(RowCollectionMenager rowCollectionMenager)
        {
            this.rowCollectionMenager = rowCollectionMenager;
        }
        //public void AutomaticAddToRowCollectionMenager_ClipboardSource(string regexSpliterColumn, string regexSpliterRow)
        //{
        //    int counter = 0;
        //    string[] lineList = TextParser.SplitRow(System.Windows.Forms.Clipboard.GetText(), regexSpliterRow);

        //    if (System.Windows.Forms.Clipboard.ContainsText())
        //    {
        //        foreach (string line in lineList)
        //        {
        //            rowCollectionMenager.AddRow(new ObjectRow(null, TextParser.SplitRow(line, regexSpliterColumn)));
        //            if ((counter++ % 1000) == 0)
        //            {
        //                System.Windows.Forms.Application.DoEvents();
        //            }
        //        }
        //    }
        //}

        public void AutomaticAddToRowCollectionMenager_ClipboardSource(string regexSpliterColumn, string regexSpliterRow, bool firstRowAsColumnName)
        {
            RowCollection rowCollection;
            RowCollectionRow row;

            string[] lineList;
            string[] columnList;
            int counter = 0;

            // Get array of rows
            lineList = TextParser.SplitRow(System.Windows.Forms.Clipboard.GetText(), regexSpliterRow);

            // If row list is null then exit
            if (lineList == null)
            {
                return;
            }

            // Go through all rows
            foreach (string line in lineList)
            {
                // Split row in array of columns
                columnList = TextParser.SplitRow(line, regexSpliterColumn);
                // get rowCollection object
                rowCollection = rowCollectionMenager.GetRowCollectionObjectFromCellNumber(columnList.Length, false);
                // check if rowCollection is null
                if (rowCollection == null)
                {
                    // create new rowCollecion object
                    //rowCollection = new RowCollection(columnList.Length, RowCollection.const_prefix + columnList.Length.ToString());
                    rowCollection = rowCollectionMenager.CreateRowCollection(columnList.Length);

                    // define column names
                    if (firstRowAsColumnName == true)
                    {
                        for (int i = 0; i < columnList.Length; i++)
                        {
                            rowCollection.Columns[i] = columnList[i];
                        }
                    }
                    else
                    {
                        // create new row object from column array
                        row = new RowCollectionRow(rowCollection, columnList);
                        // add row to rowCollection
                        rowCollection.Rows.Add(row);
                    }
                }
                else
                {
                    // create new row object from column array
                    row = new RowCollectionRow(rowCollection, columnList);
                    // add row to rowCollection
                    rowCollection.Rows.Add(row);
                }
                //rowCollectionMenager.AddRow(new ObjectRow(null, TextParser.SplitRow(line, regexSpliterColumn)));
                if ((counter++ % 1000) == 0)
                {
                    System.Windows.Forms.Application.DoEvents();
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


        /// <summary>
        /// Izmjene pravite u uredu, provjeriti code
        /// </summary>
        /// <param name="input"></param>
        /// <param name="regexSpliterColumn"></param>
        /// <param name="regexSpliterRow"></param>
        public void AutomaticAddToRowCollectionMenager(string input, string regexSpliterColumn, string regexSpliterRow)
        {
            //int counter = 0;
            //string[] lineList = TextParser.SplitRow(input, regexSpliterRow);

            

            //foreach (string line in lineList)
            //{
            //    rowCollectionMenager.AddRow(new RowCollectionRow(null, TextParser.SplitRow(line, regexSpliterColumn)));
            //    if ((counter++ % 1000) == 0)
            //    {
            //        System.Windows.Forms.Application.DoEvents();
            //    }
            //}

            RowCollection rowCollection;
            RowCollectionRow row;

            string[] lineList;
            string[] columnList;
            bool firstRowAsColumnName = false;
            int counter = 0;

            // Get array of rows
            lineList = TextParser.SplitRow(input, regexSpliterRow);

            // If row list is null then exit
            if (lineList == null)
            {
                return;
            }

            // Go through all rows
            foreach (string line in lineList)
            {
                // Split row in array of columns
                columnList = TextParser.SplitRow(line, regexSpliterColumn);
                // get rowCollection object
                rowCollection = rowCollectionMenager.GetRowCollectionObjectFromCellNumber(columnList.Length, false);
                // check if rowCollection is null
                if (rowCollection == null)
                {
                    // create new rowCollecion object
                    //rowCollection = new RowCollection(columnList.Length, RowCollection.const_prefix + columnList.Length.ToString());
                    rowCollection = rowCollectionMenager.CreateRowCollection(columnList.Length);

                    // define column names
                    if (firstRowAsColumnName == true)
                    {
                        for (int i = 0; i < columnList.Length; i++)
                        {
                            rowCollection.Columns[i] = columnList[i];
                        }
                    }
                    else
                    {
                        // create new row object from column array
                        row = new RowCollectionRow(rowCollection, columnList);
                        // add row to rowCollection
                        rowCollection.Rows.Add(row);
                    }
                }
                else
                {
                    // create new row object from column array
                    row = new RowCollectionRow(rowCollection, columnList);
                    // add row to rowCollection
                    rowCollection.Rows.Add(row);
                }
                //rowCollectionMenager.AddRow(new ObjectRow(null, TextParser.SplitRow(line, regexSpliterColumn)));
                if ((counter++ % 1000) == 0)
                {
                    System.Windows.Forms.Application.DoEvents();
                }
            }


        }

    }
}
