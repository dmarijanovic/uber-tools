using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;

using UberTools.Modules.GenericTemplate.Controls;
using  DamirM.Modules;

namespace UberTools.Modules.GenericTemplate.RowCollectionNS
{
    public class RowCollectionRow
    {
        private ArrayList columnsList;
        public RowCollection rowCollection;

        private int index;

        /// <summary>
        /// Create new instance of row collection row
        /// </summary>
        /// <param name="parent">Parent row collection</param>
        /// <param name="columns">Column values for this row</param>
        public RowCollectionRow(RowCollection parent, string[] columns)
        {
            this.rowCollection = parent;
            try
            {
                columnsList = new ArrayList();
                foreach (string column in columns)
                {
                    AddColl(new RowCollectionColumn(column));
                }
            }
            catch (Exception ex)
            {
                ModuleLog.Write(ex, typeof(RowCollectionRow), "ObjectRow", ModuleLog.LogType.ERROR);
            }
        }
        
        public void AddColl(RowCollectionColumn column)
        {
            //column.Name = "Cols" + (columnsList.Count + 1).ToString();
            column.Name = rowCollection.Columns[columnsList.Count];
            columnsList.Add(column);
        }
        public override string ToString()
        {
            return this.rowCollection.ToString() + "." + this.index;
        }

        public System.Collections.Generic.IEnumerator<RowCollectionColumn> GetEnumerator()
        {
            for (int i = 0; i < columnsList.Count; i++)
            {
                yield return this[i];
            }
        }
        public RowCollectionColumn this[int cellID]
        {
            get
            {
                if (cellID < columnsList.Count)
                {
                    return (RowCollectionColumn)columnsList[cellID];
                }
                else
                {
                    return new RowCollectionColumn();

                }
            }
        }

        public int Index
        {
            get { return this.index; }
            set { this.index = value; }
        }
        public int ColumnCount
        {
            get { return columnsList.Count; }
        }

    }
}
