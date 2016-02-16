using System;
using System.Collections.Generic;
using System.Text;

using DamirM.CommonLibrary;

namespace NTHTools
{
    public class ChildBase: System.Windows.Forms.Form
    {
        public delegate void delStatus(object text);
        public event delStatus Status;

        private void Working(string text)
        {
            Main frm = (Main)this.MdiParent;
           
        }
        public void SetStatus(object message)
        {
            this.Enabled = false;
            Status(message);
        }
        public void SetStatus()
        {
            Status(null);
            this.Enabled = true;
        }
    }
}
