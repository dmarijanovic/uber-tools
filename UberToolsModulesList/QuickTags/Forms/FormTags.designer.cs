namespace UberTools.Modules.QuickTags.Forms
{
    partial class FormTags
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
            this.btnSearch = new System.Windows.Forms.Button();
            this.txtSearchBoxAnd = new System.Windows.Forms.TextBox();
            this.txtSearchBox = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgwPanel)).BeginInit();
            this.SuspendLayout();
            // 
            // dgwPanel
            // 
            this.dgwPanel.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgwPanel.Location = new System.Drawing.Point(5, 76);
            this.dgwPanel.Name = "dgwPanel";
            this.dgwPanel.Size = new System.Drawing.Size(833, 335);
            this.dgwPanel.TabIndex = 1;
            // 
            // btnSearch
            // 
            this.btnSearch.Location = new System.Drawing.Point(763, 12);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(75, 58);
            this.btnSearch.TabIndex = 2;
            this.btnSearch.Text = "&Search";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // txtSearchBoxAnd
            // 
            this.txtSearchBoxAnd.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.txtSearchBoxAnd.Location = new System.Drawing.Point(5, 44);
            this.txtSearchBoxAnd.Name = "txtSearchBoxAnd";
            this.txtSearchBoxAnd.Size = new System.Drawing.Size(752, 26);
            this.txtSearchBoxAnd.TabIndex = 4;
            // 
            // txtSearchBox
            // 
            this.txtSearchBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.txtSearchBox.Location = new System.Drawing.Point(5, 12);
            this.txtSearchBox.Name = "txtSearchBox";
            this.txtSearchBox.Size = new System.Drawing.Size(752, 26);
            this.txtSearchBox.TabIndex = 0;
            this.txtSearchBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtSearchBox_KeyDown);
            // 
            // FormTags
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(850, 420);
            this.ControlBox = false;
            this.Controls.Add(this.txtSearchBoxAnd);
            this.Controls.Add(this.btnSearch);
            this.Controls.Add(this.dgwPanel);
            this.Controls.Add(this.txtSearchBox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.KeyPreview = true;
            this.Location = new System.Drawing.Point(500, 0);
            this.Name = "FormTags";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "Tags";
            this.TopMost = true;
            this.Activated += new System.EventHandler(this.FormTags_Activated);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Tags_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.dgwPanel)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgwPanel;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.TextBox txtSearchBoxAnd;
        private System.Windows.Forms.TextBox txtSearchBox;
    }
}