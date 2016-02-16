using System;
using System.Collections.Generic;
using System.Collections;
using System.Text;
using System.Windows.Forms;

using UberTools.Modules.GenericTemplate.Class.TagObjects;
using UberTools.Modules.GenericTemplate.Controls;
using DamirM.Modules;
using DamirM.Class;
using DamirM.Controls;
using UberTools.Modules.GenericTemplate.Forms;
using DamirM.CommonLibrary;
using UberTools.Modules.GenericTemplate.Class;

namespace UberTools.Modules.GenericTemplate.RowCollectionNS
{
    class RowCollectionHelper
    {
        RowCollectionMenager rowCollectionMenager;
        RowCollection rowCollection;

        public RowCollectionHelper(RowCollection rowCollection)
        {
            this.rowCollection = rowCollection;
            this.rowCollectionMenager = rowCollection.RowCollectionMenager;
        }


        public void GroupBy(object sender, EventArgs args)
        {
            RowCollection newRowCollection;
            TagsReplace tagReplace;
            Tag tag;
            InputBox inputBox;
            DialogResult dialogResult;
            string stringOne = "";
            string stringTwo = "";
            int counter = 0;
            int uniuqeID = 0;
            object[] tmp;
            string inputString;

            // load input text from settings
            inputString = this.rowCollectionMenager.SettingsMenager.LoadSetting("data-object-groupby-tag", "{=data.1}");
            inputBox = new InputBox("Tag source", "Group by tag source", inputString);
            dialogResult = inputBox.ShowDialog();
            if (dialogResult == DialogResult.OK)
            {
                try
                {
                    newRowCollection = rowCollectionMenager.CreateRowCollection(2, rowCollectionMenager.GetUniqueRowCollectionName("GroupBy", 2, 0));
                    newRowCollection.Columns[0] = "Value";
                    newRowCollection.Columns[1] = "Count";
                    tmp = new object[rowCollection.Rows.Count];
                    tagReplace = new TagsReplace(this.rowCollectionMenager);
                    this.rowCollectionMenager.TemperalySaveLoadLockStatus(false);
                    //for (int i = 0; i < rowList.Count; i++)
                    foreach(RowCollectionRow objectRow in rowCollection.Rows)
                    {
                        counter = 0;
                        stringOne = tagReplace.ReplaceTags(inputBox.InputTekst, objectRow);
                        for (int j = 0; j < tmp.Length; j++)
                        {
                            if (tmp[j] != null)
                            {
                                tag = (Tag)tmp[j];
                                stringTwo = tag.Name;
                                if (stringOne.Equals(stringTwo))
                                {
                                    counter = int.Parse(tag.Value);
                                    counter++;
                                    tag.Value = counter.ToString();
                                    break;
                                }
                            }
                            else
                            {
                                // exit this loop, all is null object
                                break;
                            }
                        }
                        if (counter == 0)
                        {
                            tag = new Tag(stringOne, "1");
                            tmp[uniuqeID] = tag;
                            uniuqeID++;
                        }

                    }
                    RowCollectionRow row;
                    foreach (Tag isTag in tmp)
                    {
                        row = new RowCollectionRow(newRowCollection, new string[] { isTag.Name, isTag.Value });

                        newRowCollection.Rows.Add(row);
                    }
                    // save settings
                    this.rowCollectionMenager.SettingsMenager.Items.Add(new DamirM.CommonLibrary.SettingsMenagerStructure2(inputBox.InputTekst, "data-object-groupby-tag", inputBox.InputTekst, "", DamirM.CommonLibrary.SettingsMenager2.Type.Text));
                }
                catch (Exception ex)
                {
                    ModuleLog.Write(ex, this, "GroupBy", ModuleLog.LogType.ERROR);
                }
                finally
                {
                    this.rowCollectionMenager.TemperalySaveLoadLockStatus(true);
                }
            }
        }

        public void ShowFilter(object sender, EventArgs args)
        {
            RowCollectionFilterDialog rowCollectionSettings;
            try
            {
                rowCollectionSettings = new RowCollectionFilterDialog(this.rowCollection);
                rowCollectionSettings.Show(Application.OpenForms[0]);
            }
            catch (Exception ex)
            {
                ModuleLog.Write(ex, this, "ShowFilter", ModuleLog.LogType.ERROR);
            }
        }

    }
}
