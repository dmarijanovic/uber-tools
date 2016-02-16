using System;
using System.Collections.Generic;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Text.RegularExpressions;

using DamirM.CommonLibrary;

namespace UberTools.Modules.GenericTemplate.RowCollectionNS
{
    public partial class RowCollectionFilterDialog : Form
    {
        const string CONST_LOG_NAME = "Filter data object";

        ArrayList filtersItems;
        RowCollection rowCollection;

        public RowCollectionFilterDialog(RowCollection rowCollection)
        {
            InitializeComponent();

            this.rowCollection = rowCollection;
            filtersItems = new ArrayList();
        }

        private void bAdd_Click(object sender, EventArgs e)
        {
            try
            {
                AddFilterItem();
            }
            catch (Exception ex)
            {
                Log.Write(ex, this, CONST_LOG_NAME, Log.LogType.ERROR);
            }
        }
        private void bCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void bOK_Click(object sender, EventArgs e)
        {
            RowCollection outputRowCollection = null;
            // disable form
            this.bOK.Enabled = false;
            try
            {
                if (cbOutputInNewRowCollection.Checked == true)
                {
                    // create new output row collection object
                    outputRowCollection = this.rowCollection.RowCollectionMenager.CreateRowCollection(this.rowCollection.Columns.Count);
                    // init column names
                    for (int i = 0; i < this.rowCollection.Columns.Count; i++)
                    {
                        outputRowCollection.Columns[i] = this.rowCollection.Columns[i];
                    }
                }

                // check each row agenst filters
                foreach (RowCollectionRow row in this.rowCollection.Rows)
                {
                    if (TestAgenstFilters(row) == true)
                    {
                        if (cbOutputInNewRowCollection.Checked == true)
                        {
                            outputRowCollection.Rows.Add(row);
                        }
                    }
                }

                MessageBox.Show(string.Format("Filterd {0} from {1} with this filter settings and saved in new data object named {2}", outputRowCollection.Rows.Count, rowCollection.Rows.Count, outputRowCollection.Name), "Filter output", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                Log.Write(ex, this, CONST_LOG_NAME, Log.LogType.ERROR);
            }
            this.Close();
        }
        private void bTestOutput_Click(object sender, EventArgs e)
        {
            int counterFilterd = 0;
            try
            {
                foreach (RowCollectionRow row in this.rowCollection.Rows)
                {
                    if (TestAgenstFilters(row) == true)
                    {
                        counterFilterd++;
                    }
                }

                MessageBox.Show(string.Format("Filterd {0} from {1} with this filter settings", counterFilterd, rowCollection.Rows.Count), "Filter test", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                Log.Write(ex, this, CONST_LOG_NAME, Log.LogType.ERROR);
            }
        }

        private bool TestAgenstFilters(RowCollectionRow row)
        {
            bool resultAction;
            bool resultActionLastAnd = false;
            bool haveAndLogicalInThisGroup;

            for (int i = 0; i <= 9; i++)
            {
                haveAndLogicalInThisGroup = false;
                foreach (RowCollectionFilterItem filter in filtersItems)
                {
                    if (filter.LogicalGroup == i)
                    {
                        // test action agens value
                        resultAction = TestAgenstFilterAction(filter, row[filter.ColumnID].Value);
                        if (filter.LogicalOperator == RowCollectionFilterItem.LogicalOperatorType.OR)
                        {
                            if (resultAction == true)
                            {
                                return true;
                            }
                        }
                        else if (filter.LogicalOperator == RowCollectionFilterItem.LogicalOperatorType.AND)
                        {
                            if (haveAndLogicalInThisGroup == true && resultActionLastAnd == false)
                            {
                                break;
                            }
                            haveAndLogicalInThisGroup = true;
                            resultActionLastAnd = resultAction;
                        }

                    }
                }

                if (haveAndLogicalInThisGroup == true && resultActionLastAnd == true)
                {
                    return true;
                }
            }

            return false;
        }

        private bool TestAgenstFilterAction(RowCollectionFilterItem filter,string value)
        {
            bool result = false;
            int valueAsNumber;
            int valueFromFilterAsnumber;

            if (filter.Action == RowCollectionFilterItem.ActionType.Equals)
            {
                result = filter.Value.Equals(value);
            }
            else if (filter.Action == RowCollectionFilterItem.ActionType.NotEquals)
            {
                result = !filter.Value.Equals(value);
            }
            else if (filter.Action == RowCollectionFilterItem.ActionType.EqualsIgnoreCase)
            {
                result = filter.Value.ToLower().Equals(value.ToLower());
            }
            else if (filter.Action == RowCollectionFilterItem.ActionType.NotEqualsIgnoreCase)
            {
                result = !filter.Value.ToLower().Equals(value.ToLower());
            }
            else if (filter.Action == RowCollectionFilterItem.ActionType.GreaterThan)
            {
                int.TryParse(value, out valueAsNumber);
                int.TryParse(filter.Value, out valueFromFilterAsnumber);
                result = valueAsNumber > valueFromFilterAsnumber;
            }
            else if (filter.Action == RowCollectionFilterItem.ActionType.GreaterThanEquals)
            {
                int.TryParse(value, out valueAsNumber);
                int.TryParse(filter.Value, out valueFromFilterAsnumber);
                result = valueAsNumber >= valueFromFilterAsnumber;
            }
            else if (filter.Action == RowCollectionFilterItem.ActionType.LessThan)
            {
                int.TryParse(value, out valueAsNumber);
                int.TryParse(filter.Value, out valueFromFilterAsnumber);
                result = valueAsNumber < valueFromFilterAsnumber;
            }
            else if (filter.Action == RowCollectionFilterItem.ActionType.LessThanEquals)
            {
                int.TryParse(value, out valueAsNumber);
                int.TryParse(filter.Value, out valueFromFilterAsnumber);
                result = valueAsNumber <= valueFromFilterAsnumber;
            }
            else if (filter.Action == RowCollectionFilterItem.ActionType.NotEmpty)
            {
                result = !value.Equals("");
            }
            else if (filter.Action == RowCollectionFilterItem.ActionType.RegEx)
            {
                Regex regex = new Regex(filter.Value);

                if (regex.IsMatch(value))
                {
                    result = true;
                }
                else
                {
                    result = false;
                }
            }
            return result;
        }

        /// <summary>
        /// Create new control and add it to collection
        /// </summary>
        private void AddFilterItem()
        {
            RowCollectionFilterItem rowCollectionFilterItem = new RowCollectionFilterItem(this.rowCollection);

            // init control
            rowCollectionFilterItem.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right | System.Windows.Forms.AnchorStyles.Top)));
            rowCollectionFilterItem.Location = new System.Drawing.Point(3, 3);
            rowCollectionFilterItem.Name = "rowCollectionFilterItem " + this.filtersItems.Count;
            rowCollectionFilterItem.Size = new System.Drawing.Size(this.panel1.Width, 32);
            rowCollectionFilterItem.TabIndex = 0;
            rowCollectionFilterItem.ParentControl = null;

            if (this.filtersItems.Count != 0)
            {
                rowCollectionFilterItem.UpControl = (RowCollectionFilterItem)this.filtersItems[this.filtersItems.Count - 1];
            }
            else
            {
                rowCollectionFilterItem.UpControl = null;
            }
            rowCollectionFilterItem.DownControl = null;

            // subscribe to events
            rowCollectionFilterItem.Close += new EventHandler(RemoveFilterItem);

            // add new control to place holder
            this.panel1.Controls.Add(rowCollectionFilterItem);

            // add it to filterItems menager
            filtersItems.Add(rowCollectionFilterItem);
        }
        /// <summary>
        /// Remove filter ithem from collection
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void RemoveFilterItem(object sender,EventArgs e)
        {
            RowCollectionFilterItem rowCollectionFilterItem;
            try
            {
                rowCollectionFilterItem = (RowCollectionFilterItem)sender;
                // remove item from filterItems menager
                this.filtersItems.Remove(rowCollectionFilterItem);
                // remove this item from place holder
                this.panel1.Controls.Remove(rowCollectionFilterItem);
                // call remove method
                rowCollectionFilterItem.Remove();
            }
            catch (Exception ex)
            {
                Log.Write(ex, this, CONST_LOG_NAME, Log.LogType.ERROR);
            }
        }
    }
}
