using System;
using System.Collections.Generic;
using System.Collections;
using System.Text;

namespace UberTools.Plugin.TemplatesFiller.Class.TagObjects
{
    /// <summary>
    /// ActiveObject collect DataObject string name depend on depth index
    /// </summary>
    public class ActiveObject
    {
        ArrayList list;

        int lastDepthIndex = 0; // this will limit access to colection to max lastDepth, u zadnjem prolazu je dostignuta ova dubina
        int rowCounter = 0;

        public ActiveObject()
        {
            list = new ArrayList();
        }

        /// <summary>
        /// Get or set DataObject string name
        /// </summary>
        /// <param name="depthIndex"></param>
        /// <returns>String representing DataObject string name or null if depth index is out of range</returns>
        public string this[int depthIndex]
        {
            set
            {
                // set last depth index
                this.lastDepthIndex = depthIndex;
                // add/edit arraylist object
                if (depthIndex >= list.Count)
                {
                    // add new value to list
                    list.Add(value);
                }
                else
                {
                    // replace old values
                    list[depthIndex] = value;
                }
            }
            get
            {
                // check if this index is less then last depth index
                if (depthIndex < list.Count && depthIndex <= this.lastDepthIndex)
                {
                    return (string)list[depthIndex];
                }
                else
                {
                    return null;
                }
            }
        }

        public void Clear()
        {
            list.Clear();
        }

        public int RowCounter
        {
            get
            {
                return this.rowCounter;
            }
            set
            {
                this.rowCounter = value;
            }
        }
    }
}
