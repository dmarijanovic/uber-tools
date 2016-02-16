namespace UberTools.Modules.GenericTemplate.Controls
{
    partial class ToolsWindowsTagsInput
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
            this.gbBox = new System.Windows.Forms.GroupBox();
            this.lDescription = new System.Windows.Forms.Label();
            this.bCancel = new System.Windows.Forms.Button();
            this.bOK = new System.Windows.Forms.Button();
            this.pPropertyBox = new System.Windows.Forms.Panel();
            this.gbBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // gbBox
            // 
            this.gbBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.gbBox.Controls.Add(this.pPropertyBox);
            this.gbBox.Controls.Add(this.lDescription);
            this.gbBox.Location = new System.Drawing.Point(3, 2);
            this.gbBox.Name = "gbBox";
            this.gbBox.Size = new System.Drawing.Size(569, 303);
            this.gbBox.TabIndex = 0;
            this.gbBox.TabStop = false;
            this.gbBox.Text = "tag name";
            // 
            // lDescription
            // 
            this.lDescription.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lDescription.Location = new System.Drawing.Point(7, 20);
            this.lDescription.Name = "lDescription";
            this.lDescription.Size = new System.Drawing.Size(555, 41);
            this.lDescription.TabIndex = 0;
            this.lDescription.Text = "tags description";
            // 
            // bCancel
            // 
            this.bCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.bCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.bCancel.Location = new System.Drawing.Point(497, 311);
            this.bCancel.Name = "bCancel";
            this.bCancel.Size = new System.Drawing.Size(75, 23);
            this.bCancel.TabIndex = 1;
            this.bCancel.Text = "&Cancel";
            this.bCancel.UseVisualStyleBackColor = true;
            // 
            // bOK
            // 
            this.bOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.bOK.Location = new System.Drawing.Point(416, 311);
            this.bOK.Name = "bOK";
            this.bOK.Size = new System.Drawing.Size(75, 23);
            this.bOK.TabIndex = 2;
            this.bOK.Text = "&OK";
            this.bOK.UseVisualStyleBackColor = true;
            this.bOK.Click += new System.EventHandler(this.bOK_Click);
            // 
            // pPropertyBox
            // 
            this.pPropertyBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.pPropertyBox.AutoSize = true;
            this.pPropertyBox.Location = new System.Drawing.Point(0, 64);
            this.pPropertyBox.Name = "pPropertyBox";
            this.pPropertyBox.Size = new System.Drawing.Size(569, 239);
            this.pPropertyBox.TabIndex = 1;
            // 
            // ToolsWindowsTagsInput
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.bCancel;
            this.ClientSize = new System.Drawing.Size(577, 340);
            this.Controls.Add(this.bOK);
            this.Controls.Add(this.bCancel);
            this.Controls.Add(this.gbBox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "ToolsWindowsTagsInput";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Tags input box";
            this.gbBox.ResumeLayout(false);
            this.gbBox.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gbBox;
        private System.Windows.Forms.Button bCancel;
        private System.Windows.Forms.Button bOK;
        private System.Windows.Forms.Label lDescription;
        private System.Windows.Forms.Panel pPropertyBox;
    }
}