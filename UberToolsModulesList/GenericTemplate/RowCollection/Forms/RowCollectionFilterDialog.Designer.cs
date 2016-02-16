namespace UberTools.Modules.GenericTemplate.RowCollectionNS
{
    partial class RowCollectionFilterDialog
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.bAdd = new System.Windows.Forms.Button();
            this.lAction = new System.Windows.Forms.Label();
            this.lColumn = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.bCancel = new System.Windows.Forms.Button();
            this.bOK = new System.Windows.Forms.Button();
            this.lValue = new System.Windows.Forms.Label();
            this.cbOutputInNewRowCollection = new System.Windows.Forms.CheckBox();
            this.bTestOutput = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.lValue);
            this.groupBox1.Controls.Add(this.bAdd);
            this.groupBox1.Controls.Add(this.lAction);
            this.groupBox1.Controls.Add(this.lColumn);
            this.groupBox1.Controls.Add(this.panel1);
            this.groupBox1.Location = new System.Drawing.Point(3, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(646, 223);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Filtering rules";
            // 
            // bAdd
            // 
            this.bAdd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.bAdd.Location = new System.Drawing.Point(563, 16);
            this.bAdd.Name = "bAdd";
            this.bAdd.Size = new System.Drawing.Size(75, 23);
            this.bAdd.TabIndex = 4;
            this.bAdd.Text = "&Add";
            this.bAdd.UseVisualStyleBackColor = true;
            this.bAdd.Click += new System.EventHandler(this.bAdd_Click);
            // 
            // lAction
            // 
            this.lAction.AutoSize = true;
            this.lAction.Location = new System.Drawing.Point(161, 21);
            this.lAction.Name = "lAction";
            this.lAction.Size = new System.Drawing.Size(37, 13);
            this.lAction.TabIndex = 3;
            this.lAction.Text = "Action";
            // 
            // lColumn
            // 
            this.lColumn.AutoSize = true;
            this.lColumn.Location = new System.Drawing.Point(19, 21);
            this.lColumn.Name = "lColumn";
            this.lColumn.Size = new System.Drawing.Size(42, 13);
            this.lColumn.TabIndex = 2;
            this.lColumn.Text = "Column";
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.AutoScroll = true;
            this.panel1.Location = new System.Drawing.Point(6, 43);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(634, 174);
            this.panel1.TabIndex = 1;
            // 
            // bCancel
            // 
            this.bCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.bCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.bCancel.Location = new System.Drawing.Point(574, 232);
            this.bCancel.Name = "bCancel";
            this.bCancel.Size = new System.Drawing.Size(75, 23);
            this.bCancel.TabIndex = 1;
            this.bCancel.Text = "&Cancel";
            this.bCancel.UseVisualStyleBackColor = true;
            this.bCancel.Click += new System.EventHandler(this.bCancel_Click);
            // 
            // bOK
            // 
            this.bOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.bOK.Location = new System.Drawing.Point(493, 232);
            this.bOK.Name = "bOK";
            this.bOK.Size = new System.Drawing.Size(75, 23);
            this.bOK.TabIndex = 2;
            this.bOK.Text = "&OK";
            this.bOK.UseVisualStyleBackColor = true;
            this.bOK.Click += new System.EventHandler(this.bOK_Click);
            // 
            // lValue
            // 
            this.lValue.AutoSize = true;
            this.lValue.Location = new System.Drawing.Point(320, 21);
            this.lValue.Name = "lValue";
            this.lValue.Size = new System.Drawing.Size(34, 13);
            this.lValue.TabIndex = 5;
            this.lValue.Text = "Value";
            // 
            // cbOutputInNewRowCollection
            // 
            this.cbOutputInNewRowCollection.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cbOutputInNewRowCollection.AutoSize = true;
            this.cbOutputInNewRowCollection.Checked = true;
            this.cbOutputInNewRowCollection.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbOutputInNewRowCollection.Enabled = false;
            this.cbOutputInNewRowCollection.Location = new System.Drawing.Point(12, 236);
            this.cbOutputInNewRowCollection.Name = "cbOutputInNewRowCollection";
            this.cbOutputInNewRowCollection.Size = new System.Drawing.Size(148, 17);
            this.cbOutputInNewRowCollection.TabIndex = 3;
            this.cbOutputInNewRowCollection.Text = "Output in new data object";
            this.cbOutputInNewRowCollection.UseVisualStyleBackColor = true;
            // 
            // bTestOutput
            // 
            this.bTestOutput.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.bTestOutput.Location = new System.Drawing.Point(401, 232);
            this.bTestOutput.Name = "bTestOutput";
            this.bTestOutput.Size = new System.Drawing.Size(75, 23);
            this.bTestOutput.TabIndex = 4;
            this.bTestOutput.Text = "&Test";
            this.bTestOutput.UseVisualStyleBackColor = true;
            this.bTestOutput.Click += new System.EventHandler(this.bTestOutput_Click);
            // 
            // RowCollectionFilterDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.bCancel;
            this.ClientSize = new System.Drawing.Size(653, 261);
            this.Controls.Add(this.bTestOutput);
            this.Controls.Add(this.cbOutputInNewRowCollection);
            this.Controls.Add(this.bOK);
            this.Controls.Add(this.bCancel);
            this.Controls.Add(this.groupBox1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(600, 250);
            this.Name = "RowCollectionFilterDialog";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Text = "Filter data object";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button bCancel;
        private System.Windows.Forms.Button bOK;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button bAdd;
        private System.Windows.Forms.Label lAction;
        private System.Windows.Forms.Label lColumn;
        private System.Windows.Forms.Label lValue;
        private System.Windows.Forms.CheckBox cbOutputInNewRowCollection;
        private System.Windows.Forms.Button bTestOutput;
    }
}