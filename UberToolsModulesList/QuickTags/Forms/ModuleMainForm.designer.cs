namespace UberTools.Modules.QuickTags.Forms
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
            this.dgwPanel = new System.Windows.Forms.DataGridView();
            this.btnAddTags = new System.Windows.Forms.Button();
            this.btnAddText = new System.Windows.Forms.Button();
            this.txtSearchBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnShowTags = new System.Windows.Forms.Button();
            this.rbShowTags = new System.Windows.Forms.RadioButton();
            this.rbShowTexts = new System.Windows.Forms.RadioButton();
            this.btnExport = new System.Windows.Forms.Button();
            this.btnImport = new System.Windows.Forms.Button();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.btnSettings = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgwPanel)).BeginInit();
            this.SuspendLayout();
            // 
            // dgwPanel
            // 
            this.dgwPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dgwPanel.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgwPanel.Location = new System.Drawing.Point(12, 118);
            this.dgwPanel.Name = "dgwPanel";
            this.dgwPanel.Size = new System.Drawing.Size(579, 342);
            this.dgwPanel.TabIndex = 0;
            this.dgwPanel.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgwPanel_CellContentClick);
            // 
            // btnAddTags
            // 
            this.btnAddTags.Location = new System.Drawing.Point(13, 13);
            this.btnAddTags.Name = "btnAddTags";
            this.btnAddTags.Size = new System.Drawing.Size(75, 23);
            this.btnAddTags.TabIndex = 1;
            this.btnAddTags.Text = "Add tags";
            this.btnAddTags.UseVisualStyleBackColor = true;
            this.btnAddTags.Click += new System.EventHandler(this.btnAddTags_Click);
            // 
            // btnAddText
            // 
            this.btnAddText.Location = new System.Drawing.Point(95, 13);
            this.btnAddText.Name = "btnAddText";
            this.btnAddText.Size = new System.Drawing.Size(75, 23);
            this.btnAddText.TabIndex = 2;
            this.btnAddText.Text = "Add text";
            this.btnAddText.UseVisualStyleBackColor = true;
            this.btnAddText.Click += new System.EventHandler(this.btnAddText_Click);
            // 
            // txtSearchBox
            // 
            this.txtSearchBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtSearchBox.Location = new System.Drawing.Point(69, 53);
            this.txtSearchBox.Name = "txtSearchBox";
            this.txtSearchBox.Size = new System.Drawing.Size(441, 20);
            this.txtSearchBox.TabIndex = 3;
            this.txtSearchBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtSearchBox_KeyDown);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 56);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Search";
            // 
            // btnShowTags
            // 
            this.btnShowTags.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnShowTags.Location = new System.Drawing.Point(516, 51);
            this.btnShowTags.Name = "btnShowTags";
            this.btnShowTags.Size = new System.Drawing.Size(75, 23);
            this.btnShowTags.TabIndex = 5;
            this.btnShowTags.Text = "Show";
            this.btnShowTags.UseVisualStyleBackColor = true;
            this.btnShowTags.Click += new System.EventHandler(this.btnShowTags_Click);
            // 
            // rbShowTags
            // 
            this.rbShowTags.AutoSize = true;
            this.rbShowTags.Checked = true;
            this.rbShowTags.Location = new System.Drawing.Point(12, 95);
            this.rbShowTags.Name = "rbShowTags";
            this.rbShowTags.Size = new System.Drawing.Size(49, 17);
            this.rbShowTags.TabIndex = 6;
            this.rbShowTags.TabStop = true;
            this.rbShowTags.Text = "Tags";
            this.rbShowTags.UseVisualStyleBackColor = true;
            // 
            // rbShowTexts
            // 
            this.rbShowTexts.AutoSize = true;
            this.rbShowTexts.Location = new System.Drawing.Point(103, 95);
            this.rbShowTexts.Name = "rbShowTexts";
            this.rbShowTexts.Size = new System.Drawing.Size(51, 17);
            this.rbShowTexts.TabIndex = 7;
            this.rbShowTexts.Text = "Texts";
            this.rbShowTexts.UseVisualStyleBackColor = true;
            // 
            // btnExport
            // 
            this.btnExport.Location = new System.Drawing.Point(257, 12);
            this.btnExport.Name = "btnExport";
            this.btnExport.Size = new System.Drawing.Size(75, 23);
            this.btnExport.TabIndex = 8;
            this.btnExport.Text = "Export csv";
            this.btnExport.UseVisualStyleBackColor = true;
            this.btnExport.Click += new System.EventHandler(this.btnExport_Click);
            // 
            // btnImport
            // 
            this.btnImport.Location = new System.Drawing.Point(176, 13);
            this.btnImport.Name = "btnImport";
            this.btnImport.Size = new System.Drawing.Size(75, 23);
            this.btnImport.TabIndex = 9;
            this.btnImport.Text = "Import csv";
            this.btnImport.UseVisualStyleBackColor = true;
            this.btnImport.Click += new System.EventHandler(this.btnImport_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // btnSettings
            // 
            this.btnSettings.Location = new System.Drawing.Point(339, 12);
            this.btnSettings.Name = "btnSettings";
            this.btnSettings.Size = new System.Drawing.Size(75, 23);
            this.btnSettings.TabIndex = 10;
            this.btnSettings.Text = "Settings";
            this.btnSettings.UseVisualStyleBackColor = true;
            this.btnSettings.Click += new System.EventHandler(this.btnSettings_Click);
            // 
            // FormTagsMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(599, 472);
            this.Controls.Add(this.btnSettings);
            this.Controls.Add(this.btnImport);
            this.Controls.Add(this.btnExport);
            this.Controls.Add(this.rbShowTexts);
            this.Controls.Add(this.rbShowTags);
            this.Controls.Add(this.btnShowTags);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtSearchBox);
            this.Controls.Add(this.btnAddText);
            this.Controls.Add(this.btnAddTags);
            this.Controls.Add(this.dgwPanel);
            this.Name = "FormTagsMain";
            this.Text = "Tags";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FormTagsMain_FormClosed);
            ((System.ComponentModel.ISupportInitialize)(this.dgwPanel)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgwPanel;
        private System.Windows.Forms.Button btnAddTags;
        private System.Windows.Forms.Button btnAddText;
        private System.Windows.Forms.TextBox txtSearchBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnShowTags;
        private System.Windows.Forms.RadioButton rbShowTags;
        private System.Windows.Forms.RadioButton rbShowTexts;
        private System.Windows.Forms.Button btnExport;
        private System.Windows.Forms.Button btnImport;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.Button btnSettings;
    }
}