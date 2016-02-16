using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

using DamirM.Controls;
using DamirM.CommonLibrary;
using DamirM.Modules;

namespace UberTools.Class
{
    class ToolsWindowsMenager
    {
        private Panel pPanelOne;

        public ToolsWindowsMenager()
        {

        }
        public void AddPanel(Panel panel)
        {
            this.pPanelOne = panel;
            this.pPanelOne.ControlAdded += new ControlEventHandler(panel_ControlAdded);
            this.pPanelOne.Resize += new EventHandler(panel_Resize);
        }

        public void AddControls(UserControlBase userControlBase)
        {
            pPanelOne.Controls.Add(userControlBase);
        }
        public void AddControls(UserControlBase[] userControlsBase)
        {
            if (userControlsBase != null)
            {
                foreach (UserControlBase userControlBase in userControlsBase)
                {
                    pPanelOne.Controls.Add(userControlBase);
                }
            }
        }

        public void Clear()
        {
            pPanelOne.Controls.Clear();
        }

        private void panel_ControlAdded(object sender, ControlEventArgs e)
        {
            UserControlBase upControl;
            Panel panel = (Panel)sender;
            UserControlBase addedControl;
            if (e.Control is UserControlBase)
            {
                addedControl = (UserControlBase)e.Control;
                //e.Control.Dock = DockStyle.Fill;
                addedControl.Width = panel.Width;
                SetHeightToAllControls(panel);
                if (panel.Controls.Count > 1)
                {
                    // get upcontrol from last control in collection
                    upControl = (UserControlBase)panel.Controls[panel.Controls.GetChildIndex(e.Control) - 1];
                    Log.Write(upControl.ToString(), this, "panel_ControlAdded", Log.LogType.DEBUG);
                    // set upcontrol to added control
                    addedControl.UpControl = upControl;
                }
            }
        }

        void panel_Resize(object sender, EventArgs e)
        {
            Panel panel = (Panel)sender;
            //SetHeightToAllControls(panel);
            SetWidthToAllControls(panel);
        }

        private void SetHeightToAllControls(Control parent)
        {
            int height = parent.Height / parent.Controls.Count;
            foreach (Control child in parent.Controls)
            {
                if (child is UserControlBase)
                {
                    child.Height = height;
                }
            }
        }

        private void SetWidthToAllControls(Control parent)
        {
            int width = parent.Width;
            foreach (Control child in parent.Controls)
            {
                if (child is UserControlBase)
                {
                    child.Width = width;
                }
            }
        }


        public void LostFocus(object sender, EventArgs e)
        {
            Log.Write("lostfocus", sender, "", Log.LogType.DEBUG);
            this.Clear();
        }

        public void Activate(object sender, EventArgs e)
        {
            ModuleMainFormBase moduleMainFormBase = (ModuleMainFormBase)sender;

            Log.Write("Activate", sender, "", Log.LogType.DEBUG);

            AddControls(moduleMainFormBase.ToolsWindows());
        }
    }
}
