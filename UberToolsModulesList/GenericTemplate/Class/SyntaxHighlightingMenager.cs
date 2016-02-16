using System;
using System.Collections.Generic;
using System.Collections;
using System.Text;
using System.Windows.Forms;
using System.Drawing;
using System.Text.RegularExpressions;

using DamirM.Controls;
using DamirM.CommonLibrary;
using DamirM.CommonControls;

namespace UberTools.Modules.GenericTemplate.Class
{
    class SyntaxHighlightingMenager
    {
        private ControlCollection controls;
        ArrayList tagsList;

        public SyntaxHighlightingMenager(TagsStorage tagsStorage)
        {
            //
            this.controls = new ControlCollection();
            this.controls.ControlAdded += new EventHandler(controls_ControlAdded);

            // 
            TagsShow tagsShow = new TagsShow(tagsStorage);
            tagsShow.ShowOnlyTagsOfObjectType = true;
            // get array list of tags from tagsStorage object
            tagsList = tagsShow.GetTagsList();

            // costum sort
            TagsSortClass tagsSortClass = new TagsSortClass();
            tagsList.Sort(tagsSortClass);
            Log.Write(tagsList, this, "SyntaxHighlightingMenager", Log.LogType.DEBUG);
        }

        void controls_ControlAdded(object sender, EventArgs e)
        {
            SyntaxHighlightingTextBox control = (SyntaxHighlightingTextBox)sender;
            control.DescriptorProccessMode = SyntaxHighlightingTextBox.DescriptorProccessModes.ProcsessLineForDescriptor;
            control.CaseSensitive = false;
            SetSeperators(control);
            SetKeywords(control);
        }

        private void SetSeperators(SyntaxHighlightingTextBox control)
        {
            control.Seperators.Add('\r');
            control.Seperators.Add('\n');
        }

        private void SetKeywords(SyntaxHighlightingTextBox control)
        {
            //control.HighlightDescriptors.Add(new HighlightDescriptor("\\{=string.trim", "", "", Color.Blue, null));
            //control.HighlightDescriptors.Add(new HighlightDescriptor("\\{=string", "", "", Color.Blue, null));
            foreach (string item in tagsList)
            {
                control.HighlightDescriptors.Add(new HighlightDescriptor("\\{=" + Regex.Escape(item), "", "", Color.Blue, null));
            }
            control.HighlightDescriptors.Add(new HighlightDescriptor("\\{=", "", "", Color.Magenta, null));
            control.HighlightDescriptors.Add(new HighlightDescriptor("\\}", @"\{=.*", "", Color.Magenta, null));
            control.HighlightDescriptors.Add(new HighlightDescriptor("\"", "\\.", "", Color.Magenta, null));
            control.HighlightDescriptors.Add(new HighlightDescriptor("\"", "", @"\\cf. \\}|^\.", Color.Magenta, null));
            control.HighlightDescriptors.Add(new HighlightDescriptor("//.*", "", "", Color.Green, null));
        }

        public ControlCollection Controls
        {
            get { return this.controls; }
        }

        public class ControlCollection
        {
            private ArrayList list;

            public event EventHandler ControlAdded;

            public ControlCollection()
            {
                list = new ArrayList();
            }

            public void Add(SyntaxHighlightingTextBox richTextBox)
            {
                list.Add(richTextBox);
                if (ControlAdded != null)
                {
                    ControlAdded(richTextBox, null);
                }
            }



        }

    }

    class TagsSortClass : IComparer
    {
        public int Compare(object obj1, object obj2)
        {
            if (obj1.ToString().Length > obj2.ToString().Length)
            {
                return -1;
            }
            else if (obj1.ToString().Length > obj2.ToString().Length)
            {
                return 1;
            }
            else
            {
                return 0;
            }

        }
    }
}
