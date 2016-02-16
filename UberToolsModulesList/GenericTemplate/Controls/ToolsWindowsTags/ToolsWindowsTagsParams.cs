using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

using DamirM.CommonLibrary;

namespace UberTools.Modules.GenericTemplate.Controls
{
    public partial class ToolsWindowsTagsParams : UserControlBase
    {
        public ToolsWindowsTagsParams()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Name of this property
        /// </summary>
        public string PropertyName
        {
            get
            {
                return this.lName.Text;
            }
            set
            {
                this.lName.Text = value;
            }
        }

        /// <summary>
        /// Value text of this property
        /// </summary>
        public string PropertyText
        {
            get
            {
                return this.tbText.Text;
            }
            set
            {
                this.tbText.Text = value;
            }
        }
    }
}
