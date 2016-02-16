namespace UberTools.Modules.GenericTemplate
{
    partial class RowCollectionFilterItem
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
            this.cbColumn = new System.Windows.Forms.ComboBox();
            this.cbAction = new System.Windows.Forms.ComboBox();
            this.bCloseItem = new System.Windows.Forms.Button();
            this.tbValue = new System.Windows.Forms.TextBox();
            this.cbLogicalOperator = new System.Windows.Forms.ComboBox();
            this.cbLogicalGroup = new System.Windows.Forms.ComboBox();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.SuspendLayout();
            // 
            // cbColumn
            // 
            this.cbColumn.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbColumn.FormattingEnabled = true;
            this.cbColumn.Location = new System.Drawing.Point(9, 6);
            this.cbColumn.Name = "cbColumn";
            this.cbColumn.Size = new System.Drawing.Size(133, 21);
            this.cbColumn.TabIndex = 0;
            // 
            // cbAction
            // 
            this.cbAction.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbAction.FormattingEnabled = true;
            this.cbAction.Items.AddRange(new object[] {
            "=",
            ">",
            "<",
            ">=",
            "<=",
            "!=",
            "EqualsIgnoreCase",
            "NotEqualsIgnoreCase",
            "RegEx",
            "Not empty"});
            this.cbAction.Location = new System.Drawing.Point(148, 6);
            this.cbAction.Name = "cbAction";
            this.cbAction.Size = new System.Drawing.Size(153, 21);
            this.cbAction.TabIndex = 1;
            // 
            // bCloseItem
            // 
            this.bCloseItem.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.bCloseItem.Location = new System.Drawing.Point(561, 5);
            this.bCloseItem.Name = "bCloseItem";
            this.bCloseItem.Size = new System.Drawing.Size(24, 23);
            this.bCloseItem.TabIndex = 2;
            this.bCloseItem.Text = "X";
            this.bCloseItem.UseVisualStyleBackColor = true;
            this.bCloseItem.Click += new System.EventHandler(this.bCloseItem_Click);
            // 
            // tbValue
            // 
            this.tbValue.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tbValue.Location = new System.Drawing.Point(320, 7);
            this.tbValue.Name = "tbValue";
            this.tbValue.Size = new System.Drawing.Size(133, 20);
            this.tbValue.TabIndex = 3;
            // 
            // cbLogicalOperator
            // 
            this.cbLogicalOperator.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cbLogicalOperator.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbLogicalOperator.FormattingEnabled = true;
            this.cbLogicalOperator.Items.AddRange(new object[] {
            "And",
            "Or"});
            this.cbLogicalOperator.Location = new System.Drawing.Point(503, 6);
            this.cbLogicalOperator.Name = "cbLogicalOperator";
            this.cbLogicalOperator.Size = new System.Drawing.Size(52, 21);
            this.cbLogicalOperator.TabIndex = 4;
            this.toolTip1.SetToolTip(this.cbLogicalOperator, "Logical operator in this group");
            // 
            // cbLogicalGroup
            // 
            this.cbLogicalGroup.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cbLogicalGroup.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbLogicalGroup.FormattingEnabled = true;
            this.cbLogicalGroup.Items.AddRange(new object[] {
            "0",
            "1",
            "2",
            "3",
            "4",
            "5",
            "6",
            "7",
            "8",
            "9"});
            this.cbLogicalGroup.Location = new System.Drawing.Point(459, 6);
            this.cbLogicalGroup.Name = "cbLogicalGroup";
            this.cbLogicalGroup.Size = new System.Drawing.Size(38, 21);
            this.cbLogicalGroup.TabIndex = 5;
            this.toolTip1.SetToolTip(this.cbLogicalGroup, "Logical group");
            // 
            // RowCollectionFilterItem
            // 
            this.Controls.Add(this.cbLogicalGroup);
            this.Controls.Add(this.cbLogicalOperator);
            this.Controls.Add(this.tbValue);
            this.Controls.Add(this.bCloseItem);
            this.Controls.Add(this.cbAction);
            this.Controls.Add(this.cbColumn);
            this.MinimumSize = new System.Drawing.Size(400, 0);
            this.Name = "RowCollectionFilterItem";
            this.Size = new System.Drawing.Size(598, 32);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cbColumn;
        private System.Windows.Forms.ComboBox cbAction;
        private System.Windows.Forms.Button bCloseItem;
        private System.Windows.Forms.TextBox tbValue;
        private System.Windows.Forms.ComboBox cbLogicalOperator;
        private System.Windows.Forms.ComboBox cbLogicalGroup;
        private System.Windows.Forms.ToolTip toolTip1;
    }
}
