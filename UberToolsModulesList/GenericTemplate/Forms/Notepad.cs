using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace UberTools.Modules.GenericTemplate.Forms
{
    public partial class Notepad : Form
    {
        public Notepad(string text)
        {
            InitializeComponent();
            this.tbText.Text = text;
        }
        public void Append(string text)
        {
            tbText.AppendText(text);
        }
    }
}
