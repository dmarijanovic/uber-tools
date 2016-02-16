using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DamirM.Modules
{
    public class EncodingMenager
    {
        private Encoding encoding;
        private bool useOverrideName = false;
        private string overrideName;
        public EncodingMenager(Encoding encoding)
        {
            this.encoding = encoding;
        }
        public EncodingMenager(Encoding encoding, string overrideName)
        {
            this.encoding = encoding;
            this.useOverrideName = true;
            this.overrideName = overrideName;
        }


        public static IEnumerable<EncodingMenager> GetEnumerator()
        {
            foreach (EncodingInfo encodingInfo in Encoding.GetEncodings())
            {
                yield return new EncodingMenager(encodingInfo.GetEncoding());
            }
            // UTF-8 withoutbom
            Encoding utf8 = new UTF8Encoding(false);
            yield return new EncodingMenager(utf8, utf8.EncodingName + " without BOM");
        }
        public override string ToString()
        {
            if (useOverrideName)
            {
                return overrideName;
            }
            else
            {
                return encoding.EncodingName;
            }
        }
        public Encoding Encoding
        {
         get
         {
             return encoding;
         }
        }

    }
}
