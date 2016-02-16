using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlServerCe;
using System.Collections;
using Gma.UserActivityMonitor;
using System.IO;

using DamirM.Controls;
using DamirM.CommonLibrary;
using DamirM.Modules;

namespace UberTools.Modules.QuickTags.Forms
{
    public partial class ModuleMainForm : ModuleMainFormBase
    {
        SqlCeConnection conn;
        SqlCeCommand command;
        KeyEventArgs keyEventsArgs = null;
        FormTags formTags = new FormTags();
        public ModuleMainForm()
        {
            InitializeComponent();
            try
            {
                // make data folder for this module
                Common.MakeAllSubFolders(Static.DataFolderPath);
                // check sdf database file, and copy new if dont exists
                Static.CheckDB_SDF();

                conn = new SqlCeConnection(Static.ConnectionString);
                command = new SqlCeCommand("", conn);
                dgwPanel.Columns.Add("tag", "Tag");
                dgwPanel.Columns.Add("info", "Info");
                DataGridViewButtonColumn btnColl1 = new DataGridViewButtonColumn();
                btnColl1.HeaderText = "Edit";
                btnColl1.Name = "Edit";
                dgwPanel.Columns.Add(btnColl1);
                keyEventsArgs = new KeyEventArgs(Keys.Oemtilde | Keys.Control);
                HookManager.KeyDown += new KeyEventHandler(HookManager_KeyDown);      
            }
            catch (Exception exc)
            {
                Log.Write(exc, this.Name, "ModuleMainForm", Log.LogType.ERROR);
            }
        }

        void HookManager_KeyDown(object sender, KeyEventArgs e)
        {
            //if ((e.Control && e.KeyCode == Keys.Oemtilde) && !formTags.Visible)
            if ((FormKeyMarge.CompareKeyEventAtgs(e, keyEventsArgs)) && !formTags.Visible)
            {
                formTags.Show();

            }
            //Log.Write(e.Control + ", " + e.Alt + ", " + e.Shift + " - " + e.KeyData);
        }

        private void btnShowTags_Click(object sender, EventArgs e)
        {
            ShowTagsTexts(txtSearchBox.Text);
        }
        private void txtSearchBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == 13)
            {
                ShowTagsTexts(txtSearchBox.Text);
                txtSearchBox.SelectAll();
                e.SuppressKeyPress = true;
            }
        }

        private void ShowTagsTexts(string tagsText)
        {
            Tags tags = new Tags();
            dgwPanel.Rows.Clear();
            Application.DoEvents();
            if (rbShowTags.Checked)
            {
                tags.GetTags(tagsText);
            }
            else if (rbShowTexts.Checked)
            {
                tags.GetTexts(tagsText);
            }
            foreach (Tag tag in tags.List)
            {
                DataGridViewRow row = dgwPanel.Rows[dgwPanel.Rows.Add()];
                row.Cells["tag"].Value = tag.Name;
                row.Cells["tag"].Tag = tag.ID;
                row.Cells["info"].Value = tag.Info;
                row.Cells["Edit"].Value = "Edit";
            }
        }

        private void btnAddTags_Click(object sender, EventArgs e)
        {
            Tags tags = new Tags();
            InputBox form = new InputBox("Add tags", "Add tags seperated by ;", "tag1;tag2;tag3");
            DialogResult result = form.ShowDialog(this);
            if (result == DialogResult.OK)
            {
                tags.AddTags(form.InputTekst, false);
            }
        }

        private void btnAddText_Click(object sender, EventArgs e)
        {
            Form form = new FormTagsEdit();
            form.ShowDialog(this);
        }

        private void dgwPanel_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex > -1 && e.RowIndex < dgwPanel.Rows.Count - 1)
            {
                string imeColumne = dgwPanel.Columns[e.ColumnIndex].Name;
                if (imeColumne == "Edit")
                {
                    int id = int.Parse(dgwPanel.Rows[e.RowIndex].Cells["tag"].Tag.ToString());
                    if (rbShowTags.Checked)
                    {
                        
                    }
                    else if (rbShowTexts.Checked)
                    {
                        FormTagsEdit form = new FormTagsEdit(id);
                        form.ShowDialog(this);
                    }
                }
            }
        }

        private void FormTagsMain_FormClosed(object sender, FormClosedEventArgs e)
        {
            HookManager.KeyDown -= HookManager_KeyDown;
            formTags.Close();
        }

        private void btnImport_Click(object sender, EventArgs e)
        {
            DialogResult result = openFileDialog1.ShowDialog(this);
            if (result == DialogResult.OK)
            {
                FormTagsEdit file = new FormTagsEdit();
                file.ImportCSV(openFileDialog1.FileName);
                file.Close();
            }
        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            Tags tags = new Tags();
            ArrayList list = new ArrayList();
            DialogResult result = saveFileDialog1.ShowDialog(this);

            if(result == DialogResult.OK)
            {
                StreamWriter sw = null;
                try
                {
                    sw = new StreamWriter(saveFileDialog1.FileName, false, Encoding.UTF8);
                    if (rbShowTags.Checked)
                    {
                        list = tags.GetTags(txtSearchBox.Text);
                        sw.WriteLine("tag,info");
                        foreach (Tag tag in list)
                        {
                            sw.WriteLine(tag.Name + "," + tag.Info.Replace(",", "<;>"));
                        }

                    }
                    else if (rbShowTexts.Checked)
                    {

                    }
                }
                catch (Exception exc)
                {
                    Log.Write(exc, this.Name, "btnExport_Click", Log.LogType.ERROR);
                }
                finally
                {
                    sw.Close();
                }
            }
        }

        private void btnSettings_Click(object sender, EventArgs e)
        {
            FormKeyMarge form = new FormKeyMarge(this.keyEventsArgs);
            form.ShowDialog();
            if (form.DialogResult == DialogResult.OK)
            {
                keyEventsArgs = form.KeyEventArgs;
            }
        }


    }
    class Tags
    {
        SqlCeConnection conn;
        SqlCeCommand command;
        ArrayList list;
        public Tags()
        {
            try
            {
                conn = new SqlCeConnection(Static.ConnectionString);
                command = new SqlCeCommand("", conn);

            }
            catch (Exception exc)
            {
                Log.Write(exc, this.GetType(), "Tags", Log.LogType.ERROR);
            }
        }
        public ArrayList GetTags(string tags)
        {
            list = new ArrayList();
            SqlCeDataReader dr;
            StringBuilder sb = new StringBuilder();
            int counter = 0;
            string[] tagList = tags.Split(new char[] { ' ', ',', ';' }, StringSplitOptions.RemoveEmptyEntries);
            try
            {
                if (conn.State != ConnectionState.Open)
                {
                    conn.Open();
                }
                Log.Write(conn.State + ":" + conn.DataSource, this.GetType(), "ShowTags", Log.LogType.DEBUG);
                sb.Append("SELECT * FROM tags AS t ");
                if (tagList.Length > 0)
                {
                    sb.Append("WHERE (");
                    foreach (string tag in tagList)
                    {
                        sb.Append("t.name = '");
                        sb.Append(tag);
                        sb.Append("' OR ");
                    }
                    sb.Remove(sb.Length - 3, 3);
                    sb.Append(") ");
                }
                sb.Append("ORDER BY t.name");
                Log.Write(sb.ToString(), this.GetType(), "ShowTags", Log.LogType.DEBUG);
                command.CommandText = sb.ToString();
                dr = command.ExecuteReader();
                while (dr.Read())
                {
                    list.Add(new Tag(dr["name"].ToString(), "", int.Parse(dr["tags_id"].ToString()), counter));
                    counter++;
                }
            }
            catch (Exception exc)
            {
                Log.Write(exc, this.GetType(), "ShowTags", Log.LogType.ERROR);
            }
            finally
            {
                if (conn.State == ConnectionState.Open)
                {
                    conn.Close();
                }
            }
            return list;
        }
        public ArrayList GetTags(int tags_texts_id, bool dontShowForThisID)
        {
            list = new ArrayList();
            SqlCeDataReader dr;
            StringBuilder sb = new StringBuilder();
            int counter = 0;
            try
            {
                if (conn.State != ConnectionState.Open)
                {
                    conn.Open();
                }
                sb.Append("SELECT t.tags_id AS tags_id, t.name AS name, t.info AS info FROM tags AS t ");
                if (dontShowForThisID)
                {
                    sb.Append("LEFT JOIN tags_links AS tl ON tl.tags_id = t.tags_id ");
                    sb.Append("WHERE (tl.tags_id NOT IN  (SELECT tags_id FROM tags_links WHERE tags_texts_id = ");
                    sb.Append(tags_texts_id);
                    sb.Append(")) OR  (tl.tags_texts_id IS NULL) GROUP BY t.tags_id, t.name, t.info");
                }
                else
                {
                    sb.Append("INNER JOIN tags_links AS tl ON tl.tags_id = t.tags_id ");
                    sb.Append("WHERE tl.tags_texts_id ");
                    sb.Append(" = ");
                    sb.Append(tags_texts_id);
                }
                sb.Append(" ORDER BY t.name");
                Log.Write(sb.ToString(), this.GetType(), "ShowTags", Log.LogType.DEBUG);
                command.CommandText = sb.ToString();
                dr = command.ExecuteReader();
                while (dr.Read())
                {
                    list.Add(new Tag(dr["name"].ToString(), dr["info"].ToString(), int.Parse(dr["tags_id"].ToString()), counter));
                    counter++;
                }
            }
            catch (Exception exc)
            {
                Log.Write(exc, this.GetType(), "ShowTags", Log.LogType.ERROR);
            }
            finally
            {
                if (conn.State == ConnectionState.Open)
                {
                    conn.Close();
                }
            }
            return list;
        }
        public ArrayList GetTexts(string tags)
        {
            list = new ArrayList();
            SqlCeDataReader dr;
            StringBuilder sb = new StringBuilder();
            int counter = 0;
            string[] tagList = tags.Split(new char[] { ' ', ',', ';' }, StringSplitOptions.RemoveEmptyEntries);
            try
            {
                if (conn.State != ConnectionState.Open)
                {
                    conn.Open();
                }
                Log.Write(conn.State + ":" + conn.DataSource, this.GetType(), "ShowTags", Log.LogType.DEBUG);
                sb.Append("SELECT tt.tags_texts_id AS id, tt.text AS text, tt.info AS info FROM tags_texts AS tt ");
                sb.Append("LEFT JOIN tags_links AS tl ON tl.tags_texts_id = tt.tags_texts_id ");
                sb.Append("LEFT JOIN tags AS t ON t.tags_id = tl.tags_id ");
                if (tagList.Length > 0)
                {
                    sb.Append("WHERE (");
                    foreach (string tag in tagList)
                    {
                        sb.Append("t.name = '");
                        sb.Append(tag);
                        sb.Append("' OR ");
                    }
                    sb.Remove(sb.Length - 3, 3);
                    sb.Append(") ");
                }
                sb.Append("GROUP BY tt.tags_texts_id, tt.text, tt.info");
                Log.Write(sb.ToString(), this.GetType(), "ShowTags", Log.LogType.DEBUG);
                command.CommandText = sb.ToString();
                dr = command.ExecuteReader();
                while (dr.Read())
                {
                    list.Add(new Tag(dr["text"].ToString(), dr["info"].ToString(), int.Parse(dr["id"].ToString()), counter));
                    counter++;
                }
            }
            catch (Exception exc)
            {
                Log.Write(exc, this.GetType(), "ShowTags", Log.LogType.ERROR);
            }
            finally
            {
                if (conn.State == ConnectionState.Open)
                {
                    conn.Close();
                }
            }
            return list;
        }
        public void AddTags(string tags, bool quietly)
        {
            string[] tagList = tags.Split(new char[] { ';' }, StringSplitOptions.RemoveEmptyEntries);
            string sql = "";
            object lastIDObject = null;
            int lastID = 0;
            int tagsAddedNumber = 0;
            try
            {
                if (!TagsFormatOK(tags))
                {
                    foreach (string tag in tagList)
                    {
                        if (CountTags(tag) == 0)
                        {
                            if (conn.State != ConnectionState.Open)
                            {
                                conn.Open();
                            }
                            command.CommandText = "SELECT MAX(tags_id) FROM tags";
                            lastIDObject = command.ExecuteScalar();
                            int.TryParse(lastIDObject.ToString(), out lastID);
                            lastID++;
                            Log.Write("lastID=" + lastID.ToString(), this.GetType(), "AddTags", Log.LogType.DEBUG);
                            sql = "INSERT INTO tags (tags_id,name) VALUES (" + lastID + ",'" + tag + "')";
                            Log.Write(sql, this.GetType(), "AddTags", Log.LogType.DEBUG);
                            command.CommandText = sql;
                            command.ExecuteNonQuery();
                            tagsAddedNumber++;
                        }
                        else
                        {
                            Log.Write("Tag already exists - " + tag, this.GetType(), "AddTags", Log.LogType.INFO);
                        }
                    }
                }
                if (!quietly)
                {
                    MessageBox.Show("Added " + tagsAddedNumber + " tags", "Tags added", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception exc)
            {
                Log.Write(exc, this.GetType(), "AddTags", Log.LogType.ERROR);
            }
            finally
            {
                if (conn.State == ConnectionState.Open)
                {
                    conn.Close();
                }
            }
        }
        private int CountTags(string searchValue)
        {
            SqlCeDataReader dr = null;
            string sql = "";
            int result = 0;
            try
            {
                if (conn.State != ConnectionState.Open)
                {
                    conn.Open();
                }
                sql = "SELECT tags_id FROM tags WHERE name = '" + searchValue + "'";
                Log.Write(sql, this.GetType(), "CountTags", Log.LogType.DEBUG);
                command.CommandText = sql;
                dr = command.ExecuteReader();
                if (dr.Read())
                {
                    result = int.Parse(dr["tags_id"].ToString());
                }
            }
            catch (Exception exc)
            {
                Log.Write(exc, this.GetType(), "CountRows", Log.LogType.ERROR);
            }
            finally
            {
                if (conn.State == ConnectionState.Open)
                {
                    conn.Close();
                }
            }
            return result;
        }
        public bool TagsFormatOK(string tags)
        {
            return tags.Contains(' ') || tags.Contains(',') || tags.Contains(':');
        }
        public ArrayList List
        {
            get { return list; }
        }
    }
    class Tag
    {
        private string name;
        private string info;
        private int id;
        private int index;
        private bool show;
        private bool flag;
        public Tag(string name, string info,int id, int index)
        {
            this.name = name;
            this.info = info;
            this.id = id;
            this.index = index;
            this.show = true;
            this.flag = false;
        }
        public string Name
        {
            get { return this.name; }
        }
        public string Info
        {
            get { return this.info; }
        }

        public int ID
        {
            get { return this.id; }
        }
        public int Index
        {
            get { return this.index; }
        }
        public bool Show
        {
            get { return this.show; }
            set { this.show = value; }
        }
        public bool Flag
        {
            get { return this.flag; }
            set { this.flag = value; }
        }
        public override string ToString()
        {
            return this.name;
        }

    }
}
