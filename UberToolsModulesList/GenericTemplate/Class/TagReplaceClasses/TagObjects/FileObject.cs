using System;
using System.Collections.Generic;
using System.Collections;
using System.Text;
using System.IO;

using  DamirM.Modules;
using DamirM.Class;
using DamirM.Controls;
using DamirM.CommonLibrary;
using UberTools.Modules.GenericTemplate.Class;
using DamirM.CommonControls;

namespace UberTools.Modules.GenericTemplate.Class.TagObjects
{
    class FileObject
    {
        Tag2 tag;
        ArrayList varObjectStructList;


        public FileObject(Tag2 tag, ref ArrayList varObjectStructList)
        {
            this.tag = tag;
            this.varObjectStructList = varObjectStructList;
        }

        public string ProcessTag()
        {
            string result = null;
            try
            {
                if (tag.Child.Name == "copy")
                {
                    // {=file.copy.[source].[destination]}
                    string source = tag.Child.Child.Name;
                    string destination = tag.Child.Child.Child.Name;
                    this.CopyFile(source, destination);
                    result = "";
                }
                else if (tag.Child.Name == "copyall")
                {
                    // {=file.copyall.[ArrayObject].[destination]}
                    string objectName = tag.Child.Child.Name;
                    string destination = tag.Child.Child.Child.Name;
                    this.CopyAllFiles(objectName, destination);
                    result = "";

                }
                else if (tag.Child.Name == "move")
                {
                    //int maxChar;
                    //maxChar = int.Parse(tag.Tags.Value);
                    result = "NIJE IMPLEMENTIRANO";
                }
                else if (tag.Child.Name == "list")
                {
                    // {=file.list.[ArrayObject].[FolderPath]}
                    this.List(tag.Child.Child.Child.Name, tag.Child.Child.Name);
                    result = "";
                }


                // Error - not tag
                if (result == null)
                {
                    ModuleLog.Write(new string[] { TagsReplace.constError_CommandNotFound, tag.InputText }, this, "ProcessTag", ModuleLog.LogType.ERROR);
                    result = TagsReplace.constError_SyntaxError;
                }

            }
            catch (Exception ex)
            {
                ModuleLog.Write(new string[] { TagsReplace.constError_ExecutingBlock, tag.InputText }, this, "ProcessTag", ModuleLog.LogType.DEBUG);
                ModuleLog.Write(ex, this, "ProcessTag", ModuleLog.LogType.ERROR);
                result = TagsReplace.constError_SyntaxError;
            }
            return result;
        }

        private void CopyFile(string source, string destination)
        {
            ModuleLog.Write(new string[] { "Source: " + source, "Destination: " + destination }, this, "CopyFile", ModuleLog.LogType.DEBUG);

            if (!File.Exists(source))
            {
                ModuleLog.Write(string.Format("File dont exists\r\n{0}", source), this, "CopyFile", ModuleLog.LogType.WARNING);
            }
            else
            {
                Common.MakeAllSubFolders(Common.ExtractFolderFromPath(destination));
                File.Copy(source, destination, true);
            }
        }

        private void CopyAllFiles(string arrayObjectName, string destination)
        {
            string destinationPath;
            ArrayObject arrayObject = new ArrayObject(varObjectStructList);
            VarObjectStruct varObjectStruct = arrayObject.GetObjectFromName(arrayObjectName);
            Array fileList = varObjectStruct.ToArray();

            Common.MakeAllSubFolders(destination);
            destination = Common.SetSlashOnEndOfDirectory(destination);

            for (int i = 0; i < fileList.Length; i++)
			{
                if (!File.Exists(fileList.GetValue(i).ToString()))
                {
                    ModuleLog.Write(string.Format("File dont exists\r\n{0}", fileList.GetValue(i).ToString()), this, "CopyAllFiles", ModuleLog.LogType.WARNING);
                }
                else
                {
                    destinationPath = destination + Common.ExtractFileFromPath(fileList.GetValue(i).ToString());
                    ModuleLog.Write(new string[] { "Source: " + fileList.GetValue(i).ToString(), "Destination: " + destinationPath }, this, "CopyAllFiles", ModuleLog.LogType.DEBUG);

                    File.Copy(fileList.GetValue(i).ToString(), destinationPath, true);
                }
			}
        }

        private void List(string folderPath, string arrayObjectName)
        {
            // Get all files from folder and put it in array object

            ArrayObject arrayObject = new ArrayObject(varObjectStructList);

            foreach (string file in Directory.GetFiles(folderPath))
            {
                arrayObject.AddOnce(arrayObjectName, file);
            }
            //VarObjectStruct varObjectStruct = arrayObject.GetObjectFromName(arrayObjectName);
            //ModuleLog.Write(varObjectStruct.ToArray(), this, "", ModuleLog.LogType.DEBUG);
        }
            

    }
}
