using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;

using UberTools.Modules.GenericTemplate.Class.TagObjects;
using UberTools.Modules.GenericTemplate.Controls;
using DamirM.Modules;
using DamirM.CommonLibrary;

namespace UberTools.Modules.GenericTemplate.RowCollectionNS
{
    public class RowCollectionMenager: IEnumerable<RowCollection> ,IEnumerable<RowCollectionRow>
    {
        private ArrayList rowCollectionList = new ArrayList();
        private ActiveObject activeObject;
        SettingsMenager2 settingsMenager;

        private System.Windows.Forms.Panel panel;
        private bool[] oldLockStates;

        private int position = 0;
        private int priority = 1;

        public RowCollectionMenager(System.Windows.Forms.Panel panel, SettingsMenager2 settingsMenager)
        {
            // Bound menager with GUI wher he will display RowCollection
            this.panel = panel;
            // represent active object, curent row, row counter
            this.activeObject = new ActiveObject();
            this.settingsMenager = settingsMenager;
        }

    
        public void AddRow(RowCollectionRow row)
        {
            // Return RowCollection object to write new row, if is null then make new RowCollection object
            RowCollection rowCollection = GetRowCollectionObjectFromCellNumber(row.ColumnCount, true);

            rowCollection.Rows.Add(row);

        }

        private void rowCollection_OnRemove(System.Windows.Forms.Control control)
        {
            panel.Controls.Remove(control);
            rowCollectionList.Remove(control);
        }

        /// <summary>
        /// Returns an instance of an existing object or create a new object based on the number of columns
        /// </summary>
        /// <param name="columnCount"></param>
        /// <returns></returns>
        public RowCollection GetRowCollectionObjectFromCellNumber(int columnCount, bool create)
        {
            // If RowCollection object is existing and object is write free then return reference, else is null
            RowCollection control = null;
            foreach (RowCollection rowCollection in rowCollectionList)
            {
                if (columnCount == rowCollection.Columns.Count && !rowCollection.Lock)
                {
                    control = rowCollection;
                    break;
                }
            }
            if (create == true)
            {
                if (control == null)
                {
                    control = CreateRowCollection(columnCount);
                }
            }
            return control;
        }
        public RowCollection CreateRowCollection(int columnCount)
        {
            return CreateRowCollection(columnCount, GetUniqueRowCollectionName(columnCount, 0));
        }

        /// <summary>
        /// Test metoda
        /// </summary>
        /// <param name="columnCount"></param>
        /// <param name="name"></param>
        /// <returns></returns>
        public RowCollection CreateRowCollection(int columnCount, string name)
        {
            RowCollection rowCollection;
            rowCollection = new RowCollection(this, columnCount, name);

            rowCollection.DownControl = null;
            rowCollection.Location = new System.Drawing.Point(10, 20);
            rowCollection.TabIndex = 0;
            if (rowCollectionList.Count > 0)
            {
                rowCollection.UpControl = ((RowCollection)rowCollectionList[rowCollectionList.Count - 1]).TopParent;
            }
            else
            {
                rowCollection.UpControl = null;
            }
            this.panel.Controls.Add(rowCollection);
            rowCollectionList.Add(rowCollection);
            // Subscribe to event, to delete this Object from collection list
            rowCollection.OnRemove += new DamirM.CommonLibrary.UserControlBase.delUserControlBaseGenericDelegate(rowCollection_OnRemove);

            // make it menager for this new object
            //rowCollection.RowCollectionMenager = this;
            return rowCollection;
        }

        public string GetUniqueRowCollectionName(int columnCount, int endingInt)
        {
            return GetUniqueRowCollectionName(RowCollection.const_prefix, columnCount, endingInt);
        }
        public string GetUniqueRowCollectionName(string prefix, int columnCount, int endingInt)
        {
            string endingString = "";
            if (endingInt == 0)
            {
                endingInt = 65;
                endingString = "";

            }
            else
            {
                endingString = ((char)endingInt).ToString();
                endingInt++;
            }
            string name = prefix + columnCount.ToString() + endingString;
            foreach (RowCollection rowCollection in rowCollectionList)
            {
                if (rowCollection.Name == name)
                {
                    name = GetUniqueRowCollectionName(prefix, columnCount, endingInt);
                }
            }
            return name;
        }

        public RowCollection this[int rowCollectionID]
        {
            get
            {
                try
                {
                    return (RowCollection)rowCollectionList[rowCollectionID];
                }
                catch
                {
                    return null;
                }
            }
        }
        public RowCollection this[string collectionName]
        {
            get
            {
                foreach (RowCollection rowCollection in rowCollectionList)
                {
                    if (rowCollection.Name.Equals(collectionName, StringComparison.CurrentCultureIgnoreCase))
                    {
                        return rowCollection;
                    }
                }
                return null;
            }
        }
        /// <summary>
        /// Get all RowCollection object
        /// </summary>
        /// <returns></returns>
        IEnumerator<RowCollection> IEnumerable<RowCollection>.GetEnumerator()
        {
            for (int i = 0; i < rowCollectionList.Count; i++)
            {
                yield return this[i];
            }
        }
        /// <summary>
        /// Remove all RowCollection object
        /// </summary>
        public void Clear()
        {
            // TODO: this need to call self destruction to all RowCollection object
            // this is  not in use ATM
            this.rowCollectionList.Clear();
        }
        IEnumerator<RowCollectionRow> IEnumerable<RowCollectionRow>.GetEnumerator()
        {
            RowCollection rowCollection = null;
            this.priority = 1;
            this.position = 0;
            do
            {
                rowCollection = FatchNext(this.priority, this.position, false);
                if (rowCollection != null)
                {
                    yield return rowCollection.Rows.FetchNext();
                }

            } while (rowCollection != null);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            // dummy method
            return null;
        }
        //private RowCollection FatchNext(int priotity, int position, bool indikator)
        //{
        //    RowCollection rowCollection = null;
        //    for (int i = position; i < rowCollectionList.Count; i++)
        //    {
        //        if (((RowCollection)rowCollectionList[i]).Priority == priotity && ((RowCollection)rowCollectionList[i]).Selected)
        //        {
        //            if (((RowCollection)rowCollectionList[i]).PeekNext() != null)
        //            {
        //                this.position = i + 1;
        //                if (this.position >= rowCollectionList.Count)
        //                {
        //                    this.position = 0;
        //                }
        //                return (RowCollection)rowCollectionList[i];
        //            }
        //        }
        //    }

        //    if (indikator)
        //    {
        //        this.priority++;
        //        if (this.priority > 20)
        //        {
        //            return null;
        //        }
        //    }
        //    this.position = 0;
        //    rowCollection = FatchNext(this.priority, this.position, true);

        //    return rowCollection;

        //}

        private RowCollection FatchNext(int priotity, int position, bool indikator)
        {
            RowCollection result = null;
            RowCollection rowCollection = null;

            for (int i = position; i < rowCollectionList.Count; i++)
            {
                rowCollection = (RowCollection)rowCollectionList[i];

                // Select instance only if is in top of colection, no parents
                if (rowCollection.ParentControl == null)
                {
                    if (rowCollection.Priority == priotity && rowCollection.Selected)
                    {
                        if (rowCollection.Rows.PeekNext() != null)
                        {
                            this.position = i + 1;
                            if (this.position >= rowCollectionList.Count)
                            {
                                this.position = 0;
                            }
                            return rowCollection;
                        }
                    }
                }
            }

            if (indikator)
            {
                this.priority++;
                if (this.priority > 20)
                {
                    return null;
                }
            }
            this.position = 0;
            result = FatchNext(this.priority, this.position, true);

            return result;

        }

        public int SelectedCount
        {
            get
            {
                int counter = 0;
                foreach (RowCollection rowCollection in rowCollectionList)
                {
                    if (rowCollection.Selected)
                    {
                        counter++;
                    }
                }
                return counter;
            }
        }

        public ActiveObject ActiveObjectInstance
        {
            get
            {
                return this.activeObject;
            }
            set
            {
                this.activeObject = value;
            }
        }

        public void ResetSettings()
        {
            foreach (RowCollection rowCollection in rowCollectionList)
            {
                rowCollection.SetSettings();
            }
            this.ActiveObjectInstance.RowCounter = 0;
        }
        public void TemperalySaveLoadLockStatus(bool returnOldLockStates)
        {
            if (returnOldLockStates == false)
            {
                // Save lock states
                oldLockStates = null;
                oldLockStates = new bool[rowCollectionList.Count];
                for (int i = 0; i < rowCollectionList.Count; i++)
                {
                    oldLockStates[i] = ((RowCollection)rowCollectionList[i]).Lock;
                    ((RowCollection)rowCollectionList[i]).Lock = true;
                }
            }
            else
            {
                // Return old lock states
                for (int i = 0; i < oldLockStates.Length; i++)
                {
                    ((RowCollection)rowCollectionList[i]).Lock = oldLockStates[i];
                }
                oldLockStates = null;
            }
        }

        public SettingsMenager2 SettingsMenager
        {
            get { return this.settingsMenager; }
            set { this.settingsMenager = value; }
        }
    }
}
