using System;
using System.Collections.Generic;
using System.Collections;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Text.RegularExpressions;

using DamirM.Controls;
using UberTools.Modules.GenericTemplate.Controls;
using UberTools.Modules.GenericTemplate.Class;
using UberTools.Modules.GenericTemplate.RowCollectionNS;
using DamirM.Modules;
using DamirM.Class;
using DamirM.CommonLibrary;
using DamirM.CommonControls;

using UberTools.Modules.GenericTemplate.InputData;

namespace UberTools.Modules.GenericTemplate.Forms
{
    //public partial class ModuleMainForm : ModuleMainFormBase
    public partial class ModuleMainForm : ModuleMainFormBase
    {
        // WindowsTools controls
        ToolsWindowsTemplates twtToolsWindowsTemplates;
        ToolsWindowsTags twttoolsWindowsTags;

        //AutoComplete_OLD autoComplete;
        AutoComplete autoComplete;
        TemplatesManager templatesMenager;
        SettingsMenager settingsMenager;          // ovo je stara clasa obrisati kasnije
        SettingsMenager2 settingsMenager2;
        RowCollectionMenager rowCollectionMenager;
        SyntaxHighlightingMenager syntaxHighlightingMenager;
        TagsStorage tagsStorage;


        public ModuleMainForm()
        {
            string templateFolder;
            InitializeComponent();

            try
            {
                // init mode settings
                Settings.Init();
                Settings.Setting.LoadFromFile(Common.BuildPath(GenericTemplate.moduleParams.DataPath, GenericTemplate.constModuleDataFolder) + Settings.FILE_NAME);

                // init and load tagsStorage object
                TagsLoader tagsLoader = new TagsLoader(Common.BuildPath(GenericTemplate.moduleParams.DataPath, GenericTemplate.constModuleDataFolder) + GenericTemplate.constTagsXMLFileName);
                this.tagsStorage = tagsLoader.LoadTags();

                // WindwosTools controls
                twtToolsWindowsTemplates = new ToolsWindowsTemplates();
                twttoolsWindowsTags = new ToolsWindowsTags(this.tagsStorage);
                twttoolsWindowsTags.AddControl(tbtemplateHeader);
                twttoolsWindowsTags.AddControl(tbtemplateBody);
                twttoolsWindowsTags.AddControl(tbtemplateFooter);
                twttoolsWindowsTags.AddControl(tbTemplateVariables);
                twttoolsWindowsTags.AddControl(tbTemplateComment);
                twttoolsWindowsTags.AddControl(tbFileDestinationFolder);
                twttoolsWindowsTags.AddControl(tbFileDestinationFile);

                // general default settings
                cbDataDestination.SelectedIndex = 0;

                // set icon
                this.Icon = global::UberTools.Modules.GenericTemplate.Properties.Resources.WindowsTable;

                // create settings menager object and add all controls
                templateFolder = Common.BuildPath(GenericTemplate.moduleParams.DataPath, GenericTemplate.constModuleDataFolder, GenericTemplate.constTemplateFolder);
                settingsMenager = new SettingsMenager();
                settingsMenager.Add(tbtemplateBody);
                settingsMenager.Add(tbtemplateHeader);
                settingsMenager.Add(tbtemplateFooter);
                settingsMenager.Add(tbTemplateVariables);
                settingsMenager.Add(tbTemplateComment);
                settingsMenager.Add(tbFileDestinationFolder);
                settingsMenager.Add(tbFileDestinationFile);
                settingsMenager.Add(chbDestinationFileAppend);
                settingsMenager.Add(cbDataDestination);
                settingsMenager.Add(cbEncoding);

                //// create settings menager version 2 object and add all controls
                settingsMenager2 = new SettingsMenager2(GenericTemplate.constModuleName, "UberToolsModule", "1.0.0.0");
                //settingsMenager2.Items.Add(new SettingsMenagerStructure2(tbtemplateBody, "tbtemplateBody", SettingsMenager2.Type.Textbox));
                settingsMenager2.Refresh += new EventHandler(settingsMenager2_Refresh);
                settingsMenager2.Update += new EventHandler(settingsMenager2_Update);

                // new instance template menager
                templatesMenager = new TemplatesManager(twtToolsWindowsTemplates.TreeViewControl, templateFolder, settingsMenager, settingsMenager2);
                this.twtToolsWindowsTemplates.ImageListControl = this.ilGeneral;
                templatesMenager.LoadAll();

                // set templateMenager to templateControl
                twtToolsWindowsTemplates.TemplatesMenager = templatesMenager;
                this.twtToolsWindowsTemplates.ImageListControl = this.ilGeneral;

                // Create new rowCollection object and bound it to container
                rowCollectionMenager = new RowCollectionMenager(panel1, this.settingsMenager2);
                foreach (EncodingMenager encoding in EncodingMenager.GetEnumerator())
                {
                    cbEncoding.Items.Add(encoding);
                }
                cbEncoding.SelectedIndex = cbEncoding.Items.Count - 2;

                // new instance of hoveringwindows
                autoComplete = new AutoComplete(this, this.tagsStorage);
                autoComplete.AddControl(tbtemplateHeader);
                autoComplete.AddControl(tbtemplateBody);
                autoComplete.AddControl(tbtemplateFooter);
                autoComplete.AddControl(tbTemplateVariables);
                autoComplete.AddControl(tbTemplateComment);
                autoComplete.AddControl(tbFileDestinationFolder);
                autoComplete.AddControl(tbFileDestinationFile);

                //// syntax color init
                //colorMenager = new ColorMenager_old();
                //colorMenager.Controls.Add(tbTemplateVariables);

                // SyntaxHighlightingMenager settings
                syntaxHighlightingMenager = new SyntaxHighlightingMenager(tagsStorage);
                syntaxHighlightingMenager.Controls.Add(tbTemplateVariables);
                syntaxHighlightingMenager.Controls.Add(tbtemplateBody);
                syntaxHighlightingMenager.Controls.Add(tbtemplateHeader);
                syntaxHighlightingMenager.Controls.Add(tbtemplateFooter);
                syntaxHighlightingMenager.Controls.Add(tbFileDestinationFolder);
                syntaxHighlightingMenager.Controls.Add(tbFileDestinationFile);


                // load last loadet template 
                if (Settings.Setting.LoadSetting(Settings.SettingName.ActiveTemplateName.ToString(), "") != "")
                {
                    templatesMenager.Load(Settings.Setting.LoadSetting(Settings.SettingName.ActiveTemplateName.ToString(), ""));
                }

            }
            catch (Exception ex)
            {
                ModuleLog.Write(ex, this, "ModuleMainForm", ModuleLog.LogType.ERROR);
            }
        }

        void settingsMenager2_Update(object sender, EventArgs e)
        {
            settingsMenager2.Items.Add(new SettingsMenagerStructure2(tbtemplateBody, "template-body-text"));
            settingsMenager2.Items.Add(new SettingsMenagerStructure2(tbtemplateBody, "template-body-text"));
            settingsMenager2.Items.Add(new SettingsMenagerStructure2(tbtemplateHeader, "template-header-text"));
            settingsMenager2.Items.Add(new SettingsMenagerStructure2(tbtemplateFooter, "template-footer-text"));
            settingsMenager2.Items.Add(new SettingsMenagerStructure2(tbTemplateVariables, "template-variables-text"));
            settingsMenager2.Items.Add(new SettingsMenagerStructure2(tbTemplateComment, "template-comment-text"));
            settingsMenager2.Items.Add(new SettingsMenagerStructure2(tbFileDestinationFolder, "file-destination-folder"));
            settingsMenager2.Items.Add(new SettingsMenagerStructure2(tbFileDestinationFile, "file-destination-name"));
            settingsMenager2.Items.Add(new SettingsMenagerStructure2(chbDestinationFileAppend, "file-destination-append"));
            settingsMenager2.Items.Add(new SettingsMenagerStructure2(cbDataDestination, "output-destination-type"));
            settingsMenager2.Items.Add(new SettingsMenagerStructure2(cbEncoding, "output-destination-encoding"));
        }

        void settingsMenager2_Refresh(object sender, EventArgs e)
        {
            settingsMenager2.LoadSetting(tbtemplateBody, "template-body-text", null);
            settingsMenager2.LoadSetting(tbtemplateHeader, "template-header-text", null);
            settingsMenager2.LoadSetting(tbtemplateFooter, "template-footer-text", null);
            settingsMenager2.LoadSetting(tbTemplateVariables, "template-variables-text", null);
            settingsMenager2.LoadSetting(tbTemplateComment, "template-comment-text", null);
            settingsMenager2.LoadSetting(tbFileDestinationFolder, "file-destination-folder", null);
            settingsMenager2.LoadSetting(tbFileDestinationFile, "file-destination-name", null);
            settingsMenager2.LoadSetting(chbDestinationFileAppend, "file-destination-append", null);
            settingsMenager2.LoadSetting(cbDataDestination, "output-destination-type", null);
            settingsMenager2.LoadSetting(cbEncoding, "output-destination-encoding", null);
            // create RTF colors on text
            tbTemplateVariables.ProccessFormatOnAllLines();
            tbtemplateBody.ProccessFormatOnAllLines();
            tbtemplateHeader.ProccessFormatOnAllLines();
            tbtemplateFooter.ProccessFormatOnAllLines();
            tbFileDestinationFolder.ProccessFormatOnAllLines();
            tbFileDestinationFile.ProccessFormatOnAllLines();
        }

        private void btnLoad_Click(object sender, EventArgs e)
        {
            try
            {
                InputDataSource inputDataSource = new InputDataSource(rowCollectionMenager, settingsMenager2);
                inputDataSource.ShowDialog(this);

            }
            catch(Exception ex)
            {
                ModuleLog.Write(ex,this,"btnLoad_Click",ModuleLog.LogType.ERROR);
            }
        }
        private void bTemplateWork_Click(object sender, EventArgs e)
        {
            OutputMenagerSettings oms;
            OutputMenager outputMenager;

            try
            {
                if (cbDataDestination.SelectedIndex == 0)
                {
                    oms = new OutputMenagerSettings(rowCollectionMenager, OutputMenagerSettings.DestinationType.File);
                    oms.SetPathTemplate(tbFileDestinationFolder.Text, tbFileDestinationFile.Text);

                }
                else if (cbDataDestination.SelectedIndex == 1)
                {
                    oms = new OutputMenagerSettings(rowCollectionMenager, OutputMenagerSettings.DestinationType.Notepad);
                }
                else if (cbDataDestination.SelectedIndex == 2)
                {
                    // data object - comparation string
                    oms = new OutputMenagerSettings(rowCollectionMenager, OutputMenagerSettings.DestinationType.DataObjectCompareStrings);
                    oms.SetRegExSpliter(tbObjectDestinationRegexRowSpliter.Text, tbObjectDestinationRegexColumnSpliter.Text);
                }
                else
                {
                    throw new Exception("No destination source selected");
                }

                oms.SetTemplateText(tbtemplateHeader.Text, tbtemplateBody.Text, tbtemplateFooter.Text, tbTemplateVariables.Text);
                oms.Encoding = ((EncodingMenager)cbEncoding.Items[cbEncoding.SelectedIndex]).Encoding;
                oms.AppendFile = chbDestinationFileAppend.Checked;
                outputMenager = new OutputMenager(oms);
                if (rowCollectionMenager.SelectedCount > 0)
                {
                    outputMenager.SelectObjectData();
                }
                else
                {
                    InputBox frm = new InputBox("Set counter", "Set counter", "1");
                    DialogResult result = frm.ShowDialog(this);
                    if (result == DialogResult.OK)
                    {
                        outputMenager.Run_Counter(int.Parse(frm.InputTekst));
                    }
                }

            }
            catch (Exception exc)
            {
                ModuleLog.Write(exc, this, "bTemplateWork_Click", ModuleLog.LogType.ERROR);
            }
            MessageBox.Show("Done");
        }



        private void btnBrowseFolder_Click(object sender, EventArgs e)
        {
            folderBrowserDialog1.SelectedPath = tbFileDestinationFolder.Text;
            DialogResult dialogResult = folderBrowserDialog1.ShowDialog(this);
            if(dialogResult == DialogResult.OK)
            {
                tbFileDestinationFolder.Text = folderBrowserDialog1.SelectedPath + @"\";
            }
        }



        private void cbDataDestination_SelectedIndexChanged(object sender, EventArgs e)
        {
            foreach (System.Windows.Forms.Control destinationPanel in groupBox3.Controls)
            {
                if (destinationPanel.GetType() == typeof(System.Windows.Forms.Panel))
                {
                    if (destinationPanel.Name.EndsWith(cbDataDestination.SelectedIndex.ToString()))
                    {
                        destinationPanel.Visible = true;
                    }
                    else
                    {
                        destinationPanel.Visible = false;
                    }

                }
            }
        }

        private void tbtemplate_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control == true && e.KeyCode == Keys.A)
            {
                TextBoxBase textBox = (TextBoxBase)sender;
                textBox.SelectAll();
            }
        }

        public override UserControlBase[] ToolsWindows()
        {
            UserControlBase[] toolsWindows = new UserControlBase[2];
            toolsWindows[0] = twtToolsWindowsTemplates;
            toolsWindows[1] = twttoolsWindowsTags;
            return toolsWindows;
        }

        private void ModuleMainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            Settings.Setting.SaveToFile(Common.BuildPath(GenericTemplate.moduleParams.DataPath, GenericTemplate.constModuleDataFolder) + Settings.FILE_NAME);
        }
    }
}
        