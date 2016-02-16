namespace UberTools.Modules.GenericTemplate.RowCollectionNS
{
    partial class RowCollection
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
            this.lblname = new System.Windows.Forms.Label();
            this.btnShow = new System.Windows.Forms.Button();
            this.cbUseIt = new System.Windows.Forms.CheckBox();
            this.tbStartAt = new System.Windows.Forms.TextBox();
            this.tbIncrement = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.tbEndAt = new System.Windows.Forms.TextBox();
            this.bUnload = new System.Windows.Forms.Button();
            this.lObjectName = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.cbLock = new System.Windows.Forms.CheckBox();
            this.cbPriority = new System.Windows.Forms.ComboBox();
            this.lPriority = new System.Windows.Forms.Label();
            this.cbRepeat = new System.Windows.Forms.CheckBox();
            this.bWork = new System.Windows.Forms.Button();
            this.bMakeChild = new System.Windows.Forms.Button();
            this.ttToolTip = new System.Windows.Forms.ToolTip(this.components);
            this.cmsMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.tsmSaveAs = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmFilter = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.tsmGroupBy = new System.Windows.Forms.ToolStripMenuItem();
            this.cmsMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblname
            // 
            this.lblname.AutoSize = true;
            this.lblname.Location = new System.Drawing.Point(546, 10);
            this.lblname.Name = "lblname";
            this.lblname.Size = new System.Drawing.Size(46, 13);
            this.lblname.TabIndex = 0;
            this.lblname.Text = "Struct id";
            // 
            // btnShow
            // 
            this.btnShow.Location = new System.Drawing.Point(465, 5);
            this.btnShow.Name = "btnShow";
            this.btnShow.Size = new System.Drawing.Size(75, 23);
            this.btnShow.TabIndex = 1;
            this.btnShow.Text = "Show";
            this.ttToolTip.SetToolTip(this.btnShow, "Show all rows");
            this.btnShow.UseVisualStyleBackColor = true;
            this.btnShow.Click += new System.EventHandler(this.btnShow_Click);
            // 
            // cbUseIt
            // 
            this.cbUseIt.AutoSize = true;
            this.cbUseIt.Location = new System.Drawing.Point(5, 9);
            this.cbUseIt.Name = "cbUseIt";
            this.cbUseIt.Size = new System.Drawing.Size(15, 14);
            this.cbUseIt.TabIndex = 2;
            this.ttToolTip.SetToolTip(this.cbUseIt, "Use this data object");
            this.cbUseIt.UseVisualStyleBackColor = true;
            // 
            // tbStartAt
            // 
            this.tbStartAt.Font = new System.Drawing.Font("Microsoft Sans Serif", 6F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.tbStartAt.Location = new System.Drawing.Point(99, 10);
            this.tbStartAt.Name = "tbStartAt";
            this.tbStartAt.Size = new System.Drawing.Size(35, 17);
            this.tbStartAt.TabIndex = 3;
            this.tbStartAt.Tag = "Start from row, zero is max row in object";
            this.tbStartAt.Text = "1";
            // 
            // tbIncrement
            // 
            this.tbIncrement.Font = new System.Drawing.Font("Microsoft Sans Serif", 6F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.tbIncrement.Location = new System.Drawing.Point(187, 10);
            this.tbIncrement.Name = "tbIncrement";
            this.tbIncrement.Size = new System.Drawing.Size(35, 17);
            this.tbIncrement.TabIndex = 4;
            this.tbIncrement.Tag = "increment by value, can be negative value";
            this.tbIncrement.Text = "1";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 6F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label1.Location = new System.Drawing.Point(99, 2);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(29, 9);
            this.label1.TabIndex = 5;
            this.label1.Text = "Start at";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 6F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label2.Location = new System.Drawing.Point(187, 2);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(39, 9);
            this.label2.TabIndex = 6;
            this.label2.Text = "Increment";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 6F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label3.Location = new System.Drawing.Point(140, 2);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(26, 9);
            this.label3.TabIndex = 8;
            this.label3.Text = "End at";
            // 
            // tbEndAt
            // 
            this.tbEndAt.Font = new System.Drawing.Font("Microsoft Sans Serif", 6F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.tbEndAt.Location = new System.Drawing.Point(140, 10);
            this.tbEndAt.Name = "tbEndAt";
            this.tbEndAt.Size = new System.Drawing.Size(35, 17);
            this.tbEndAt.TabIndex = 7;
            this.tbEndAt.Tag = "Start from row, zero is max row in object";
            this.tbEndAt.Text = "1";
            // 
            // bUnload
            // 
            this.bUnload.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.bUnload.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.bUnload.Location = new System.Drawing.Point(805, 5);
            this.bUnload.Name = "bUnload";
            this.bUnload.Size = new System.Drawing.Size(23, 23);
            this.bUnload.TabIndex = 9;
            this.bUnload.Text = "X";
            this.ttToolTip.SetToolTip(this.bUnload, "Close data object and all childs");
            this.bUnload.UseVisualStyleBackColor = true;
            this.bUnload.Click += new System.EventHandler(this.bUnload_Click);
            // 
            // lObjectName
            // 
            this.lObjectName.AutoSize = true;
            this.lObjectName.Location = new System.Drawing.Point(26, 13);
            this.lObjectName.Name = "lObjectName";
            this.lObjectName.Size = new System.Drawing.Size(66, 13);
            this.lObjectName.TabIndex = 10;
            this.lObjectName.Text = "ObjectName";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 6F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label4.Location = new System.Drawing.Point(28, 2);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(48, 9);
            this.label4.TabIndex = 11;
            this.label4.Text = "Object name";
            // 
            // cbLock
            // 
            this.cbLock.AutoSize = true;
            this.cbLock.Font = new System.Drawing.Font("Microsoft Sans Serif", 6F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.cbLock.ForeColor = System.Drawing.SystemColors.ControlText;
            this.cbLock.Location = new System.Drawing.Point(285, 10);
            this.cbLock.Name = "cbLock";
            this.cbLock.Size = new System.Drawing.Size(40, 14);
            this.cbLock.TabIndex = 12;
            this.cbLock.Text = "Lock";
            this.cbLock.UseVisualStyleBackColor = true;
            // 
            // cbPriority
            // 
            this.cbPriority.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbPriority.Font = new System.Drawing.Font("Microsoft Sans Serif", 6F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.cbPriority.FormattingEnabled = true;
            this.cbPriority.Items.AddRange(new object[] {
            "1",
            "2",
            "3",
            "4",
            "5",
            "6",
            "8",
            "9",
            "10",
            "11",
            "12",
            "13",
            "14",
            "15",
            "16",
            "17",
            "18",
            "19",
            "20"});
            this.cbPriority.Location = new System.Drawing.Point(228, 10);
            this.cbPriority.Name = "cbPriority";
            this.cbPriority.Size = new System.Drawing.Size(51, 17);
            this.cbPriority.TabIndex = 13;
            // 
            // lPriority
            // 
            this.lPriority.AutoSize = true;
            this.lPriority.Font = new System.Drawing.Font("Microsoft Sans Serif", 6F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lPriority.Location = new System.Drawing.Point(230, 2);
            this.lPriority.Name = "lPriority";
            this.lPriority.Size = new System.Drawing.Size(30, 9);
            this.lPriority.TabIndex = 14;
            this.lPriority.Text = "Priority";
            // 
            // cbRepeat
            // 
            this.cbRepeat.AutoSize = true;
            this.cbRepeat.Font = new System.Drawing.Font("Microsoft Sans Serif", 6F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.cbRepeat.ForeColor = System.Drawing.SystemColors.ControlText;
            this.cbRepeat.Location = new System.Drawing.Point(330, 10);
            this.cbRepeat.Name = "cbRepeat";
            this.cbRepeat.Size = new System.Drawing.Size(48, 14);
            this.cbRepeat.TabIndex = 15;
            this.cbRepeat.Text = "Repeat";
            this.cbRepeat.UseVisualStyleBackColor = true;
            // 
            // bWork
            // 
            this.bWork.Location = new System.Drawing.Point(384, 5);
            this.bWork.Name = "bWork";
            this.bWork.Size = new System.Drawing.Size(75, 23);
            this.bWork.TabIndex = 16;
            this.bWork.Text = "Work";
            this.bWork.UseVisualStyleBackColor = true;
            this.bWork.Click += new System.EventHandler(this.bWork_Click);
            // 
            // bMakeChild
            // 
            this.bMakeChild.Location = new System.Drawing.Point(767, 5);
            this.bMakeChild.Name = "bMakeChild";
            this.bMakeChild.Size = new System.Drawing.Size(32, 23);
            this.bMakeChild.TabIndex = 17;
            this.bMakeChild.Text = ">>";
            this.ttToolTip.SetToolTip(this.bMakeChild, "Set as child");
            this.bMakeChild.UseVisualStyleBackColor = true;
            this.bMakeChild.Click += new System.EventHandler(this.bMakeChild_Click);
            // 
            // cmsMenu
            // 
            this.cmsMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmSaveAs,
            this.tsmFilter,
            this.toolStripSeparator1,
            this.tsmGroupBy});
            this.cmsMenu.Name = "cmsMenu";
            this.cmsMenu.Size = new System.Drawing.Size(133, 76);
            // 
            // tsmSaveAs
            // 
            this.tsmSaveAs.Name = "tsmSaveAs";
            this.tsmSaveAs.Size = new System.Drawing.Size(152, 22);
            this.tsmSaveAs.Text = "&Save as...";
            this.tsmSaveAs.Click += new System.EventHandler(this.tsmSaveAs_Click);
            // 
            // tsmFilter
            // 
            this.tsmFilter.Name = "tsmFilter";
            this.tsmFilter.Size = new System.Drawing.Size(152, 22);
            this.tsmFilter.Text = "Filter...";
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(149, 6);
            // 
            // tsmGroupBy
            // 
            this.tsmGroupBy.Name = "tsmGroupBy";
            this.tsmGroupBy.Size = new System.Drawing.Size(152, 22);
            this.tsmGroupBy.Text = "Group by...";
            // 
            // RowCollection
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.Controls.Add(this.bMakeChild);
            this.Controls.Add(this.bWork);
            this.Controls.Add(this.cbRepeat);
            this.Controls.Add(this.lPriority);
            this.Controls.Add(this.cbPriority);
            this.Controls.Add(this.cbLock);
            this.Controls.Add(this.bUnload);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.tbEndAt);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tbIncrement);
            this.Controls.Add(this.tbStartAt);
            this.Controls.Add(this.cbUseIt);
            this.Controls.Add(this.btnShow);
            this.Controls.Add(this.lblname);
            this.Controls.Add(this.lObjectName);
            this.Controls.Add(this.label4);
            this.Name = "RowCollection";
            this.Size = new System.Drawing.Size(833, 31);
            this.cmsMenu.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblname;
        private System.Windows.Forms.Button btnShow;
        public System.Windows.Forms.CheckBox cbUseIt;
        private System.Windows.Forms.TextBox tbStartAt;
        private System.Windows.Forms.TextBox tbIncrement;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox tbEndAt;
        private System.Windows.Forms.Button bUnload;
        private System.Windows.Forms.Label lObjectName;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.CheckBox cbLock;
        private System.Windows.Forms.ComboBox cbPriority;
        private System.Windows.Forms.Label lPriority;
        private System.Windows.Forms.CheckBox cbRepeat;
        private System.Windows.Forms.Button bWork;
        private System.Windows.Forms.Button bMakeChild;
        private System.Windows.Forms.ToolTip ttToolTip;
        private System.Windows.Forms.ContextMenuStrip cmsMenu;
        private System.Windows.Forms.ToolStripMenuItem tsmGroupBy;
        private System.Windows.Forms.ToolStripMenuItem tsmFilter;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem tsmSaveAs;
    }
}
