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

using DamirM.Module.ModuleManager;
using DamirM.Class;

namespace UberTools.Plugin.TemplatesFiller.Controls
{
    public partial class HoveringWindow : UserControl
    {
        private Form owner;
        private bool isVisible = false;
        private TextBoxBase activeControl;
        private TagsStorage tagsStorage;

        public HoveringWindow(Form owner)
        {
            InitializeComponent();
            this.owner = owner;
            //this.owner.Click += new EventHandler(control_LostFocus);
            tvList.GotFocus += new EventHandler(listBox1_GotFocus);

            TagsLoader tagsLoader = new TagsLoader();
            this.tagsStorage = tagsLoader.LoadTags();
        }

        public void AddControl(TextBoxBase control)
        {
            control.KeyUp += new KeyEventHandler(control_KeyUp);
            //control.LostFocus += new EventHandler(control_LostFocus);
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
                    HoweringWindow_Refresh();
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
                            HoweringWindow_Refresh();
                        }
                    }
                }
            }
            else
            {
                if (e.KeyCode != Keys.Up && e.KeyCode != Keys.Down)
                {
                    HoweringWindow_Refresh();
                }
            }
        }

        private void HoweringWindow_Refresh()
        {
            string result = GetTagBlock(activeControl.Text, activeControl.SelectionStart);


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
            int offSetX = 0;
            int offSetY = 0;
            Point point;

            // 
            // hoveringWindow1
            // 
            Point topParentOffSet = GetTopParentOffSet(control);
            offSetX = topParentOffSet.X;
            offSetY = topParentOffSet.Y;

            offSetX += 5;
            offSetY += 55;

            point = GetCaretCoordinates(control);

            offSetX += point.X;
            offSetY += point.Y + 20;

            this.Location = new System.Drawing.Point(offSetX + this.owner.Left + control.Location.X, offSetY + this.owner.Top + control.Location.Y);
            if (isVisible == false)
            {
                this.Name = "hoveringWindow1";
                this.Size = new System.Drawing.Size(228, 97);
                this.TabIndex = 29;
                this.owner.MdiParent.Controls.Add(this);
                this.Visible = true;
                this.owner.Parent.MouseClick += new MouseEventHandler(Parent_MouseClick);
                isVisible = true;
            }
        }


        private void UpdateHoveringWindowList(string text)
        {
            TagsStorage activeTagStorage = null;
            TreeNode treeNode;

            if (text.Length > 2)
            {
                text = text.Substring(2, text.Length - 2);
                Tag tag = new Tag("Root", text);
                activeTagStorage = tagsStorage.GetTagsStorage(tag.Tags);
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
                    treeNode = new TreeNode(tags.Name, 0, 0);
                    treeNode.Tag = tags.Type == TagsStorage.TagType.Object ? tags.Name : "\"\"";
                    tvList.Nodes.Add(treeNode);
                }
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
                    //if (typeof(UberTools.Plugin.TemplatesFiller.Forms.ModuleMainForm) != type)
                    if (typeof(UberTools.Plugin.TemplatesFiller.Forms.ModuleMainForm) != type && typeof(MdiClient) != type)
                    {
                        parentControl = parentControl.Parent;
                        point.X += parentControl.Location.X;
                        point.Y += parentControl.Location.Y;
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

        private System.Drawing.Point GetCaretCoordinates(TextBoxBase control)
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
            int oldSelectionStart;
            string tagBlock;
            int lastIndexOf;

            if (tvList.SelectedNode != null)
            {
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
                        activeControl.SelectionStart = 2;
                    }
                    activeControl.SelectionLength = oldSelectionStart - activeControl.SelectionStart;

                }

                activeControl.SelectedText = tvList.SelectedNode.Tag.ToString();
                if (tvList.SelectedNode.Tag.ToString() == "\"\"")
                {
                    activeControl.SelectionStart = activeControl.SelectionStart - 1;
                }
                control_LostFocus(sender, null);
            }
        }
    }

    class TagsLoader
    {
        string path;

        public TagsLoader(string path)
        {
            this.path = path;
        }
        public TagsLoader()
        {
            this.path = GenericTemplate.moduleParams.DataPath + "tags.xml";
        }
        public TagsStorage LoadTags()
        {
            TagsStorage rootNode = null;
            XmlDocument xmlDoc;
            if (File.Exists(this.path))
            {
                xmlDoc = new XmlDocument();
                try
                {
                    rootNode = new TagsStorage("{=", TagsStorage.TagType.Object);
                    xmlDoc.Load(path);
                    LoadXMLChild(rootNode, xmlDoc.SelectSingleNode("tags"));
                }
                catch (XmlException ex)
                {
                    ModuleLog.Write(ex, this, "LoadTags", ModuleLog.LogType.ERROR);
                }
                catch (Exception ex)
                {
                    ModuleLog.Write(ex, this, "LoadTags", ModuleLog.LogType.ERROR);
                }
            }
            return rootNode;
        }
        
        private void LoadXMLChild(TagsStorage tagsStorage, XmlNode xmlNode)
        {
            TagsStorage newTagsStorage;
            TagsStorage.TagType tagType;
            foreach (XmlNode node in xmlNode.ChildNodes)
            {
                if (node.NodeType == XmlNodeType.Element)
                {
                    if (node.Name == "tag")
                    {
                        if(node.Attributes["type"].Value == "object")
                        {
                            tagType = TagsStorage.TagType.Object;
                        }
                        else if(node.Attributes["type"].Value == "string")
                        {
                            tagType = TagsStorage.TagType.String;
                        }
                        else if(node.Attributes["type"].Value == "int")
                        {
                            tagType = TagsStorage.TagType.Int;
                        }
                        else
                        {
                            tagType = TagsStorage.TagType.Unknown;
                        }

                        if (node.Attributes["type"] != null)
                        {
                            // check if node is type of object

                            // ovo staviti pod isti i, jer je isto code
                            if (node.Attributes["type"].Value == "object")
                            {
                                if (tagsStorage != null)
                                {
                                    // if TagsStorage is not null then build nodes
                                    newTagsStorage = new TagsStorage(node.Attributes["name"].Value, tagType);
                                    tagsStorage.Add(newTagsStorage);
                                    if (node.HasChildNodes)
                                    {
                                        LoadXMLChild(newTagsStorage, node);
                                    }
                                }
                                else
                                {
                                    ModuleLog.Write("Bad xml format \r\n" + node.InnerXml, this, "LoadXMLChild", ModuleLog.LogType.WARNING);
                                }
                            }
                            else
                            {
                                if (tagsStorage != null)
                                {
                                    // if TagsStorage is not null then build nodes
                                    newTagsStorage = new TagsStorage(node.Attributes["name"].Value , tagType);
                                    tagsStorage.Add(newTagsStorage);
                                    if (node.HasChildNodes)
                                    {
                                        LoadXMLChild(newTagsStorage, node);
                                    }
                                }
                                else
                                {
                                    ModuleLog.Write("Bad xml format \r\n" + node.InnerXml, this, "LoadXMLChild", ModuleLog.LogType.WARNING);
                                }
                            }
                        }
                        else
                        {
                            ModuleLog.Write("Bad xml format \r\n" + node.InnerXml, this, "LoadXMLChild", ModuleLog.LogType.WARNING);
                        }
                    }
                    else if (node.Name == "syntax")
                    {
                        //tbSyntax.Text = node.InnerText;
                    }
                    else if (node.Name == "result")
                    {
                        //lblResult.Text = "Result: " + node.InnerText;
                    }
                    else if (node.Name == "example")
                    {
                        //lblExample.Text = "Example: " + node.InnerText;
                    }
                    else
                    {
                        if (node.HasChildNodes)
                        {
                            LoadXMLChild(tagsStorage, node);
                        }
                    }
                }
            }
        }

    }

    class TagsStorage
    {
        string name;
        TagType tagType;
        string description;
        ArrayList tagsList;
        public TagsStorage parent;

        public enum TagType
        {
            Unknown, Object, Int, String
        }

        public TagsStorage(string name, TagType tagType)
        {
            this.tagType = tagType;
            if (this.tagType == TagType.Object)
            {
                this.name = name;
            }
            else
            {
                this.name = name + " [" + tagType.ToString() + "]";
            }
        }

        public void Add(TagsStorage tagsStorage)
        {
            tagsStorage.parent = this;
            if (tagsList == null)
            {
                tagsList = new ArrayList();
            }
            tagsList.Add(tagsStorage);
        }

        public TagsStorage GetTagsStorage(Tag tag)
        {
            TagsStorage result = null;
            foreach (TagsStorage tagsStorage in this)
            {
                if (tagsStorage.name == tag.Name || (tagsStorage.tagType != TagType.Object) && tag.Name != ""  )
                {
                    if (tag.Tags == null)
                    {
                        result = tagsStorage;
                    }
                    else
                    {
                        result = tagsStorage.GetTagsStorage(tag.Tags);
                    }
                }
            }
            if (result == null)
            {
                result = this;
            }

            return result;
        }

        public System.Collections.Generic.IEnumerator<TagsStorage> GetEnumerator()
        {
            if (tagsList != null)
            {
                for (int i = 0; i < tagsList.Count; i++)
                {
                    yield return (TagsStorage)tagsList[i];
                }
            }
        }

        public string Name
        {
            get
            {
                return this.name;
            }
        }
        public TagType Type
        {
            get
            {
                return this.tagType;
            }
        }

        public override string ToString()
        {
            return name;
        }

    }

}
