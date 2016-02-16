using System;
using System.Collections.Generic;
using System.Collections;
using System.Text;
using System.Text.RegularExpressions;

using System.IO;

using UberTools.Modules.GenericTemplate.RowCollectionNS;
using UberTools.Modules.GenericTemplate.Controls;
using  DamirM.Modules;
using DamirM.CommonLibrary;

namespace UberTools.Modules.GenericTemplate.InputData
{
    class FolderParser
    {
        RowCollectionMenager rowCollectionMenager;
        string rootFolder;
        string regexFolderMatcher;
        string regexSpliterColumn;
        bool subfolders;

        public FolderParser(RowCollectionMenager rowCollectionMenager)
        {
            this.rowCollectionMenager = rowCollectionMenager;
        }

        public void AutomaticAddToRowCollectionMenager_FolderSource(string rootFolder, string regexFolderMatcher, string regexSpliterColumn, bool subfolders)
        {
            this.rootFolder = rootFolder;
            this.regexFolderMatcher = regexFolderMatcher;
            this.regexSpliterColumn = regexSpliterColumn;
            this.subfolders = subfolders;

            BrowseFolders(rootFolder);
        }

        private void BrowseFolders(string path)
        {
            RowCollection rowCollection;
            RowCollectionRow objectRow;
            Regex regex;
            Match match;
            string[] folderColumns;
            int counter = 0;
            string[] folderList = Directory.GetDirectories(path);

            // define regex matcher
            regex = new Regex(regexFolderMatcher, RegexOptions.IgnoreCase);
            foreach (string folder in folderList)
            {
                match = regex.Match(folder);

                if (match.Length > 0)
                {
                    ModuleLog.Write(new string[] { "Folder: " + path, "Match: yes" }, this, "BrowseFolders", ModuleLog.LogType.DEBUG);
                    folderColumns = FolderParser.SplitRow(folder, regexSpliterColumn);
                    // new rowcollection
                    rowCollection = rowCollectionMenager.GetRowCollectionObjectFromCellNumber(2 + folderColumns.Length, true);

                    objectRow = new RowCollectionRow(rowCollection, Common.MargeTwoStringArray(GetDefaultColumns(folder), folderColumns));
                    //rowCollectionMenager.AddRow(objectRow);
                    rowCollection.Rows.Add(objectRow);
                    if (subfolders == true)
                    {
                        BrowseFolders(folder);
                    }
                }
                else
                {
                    // dont import folder but browse childs
                    if (subfolders == true)
                    {
                        ModuleLog.Write(new string[] { "Folder: " + path, "Match: no" }, this, "BrowseFolders", ModuleLog.LogType.DEBUG);
                        BrowseFolders(folder);
                    }
                    else
                    {
                        ModuleLog.Write(new string[] { "Folder: " + path, "Match: skip" }, this, "BrowseFolders", ModuleLog.LogType.DEBUG);
                    }
                }
                if ((counter++ % 1000) == 0)
                {
                    System.Windows.Forms.Application.DoEvents();
                }
            }
        }

        public static string[] SplitRow(string path, string regexSpliter)
        {
            ArrayList list;
            Regex regex;
            string[] result;
            try
            {
                if (!regexSpliter.Equals(""))
                {
                    list = new ArrayList();
                    regex = new Regex(regexSpliter);
                    result = regex.Split(path);
                }
                else
                {
                    result = new string[]{path};
                }
            }
            catch (Exception ex)
            {
                ModuleLog.Write(ex, typeof(TextParser), "SplitRow", ModuleLog.LogType.ERROR, true);
                ModuleLog.Write(path + "\r\n" + regexSpliter, typeof(TextParser), "SplitRow", ModuleLog.LogType.DEBUG);
                result = null;
            }
            return result;
        }

        private string[] GetDefaultColumns(string path)
        {
            string localPath;

            localPath = path.Remove(0, rootFolder.Length);
            return new string[] { rootFolder, localPath};
        }

    }
}
