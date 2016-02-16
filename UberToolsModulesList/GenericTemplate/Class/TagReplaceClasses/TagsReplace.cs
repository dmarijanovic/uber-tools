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
using DamirM.CommonControls;

using UberTools.Modules.GenericTemplate.Class.TagObjects;

namespace UberTools.Modules.GenericTemplate.Class
{
    partial class TagsReplace
    {
        private const int constNumberObject_counter_defaultValue = -36000;

        // varObject is dinamic variable object
        public ArrayList varObjectList = null;
        private RowCollectionMenager rowCollectionMenager = null;
        private Random random;
        private InputObject inputObject;

        bool isInitialization;

        private int numberObject_counter = constNumberObject_counter_defaultValue;

        public const string constError_SyntaxError = "Syntax error";
        public const string constError_CommandNotFound = "Command not found";
        public const string constError_ExecutingBlock = "Execution error in block";

        public TagsReplace(RowCollectionMenager rowCollectionMenager)
        {
            this.rowCollectionMenager = rowCollectionMenager;
            varObjectList = new ArrayList();
            inputObject = new InputObject(this);
        }

        public string ReplaceTags(string text, RowCollectionRow row)
        {
            return ReplaceTags(text, row, false);
        }
        public string ReplaceTags(string text, RowCollectionRow row, bool isInitialization)
        {
            int indexOfFirst = 0;
            int indexOfLast = 0;
            int indexOfLastNoTag = 0;
            int tagCounter = 0;
            bool tagSearchActive = false;
            string result = "";
            string processedText = "";

            this.isInitialization = isInitialization;

            for (int i = 0; i < text.Length; i++)
            {
                // Find first tag, {
                if (text[i] == '{')
                {
                        if (!Tag2.IsExcaped(text, i))
                        {
                            // if start tag is complete, is like {=
                            if ((text.Length > 2 && i < text.Length - 2) && text[i + 1] == '=')
                            {
                                // increment tag counter
                                tagCounter++;
                                // if this is first tag that is find then save indexOf
                                if (tagSearchActive == false)
                                {
                                    indexOfFirst = i;
                                    // indicate thats tag search is active, from now if tagCounter is 0 then cut tag and call ReplaceTagsFromInToOut(x, x)
                                    tagSearchActive = true;
                                    // start tag find next for
                                    continue;
                                }
                            }
                        }
                    //}
                }


                // Find last tag
                if (text[i] == '}')
                {
                    // Check if is not excaped
                    if (!Tag2.IsExcaped(text, i))
                    {
                        // Decrement tag counter and set indexOfLast
                        tagCounter--;
                        indexOfLast = i;
                    }
                }

                // if tagCounter is less then zero then throw error
                if (tagCounter < 0)
                {
                    throw new Exception("Template syntax error at end of " + Environment.NewLine + text.Substring(indexOfFirst, indexOfLast - indexOfFirst));
                }

                // Check is tag search is active and tagCounter value is zero, if is zero then call ReplaceTagsFromInToOut(x, x)
                if (tagSearchActive)
                {
                    // if tagCounter is zero then call ReplaceTagsFromInToOut(x, x)
                    if (tagCounter == 0)
                    {
                        // call function to parse tags extracted
                        result = ReplaceTagsFromInToOut(text.Substring(indexOfFirst, (indexOfLast - indexOfFirst) + 1), row);
                        // copy no tag text
                        processedText += text.Substring(indexOfLastNoTag, indexOfFirst - indexOfLastNoTag);
                        indexOfLastNoTag = indexOfLast + 1;
                        // replace extracted tags block with result from function with 2 (0, 1) (2 - 1) = 1 <= 1 , 1 + 1 = 2, (2 - 1)  - 1 1
                        //processedText += string.Concat(text.Substring(0, indexOfFirst), result, text.Length - 1 >= indexOfLast ? text.Substring(indexOfLast + 1, (text.Length - 1) - indexOfLast) : "");
                        processedText += result;
                        // reset varables
                        tagSearchActive = false;
                    }
                }

            }

            // Copy text after last tag
            if (indexOfLastNoTag < text.Length)
            {
                processedText += text.Substring(indexOfLastNoTag, text.Length - indexOfLastNoTag);
            }

            // if tagCounter is not zero then throw error
            if (tagCounter > 0)
            {
                throw new Exception("Template syntax error at start of " + Environment.NewLine + text.Substring(indexOfFirst, text.Length - indexOfFirst));
            }

            // Do all unexcape
            //processedText = processedText.Replace("\\\\", "\\");
            processedText = Tag2.UnEscape(processedText);


            // log if change is made
            if (text != processedText)
            {
                ModuleLog.Write(processedText, this, "ReplaceTags", ModuleLog.LogType.DEBUG);
            }
            return processedText;
        }

        private string ReplaceTagsFromInToOut(string text, RowCollectionRow row)
        {
            string result = null;
            string objectName = "";
            string objectValue = "";
            //string oldText = "";
            // Define all regex match with patern
            //Regex regexMain = new Regex(@"\{=[\w]+\.[^{}]+\}");

            // Test regex expresion added for escape function
            // za right je nije(?!mal)
            Regex regexMain = new Regex(@"(?<![^\\]\\)\{=[\w]+\.(?!.*(?<![^\\]\\){=.*(?<!\\)}).*?(?<!\\)\}",RegexOptions.Singleline);
            Regex regex;
            // Get all matches
            MatchCollection matchList;
            // do loop is needed if tags are nested
            do
            {
                matchList = regexMain.Matches(text);
                foreach (Match match in matchList)
                {
                    // Define regex string that will extract object name
                    regex = new Regex(@"\{=|\..+\}",RegexOptions.Singleline);
                    // get that object name and save it
                    objectName = regex.Replace(match.Value, "");
                    // Define regex string that will extract object value
                    //regex = new Regex(@"{=[\w]+\.|}+");
                    regex = new Regex(@"(?<!\\)\{=[\w]+\.|(?<!\\)\}");
                    // get that object value
                    objectValue = regex.Replace(match.Value, "");
                    // Call suported object name and replace tags in text
                    result = this.ReplaceSuportedObject(objectName, objectValue, row);
                    if (result != null)
                    {
                        text = ReplaceOnce(text, match.Value, result);
                    }
                    else
                    {
                        // No suported object found
                        text = text.Replace(match.Value, match.Value.Replace("{=", "(=ubertools_replace_string)"));
                        // dont loog this
                        if (isInitialization == false)
                        {
                            ModuleLog.Write(text, this, "ReplaceTagsFromInToOut", ModuleLog.LogType.DEBUG);
                        }
                    }
                }
            } while (matchList.Count > 0);
            text = text.Replace("(=ubertools_replace_string)", "{=");

            return text;
        }

        public string ReplaceTagsOnce(string text)
        {
            inputObject.ProcessText(text);
            ReplaceTags(text, null, true);

            return text;
        }


        private string ReplaceOnce(string text, string replace, string replaceWith)
        {
            string result = "";
            int indexOf;

            indexOf = text.IndexOf(replace);
            result = text.Substring(0, indexOf) + replaceWith;

            result += text.Substring(indexOf + replace.Length, text.Length - (indexOf + replace.Length));
            return result;
        }

        private string ReplaceSuportedObject(string objectName, string objectValue, RowCollectionRow row)
        {
            //
            //  I N F O - ReplaceTagsFromInToOut will not cut this 
            //

            Tag2 tag = new Tag2("{=" + objectName + "." + objectValue);

            if (objectName == "date")
            {
                // Call to datetime object
                return this.DateObject(objectValue);
            }
            else if (objectName == "string")
            {
                // Call to main generic method, other method will call it to get object row value and then format it
                // this one just return pure text value 


                //
                //   Ovo sa split je privremeno ovdje stavito
                //
                if (tag.Child.Name.Equals("split"))
                {
                    return StringObject(row, tag);
                }
                else
                {
                    return StringObject(row, objectValue);
                }
            }
            else if (objectName == "nth")
            {
                // Call to main generic method, other method will call it to get object row value and then format it
                // this one just return pure text value 
                return NTHObject(row, objectValue);
            }
            else if (objectName == "number")
            {
                // Call to main generic method, other method will call it to get object row value and then format it
                // this one just return pure text value 
                return NumberObject(row, objectValue);
            }
            else if (tag.Name == "input")
            {
                // Call to InputObject
                return InputObject(row, tag);
            }
            else if (tag.Name == "var")
            {
                // Call to VarObject
                return VarObject(tag);
            }
            else if (tag.Name == "array")
            {
                // Call to ArrayObject
                ArrayObject arrayObject = new ArrayObject(tag, varObjectList);
                return arrayObject.ProcessTag();
            }
            else if (tag.Name == "format")
            {
                // Call to FormatObject, get and set method
                return FormatObject(tag);
            }
            else if (objectName == "xml")
            {
                // Call to FormatObject, get and set method
                return XMLObject(row, objectValue);
            }
            else if (objectName.StartsWith("random"))
            {
                return RandomObject(objectName, objectValue);
            }
            else if (objectName.StartsWith("md5"))
            {
                return MD5Object(objectName, objectValue);
            }
            else if (tag.Name == "file")
            {
                FileObject fileObject = new FileObject(tag, ref varObjectList);
                return fileObject.ProcessTag();
            }
            else if (tag.Name == "dir")
            {
                DirObject dirObject = new DirObject(tag, ref varObjectList);
                return dirObject.ProcessTag();
            }
            else if (tag.Name == "graphics")
            {
                GraphicsObject fileObject = new GraphicsObject(tag);
                return fileObject.ProcessTag();
            }
            else if (tag.Name == "math")
            {
                MathObject mathObject = new MathObject(tag);
                return mathObject.ProcessTag();
            }
            else
            {
                // objects that dont need be in initialization proccess
                if (isInitialization == false)
                {
                    if (tag.Name == "active")
                    {
                        return ActiveObject(tag);

                    }
                    else if (tag.Name == "data")
                    {
                        // Call to main generic method, other method will call it to get object row value and then format it
                        // this one just return pure text value 
                        return DataObjectGetValue(row, tag);
                    }
                    //else if (objectName.StartsWith("data"))
                    //{
                    //    return DataObjectGetValue(objectName, objectValue);
                    //}
                    else
                    {
                        return DataObjectGetValue(tag);
                    }
                }
            }

            return null;
        }
    }
}
