using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using DamirM.Controls;
using DamirM.CommonLibrary;

namespace DamirM.Modules
{
    public partial class ModuleMainFormBase : Form, iModuleMainFormBase
    {
        public ModuleMainFormBase()
        {
            InitializeComponent();
        }
        public virtual UserControlBase[] ToolsWindows()
        {
            return null;
        }

    }
}
