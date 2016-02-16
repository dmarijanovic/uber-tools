namespace UberTools.Modules.GenericTemplate.Controls
{
    partial class ToolsWindowsTagsParams
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.lName = new System.Windows.Forms.Label();
            this.tbText = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // lName
            // 
            this.lName.AutoSize = true;
            this.lName.Location = new System.Drawing.Point(14, 10);
            this.lName.Name = "lName";
            this.lName.Size = new System.Drawing.Size(33, 13);
            this.lName.TabIndex = 0;
            this.lName.Text = "name";
            // 
            // tbText
            // 
            this.tbText.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tbText.Location = new System.Drawing.Point(94, 7);
            this.tbText.Name = "tbText";
            this.tbText.Size = new System.Drawing.Size(393, 20);
            this.tbText.TabIndex = 1;
            // 
            // ToolsWindowsTagsParams
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tbText);
            this.Controls.Add(this.lName);
            this.Name = "ToolsWindowsTagsParams";
            this.Size = new System.Drawing.Size(490, 30);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lName;
        public System.Windows.Forms.TextBox tbText;
    }
}
