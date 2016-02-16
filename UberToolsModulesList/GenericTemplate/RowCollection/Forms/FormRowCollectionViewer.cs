using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Collections;
using UberTools.Modules.GenericTemplate.Class;

using UberTools.Modules.GenericTemplate.Controls;
using  DamirM.Modules;

namespace UberTools.Modules.GenericTemplate.RowCollectionNS
{
    public partial class FormRowCollectionViewer : Form
    {
        RowCollection rowCollection;

        public FormRowCollectionViewer(RowCollection rowCollection)
        {
            InitializeComponent();
            this.rowCollection = rowCollection;
            try
            {
                this.Text = string.Format("Data view - [{0}]", rowCollection.Name);
                CreateColumnsAndControls();
                ShowData();
            }
            catch (Exception ex)
            {
                ModuleLog.Write(ex, this, "RowCollectionViewer", ModuleLog.LogType.ERROR);
            }
        }

        private void CreateColumnsAndControls()
        {
            DataGridViewRow dgvRow;
            DataGridViewTextBoxCell dgvCell;
            DataGridViewCellStyle style = new DataGridViewCellStyle();

            style.BackColor = Color.Cyan;
            for (int i = 0; i < rowCollection.Columns.Count; i++)
            {
                //dgvColumn = new DataGridViewColumn();
                //dgvColumn.Name = rowCollection.GetColumnName(i);
                //dgvColumn.HeaderText = rowCollection.GetColumnName(i);
                //dgvGrid.Columns.AddRange(dgvColumn);
                dgvGrid.Columns.Add(rowCollection.Columns[i], rowCollection.Columns[i]);
            }
            //dgvRow = new DataGridViewRow();
            //dgvRow.Frozen = true;
            //for (int i = 0; i < rowCollection.ColumnCount; i++)
            //{
            //    dgvCell = new DataGridViewTextBoxCell();
            //    dgvCell.Style = style;
            //    dgvRow.Cells.Add(dgvCell);
            //}
            //dgvGrid.Rows.Add(dgvRow);
        }


        public void ShowData()
        {
            DataGridViewRow rowData;
            foreach (RowCollectionRow row in rowCollection.Rows)
            {
                rowData = dgvGrid.Rows[dgvGrid.Rows.Add()];
                foreach (RowCollectionColumn cell in row)
                {
                    rowData.Cells[cell.Name].Value = cell.ValueNoExcape;
                }
            }
        }
    }
}
