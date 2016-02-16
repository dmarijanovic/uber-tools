using System;
using System.Collections.Generic;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using UberTools.Modules.GenericTemplate;
using DamirM.Modules;
using DamirM.CommonLibrary;
using DamirM.CommonControls;

namespace UberTools.Modules.GenericTemplate.Controls
{
    public partial class ToolsWindowsTagsInput : Form
    {
        //  use by upcontrol property
        Control lastAdded_ToolsWindowsTagsParams = null;
        TagsStorage tagsStorage;
        AutoComplete howeringWindow;

        string buildTagString;

        public ToolsWindowsTagsInput(TagsStorage tagsStorage)
        {
            InitializeComponent();
            this.Text = string.Concat(this.Name, " - ", UppercaseFirst(tagsStorage.DisplayText));
            this.tagsStorage = tagsStorage;

            // new tags hoveringWindows instance
            //howeringWindow = new HoveringWindow(this, Common.BuildPath(GenericTemplate.moduleParams.DataPath, GenericTemplate.constModuleDataFolder) + GenericTemplate.constTagsXMLFileName);
            howeringWindow = new AutoComplete(this, tagsStorage);

            // set tag info text
            gbBox.Text = UppercaseFirst(tagsStorage.DisplayText);
            lDescription.Text = tagsStorage.Desctiption;

            // add all propertys 
            AddAllChildPropertys(tagsStorage);

        }

        private void bOK_Click(object sender, EventArgs e)
        {
            ToolsWindowsTagsParams toolsWindowsTagsParams;
            TagsStorage tagsStorageParams;
            string buff1 = "";
            string buff2 = "";

            foreach (Control control in pPropertyBox.Controls)
            {
                if (control is ToolsWindowsTagsParams)
                {
                    toolsWindowsTagsParams = (ToolsWindowsTagsParams)control;
                    // get tagsStorage ovbject from tag
                    tagsStorageParams = (TagsStorage)toolsWindowsTagsParams.Tag;
                    if (tagsStorageParams.Type == TagsStorage.TagsStorageType.String)
                    {
                        buff1 = string.Concat(buff1, ".", "\"", toolsWindowsTagsParams.PropertyText, "\"");
                    }
                    else
                    {
                        buff1 = string.Concat(buff1, ".", toolsWindowsTagsParams.PropertyText);
                        //buff1 += "." + toolsWindowsTagsParams.PropertyText;
                    }
                }
            }

            buff2 = BuildStartTagString(tagsStorage, null);

            this.buildTagString = buff2 + buff1 + "}";
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void AddAllChildPropertys(TagsStorage tagsStorage)
        {
            foreach (TagsStorage tags in tagsStorage)
            {
                //ModuleLog.Write(tags.DisplayText, this, "AddAllPropertys", ModuleLog.LogType.DEBUG);
                AddProperty(tags);
                AddAllChildPropertys(tags);
                break;
            }
        }
        private void AddProperty(TagsStorage tagsStorage)
        {
            ToolsWindowsTagsParams toolsWindowsTagsParams = new ToolsWindowsTagsParams();

            toolsWindowsTagsParams.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            toolsWindowsTagsParams.DownControl = null;
            toolsWindowsTagsParams.Location = new System.Drawing.Point(10, 5);
            toolsWindowsTagsParams.Name = tagsStorage.DisplayText;
            toolsWindowsTagsParams.ParentControl = null;
            toolsWindowsTagsParams.Size = new System.Drawing.Size(553, 30);
            toolsWindowsTagsParams.TabIndex = 1;
            toolsWindowsTagsParams.PropertyName = UppercaseFirst(tagsStorage.Name);
            toolsWindowsTagsParams.PropertyText = "";
            // save reference to tagsStorage object
            toolsWindowsTagsParams.Tag = tagsStorage;
            // add upControl
            if (lastAdded_ToolsWindowsTagsParams != null)
            {
                toolsWindowsTagsParams.UpControl = (ToolsWindowsTagsParams)lastAdded_ToolsWindowsTagsParams;
            }
            this.pPropertyBox.Controls.Add(toolsWindowsTagsParams);
            // bound hoveringWindows to control
            howeringWindow.AddControl(toolsWindowsTagsParams.tbText);

            lastAdded_ToolsWindowsTagsParams = toolsWindowsTagsParams;
        }


        private string BuildStartTagString(TagsStorage tagsStorage, ArrayList list)
        {
            string result = "";
            if (list == null)
            {
                list = new ArrayList();
            }
            // add tag to array
            list.Add(tagsStorage.Value);
            if (tagsStorage.Parent != null)
            {
                result = BuildStartTagString(tagsStorage.Parent, list);
            }
            else
            {
                for (int i = list.Count - 1; i >= 0; i--)
                {
                    if (list.Count - 1 == i || i == 0)
                    {
                        result = string.Concat(result, list[i].ToString());
                    }
                    else
                    {
                        result = string.Concat(result, list[i].ToString(), ".");
                    }
                }
            }

            return result;
        }

        /// <summary>
        /// http://dotnetperls.com/uppercase-first-letter
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        private string UppercaseFirst(string s)
        {
            if (string.IsNullOrEmpty(s))
            {
                return string.Empty;
            }
            char[] a = s.ToCharArray();
            a[0] = char.ToUpper(a[0]);
            return new string(a);
        }

        public string BuildTagString
        {
            get
            {
                return this.buildTagString;
            }
        }

    }
}
