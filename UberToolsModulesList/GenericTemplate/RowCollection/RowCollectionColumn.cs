using System;
using System.Collections.Generic;
using System.Text;

using DamirM.Class;
using DamirM.CommonControls;

namespace UberTools.Modules.GenericTemplate.RowCollectionNS
{
    public struct RowCollectionColumn
    {
        private string name;
        private string value;

        public RowCollectionColumn(string value)
        {
            this.name = "";
            this.value = value;
        }
        public string Name
        {
            get { return this.name; }
            set { name = value; }
        }
        public string Value
        {
            get { return Tag2.Excape(this.value); }
        }
        public string ValueNoExcape
        {
            get { return this.value; }
        }
    }
}
