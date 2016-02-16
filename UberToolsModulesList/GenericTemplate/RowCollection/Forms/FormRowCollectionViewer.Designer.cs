namespace UberTools.Modules.GenericTemplate.RowCollectionNS
{
    partial class FormRowCollectionViewer
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
            this.dgvGrid = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dgvGrid)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvGrid
            // 
            this.dgvGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvGrid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvGrid.Location = new System.Drawing.Point(0, 0);
            this.dgvGrid.Name = "dgvGrid";
            this.dgvGrid.Size = new System.Drawing.Size(1046, 446);
            this.dgvGrid.TabIndex = 0;
            // 
            // RowCollectionViewer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1046, 446);
            this.Controls.Add(this.dgvGrid);
            this.Name = "RowCollectionViewer";
            this.Text = "NTHPropertyHelp_view";
            ((System.ComponentModel.ISupportInitialize)(this.dgvGrid)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvGrid;
    }
}