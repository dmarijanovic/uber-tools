using System;
using System.Collections.Generic;
using System.Collections;
using System.Text;
using System.IO;

using DamirM.Dll.CommonLibrary.Forms;

namespace UberTools.Plugin.UpdateManager.Class
{
    class Project
    {
        ProjectFolder RootFolder;
        //private string path;

        public Project(string path)
        {
            this.RootFolder = new ProjectFolder("Root", path);
        }

        public void ScanProject()
        {
            try
            {
                Log.Write("Starting scaning local project", this, "ScanProject", Log.LogType.DEBUG);
                BrowserFolder(RootFolder);
            }
            catch(Exception ex)
            {
                Log.Write(ex, this, "ScanProject", Log.LogType.ERROR);
            }
        }

        private void BrowserFolder(ProjectFolder projectFolder)
        {
            ProjectFolder subFolder;
            ProjectFile projectFile;
            DirectoryInfo dir = new DirectoryInfo(projectFolder.Path);

            /// Add all files to curent folder
            foreach (FileInfo fileInfo in dir.GetFiles())
            {
                projectFile = new ProjectFile(fileInfo.Name,fileInfo.FullName);
                projectFolder.AddFile(projectFile);
                //Log.Write(fileInfo.FullName, this, "BrowserFolder", Log.LogType.DEBUG);
            }


            /// Add all subfolders to curent folder and ...
            foreach (DirectoryInfo di in dir.GetDirectories())
            {
                subFolder = new ProjectFolder(di.Name, di.FullName);
                projectFolder.AddFolder(subFolder);
                BrowserFolder(subFolder);
            }
        }

        public ProjectFolder GetProductFolderFromLinkReference(object linkReference)
        {
            ProjectFolder pf = null;
            try
            {
                pf = BrowserProductFolder(this.GetRootFolder, linkReference);
            }
            catch (Exception ex)
            {
                Log.Write(ex, this, "GetProductFolderFromLinkReference", Log.LogType.ERROR);
            }
            return pf;
        }

        private ProjectFolder BrowserProductFolder(ProjectFolder projectFolder, object linkReference)
        {
            ProjectFolder resultProductFolder = null;

            if (object.ReferenceEquals(projectFolder.LinkReference, linkReference))
            {
                return projectFolder;
            }

            foreach (ProjectFolder pf in (IEnumerable<ProjectFolder>)projectFolder)
            {
                resultProductFolder = BrowserProductFolder(pf, linkReference);
                if (resultProductFolder != null)
                {
                    // Object found, exit 
                    break;
                }
            }
            return resultProductFolder;
        }

        public ProjectFolder GetRootFolder
        {
            get
            {
                return RootFolder;
            }
        }

    }
}
