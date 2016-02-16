using System;
using System.Collections.Generic;
using System.Collections;
using System.Text;
using System.Windows.Forms;
using System.Drawing;
using System.Text.RegularExpressions;

using DamirM.Modules;

namespace UberTools.Modules.GenericTemplate
{
    class ColorMenager_old
    {
        private ControlCollection controls;

        public ColorMenager_old()
        {
            this.controls = new ControlCollection();
            this.controls.ControlAdded += new EventHandler(controls_ControlAdded);
        }

        void controls_ControlAdded(object sender, EventArgs e)
        {
            RichTextBox control = (RichTextBox)sender;

            control.KeyUp += new KeyEventHandler(control_KeyUp);
        }

        void control_KeyUp(object sender, KeyEventArgs e)
        {
            RichTextBox richTextBox;
            Regex r;
            String[] lines;
            int oldSelectionStart;
            int row;
            int first_row_index;
            int last_row_index;

            richTextBox = (RichTextBox)sender;
            r = new Regex(Environment.NewLine);
            lines = r.Split(richTextBox.Text);

            oldSelectionStart = richTextBox.SelectionStart;
            row = richTextBox.GetLineFromCharIndex(richTextBox.SelectionStart);
            first_row_index = richTextBox.GetFirstCharIndexFromLine(row);
            last_row_index = richTextBox.Text.IndexOf("\n", first_row_index);

            richTextBox.SelectionStart = first_row_index;
            richTextBox.SelectionLength = last_row_index - first_row_index;

            richTextBox.SelectionColor = Color.Blue;
            richTextBox.SelectionFont = new Font("Courier New", 10, FontStyle.Bold);

            richTextBox.SelectionStart = oldSelectionStart;
            richTextBox.SelectionLength = 0;
            //richTextBox.Clear();
            //foreach (string line in lines)
            //{
            //    ParseLine(richTextBox, line);
            //}

            ModuleLog.Write("Row:" + row.ToString() + ", first_row_index: " + first_row_index + ", last_row_index" + last_row_index, "control_KeyUp", "control_KeyUp", ModuleLog.LogType.DEBUG);
            
        }

        public void ParseLine(RichTextBox richTextBox, string line)
        {
            Regex r = new Regex("([ \\t{}():;])");
            String[] tokens = r.Split(line);
            foreach (string token in tokens)
            {
                // Set the tokens default color and font.
                richTextBox.SelectionColor = Color.Black;
                richTextBox.SelectionFont = new Font("Courier New", 10, FontStyle.Regular);
                // Check whether the token is a keyword. 
                String[] keywords = { "string", "data", "{=", "}", "." };
                for (int i = 0; i < keywords.Length; i++)
                {
                    if (keywords[i] == token)
                    {
                        // Apply alternative color and font to highlight keyword.
                        richTextBox.SelectionColor = Color.Blue;
                        richTextBox.SelectionFont = new Font("Courier New", 10, FontStyle.Bold);
                        break;
                    }
                }
                richTextBox.SelectedText = token;
            }
            richTextBox.SelectedText = Environment.NewLine;
        }
        public void ParseLine2(RichTextBox richTextBox, string line)
        {
            Regex r = new Regex("([ \\t{}():;])");
            String[] tokens = r.Split(line);
            
            foreach( string token in tokens)
            {
                // Set the tokens default color and font.
                richTextBox.SelectionColor = Color.Black;
                richTextBox.SelectionFont = new Font("Courier New", 10, FontStyle.Regular);
                // Check whether the token is a keyword. 
                String[] keywords = { "string", "data", "{=", "}", "." };
                for (int i = 0; i < keywords.Length; i++)
                {
                    if (keywords[i] == token)
                    {
                        // Apply alternative color and font to highlight keyword.
                        richTextBox.SelectionColor = Color.Blue;
                        richTextBox.SelectionFont = new Font("Courier New", 10, FontStyle.Bold);
                        break;
                    }
                }
                richTextBox.SelectedText = token;
            }
            richTextBox.SelectedText = Environment.NewLine;
        }


        public ControlCollection Controls
        {
            get { return this.controls; }
        }



        public class ControlCollection
        {
            private ArrayList list;

            public event EventHandler ControlAdded;

            public ControlCollection()
            {
                list = new ArrayList();
            }

            public void Add(RichTextBox richTextBox)
            {
                list.Add(richTextBox);
                if (ControlAdded != null)
                {
                    ControlAdded(richTextBox, null);
                }
            }



        }


    }
}
