using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Collections;
using System.Data.SqlServerCe;
using System.IO;

using DamirM.CommonLibrary;
using UberTools.Modules.QuickTags;

namespace UberTools.Modules.QuickTags.Forms
{
    public partial class FormTagsEdit : Form
    {
        SqlCeConnection conn = new SqlCeConnection(Static.ConnectionString);
        SqlCeCommand command;
        Tags tags = new Tags();
        int tags_texts_id;
        public FormTagsEdit()
        {
            InitializeComponent();
            btnAddEditText.Text = "Add";
            command = new SqlCeCommand("", conn);
            tags.GetTags("");
            ShowTags(lbTags, false);
        }
        public FormTagsEdit(int tags_texts_id)
        {
            InitializeComponent();
            btnAddEditText.Text = "Edit";
            this.tags_texts_id = tags_texts_id;
            command = new SqlCeCommand("", conn);
            tags.GetTags(tags_texts_id,true);
            ShowTags(lbTags, false);
            tags.GetTags(tags_texts_id, false);
            ShowTags(lbTextTags, true);
            GetTextAndInfo(tags_texts_id);
        }


        private void ShowTags(ListBox listBox, bool flag)
        {
            ArrayList list = tags.List;
            listBox.Items.Clear();
            foreach (Tag tag in list)
            {
                tag.Flag = flag;
                listBox.Items.Add(tag);
            }
        }

        private void btnAddTagToTextTags_Click(object sender, EventArgs e)
        {
            if (lbTags.SelectedIndex != -1)
            {
                for (int i = lbTags.SelectedItems.Count - 1; i >= 0; i--)
                {
                    lbTextTags.Items.Add(lbTags.SelectedItems[i]);
                    lbTags.Items.Remove(lbTags.SelectedItems[i]);
                }

            }
        }
        private void btnRemoveTagFromText_Click(object sender, EventArgs e)
        {
            if (lbTextTags.SelectedIndex != -1)
            {
                for (int i = lbTextTags.SelectedItems.Count - 1; i >= 0; i--)
                {
                    lbTags.Items.Add(lbTextTags.SelectedItems[i]);
                    lbTextTags.Items.Remove(lbTextTags.SelectedItems[i]);
                }
            }
        }
        private void GetTextAndInfo(int tags_texts_id)
        {
            SqlCeDataReader dr;
            StringBuilder sb = new StringBuilder();
            try
            {
                if (conn.State != ConnectionState.Open)
                {
                    conn.Open();
                }
                Log.Write(conn.State + ":" + conn.DataSource, this.GetType(), "GetText", Log.LogType.DEBUG);
                sb.Append("SELECT * FROM tags_texts WHERE tags_texts_id =" + tags_texts_id);
                Log.Write(sb.ToString(), this.GetType(), "GetText", Log.LogType.DEBUG);
                command.CommandText = sb.ToString();
                dr = command.ExecuteReader();
                while (dr.Read())
                {
                    txtText.Text = dr["text"].ToString();
                    txtInfo.Text = dr["info"].ToString();
                }
            }
            catch (Exception exc)
            {
                Log.Write(exc, this.GetType(), "GetText", Log.LogType.ERROR);
            }
            finally
            {
                if (conn.State == ConnectionState.Open)
                {
                    conn.Close();
                }
            }
        }

        private void btnAddEditText_Click(object sender, EventArgs e)
        {
            AddEditTextTags();
            this.Close();
        }

        private void AddEditTextTags()
        {
            StringBuilder sb = new StringBuilder();
            int lastID = 0;
            int result = 0;
            object lastIDObject = null;
            try
            {
                if (conn.State != ConnectionState.Open)
                {
                    conn.Open();
                }
                if (this.tags_texts_id == 0)
                {
                    command.CommandText = "SELECT MAX(tags_texts_id) FROM tags_texts";
                    lastIDObject = command.ExecuteScalar();
                    int.TryParse(lastIDObject.ToString(), out lastID);
                    lastID++;
                    sb.Append("INSERT INTO tags_texts (tags_texts_id,text,info) VALUES (");
                    sb.Append(lastID);
                    sb.Append(",'");
                    sb.Append(txtText.Text.Trim());
                    sb.Append("','");
                    sb.Append(txtInfo.Text.Trim());
                    sb.Append("')");
                    Log.Write(sb.ToString(), this.GetType(), "btnAddEditText_Click", Log.LogType.DEBUG);
                    this.tags_texts_id = lastID;
                    command.CommandText = sb.ToString();
                    result = command.ExecuteNonQuery();
                    Log.Write("Rows afected " + result, this.GetType(), "btnAddEditText_Click", Log.LogType.INFO);
                }
                else
                {
                    sb.Append("UPDATE tags_texts SET text = '");
                    sb.Append(txtText.Text.Trim());
                    sb.Append("', info = '");
                    sb.Append(txtInfo.Text.Trim());
                    sb.Append("' WHERE tags_texts_id = ");
                    sb.Append(this.tags_texts_id);
                    Log.Write(sb.ToString(), this.GetType(), "btnAddEditText_Click", Log.LogType.DEBUG);
                    command.CommandText = sb.ToString();
                    command.ExecuteNonQuery();
                }
                command.CommandText = "SELECT MAX(tags_links_id) FROM tags_links";
                lastIDObject = command.ExecuteScalar();
                int.TryParse(lastIDObject.ToString(), out lastID);
                foreach (Tag tag in lbTextTags.Items)
                {
                    /// Ako treba dodati tag flag je na false
                    if (!tag.Flag)
                    {
                        lastID++;
                        sb.Remove(0, sb.Length);
                        sb.Append("INSERT INTO tags_links (tags_links_id, tags_id, tags_texts_id) VALUES (");
                        sb.Append(lastID);
                        sb.Append(",");
                        sb.Append(tag.ID);
                        sb.Append(",");
                        sb.Append(this.tags_texts_id);
                        sb.Append(")");
                        Log.Write(sb.ToString(), this.GetType(), "btnAddEditText_Click", Log.LogType.DEBUG);
                        Log.Write("Linking tag: " + tag.Name, this.GetType(), "btnAddEditText_Click", Log.LogType.DEBUG);
                        command.CommandText = sb.ToString();
                        result = command.ExecuteNonQuery();
                        Log.Write("Rows afected " + result, this.GetType(), "btnAddEditText_Click", Log.LogType.INFO);
                    }
                }
                foreach (Tag tag in lbTags.Items)
                {
                    /// Ako treba izbrisati tag, flag je true
                    if (tag.Flag)
                    {
                        lastID++;
                        sb.Remove(0, sb.Length);
                        sb.Append("DELETE FROM tags_links WHERE tags_id =");
                        sb.Append(tag.ID);
                        sb.Append(" AND tags_texts_id =");
                        sb.Append(this.tags_texts_id);
                        Log.Write(sb.ToString(), this.GetType(), "btnAddEditText_Click", Log.LogType.DEBUG);
                        command.CommandText = sb.ToString();
                        command.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception exc)
            {
                Log.Write(exc, this.GetType(), "btnAddEditText_Click", Log.LogType.ERROR);
            }
            finally
            {
                if (conn.State == ConnectionState.Open)
                {
                    conn.Close();
                }
            }
        }

        private void btnAddTags_Click(object sender, EventArgs e)
        {
            tags.AddTags(txtTagsAddList.Text, false);
            if (tags_texts_id == 0)
            {
                tags.GetTags("");
                ShowTags(lbTags, false);
            }
            else
            {
                tags.GetTags(tags_texts_id, true);
                ShowTags(lbTags, false);
                tags.GetTags(tags_texts_id, false);
                ShowTags(lbTextTags, true);
            }
            SelectAllTagsInList(txtTagsAddList.Text, lbTags);
            txtTagsAddList.Text = "";
        }
        private void SelectAllTagsInList(string tags, ListBox listBox)
        {
            string[] tagList = tags.Split(new char[] { ' ', ',', ';' }, StringSplitOptions.RemoveEmptyEntries);
            foreach (string tag in tagList)
            {
                for (int i = 0; i < listBox.Items.Count; i++)
                {
                    if (tag.Equals(listBox.Items[i].ToString(), StringComparison.CurrentCultureIgnoreCase))
                    {
                        listBox.SetSelected(i, true);
                        break;
                    }
                }
            }
        }
        public void ImportCSV(string file)
        {
            StreamReader sr = null;
            string[] listStruct;
            string[] listData;
            int counter = 1;
            try
            {
                sr = new StreamReader(file);
                do
                {
                    listData = sr.ReadLine().Split(',');
                    if (counter == 1)
                    {
                        listStruct = listData;
                    }
                    else
                    {
                        // Add text and info in form textboxes, then add tag if is not in base
                        for (int i = 0; i < listData.Length; i++)
                        {
                            if (i == 0)
                            {
                                txtText.Text = listData[i].Replace("<;>", ",");
                            }
                            else if (i == 1)
                            {
                                txtInfo.Text = listData[i].Replace("<;>", ",");
                            }
                            else
                            {
                                tags.AddTags(listData[i], true);
                            }
                        }
                        // Fill all tags in listbox, flag fals tell is not in tags list, is now so it can be !!!
                        tags.GetTags("");
                        ShowTags(lbTags, false);
                        // Swap tags for AllTags listBox in tags list to addet with text
                        lbTextTags.Items.Clear();
                        for (int i = 2; i < listData.Length; i++)
                        {
                            foreach (Tag tag in lbTags.Items)
                            {
                                if (tag.Name == listData[i])
                                {
                                    lbTextTags.Items.Add(tag);
                                    break;
                                }
                            }
                        }
                        // And then create text,info and then attach new tags 
                        this.tags_texts_id = 0;
                        AddEditTextTags();
                        Application.DoEvents();
                    }
                    counter++;
                } while (!sr.EndOfStream);
                Application.DoEvents();
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message, "Import exit with error");
            }
            finally
            {
                sr.Close();
            }
        }
    }
}
