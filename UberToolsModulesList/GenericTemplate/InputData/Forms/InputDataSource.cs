using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;

using DamirM.Modules;
using UberTools.Modules.GenericTemplate.RowCollectionNS;
using DamirM.CommonLibrary;

namespace UberTools.Modules.GenericTemplate.InputData
{
    public partial class InputDataSource : Form
    {
        RowCollectionMenager rowCollectionMenager;
        SettingsMenager2 settingsMenager2;

        public InputDataSource(RowCollectionMenager rowCollectionMenager, SettingsMenager2 settingsMenager2)
        {
            InitializeComponent();
            this.rowCollectionMenager = rowCollectionMenager;
            this.settingsMenager2 = settingsMenager2;
            cbDataSource.SelectedIndex = 0;

            try
            {
                ///
                ///   ovo extraktirati u metodu ili u klasu od data object menagera nekoga
                ///
                ///
                string dataObjectPath = Common.BuildPath(GenericTemplate.moduleParams.DataPath, GenericTemplate.constModuleDataFolder, GenericTemplate.constDataObjectsFolder);
                string fileName;
                string[] fileList = Directory.GetFiles(dataObjectPath, "*.xml");

                foreach (string item in fileList)
                {
                    fileName = Common.ExtractFileFromPath(item);
                    fileName = fileName.Replace(".xml", "");
                    lbDataObjectList.Items.Add(fileName);
                }

                LoadSettingsFromSettingsMenager();
            }
            catch (Exception ex)
            {
                ModuleLog.Write(ex, this, "InputDataSource", ModuleLog.LogType.ERROR);
            }
        }

        private void bBrowseFile_Click(object sender, EventArgs e)
        {
            openFileDialog1.InitialDirectory = tbSourceFile.Text;
            DialogResult dialogResult = openFileDialog1.ShowDialog(this);
            if (dialogResult == DialogResult.OK)
            {
                tbSourceFile.Text = openFileDialog1.FileName;
            }
        }

        private void cbDataSource_SelectedIndexChanged(object sender, EventArgs e)
        {
            foreach (System.Windows.Forms.Control optionsPanle in this.Controls)
            {
                if (optionsPanle.GetType() == typeof(System.Windows.Forms.GroupBox))
                {
                    if (optionsPanle.Name.EndsWith(cbDataSource.SelectedIndex.ToString()))
                    {
                        optionsPanle.Visible = true;
                    }
                    else
                    {
                        optionsPanle.Visible = false;
                    }

                }
            }
        }

        private void bLoad_Click(object sender, EventArgs e)
        {
            try
            {
                bLoad.Enabled = false;
                bLoad.Text = "Loading...";
                if (cbDataSource.SelectedIndex == 0)
                {
                    string dataObjectPath = Common.BuildPath(GenericTemplate.moduleParams.DataPath, GenericTemplate.constModuleDataFolder, GenericTemplate.constDataObjectsFolder);
                    string dataObjectName = lbDataObjectList.Items[lbDataObjectList.SelectedIndex].ToString();
                    dataObjectName += ".xml";

                    RowCollectionIO rowCollectionIO = new RowCollectionIO(rowCollectionMenager, dataObjectPath + dataObjectName);
                    rowCollectionIO.Load();

                }
                else if (cbDataSource.SelectedIndex == 1)
                {
                    // Input data from clipboard
                    // new parser will add rows to rowCollection object
                    TextParser textParser = new TextParser(rowCollectionMenager);
                    textParser.AutomaticAddToRowCollectionMenager_ClipboardSource(tbRegexColumnSpliter.Text, tbRegexRowSpliter.Text, cbRegexFirstColumnAsColumnName.Checked);
                }
                else if (cbDataSource.SelectedIndex == 2)
                {
                    // Input data from xml file
                    //XMLParser xmlParser = new XMLParser(rowCollectionMenager, tbSourceFile.Text, int.Parse(tbSourceXMLStartDepth.Text));
                    XMLParser2 xmlParser = new XMLParser2(rowCollectionMenager, tbSourceFile.Text, tbXPath.Text);
                }
                else if (cbDataSource.SelectedIndex == 5)
                {
                    FolderParser folderParser = new FolderParser(rowCollectionMenager);
                    folderParser.AutomaticAddToRowCollectionMenager_FolderSource(tbFolderInputPath.Text, tbFolderInputFolderMatcher.Text, tbFolderInputColumnRegex.Text, cbFolderInputLookSubfolders.Checked);
                }
                else if (cbDataSource.SelectedIndex == 6)
                {
                    FileParser folderParser = new FileParser(rowCollectionMenager);
                    folderParser.AutomaticAddToRowCollectionMenager_FileSource(tbFileInputFolder.Text, tbFileInputFolderMatcher.Text, tbFileInputFileMatcher.Text, tbFileInputColumnSpliter.Text, cbFileInputSubfolders.Checked);
                }
                else
                {
                    MessageBox.Show("Select data source");
                }

                // save settings
                SaveSettingsToSettingsMenager();
            }
            catch (Exception ex)
            {
                ModuleLog.Write(ex, this, "btnLoad_Click", ModuleLog.LogType.ERROR);
            }
            this.Close();
        }

        private void bInputFolderBrowse_Click(object sender, EventArgs e)
        {
            //folderBrowserDialog1.RootFolder = tbInputFolderPath.Text;
            DialogResult dialogResult = folderBrowserDialog1.ShowDialog(this);
            if (dialogResult == DialogResult.OK)
            {
                tbFolderInputPath.Text = folderBrowserDialog1.SelectedPath;
            }
        }

        private void bFileInputBrowse_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = folderBrowserDialog1.ShowDialog(this);
            if (dialogResult == DialogResult.OK)
            {
                tbFileInputFolder.Text = folderBrowserDialog1.SelectedPath;
            }
        }


        private void SaveSettingsToSettingsMenager()
        {
            // select input box
            this.settingsMenager2.Items.Add(new SettingsMenagerStructure2(cbDataSource, "input-data-source"));

            // clibbord panel
            this.settingsMenager2.Items.Add(new SettingsMenagerStructure2(tbRegexRowSpliter, "input-clipbord-row-spliter"));
            this.settingsMenager2.Items.Add(new SettingsMenagerStructure2(tbRegexColumnSpliter, "input-clipbord-column-spliter"));
            this.settingsMenager2.Items.Add(new SettingsMenagerStructure2(cbRegexFirstColumnAsColumnName, "input-clipbord-first-row-ass-column-name"));

            // xml panel
            this.settingsMenager2.Items.Add(new SettingsMenagerStructure2(tbSourceFile, "input-xml-file"));
            this.settingsMenager2.Items.Add(new SettingsMenagerStructure2(tbXPath, "input-xml-xpath"));
            this.settingsMenager2.Items.Add(new SettingsMenagerStructure2(cbIgnoreAttributes, "input-xml-ignore-attributes"));
            this.settingsMenager2.Items.Add(new SettingsMenagerStructure2(cbIgnoreInnerText, "input-xml-ignore-inner-text"));
            // folder panel
            this.settingsMenager2.Items.Add(new SettingsMenagerStructure2(tbFolderInputPath, "input-folder-path"));
            this.settingsMenager2.Items.Add(new SettingsMenagerStructure2(tbFolderInputFolderMatcher, "input-folder-folder-matcher"));
            this.settingsMenager2.Items.Add(new SettingsMenagerStructure2(tbFolderInputColumnRegex, "input-folder-column-regex"));
            this.settingsMenager2.Items.Add(new SettingsMenagerStructure2(cbFolderInputLookSubfolders, "input-folder-look-subfolders"));
            // file panel
            this.settingsMenager2.Items.Add(new SettingsMenagerStructure2(tbFileInputFolder, "input-file-path"));
            this.settingsMenager2.Items.Add(new SettingsMenagerStructure2(tbFileInputFolderMatcher, "input-file-folder-matcher"));
            this.settingsMenager2.Items.Add(new SettingsMenagerStructure2(tbFileInputFileMatcher, "input-file-file-matcher"));
            this.settingsMenager2.Items.Add(new SettingsMenagerStructure2(tbFileInputColumnSpliter, "input-file-column-regex"));
            this.settingsMenager2.Items.Add(new SettingsMenagerStructure2(cbFileInputSubfolders, "input-file-look-subfolders"));


        }
        private void LoadSettingsFromSettingsMenager()
        {
            // select input box
            this.settingsMenager2.LoadSetting(cbDataSource, "input-data-source", "0");

            // clibbord panel
            this.settingsMenager2.LoadSetting(tbRegexRowSpliter, "input-clipbord-row-spliter", @"\r\n");
            this.settingsMenager2.LoadSetting(tbRegexColumnSpliter, "input-clipbord-column-spliter", @"\t");
            this.settingsMenager2.LoadSetting(cbRegexFirstColumnAsColumnName, "input-clipbord-first-row-ass-column-name", "false");
            // xml panel
            this.settingsMenager2.LoadSetting(tbSourceFile, "input-xml-file", "c:\\test.xml");
            this.settingsMenager2.LoadSetting(tbXPath, "input-xml-xpath", "/*");
            this.settingsMenager2.LoadSetting(cbIgnoreAttributes, "input-xml-ignore-attributes", "false");
            this.settingsMenager2.LoadSetting(cbIgnoreInnerText, "input-xml-ignore-inner-text", "false");
            // folder panel
            this.settingsMenager2.LoadSetting(tbFolderInputPath, "input-folder-path", "c:\\");
            this.settingsMenager2.LoadSetting(tbFolderInputFolderMatcher, "input-folder-folder-matcher", ".*");
            this.settingsMenager2.LoadSetting(tbFolderInputColumnRegex, "input-folder-column-regex", "");
            this.settingsMenager2.LoadSetting(cbFolderInputLookSubfolders, "input-folder-look-subfolders", "true");
            // file panel
            this.settingsMenager2.LoadSetting(tbFileInputFolder, "input-file-path", "c:\\");
            this.settingsMenager2.LoadSetting(tbFileInputFolderMatcher, "input-file-folder-matcher", ".*");
            this.settingsMenager2.LoadSetting(tbFileInputFileMatcher, "input-file-file-matcher", @".*\.(jpg|jepg|gif|bmp|)");
            this.settingsMenager2.LoadSetting(tbFileInputColumnSpliter, "input-file-column-regex", "");
            this.settingsMenager2.LoadSetting(cbFileInputSubfolders, "input-file-look-subfolders", "true");
        }

    }
}
