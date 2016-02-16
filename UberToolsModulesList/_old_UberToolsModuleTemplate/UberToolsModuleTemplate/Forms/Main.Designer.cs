namespace UberToolsModuleTemplate.Forms
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
            this.bWriteErrorLog = new System.Windows.Forms.Button();
            this.tbOutputText = new System.Windows.Forms.TextBox();
            this.bTestInputBox = new System.Windows.Forms.Button();
            this.bTestInputBoxMultiInput = new System.Windows.Forms.Button();
            this.bTestInputConfirmation = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // bWriteErrorLog
            // 
            this.bWriteErrorLog.Location = new System.Drawing.Point(26, 30);
            this.bWriteErrorLog.Name = "bWriteErrorLog";
            this.bWriteErrorLog.Size = new System.Drawing.Size(123, 23);
            this.bWriteErrorLog.TabIndex = 0;
            this.bWriteErrorLog.Text = "WriteErrorOnLog";
            this.bWriteErrorLog.UseVisualStyleBackColor = true;
            this.bWriteErrorLog.Click += new System.EventHandler(this.bWriteErrorLog_Click);
            // 
            // tbOutputText
            // 
            this.tbOutputText.Location = new System.Drawing.Point(12, 170);
            this.tbOutputText.Multiline = true;
            this.tbOutputText.Name = "tbOutputText";
            this.tbOutputText.Size = new System.Drawing.Size(682, 70);
            this.tbOutputText.TabIndex = 1;
            // 
            // bTestInputBox
            // 
            this.bTestInputBox.Location = new System.Drawing.Point(170, 30);
            this.bTestInputBox.Name = "bTestInputBox";
            this.bTestInputBox.Size = new System.Drawing.Size(116, 23);
            this.bTestInputBox.TabIndex = 2;
            this.bTestInputBox.Text = "InputBox";
            this.bTestInputBox.UseVisualStyleBackColor = true;
            this.bTestInputBox.Click += new System.EventHandler(this.bTestInputBox_Click);
            // 
            // bTestInputBoxMultiInput
            // 
            this.bTestInputBoxMultiInput.Location = new System.Drawing.Point(304, 30);
            this.bTestInputBoxMultiInput.Name = "bTestInputBoxMultiInput";
            this.bTestInputBoxMultiInput.Size = new System.Drawing.Size(116, 23);
            this.bTestInputBoxMultiInput.TabIndex = 3;
            this.bTestInputBoxMultiInput.Text = "InputBox Multi Input";
            this.bTestInputBoxMultiInput.UseVisualStyleBackColor = true;
            this.bTestInputBoxMultiInput.Click += new System.EventHandler(this.bTestInputBoxMultiInput_Click);
            // 
            // bTestInputConfirmation
            // 
            this.bTestInputConfirmation.Location = new System.Drawing.Point(437, 30);
            this.bTestInputConfirmation.Name = "bTestInputConfirmation";
            this.bTestInputConfirmation.Size = new System.Drawing.Size(174, 23);
            this.bTestInputConfirmation.TabIndex = 4;
            this.bTestInputConfirmation.Text = "InputBox Confirmation";
            this.bTestInputConfirmation.UseVisualStyleBackColor = true;
            this.bTestInputConfirmation.Click += new System.EventHandler(this.bTestInputConfirmation_Click);
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(706, 252);
            this.Controls.Add(this.bTestInputConfirmation);
            this.Controls.Add(this.bTestInputBoxMultiInput);
            this.Controls.Add(this.bTestInputBox);
            this.Controls.Add(this.tbOutputText);
            this.Controls.Add(this.bWriteErrorLog);
            this.Name = "Main";
            this.Text = "Main";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button bWriteErrorLog;
        private System.Windows.Forms.TextBox tbOutputText;
        private System.Windows.Forms.Button bTestInputBox;
        private System.Windows.Forms.Button bTestInputBoxMultiInput;
        private System.Windows.Forms.Button bTestInputConfirmation;
    }
}