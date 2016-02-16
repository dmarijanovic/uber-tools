using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

using UberTools.Modules.GenericTemplate.Forms;
using DamirM.Modules;
using DamirM.Class;
using DamirM.Controls;
using DamirM.CommonLibrary;
using UberTools.Modules.GenericTemplate.Class;
using UberTools.Modules.GenericTemplate;
using DamirM.CommonControls;

namespace UberTools.Modules.GenericTemplate.Controls
{
    public partial class ToolsWindowsTags : UserControlBase
    {
        TagsStorage tagsStorage;
        // control where to put text from toolswindwosInput form
        TextBoxBase lastActiveControl;

        public ToolsWindowsTags(TagsStorage tagsStorage)
        {
            InitializeComponent();
            this.tagsStorage = tagsStorage;
            TagsShow tagsShow = new TagsShow(tagsStorage);
            tagsShow.ShowOnlyTagsOfObjectType = true;
            tagsShow.Show(tvTags);
        }

        private void tvTags_NodeMouseDoubleClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            DialogResult dialogResult;
            ToolsWindowsTagsInput toolsWindowsTagsInput = new ToolsWindowsTagsInput((TagsStorage)e.Node.Tag);
            dialogResult = toolsWindowsTagsInput.ShowDialog(Application.OpenForms[0]);
            if (dialogResult == DialogResult.OK)
            {
                if (lastActiveControl != null)
                {
                    lastActiveControl.SelectedText = toolsWindowsTagsInput.BuildTagString;
                    //lastActiveControl.Text = toolsWindowsTagsInput.BuildTagString;
                }
                else
                {

                    dialogResult = MessageBox.Show("No active control selected, copy tag in clipbord", "Error - No active control selected", MessageBoxButtons.YesNo,MessageBoxIcon.Error);
                    if (dialogResult == DialogResult.Yes)
                    {
                        Clipboard.SetText(toolsWindowsTagsInput.BuildTagString);
                    }
                    
                }
            }
        }

        public void AddControl(Control control)
        {
            control.Enter += new EventHandler(control_Enter);
        }

        void control_Enter(object sender, EventArgs e)
        {
            lastActiveControl = (TextBoxBase)sender;
        }
    }
}
