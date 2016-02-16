using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using DamirM.CommonLibrary;

namespace UberTools.Modules.RegularExpressions
{
    public partial class PropertiesToolsWindowsProperty : UserControlBase
    {
        private Type type;
        string propertyName;
        string propertyCaption;

        public event PropertiesToolsWindows.PropertiesToolsWindowsEventHandler Change;

        public enum Type
        {
            Text, ComboBox, TrueFalse
        }

        public PropertiesToolsWindowsProperty(Type type): base(0)
        {

            InitializeComponent();
            this.type = type;
            propertyCaption = "";
            if (type == Type.ComboBox)
            {
                cbValue.Visible = false;
                tbText.Visible = true;
            }
            else if (type == Type.TrueFalse)
            {
                cbValue.Visible = false;
                tbText.Visible = true;

                cbValue.Items.Add("True");
                cbValue.Items.Add("False");
            }
            else
            {
                cbValue.Visible = false;
                tbText.Visible = true;
            }

        }

        #region Methods
        public void PropertyListSet(string[] list)
        {
            foreach (string item in list)
            {
                cbValue.Items.Add(item);
            }
        }
        private void DrawName(string value)
        {
            Graphics graphics = this.CreateGraphics();
            Brush brush = new SolidBrush(Color.Black);
            Font font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));

            graphics.DrawString(value, font, brush, 5, 0);
        }
        #endregion

        #region Events
        private void PropertiesToolsWindowsPart_Enter(object sender, EventArgs e)
        {
            this.BackColor = System.Drawing.SystemColors.ControlLight;
            if (type == Type.ComboBox || type == Type.TrueFalse)
            {
                cbValue.Visible = true;
                tbText.Visible = false;
            }
            else if (type == Type.Text)
            {

            }
        }
        private void PropertiesToolsWindowsPart_Leave(object sender, EventArgs e)
        {
            this.BackColor = System.Drawing.SystemColors.ControlLightLight;
            if (type == Type.ComboBox || type == Type.TrueFalse)
            {
                tbText.Text = cbValue.Items[cbValue.SelectedIndex].ToString();

                cbValue.Visible = false;
                tbText.Visible = true;
            }
            else if (type == Type.Text)
            {

            }
        }
        private void PropertiesToolsWindowsPart_Paint(object sender, PaintEventArgs e)
        {
            DrawName(this.propertyCaption);
        }
        private void tbText_TextChanged(object sender, EventArgs e)
        {
            if (this.type == Type.Text)
            {
                if (Change != null)
                {
                    Change(this);
                }
            }
        }
        private void cbValue_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (Change != null)
            {
                Change(this);
            }
        }
        #endregion

        #region Propertys
        public string PropertyName
        {
            get
            {
                return this.propertyName;
            }
            set
            {
                this.propertyName = value;
            }
        }
        public string PropertyCaption
        {
            get
            {
                return this.propertyCaption;
            }
            set
            {
                propertyCaption = value;
                DrawName(value);

                //this.lName.Text = value;
            }
        }
        /// <summary>
        /// Value text of this property
        /// </summary>
        public string PropertyValue
        {
            get
            {
                if (this.type == Type.ComboBox)
                {
                    return this.cbValue.Items[cbValue.SelectedIndex].ToString();
                }
                else
                {
                    return this.tbText.Text;
                }
            }
            set
            {
                if (this.type == Type.ComboBox)
                {
                    for (int i = 0; i < cbValue.Items.Count; i++)
                    {
                        if (cbValue.Items[i].ToString().Equals(value))
                        {
                            cbValue.SelectedIndex = i;
                            this.tbText.Text = value;
                            break;
                        }
                    }
                }
                else
                {
                    this.tbText.Text = value;
                }
            }
        }

        public bool PropertyValueTrueFalse
        {
            get
            {
                if (this.type == Type.TrueFalse)
                {
                    if (this.cbValue.Items[cbValue.SelectedIndex].ToString() == "True")
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
                else
                {
                    return false;
                }
            }
            set
            {
                if (this.type == Type.TrueFalse)
                {
                    if (value == true)
                    {
                        cbValue.SelectedIndex = 0;
                        this.tbText.Text = "True";
                    }
                    else
                    {
                        cbValue.SelectedIndex = 1;
                        this.tbText.Text = "False";
                    }
                }
                else
                {
                    cbValue.SelectedIndex = 1;
                    this.tbText.Text = "False";
                }
            }
        }

        #endregion

     }
}
