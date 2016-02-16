namespace DamirM.Controls
{
    partial class TagControl
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
            this.tbValue = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // lName
            // 
            this.lName.AutoSize = true;
            this.lName.Location = new System.Drawing.Point(3, 8);
            this.lName.Name = "lName";
            this.lName.Size = new System.Drawing.Size(35, 13);
            this.lName.TabIndex = 0;
            this.lName.Text = "Name";
            // 
            // tbValue
            // 
            this.tbValue.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tbValue.Location = new System.Drawing.Point(95, 5);
            this.tbValue.Name = "tbValue";
            this.tbValue.Size = new System.Drawing.Size(329, 20);
            this.tbValue.TabIndex = 1;
            // 
            // TagControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tbValue);
            this.Controls.Add(this.lName);
            this.Name = "TagControl";
            this.Size = new System.Drawing.Size(427, 31);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lName;
        private System.Windows.Forms.TextBox tbValue;
    }
}
