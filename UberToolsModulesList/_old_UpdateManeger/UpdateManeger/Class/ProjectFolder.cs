using System;
using System.Collections.Generic;
using System.Collections;
using System.Text;

namespace UberTools.Plugin.UpdateManager.Class
{
    public class ProjectFolder : IEnumerable<ProjectFolder>, IEnumerable<ProjectFile>
    {
        ArrayList folderList;
        ArrayList fileList;
        string name;
        string path;
        object linkReference;

        public ProjectFolder(string name, string path)
        {
            this.name = name;
            this.path = path;
        }
        public void AddFolder(ProjectFolder projectFolder)
        {
            if (folderList == null)
            {
                folderList = new ArrayList();
            }

            folderList.Add(projectFolder);
        }
        public void AddFile(ProjectFile projectFile)
        {
            if (fileList == null)
            {
                fileList = new ArrayList();
            }

            fileList.Add(projectFile);
        }

        public string Path
        {
            get
            {
                return this.path;
            }
        }
        public string Name
        {
            get
            {
                return this.name;
            }
        }
        public object LinkReference
        {
            get
            {
                return this.linkReference;
            }
            set
            {
                this.linkReference = value;
            }
        }

        IEnumerator<ProjectFolder> IEnumerable<ProjectFolder>.GetEnumerator()
        {
            if (folderList != null)
            {
                foreach (ProjectFolder projectFolder in folderList)
                {
                    yield return projectFolder;
                }
            }
        }
        IEnumerator<ProjectFile> IEnumerable<ProjectFile>.GetEnumerator()
        {
            if (fileList != null)
            {
                foreach (ProjectFile projectFile in fileList)
                {
                    yield return projectFile;
                }
            }
        }
        IEnumerator IEnumerable.GetEnumerator()
        {
            // dummy method
            return null;
        }
    }
}
