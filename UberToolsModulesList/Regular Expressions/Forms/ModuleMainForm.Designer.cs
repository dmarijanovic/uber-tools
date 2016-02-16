namespace UberTools.Modules.RegularExpressions.Forms
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
            this.tbRegEx = new System.Windows.Forms.TextBox();
            this.tbText = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.tbResult = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // tbRegEx
            // 
            this.tbRegEx.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tbRegEx.Location = new System.Drawing.Point(12, 29);
            this.tbRegEx.Multiline = true;
            this.tbRegEx.Name = "tbRegEx";
            this.tbRegEx.Size = new System.Drawing.Size(1089, 101);
            this.tbRegEx.TabIndex = 0;
            this.tbRegEx.KeyUp += new System.Windows.Forms.KeyEventHandler(this.textChange_KeyUp);
            // 
            // tbText
            // 
            this.tbText.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tbText.Location = new System.Drawing.Point(12, 173);
            this.tbText.Multiline = true;
            this.tbText.Name = "tbText";
            this.tbText.Size = new System.Drawing.Size(1089, 173);
            this.tbText.TabIndex = 1;
            this.tbText.KeyUp += new System.Windows.Forms.KeyEventHandler(this.textChange_KeyUp);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(103, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Regular Expressions";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(9, 143);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(28, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Text";
            // 
            // button1
            // 
            this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.button1.Location = new System.Drawing.Point(1026, 618);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 4;
            this.button1.Text = "&Exit";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // tbResult
            // 
            this.tbResult.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tbResult.Location = new System.Drawing.Point(12, 383);
            this.tbResult.Multiline = true;
            this.tbResult.Name = "tbResult";
            this.tbResult.ReadOnly = true;
            this.tbResult.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.tbResult.Size = new System.Drawing.Size(1089, 229);
            this.tbResult.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(9, 363);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(37, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "Result";
            // 
            // ModuleMainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1113, 650);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.tbResult);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tbText);
            this.Controls.Add(this.tbRegEx);
            this.Name = "ModuleMainForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Text = "Regular Expressions Tester";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox tbRegEx;
        private System.Windows.Forms.TextBox tbText;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox tbResult;
        private System.Windows.Forms.Label label3;
    }
}