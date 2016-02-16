using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using System.Xml;
using System.IO;
using System.Collections;

using  DamirM.Modules;
using DamirM.Class;
using DamirM.CommonControls;

namespace UberTools.Modules.GenericTemplate.Controls
{
    public partial class AutoComplete_OLD : Form
    {
        private Form owner;
        private bool isVisible = false;
        private TextBoxBase activeControl;
        private TagsStorage tagsStorage;

        public AutoComplete_OLD(Form owner, TagsStorage tagsStorage)
        {
            InitializeComponent();
            this.owner = owner;
            this.owner.Click += new EventHandler(control_LostFocus);
            tvList.GotFocus += new EventHandler(listBox1_GotFocus);

            //TagsLoader tagsLoader = new TagsLoader(xmlPath);
            //this.tagsStorage = tagsLoader.LoadTags();
            this.tagsStorage = tagsStorage;
        }

        public void AddControl(TextBoxBase control)
        {
            control.KeyUp += new KeyEventHandler(control_KeyUp);
            control.MouseClick += new MouseEventHandler(control_MouseClick);
            control.GotFocus += new EventHandler(control_GotFocus);
            control.KeyDown += new KeyEventHandler(control_KeyDown);

        }

        void control_KeyDown(object sender, KeyEventArgs e)
        {
            if (isVisible == true)
            {
                if (e.KeyCode == Keys.Up)
                {
                    if (tvList.SelectedNode != null)
                    {
                        if (tvList.SelectedNode.Index != 0)
                        {
                            if (tvList.SelectedNode.Index != -1)
                            {
                                if (tvList.SelectedNode.Index > 0)
                                {
                                    tvList.SelectedNode = tvList.Nodes[tvList.SelectedNode.Index - 1];
                                }
                            }
                            else
                            {
                                tvList.SelectedNode = tvList.Nodes[0];
                            }
                        }
                    }
                    e.SuppressKeyPress = true;
                }
                else if (e.KeyCode == Keys.Down)
                {
                    if (tvList.SelectedNode != null)
                    {
                        if (tvList.SelectedNode.Index != tvList.Nodes.Count)
                        {
                            if (tvList.SelectedNode.Index != -1)
                            {
                                if (tvList.SelectedNode.Index < tvList.Nodes.Count - 1)
                                {
                                    tvList.SelectedNode = tvList.Nodes[tvList.SelectedNode.Index + 1];
                                }
                            }
                            else
                            {
                                tvList.SelectedNode = tvList.Nodes[0];
                            }
                        }
                    }
                    else
                    {
                        if (tvList.Nodes.Count > 0)
                        {
                            tvList.SelectedNode = tvList.Nodes[0];
                        }
                    }
                    e.SuppressKeyPress = true;
                }
                else if (e.KeyCode == Keys.Escape)
                {
                    control_LostFocus(sender, null);
                }
                else if (e.KeyCode == Keys.Enter)
                {
                    tvList_DoubleClick(null, null);
                    e.SuppressKeyPress = true;
                }
            }
            else
            {
                if (e.Control == true && e.KeyCode == Keys.Space)
                {
                    AutoComplete_Refresh();
                    e.SuppressKeyPress = true;
                }
            }
        }

        private void control_KeyUp(object sender, KeyEventArgs e)
        {
            TextBoxBase control = (TextBoxBase)sender;


            if (isVisible == false)
            {
                if (e.KeyCode != Keys.Left && e.KeyCode != Keys.Right && e.KeyCode != Keys.Up && e.KeyCode != Keys.Down && e.KeyCode != Keys.Back && e.KeyCode != Keys.Escape)
                {
                    if (control.SelectionStart > 1)
                    {
                        if ((control.Text[control.SelectionStart - 2] == '{' && control.Text[control.SelectionStart - 1] == '=') || (control.Text[control.SelectionStart - 2] != '\\' && control.Text[control.SelectionStart - 1] == '.'))
                        {
                            AutoComplete_Refresh();
                        }
                    }
                }
            }
            else
            {
                if (e.KeyCode != Keys.Up && e.KeyCode != Keys.Down)
                {
                    AutoComplete_Refresh();
                }
            }
        }

        private void AutoComplete_Refresh()
        {
            string result;

            try
            {
                result = GetTagBlock(activeControl.Text, activeControl.SelectionStart);


                // Show window
                if (isVisible == false)
                {
                    if (result != "")
                    {
                        UpdateHoveringWindowList(result);
                        this.Show(activeControl);
                    }
                }
                else
                {
                    if (result != "")
                    {
                        UpdateHoveringWindowList(result);
                        this.Show(activeControl);
                    }
                    else
                    {
                        control_LostFocus(activeControl, null);
                    }
                }
            }
            catch (Exception ex)
            {
                ModuleLog.Write(ex, this, "HoweringWindow_Refresh", ModuleLog.LogType.ERROR);
            }
        }


        void control_GotFocus(object sender, EventArgs e)
        {
            this.activeControl = (TextBoxBase)sender;
        }

        void listBox1_GotFocus(object sender, EventArgs e)
        {
            this.activeControl.Focus();
        }

        void Parent_MouseClick(object sender, MouseEventArgs e)
        {
            control_LostFocus(sender, null);
        }


        private void Show(TextBoxBase control)
        {
            //int offSetX = 0;
            //int offSetY = 0;
            //Point point;
            
            //// 
            //// hoveringWindow1
            //// 
            //Point topParentOffSet = GetTopParentOffSet(control);
            //offSetX = topParentOffSet.X;
            //offSetY = topParentOffSet.Y;

            //point = GetCurrentCoordinates(control);

            //offSetX += point.X;
            //offSetY += point.Y + 20;

            //if (this.owner.MdiParent != null)
            //{
            //    offSetX += 5;
            //    offSetY += 55;
            //    //ModuleLog.Write(this.owner.Location.X.ToString(), this, "Show", ModuleLog.LogType.DEBUG);
                
            //    this.Location = new System.Drawing.Point(offSetX + this.owner.Left + control.Location.X, offSetY + this.owner.Top + control.Location.Y);
            //}
            //else
            //{
            //    this.Location = new System.Drawing.Point(offSetX + control.Location.X, offSetY + control.Location.Y);
            //}

            ///this.SetAutoCompleteLocation(control, true);
            ///
            //if (isVisible == false)
            //{
            //    this.Name = "hoveringWindow1";
            //    this.Size = new System.Drawing.Size(228, 97);
            //    this.TabIndex = 29;
            //    // add this instance to control collectin
            //    if (this.owner.MdiParent != null)
            //    {
            //        // if owner form is mdi chaild then add hoveringWindows to midparent
            //        this.owner.MdiParent.Controls.Add(this);
            //    }
            //    else
            //    {
            //        // else add it to owener form
            //        this.owner.Controls.Add(this);
            //    }
            //    //
            //    if (this.owner.Parent != null)
            //    {
            //        this.owner.Parent.MouseClick += new MouseEventHandler(Parent_MouseClick);
            //    }
            //    isVisible = true;
            //    this.Visible = true;
            //    this.BringToFront();
            //}
            this.Visible = true;
            Focus();
        }


        private void UpdateHoveringWindowList(string text)
        {
            TagsStorage activeTagStorage = null;
            TreeNode treeNode;

            if (text.Length > 2)
            {
                text = text.Substring(2, text.Length - 2);
                //Tag2 tag = new Tag2("Root", text);
                Tag2 tag = new Tag2(text);
                activeTagStorage = tagsStorage.GetTagsStorage(tag);
            }
            else
            {
                activeTagStorage = tagsStorage;
            }
            if (activeTagStorage != null)
            {
                tvList.Nodes.Clear();
                foreach (TagsStorage tags in activeTagStorage)
                {
                    treeNode = new TreeNode(tags.DisplayText);
                    treeNode.ImageKey = tags.Type.ToString();
                    treeNode.SelectedImageKey = tags.Type.ToString();
                    //treeNode.Tag = tags.Value;
                    treeNode.Tag = tags;
                    tvList.Nodes.Add(treeNode);
                }
            }
            else
            {
                tvList.Nodes.Clear();
                control_LostFocus(null, null);
            }
            // ovo je tmp rjesenje jer " . " bug, raditi preko tagova orginalno
            int lastIndexOfDot = text.LastIndexOf('.');
            string lastText;
            if (lastIndexOfDot != -1)
            {
                lastText = text.Substring(lastIndexOfDot + 1, (text.Length - lastIndexOfDot) - 1);
            }
            else
            {
                lastText = text;
            }

            // select active node base on user input
            foreach (TreeNode node in tvList.Nodes)
            {
                if (node.Text.StartsWith(lastText))
                {
                    tvList.SelectedNode = node;
                    break;
                }
            }
        }

        private void control_MouseClick(object sender, MouseEventArgs e)
        {
            control_LostFocus(sender, null);
        }

        private void control_LostFocus(object sender, EventArgs e)
        {
            this.Visible = false;
            this.isVisible = false;
            ttToolTip.Hide(this);
            ttToolTip.RemoveAll();
        }

        private Point GetTopParentOffSet(Control control)
        {
            Point point = new Point(0, 0);
            Control parentControl = control;
            do
            {
                if (parentControl.Parent != null)
                {
                    Type type = parentControl.Parent.GetType();
                    //if (typeof(UberTools.Plugin.GenericTemplate.Forms.ModuleMainForm) != type && typeof(MdiClient) != type)
                    if (!(parentControl.Parent is Form))
                    {
                        parentControl = parentControl.Parent;
                        point.X += parentControl.Location.X;
                        point.Y += parentControl.Location.Y;
                        //ModuleLog.Write(parentControl.Name, this, "GetTopParentOffSet2", ModuleLog.LogType.DEBUG);
                    }
                    else
                    {
                        break;
                    }
                }
                else
                {
                    break;
                }
            } while (true);

            return point;

        }

        /// <summary>
        /// Sets the location of the AutoComplete form, maiking sure it's on the screen where the cursor is.
        /// </summary>
        /// <param name="moveHorizontly">determines wheather or not to move the form horizontly.</param>
        private void SetAutoCompleteLocation(TextBoxBase control, bool moveHorizontly)
        {
            Point cursorLocation = control.GetPositionFromCharIndex(control.SelectionStart);
            Screen screen = Screen.FromPoint(cursorLocation);
            Point optimalLocation = new Point(PointToScreen(cursorLocation).X - 15, (int)(PointToScreen(cursorLocation).Y + Font.Size * 2 + 2));
            Rectangle desiredPlace = new Rectangle(optimalLocation, this.Size);
            desiredPlace.Width = 152;
            if (desiredPlace.Left < screen.Bounds.Left)
            {
                desiredPlace.X = screen.Bounds.Left;
            }
            if (desiredPlace.Right > screen.Bounds.Right)
            {
                desiredPlace.X -= (desiredPlace.Right - screen.Bounds.Right);
            }
            if (desiredPlace.Bottom > screen.Bounds.Bottom)
            {
                desiredPlace.Y = cursorLocation.Y - 2 - desiredPlace.Height;
            }
            if (!moveHorizontly)
            {
                desiredPlace.X = this.Left;
            }

            this.Bounds = desiredPlace;
        }



        private string GetTagBlock(string text, int cursorPos)
        {
            string result = "";
            int endTagCount = 0;

            cursorPos--;

            for (int i = cursorPos; i >= 0; i--)
            {
                if (text[i] == '=')
                {
                    if ((i - 1) >= 0)
                    {
                        if (text[i - 1] == '{')
                        {
                            if (endTagCount == 0)
                            {
                                result = text.Substring(i - 1, (cursorPos - i) + 2);
                                break;
                            }
                            else
                            {
                                endTagCount--;
                            }
                        }
                    }
                }
                else if (text[i] == '}')
                {
                    if ((i - 1) >= 0)
                    {
                        if (text[i - 1] != '\\')
                        {
                            endTagCount++;
                        }
                    }
                }
            }

            return result;
        }

        private System.Drawing.Point GetCurrentCoordinates(TextBoxBase control)
        { // note, get rid of the "+1" if you want the coordinates to be zero based
            //Point p = new System.Drawing.Point();
            //p.Y = (rtb.GetLineFromCharIndex(rtb.SelectionStart)) + 1;
            //p.X = (rtb.SelectionStart - rtb.GetFirstCharIndexOfCurrentLine()) + 1;
            Point point = control.GetPositionFromCharIndex(control.SelectionStart);
            // FIX for textbox
            if(point.X ==0 && point.Y == 0)
            {
                if (control.SelectionStart > 0)
                {
                    point = control.GetPositionFromCharIndex(control.SelectionStart - 1);
                }
            }

            return point;
        }

        private void tvList_DoubleClick(object sender, EventArgs e)
        {
            TagsStorage tagsStorage;
            int oldSelectionStart;
            string tagBlock;
            int lastIndexOf;

            if (tvList.SelectedNode != null)
            {
                tagsStorage = (TagsStorage)tvList.SelectedNode.Tag;
                oldSelectionStart = activeControl.SelectionStart;
                tagBlock = GetTagBlock(activeControl.Text, activeControl.SelectionStart);

                if (tagBlock.Length > 2)
                {
                    lastIndexOf = activeControl.Text.LastIndexOf('.', activeControl.SelectionStart - 1, tagBlock.Length);
                    if (lastIndexOf != -1)
                    {
                        activeControl.SelectionStart = lastIndexOf + 1;
                    }
                    else
                    {
                        activeControl.SelectionStart = oldSelectionStart - tagBlock.Length + 2;
                    }
                    activeControl.SelectionLength = oldSelectionStart - activeControl.SelectionStart;

                }

                activeControl.SelectedText = tagsStorage.Value;
                if (tagsStorage.Type == TagsStorage.TagsStorageType.String)
                {
                    activeControl.SelectionStart = activeControl.SelectionStart - 1;
                }
                control_LostFocus(sender, null);
            }
        }

        private void tvList_AfterSelect(object sender, TreeViewEventArgs e)
        {
            TagsStorage tagsStorage;
            tagsStorage = (TagsStorage)e.Node.Tag;
            ttToolTip.Show(tagsStorage.Desctiption, this, this.Width, this.Height / 3);
        }
    }



}
