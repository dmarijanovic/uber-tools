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
    class FileParser
    {
        RowCollectionMenager rowCollectionMenager;
        string rootFolder;
        string regexFolderMatcher;
        string regexFileMatcher;
        string regexSpliterColumn;
        bool subfolders;

        public FileParser(RowCollectionMenager rowCollectionMenager)
        {
            this.rowCollectionMenager = rowCollectionMenager;
        }

        public void AutomaticAddToRowCollectionMenager_FileSource(string rootFolder, string regexFolderMatcher, string regexFileMatcher, string regexSpliterColumn, bool subfolders)
        {
            this.rootFolder = rootFolder;
            this.regexFolderMatcher = regexFolderMatcher;
            this.regexFileMatcher = regexFileMatcher;
            this.regexSpliterColumn = regexSpliterColumn;
            this.subfolders = subfolders;

            BrowseFolders(rootFolder);
        }

        private void BrowseFolders(string path)
        {
            Regex regex;
            Match match;
            int counter = 0;
            string[] folderList = Directory.GetDirectories(path);

            regex = new Regex(regexFolderMatcher, RegexOptions.IgnoreCase);

            foreach (string folder in folderList)
            {
                match = regex.Match(folder);

                if (match.Length > 0)
                {
                    //rowCollectionMenager.AddRow(new ObjectRow(null, FolderParser.SplitRow(folder, regexSpliterColumn)));
                    ImportFiles(folder);
                    if (subfolders == true)
                    {
                        BrowseFolders(folder);
                    }
                }

                if ((counter++ % 1000) == 0)
                {
                    System.Windows.Forms.Application.DoEvents();
                }
            }
        }

        private void ImportFiles(string folderPath)
        {
            RowCollection rowCollection;
            Regex regex;
            Match match;
            RowCollectionRow objectRow;
            string[] fileColumns;
            string[] fileList = Directory.GetFiles(folderPath);

            regex = new Regex(regexFileMatcher, RegexOptions.IgnoreCase);

            foreach (string file in fileList)
            {
                match = regex.Match(file);

                if (match.Length > 0)
                {
                    fileColumns =  SplitRow(file, regexSpliterColumn);
                    rowCollection = rowCollectionMenager.GetRowCollectionObjectFromCellNumber(3 + fileColumns.Length, true);
                    objectRow = new RowCollectionRow(rowCollection, Common.MargeTwoStringArray(GetDefaultColumns(file),fileColumns));
                    rowCollection.Rows.Add(objectRow);
                }
            }
        }

        public string[] SplitRow(string filePath, string regexSpliter)
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

                    result = regex.Split(filePath);
                }
                else
                {
                    result = new string[] { filePath };
                }
            }
            catch (Exception ex)
            {
                ModuleLog.Write(ex, typeof(FileParser), "SplitRow", ModuleLog.LogType.ERROR, true);
                ModuleLog.Write(filePath + "\r\n" + regexSpliter, typeof(FileParser), "SplitRow", ModuleLog.LogType.DEBUG);
                result = null;
            }
            return result;
        }


        /// <summary>
        /// Make string array of default columns
        /// </summary>
        /// <param name="filePath"></param>
        /// <returns></returns>
        private string[] GetDefaultColumns(string filePath)
        {
            string localPath;
            string fileName;

            localPath = Common.ExtractFolderFromPath(filePath).Remove(0, rootFolder.Length);
            fileName = Common.ExtractFileFromPath(filePath);
            return new string[] { rootFolder, localPath, fileName };
        }
    }
}
