using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;


namespace NTHTools.Child
{
    public partial class NTHClipBoardFlyWindow : Form
    {
        private ClipBoardData clipBoardData = new ClipBoardData();
        private object lastActive = null;

        public NTHClipBoardFlyWindow()
        {
            InitializeComponent();
            MakeControlls();
        }
        public void MakeControlls()
        {
            for(int i= 0 ; i < ClipBoardData.id_max; i++)
            {
                LinkLabel label = new LinkLabel();
                label.AutoSize = true;
                label.Location = new System.Drawing.Point(22, i * 25);
                label.Name = "lblLink_" + i;
                label.Size = new System.Drawing.Size(55, 13);
                label.TabStop = true;
                label.Visible = true;
                label.Tag = i;
                label.LinkBehavior = LinkBehavior.HoverUnderline;
                label.Click += new EventHandler(ClipBoardEntery_Click);

                CheckBox chkBox = new CheckBox();
                chkBox.Location = new System.Drawing.Point(5, i * 25);
                chkBox.Size = new System.Drawing.Size(14, 14);
                chkBox.Name = "chkBox_" + i;
                chkBox.TabStop = true;
                chkBox.Tag = i;
                chkBox.CheckedChanged +=new EventHandler(ClipBoardChkBox_CheckedChanged);

                panel1.Controls.Add(label);
                panel1.Controls.Add(chkBox);

            }
        }

        void ClipBoardEntery_Click(object sender, EventArgs e)
        {
            Control control = (Control)sender;
            int id;
            int.TryParse(control.Tag.ToString(), out id);
            clipBoardData[id].MakeActive();
            SelectActive();
            //this.Visible = false;
        }
        void ClipBoardChkBox_CheckedChanged(object sender, EventArgs e)
        {
            CheckBox control = (CheckBox)sender;
            int id;
            int.TryParse(control.Tag.ToString(), out id);
            ClipBoardData.ClipBoardStruct cbStruct = (ClipBoardData.ClipBoardStruct)clipBoardData[id];
            cbStruct.save = control.Checked;
            clipBoardData[id] = cbStruct;
        }
        public void Refresh_Names()
        {
            for (int i = 0; i < ClipBoardData.id_max; i++)
            {
                LinkLabel label = (LinkLabel)panel1.Controls["lblLink_" + i];
                label.Text = clipBoardData[i].ToString();
                toolTip1.SetToolTip(label, clipBoardData[i].GenerateBody());
            }
        }
        public void Work()
        {
            if (clipBoardData.IsUniqe())
            {
                clipBoardData.AddClipBoard();
            }
        }
        public void SelectActive()
        {
            int active = clipBoardData.ActiveID();
            if (lastActive != null)
            {
                Control control = (Control)this.lastActive;
                control.BackColor = Color.White;
            }
            if (active != -1)
            {
                Control control = (Control)panel1.Controls["lblLink_" + active];
                control.BackColor = Color.LightBlue;
                lastActive = control;
            }
        }

        public ClipBoardData Items
        {
            get
            {
                return clipBoardData;
            }
        }
    }
}
