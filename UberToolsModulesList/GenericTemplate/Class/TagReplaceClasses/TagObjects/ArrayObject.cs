using System;
using System.Collections.Generic;
using System.Collections;
using System.Text;

using  DamirM.Modules;
using DamirM.Class;
using DamirM.Controls;
using DamirM.CommonLibrary;
using UberTools.Modules.GenericTemplate.Class;
using DamirM.CommonControls;

namespace UberTools.Modules.GenericTemplate.Class.TagObjects
{
    class ArrayObject
    {
        Tag2 tag;
        ArrayList varObjectStructList;

        public ArrayObject(Tag2 tag, ArrayList varObjectStructList)
        {
            this.tag = tag;
            this.varObjectStructList = varObjectStructList;

            //// If varObject is null, first use, create instance
            //if (varObjectStructList == null)
            //{
            //    varObjectStructList = new ArrayList();
            //}
        }

        public ArrayObject(ArrayList varObjectStructList)
        {
            //// If varObject is null, first use, create instance
            //if (varObjectStructList == null)
            //{
            //    varObjectStructList = new ArrayList();
            //}
            this.varObjectStructList = varObjectStructList;
        }

        public string ProcessTag()
        {
            string result = null;
            try
            {
                if (tag.Child.Name == "add")
                {
                    //{=array.add.[ArrayName].[Value]}
                    this.Add(tag.Child.Child.Name, tag.Child.Child.Child.Name);
                }
                else if (tag.Child.Name == "addOnce")
                {
                    //{=array.addOnce.[ArrayName].[Value]}
                    this.AddOnce(tag.Child.Child.Name,tag.Child.Child.Child.Name);
                }
                else if (tag.Child.Name == "fetch")
                {
                    // {=array.fetch."[ArrayName]"
                    foreach (VarObjectStruct varObjectStruct in varObjectStructList)
                    {
                        if (varObjectStruct.Name == tag.Child.Child.Name)
                        {
                            result = varObjectStruct.Fetch();
                            //ModuleLog.Write("VarObjectName: " + objectEntry.Name + "\r\nVarObjectValue: " + objectEntry.Value, this, "VarObject", ModuleLog.LogType.DEBUG);
                            break;
                        }
                    }
                }
                else if (tag.Child.Name == "fetchNext")
                {
                    // {=array.fetch."[ArrayName]"
                    foreach (VarObjectStruct varObjectStruct in varObjectStructList)
                    {
                        if (varObjectStruct.Name == tag.Child.Child.Name)
                        {
                            result = varObjectStruct.FetchNext();
                            //ModuleLog.Write("VarObjectName: " + objectEntry.Name + "\r\nVarObjectValue: " + objectEntry.Value, this, "VarObject", ModuleLog.LogType.DEBUG);
                            break;
                        }
                    }
                }
                else if (tag.Child.Name == "empty")
                {
                    // {=array.empty."[ArrayName]"}
                    VarObjectStruct varObjectStruct = GetObjectFromName(tag.Child.Child.Name);
                    varObjectStruct.Empty();
                    result = "";
                }
                else
                {
                    ModuleLog.Write(new string[] { TagsReplace.constError_CommandNotFound, tag.InputText }, this, "ArrayObject", ModuleLog.LogType.ERROR);
                    result = TagsReplace.constError_SyntaxError;
                }
            }
            catch (Exception ex)
            {
                ModuleLog.Write(new string[] { TagsReplace.constError_ExecutingBlock, tag.InputText }, this, "ArrayObject", ModuleLog.LogType.DEBUG);
                ModuleLog.Write(ex, this, "ArrayObject", ModuleLog.LogType.ERROR);
                result = TagsReplace.constError_SyntaxError;
            }
            return result;
        }
        public void Add(string objectName, string value)
        {
            VarObjectStruct varObjectStruct = null;

            // if objectStruct exists return it, else return null
            varObjectStruct = GetObjectFromName(objectName);

            if (varObjectStruct == null)
            {
                // VarObjectStruct entry is object with name and value propertis
                varObjectStruct = new VarObjectStruct(objectName, VarObjectStruct.Type.Array);
                varObjectStruct.Add(value);

                // Add entry to row collection
                varObjectStructList.Add(varObjectStruct);
            }
            else
            {
                varObjectStruct.Add(value);
            }
        }

        public void AddOnce(string objectName, string value)
        {
            VarObjectStruct varObjectStruct = null;

            // if objectStruct exists return it, else return null
            varObjectStruct = GetObjectFromName(objectName);

            // if no object with that name
            if (varObjectStruct == null)
            {
                // VarObjectStruct entry is object with name and value propertis
                varObjectStruct = new VarObjectStruct(objectName, VarObjectStruct.Type.Array);

                varObjectStruct.AddOnce(value);
                // Add entry to row collection
                varObjectStructList.Add(varObjectStruct);
            }
            else
            {

                varObjectStruct.AddOnce(value);
            }
        }

        public VarObjectStruct GetObjectFromName(string objectName)
        {
            VarObjectStruct varObjectStruct = null;

            // Is object with 'array name' already set ?
            foreach (VarObjectStruct isVariable in varObjectStructList)
            {
                if (objectName == isVariable.Name)
                {
                    varObjectStruct = isVariable;
                    break;
                }
            }
            return varObjectStruct;
        }

    }
}
