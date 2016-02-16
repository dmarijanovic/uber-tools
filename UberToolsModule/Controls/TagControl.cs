using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

using DamirM.Class;
using DamirM.CommonLibrary;

namespace DamirM.Controls
{
    public partial class TagControl : UserControlBase
    {
        Tag tag;
        public TagControl(Tag tag)
        {
            InitializeComponent();
            this.tag = tag;
        }
        public void SetTag(Tag tag)
        {
            lName.Text = tag.Name;
            tbValue.Text = tag.Value;
        }
        public static TagControl GetControlInstance(Panel panel, Tag tag, UserControlBase upControl, UserControlBase downControl)
        {
            //UserControlBase control;
            TagControl control;
            control = new TagControl(tag);

            control.Location = new System.Drawing.Point(10, 20);
            //rowCollection.Name = "Data" + columnCount;
            control.Size = new System.Drawing.Size(800, 30);
            control.TabIndex = 0;

            control.UpControl = upControl;
            control.DownControl = downControl;
            panel.Controls.Add(control);
            return control;
        }
    }
}
