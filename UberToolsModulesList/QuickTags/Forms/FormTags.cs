using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlServerCe;
using System.Collections;

using DamirM.CommonLibrary;

namespace UberTools.Modules.QuickTags.Forms
{
    public partial class FormTags : Form
    {
        SqlCeConnection conn;
        SqlCeCommand command;
        public FormTags()
        {
            InitializeComponent();
            this.Location = new System.Drawing.Point((Screen.PrimaryScreen.WorkingArea.Width / 2) - (this.Width / 2), 0);
            try
            {
                conn = new SqlCeConnection(Static.ConnectionString);
                command = new SqlCeCommand("", conn);
                dgwPanel.Columns.Add("word", "Word");
                dgwPanel.Columns.Add("info", "Info");
                dgwPanel.Columns["word"].Width = 450;

            }
            catch (Exception exc)
            {
                Log.Write(exc, this.Name, "Tags", Log.LogType.ERROR);
            }
        }

        private void txtSearchBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == 13)
            {
                SearchTags(txtSearchBox.Text);
                txtSearchBox.SelectAll();
                e.SuppressKeyPress = true;
            }
            else if (e.KeyValue == 27)
            {
                e.SuppressKeyPress = true;
            }
        }


        private void SearchTags(string tags)
        {
            SqlCeDataReader dr;
            StringBuilder sb = new StringBuilder();
            string[] tagList = tags.Split(new char[]{' ',',',';'},StringSplitOptions.RemoveEmptyEntries);
            string tags_texts_id_list = "";
            try
            {
                if (conn.State != ConnectionState.Open)
                {
                    conn.Open();
                }
                foreach (string tag in tagList)
                {
                    sb.Remove(0, sb.Length);
                    sb.Append("SELECT tl.tags_texts_id AS id FROM tags_links AS tl ");
                    sb.Append("INNER JOIN tags AS t ON t.tags_id = tl.tags_id ");
                    sb.Append("WHERE t.name = '");
                    sb.Append(tag);
                    sb.Append("'");
                    Log.Write(sb.ToString(), this.Name, "SearchTags", Log.LogType.DEBUG);
                    command.CommandText = sb.ToString();
                    dr = command.ExecuteReader();
                    while (dr.Read())
                    {
                        tags_texts_id_list += dr["id"].ToString() + ",";
                    }
                }
                tags_texts_id_list = Static.GetCountEquls(tags_texts_id_list, new char[] { ',' }, ",", tagList.Length);
                sb.Remove(0, sb.Length);
                sb.Append("SELECT text, info FROM tags_texts WHERE tags_texts_id IN (");
                sb.Append(tags_texts_id_list);
                sb.Append(")");

                //sb.Append("SELECT tt.tags_texts_id AS id, tt.text AS text FROM tags_texts AS tt ");
                //sb.Append("INNER JOIN tags_links AS tl ON tl.tags_texts_id = tt.tags_texts_id ");
                //sb.Append("INNER JOIN tags AS t ON t.tags_id = tl.tags_id ");
                //if (tagList.Length > 0)
                //{
                //    sb.Append("WHERE (t.tags_id IN (SELECT tags_id FROM tags WHERE ");
                //    foreach (string tag in tagList)
                //    {
                //        sb.Append("t.name = '");
                //        sb.Append(tag);
                //        sb.Append("' OR ");
                //    }
                //    sb.Remove(sb.Length - 3, 3);
                //    sb.Append(")) ");
                //}
                //sb.Append("GROUP BY tt.tags_texts_id, tt.text");
                dgwPanel.Rows.Clear();
                Log.Write(sb.ToString(), this.Name, "SearchTags", Log.LogType.DEBUG);
                if (tags_texts_id_list != "")
                {
                     command.CommandText = sb.ToString();
                    dr = command.ExecuteReader();
                    while (dr.Read())
                    {
                        DataGridViewRow row = dgwPanel.Rows[dgwPanel.Rows.Add()];
                        row.Cells["word"].Value = dr["text"].ToString();
                        row.Cells["info"].Value = dr["info"].ToString();
                    }
                }
            }
            catch (Exception exc)
            {
                Log.Write(exc, this.Name, "SearchTags", Log.LogType.ERROR);
            }
            finally
            {
                if (conn.State == ConnectionState.Open)
                {
                    conn.Close();
                }
            }
        }


        private void Tags_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == 27)
            {
                this.Hide();
            }
        }

        private void FormTags_Activated(object sender, EventArgs e)
        {
            txtSearchBox.Focus();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            SearchTags(txtSearchBox.Text);
            txtSearchBox.SelectAll();
        }














    }
}
