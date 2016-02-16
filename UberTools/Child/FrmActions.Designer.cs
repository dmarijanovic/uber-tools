namespace NTHTools
{
    partial class FrmActions
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
            this.components = new System.ComponentModel.Container();
            this.menuXMLEdit = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.deleteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.txbFile = new System.Windows.Forms.TextBox();
            this.btnOpen = new System.Windows.Forms.Button();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.treeView1 = new System.Windows.Forms.TreeView();
            this.cmbGroup = new System.Windows.Forms.ComboBox();
            this.lblType = new System.Windows.Forms.Label();
            this.lblName = new System.Windows.Forms.Label();
            this.btnAction = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.menuXMLEdit.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuXMLEdit
            // 
            this.menuXMLEdit.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.deleteToolStripMenuItem});
            this.menuXMLEdit.Name = "menuXMLEdit";
            this.menuXMLEdit.Size = new System.Drawing.Size(117, 26);
            // 
            // deleteToolStripMenuItem
            // 
            this.deleteToolStripMenuItem.Name = "deleteToolStripMenuItem";
            this.deleteToolStripMenuItem.Size = new System.Drawing.Size(116, 22);
            this.deleteToolStripMenuItem.Text = "&Delete";
            // 
            // txbFile
            // 
            this.txbFile.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txbFile.Location = new System.Drawing.Point(32, 23);
            this.txbFile.Name = "txbFile";
            this.txbFile.Size = new System.Drawing.Size(599, 20);
            this.txbFile.TabIndex = 0;
            // 
            // btnOpen
            // 
            this.btnOpen.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOpen.Location = new System.Drawing.Point(637, 21);
            this.btnOpen.Name = "btnOpen";
            this.btnOpen.Size = new System.Drawing.Size(75, 23);
            this.btnOpen.TabIndex = 1;
            this.btnOpen.Text = "&Open";
            this.btnOpen.UseVisualStyleBackColor = true;
            this.btnOpen.Click += new System.EventHandler(this.btnOpen_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.Filter = "XML files|*.xml|All files|*.* ";
            // 
            // btnRefresh
            // 
            this.btnRefresh.Location = new System.Drawing.Point(32, 49);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(75, 23);
            this.btnRefresh.TabIndex = 2;
            this.btnRefresh.Text = "&Refresh";
            this.btnRefresh.UseVisualStyleBackColor = true;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // treeView1
            // 
            this.treeView1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)));
            this.treeView1.Location = new System.Drawing.Point(32, 78);
            this.treeView1.Name = "treeView1";
            this.treeView1.Size = new System.Drawing.Size(239, 331);
            this.treeView1.TabIndex = 3;
            this.treeView1.NodeMouseClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.treeView1_NodeMouseClick_1);
            // 
            // cmbGroup
            // 
            this.cmbGroup.FormattingEnabled = true;
            this.cmbGroup.Location = new System.Drawing.Point(301, 156);
            this.cmbGroup.Name = "cmbGroup";
            this.cmbGroup.Size = new System.Drawing.Size(222, 21);
            this.cmbGroup.TabIndex = 4;
            // 
            // lblType
            // 
            this.lblType.AutoSize = true;
            this.lblType.Location = new System.Drawing.Point(298, 94);
            this.lblType.Name = "lblType";
            this.lblType.Size = new System.Drawing.Size(31, 13);
            this.lblType.TabIndex = 5;
            this.lblType.Text = "Type";
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.Location = new System.Drawing.Point(300, 122);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(35, 13);
            this.lblName.TabIndex = 6;
            this.lblName.Text = "Name";
            // 
            // btnAction
            // 
            this.btnAction.Location = new System.Drawing.Point(533, 156);
            this.btnAction.Name = "btnAction";
            this.btnAction.Size = new System.Drawing.Size(75, 23);
            this.btnAction.TabIndex = 7;
            this.btnAction.Text = "&Rename";
            this.btnAction.UseVisualStyleBackColor = true;
            this.btnAction.Click += new System.EventHandler(this.btnAction_Click);
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(113, 49);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 8;
            this.btnSave.Text = "&Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // saveFileDialog1
            // 
            this.saveFileDialog1.Filter = "XML files|*.xml|All files|*.* ";
            // 
            // imageList1
            // 
            this.imageList1.ColorDepth = System.Windows.Forms.ColorDepth.Depth8Bit;
            this.imageList1.ImageSize = new System.Drawing.Size(16, 16);
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            // 
            // FrmActions
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(724, 421);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnAction);
            this.Controls.Add(this.lblName);
            this.Controls.Add(this.lblType);
            this.Controls.Add(this.cmbGroup);
            this.Controls.Add(this.treeView1);
            this.Controls.Add(this.btnRefresh);
            this.Controls.Add(this.btnOpen);
            this.Controls.Add(this.txbFile);
            this.Name = "FrmActions";
            this.Text = "SecT action.xml edit";
            this.menuXMLEdit.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txbFile;
        private System.Windows.Forms.Button btnOpen;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.TreeView treeView1;
        private System.Windows.Forms.ComboBox cmbGroup;
        private System.Windows.Forms.Label lblType;
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.Button btnAction;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.ContextMenuStrip menuXMLEdit;
        private System.Windows.Forms.ToolStripMenuItem deleteToolStripMenuItem;
        private System.Windows.Forms.ImageList imageList1;
    }
}