using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

// using for module log
using DamirM.Module.ModuleManager;
// using for inputbox
using DamirM.Controls;

namespace UberToolsModuleTemplate.Forms
{
    public partial class Main : Form
    {
        public Main()
        {
            InitializeComponent();
        }

        private void bWriteErrorLog_Click(object sender, EventArgs e)
        {
            ModuleLog.Write("Now will we ganerate error",this,"bWriteErrorLog_Click",ModuleLog.LogType.INFO);

            try
            {
                throw new Exception("I made error :P");
            }
            catch (Exception ex)
            {
                ModuleLog.Write(ex, this, "bWriteErrorLog_Click", ModuleLog.LogType.ERROR);
            }
        }

        private void bTestInputBox_Click(object sender, EventArgs e)
        {
            InputBox inputBox = new InputBox("Input", "Input some text pleas");
            inputBox.ShowDialog(this);
            if (inputBox.DialogResult == DialogResult.OK)
            {
                tbOutputText.Text = inputBox.InputTekst;
            }
        }

        private void bTestInputBoxMultiInput_Click(object sender, EventArgs e)
        {
            string[] inputList = { "Name", "Lastname", "Address", "Phone number" };
            InputBox inputBox = new InputBox("Input", inputList, "Input some text pleas");
            inputBox.ShowDialog(this);
            if (inputBox.DialogResult == DialogResult.OK)
            {
                for (int i = 0; i < inputList.Length; i++)
                {
                    tbOutputText.Text += inputList[i] + ": " + inputBox[i].Text + Environment.NewLine;
                }
            }
        }

        private void bTestInputConfirmation_Click(object sender, EventArgs e)
        {
            string[] confirmationTextList = { "da", "yes", "ok", "delete", "obrisi", "obriši" };
            InputBox inputBox = new InputBox("Input", "To delete file write 'delete' word", "", confirmationTextList);
            inputBox.InformationText = "To delete file pls write 'delete'";
            inputBox.ShowDialog(this);
            if (inputBox.DialogResult == DialogResult.OK)
            {
                MessageBox.Show("User confirmed");
            }
            else
            {
                MessageBox.Show("User say NO!!!!!!");
            }
        }
    }
}
