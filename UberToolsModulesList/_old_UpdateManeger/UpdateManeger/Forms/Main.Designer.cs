namespace UberTools.Plugin.UpdateManager.Forms
{
    partial class Main
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
            System.Windows.Forms.ListViewGroup listViewGroup3 = new System.Windows.Forms.ListViewGroup("Publish", System.Windows.Forms.HorizontalAlignment.Left);
            System.Windows.Forms.ListViewGroup listViewGroup4 = new System.Windows.Forms.ListViewGroup("Do not publish", System.Windows.Forms.HorizontalAlignment.Left);
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Main));
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.tvProductList = new System.Windows.Forms.TreeView();
            this.label1 = new System.Windows.Forms.Label();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.tvProjectFolders = new System.Windows.Forms.TreeView();
            this.lvProjectFiles = new System.Windows.Forms.ListView();
            this.columnHeader1 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader2 = new System.Windows.Forms.ColumnHeader();
            this.label2 = new System.Windows.Forms.Label();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.tsbConnect = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton2 = new System.Windows.Forms.ToolStripButton();
            this.tsbUpload = new System.Windows.Forms.ToolStripButton();
            this.tableLayoutPanel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.69742F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 83.30258F));
            this.tableLayoutPanel1.Controls.Add(this.tvProductList, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.label1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.splitContainer1, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.label2, 1, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1084, 584);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // tvProductList
            // 
            this.tvProductList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tvProductList.Location = new System.Drawing.Point(3, 28);
            this.tvProductList.Name = "tvProductList";
            this.tvProductList.Size = new System.Drawing.Size(175, 553);
            this.tvProductList.TabIndex = 0;
            this.tvProductList.NodeMouseDoubleClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.tvProductList_NodeMouseDoubleClick);
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 6);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(84, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Product browser";
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(184, 28);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.splitContainer2);
            this.splitContainer1.Panel2.Paint += new System.Windows.Forms.PaintEventHandler(this.splitContainer1_Panel2_Paint);
            this.splitContainer1.Size = new System.Drawing.Size(897, 553);
            this.splitContainer1.SplitterDistance = 158;
            this.splitContainer1.TabIndex = 2;
            // 
            // splitContainer2
            // 
            this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer2.Location = new System.Drawing.Point(0, 0);
            this.splitContainer2.Name = "splitContainer2";
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.Controls.Add(this.tvProjectFolders);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.lvProjectFiles);
            this.splitContainer2.Size = new System.Drawing.Size(897, 391);
            this.splitContainer2.SplitterDistance = 235;
            this.splitContainer2.TabIndex = 0;
            // 
            // tvProjectFolders
            // 
            this.tvProjectFolders.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tvProjectFolders.Location = new System.Drawing.Point(0, 0);
            this.tvProjectFolders.Name = "tvProjectFolders";
            this.tvProjectFolders.Size = new System.Drawing.Size(235, 391);
            this.tvProjectFolders.TabIndex = 0;
            this.tvProjectFolders.NodeMouseClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.tvProjectFolders_NodeMouseClick);
            // 
            // lvProjectFiles
            // 
            this.lvProjectFiles.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2});
            this.lvProjectFiles.Dock = System.Windows.Forms.DockStyle.Fill;
            listViewGroup3.Header = "Publish";
            listViewGroup3.Name = "lvgPublish";
            listViewGroup4.Header = "Do not publish";
            listViewGroup4.Name = "lvgDoNotPublish";
            this.lvProjectFiles.Groups.AddRange(new System.Windows.Forms.ListViewGroup[] {
            listViewGroup3,
            listViewGroup4});
            this.lvProjectFiles.Location = new System.Drawing.Point(0, 0);
            this.lvProjectFiles.Name = "lvProjectFiles";
            this.lvProjectFiles.Size = new System.Drawing.Size(658, 391);
            this.lvProjectFiles.TabIndex = 0;
            this.lvProjectFiles.UseCompatibleStateImageBehavior = false;
            this.lvProjectFiles.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Name";
            this.columnHeader1.Width = 100;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Path";
            this.columnHeader2.Width = 200;
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(184, 6);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(83, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Product settings";
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsbConnect,
            this.toolStripButton2,
            this.tsbUpload});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(1084, 25);
            this.toolStrip1.TabIndex = 1;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // tsbConnect
            // 
            this.tsbConnect.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbConnect.Image = ((System.Drawing.Image)(resources.GetObject("tsbConnect.Image")));
            this.tsbConnect.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbConnect.Name = "tsbConnect";
            this.tsbConnect.Size = new System.Drawing.Size(23, 22);
            this.tsbConnect.Text = "Connect...";
            this.tsbConnect.Click += new System.EventHandler(this.tsbConnect_Click);
            // 
            // toolStripButton2
            // 
            this.toolStripButton2.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton2.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton2.Image")));
            this.toolStripButton2.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton2.Name = "toolStripButton2";
            this.toolStripButton2.Size = new System.Drawing.Size(23, 22);
            this.toolStripButton2.Text = "Add product";
            // 
            // tsbUpload
            // 
            this.tsbUpload.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbUpload.Image = ((System.Drawing.Image)(resources.GetObject("tsbUpload.Image")));
            this.tsbUpload.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbUpload.Name = "tsbUpload";
            this.tsbUpload.Size = new System.Drawing.Size(23, 22);
            this.tsbUpload.Text = "Upload";
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1084, 584);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "Main";
            this.Text = "Update Manager";
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.ResumeLayout(false);
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel2.ResumeLayout(false);
            this.splitContainer2.ResumeLayout(false);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.TreeView tvProductList;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private System.Windows.Forms.TreeView tvProjectFolders;
        private System.Windows.Forms.ListView lvProjectFiles;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton tsbConnect;
        private System.Windows.Forms.ToolStripButton toolStripButton2;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ToolStripButton tsbUpload;
    }
}