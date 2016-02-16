using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

using  DamirM.Modules;
using DamirM.Class;
using DamirM.Controls;
using DamirM.CommonLibrary;
using UberTools.Modules.GenericTemplate.Class;
using DamirM.CommonControls;

//using DamirM.Dll.CommonLibrary;

namespace UberTools.Modules.GenericTemplate.Class.TagObjects
{
    class InputObject
    {
        private int inputTagsCount;
        private int activeIndex;
        private ArrayList list;
        private TagsReplace varObjectList;

        public InputObject(TagsReplace varObjectList)
        {
            this.varObjectList = varObjectList;
            activeIndex = -1;
        }
        public void ProcessText(string text)
        {
            this.inputTagsCount += GetNumberOfInputOnceTags(text);
            if (list == null)
            {
                if (this.inputTagsCount > 0)
                {
                    list = new ArrayList();
                }
            }
        }

        public string ProcessTag(Tag2 tag)
        {
            string result = "";
            try
            {
                activeIndex++;
                if (activeIndex < list.Count)
                {
                    // input object fount so return value and exit
                    result = (string)((NameValueDataStruct)list[activeIndex]).Value;
                }
                else
                {
                    if (tag.Child.Child.Name == "textbox")
                    {
                        // {=input.once.textbox.[Text]}
                        list.Add(new NameValueDataStruct(tag.Child.Child.Child.Name, null));
                    }
                    else if (tag.Child.Child.Name == "combobox")
                    {
                        // {=input.once.combobox."Caption name".[ArrayObject].[ArrayObject]}
                        NameValueDataStruct nameValueDataStruct = new NameValueDataStruct(tag.Child.Child.Child.Name, null);
                        Array nameArray = null;
                        Array valueArray = null;
                        ArrayList data;

                        // get object from text
                        foreach (VarObjectStruct varObjectStruct in varObjectList.varObjectList)
                        {
                            if (varObjectStruct.Name == tag.Child.Child.Child.Child.Name)
                            {
                                //data.Add(varObjectStruct.ToArray());
                                nameArray = varObjectStruct.ToArray();
                                break;
                            }
                        }

                        // get object from text
                        foreach (VarObjectStruct varObjectStruct in varObjectList.varObjectList)
                        {
                            if (varObjectStruct.Name == tag.Child.Child.Child.Child.Child.Name)
                            {
                                valueArray = varObjectStruct.ToArray();
                                break;
                            }
                        }

                        // if value array is null then make it equals as name array, so user can make empty value array string
                        if (valueArray == null && tag.Child.Child.Child.Child.Child.Name == "")
                        {
                            valueArray = nameArray;
                        }

                        if (nameArray != null && valueArray != null)
                        {
                            data = new ArrayList(nameArray.Length);
                            for (int i = 0; i < nameArray.Length; i++)
                            {
                                data.Add(new NameValueDataStruct(nameArray.GetValue(i).ToString(), valueArray.GetValue(i)));
                            }

                            nameValueDataStruct.Data = data;
                        }
                        else
                        {
                            ModuleLog.Write("Array object not found for " + nameValueDataStruct.Name, this, "ProcessTag", ModuleLog.LogType.ERROR);
                        }

                        list.Add(nameValueDataStruct);
                    }
                    else
                    {
                        ModuleLog.Write(new string[] { TagsReplace.constError_CommandNotFound, tag.InputText }, this, "ProcessTag", ModuleLog.LogType.ERROR);
                        result = TagsReplace.constError_SyntaxError;
                    }

                    // if is last input object then call user to imput data
                    if (activeIndex >= inputTagsCount - 1)
                    {
                        CallUserInput();
                    }
                }
                if (activeIndex >= inputTagsCount - 1)
                {
                    activeIndex = -1;
                }
            }
            catch(Exception ex)
            {
                ModuleLog.Write(new string[] { TagsReplace.constError_ExecutingBlock, tag.InputText }, this, "ProcessTag", ModuleLog.LogType.DEBUG);
                ModuleLog.Write(ex, this, "ProcessTag", ModuleLog.LogType.ERROR);
                result = TagsReplace.constError_SyntaxError;
            }
            return result;
        }

        private void CallUserInput()
        {
            InputBox inputBox;
            NameValueDataStruct nameValueStruct;
            try
            {
                inputBox = new InputBox("Input requested values", list, "");
                inputBox.ShowDialog(System.Windows.Forms.Application.OpenForms[0]);

                for (int i = 0; i < list.Count; i++)
                {
                    nameValueStruct = (NameValueDataStruct)list[i];
                    nameValueStruct.Value = inputBox[i];
                    list[i] = nameValueStruct;
                }

            }
            catch (Exception ex)
            {
                ModuleLog.Write(ex, this, "InputObject", ModuleLog.LogType.ERROR);
                inputBox = null;
            }
        }

        private int GetNumberOfInputOnceTags(string text)
        {
            // Define all regex match with patern
            Regex regexMain = new Regex(@"\{=input.once.[^{}]+\}");
            // Get all matches
            MatchCollection matchList;
            matchList = regexMain.Matches(text);

            return matchList.Count;
        }


    }
}
