using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using DamirM.CommonLibrary;
using UberTools.Modules.GenericTemplate.RowCollectionNS;

namespace UberTools.Modules.GenericTemplate
{
    public partial class RowCollectionFilterItem : UserControlBase
    {
        private RowCollection rowCollection;

        public event EventHandler Close;


        public enum ActionType
        {
            Equals, GreaterThan, LessThan, GreaterThanEquals, LessThanEquals, NotEquals, RegEx, EqualsIgnoreCase, NotEqualsIgnoreCase, NotEmpty
        }
        public enum LogicalOperatorType
        {
            AND, OR
        }
        public RowCollectionFilterItem(RowCollection rowCollection)
        {
            InitializeComponent();

            this.rowCollection = rowCollection;

            FillColumnList();
            cbColumn.SelectedIndex = 0;
            cbAction.SelectedIndex = 0;
            cbLogicalGroup.SelectedIndex = 0;
            cbLogicalOperator.SelectedIndex = 0;
        }
        public RowCollectionFilterItem()
        {
            InitializeComponent();

            this.rowCollection = null;

        }

        protected override void OnPaint(PaintEventArgs pe)
        {
            base.OnPaint(pe);
        }
        /// <summary>
        /// Fill combo box with names of columns from row collection object
        /// </summary>
        private void FillColumnList()
        {
            cbColumn.Items.Clear();
            foreach (string column in this.rowCollection.Columns)
            {
                cbColumn.Items.Add(column);
            }
        }

        public override string ToString()
        {
            return this.Name;
        }

        private void bCloseItem_Click(object sender, EventArgs e)
        {
            if (Close != null)
            {
                Close(this, new EventArgs());
            }
        }

        public int ColumnID
        {
            get
            {
                if (cbColumn.SelectedIndex != -1)
                {
                    return cbColumn.SelectedIndex;
                }
                else
                {
                    return -1;
                }
            }
        }
        public ActionType Action
        {
            get
            {
                string actionText = cbAction.SelectedIndex != -1? cbAction.Items[cbAction.SelectedIndex].ToString():"";

                if(actionText.Equals("=")){
                    return ActionType.Equals;
                }
                else if(actionText.Equals(">")){
                    return ActionType.GreaterThan;
                }
                else if(actionText.Equals("<")){
                    return ActionType.LessThan;
                }
                else if(actionText.Equals(">=")){
                    return ActionType.GreaterThanEquals;
                }
                else if(actionText.Equals("<=")){
                    return ActionType.LessThanEquals;
                }
                else if(actionText.Equals("!=")){
                    return ActionType.NotEquals;
                }
                else if(actionText.Equals("RegEx")){
                    return ActionType.RegEx;
                }
                else if (actionText.Equals("EqualsIgnoreCase"))
                {
                    return ActionType.EqualsIgnoreCase;
                }
                else if (actionText.Equals("NotEqualsIgnoreCase"))
                {
                    return ActionType.NotEqualsIgnoreCase;
                }
                else if(actionText.Equals("Not empty")){
                    return ActionType.NotEmpty;
                }
                else{
                    throw new Exception("ActionType unknown in Row Collection filter item");
            	}
            }
        }
        public string Value
        {
            get
            {
                return tbValue.Text;
            }
        }
        public int LogicalGroup
        {
            get { return int.Parse(cbLogicalGroup.Items[cbLogicalGroup.SelectedIndex].ToString()); }
        }
        public LogicalOperatorType LogicalOperator
        {
            get 
            {
                if (cbLogicalOperator.Items[cbLogicalOperator.SelectedIndex].ToString().ToLower().Equals("and"))
                {
                    return LogicalOperatorType.AND;
                }
                else
                {
                    return LogicalOperatorType.OR;
                }
            }
        }
    }
}
