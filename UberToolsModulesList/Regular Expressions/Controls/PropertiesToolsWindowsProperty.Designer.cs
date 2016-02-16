namespace UberTools.Modules.RegularExpressions
{
    partial class PropertiesToolsWindowsProperty
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
            this.tbText = new System.Windows.Forms.TextBox();
            this.cbValue = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // tbText
            // 
            this.tbText.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tbText.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tbText.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.tbText.Location = new System.Drawing.Point(89, 3);
            this.tbText.Name = "tbText";
            this.tbText.Size = new System.Drawing.Size(168, 13);
            this.tbText.TabIndex = 1;
            this.tbText.Visible = false;
            this.tbText.TextChanged += new System.EventHandler(this.tbText_TextChanged);
            // 
            // cbValue
            // 
            this.cbValue.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.cbValue.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbValue.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cbValue.FormattingEnabled = true;
            this.cbValue.Location = new System.Drawing.Point(90, 0);
            this.cbValue.Name = "cbValue";
            this.cbValue.Size = new System.Drawing.Size(168, 21);
            this.cbValue.TabIndex = 2;
            this.cbValue.Visible = false;
            this.cbValue.SelectedIndexChanged += new System.EventHandler(this.cbValue_SelectedIndexChanged);
            // 
            // PropertiesToolsWindowsPart
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.Controls.Add(this.tbText);
            this.Controls.Add(this.cbValue);
            this.Name = "PropertiesToolsWindowsPart";
            this.Size = new System.Drawing.Size(257, 19);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.PropertiesToolsWindowsPart_Paint);
            this.Leave += new System.EventHandler(this.PropertiesToolsWindowsPart_Leave);
            this.Enter += new System.EventHandler(this.PropertiesToolsWindowsPart_Enter);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox tbText;
        private System.Windows.Forms.ComboBox cbValue;
    }
}
