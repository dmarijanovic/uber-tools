using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.IO;

using  DamirM.Modules;
using DamirM.Controls;
using DamirM.Class;
using DamirM.CommonLibrary;

namespace UberTools.Modules.GenericTemplate.Class
{
    public class TemplatesManager
    {
        TreeView treeView;
        string templateFolder;
        SettingsMenager settingsManager;
        SettingsMenager2 settingsManager2;
        string activeTemplatePath = "";


        public enum FolderType { Desktop, Folder, File };

        public TemplatesManager(TreeView treeView, string templateFolder, SettingsMenager settingsMenager, SettingsMenager2 settingsMenager2)
        {
            this.treeView = treeView;
            this.templateFolder = templateFolder;
            this.settingsManager = settingsMenager;

            this.settingsManager2 = settingsMenager2;
            try
            {
                // make template folder
                Common.MakeAllSubFolders(templateFolder);
            }
            catch (Exception ex)
            {
                ModuleLog.Write(ex, this, "TemplatesManager", ModuleLog.LogType.ERROR);
            }
        }

        public void LoadAll()
        {
            DirectoryInfo directory;
            TreeNode rootNode;
            FileInfo[] fileList;
            string fileName;

            try
            {
                //ModuleLog.Write(new string[]{"Refreshing list of templates", "Source: " + templateFolder}, this, "LoadAll", ModuleLog.LogType.DEBUG);
                // clear all old nodes
                treeView.Nodes.Clear();
                // create new root node
                rootNode = new TreeNode("Desktop");  //, 2, 2);
                rootNode.ImageKey = "desktop";
                rootNode.SelectedImageKey = "desktop";
                rootNode.Name = "desktop";
                treeView.Nodes.Add(rootNode);

                directory = new DirectoryInfo(templateFolder);
                foreach (DirectoryInfo directoriInfo in directory.GetDirectories())
                {
                    rootNode = new TreeNode(directoriInfo.Name, 0, 0);
                    rootNode.Name = "folder";
                    ProccessTemplateFolder(directoriInfo.FullName, rootNode);
                    treeView.Nodes.Add(rootNode);
                }
                fileList = directory.GetFiles("*.xml");
                foreach (FileInfo file in fileList)
                {
                    fileName = file.Name.Replace(".xml", "");
                    rootNode = new TreeNode(fileName, 1, 1);
                    rootNode.Name = "file";
                    treeView.Nodes.Add(rootNode);
                }
            }
            catch (Exception ex)
            {
                ModuleLog.Write(ex, this, "LoadAll", ModuleLog.LogType.ERROR);
            }

        }

        private void ProccessTemplateFolder(string path, TreeNode rootNode)
        {
            TreeNode treeNode;
            DirectoryInfo directory;
            FileInfo[] fileList;
            string fileName;

            try
            {
                directory = new DirectoryInfo(path);
                foreach (DirectoryInfo directoriInfo in directory.GetDirectories())
                {
                    treeNode = new TreeNode(directoriInfo.Name, 0, 0);
                    treeNode.Name = "folder";
                    rootNode.Nodes.Add(treeNode);
                    ProccessTemplateFolder(directoriInfo.FullName, treeNode);
                }

                fileList = directory.GetFiles("*.xml");
                foreach (FileInfo file in fileList)
                {
                    fileName = file.Name.Replace(".xml", "");
                    treeNode = new TreeNode(fileName, 1, 1);
                    treeNode.Name = "file";
                    rootNode.Nodes.Add(treeNode);
                }
            }
            catch (Exception ex)
            {
                ModuleLog.Write(ex, this, "ProccessTemplateFolder", ModuleLog.LogType.ERROR);
            }
        }


        public void Save()
        {
            //TreeNode node;
            InputBox inputBox;
            string path = "";
            string fileName = "";
            //string activeTemplatePath;
            string activeTemplateName;

            try
            {
                // ako korisnik nije kliknio na load template ovaj ovjkt ce bii null
                if (activeTemplatePath != "")
                {
                    activeTemplateName = Common.ExtractFileFromPath(activeTemplatePath).Replace(".xml", "");
                }
                else
                {
                    activeTemplateName = "TemplateName";
                }

                inputBox = new InputBox("Template name", "Enter template name", activeTemplateName);


                inputBox.ShowDialog(Application.OpenForms[0]);
                if (inputBox.DialogResult == DialogResult.OK)
                {
                    fileName = inputBox.InputTekst;

                    // is save 
                    if (activeTemplateName == fileName)
                    {
                        path = activeTemplatePath;
                    }
                    else
                    {
                        path = GetNodeRealFolder(treeView.SelectedNode);
                        Common.MakeAllSubFolders(path);
                        path = Common.BuildPath(path) + fileName + ".xml";
                    }


                    ModuleLog.Write(new string[] { "Saving template", "Destination: " + path }, this, "Save", ModuleLog.LogType.DEBUG);

                    //settingsManager.FilePath = path;
                    //settingsManager.GroupOf = fileName;
                    //settingsManager.SaveSettings();

                    //
                    // New settings menager
                    //
                    settingsManager2.SaveToFile(path);

                    this.LoadAll();
                    // save active path
                    activeTemplatePath = path;
                }
            }
            catch (Exception ex)
            {
                ModuleLog.Write(ex, this, "Save", ModuleLog.LogType.ERROR);
            }
        }
        public void Load()
        {
            TreeNode node;
            string path = "";
            string templateName;
            try
            {
                node = treeView.SelectedNode;
                if (node.Name.Equals("file"))
                {
                    templateName = node.Text;

                    DialogResult dialogResult = MessageBox.Show("Load template: " + templateName, "Load template", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                    if (dialogResult == DialogResult.OK)
                    {
                        if (node.Parent != null)
                        {
                            path = Common.BuildPath(templateFolder, node.Parent.FullPath);
                        }
                        else
                        {
                            path = Common.BuildPath(templateFolder);
                        }
                        path = path + templateName + ".xml";

                        ModuleLog.Write(new string[] { "Loading template", "Name:" + templateName, "Path: " + path }, this, "Load", ModuleLog.LogType.INFO);

                        // try load with old settgins menager
                        bool result;
                        settingsManager.FilePath = path;
                        settingsManager.GroupOf = node.Name;
                        result = settingsManager.LoadSettings();

                        if (result == false)
                        {
                            // settings menager 2
                            ModuleLog.Write("Old settings menager fail to load template, will try to load with new settings menager", this, "Load", ModuleLog.LogType.INFO);

                            settingsManager2.LoadFromFile(path);
                        }
                    }
                    activeTemplatePath = path;
                    // save general active template
                    Settings.Setting.Items.Add(new SettingsMenagerStructure2(Settings.SettingName.ActiveTemplateName.ToString(), Settings.SettingName.ActiveTemplateName.ToString(), path, "", SettingsMenager2.Type.Text));
                }
            }
            catch (Exception ex)
            {
                ModuleLog.Write(ex, this, "Load", ModuleLog.LogType.ERROR);
            }
        }
        public void Load(string path)
        {
            try
            {
                ModuleLog.Write(new string[] { "Loading template", "Name:" , "Path: " + path }, this, "Load", ModuleLog.LogType.INFO);

                // try load with old settings menager
                bool result;
                settingsManager.FilePath = path;
                result = settingsManager.LoadSettings();

                if (result == false)
                {
                    // settings menager 2
                    ModuleLog.Write("Old settings menager fail to load template, will try to load with new settings menager", this, "Load", ModuleLog.LogType.INFO);

                    settingsManager2.LoadFromFile(path);
                }
            }
            catch (Exception ex)
            {
                ModuleLog.Write(ex, this, "Load", ModuleLog.LogType.ERROR);
            }
        }



        public void NewFolder(string folderName)
        {
            string folderPath;

            try
            {
                folderPath = GetNodeRealFolder(treeView.SelectedNode);

                // make new folder
                folderPath = Common.BuildPath(folderPath, folderName);

                ModuleLog.Write("Make directory: " + folderPath, this, "Delete", ModuleLog.LogType.DEBUG);
                Directory.CreateDirectory(folderPath);
            }
            catch (Exception ex)
            {
                ModuleLog.Write(ex, this, "Delete", ModuleLog.LogType.ERROR);
            }
        }

        public void Delete()
        {
            string folderPath;
            string filePath;

            try
            {
                folderPath = GetNodeRealFolder(treeView.SelectedNode);
                filePath = GetNodeRealPath(treeView.SelectedNode);

                if (ActiveNodeType == FolderType.Folder)
                {
                    // folder/categori is selected
                    ModuleLog.Write("Deleting: " + folderPath, this, "Delete", ModuleLog.LogType.DEBUG);
                    Directory.Delete(folderPath, true);
                }
                else if (ActiveNodeType == FolderType.File)
                {
                    // file/template is selected
                    ModuleLog.Write("Deleting: " + filePath, this, "Delete", ModuleLog.LogType.DEBUG);
                    File.Delete(filePath);
                }

            }
            catch (Exception ex)
            {
                ModuleLog.Write(ex, this, "Delete", ModuleLog.LogType.ERROR);
            }
            
        }

        public bool Copy(TreeNode source, TreeNode destination)
        {
            string sourcePath;
            string destinationPath;
            string fileName;
            bool result = false;

            try
            {
                sourcePath = GetNodeRealPath(source);
                fileName = Common.ExtractFileFromPath(sourcePath);
                destinationPath = Common.BuildPath(GetNodeRealFolder(destination)) + fileName;

                ModuleLog.Write(new string[]{"Source: " +sourcePath,"Destination: "  + destinationPath}, this, "Copy", ModuleLog.LogType.DEBUG);
                File.Copy(sourcePath, destinationPath);
                File.Delete(sourcePath);
                result = true;
            }
            catch (Exception ex)
            {
                ModuleLog.Write(ex, this, "Copy", ModuleLog.LogType.ERROR);
            }

            return result;
        }

        private string GetNodeRealPath(TreeNode node)
        {
            string path = "";
            if (node != null)
            {
                if (node.Name == "desktop")
                {
                    path = Common.BuildPath(templateFolder);
                }
                else if (node.Name == "folder")
                {
                    path = Common.BuildPath(templateFolder, node.FullPath);
                }
                else if (node.Name ==  "file")
                {
                    if (node.Parent != null)
                    {
                        path = Common.BuildPath(templateFolder, node.Parent.FullPath);
                    }
                    else
                    {
                        path = Common.BuildPath(templateFolder);
                    }
                    path = path + node.Text + ".xml";
                }
                else
                {
                    throw new Exception("Template tape " + node.Name + " is unknown");
                }
            }
            else
            {
                path = Common.BuildPath(templateFolder);
            }
            return path;
        }
        private string GetNodeRealFolder(TreeNode node)
        {
            string path = "";
            if (node != null)
            {
                if (node.Name == "desktop")
                {
                    path = Common.BuildPath(templateFolder);
                }
                else if (node.Name == "folder")
                {
                    path = Common.BuildPath(templateFolder, node.FullPath);
                }
                else if (node.Name == "file")
                {
                    if (node.Parent != null)
                    {
                        path = Common.BuildPath(templateFolder, node.Parent.FullPath);
                    }
                    else
                    {
                        path = Common.BuildPath(templateFolder);
                    }
                }
                else
                {
                    throw new Exception("Template tape " + node.Name + " is unknown");
                }
            }
            else
            {
                path = Common.BuildPath(templateFolder);
            }
            return path;
        }
        public FolderType ActiveNodeType
        {
            get
            {
                TreeNode node;
                FolderType result;

                node = treeView.SelectedNode;
                if (node != null)
                {
                    if (node.Name == "desktop")
                    {
                        result = TemplatesManager.FolderType.Desktop;
                    }
                    else if (node.Name == "folder")
                    {
                        result = TemplatesManager.FolderType.Folder;
                    }
                    else if (node.Name == "file")
                    {
                        result = TemplatesManager.FolderType.File;
                    }
                    else
                    {
                        throw new Exception("Template tape " + node.Name + " is unknown");
                    }
                }
                else
                {
                    result = TemplatesManager.FolderType.Folder;
                }

                return result;
            }
        }

        public string TemplateFolder
        {
            get
            {
                return this.templateFolder;
            }
        }

    }
}
