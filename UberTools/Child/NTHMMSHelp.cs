using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;

using DamirM.CommonLibrary;

namespace NTHTools
{
    public partial class NTHMMSHelp : ChildBase
    {
        public NTHMMSHelp()
        {
            InitializeComponent();
            cbFormats.Text = cbFormats.Items[0].ToString();
            textBox2_TextChanged(null, null);
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string pathDestinationTxt = "";
            string pathSourceTxt = "";
            //SetStatus("Working...");
            FileInfo fileInfo;
            try
            {
                fileInfo = (FileInfo)listBox1.Items[listBox1.SelectedIndex];
                //Image img = Image.FromFile(fileInfo.FullName);
                pathDestinationTxt = tbPathDestination.Text + "\\" + ExtractName(fileInfo.Name,fileInfo.Extension) + ".txt";
                if (File.Exists(pathDestinationTxt))
                {
                    lblDestination.Text = LoadText(pathDestinationTxt);
                }
                else
                {
                    lblDestination.Text = "N/A";
                }
                //if (File.Exists(pathDestinationTxt))
                pathSourceTxt = tbPathSource.Text + "\\" + ExtractName(fileInfo.Name, fileInfo.Extension) + ".txt";
                if (File.Exists(pathSourceTxt))
                {
                    lblSource.Text = LoadText(pathSourceTxt);
                    textBox2.Text = lblSource.Text;
                }
                else
                {
                    textBox2.Text = "";
                    lblSource.Text = "N/A";
                }
                // Load image
                pbSource.Image = Image.FromFile(fileInfo.FullName);
                if (File.Exists(tbPathDestination.Text + "\\" + fileInfo.Name))
                {
                    pbDestination.Image = Image.FromFile(tbPathDestination.Text + "\\" + fileInfo.Name);
                }
                else
                {
                    pbDestination.Image = null;
                }
            }
            catch(Exception exc)
            {
                Log.Write(exc, this.Name, "listBox1_SelectedIndexChanged", Log.LogType.DEBUG);
                //SetStatus("Error");
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            pbDestination.Image = null;
            //pbSource.Image = null;
            FileInfo fileInfo = (FileInfo)listBox1.Items[listBox1.SelectedIndex];
            try
            {
                string file = tbPathDestination.Text + "\\" + ExtractName(fileInfo.Name, fileInfo.Extension) + ".txt";
                if (File.Exists(file))
                {
                    File.Delete(file);
                }
                StreamWriter sWriter = new StreamWriter(file);
                sWriter.Write(textBox2.Text);
                sWriter.Close();

                file = tbPathSource.Text + "\\" + ExtractName(fileInfo.Name, fileInfo.Extension) + ".txt";
                if (File.Exists(file))
                {
                    File.Delete(file);
                }
                sWriter = new StreamWriter(file);
                sWriter.Write(textBox2.Text);
                sWriter.Close();
                if (!File.Exists(tbPathDestination.Text + "\\" + fileInfo.Name))
                {
                    File.Copy(fileInfo.FullName, tbPathDestination.Text + "\\" + fileInfo.Name, true);
                }
                listBox1_SelectedIndexChanged(null, new EventArgs());
            }
            catch(Exception exc)
            {
                Log.Write(exc, this.Name, "button1_Click", Log.LogType.INFO);
                MessageBox.Show(exc.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void button2_Click(object sender, EventArgs e)
        {
            folderBrowserDialog1.SelectedPath = tbPathSource.Text;
            folderBrowserDialog1.ShowDialog(this);
            tbPathSource.Text = folderBrowserDialog1.SelectedPath;
        }
        private void button3_Click(object sender, EventArgs e)
        {
            folderBrowserDialog1.SelectedPath = tbPathDestination.Text;
            folderBrowserDialog1.ShowDialog(this);
            tbPathDestination.Text = folderBrowserDialog1.SelectedPath;
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            if (textBox2.Text.EndsWith("\r\n"))
            {
                textBox2.Text = textBox2.Text.Replace("\r\n", "");
            }
            textBox2.Text = textBox2.Text.Trim();
        }
        private void FillListBox(string folder, string listFormats)
        {
            DirectoryInfo mapaSource = new DirectoryInfo(folder);
            FileInfo[] filelist;
            string[] formats = listFormats.Split(new char[] {';'}, StringSplitOptions.RemoveEmptyEntries);
            try
            {
                listBox1.Items.Clear();
                foreach (string format in formats)
                {
                    filelist = mapaSource.GetFiles(txtSearch.Text + "*." + format);
                    foreach (FileInfo fileInfo in filelist)
                    {
                        listBox1.Items.Add(fileInfo);
                    }
                    ///fileInfo.Name.Replace(fileInfo.Extension, "")
                }
            }
            catch(Exception exc)
            {
                SetStatus("Greska !!!");
                Log.Write(exc, this.Name, "FillListBox", Log.LogType.DEBUG);
            }
        }
        private void txtSearch_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == 38) // down
            {
                if (listBox1.SelectedIndex > 0)
                {
                    listBox1.SelectedIndex = listBox1.SelectedIndex - 1;
                }
                e.SuppressKeyPress = true;
            }
            else if (e.KeyValue == 40) // up
            {
                if (listBox1.SelectedIndex + 1 < listBox1.Items.Count)
                {
                    listBox1.SelectedIndex = listBox1.SelectedIndex + 1;
                }
                e.SuppressKeyPress = true;
            }
        }
        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            FillListBox(tbPathSource.Text, cbFormats.Text);
        }

        private string ExtractName(string fullName, string Extansion)
        {
            return fullName.Substring(0,fullName.Length - Extansion.Length);
        }
        private void ClearSourceDestination()
        {
            lblDestination.Text = "N/A";
            lblSource.Text = "N/A";
            pbSource.Image = null;
            pbDestination.Image = null;
            textBox2.Text = "";
        }
        private string LoadText(string path)
        {
            StreamReader sReader = new StreamReader(path);
            string buff = sReader.ReadToEnd();
            sReader.Close();
            sReader.Dispose();
            return buff;
        }
    }
}
