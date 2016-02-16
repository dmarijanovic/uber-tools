namespace UberTools.Modules.RegularExpressions
{
    partial class PropertiesToolsWindows
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
            this.windowsToolsTop = new DamirM.CommonLibrary.WindowsToolsTop();
            this.pPanel = new System.Windows.Forms.Panel();
            this.SuspendLayout();
            // 
            // windowsToolsTop
            // 
            this.windowsToolsTop.ActiveColor = System.Drawing.SystemColors.ActiveCaption;
            this.windowsToolsTop.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.windowsToolsTop.Caption = "Tool Windows name";
            this.windowsToolsTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.windowsToolsTop.InactiveColor = System.Drawing.SystemColors.InactiveCaption;
            this.windowsToolsTop.Location = new System.Drawing.Point(0, 0);
            this.windowsToolsTop.MaximumSize = new System.Drawing.Size(300, 20);
            this.windowsToolsTop.MinimumSize = new System.Drawing.Size(150, 20);
            this.windowsToolsTop.Name = "windowsToolsTop";
            this.windowsToolsTop.Size = new System.Drawing.Size(193, 20);
            this.windowsToolsTop.TabIndex = 0;
            // 
            // pPanel
            // 
            this.pPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.pPanel.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.pPanel.Location = new System.Drawing.Point(0, 20);
            this.pPanel.Name = "pPanel";
            this.pPanel.Size = new System.Drawing.Size(193, 255);
            this.pPanel.TabIndex = 1;
            // 
            // PropertiesToolsWindows
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.pPanel);
            this.Controls.Add(this.windowsToolsTop);
            this.Name = "PropertiesToolsWindows";
            this.Size = new System.Drawing.Size(193, 275);
            this.ResumeLayout(false);

        }

        #endregion

        private DamirM.CommonLibrary.WindowsToolsTop windowsToolsTop;
        private System.Windows.Forms.Panel pPanel;
    }
}
