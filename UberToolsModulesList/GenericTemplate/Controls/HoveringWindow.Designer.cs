namespace UberTools.Plugin.TemplatesFiller.Controls
{
    partial class HoveringWindow
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
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.TreeNode treeNode1 = new System.Windows.Forms.TreeNode("Loading...");
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(HoveringWindow));
            this.tvList = new System.Windows.Forms.TreeView();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.SuspendLayout();
            // 
            // tvList
            // 
            this.tvList.BackColor = System.Drawing.SystemColors.Info;
            this.tvList.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tvList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tvList.FullRowSelect = true;
            this.tvList.HideSelection = false;
            this.tvList.Indent = 15;
            this.tvList.ItemHeight = 16;
            this.tvList.Location = new System.Drawing.Point(2, 2);
            this.tvList.Name = "tvList";
            treeNode1.ImageIndex = 0;
            treeNode1.Name = "Node0";
            treeNode1.Text = "Loading...";
            this.tvList.Nodes.AddRange(new System.Windows.Forms.TreeNode[] {
            treeNode1});
            this.tvList.ShowLines = false;
            this.tvList.ShowRootLines = false;
            this.tvList.Size = new System.Drawing.Size(184, 86);
            this.tvList.StateImageList = this.imageList1;
            this.tvList.TabIndex = 1;
            this.tvList.DoubleClick += new System.EventHandler(this.tvList_DoubleClick);
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "object_32.png");
            // 
            // HoveringWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tvList);
            this.Name = "HoveringWindow";
            this.Padding = new System.Windows.Forms.Padding(2);
            this.Size = new System.Drawing.Size(188, 90);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TreeView tvList;
        private System.Windows.Forms.ImageList imageList1;

    }
}
