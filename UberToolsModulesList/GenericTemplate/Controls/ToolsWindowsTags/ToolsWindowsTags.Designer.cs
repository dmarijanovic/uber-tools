namespace UberTools.Modules.GenericTemplate.Controls
{
    partial class ToolsWindowsTags
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
            this.windowsToolsTop1 = new DamirM.CommonLibrary.WindowsToolsTop();
            this.tvTags = new System.Windows.Forms.TreeView();
            this.SuspendLayout();
            // 
            // windowsToolsTop1
            // 
            this.windowsToolsTop1.ActiveColor = System.Drawing.SystemColors.ActiveCaption;
            this.windowsToolsTop1.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.windowsToolsTop1.Caption = "Tags";
            this.windowsToolsTop1.Dock = System.Windows.Forms.DockStyle.Top;
            this.windowsToolsTop1.InactiveColor = System.Drawing.SystemColors.InactiveCaption;
            this.windowsToolsTop1.Location = new System.Drawing.Point(0, 0);
            this.windowsToolsTop1.MaximumSize = new System.Drawing.Size(300, 20);
            this.windowsToolsTop1.MinimumSize = new System.Drawing.Size(150, 20);
            this.windowsToolsTop1.Name = "windowsToolsTop1";
            this.windowsToolsTop1.Size = new System.Drawing.Size(196, 20);
            this.windowsToolsTop1.TabIndex = 0;
            // 
            // tvTags
            // 
            this.tvTags.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tvTags.Location = new System.Drawing.Point(0, 20);
            this.tvTags.Name = "tvTags";
            this.tvTags.ShowNodeToolTips = true;
            this.tvTags.Size = new System.Drawing.Size(196, 328);
            this.tvTags.TabIndex = 1;
            this.tvTags.NodeMouseDoubleClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.tvTags_NodeMouseDoubleClick);
            // 
            // ToolsWindowsTags
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tvTags);
            this.Controls.Add(this.windowsToolsTop1);
            this.Name = "ToolsWindowsTags";
            this.Size = new System.Drawing.Size(196, 348);
            this.ResumeLayout(false);

        }

        #endregion

        private DamirM.CommonLibrary.WindowsToolsTop windowsToolsTop1;
        private System.Windows.Forms.TreeView tvTags;
    }
}
