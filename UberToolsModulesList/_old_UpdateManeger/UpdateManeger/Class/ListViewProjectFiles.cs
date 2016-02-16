using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

using DamirM.Dll.CommonLibrary.Forms;

namespace UberTools.Plugin.UpdateManager.Class
{
    class ListViewProjectFiles
    {
        ListView listView;
        ProjectFolder projectFolder;

        public ListViewProjectFiles(ListView listView, ProjectFolder projectFolder)
        {
            this.listView = listView;
            this.projectFolder = projectFolder;
        }

        public void Fill()
        {
            ListViewItem item;
            try
            {
                Log.Write("Start file fill...", this, "Fill", Log.LogType.DEBUG);
                foreach (ProjectFile projectFile in (IEnumerable<ProjectFile>)projectFolder)
                {
                    //Log.Write("Adding file " + projectFile.Name, this, "Fill", Log.LogType.DEBUG);
                    item = new ListViewItem(projectFile.Name);
                    item.SubItems.Add(projectFile.Path);
                    if (projectFile.Publish)
                    {
                        item.Group = listView.Groups["lvgPublish"];
                    }
                    else
                    {
                        item.Group = listView.Groups["lvgDoNotPublish"];
                    }
                    this.listView.Items.Add(item);
                }
            }
            catch (Exception ex)
            {
                Log.Write(ex, this, "Fill", Log.LogType.ERROR);
            }
        }

    }
}
