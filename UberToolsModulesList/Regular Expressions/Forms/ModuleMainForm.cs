using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;

using DamirM.Controls;
using DamirM.CommonLibrary;
using DamirM.Modules;

namespace UberTools.Modules.RegularExpressions.Forms
{
    public partial class ModuleMainForm : ModuleMainFormBase
    {
        RegExParser regExParser;
        PropertiesToolsWindows regExPropertys;

        public ModuleMainForm()
        {
            InitializeComponent();
            try
            {
                // set property windows 
                regExPropertys = new PropertiesToolsWindows("Options");
                regExPropertys.AddProperty(RegexOptions.IgnoreCase.ToString(), "Ignore case", false);
                regExPropertys.AddProperty(RegexOptions.Multiline.ToString(), "Multiline mode", false);
                regExPropertys.AddProperty(RegexOptions.Singleline.ToString(), "Dot match all", false);
                regExPropertys.Change += new PropertiesToolsWindows.PropertiesToolsWindowsEventHandler(regExOptions_Change);

                // create instance of regex parser
                RegexOptions regexOptions = System.Text.RegularExpressions.RegexOptions.None;
                regExParser = new RegExParser(regexOptions);

            }
            catch (Exception ex)
            {
                Log.Write(ex, this, "ModuleMainForm", Log.LogType.ERROR);
            }
        }

        #region Methods
        public override UserControlBase[] ToolsWindows()
        {
            UserControlBase[] toolsWindows = new UserControlBase[1];
            toolsWindows[0] = regExPropertys;

            return toolsWindows;
        } 
        #endregion

        #region Events
        void regExOptions_Change(PropertiesToolsWindowsProperty property)
        {
            RegexOptions regexOptions = new System.Text.RegularExpressions.RegexOptions();
            // event retuens property with new value but we loop on all propertys to build regexOptions
            foreach (PropertiesToolsWindowsProperty propertyItem in regExPropertys.Propertys)
            {
                if (propertyItem.PropertyName == RegexOptions.IgnoreCase.ToString())
                {
                    if (propertyItem.PropertyValueTrueFalse == true)
                    {
                        regexOptions = regexOptions | RegexOptions.IgnoreCase;
                    }
                }
                else if (propertyItem.PropertyName == RegexOptions.Multiline.ToString())
                {
                    if (propertyItem.PropertyValueTrueFalse == true)
                    {
                        regexOptions = regexOptions | RegexOptions.Multiline;
                    }
                }
                else if (propertyItem.PropertyName == RegexOptions.Singleline.ToString())
                {
                    if (propertyItem.PropertyValueTrueFalse == true)
                    {
                        regexOptions = regexOptions | RegexOptions.Singleline;
                    }
                }
            }

            regExParser.RegexOptions = regexOptions;

            // refresh
            textChange_KeyUp(null, null);
        }

        private void textChange_KeyUp(object sender, KeyEventArgs e)
        {
            regExParser.RegExExpresion = tbRegEx.Text;
            regExParser.Text = tbText.Text;

            tbResult.Text = regExParser.GetMatches();
        } 
        #endregion
    }
}
