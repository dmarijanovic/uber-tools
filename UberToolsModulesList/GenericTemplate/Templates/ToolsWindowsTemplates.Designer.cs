namespace UberTools.Modules.GenericTemplate.Controls
{
    partial class ToolsWindowsTemplates
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ToolsWindowsTemplates));
            this.tvTree = new System.Windows.Forms.TreeView();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.tsbLoad = new System.Windows.Forms.ToolStripButton();
            this.tsbSave = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.tsbNewFolder = new System.Windows.Forms.ToolStripButton();
            this.tsbDelete = new System.Windows.Forms.ToolStripButton();
            this.tsbRefresh = new System.Windows.Forms.ToolStripButton();
            this.windowsToolsTop1 = new DamirM.CommonLibrary.WindowsToolsTop();
            this.tsbNew = new System.Windows.Forms.ToolStripButton();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tvTree
            // 
            this.tvTree.AllowDrop = true;
            this.tvTree.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tvTree.HideSelection = false;
            this.tvTree.Location = new System.Drawing.Point(0, 45);
            this.tvTree.Name = "tvTree";
            this.tvTree.Size = new System.Drawing.Size(180, 383);
            this.tvTree.TabIndex = 2;
            this.tvTree.NodeMouseDoubleClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.tvTree_NodeMouseDoubleClick);
            this.tvTree.DragDrop += new System.Windows.Forms.DragEventHandler(this.tvTree_DragDrop);
            this.tvTree.MouseDown += new System.Windows.Forms.MouseEventHandler(this.tvTree_MouseDown);
            this.tvTree.DragOver += new System.Windows.Forms.DragEventHandler(this.tvTree_DragOver);
            this.tvTree.Click += new System.EventHandler(this.tvTree_Click);
            // 
            // toolStrip1
            // 
            this.toolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsbNew,
            this.tsbLoad,
            this.tsbSave,
            this.toolStripSeparator1,
            this.tsbNewFolder,
            this.tsbDelete,
            this.tsbRefresh});
            this.toolStrip1.Location = new System.Drawing.Point(0, 20);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(180, 25);
            this.toolStrip1.TabIndex = 3;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // tsbLoad
            // 
            this.tsbLoad.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbLoad.Image = ((System.Drawing.Image)(resources.GetObject("tsbLoad.Image")));
            this.tsbLoad.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbLoad.Name = "tsbLoad";
            this.tsbLoad.Size = new System.Drawing.Size(23, 22);
            this.tsbLoad.Text = "Load...";
            this.tsbLoad.Click += new System.EventHandler(this.tsbLoad_Click);
            // 
            // tsbSave
            // 
            this.tsbSave.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbSave.Image = ((System.Drawing.Image)(resources.GetObject("tsbSave.Image")));
            this.tsbSave.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbSave.Name = "tsbSave";
            this.tsbSave.Size = new System.Drawing.Size(23, 22);
            this.tsbSave.Text = "Save...";
            this.tsbSave.Click += new System.EventHandler(this.tsbSave_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // tsbNewFolder
            // 
            this.tsbNewFolder.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbNewFolder.Image = ((System.Drawing.Image)(resources.GetObject("tsbNewFolder.Image")));
            this.tsbNewFolder.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbNewFolder.Name = "tsbNewFolder";
            this.tsbNewFolder.Size = new System.Drawing.Size(23, 22);
            this.tsbNewFolder.Text = "New folder...";
            this.tsbNewFolder.Click += new System.EventHandler(this.tsbNewFolder_Click);
            // 
            // tsbDelete
            // 
            this.tsbDelete.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbDelete.Image = ((System.Drawing.Image)(resources.GetObject("tsbDelete.Image")));
            this.tsbDelete.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbDelete.Name = "tsbDelete";
            this.tsbDelete.Size = new System.Drawing.Size(23, 22);
            this.tsbDelete.Text = "Delete...";
            this.tsbDelete.Click += new System.EventHandler(this.tsbDelete_Click);
            // 
            // tsbRefresh
            // 
            this.tsbRefresh.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbRefresh.Image = ((System.Drawing.Image)(resources.GetObject("tsbRefresh.Image")));
            this.tsbRefresh.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbRefresh.Name = "tsbRefresh";
            this.tsbRefresh.Size = new System.Drawing.Size(23, 22);
            this.tsbRefresh.Text = "Refresh";
            this.tsbRefresh.Click += new System.EventHandler(this.tsbRefresh_Click);
            // 
            // windowsToolsTop1
            // 
            this.windowsToolsTop1.ActiveColor = System.Drawing.SystemColors.ActiveCaption;
            this.windowsToolsTop1.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.windowsToolsTop1.Caption = "Templates";
            this.windowsToolsTop1.Dock = System.Windows.Forms.DockStyle.Top;
            this.windowsToolsTop1.InactiveColor = System.Drawing.SystemColors.InactiveCaption;
            this.windowsToolsTop1.Location = new System.Drawing.Point(0, 0);
            this.windowsToolsTop1.MaximumSize = new System.Drawing.Size(300, 20);
            this.windowsToolsTop1.MinimumSize = new System.Drawing.Size(150, 20);
            this.windowsToolsTop1.Name = "windowsToolsTop1";
            this.windowsToolsTop1.Size = new System.Drawing.Size(180, 20);
            this.windowsToolsTop1.TabIndex = 4;
            // 
            // tsbNew
            // 
            this.tsbNew.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbNew.Image = ((System.Drawing.Image)(resources.GetObject("tsbNew.Image")));
            this.tsbNew.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbNew.Margin = new System.Windows.Forms.Padding(2, 1, 0, 2);
            this.tsbNew.Name = "tsbNew";
            this.tsbNew.Size = new System.Drawing.Size(23, 22);
            this.tsbNew.Text = "New";
            this.tsbNew.Click += new System.EventHandler(this.tsbNew_Click);
            // 
            // ToolsWindowsTemplates
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tvTree);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.windowsToolsTop1);
            this.Name = "ToolsWindowsTemplates";
            this.Size = new System.Drawing.Size(180, 428);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TreeView tvTree;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton tsbLoad;
        private System.Windows.Forms.ToolStripButton tsbSave;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton tsbNewFolder;
        private System.Windows.Forms.ToolStripButton tsbDelete;
        private System.Windows.Forms.ToolStripButton tsbRefresh;
        private DamirM.CommonLibrary.WindowsToolsTop windowsToolsTop1;
        private System.Windows.Forms.ToolStripButton tsbNew;
    }
}
