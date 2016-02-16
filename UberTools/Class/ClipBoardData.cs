using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using System.Web;

namespace NTHTools
{
    public class ClipBoardData: IEnumerable
    {
        public delegate void OnAddEventHandler(ClipBoardStruct data);
        public event OnAddEventHandler Added;
        public const int id_max = 10;
        private Array list = Array.CreateInstance(typeof(ClipBoardStruct), id_max);
        private int id_set = 0;
        public ClipBoardData()
        {
        }
        public void Add(object title, object data, string format)
        {
            ClipBoardStruct cbStruct;
            for (int j = 0; j < 2; j++)
            {
                for (int i = id_set; i < list.GetLength(0); i++)
                {
                    if (!this[i].save)
                    {
                        id_set = id_set < id_max - 1 ? id_set + 1 : 0;
                        cbStruct = new ClipBoardStruct(title, data, format);
                        list.SetValue(cbStruct, i);
                        Added(cbStruct);
                        return;
                    }
                }
                id_set = 0;
            }
        }
        public bool IsUniqe()
        {
            bool indikator = true;
            try
            {
                bool isText = Clipboard.ContainsText();
                string textData = null;
                if (isText)
                {
                    textData = Clipboard.GetText();
                }
                foreach (ClipBoardStruct clipBoard in list)
                {
                    if (clipBoard.format == DataFormats.Text && isText)
                    {
                        if ((string)clipBoard.data == textData)
                        {
                            indikator = false;
                        }
                    }

                }
            }
            catch { indikator = false; }
            return indikator;
        }
        public int ActiveID()
        {
            int instance = -1;
            for(int i = 0; i  < ClipBoardData.id_max; i++)
            {
                if (this[i].IsEqual(ClipBoardStruct.GetClipBoardData(), ClipBoardStruct.GetFormat()))
                {
                    instance = i;
                    break;
                }

            }
            return instance;
        }
        public void AddClipBoard()
        {
            if (Clipboard.ContainsText())
            {
                Add(null, Clipboard.GetText(), DataFormats.Text);
            }
            else if (Clipboard.ContainsImage())
            {
                Add(null, Clipboard.GetImage(), DataFormats.Bitmap);
            }
            else if (Clipboard.ContainsFileDropList())
            {
                Add(null, Clipboard.GetFileDropList(), DataFormats.FileDrop);
            }
        }
        public ClipBoardStruct this[int id]
        {
            get { return (ClipBoardStruct)list.GetValue(id); }
            set { list.SetValue(value, id); }
        }
        public IEnumerator GetEnumerator()
        {
            ClipBoardStruct clipBoardStruct;
            for (int i = 0; i < list.GetLength(0); i++)
            {
                clipBoardStruct = (ClipBoardStruct)list.GetValue(i);
                if (clipBoardStruct.data != null)
                {
                    yield return clipBoardStruct;
                }
                else
                {
                    break;
                }
            }
        }

        public struct ClipBoardStruct
        {
            private string title;
            public object data;
            public bool save;
            public string format;
            private DateTime created;
            public ClipBoardStruct(object title, object data, string format)
            {
                this.data = data;
                this.save = false;
                this.format = format;
                this.created = DateTime.Now;
                this.title = "";    // dummy set;
                this.title = title == null ? GenerateTitle(data, format) : (string)title;
            }
            public override string ToString()
            {
                if (data == null)
                {
                    return "<no data>";
                }
                else
                {
                    TimeSpan time = DateTime.Now.Subtract(this.created);
                    return string.Format("{0} [{1}]", this.title, (time.Minutes > 0 ? (int)time.TotalMinutes + " min" : time.Seconds + " sec"));
                }
            }
            private string GenerateTitle(object data, string format)
            {
                string name = ""; ;
                if (format == DataFormats.Text)
                {
                    name = (string)data;
                    int count = name.Length;
                    name = Regex.Replace(name.TrimStart(' '), "\r\n", " ");
                    name = string.Format("{0} [{1}]", (name.Length > 35 ? name.Substring(0, 35) : name), count);
                }
                else if (format == DataFormats.Bitmap)
                {
                    name = "Image entery ";
                }
                else if (format == DataFormats.FileDrop)
                {
                    System.Collections.Specialized.StringCollection collection = (System.Collections.Specialized.StringCollection)data;
                    string[] fileList = new string[collection.Count];
                    collection.CopyTo(fileList, 0);
                    name = string.Format("File link{1} ({0} file{1})", fileList.Length, fileList.Length == 1 ? "" : "s");
                }
                else
                {
                    name = "Unknown object";
                }
                return name;
            }
            public string GenerateBody()
            {
                string name = "";
                if (format == DataFormats.Text)
                {
                    name = (string)data;
                    name = name.Length > 256 ? name.Substring(0, 256) + "..." : name;
                }
                else if (format == DataFormats.Bitmap)
                {
                    name = "Image entery ";
                }
                else if (format == DataFormats.FileDrop)
                {
                    System.Collections.Specialized.StringCollection collection = (System.Collections.Specialized.StringCollection)data;
                    string[] fileList = new string[collection.Count];
                    collection.CopyTo(fileList, 0);
                    foreach (string file in fileList)
                    {
                        name += file + "\r\n";
                    }
                }
                else
                {
                    name = "Unknown object";
                }
                return name;
            }
            public void MakeActive()
            {
                if (format == DataFormats.Text)
                {
                    Clipboard.SetText((string)data);
                }
                else if (format == DataFormats.Bitmap)
                {
                    Clipboard.SetImage((System.Drawing.Image)data);
                }
                else if (format == DataFormats.FileDrop)
                {
                    Clipboard.SetFileDropList((System.Collections.Specialized.StringCollection)data);
                }
            }
            public bool IsEqual(object data, string format)
            {
                bool indikator = false;
                if (format == DataFormats.Text)
                {
                    if ((string)this.data == (string)data)
                    {
                        indikator = true;
                    }
                }
                else if (format == DataFormats.Bitmap)
                {

                }
                else if (format == DataFormats.FileDrop)
                {
                }
                else
                {
                }
                return indikator;
            }
            public string GetStringFromData()
            {
                if (this.format == DataFormats.Text)
                {
                    return (string)data;
                }
                else if (this.format == DataFormats.Bitmap)
                {

                }
                else if (this.format == DataFormats.FileDrop)
                {
                    string buff = "";
                    foreach (string file in (System.Collections.Specialized.StringCollection)this.data)
                    {
                        buff += file + ";";
                    }
                    return buff;
                }
                else
                {
                }
                return null;
            }
            public static object GetClipBoardData()
            {
                string format = GetFormat();
                if (format == DataFormats.Text)
                {
                    return Clipboard.GetText();
                }
                else if (format == DataFormats.Bitmap)
                {

                }
                else if (format == DataFormats.FileDrop)
                {
                    string buff = "";
                    foreach (string file in Clipboard.GetFileDropList())
                    {
                        buff += file + ";";
                    }
                    return buff;
                }
                else
                {
                }
                return null;
            }
            public static string GetFormat()
            {
                string format = "";
                if (Clipboard.ContainsText())
                {
                    format = DataFormats.Text;
                }
                return format;
            }

        }
    }
}
