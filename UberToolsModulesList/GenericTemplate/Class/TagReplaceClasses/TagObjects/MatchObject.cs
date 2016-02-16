using System;
using System.Collections.Generic;

using  DamirM.Modules;
using DamirM.Class;
using DamirM.Controls;
using DamirM.CommonLibrary;
using UberTools.Modules.GenericTemplate.Class;
using DamirM.CommonControls;

namespace UberTools.Modules.GenericTemplate.Class.TagObjects
{
    class MathObject
    {
        Tag2 tag;

        public MathObject(Tag2 tag)
        {
            this.tag = tag;
        }

        public string ProcessTag()
        {
            string result = null;
            try
            {
                if (tag.Child.Name == "sum")
                {
                    // {=math.sum.[numberOne].[numberTwo]}
                    long numberOne = long.Parse(tag.Child.Child.Name);
                    long numberTwo = long.Parse(tag.Child.Child.Child.Name);

                    result = (numberOne + numberTwo).ToString();

                }
                else if (tag.Child.Name == "subtract")
                {
                    // {=math.subtract.[numberOne].[numberTwo]}
                    long numberOne = long.Parse(tag.Child.Child.Name);
                    long numberTwo = long.Parse(tag.Child.Child.Child.Name);

                    result = (numberOne - numberTwo).ToString();
                }
                else if (tag.Child.Name == "multiplying")
                {
                    // {=math.multiplying.[numberOne].[numberTwo]}
                    long numberOne = long.Parse(tag.Child.Child.Name);
                    long numberTwo = long.Parse(tag.Child.Child.Child.Name);

                    result = (numberOne * numberTwo).ToString();
                }
                else if (tag.Child.Name == "division")
                {
                    // {=math.division.[numberOne].[numberTwo]}
                    long numberOne = long.Parse(tag.Child.Child.Name);
                    long numberTwo = long.Parse(tag.Child.Child.Child.Name);

                    result = (numberOne / numberTwo).ToString();
                }
                else if (tag.Child.Name == "mod")
                {
                    // {=math.mod.[numberOne].[numberTwo]}
                    long numberOne = long.Parse(tag.Child.Child.Name);
                    long numberTwo = long.Parse(tag.Child.Child.Child.Name);

                    result = (numberOne % numberTwo).ToString();
                }
                else if (tag.Child.Name == "abs")
                {
                    // {=math.mod.[numberOne].[numberTwo]}
                    long numberOne = long.Parse(tag.Child.Child.Name);

                    result = Math.Abs(numberOne).ToString();
                }

                // Error - not tag
                if (result == null)
                {
                    ModuleLog.Write(new string[] { TagsReplace.constError_CommandNotFound, tag.InputText }, this, "ProcessTag", ModuleLog.LogType.ERROR);
                    result = TagsReplace.constError_SyntaxError;
                }

            }
            catch (Exception ex)
            {
                ModuleLog.Write(new string[] { TagsReplace.constError_ExecutingBlock, tag.InputText }, this, "ProcessTag", ModuleLog.LogType.DEBUG);
                ModuleLog.Write(ex, this, "ProcessTag", ModuleLog.LogType.ERROR);
                result = TagsReplace.constError_SyntaxError;
            }
            return result;
        }







    }
}
