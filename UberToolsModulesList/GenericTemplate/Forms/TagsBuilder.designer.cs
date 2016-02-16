namespace UberTools.Modules.GenericTemplate.Forms
{
    partial class TagsBuilder
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
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.treeView1 = new System.Windows.Forms.TreeView();
            this.lblExample = new System.Windows.Forms.Label();
            this.lblResult = new System.Windows.Forms.Label();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.tbSyntax = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.pParametars = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.menuXMLEdit.SuspendLayout();
            this.groupBox1.SuspendLayout();
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
            // openFileDialog1
            // 
            this.openFileDialog1.Filter = "XML files|*.xml|All files|*.* ";
            // 
            // treeView1
            // 
            this.treeView1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)));
            this.treeView1.Location = new System.Drawing.Point(12, 51);
            this.treeView1.Name = "treeView1";
            this.treeView1.Size = new System.Drawing.Size(239, 358);
            this.treeView1.TabIndex = 3;
            this.treeView1.NodeMouseClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.treeView1_NodeMouseClick);
            // 
            // lblExample
            // 
            this.lblExample.AutoSize = true;
            this.lblExample.Location = new System.Drawing.Point(15, 25);
            this.lblExample.Name = "lblExample";
            this.lblExample.Size = new System.Drawing.Size(50, 13);
            this.lblExample.TabIndex = 5;
            this.lblExample.Text = "Example:";
            // 
            // lblResult
            // 
            this.lblResult.AutoSize = true;
            this.lblResult.Location = new System.Drawing.Point(15, 58);
            this.lblResult.Name = "lblResult";
            this.lblResult.Size = new System.Drawing.Size(40, 13);
            this.lblResult.TabIndex = 6;
            this.lblResult.Text = "Result:";
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
            // tbSyntax
            // 
            this.tbSyntax.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tbSyntax.Location = new System.Drawing.Point(12, 25);
            this.tbSyntax.Name = "tbSyntax";
            this.tbSyntax.Size = new System.Drawing.Size(700, 20);
            this.tbSyntax.TabIndex = 7;
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.pParametars);
            this.groupBox1.Controls.Add(this.lblExample);
            this.groupBox1.Controls.Add(this.lblResult);
            this.groupBox1.Location = new System.Drawing.Point(257, 51);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(455, 358);
            this.groupBox1.TabIndex = 8;
            this.groupBox1.TabStop = false;
            // 
            // pParametars
            // 
            this.pParametars.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.pParametars.Location = new System.Drawing.Point(7, 94);
            this.pParametars.Name = "pParametars";
            this.pParametars.Size = new System.Drawing.Size(442, 258);
            this.pParametars.TabIndex = 7;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(59, 13);
            this.label1.TabIndex = 9;
            this.label1.Text = "Tag syntax";
            // 
            // TagsBuilder
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(724, 421);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.tbSyntax);
            this.Controls.Add(this.treeView1);
            this.Name = "TagsBuilder";
            this.Text = "Tag builder (This form is deprecated)";
            this.menuXMLEdit.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.TreeView treeView1;
        private System.Windows.Forms.Label lblExample;
        private System.Windows.Forms.Label lblResult;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.ContextMenuStrip menuXMLEdit;
        private System.Windows.Forms.ToolStripMenuItem deleteToolStripMenuItem;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.TextBox tbSyntax;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel pParametars;
    }
}