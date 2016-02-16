namespace UberTools.Modules.GenericTemplate.InputData
{
    partial class InputDataSource
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label4 = new System.Windows.Forms.Label();
            this.cbDataSource = new System.Windows.Forms.ComboBox();
            this.label12 = new System.Windows.Forms.Label();
            this.tbXPath = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.bBrowseFile = new System.Windows.Forms.Button();
            this.tbSourceFile = new System.Windows.Forms.TextBox();
            this.tbRegexRowSpliter = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.tbRegexColumnSpliter = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.bCancel = new System.Windows.Forms.Button();
            this.bLoad = new System.Windows.Forms.Button();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.gbClipboard_1 = new System.Windows.Forms.GroupBox();
            this.cbRegexFirstColumnAsColumnName = new System.Windows.Forms.CheckBox();
            this.label1 = new System.Windows.Forms.Label();
            this.gbXMLFile_2 = new System.Windows.Forms.GroupBox();
            this.cbIgnoreInnerText = new System.Windows.Forms.CheckBox();
            this.cbIgnoreAttributes = new System.Windows.Forms.CheckBox();
            this.label2 = new System.Windows.Forms.Label();
            this.gbDirectory_5 = new System.Windows.Forms.GroupBox();
            this.cbFolderInputLookSubfolders = new System.Windows.Forms.CheckBox();
            this.label10 = new System.Windows.Forms.Label();
            this.tbFolderInputColumnRegex = new System.Windows.Forms.TextBox();
            this.tbFolderInputFolderMatcher = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.bFolderInputBrowse = new System.Windows.Forms.Button();
            this.tbFolderInputPath = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.gbFile_6 = new System.Windows.Forms.GroupBox();
            this.tbFileInputFileMatcher = new System.Windows.Forms.TextBox();
            this.label16 = new System.Windows.Forms.Label();
            this.cbFileInputSubfolders = new System.Windows.Forms.CheckBox();
            this.tbFileInputColumnSpliter = new System.Windows.Forms.TextBox();
            this.tbFileInputFolderMatcher = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.bFileInputBrowse = new System.Windows.Forms.Button();
            this.tbFileInputFolder = new System.Windows.Forms.TextBox();
            this.label15 = new System.Windows.Forms.Label();
            this.gbLoadRowCollection_0 = new System.Windows.Forms.GroupBox();
            this.lbDataObjectList = new System.Windows.Forms.ListBox();
            this.gbClipboard_1.SuspendLayout();
            this.gbXMLFile_2.SuspendLayout();
            this.gbDirectory_5.SuspendLayout();
            this.gbFile_6.SuspendLayout();
            this.gbLoadRowCollection_0.SuspendLayout();
            this.SuspendLayout();
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(5, 9);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(41, 13);
            this.label4.TabIndex = 15;
            this.label4.Text = "Source";
            // 
            // cbDataSource
            // 
            this.cbDataSource.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbDataSource.FormattingEnabled = true;
            this.cbDataSource.Items.AddRange(new object[] {
            "Load saved data object",
            "Clipboard",
            "XML File",
            "Text dialog",
            "Data base",
            "Folder",
            "File",
            "HTTP link",
            "The Void"});
            this.cbDataSource.Location = new System.Drawing.Point(5, 25);
            this.cbDataSource.Name = "cbDataSource";
            this.cbDataSource.Size = new System.Drawing.Size(265, 21);
            this.cbDataSource.TabIndex = 17;
            this.cbDataSource.SelectedIndexChanged += new System.EventHandler(this.cbDataSource_SelectedIndexChanged);
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(8, 51);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(39, 13);
            this.label12.TabIndex = 6;
            this.label12.Text = "XPath:";
            // 
            // tbXPath
            // 
            this.tbXPath.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tbXPath.Location = new System.Drawing.Point(60, 48);
            this.tbXPath.Name = "tbXPath";
            this.tbXPath.Size = new System.Drawing.Size(688, 20);
            this.tbXPath.TabIndex = 5;
            this.tbXPath.Text = "/*";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(8, 21);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(32, 13);
            this.label7.TabIndex = 2;
            this.label7.Text = "Path:";
            // 
            // bBrowseFile
            // 
            this.bBrowseFile.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.bBrowseFile.Location = new System.Drawing.Point(754, 17);
            this.bBrowseFile.Name = "bBrowseFile";
            this.bBrowseFile.Size = new System.Drawing.Size(75, 23);
            this.bBrowseFile.TabIndex = 1;
            this.bBrowseFile.Text = "Browse...";
            this.bBrowseFile.UseVisualStyleBackColor = true;
            this.bBrowseFile.Click += new System.EventHandler(this.bBrowseFile_Click);
            // 
            // tbSourceFile
            // 
            this.tbSourceFile.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tbSourceFile.Location = new System.Drawing.Point(60, 18);
            this.tbSourceFile.Name = "tbSourceFile";
            this.tbSourceFile.Size = new System.Drawing.Size(688, 20);
            this.tbSourceFile.TabIndex = 0;
            this.tbSourceFile.Text = "c:\\test.xml";
            // 
            // tbRegexRowSpliter
            // 
            this.tbRegexRowSpliter.Location = new System.Drawing.Point(120, 29);
            this.tbRegexRowSpliter.Name = "tbRegexRowSpliter";
            this.tbRegexRowSpliter.Size = new System.Drawing.Size(510, 20);
            this.tbRegexRowSpliter.TabIndex = 20;
            this.tbRegexRowSpliter.Text = "\\r\\n";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(8, 32);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(91, 13);
            this.label6.TabIndex = 19;
            this.label6.Text = "Regex row spliter:";
            // 
            // tbRegexColumnSpliter
            // 
            this.tbRegexColumnSpliter.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tbRegexColumnSpliter.Location = new System.Drawing.Point(120, 63);
            this.tbRegexColumnSpliter.Name = "tbRegexColumnSpliter";
            this.tbRegexColumnSpliter.Size = new System.Drawing.Size(510, 20);
            this.tbRegexColumnSpliter.TabIndex = 16;
            this.tbRegexColumnSpliter.Text = "\\t";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(6, 66);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(108, 13);
            this.label5.TabIndex = 18;
            this.label5.Text = "Regex column spliter:";
            // 
            // bCancel
            // 
            this.bCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.bCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.bCancel.Location = new System.Drawing.Point(772, 266);
            this.bCancel.Name = "bCancel";
            this.bCancel.Size = new System.Drawing.Size(77, 23);
            this.bCancel.TabIndex = 30;
            this.bCancel.Text = "&Cancel";
            this.bCancel.UseVisualStyleBackColor = true;
            // 
            // bLoad
            // 
            this.bLoad.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.bLoad.Location = new System.Drawing.Point(676, 266);
            this.bLoad.Name = "bLoad";
            this.bLoad.Size = new System.Drawing.Size(77, 23);
            this.bLoad.TabIndex = 31;
            this.bLoad.Text = "&Load";
            this.bLoad.UseVisualStyleBackColor = true;
            this.bLoad.Click += new System.EventHandler(this.bLoad_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // gbClipboard_1
            // 
            this.gbClipboard_1.Controls.Add(this.cbRegexFirstColumnAsColumnName);
            this.gbClipboard_1.Controls.Add(this.label1);
            this.gbClipboard_1.Controls.Add(this.tbRegexRowSpliter);
            this.gbClipboard_1.Controls.Add(this.label6);
            this.gbClipboard_1.Controls.Add(this.label5);
            this.gbClipboard_1.Controls.Add(this.tbRegexColumnSpliter);
            this.gbClipboard_1.Location = new System.Drawing.Point(6, 52);
            this.gbClipboard_1.Name = "gbClipboard_1";
            this.gbClipboard_1.Size = new System.Drawing.Size(844, 208);
            this.gbClipboard_1.TabIndex = 32;
            this.gbClipboard_1.TabStop = false;
            this.gbClipboard_1.Text = "Clipboard";
            // 
            // cbRegexFirstColumnAsColumnName
            // 
            this.cbRegexFirstColumnAsColumnName.AutoSize = true;
            this.cbRegexFirstColumnAsColumnName.Location = new System.Drawing.Point(11, 95);
            this.cbRegexFirstColumnAsColumnName.Name = "cbRegexFirstColumnAsColumnName";
            this.cbRegexFirstColumnAsColumnName.Size = new System.Drawing.Size(162, 17);
            this.cbRegexFirstColumnAsColumnName.TabIndex = 22;
            this.cbRegexFirstColumnAsColumnName.Text = "First column as column name";
            this.cbRegexFirstColumnAsColumnName.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.SystemColors.GrayText;
            this.label1.Location = new System.Drawing.Point(8, 144);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(528, 13);
            this.label1.TabIndex = 21;
            this.label1.Text = "Load data directly from the clipboard. Number of columns and rows depends on the " +
                "regular expression entered.";
            // 
            // gbXMLFile_2
            // 
            this.gbXMLFile_2.Controls.Add(this.cbIgnoreInnerText);
            this.gbXMLFile_2.Controls.Add(this.cbIgnoreAttributes);
            this.gbXMLFile_2.Controls.Add(this.label2);
            this.gbXMLFile_2.Controls.Add(this.label12);
            this.gbXMLFile_2.Controls.Add(this.label7);
            this.gbXMLFile_2.Controls.Add(this.tbXPath);
            this.gbXMLFile_2.Controls.Add(this.tbSourceFile);
            this.gbXMLFile_2.Controls.Add(this.bBrowseFile);
            this.gbXMLFile_2.Location = new System.Drawing.Point(6, 52);
            this.gbXMLFile_2.Name = "gbXMLFile_2";
            this.gbXMLFile_2.Size = new System.Drawing.Size(844, 208);
            this.gbXMLFile_2.TabIndex = 33;
            this.gbXMLFile_2.TabStop = false;
            this.gbXMLFile_2.Text = "XML File";
            // 
            // cbIgnoreInnerText
            // 
            this.cbIgnoreInnerText.AutoSize = true;
            this.cbIgnoreInnerText.Location = new System.Drawing.Point(143, 83);
            this.cbIgnoreInnerText.Name = "cbIgnoreInnerText";
            this.cbIgnoreInnerText.Size = new System.Drawing.Size(102, 17);
            this.cbIgnoreInnerText.TabIndex = 9;
            this.cbIgnoreInnerText.Text = "Ignore inner text";
            this.cbIgnoreInnerText.UseVisualStyleBackColor = true;
            // 
            // cbIgnoreAttributes
            // 
            this.cbIgnoreAttributes.AutoSize = true;
            this.cbIgnoreAttributes.Location = new System.Drawing.Point(11, 83);
            this.cbIgnoreAttributes.Name = "cbIgnoreAttributes";
            this.cbIgnoreAttributes.Size = new System.Drawing.Size(102, 17);
            this.cbIgnoreAttributes.TabIndex = 8;
            this.cbIgnoreAttributes.Text = "Ignore attributes";
            this.cbIgnoreAttributes.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.SystemColors.GrayText;
            this.label2.Location = new System.Drawing.Point(8, 143);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(604, 13);
            this.label2.TabIndex = 7;
            this.label2.Text = "Load data directly from the xml file. Loaded objects will have a parent / child s" +
                "tructure. To restrict entry try using XPath selector.";
            // 
            // gbDirectory_5
            // 
            this.gbDirectory_5.Controls.Add(this.cbFolderInputLookSubfolders);
            this.gbDirectory_5.Controls.Add(this.label10);
            this.gbDirectory_5.Controls.Add(this.tbFolderInputColumnRegex);
            this.gbDirectory_5.Controls.Add(this.tbFolderInputFolderMatcher);
            this.gbDirectory_5.Controls.Add(this.label9);
            this.gbDirectory_5.Controls.Add(this.label8);
            this.gbDirectory_5.Controls.Add(this.bFolderInputBrowse);
            this.gbDirectory_5.Controls.Add(this.tbFolderInputPath);
            this.gbDirectory_5.Controls.Add(this.label3);
            this.gbDirectory_5.Location = new System.Drawing.Point(6, 52);
            this.gbDirectory_5.Name = "gbDirectory_5";
            this.gbDirectory_5.Size = new System.Drawing.Size(844, 208);
            this.gbDirectory_5.TabIndex = 34;
            this.gbDirectory_5.TabStop = false;
            this.gbDirectory_5.Text = "Folder";
            this.gbDirectory_5.Visible = false;
            // 
            // cbFolderInputLookSubfolders
            // 
            this.cbFolderInputLookSubfolders.AutoSize = true;
            this.cbFolderInputLookSubfolders.Location = new System.Drawing.Point(6, 138);
            this.cbFolderInputLookSubfolders.Name = "cbFolderInputLookSubfolders";
            this.cbFolderInputLookSubfolders.Size = new System.Drawing.Size(114, 17);
            this.cbFolderInputLookSubfolders.TabIndex = 8;
            this.cbFolderInputLookSubfolders.Text = "Look all subfolders";
            this.cbFolderInputLookSubfolders.UseVisualStyleBackColor = true;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(8, 172);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(39, 13);
            this.label10.TabIndex = 7;
            this.label10.Text = "no info";
            // 
            // tbFolderInputColumnRegex
            // 
            this.tbFolderInputColumnRegex.Location = new System.Drawing.Point(120, 103);
            this.tbFolderInputColumnRegex.Name = "tbFolderInputColumnRegex";
            this.tbFolderInputColumnRegex.Size = new System.Drawing.Size(626, 20);
            this.tbFolderInputColumnRegex.TabIndex = 6;
            // 
            // tbFolderInputFolderMatcher
            // 
            this.tbFolderInputFolderMatcher.Location = new System.Drawing.Point(120, 68);
            this.tbFolderInputFolderMatcher.Name = "tbFolderInputFolderMatcher";
            this.tbFolderInputFolderMatcher.Size = new System.Drawing.Size(626, 20);
            this.tbFolderInputFolderMatcher.TabIndex = 5;
            this.tbFolderInputFolderMatcher.Text = ".*";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(6, 103);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(104, 13);
            this.label9.TabIndex = 4;
            this.label9.Text = "Column spliter regex:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(6, 68);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(106, 13);
            this.label8.TabIndex = 3;
            this.label8.Text = "Folder matcher regex";
            // 
            // bFolderInputBrowse
            // 
            this.bFolderInputBrowse.Location = new System.Drawing.Point(752, 29);
            this.bFolderInputBrowse.Name = "bFolderInputBrowse";
            this.bFolderInputBrowse.Size = new System.Drawing.Size(75, 23);
            this.bFolderInputBrowse.TabIndex = 2;
            this.bFolderInputBrowse.Text = "Browse...";
            this.bFolderInputBrowse.UseVisualStyleBackColor = true;
            this.bFolderInputBrowse.Click += new System.EventHandler(this.bInputFolderBrowse_Click);
            // 
            // tbFolderInputPath
            // 
            this.tbFolderInputPath.Location = new System.Drawing.Point(58, 31);
            this.tbFolderInputPath.Name = "tbFolderInputPath";
            this.tbFolderInputPath.Size = new System.Drawing.Size(688, 20);
            this.tbFolderInputPath.TabIndex = 1;
            this.tbFolderInputPath.Text = "c:\\";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 34);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(39, 13);
            this.label3.TabIndex = 0;
            this.label3.Text = "Folder:";
            // 
            // gbFile_6
            // 
            this.gbFile_6.Controls.Add(this.tbFileInputFileMatcher);
            this.gbFile_6.Controls.Add(this.label16);
            this.gbFile_6.Controls.Add(this.cbFileInputSubfolders);
            this.gbFile_6.Controls.Add(this.tbFileInputColumnSpliter);
            this.gbFile_6.Controls.Add(this.tbFileInputFolderMatcher);
            this.gbFile_6.Controls.Add(this.label13);
            this.gbFile_6.Controls.Add(this.label14);
            this.gbFile_6.Controls.Add(this.bFileInputBrowse);
            this.gbFile_6.Controls.Add(this.tbFileInputFolder);
            this.gbFile_6.Controls.Add(this.label15);
            this.gbFile_6.Location = new System.Drawing.Point(6, 52);
            this.gbFile_6.Name = "gbFile_6";
            this.gbFile_6.Size = new System.Drawing.Size(844, 208);
            this.gbFile_6.TabIndex = 35;
            this.gbFile_6.TabStop = false;
            this.gbFile_6.Text = "Files";
            this.gbFile_6.Visible = false;
            // 
            // tbFileInputFileMatcher
            // 
            this.tbFileInputFileMatcher.Location = new System.Drawing.Point(122, 96);
            this.tbFileInputFileMatcher.Name = "tbFileInputFileMatcher";
            this.tbFileInputFileMatcher.Size = new System.Drawing.Size(626, 20);
            this.tbFileInputFileMatcher.TabIndex = 10;
            this.tbFileInputFileMatcher.Text = ".*\\..*";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(6, 99);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(93, 13);
            this.label16.TabIndex = 9;
            this.label16.Text = "File matcher regex";
            // 
            // cbFileInputSubfolders
            // 
            this.cbFileInputSubfolders.AutoSize = true;
            this.cbFileInputSubfolders.Checked = true;
            this.cbFileInputSubfolders.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbFileInputSubfolders.Location = new System.Drawing.Point(9, 168);
            this.cbFileInputSubfolders.Name = "cbFileInputSubfolders";
            this.cbFileInputSubfolders.Size = new System.Drawing.Size(114, 17);
            this.cbFileInputSubfolders.TabIndex = 8;
            this.cbFileInputSubfolders.Text = "Look all subfolders";
            this.cbFileInputSubfolders.UseVisualStyleBackColor = true;
            // 
            // tbFileInputColumnSpliter
            // 
            this.tbFileInputColumnSpliter.Location = new System.Drawing.Point(122, 127);
            this.tbFileInputColumnSpliter.Name = "tbFileInputColumnSpliter";
            this.tbFileInputColumnSpliter.Size = new System.Drawing.Size(626, 20);
            this.tbFileInputColumnSpliter.TabIndex = 6;
            // 
            // tbFileInputFolderMatcher
            // 
            this.tbFileInputFolderMatcher.Location = new System.Drawing.Point(122, 63);
            this.tbFileInputFolderMatcher.Name = "tbFileInputFolderMatcher";
            this.tbFileInputFolderMatcher.Size = new System.Drawing.Size(626, 20);
            this.tbFileInputFolderMatcher.TabIndex = 5;
            this.tbFileInputFolderMatcher.Text = ".*";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(6, 130);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(104, 13);
            this.label13.TabIndex = 4;
            this.label13.Text = "Column spliter regex:";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(6, 68);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(106, 13);
            this.label14.TabIndex = 3;
            this.label14.Text = "Folder matcher regex";
            // 
            // bFileInputBrowse
            // 
            this.bFileInputBrowse.Location = new System.Drawing.Point(752, 29);
            this.bFileInputBrowse.Name = "bFileInputBrowse";
            this.bFileInputBrowse.Size = new System.Drawing.Size(75, 23);
            this.bFileInputBrowse.TabIndex = 2;
            this.bFileInputBrowse.Text = "Browse...";
            this.bFileInputBrowse.UseVisualStyleBackColor = true;
            this.bFileInputBrowse.Click += new System.EventHandler(this.bFileInputBrowse_Click);
            // 
            // tbFileInputFolder
            // 
            this.tbFileInputFolder.Location = new System.Drawing.Point(58, 31);
            this.tbFileInputFolder.Name = "tbFileInputFolder";
            this.tbFileInputFolder.Size = new System.Drawing.Size(688, 20);
            this.tbFileInputFolder.TabIndex = 1;
            this.tbFileInputFolder.Text = "c:\\";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(6, 34);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(39, 13);
            this.label15.TabIndex = 0;
            this.label15.Text = "Folder:";
            // 
            // gbLoadRowCollection_0
            // 
            this.gbLoadRowCollection_0.Controls.Add(this.lbDataObjectList);
            this.gbLoadRowCollection_0.Location = new System.Drawing.Point(5, 52);
            this.gbLoadRowCollection_0.Name = "gbLoadRowCollection_0";
            this.gbLoadRowCollection_0.Size = new System.Drawing.Size(844, 208);
            this.gbLoadRowCollection_0.TabIndex = 36;
            this.gbLoadRowCollection_0.TabStop = false;
            this.gbLoadRowCollection_0.Text = "Load saved data objects";
            // 
            // lbDataObjectList
            // 
            this.lbDataObjectList.FormattingEnabled = true;
            this.lbDataObjectList.Location = new System.Drawing.Point(10, 28);
            this.lbDataObjectList.Name = "lbDataObjectList";
            this.lbDataObjectList.Size = new System.Drawing.Size(828, 173);
            this.lbDataObjectList.TabIndex = 0;
            // 
            // InputDataSource
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.bCancel;
            this.ClientSize = new System.Drawing.Size(853, 297);
            this.Controls.Add(this.gbClipboard_1);
            this.Controls.Add(this.gbXMLFile_2);
            this.Controls.Add(this.gbDirectory_5);
            this.Controls.Add(this.gbFile_6);
            this.Controls.Add(this.gbLoadRowCollection_0);
            this.Controls.Add(this.bLoad);
            this.Controls.Add(this.bCancel);
            this.Controls.Add(this.cbDataSource);
            this.Controls.Add(this.label4);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "InputDataSource";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Text = "Select Input Data Source";
            this.gbClipboard_1.ResumeLayout(false);
            this.gbClipboard_1.PerformLayout();
            this.gbXMLFile_2.ResumeLayout(false);
            this.gbXMLFile_2.PerformLayout();
            this.gbDirectory_5.ResumeLayout(false);
            this.gbDirectory_5.PerformLayout();
            this.gbFile_6.ResumeLayout(false);
            this.gbFile_6.PerformLayout();
            this.gbLoadRowCollection_0.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cbDataSource;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox tbXPath;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button bBrowseFile;
        private System.Windows.Forms.TextBox tbSourceFile;
        private System.Windows.Forms.TextBox tbRegexRowSpliter;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox tbRegexColumnSpliter;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button bCancel;
        private System.Windows.Forms.Button bLoad;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.GroupBox gbClipboard_1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox gbXMLFile_2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.CheckBox cbIgnoreAttributes;
        private System.Windows.Forms.CheckBox cbIgnoreInnerText;
        private System.Windows.Forms.GroupBox gbDirectory_5;
        private System.Windows.Forms.Button bFolderInputBrowse;
        private System.Windows.Forms.TextBox tbFolderInputPath;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox tbFolderInputColumnRegex;
        private System.Windows.Forms.TextBox tbFolderInputFolderMatcher;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.CheckBox cbFolderInputLookSubfolders;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.GroupBox gbFile_6;
        private System.Windows.Forms.CheckBox cbFileInputSubfolders;
        private System.Windows.Forms.TextBox tbFileInputColumnSpliter;
        private System.Windows.Forms.TextBox tbFileInputFolderMatcher;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Button bFileInputBrowse;
        private System.Windows.Forms.TextBox tbFileInputFolder;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.TextBox tbFileInputFileMatcher;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.CheckBox cbRegexFirstColumnAsColumnName;
        private System.Windows.Forms.GroupBox gbLoadRowCollection_0;
        private System.Windows.Forms.ListBox lbDataObjectList;
    }
}