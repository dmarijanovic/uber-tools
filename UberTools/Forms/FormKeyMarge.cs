using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace UberTools.Modules.QuickTags
{
    public partial class FormKeyMarge : Form
    {
        private KeyEventArgs keyEventArgs = null;
        public FormKeyMarge()
        {
            InitializeComponent();
        }
        public FormKeyMarge(KeyEventArgs keyEventArgs): this()
        {
            this.keyEventArgs = keyEventArgs;
            txtKeyEnter_KeyDown(null, keyEventArgs);
        }

        private void txtKeyEnter_KeyDown(object sender, KeyEventArgs e)
        {
            string text = "";
            if (e.Alt == true)
            {
                text += "ALT + ";
            }
            if (e.Control == true)
            {
                text += "Control + ";
            }
            if (e.Shift == true)
            {
                text += "Shift + ";
            }
            text += e.KeyCode;
            txtKeyEnter.Text = text;
            e.SuppressKeyPress = true;
            this.keyEventArgs = e;
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }
        public KeyEventArgs KeyEventArgs
        {
            get { return keyEventArgs; }
        }
        public static bool CompareKeyEventAtgs(KeyEventArgs arg1, KeyEventArgs arg2)
        {
            if (arg1.Alt == arg2.Alt)
            {
                if (arg1.Control == arg2.Control)
                {
                    if (arg1.Shift == arg2.Shift)
                    {
                        if (arg1.KeyValue == arg2.KeyValue)
                        {
                            return true;
                        }
                    }
                }
            }
            return false;
        }
    }
}
