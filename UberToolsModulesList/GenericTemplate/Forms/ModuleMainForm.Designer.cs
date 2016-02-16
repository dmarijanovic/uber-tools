namespace UberTools.Modules.GenericTemplate.Forms
{
    partial class ModuleMainForm
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ModuleMainForm));
            this.tbtemplateBody = new DamirM.Controls.SyntaxHighlightingTextBox();
            this.bTemplateWork = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.tbFileDestinationFile = new DamirM.Controls.SyntaxHighlightingTextBox();
            this.btnLoad = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.tbFileDestinationFolder = new DamirM.Controls.SyntaxHighlightingTextBox();
            this.btnBrowseFolder = new System.Windows.Forms.Button();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.chbDestinationFileAppend = new System.Windows.Forms.CheckBox();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage5 = new System.Windows.Forms.TabPage();
            this.tbTemplateVariables = new DamirM.Controls.SyntaxHighlightingTextBox();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.tbtemplateHeader = new DamirM.Controls.SyntaxHighlightingTextBox();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.tbtemplateFooter = new DamirM.Controls.SyntaxHighlightingTextBox();
            this.tabPage4 = new System.Windows.Forms.TabPage();
            this.tbTemplateComment = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.cbDataDestination = new System.Windows.Forms.ComboBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.pDestinationOptions0 = new System.Windows.Forms.Panel();
            this.label9 = new System.Windows.Forms.Label();
            this.cbEncoding = new System.Windows.Forms.ComboBox();
            this.pDestinationOptions2 = new System.Windows.Forms.Panel();
            this.tbObjectDestinationRegexRowSpliter = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.tbObjectDestinationRegexColumnSpliter = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.ilGeneral = new System.Windows.Forms.ImageList(this.components);
            this.tabControl1.SuspendLayout();
            this.tabPage5.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.tabPage4.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.pDestinationOptions0.SuspendLayout();
            this.pDestinationOptions2.SuspendLayout();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tbtemplateBody
            // 
            this.tbtemplateBody.CaseSensitive = false;
            this.tbtemplateBody.DescriptorProccessMode = DamirM.Controls.SyntaxHighlightingTextBox.DescriptorProccessModes.ProccessBySeperarators;
            this.tbtemplateBody.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbtemplateBody.Location = new System.Drawing.Point(3, 3);
            this.tbtemplateBody.MaxLength = 0;
            this.tbtemplateBody.MaxUndoRedoSteps = 50;
            this.tbtemplateBody.Name = "tbtemplateBody";
            this.tbtemplateBody.Size = new System.Drawing.Size(1112, 440);
            this.tbtemplateBody.TabIndex = 0;
            this.tbtemplateBody.Text = "";
            this.tbtemplateBody.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tbtemplate_KeyDown);
            // 
            // bTemplateWork
            // 
            this.bTemplateWork.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.bTemplateWork.Location = new System.Drawing.Point(1047, 19);
            this.bTemplateWork.Name = "bTemplateWork";
            this.bTemplateWork.Size = new System.Drawing.Size(81, 28);
            this.bTemplateWork.TabIndex = 1;
            this.bTemplateWork.Text = "Work...";
            this.bTemplateWork.UseVisualStyleBackColor = true;
            this.bTemplateWork.Click += new System.EventHandler(this.bTemplateWork_Click);
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.AutoScroll = true;
            this.panel1.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.panel1.Location = new System.Drawing.Point(6, 19);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1035, 107);
            this.panel1.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(5, 33);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(55, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "File name:";
            // 
            // tbFileDestinationFile
            // 
            this.tbFileDestinationFile.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tbFileDestinationFile.CaseSensitive = false;
            this.tbFileDestinationFile.DescriptorProccessMode = DamirM.Controls.SyntaxHighlightingTextBox.DescriptorProccessModes.ProccessBySeperarators;
            this.tbFileDestinationFile.Location = new System.Drawing.Point(74, 30);
            this.tbFileDestinationFile.MaxUndoRedoSteps = 50;
            this.tbFileDestinationFile.Multiline = false;
            this.tbFileDestinationFile.Name = "tbFileDestinationFile";
            this.tbFileDestinationFile.Size = new System.Drawing.Size(509, 20);
            this.tbFileDestinationFile.TabIndex = 5;
            this.tbFileDestinationFile.Text = "name.txt";
            // 
            // btnLoad
            // 
            this.btnLoad.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnLoad.Location = new System.Drawing.Point(1048, 103);
            this.btnLoad.Name = "btnLoad";
            this.btnLoad.Size = new System.Drawing.Size(80, 23);
            this.btnLoad.TabIndex = 6;
            this.btnLoad.Text = "Load...";
            this.btnLoad.UseVisualStyleBackColor = true;
            this.btnLoad.Click += new System.EventHandler(this.btnLoad_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(5, 7);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(63, 13);
            this.label3.TabIndex = 7;
            this.label3.Text = "Destination:";
            // 
            // tbFileDestinationFolder
            // 
            this.tbFileDestinationFolder.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tbFileDestinationFolder.CaseSensitive = false;
            this.tbFileDestinationFolder.DescriptorProccessMode = DamirM.Controls.SyntaxHighlightingTextBox.DescriptorProccessModes.ProccessBySeperarators;
            this.tbFileDestinationFolder.Location = new System.Drawing.Point(74, 3);
            this.tbFileDestinationFolder.MaxUndoRedoSteps = 50;
            this.tbFileDestinationFolder.Multiline = false;
            this.tbFileDestinationFolder.Name = "tbFileDestinationFolder";
            this.tbFileDestinationFolder.Size = new System.Drawing.Size(741, 20);
            this.tbFileDestinationFolder.TabIndex = 8;
            this.tbFileDestinationFolder.Text = "c:\\";
            // 
            // btnBrowseFolder
            // 
            this.btnBrowseFolder.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnBrowseFolder.Location = new System.Drawing.Point(828, 3);
            this.btnBrowseFolder.Name = "btnBrowseFolder";
            this.btnBrowseFolder.Size = new System.Drawing.Size(75, 23);
            this.btnBrowseFolder.TabIndex = 9;
            this.btnBrowseFolder.Text = "Browse...";
            this.btnBrowseFolder.UseVisualStyleBackColor = true;
            this.btnBrowseFolder.Click += new System.EventHandler(this.btnBrowseFolder_Click);
            // 
            // chbDestinationFileAppend
            // 
            this.chbDestinationFileAppend.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.chbDestinationFileAppend.AutoSize = true;
            this.chbDestinationFileAppend.Location = new System.Drawing.Point(829, 37);
            this.chbDestinationFileAppend.Name = "chbDestinationFileAppend";
            this.chbDestinationFileAppend.Size = new System.Drawing.Size(63, 17);
            this.chbDestinationFileAppend.TabIndex = 11;
            this.chbDestinationFileAppend.Text = "Append";
            this.chbDestinationFileAppend.UseVisualStyleBackColor = true;
            // 
            // tabControl1
            // 
            this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl1.Controls.Add(this.tabPage5);
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Controls.Add(this.tabPage4);
            this.tabControl1.Location = new System.Drawing.Point(4, 87);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1126, 472);
            this.tabControl1.TabIndex = 19;
            // 
            // tabPage5
            // 
            this.tabPage5.Controls.Add(this.tbTemplateVariables);
            this.tabPage5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.tabPage5.Location = new System.Drawing.Point(4, 22);
            this.tabPage5.Name = "tabPage5";
            this.tabPage5.Size = new System.Drawing.Size(1118, 446);
            this.tabPage5.TabIndex = 4;
            this.tabPage5.Text = "Set variables";
            this.tabPage5.UseVisualStyleBackColor = true;
            // 
            // tbTemplateVariables
            // 
            this.tbTemplateVariables.CaseSensitive = false;
            this.tbTemplateVariables.DescriptorProccessMode = DamirM.Controls.SyntaxHighlightingTextBox.DescriptorProccessModes.ProccessBySeperarators;
            this.tbTemplateVariables.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbTemplateVariables.Location = new System.Drawing.Point(0, 0);
            this.tbTemplateVariables.MaxUndoRedoSteps = 50;
            this.tbTemplateVariables.Name = "tbTemplateVariables";
            this.tbTemplateVariables.Size = new System.Drawing.Size(1118, 446);
            this.tbTemplateVariables.TabIndex = 0;
            this.tbTemplateVariables.Text = "// This is a good place for a variable setting\n// During each passage, this part " +
                "is executed first";
            this.tbTemplateVariables.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tbtemplate_KeyDown);
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.tbtemplateBody);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(1118, 446);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Template body";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.tbtemplateHeader);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(1118, 446);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Template header";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // tbtemplateHeader
            // 
            this.tbtemplateHeader.CaseSensitive = false;
            this.tbtemplateHeader.DescriptorProccessMode = DamirM.Controls.SyntaxHighlightingTextBox.DescriptorProccessModes.ProccessBySeperarators;
            this.tbtemplateHeader.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbtemplateHeader.Location = new System.Drawing.Point(3, 3);
            this.tbtemplateHeader.MaxUndoRedoSteps = 50;
            this.tbtemplateHeader.Name = "tbtemplateHeader";
            this.tbtemplateHeader.Size = new System.Drawing.Size(1112, 440);
            this.tbtemplateHeader.TabIndex = 0;
            this.tbtemplateHeader.Text = "";
            this.tbtemplateHeader.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tbtemplate_KeyDown);
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.tbtemplateFooter);
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Size = new System.Drawing.Size(1118, 446);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Template footer";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // tbtemplateFooter
            // 
            this.tbtemplateFooter.CaseSensitive = false;
            this.tbtemplateFooter.DescriptorProccessMode = DamirM.Controls.SyntaxHighlightingTextBox.DescriptorProccessModes.ProccessBySeperarators;
            this.tbtemplateFooter.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbtemplateFooter.Location = new System.Drawing.Point(0, 0);
            this.tbtemplateFooter.MaxUndoRedoSteps = 50;
            this.tbtemplateFooter.Name = "tbtemplateFooter";
            this.tbtemplateFooter.Size = new System.Drawing.Size(1118, 446);
            this.tbtemplateFooter.TabIndex = 0;
            this.tbtemplateFooter.Text = "";
            this.tbtemplateFooter.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tbtemplate_KeyDown);
            // 
            // tabPage4
            // 
            this.tabPage4.Controls.Add(this.tbTemplateComment);
            this.tabPage4.Location = new System.Drawing.Point(4, 22);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage4.Size = new System.Drawing.Size(1118, 446);
            this.tabPage4.TabIndex = 3;
            this.tabPage4.Text = "Template info";
            this.tabPage4.UseVisualStyleBackColor = true;
            // 
            // tbTemplateComment
            // 
            this.tbTemplateComment.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbTemplateComment.Location = new System.Drawing.Point(3, 3);
            this.tbTemplateComment.Multiline = true;
            this.tbTemplateComment.Name = "tbTemplateComment";
            this.tbTemplateComment.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.tbTemplateComment.Size = new System.Drawing.Size(1112, 440);
            this.tbTemplateComment.TabIndex = 0;
            this.tbTemplateComment.Text = "Author:\r\nVersion:\r\nDate:\r\nPurpose:\r\n\r\nHow to use:";
            this.tbTemplateComment.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tbtemplate_KeyDown);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(63, 13);
            this.label1.TabIndex = 20;
            this.label1.Text = "Destination:";
            // 
            // cbDataDestination
            // 
            this.cbDataDestination.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbDataDestination.FormattingEnabled = true;
            this.cbDataDestination.Items.AddRange(new object[] {
            "File",
            "Notepad",
            "Data object"});
            this.cbDataDestination.Location = new System.Drawing.Point(66, 19);
            this.cbDataDestination.Name = "cbDataDestination";
            this.cbDataDestination.Size = new System.Drawing.Size(146, 21);
            this.cbDataDestination.TabIndex = 21;
            this.cbDataDestination.SelectedIndexChanged += new System.EventHandler(this.cbDataDestination_SelectedIndexChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.bTemplateWork);
            this.groupBox1.Controls.Add(this.panel1);
            this.groupBox1.Controls.Add(this.btnLoad);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1135, 132);
            this.groupBox1.TabIndex = 22;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Loaded data object";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.cbDataDestination);
            this.groupBox3.Controls.Add(this.label1);
            this.groupBox3.Controls.Add(this.pDestinationOptions0);
            this.groupBox3.Controls.Add(this.pDestinationOptions2);
            this.groupBox3.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox3.Location = new System.Drawing.Point(0, 0);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(1135, 77);
            this.groupBox3.TabIndex = 28;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Destination";
            // 
            // pDestinationOptions0
            // 
            this.pDestinationOptions0.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.pDestinationOptions0.Controls.Add(this.chbDestinationFileAppend);
            this.pDestinationOptions0.Controls.Add(this.label9);
            this.pDestinationOptions0.Controls.Add(this.tbFileDestinationFolder);
            this.pDestinationOptions0.Controls.Add(this.cbEncoding);
            this.pDestinationOptions0.Controls.Add(this.btnBrowseFolder);
            this.pDestinationOptions0.Controls.Add(this.label3);
            this.pDestinationOptions0.Controls.Add(this.tbFileDestinationFile);
            this.pDestinationOptions0.Controls.Add(this.label2);
            this.pDestinationOptions0.Location = new System.Drawing.Point(222, 12);
            this.pDestinationOptions0.Name = "pDestinationOptions0";
            this.pDestinationOptions0.Size = new System.Drawing.Size(906, 59);
            this.pDestinationOptions0.TabIndex = 29;
            // 
            // label9
            // 
            this.label9.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(589, 33);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(55, 13);
            this.label9.TabIndex = 23;
            this.label9.Text = "Encoding:";
            // 
            // cbEncoding
            // 
            this.cbEncoding.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cbEncoding.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbEncoding.FormattingEnabled = true;
            this.cbEncoding.Location = new System.Drawing.Point(649, 29);
            this.cbEncoding.Name = "cbEncoding";
            this.cbEncoding.Size = new System.Drawing.Size(166, 21);
            this.cbEncoding.TabIndex = 22;
            // 
            // pDestinationOptions2
            // 
            this.pDestinationOptions2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.pDestinationOptions2.Controls.Add(this.tbObjectDestinationRegexRowSpliter);
            this.pDestinationOptions2.Controls.Add(this.label10);
            this.pDestinationOptions2.Controls.Add(this.tbObjectDestinationRegexColumnSpliter);
            this.pDestinationOptions2.Controls.Add(this.label11);
            this.pDestinationOptions2.Location = new System.Drawing.Point(223, 13);
            this.pDestinationOptions2.Name = "pDestinationOptions2";
            this.pDestinationOptions2.Size = new System.Drawing.Size(905, 59);
            this.pDestinationOptions2.TabIndex = 30;
            this.pDestinationOptions2.Visible = false;
            // 
            // tbObjectDestinationRegexRowSpliter
            // 
            this.tbObjectDestinationRegexRowSpliter.Location = new System.Drawing.Point(104, 10);
            this.tbObjectDestinationRegexRowSpliter.Name = "tbObjectDestinationRegexRowSpliter";
            this.tbObjectDestinationRegexRowSpliter.Size = new System.Drawing.Size(88, 20);
            this.tbObjectDestinationRegexRowSpliter.TabIndex = 24;
            this.tbObjectDestinationRegexRowSpliter.Text = "\\r\\n";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(10, 14);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(91, 13);
            this.label10.TabIndex = 23;
            this.label10.Text = "Regex row spliter:";
            // 
            // tbObjectDestinationRegexColumnSpliter
            // 
            this.tbObjectDestinationRegexColumnSpliter.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tbObjectDestinationRegexColumnSpliter.Location = new System.Drawing.Point(312, 10);
            this.tbObjectDestinationRegexColumnSpliter.Name = "tbObjectDestinationRegexColumnSpliter";
            this.tbObjectDestinationRegexColumnSpliter.Size = new System.Drawing.Size(579, 20);
            this.tbObjectDestinationRegexColumnSpliter.TabIndex = 21;
            this.tbObjectDestinationRegexColumnSpliter.Text = "\\t";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(198, 13);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(108, 13);
            this.label11.TabIndex = 22;
            this.label11.Text = "Regex column spliter:";
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.groupBox1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.groupBox3);
            this.splitContainer1.Panel2.Controls.Add(this.tabControl1);
            this.splitContainer1.Size = new System.Drawing.Size(1135, 698);
            this.splitContainer1.SplitterDistance = 132;
            this.splitContainer1.TabIndex = 29;
            // 
            // ilGeneral
            // 
            this.ilGeneral.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("ilGeneral.ImageStream")));
            this.ilGeneral.TransparentColor = System.Drawing.Color.Transparent;
            this.ilGeneral.Images.SetKeyName(0, "folder");
            this.ilGeneral.Images.SetKeyName(1, "file");
            this.ilGeneral.Images.SetKeyName(2, "load");
            this.ilGeneral.Images.SetKeyName(3, "save");
            this.ilGeneral.Images.SetKeyName(4, "newfolder");
            this.ilGeneral.Images.SetKeyName(5, "delete");
            this.ilGeneral.Images.SetKeyName(6, "refresh");
            this.ilGeneral.Images.SetKeyName(7, "desktop");
            this.ilGeneral.Images.SetKeyName(8, "newfile");
            // 
            // ModuleMainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1135, 698);
            this.Controls.Add(this.splitContainer1);
            this.KeyPreview = true;
            this.Name = "ModuleMainForm";
            this.Text = "Generic tamplate";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ModuleMainForm_FormClosing);
            this.tabControl1.ResumeLayout(false);
            this.tabPage5.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.tabPage3.ResumeLayout(false);
            this.tabPage4.ResumeLayout(false);
            this.tabPage4.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.pDestinationOptions0.ResumeLayout(false);
            this.pDestinationOptions0.PerformLayout();
            this.pDestinationOptions2.ResumeLayout(false);
            this.pDestinationOptions2.PerformLayout();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private DamirM.Controls.SyntaxHighlightingTextBox tbtemplateBody;
        private System.Windows.Forms.Button bTemplateWork;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label2;
        private DamirM.Controls.SyntaxHighlightingTextBox tbFileDestinationFile;
        private System.Windows.Forms.Button btnLoad;
        private System.Windows.Forms.Label label3;
        private DamirM.Controls.SyntaxHighlightingTextBox tbFileDestinationFolder;
        private System.Windows.Forms.Button btnBrowseFolder;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private System.Windows.Forms.CheckBox chbDestinationFileAppend;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TabPage tabPage3;
        private DamirM.Controls.SyntaxHighlightingTextBox tbtemplateHeader;
        private DamirM.Controls.SyntaxHighlightingTextBox tbtemplateFooter;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cbDataDestination;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TabPage tabPage4;
        private System.Windows.Forms.TextBox tbTemplateComment;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.ComboBox cbEncoding;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TabPage tabPage5;
        //private System.Windows.Forms.TextBox tbTemplateVariables;
        private DamirM.Controls.SyntaxHighlightingTextBox tbTemplateVariables;
        private System.Windows.Forms.Panel pDestinationOptions0;
        private System.Windows.Forms.Panel pDestinationOptions2;
        private System.Windows.Forms.TextBox tbObjectDestinationRegexRowSpliter;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox tbObjectDestinationRegexColumnSpliter;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.ImageList ilGeneral;
    }
}