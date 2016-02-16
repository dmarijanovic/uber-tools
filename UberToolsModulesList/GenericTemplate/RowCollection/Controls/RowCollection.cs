using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using System.Collections;

using DamirM.Controls;
using DamirM.Class;
using UberTools.Modules.GenericTemplate.Forms;
using UberTools.Modules.GenericTemplate.Class;
using DamirM.CommonLibrary;

using DamirM.Modules;


namespace UberTools.Modules.GenericTemplate.RowCollectionNS
{
    public partial class RowCollection : UserControlBase
    {
        ObjectCollectionRows objectCollectionRows;
        ObjectCollectionColumns objectCollectionColumns;
        RowCollectionHelper rowCollectionHelper;
        RowCollectionMenager rowCollectionMenager;  // menager for this object

        // default prefix name
        public const string const_prefix = "Data";
        public const string const_prefix_column = "C";

        private int curentRowIndex = 0;
        private int[] positionColumn;
        private int startAt = 0;
        private int endAt = 0;
        private int increment = 0;

        public RowCollection(RowCollectionMenager rowCollectionMenager, int columnCount, string name)
        {
            InitializeComponent();
            this.objectCollectionRows = new ObjectCollectionRows(rowCollectionMenager, this);
            this.objectCollectionColumns = new ObjectCollectionColumns(columnCount);
            // set RowCollectionMenager for this instance
            this.rowCollectionMenager = rowCollectionMenager;
            // new instance of RowCollectionHelper
            rowCollectionHelper = new RowCollectionHelper(this);
            // bind filter menu to rowCollectionHelper
            tsmFilter.Click += new EventHandler(rowCollectionHelper.ShowFilter);
            // bind group by menu to rowCollectionHelper
            tsmGroupBy.Click += new EventHandler(rowCollectionHelper.GroupBy);

            this.positionColumn = new int[columnCount];
            lObjectName.Text = name;
            ttToolTip.SetToolTip(lObjectName, name);
            this.Name = name;
            cbPriority.SelectedIndex = 0;
        }

        private void bWork_Click(object sender, EventArgs e)
        {
            try
            {
                cmsMenu.Show((Control)sender, new Point(0, ((Control)sender).Height));
            }
            catch (Exception exc)
            {
                ModuleLog.Write(exc, this, "bWork_Click", ModuleLog.LogType.ERROR);
            }
        }
        private void bMakeChild_Click(object sender, EventArgs e)
        {
            // this instance will become child of top control object
            if (this.UpControl != null)
            {
                // this control have top control object
                this.UpControl.AddChild(this);
            }
        }
        private void btnShow_Click(object sender, EventArgs e)
        {
            try
            {
                this.SetSettings();
                FormRowCollectionViewer form = new FormRowCollectionViewer(this);
                form.Show(this);
                //form.ShowData(rowList, 0);
            }
            catch (Exception ex)
            {
                ModuleLog.Write(ex, this, "btnShow_Click", ModuleLog.LogType.ERROR);
            }
        }
        private void bUnload_Click(object sender, EventArgs e)
        {
            this.Remove();
            //this.Remove(this);
        }

        private void tsmSaveAs_Click(object sender, EventArgs e)
        {
            InputBox inputBox;
            RowCollectionIO rowCollectionIO;
            string dataObjectPath;

            inputBox = new InputBox("Save data object", "Enter name for new data object");
            inputBox.ShowDialog(Application.OpenForms[0]);

            if (inputBox.DialogResult == DialogResult.OK)
            {
                dataObjectPath = Common.BuildPath(GenericTemplate.moduleParams.DataPath, GenericTemplate.constModuleDataFolder, GenericTemplate.constDataObjectsFolder);
                Common.MakeAllSubFolders(dataObjectPath);
                rowCollectionIO = new RowCollectionIO(dataObjectPath + inputBox.InputTekst + ".xml");

                rowCollectionIO.Save(this);
            }
        }


        public void SetSettings()
        {
            try
            {
                // Try parse all values
                this.startAt = int.Parse(tbStartAt.Text);
                this.endAt = int.Parse(tbEndAt.Text);
                this.increment = int.Parse(tbIncrement.Text);

                // Hendle start value 
                if (this.startAt == 0)
                {
                    this.startAt = Rows.Count - 1;
                }
                else if (this.startAt > Rows.Count)
                {
                    this.startAt = Rows.Count - 1;
                    ModuleLog.Write("Start at is greater then row count, reseting", this, "SetSettings", ModuleLog.LogType.WARNING);
                }
                else
                {
                    this.startAt--;
                }

                // Hendle end value
                if (this.endAt == 0)
                {
                    this.endAt = Rows.Count;
                }
                else if (this.endAt > Rows.Count)
                {
                    this.endAt = Rows.Count;
                    ModuleLog.Write("End at is greater then row count, reseting", this, "SetSettings", ModuleLog.LogType.WARNING);
                }
                else
                {
                    this.endAt--;
                }


                // Set corent position
                this.curentRowIndex = -1; // startAt;

                // Hendle increment value
                if (this.increment == 0)
                {
                    this.increment = 1;
                    ModuleLog.Write("Increment value can not be zero", this, "SetSettings", ModuleLog.LogType.WARNING);
                }

                // Column position row counter
                for (int i = 0; i < positionColumn.Length; i++)
                {
                    positionColumn[i] = startAt;
                }
            }
            catch (Exception exc)
            {
                this.startAt = 0;
                this.endAt = 0;
                this.increment = 0;
                this.curentRowIndex = 0;
                ModuleLog.Write(exc, this, "SetSettings", ModuleLog.LogType.ERROR);
            }
        }
        public override string ToString()
        {
            return this.lObjectName.Text;
        }

        public void ResetAllChildCurentRowIndex(int value)
        {
            foreach (RowCollection userControlBase in (IEnumerable<UserControlBase>)this)
            {
                userControlBase.ResetAllChildCurentRowIndex(value);
            }
        }

        public RowCollectionMenager RowCollectionMenager
        {
            get
            {
                return this.rowCollectionMenager;
            }
        }
        public ObjectCollectionRows Rows
        {
            get
            {
                return this.objectCollectionRows;
            }
        }
        public ObjectCollectionColumns Columns
        {
            get { return this.objectCollectionColumns; }
        }

        public string LabelName
        {
            get { return this.lblname.Text; }
            set { this.lblname.Text = value; }
        }


        /// <summary>
        /// If is true, new rows will not be added to list, same columns number will be ignored and create new object
        /// </summary>
        public bool Lock
        {
            get
            {
                return cbLock.Checked;
            }
            set
            {
                cbLock.Checked = value;
            }
        }
        public bool Repeat
        {
            get { return cbRepeat.Checked; }
        }
        public bool Selected
        {
            get
            {
                return cbUseIt.Checked;
            }
        }
        public int Priority
        {
            get
            {
                int priority;
                int.TryParse(cbPriority.Text, out priority);
                return priority;
            }
        }



        public class ObjectCollectionRows
        {
            RowCollection rowCollection;
            RowCollectionMenager rowCollectionMenager;
            ArrayList rowList = new ArrayList();

            public ObjectCollectionRows(RowCollectionMenager rowCollectionMenager, RowCollection rowCollection)
            {
                this.rowCollection = rowCollection;
                this.rowCollectionMenager = rowCollectionMenager;
            }

            public void Add(RowCollectionRow row)
            {
                row.rowCollection = this.rowCollection;
                row.Index = rowList.Count;
                rowList.Add(row);
                this.rowCollection.LabelName = "Columns count:" + row.ColumnCount + ", Row count: " + rowList.Count.ToString();
                this.rowCollection.tbEndAt.Text = rowList.Count.ToString();
                this.rowCollection.SetSettings();
            }


            public RowCollectionRow this[int i]
            {
                get
                {
                    if (i >= 0 && i < rowList.Count)
                    {
                        return (RowCollectionRow)rowList[i];
                    }
                    else
                    {
                        return null;
                    }
                }
            }
            public IEnumerator<RowCollectionRow> GetEnumerator()
            {
                for (int i = this.rowCollection.startAt; i <= this.rowCollection.endAt; i = i + this.rowCollection.increment)
                {
                    yield return (RowCollectionRow)rowList[i];
                }
            }

            public RowCollectionRow FetchNext()
            {
                RowCollectionRow row = null;
                RowCollection rowCollection = null;

                this.rowCollectionMenager.ActiveObjectInstance[this.rowCollection.DepthIndex] = this.ToString();

                //#1 child logic code
                if (this.rowCollection.HasChildrenControls == true)
                {
                    // reset curent row index for this instance
                    if (this.rowCollection.curentRowIndex == -1)
                    {
                        this.rowCollection.curentRowIndex = this.rowCollection.startAt;
                    }

                    rowCollection = (RowCollection)this.rowCollection.FetchCurentChild();
                    //if (rowCollection == null)
                    //{
                    //    rowCollection = (RowCollection)this.FetchNextChild();
                    //}
                    row = this.FetchNext();
                }
                //#1
                else
                {
                    //#2 test
                    if (this.rowCollection.curentRowIndex == -1)
                    {
                        this.rowCollection.curentRowIndex = this.rowCollection.startAt;
                    }
                    else
                    {
                        this.rowCollection.curentRowIndex = this.rowCollection.curentRowIndex + this.rowCollection.increment;
                    }
                    //#2

                    if ((this.rowCollection.curentRowIndex >= this.rowCollection.startAt && this.rowCollection.startAt <= this.rowCollection.endAt) || (this.rowCollection.curentRowIndex <= this.rowCollection.startAt && this.rowCollection.startAt > this.rowCollection.endAt))
                    {
                        if ((this.rowCollection.curentRowIndex <= this.rowCollection.endAt && this.rowCollection.startAt <= this.rowCollection.endAt) || (this.rowCollection.curentRowIndex >= this.rowCollection.endAt && this.rowCollection.startAt > this.rowCollection.endAt))
                        {
                            row = this[this.rowCollection.curentRowIndex];
                        }
                    }
                    //this.curentRowIndex = this.curentRowIndex + this.increment;
                }
                return row;
            }

            /// <summary>
            /// Peek next row object, if instance have child then will retrun row object from last child
            /// </summary>
            /// <returns></returns>
            public RowCollectionRow PeekNext()
            {
                RowCollectionRow row = null;
                RowCollection rowCollection = null;

                //#1 child logic code
                if (this.rowCollection.HasChildrenControls == true)
                {
                    // reset curent row index for this instance
                    //if (this.curentRowIndex == -1)
                    //{
                    //this.curentRowIndex = this.startAt;
                    //}

                    // Fetch curent child instance
                    rowCollection = (RowCollection)this.rowCollection.FetchCurentChild();
                    // if child is not null then peek next row object
                    if (rowCollection != null)
                    {
                        row = this.PeekNext();
                        if (row == null)
                        {
                            if (this.rowCollection.curentRowIndex + 1 <= this.rowCollection.endAt)
                            {
                                this.rowCollection.curentRowIndex++;
                                this.rowCollection.ResetAllChildCurentRowIndex(-1);
                                rowCollection.curentRowIndex = -1;
                                row = this.PeekNext();
                            }
                            else
                            {
                                // 
                                if (this.rowCollection.FetchNextChild() != null)
                                {
                                    this.rowCollection.curentRowIndex = -1; // 0;
                                    row = this.PeekNext();
                                }
                                else
                                {
                                    this.rowCollection.ResetNextChildStatus();
                                    //this.curentRowIndex = -1;
                                    //row = this.PeekNext();
                                }
                            }
                        }
                    }
                }
                //#1
                else
                {
                    int peekCurentRowIndex = this.rowCollection.curentRowIndex;
                    //#2 test
                    if (peekCurentRowIndex == -1)
                    {
                        peekCurentRowIndex = this.rowCollection.startAt;
                    }
                    else
                    {
                        peekCurentRowIndex = peekCurentRowIndex + this.rowCollection.increment;
                    }
                    //#2


                    if ((peekCurentRowIndex >= this.rowCollection.startAt && this.rowCollection.startAt <= this.rowCollection.endAt) || (peekCurentRowIndex <= this.rowCollection.startAt && this.rowCollection.startAt > this.rowCollection.endAt))
                    {
                        if ((peekCurentRowIndex <= this.rowCollection.endAt && this.rowCollection.startAt <= this.rowCollection.endAt) || (peekCurentRowIndex >= this.rowCollection.endAt && this.rowCollection.startAt > this.rowCollection.endAt))
                        {
                            row = this[peekCurentRowIndex];
                        }
                    }
                }
                return row;
            }
            public RowCollectionRow SearchRow(string searchPattern, int columnID)
            {
                Regex regex = new Regex(searchPattern);
                foreach (RowCollectionRow rowCollectionRow in rowList)
                {
                    if (regex.Match(rowCollectionRow[columnID].Value).Success)
                    {
                        return rowCollectionRow;
                    }
                }
                return null;
            }

            public string FetchNextColumn(int columnID)
            {
                string result;
                // increment this column index
                this.rowCollection.positionColumn[columnID] = this.rowCollection.positionColumn[columnID] + this.rowCollection.increment;
                // fetch value
                result = this[this.rowCollection.positionColumn[columnID]][columnID].Value;

                // if is last index and repeat is on then start from begining
                if ((this.rowCollection.positionColumn[columnID] >= this.Count) && this.rowCollection.Repeat)
                {
                    this.rowCollection.positionColumn[columnID] = this.rowCollection.startAt;
                }
                // return value
                return result;

            }
            public string FetchColumn(int columnID)
            {
                string result = this[this.rowCollection.positionColumn[columnID]][columnID].Value;
                if ((this.rowCollection.positionColumn[columnID] >= this.Count) && this.rowCollection.Repeat)
                {
                    this.rowCollection.positionColumn[columnID] = this.rowCollection.startAt;
                }
                return result;
            }

            public int Count
            {
                get { return rowList.Count; }
            }
            /// <summary>
            /// Return curent row index from this instance
            /// </summary>
            public int Curent
            {
                get
                {
                    return this.rowCollection.curentRowIndex;
                }
                set
                {
                    this.rowCollection.curentRowIndex = value;
                }
            }

        }

        public class ObjectCollectionColumns
        {
            string[] list;
            private int count;

            public ObjectCollectionColumns(int count)
            {
                this.count = count;
                // set default column names
                list = new string[count];
                for (int i = 0; i < count; i++)
                {
                    list[i] = RowCollection.const_prefix_column + (i + 1).ToString();
                }
            }

            public IEnumerator<string> GetEnumerator()
            {
                for (int i = 0; i < list.Length; i++)
                {
                    yield return list[i].ToString();
                }
            }

            public int Count
            {
                get { return this.count; }
            }

            public string this[int index]
            {
                get
                {
                    return list[index];
                }
                set
                {
                    list[index] = value;
                }
            }

        }

    }
}
