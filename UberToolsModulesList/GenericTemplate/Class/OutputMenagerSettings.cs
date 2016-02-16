using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

using UberTools.Modules.GenericTemplate.RowCollectionNS;
using UberTools.Modules.GenericTemplate.Forms;
using  DamirM.Modules;

namespace UberTools.Modules.GenericTemplate.Class
{
    class OutputMenagerSettings
    {
        public string sourceTemplateHeader;
        public string sourceTemplateBody;
        public string sourceTemplateFooter;
        public string sourceTemplateVariables;
        public string sourceFolder;
        public string sourceFileName;
        public string rowSpliterRegEx;
        public string columnSpliterRegEx;


        bool appendFile;
        Encoding encoding;

        public RowCollectionMenager rowCollectionMenager;
        public DestinationType destinationType;


        public enum DestinationType
        {
            File, Notepad, DataObjectCompareStrings
        }
        public OutputMenagerSettings(RowCollectionMenager rowCollectionMenager, DestinationType destinationType)
        {
            this.rowCollectionMenager = rowCollectionMenager;
            this.destinationType = destinationType;
        }
        public void SetTemplateText(string headerTemplate, string bodyTemplate, string footerTemplate, string variablesTemplate)
        {
            this.sourceTemplateHeader = headerTemplate;
            this.sourceTemplateBody = bodyTemplate;
            this.sourceTemplateFooter = footerTemplate;
            this.sourceTemplateVariables = variablesTemplate;
        }
        public void SetPathTemplate(string folder, string file)
        {
            this.sourceFolder = folder;
            this.sourceFileName = file;
        }
        public void SetRegExSpliter(string rowSpliterRegEx, string columnSpliterRegEx)
        {
            this.rowSpliterRegEx = rowSpliterRegEx;
            this.columnSpliterRegEx = columnSpliterRegEx;
        }
        public bool AppendFile
        {
            set
            {
                this.appendFile = value;
            }
            get
            {
                return this.appendFile;
            }
        }
        public Encoding Encoding
        {
            set
            {
                this.encoding = value;
            }
            get
            {
                return this.encoding;
            }
        }
    }
}
