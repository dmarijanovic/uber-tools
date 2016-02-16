using System;
using System.Collections.Generic;
using System.Collections;
using System.Text;
using System.Text.RegularExpressions;
using System.IO;

using UberTools.Modules.GenericTemplate.RowCollectionNS;
using  DamirM.Modules;
using DamirM.Controls;
using DamirM.Class;
using DamirM.CommonLibrary;
using UberTools.Modules.GenericTemplate.Controls;
using UberTools.Modules.GenericTemplate.Class.TagObjects;
using UberTools.Modules.GenericTemplate.InputData;
using DamirM.CommonControls;

namespace UberTools.Modules.GenericTemplate.Class
{
    partial class TagsReplace
    {
        private string DateObject(string objectValue)
        {
            string text = "";
            // {=date.now}
            if (objectValue == "now")
            {
                text = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            }
            else if (objectValue == "date")
            {
                text = DateTime.Now.ToString("yyyy-MM-dd");
            }
            else if (objectValue == "time")
            {
                text = DateTime.Now.ToString("HH:mm:ss");
            }
            else if (objectValue == "year")
            {
                text = DateTime.Now.ToString("yyyy");
            }
            else if (objectValue == "month")
            {
                text = DateTime.Now.ToString("mm");
            }
            else if (objectValue == "day")
            {
                text = DateTime.Now.ToString("dd");
            }
            else if (objectValue == "hour")
            {
                text = DateTime.Now.ToString("HH");
            }
            else if (objectValue == "minute")
            {
                text = DateTime.Now.ToString("mm");
            }
            else if (objectValue == "second")
            {
                text = DateTime.Now.ToString("ss");
            }
            else
            {
                try
                {
                    text = DateTime.Today.ToString(objectValue);
                }
                catch
                {
                    ModuleLog.Write(string.Concat(constError_SyntaxError, " (", objectValue, ")"), this, "DateObject", ModuleLog.LogType.ERROR);
                    text = constError_SyntaxError;
                }
            }
            return text;

        }

        private string ActiveObject(Tag2 active)
        {
            string result = null;
            try
            {
                // {=active.fetch.[deep_index].[column_index]}
                if (active.Child.Name == "counter")
                {
                    result = this.rowCollectionMenager.ActiveObjectInstance.RowCounter.ToString();
                }
                else
                {
                    int depth = int.Parse(active.Child.Child.Name);
                    depth--;
                    string objectName = rowCollectionMenager.ActiveObjectInstance[depth];
                    if (objectName != null)
                    {
                        RowCollection rowCollection = rowCollectionMenager[objectName];

                        if (active.Child.Name == "fetch")
                        {
                            int columnIndex = int.Parse(active.Child.Child.Child.Name);
                            columnIndex--;
                            RowCollectionRow objectRow = rowCollection.Rows[rowCollection.Rows.Curent];
                            if (objectRow != null)
                            {
                                result = objectRow[columnIndex].Value;
                            }
                            else
                            {
                                // active object is out of scope
                                result = "";
                            }
                        }
                        else if (active.Child.Name == "index")
                        {
                            result = (rowCollection.Rows.Curent + 1).ToString(); ;
                        }
                        else
                        {
                            ModuleLog.Write(new string[] { constError_CommandNotFound, active.InputText }, this, "ActiveObject", ModuleLog.LogType.ERROR);
                            result = constError_SyntaxError;
                        }
                    }
                    else
                    {
                        // active object is out of scope
                        result = "";
                    }
                }
            }
            catch (Exception ex)
            {
                ModuleLog.Write(new string[] { constError_ExecutingBlock, active.InputText }, this, "ActiveObject", ModuleLog.LogType.DEBUG);
                ModuleLog.Write(ex, this, "ActiveObject", ModuleLog.LogType.ERROR);
                result = constError_SyntaxError;
            }
            return result;
        }

        /// <summary>
        /// Generic method, it will return string value of row object and columnt index
        /// </summary>
        /// <param name="row">Row object</param>
        /// <param name="objectValue">Column index</param>
        /// <returns></returns>
        /// 
        private string DataObjectGetValue(RowCollectionRow row, Tag2 tag)
        {
            string result = null;
            int columntID = 0;
            try
            {
                if (tag.Child.Child == null)
                {
                    columntID = int.Parse(tag.Child.Name);
                    // Column index is zero base, but user need to treat it like non zero base else it is error 
                    if (columntID > 0)
                    {
                        // Increment column index to 1, zero index base, user will access it by one base
                        columntID--;
                        result = row[columntID].Value;
                    }
                    else
                    {
                        ModuleLog.Write(new string[] { constError_SyntaxError, tag.InputText }, this, "DataObjectGetValue", ModuleLog.LogType.ERROR);
                        result = constError_SyntaxError;
                    }
                }
                else
                {
                    ModuleLog.Write(new string[] { constError_CommandNotFound, tag.InputText }, this, "DataObjectGetValue", ModuleLog.LogType.ERROR);
                    result = constError_SyntaxError;
                }
            }
            catch (Exception ex)
            {
                ModuleLog.Write(new string[] { constError_ExecutingBlock, tag.InputText }, this, "DataObjectGetValue", ModuleLog.LogType.DEBUG);
                ModuleLog.Write(ex, this, "DataObjectGetValue", ModuleLog.LogType.ERROR);
                result = constError_SyntaxError;
            }
            //if (result == null)
            //{
            //    ModuleLog.Write(string.Concat(constError_SyntaxError, " (", objectValue, ")"), this, "DataObjectGetValue", ModuleLog.LogType.ERROR);
            //    result = constError_SyntaxError;
            //}
            return result;
        }

        /// <summary>
        /// RowCollection object
        /// </summary>
        /// <param name="tag"></param>
        /// <returns></returns>
        private string DataObjectGetValue(Tag2 tag)
        {
            string result = null;
            int columntID;
            RowCollection rowCollection = rowCollectionMenager[tag.Name];
            try
            {
                // {=objectname.row.column}
                // {=objectname.column}
                // Column index is zero base, but user need to treat it like non zero base else it is error 
                if (rowCollection != null)
                {
                    if (tag.Child.Name == "fetch")
                    {
                        columntID = int.Parse(tag.Child.Child.Name);
                        columntID--;
                        result = rowCollection.Rows.FetchColumn(columntID);
                    }
                    else if (tag.Child.Name == "fetchNext")
                    {
                        columntID = int.Parse(tag.Child.Child.Name);
                        columntID--;
                        result = rowCollection.Rows.FetchNextColumn(columntID);
                    }
                    else if (tag.Child.Name == "search")
                    {
                        // {=object.searchRegex.searchOnColumn.returnColumn."<regex>"}
                        columntID = int.Parse(tag.Child.Child.Name);
                        columntID--;
                        int columnID2 = int.Parse(tag.Child.Child.Child.Name);
                        columnID2--;
                        RowCollectionRow row = rowCollection.Rows.SearchRow(tag.Child.Child.Child.Child.Name, columntID);

                        if (row != null)
                        {
                            result = row[columnID2].Value;
                        }
                        else
                        {
                            result = "";
                        }
                    }
                }
                else
                {
                    ModuleLog.Write(new string[] { constError_CommandNotFound, tag.InputText }, this, "DataObjectGetValue", ModuleLog.LogType.ERROR);
                    result = constError_SyntaxError;
                }
            }
            catch(Exception ex)
            {
                ModuleLog.Write(new string[] { constError_ExecutingBlock, tag.InputText }, this, "DataObjectGetValue", ModuleLog.LogType.DEBUG);
                ModuleLog.Write(ex, this, "DataObjectGetValue", ModuleLog.LogType.ERROR);
                result = constError_SyntaxError;
            }
            return result;
        }
        private string StringObject(RowCollectionRow row, string objectValue)
        {
            string result = null;
            Tag tag = new Tag("string", objectValue);

            try
            {
                if (tag.Tags.Name == "trim")
                {
                    result = tag.Tags.Value.Trim();
                }
                else if (tag.Tags.Name == "substring")
                {
                    // {=string.substring.4.2.neki text}
                    int start;
                    int lenght;
                    start = int.Parse(tag.Tags.Tags.Name);
                    lenght = int.Parse(tag.Tags.Tags.Tags.Name);
                    // if index is in range of string length
                    if ((start + lenght) < tag.Tags.Tags.Tags.Value.Length)
                    {
                        result = tag.Tags.Tags.Tags.Value.Substring(start, lenght);
                    }
                    else
                    {
                        // else return empty string and log waring
                        result = "";
                        ModuleLog.Write("String out of range returning empty string", this, "StringObject", ModuleLog.LogType.WARNING);
                    }
                }
                else if (tag.Tags.Name == "indexof")
                {
                    // {=string.indexof. .damir marijanovic}
                    result = tag.Tags.Tags.Value.IndexOf(tag.Tags.Tags.Name).ToString();
                }
                else if (tag.Tags.Name == "toupper")
                {
                    result = tag.Tags.Value.ToUpper();
                }
                else if (tag.Tags.Name == "tolower")
                {
                    result = tag.Tags.Value.ToLower();
                }
                else if (tag.Tags.Name == "replace")
                {
                    // {=string.replace.old.new.text}
                    result = tag.Tags.Tags.Tags.Value.Replace(tag.Tags.Tags.ToString(), tag.Tags.Tags.Tags.ToString());
                }
                else if (tag.Tags.Name == "split")
                {
                    // string.split.[index].[split string].[text]
                    string[] splitList = tag.Tags.Tags.Tags.Value.Split(new string[] { tag.Tags.Tags.Tags.Name }, StringSplitOptions.RemoveEmptyEntries);
                    int index;
                    index = int.Parse(tag.Tags.Tags.Name);
                    // if index is in range of array
                    if (index < splitList.Length)
                    {
                        result = splitList[index];
                    }
                    else
                    {
                        // else return empty string and log waring
                        result = "";
                        ModuleLog.Write("String out of range returning empty string", this, "StringObject", ModuleLog.LogType.WARNING);
                    }
                }
                else
                {
                    ModuleLog.Write(string.Concat(constError_SyntaxError, " (", objectValue, ")"), this, "StringObject", ModuleLog.LogType.ERROR);
                    result = constError_SyntaxError;
                }
            }
            catch(Exception ex)
            {
                ModuleLog.Write(string.Concat(constError_SyntaxError, " (", objectValue, ")"), this, "StringObject", ModuleLog.LogType.DEBUG);
                ModuleLog.Write(ex, this, "StringObject", ModuleLog.LogType.ERROR);
                result = constError_SyntaxError;
            }
            return result;
        }
        private string StringObject(RowCollectionRow row, Tag2 tag)
        {
            string result = null;
            try
            {
                if (tag.Child.Name == "split")
                {
                    // string.split.[index].[split string].[text]
                    string[] splitList = tag.Child.Child.Child.Child.Name.Split(new string[] { tag.Child.Child.Child.Name }, StringSplitOptions.RemoveEmptyEntries);
                    int index;
                    index = int.Parse(tag.Child.Child.Name);
                    // if index is in range of array
                    if (index < splitList.Length)
                    {
                        result = splitList[index];
                    }
                    else
                    {
                        // else return empty string and log waring
                        result = "";
                        ModuleLog.Write("String out of range returning empty string", this, "StringObject", ModuleLog.LogType.WARNING);
                    }
                }
                else
                {
                    ModuleLog.Write(string.Concat(constError_SyntaxError, " (", tag.InputText, ")"), this, "StringObject", ModuleLog.LogType.ERROR);
                    result = constError_SyntaxError;
                }
            }
            catch (Exception ex)
            {
                ModuleLog.Write(string.Concat(constError_SyntaxError, " (", tag.InputText, ")"), this, "StringObject", ModuleLog.LogType.DEBUG);
                ModuleLog.Write(ex, this, "StringObject", ModuleLog.LogType.ERROR);
                result = constError_SyntaxError;
            }
            return result;
        }

        private string NTHObject(RowCollectionRow row, string objectValue)
        {
            string result = null;
            Tag tag = new Tag("nth", objectValue);

            try
            {
                if (tag.Tags.Name == "swapzarez")
                {
                    //{=nth.swapzarez.text}
                    result = tag.Tags.Value.Replace(",", "<;>");
                }
                else if (tag.Tags.Name == "max160")
                {
                    //{=nth.max160.text}
                    if (tag.Tags.Value.Length > 160)
                    {
                        result = "- - - W A R N I N G (text length " + tag.Tags.Value.Length + " )  - - -";
                        ModuleLog.Write(result, this, "NTHObject", ModuleLog.LogType.WARNING);
                        ModuleLog.Write(tag.Tags.Value, this, "NTHObject", ModuleLog.LogType.DEBUG);
                    }
                    else
                    {
                        result = tag.Tags.Value;
                    }
                }
                else
                {
                    ModuleLog.Write(string.Concat(constError_SyntaxError, " (", objectValue, ")"), this, "NTHObject", ModuleLog.LogType.ERROR);
                    result = constError_SyntaxError;
                }
            }
            catch
            {
                ModuleLog.Write(string.Concat(constError_SyntaxError, " (", objectValue, ")"), this, "NTHObject", ModuleLog.LogType.ERROR);
                result = constError_SyntaxError;
            }
            return result;
        }
        private string NumberObject(RowCollectionRow row, string objectValue)
        {
            string result = null;
            Tag tag = new Tag("number", objectValue);
            try
            {
                if (tag.Value == "getvalue")
                {
                    //{=number.getvalue}
                    result = numberObject_counter.ToString();
                }
                else
                {
                    if (tag.Tags.Name == "increment")
                    {
                        //{=number.increment.startNumber.incrementBy}
                        if (numberObject_counter == constNumberObject_counter_defaultValue)
                        {
                            ModuleLog.Write(tag.Tags.Tags.Name, this, "NumberObject", ModuleLog.LogType.INFO);
                            numberObject_counter = int.Parse(tag.Tags.Tags.Name);
                        }
                        else
                        {
                            int number_to_increment = 0;
                            number_to_increment = int.Parse(tag.Tags.Tags.Value);
                            numberObject_counter = numberObject_counter + number_to_increment;
                        }
                        result = numberObject_counter.ToString();
                    }
                    else
                    {
                        ModuleLog.Write(string.Concat(constError_SyntaxError, " (", objectValue, ")"), this, "NumberObject", ModuleLog.LogType.WARNING);
                        result = constError_SyntaxError;
                    }
                }
            }
            catch (Exception ex)
            {
                ModuleLog.Write(ex, this, "--NumberObject", ModuleLog.LogType.ERROR);
                ModuleLog.Write(string.Concat(constError_SyntaxError, " (", objectValue, ")"), this, "--NumberObject", ModuleLog.LogType.DEBUG);
                result = constError_SyntaxError;
            }
            return result;
        }
        private string InputObject(RowCollectionRow row, Tag2 tag)
        {
            string result = null;

            InputBox inputBox;
            try
            {
                if (tag.Child.Name == "repeat")
                {
                    //
                    // NOTE this need to be like $input.once object
                    //
                    //{=input.repeat.[Value]}
                    inputBox = new InputBox("Write text", tag.Child.Name, "Replace tag with text...");
                    inputBox.ShowDialog(System.Windows.Forms.Application.OpenForms[0]);
                    result = inputBox.InputTekst;
                }
                else if (tag.Child.Name == "once")
                {
                    result = inputObject.ProcessTag(tag);
                    if (result == null)
                    {
                        result = constError_SyntaxError;
                    }
                }
                else
                {
                    ModuleLog.Write(new string[] { constError_CommandNotFound, tag.InputText }, this, "InputObject", ModuleLog.LogType.ERROR);
                    result = constError_SyntaxError;
                }
            }
            catch (Exception ex)
            {
                ModuleLog.Write(new string[] { constError_ExecutingBlock, tag.InputText }, this, "InputObject", ModuleLog.LogType.DEBUG);
                ModuleLog.Write(ex, this, "InputObject", ModuleLog.LogType.ERROR);
                result = constError_SyntaxError;
            }
            return result;
        }
        private InputBox InputObject(Array objectValue)
        {
            //{=input.once.Text}
            InputBox inputBox;
            try
            {
                inputBox = new InputBox("Write all texts", objectValue, "");
                inputBox.ShowDialog(System.Windows.Forms.Application.OpenForms[0]);
            }
            catch (Exception ex)
            {
                ModuleLog.Write(ex, this, "InputObject", ModuleLog.LogType.ERROR);
                inputBox = null;
            }
            return inputBox;
        }
        private string VarObject(Tag2 tag)
        {
            string result = null;
            try
            {
                if (tag.Child.Name == "set")
                {
                    VarObjectStruct varObjectStruct = null;

                    //{=var.set.[VariableName].[Value]}
                    // If varObject is null, first use, create instance
                    if (varObjectList == null)
                    {
                        varObjectList = new ArrayList();
                    }
                    // Is object alredy set ?
                    foreach (VarObjectStruct isVariable in varObjectList)
                    {
                        if (tag.Child.Child.Name == isVariable.Name)
                        {
                            varObjectStruct = isVariable;
                            break;
                        }
                    }
                    if (varObjectStruct == null)
                    {
                        // varObject entry is object with name and value propertis, tag class will be replacet with one of generic  class
                        varObjectStruct = new VarObjectStruct(tag.Child.Child.Name, VarObjectStruct.Type.Single);
                        varObjectStruct.Add(tag.Child.Child.Child.Name);
                        // Add entry to row collection
                        varObjectList.Add(varObjectStruct);
                        result = ""; // varObjectStruct.Name + " set value to " + varObjectStruct.FetchNext();
                    }
                    else
                    {
                        varObjectStruct.Add(tag.Child.Child.Child.Name);
                        // Remove var object tag and replace with value
                        result = ""; // varObjectStruct.Name + " update value to " + varObjectStruct.FetchNext();
                    }
                }
                else if (tag.Child.Name == "get")
                {
                    //{=var.get.[VariableName]}
                    foreach (VarObjectStruct varObjectStruct in varObjectList)
                    {
                        if (varObjectStruct.Name == tag.Child.Child.Name)
                        {
                            result = varObjectStruct.Fetch();

                            break;
                        }
                    }
                    if (result == null)
                    {
                        result = constError_SyntaxError;
                    }
                }
                else
                {
                    ModuleLog.Write(new string[] { constError_CommandNotFound, tag.InputText }, this, "VarObject", ModuleLog.LogType.ERROR);
                    result = constError_SyntaxError;
                }
            }
            catch (Exception ex)
            {
                ModuleLog.Write(new string[] { constError_ExecutingBlock, tag.InputText }, this, "VarObject", ModuleLog.LogType.DEBUG);
                ModuleLog.Write(ex, this, "VarObject", ModuleLog.LogType.ERROR);
                result = constError_SyntaxError;
            }
            return result;
        }
        //private string ArrayObject(Tag2 tag)
        //{
        //    string result = null;
        //    try
        //    {
        //        if (tag.Child.Name == "add" || tag.Child.Name == "addOnce")
        //        {
        //            VarObjectStruct varObjectStruct = null;

        //            //{=array.add.[ArrayName].[Value]}
        //            //{=array.addOnce.[ArrayName].[Value]}
        //            // If varObject is null, first use, create instance
        //            if (varObjectList == null)
        //            {
        //                varObjectList = new ArrayList();
        //            }
        //            // Is object with 'array name' already set ?
        //            foreach (VarObjectStruct isVariable in varObjectList)
        //            {
        //                if (tag.Child.Child.Name == isVariable.Name)
        //                {
        //                    varObjectStruct = isVariable;
        //                    break;
        //                }
        //            }
        //            if (varObjectStruct == null)
        //            {
        //                // VarObjectStruct entry is object with name and value propertis
        //                varObjectStruct = new VarObjectStruct(tag.Child.Child.Name, VarObjectStruct.Type.Array);
        //                if (tag.Child.Name == "add")
        //                {
        //                    varObjectStruct.Add(tag.Child.Child.Child.Name);
        //                }
        //                else
        //                {
        //                    varObjectStruct.AddOnce(tag.Child.Child.Child.Name);
        //                }
        //                // Add entry to row collection
        //                varObjectList.Add(varObjectStruct);
        //                result = ""; // varObjectStruct.Name + " set value to " + varObjectStruct.FetchNext();
        //            }
        //            else
        //            {
        //                if (tag.Child.Name == "add")
        //                {
        //                    varObjectStruct.Add(tag.Child.Child.Child.Name);
        //                }
        //                else
        //                {
        //                    varObjectStruct.AddOnce(tag.Child.Child.Child.Name);
        //                }
        //                // Remove var object tag and replace with value
        //                result = ""; // varObjectStruct.Name + " update value to " + varObjectStruct.FetchNext();
        //            }
        //        }
        //        else if (tag.Child.Name == "fetch")
        //        {
        //            // {=array.fetch."[ArrayName]"
        //            foreach (VarObjectStruct varObjectStruct in varObjectList)
        //            {
        //                if (varObjectStruct.Name == tag.Child.Child.Name)
        //                {
        //                    result = varObjectStruct.Fetch();
        //                    //ModuleLog.Write("VarObjectName: " + objectEntry.Name + "\r\nVarObjectValue: " + objectEntry.Value, this, "VarObject", ModuleLog.LogType.DEBUG);
        //                    break;
        //                }
        //            }
        //        }
        //        else if (tag.Child.Name == "fetchNext")
        //        {
        //            // {=array.fetch."[ArrayName]"
        //            foreach (VarObjectStruct varObjectStruct in varObjectList)
        //            {
        //                if (varObjectStruct.Name == tag.Child.Child.Name)
        //                {
        //                    result = varObjectStruct.FetchNext();
        //                    //ModuleLog.Write("VarObjectName: " + objectEntry.Name + "\r\nVarObjectValue: " + objectEntry.Value, this, "VarObject", ModuleLog.LogType.DEBUG);
        //                    break;
        //                }
        //            }
        //        }
        //        else
        //        {
        //            ModuleLog.Write(new string[] { constError_CommandNotFound, tag.InputText }, this, "ArrayObject", ModuleLog.LogType.ERROR);
        //            result = constError_SyntaxError;
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        ModuleLog.Write(new string[] { constError_ExecutingBlock, tag.InputText }, this, "ArrayObject", ModuleLog.LogType.DEBUG);
        //        ModuleLog.Write(ex, this, "ArrayObject", ModuleLog.LogType.ERROR);
        //        result = constError_SyntaxError;
        //    }
        //    return result;
        //}

        private string FormatObject(Tag2 tag)
        {
            string result = null;
            try
            {

                if (tag.Child.Name == "removenewline")
                {
                    //{=format.removerow.text}
                    result = tag.Child.Child.Name.Replace("\r\n", "");
                }
                else if (tag.Child.Name == "escape")
                {
                    ModuleLog.Write("Tag is on TODO list", this, "FormatObject", ModuleLog.LogType.WARNING);
                }
                else if (tag.Child.Name == "unescape")
                {
                    //{=format.unescape."[text]"}
                    result = tag.Child.Child.Name.Replace(@"\{=", "{=").Replace(@"\}", "}");
                }
                else if (tag.Child.Name == "\\")
                {
                    //{=format.\.text}
                    result = tag.Child.Child.Name.Replace(".", "<*D*>");
                    ModuleLog.Write("Tag is deprecated", this, "FormatObject", ModuleLog.LogType.WARNING);
                }
                else
                {
                    ModuleLog.Write(new string[] { constError_CommandNotFound, tag.InputText }, this, "ArrayObject", ModuleLog.LogType.ERROR);
                    result = constError_SyntaxError;
                }
            }
            catch (Exception ex)
            {
                ModuleLog.Write(new string[] { constError_ExecutingBlock, tag.InputText }, this, "ArrayObject", ModuleLog.LogType.DEBUG);
                ModuleLog.Write(ex, this, "ArrayObject", ModuleLog.LogType.ERROR);
                result = constError_SyntaxError;
            }
            return result;
        }
        private string XMLObject(object obj, string objectValue)
        {
            string result = null;
            Tag tag = new Tag("xml", objectValue);
            try
            {
                if (tag.Tags.Name == "xpath")
                {
                    if (tag.Tags.Tags.Name == "attribute")
                    {
                        //{=xml.xpath.attribute.atributeToGet.xpathText}
                        result = XMLParser.XMLObject.GetXPathAttributeValue(tag.Tags.Tags.Tags.Value, tag.Tags.Tags.Tags.Name);
                    }
                }
                else
                {
                    ModuleLog.Write(string.Concat(constError_SyntaxError, " (", objectValue, ")"), this, "XMLObject", ModuleLog.LogType.ERROR);
                    result = constError_SyntaxError;
                }

            }
            catch (Exception ex)
            {
                ModuleLog.Write(ex, this, "XMLObject", ModuleLog.LogType.ERROR);
                ModuleLog.Write(string.Concat(constError_SyntaxError, " (", objectValue, ")"), this, "XMLObject", ModuleLog.LogType.DEBUG);
                result = constError_SyntaxError;
            }
            return result;
        }
        private string RandomObject(object obj, string objectValue)
        {
            string result = null;
            Tag tag = new Tag("random", objectValue);
            try
            {
                if (tag.Tags.Name == "number")
                {
                    int minValue;
                    int maxValue;
                    minValue = int.Parse(tag.Tags.Tags.Name);
                    maxValue = int.Parse(tag.Tags.Tags.Value);
                    if (random == null)
                    {
                        random = new Random();
                    }
                    result = random.Next(minValue, maxValue).ToString();
                }
                else if (tag.Tags.Name == "string")
                {
                    int maxChar;
                    maxChar = int.Parse(tag.Tags.Value);

                    result = RandomString(maxChar);
                }
                else
                {
                    ModuleLog.Write(string.Concat(constError_SyntaxError, " (", objectValue, ")"), this, "RandomObject", ModuleLog.LogType.ERROR);
                    result = constError_SyntaxError;
                }

            }
            catch (Exception ex)
            {
                ModuleLog.Write(ex, this, "RandomObject", ModuleLog.LogType.ERROR);
                ModuleLog.Write(string.Concat(constError_SyntaxError, " (", objectValue, ")"), this, "RandomObject", ModuleLog.LogType.DEBUG);
                result = constError_SyntaxError;
            }
            return result;
        }

        private string MD5Object(object obj, string objectValue)
        {
            string result = null;
            Tag tag = new Tag("md5", objectValue);
            try
            {
                if (tag.Tags.Name == "text")
                {
                    result = MD5.MD5FromText(tag.Tags.Value);
                }
                else if (tag.Tags.Name == "file")
                {
                    result = MD5.MD5FromFile(tag.Tags.Value);
                }
                else
                {
                    ModuleLog.Write(string.Concat(constError_SyntaxError, " (", objectValue, ")"), this, "MD5Object", ModuleLog.LogType.ERROR);
                    result = constError_SyntaxError;
                }

            }
            catch (Exception ex)
            {
                ModuleLog.Write(ex, this, "MD5Object", ModuleLog.LogType.ERROR);
                ModuleLog.Write(string.Concat(constError_SyntaxError, " (", objectValue, ")"), this, "MD5Object", ModuleLog.LogType.DEBUG);
                result = constError_SyntaxError;
            }
            return result;
        }

        //private string FileObject(Tag2 tag)
        //{
        //    string result = null;
        //    try
        //    {
        //        if (tag.Child.Name == "copy")
        //        {
        //            // {=file.copy.[source].[destination]}
        //            string source = tag.Child.Child.Name;
        //            string destination = tag.Child.Child.Child.Name;

        //            ModuleLog.Write(new string[] { "Source: " + source, "Destination: " + destination }, this, "FileObject", ModuleLog.LogType.DEBUG);

        //            //ModuleLog.Write(string.Format("Source: {0}", source), this, "FileObject", ModuleLog.LogType.DEBUG);
        //            //ModuleLog.Write(string.Format("Destination: {0}", destination), this, "FileObject", ModuleLog.LogType.DEBUG);
        //            if (!File.Exists(source))
        //            {
        //                ModuleLog.Write(string.Format("File dont exists\r\n{0}", source), this, "FileObject", ModuleLog.LogType.WARNING);
        //            }
        //            else
        //            {
        //                Common.MakeAllSubFolders(Common.ExtractFolderFromPath(destination));
        //                File.Copy(source, destination, true);
        //            }
        //            result = "";

        //        }
        //        else if (tag.Child.Name == "move")
        //        {
        //            //int maxChar;
        //            //maxChar = int.Parse(tag.Tags.Value);
        //            result = "NIJE IMPLEMENTIRANO";
        //        }
        //        else
        //        {
        //            ModuleLog.Write(new string[] { constError_CommandNotFound, tag.InputText }, this, "FileObject", ModuleLog.LogType.ERROR);
        //            result = constError_SyntaxError;
        //        }

        //    }
        //    catch (Exception ex)
        //    {
        //        ModuleLog.Write(new string[] { constError_ExecutingBlock, tag.InputText }, this, "FileObject", ModuleLog.LogType.DEBUG);
        //        ModuleLog.Write(ex, this, "FileObject", ModuleLog.LogType.ERROR);
        //        result = constError_SyntaxError;
        //    }
        //    return result;
        //}


        /// <summary>
        /// Ovo bi trebalo ukloniti iz ove klase
        /// </summary>
        /// <param name="size"></param>
        /// <returns></returns>
        private string RandomString(int size)
        {
            StringBuilder builder = new StringBuilder();
            //int j = (int)DateTime.Now.Ticks;
            if (random == null)
            {
                random = new Random();
            }
            char ch;
            for (int i = 0; i < size; i++)
            {
                ch = Convert.ToChar(Convert.ToInt32(Math.Floor(26 * random.NextDouble() + 65)));
                builder.Append(ch);
            }

            return builder.ToString();
        }
    }
}
