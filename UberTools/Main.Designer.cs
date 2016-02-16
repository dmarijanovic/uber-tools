namespace NTHTools
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Main));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.datotekaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuExit = new System.Windows.Forms.ToolStripMenuItem();
            this.viewToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.test1ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.alatiToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuTools_SeCT_Action = new System.Windows.Forms.ToolStripMenuItem();
            this.menuTools_ClipBoard = new System.Windows.Forms.ToolStripMenuItem();
            this.menuTools_NTHMMSHelp = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmPlugins = new System.Windows.Forms.ToolStripMenuItem();
            this.hToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuHelp_Log = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.tsmUpdate = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.aboutToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.tssStatus = new System.Windows.Forms.ToolStripStatusLabel();
            this.tssErrors = new System.Windows.Forms.ToolStripStatusLabel();
            this.tssWarnings = new System.Windows.Forms.ToolStripStatusLabel();
            this.tssNewUpdate = new System.Windows.Forms.ToolStripStatusLabel();
            this.tryIcon = new System.Windows.Forms.NotifyIcon(this.components);
            this.tUpdateChecker = new System.Windows.Forms.Timer(this.components);
            this.pToolsWindowsHolder = new System.Windows.Forms.Panel();
            this.splitter1 = new System.Windows.Forms.Splitter();
            this.menuStrip1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.datotekaToolStripMenuItem,
            this.viewToolStripMenuItem,
            this.alatiToolStripMenuItem,
            this.tsmPlugins,
            this.hToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.menuStrip1.Size = new System.Drawing.Size(1072, 24);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // datotekaToolStripMenuItem
            // 
            this.datotekaToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuExit});
            this.datotekaToolStripMenuItem.Name = "datotekaToolStripMenuItem";
            this.datotekaToolStripMenuItem.Size = new System.Drawing.Size(35, 20);
            this.datotekaToolStripMenuItem.Text = "&File";
            // 
            // menuExit
            // 
            this.menuExit.Name = "menuExit";
            this.menuExit.Size = new System.Drawing.Size(103, 22);
            this.menuExit.Text = "E&xit";
            this.menuExit.Click += new System.EventHandler(this.menuExit_Click);
            // 
            // viewToolStripMenuItem
            // 
            this.viewToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.test1ToolStripMenuItem});
            this.viewToolStripMenuItem.Name = "viewToolStripMenuItem";
            this.viewToolStripMenuItem.Size = new System.Drawing.Size(41, 20);
            this.viewToolStripMenuItem.Text = "&View";
            // 
            // test1ToolStripMenuItem
            // 
            this.test1ToolStripMenuItem.Name = "test1ToolStripMenuItem";
            this.test1ToolStripMenuItem.Size = new System.Drawing.Size(112, 22);
            this.test1ToolStripMenuItem.Text = "Test1";
            // 
            // alatiToolStripMenuItem
            // 
            this.alatiToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuTools_SeCT_Action,
            this.menuTools_ClipBoard,
            this.menuTools_NTHMMSHelp});
            this.alatiToolStripMenuItem.Name = "alatiToolStripMenuItem";
            this.alatiToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
            this.alatiToolStripMenuItem.Text = "&Tools";
            // 
            // menuTools_SeCT_Action
            // 
            this.menuTools_SeCT_Action.Name = "menuTools_SeCT_Action";
            this.menuTools_SeCT_Action.Size = new System.Drawing.Size(254, 22);
            this.menuTools_SeCT_Action.Text = "(Do not use) SeCT - Action.xml edit";
            this.menuTools_SeCT_Action.Click += new System.EventHandler(this.menuTools_Click);
            // 
            // menuTools_ClipBoard
            // 
            this.menuTools_ClipBoard.Name = "menuTools_ClipBoard";
            this.menuTools_ClipBoard.Size = new System.Drawing.Size(254, 22);
            this.menuTools_ClipBoard.Text = "Clip Board Extansion";
            this.menuTools_ClipBoard.Click += new System.EventHandler(this.menuTools_Click);
            // 
            // menuTools_NTHMMSHelp
            // 
            this.menuTools_NTHMMSHelp.Name = "menuTools_NTHMMSHelp";
            this.menuTools_NTHMMSHelp.Size = new System.Drawing.Size(254, 22);
            this.menuTools_NTHMMSHelp.Text = "Multi MMS help";
            this.menuTools_NTHMMSHelp.Click += new System.EventHandler(this.menuTools_Click);
            // 
            // tsmPlugins
            // 
            this.tsmPlugins.Name = "tsmPlugins";
            this.tsmPlugins.Size = new System.Drawing.Size(52, 20);
            this.tsmPlugins.Text = "Plugins";
            // 
            // hToolStripMenuItem
            // 
            this.hToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuHelp_Log,
            this.toolStripSeparator2,
            this.tsmUpdate,
            this.toolStripSeparator1,
            this.aboutToolStripMenuItem1});
            this.hToolStripMenuItem.Name = "hToolStripMenuItem";
            this.hToolStripMenuItem.Size = new System.Drawing.Size(40, 20);
            this.hToolStripMenuItem.Text = "&Help";
            // 
            // menuHelp_Log
            // 
            this.menuHelp_Log.Name = "menuHelp_Log";
            this.menuHelp_Log.Size = new System.Drawing.Size(132, 22);
            this.menuHelp_Log.Text = "&Log";
            this.menuHelp_Log.Click += new System.EventHandler(this.menuHelp_Log_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(129, 6);
            // 
            // tsmUpdate
            // 
            this.tsmUpdate.Name = "tsmUpdate";
            this.tsmUpdate.Size = new System.Drawing.Size(132, 22);
            this.tsmUpdate.Text = "Update...";
            this.tsmUpdate.Click += new System.EventHandler(this.tsmUpdate_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(129, 6);
            // 
            // aboutToolStripMenuItem1
            // 
            this.aboutToolStripMenuItem1.Name = "aboutToolStripMenuItem1";
            this.aboutToolStripMenuItem1.Size = new System.Drawing.Size(132, 22);
            this.aboutToolStripMenuItem1.Text = "&About";
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tssStatus,
            this.tssErrors,
            this.tssWarnings,
            this.tssNewUpdate});
            this.statusStrip1.Location = new System.Drawing.Point(0, 614);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(1072, 22);
            this.statusStrip1.TabIndex = 3;
            this.statusStrip1.Text = "status";
            // 
            // tssStatus
            // 
            this.tssStatus.Image = global::UberTools.Properties.Resources.Info_icon;
            this.tssStatus.Name = "tssStatus";
            this.tssStatus.Size = new System.Drawing.Size(54, 17);
            this.tssStatus.Text = "Ready";
            // 
            // tssErrors
            // 
            this.tssErrors.Image = global::UberTools.Properties.Resources.errorIcon;
            this.tssErrors.Name = "tssErrors";
            this.tssErrors.Size = new System.Drawing.Size(65, 17);
            this.tssErrors.Text = "Errors: 0";
            // 
            // tssWarnings
            // 
            this.tssWarnings.Image = global::UberTools.Properties.Resources.warning;
            this.tssWarnings.Name = "tssWarnings";
            this.tssWarnings.Size = new System.Drawing.Size(81, 17);
            this.tssWarnings.Text = "Warnings: 0";
            // 
            // tssNewUpdate
            // 
            this.tssNewUpdate.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.tssNewUpdate.Image = global::UberTools.Properties.Resources.update;
            this.tssNewUpdate.Name = "tssNewUpdate";
            this.tssNewUpdate.Size = new System.Drawing.Size(126, 17);
            this.tssNewUpdate.Text = "New update available";
            this.tssNewUpdate.Visible = false;
            this.tssNewUpdate.Click += new System.EventHandler(this.tsmUpdate_Click);
            // 
            // tryIcon
            // 
            this.tryIcon.Icon = ((System.Drawing.Icon)(resources.GetObject("tryIcon.Icon")));
            this.tryIcon.Text = "Uber Tools";
            this.tryIcon.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.tryIcon_MouseDoubleClick);
            // 
            // tUpdateChecker
            // 
            this.tUpdateChecker.Enabled = true;
            this.tUpdateChecker.Interval = 100000;
            this.tUpdateChecker.Tick += new System.EventHandler(this.tUpdateChecker_Tick);
            // 
            // pToolsWindowsHolder
            // 
            this.pToolsWindowsHolder.Dock = System.Windows.Forms.DockStyle.Left;
            this.pToolsWindowsHolder.Location = new System.Drawing.Point(0, 24);
            this.pToolsWindowsHolder.Margin = new System.Windows.Forms.Padding(5);
            this.pToolsWindowsHolder.Name = "pToolsWindowsHolder";
            this.pToolsWindowsHolder.Padding = new System.Windows.Forms.Padding(20);
            this.pToolsWindowsHolder.Size = new System.Drawing.Size(167, 590);
            this.pToolsWindowsHolder.TabIndex = 5;
            // 
            // splitter1
            // 
            this.splitter1.Location = new System.Drawing.Point(167, 24);
            this.splitter1.MinExtra = 500;
            this.splitter1.MinSize = 100;
            this.splitter1.Name = "splitter1";
            this.splitter1.Size = new System.Drawing.Size(3, 590);
            this.splitter1.TabIndex = 7;
            this.splitter1.TabStop = false;
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1072, 636);
            this.Controls.Add(this.splitter1);
            this.Controls.Add(this.pToolsWindowsHolder);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Main";
            this.Text = "Uber Tools";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmParent_FormClosing);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem datotekaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem alatiToolStripMenuItem;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel tssStatus;
        private System.Windows.Forms.ToolStripMenuItem menuTools_SeCT_Action;
        private System.Windows.Forms.ToolStripMenuItem menuExit;
        private System.Windows.Forms.ToolStripMenuItem menuTools_ClipBoard;
        private System.Windows.Forms.NotifyIcon tryIcon;
        private System.Windows.Forms.ToolStripMenuItem menuTools_NTHMMSHelp;
        private System.Windows.Forms.ToolStripMenuItem hToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem menuHelp_Log;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem tsmPlugins;
        private System.Windows.Forms.ToolStripStatusLabel tssErrors;
        private System.Windows.Forms.ToolStripStatusLabel tssNewUpdate;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem tsmUpdate;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripStatusLabel tssWarnings;
        private System.Windows.Forms.Timer tUpdateChecker;
        private System.Windows.Forms.Panel pToolsWindowsHolder;
        private System.Windows.Forms.ToolStripMenuItem viewToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem test1ToolStripMenuItem;
        private System.Windows.Forms.Splitter splitter1;

    }
}

