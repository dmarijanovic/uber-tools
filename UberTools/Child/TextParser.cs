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
    public partial class TextParser : ChildBase
    {
        public TextParser()
        {
            InitializeComponent();
        }

        private void btnOpen_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = openFileDialog1.ShowDialog(this);
            if (dialogResult == DialogResult.OK)
            {
                txbFilePath.Text = openFileDialog1.FileName;
            }
        }
    }
}
