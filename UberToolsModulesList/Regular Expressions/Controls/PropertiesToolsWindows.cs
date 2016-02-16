using System;
using System.Collections.Generic;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

using DamirM.CommonLibrary;

namespace UberTools.Modules.RegularExpressions
{
    public partial class PropertiesToolsWindows : UserControlBase
    {
        PropertiesToolsWindows.PropertyCollection propertys;
        UserControlBase lastAddedControl;

        public delegate void PropertiesToolsWindowsEventHandler(PropertiesToolsWindowsProperty property);
        public event PropertiesToolsWindowsEventHandler Change;

        public PropertiesToolsWindows(string caption)
        {
            InitializeComponent();
            propertys = new PropertyCollection();
            windowsToolsTop.Caption = caption;
        }

        public PropertiesToolsWindowsProperty AddProperty(string name, string caption, string value)
        {
            PropertiesToolsWindowsProperty propertiesToolsWindowsPart;
            propertiesToolsWindowsPart = MakePropertyText(name, caption, value);

            if (propertys.Contains(propertiesToolsWindowsPart))
            {
                Log.Write("Duplicate property name: " + name, this, "AddProperty", Log.LogType.ERROR);
                return null;
            }

            propertys.Add(propertiesToolsWindowsPart);
            return propertiesToolsWindowsPart;
        }
        public PropertiesToolsWindowsProperty AddProperty(string name, string caption, bool value)
        {
            PropertiesToolsWindowsProperty propertiesToolsWindowsPart;
            propertiesToolsWindowsPart = MakePropertyTrueFalse(name, caption, value);

            if (propertys.Contains(propertiesToolsWindowsPart))
            {
                Log.Write("Duplicate property name: " + name, this, "AddProperty", Log.LogType.ERROR);
                return null;
            }

            propertys.Add(propertiesToolsWindowsPart);
            return propertiesToolsWindowsPart;
        }
        public PropertiesToolsWindowsProperty AddProperty(string name, string caption, string[] values, string selected)
        {
            PropertiesToolsWindowsProperty propertiesToolsWindowsPart;
            propertiesToolsWindowsPart = MakePropertyComboBox(name, caption, values, selected);

            if (propertys.Contains(propertiesToolsWindowsPart))
            {
                Log.Write("Duplicate property name: " + name, this, "AddProperty", Log.LogType.ERROR);
                return null;
            }

            propertys.Add(propertiesToolsWindowsPart);
            return propertiesToolsWindowsPart;
        }

        private PropertiesToolsWindowsProperty MakePropertyText(string name, string caption, string value)
        {
            PropertiesToolsWindowsProperty propertiesToolsWindowsPart = new PropertiesToolsWindowsProperty(PropertiesToolsWindowsProperty.Type.Text);

            propertiesToolsWindowsPart.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            propertiesToolsWindowsPart.DownControl = null;
            //propertiesToolsWindowsPart.Location = new System.Drawing.Point(10, 5);
            propertiesToolsWindowsPart.Name = name;
            propertiesToolsWindowsPart.ParentControl = null;
            propertiesToolsWindowsPart.Size = new System.Drawing.Size(pPanel.Width, propertiesToolsWindowsPart.Height);
            propertiesToolsWindowsPart.TabIndex = 1;
            propertiesToolsWindowsPart.PropertyName = name;
            propertiesToolsWindowsPart.PropertyCaption = caption;
            propertiesToolsWindowsPart.PropertyValue = value;
            // subscribe to change event
            propertiesToolsWindowsPart.Change += new PropertiesToolsWindowsEventHandler(property_Change);

            if (lastAddedControl != null)
            {
                propertiesToolsWindowsPart.UpControl = (PropertiesToolsWindowsProperty)lastAddedControl;
            }
            this.pPanel.Controls.Add(propertiesToolsWindowsPart);

            lastAddedControl = propertiesToolsWindowsPart;

            return propertiesToolsWindowsPart;
        }
        private PropertiesToolsWindowsProperty MakePropertyComboBox(string name, string caption, string[] values, string selected)
        {
            PropertiesToolsWindowsProperty propertiesToolsWindowsPart = new PropertiesToolsWindowsProperty(PropertiesToolsWindowsProperty.Type.ComboBox);

            propertiesToolsWindowsPart.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            propertiesToolsWindowsPart.DownControl = null;
            //propertiesToolsWindowsPart.Location = new System.Drawing.Point(10, 5);
            propertiesToolsWindowsPart.Name = name;
            propertiesToolsWindowsPart.ParentControl = null;
            propertiesToolsWindowsPart.Size = new System.Drawing.Size(pPanel.Width, propertiesToolsWindowsPart.Height);
            propertiesToolsWindowsPart.TabIndex = 1;
            propertiesToolsWindowsPart.PropertyName = name;
            propertiesToolsWindowsPart.PropertyCaption = caption;
            // fill combobox with values
            propertiesToolsWindowsPart.PropertyListSet(values);
            // select default text
            propertiesToolsWindowsPart.PropertyValue = selected;
            // subscribe to change event
            propertiesToolsWindowsPart.Change += new PropertiesToolsWindowsEventHandler(property_Change);

            if (lastAddedControl != null)
            {
                propertiesToolsWindowsPart.UpControl = (PropertiesToolsWindowsProperty)lastAddedControl;
            }
            this.pPanel.Controls.Add(propertiesToolsWindowsPart);

            lastAddedControl = propertiesToolsWindowsPart;

            return propertiesToolsWindowsPart;
        }
        private PropertiesToolsWindowsProperty MakePropertyTrueFalse(string name, string caption, bool selected)
        {
            PropertiesToolsWindowsProperty propertiesToolsWindowsPart = new PropertiesToolsWindowsProperty(PropertiesToolsWindowsProperty.Type.TrueFalse);

            propertiesToolsWindowsPart.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            propertiesToolsWindowsPart.DownControl = null;
            //propertiesToolsWindowsPart.Location = new System.Drawing.Point(10, 5);
            propertiesToolsWindowsPart.Name = name;
            propertiesToolsWindowsPart.ParentControl = null;
            propertiesToolsWindowsPart.Size = new System.Drawing.Size(pPanel.Width, propertiesToolsWindowsPart.Height);
            propertiesToolsWindowsPart.TabIndex = 1;
            propertiesToolsWindowsPart.PropertyName = name;
            propertiesToolsWindowsPart.PropertyCaption = caption;
            // select default text
            propertiesToolsWindowsPart.PropertyValueTrueFalse = selected;
            // subscribe to change event
            propertiesToolsWindowsPart.Change += new PropertiesToolsWindowsEventHandler(property_Change);

            if (lastAddedControl != null)
            {
                propertiesToolsWindowsPart.UpControl = (PropertiesToolsWindowsProperty)lastAddedControl;
            }
            this.pPanel.Controls.Add(propertiesToolsWindowsPart);

            lastAddedControl = propertiesToolsWindowsPart;

            return propertiesToolsWindowsPart;
        }

        void property_Change(PropertiesToolsWindowsProperty property)
        {
            if (Change != null)
            {
                Change(property);
            }
        }

        public PropertiesToolsWindows.PropertyCollection Propertys
        {
            get
            {
                return this.propertys;
            }
        }


        // class
        public class PropertyCollection : IEnumerable
        {
            ArrayList propertyList;

            public PropertyCollection()
            {
                propertyList = new ArrayList();
            }

            public void Add(PropertiesToolsWindowsProperty property)
            {
                propertyList.Add(property);
            }

            public void Clear()
            {
                propertyList.Clear();
            }

            public bool Contains(PropertiesToolsWindowsProperty value)
            {
                foreach (PropertiesToolsWindowsProperty property in propertyList)
                {
                    if (property.Equals(value))
                    {
                        return true;
                    }
                }
                return false;
            }


            public IEnumerator GetEnumerator()
            {
                foreach (PropertiesToolsWindowsProperty property in propertyList)
                {
                    yield return property;
                }
            }


            public PropertiesToolsWindowsProperty this[int index]
            {
                get
                {
                    return (PropertiesToolsWindowsProperty)propertyList[index];
                }
            }

            // TODO: Dali ova metoda treba,, kad vraca isti objekt ?????????
            public PropertiesToolsWindowsProperty this[string name]
            {
                get
                {
                    foreach (PropertiesToolsWindowsProperty propertyItem in propertyList)
                    {
                        if (propertyItem.ProductName == name)
                        {
                            return propertyItem;
                        }
                    }

                    Log.Write("No property name: " + name, this, "this", Log.LogType.WARNING);
                    return null;
                }
            }

        }

    }

}
