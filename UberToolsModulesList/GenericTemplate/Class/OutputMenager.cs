using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

using UberTools.Modules.GenericTemplate.Forms;
using UberTools.Modules.GenericTemplate.RowCollectionNS;
using DamirM.Modules;
using DamirM.CommonLibrary;
using UberTools.Modules.GenericTemplate.InputData;


namespace UberTools.Modules.GenericTemplate.Class
{
    class OutputMenager
    {
        OutputMenagerSettings outputMenagerSettings;
        TagsReplace tagsReplace;

        Notepad notepad;
        StreamWriter sw;

        private string sw_filePath = "";

        public OutputMenager(OutputMenagerSettings outputMenagerSettings)
        {
            this.outputMenagerSettings = outputMenagerSettings;
            tagsReplace = new TagsReplace(outputMenagerSettings.rowCollectionMenager);
        }
        private void ReplaceTagsOnce()
        {
            // Replace all input tags, once only
            outputMenagerSettings.sourceTemplateVariables = tagsReplace.ReplaceTagsOnce(outputMenagerSettings.sourceTemplateVariables);
            outputMenagerSettings.sourceTemplateHeader = tagsReplace.ReplaceTagsOnce(outputMenagerSettings.sourceTemplateHeader);
            outputMenagerSettings.sourceTemplateBody = tagsReplace.ReplaceTagsOnce(outputMenagerSettings.sourceTemplateBody);
            outputMenagerSettings.sourceTemplateFooter = tagsReplace.ReplaceTagsOnce(outputMenagerSettings.sourceTemplateFooter);

            if (OutputMenagerSettings.DestinationType.File == outputMenagerSettings.destinationType)
            {
                outputMenagerSettings.sourceFolder = tagsReplace.ReplaceTagsOnce(outputMenagerSettings.sourceFolder);
                outputMenagerSettings.sourceFileName = tagsReplace.ReplaceTagsOnce(outputMenagerSettings.sourceFileName);
            }
        }
        public void SelectObjectData()
        {
            string templateVariable;
            string templateHeader;
            string templateBody;
            string templateFooter;

            // Reset all setings on RowCollections objects
            outputMenagerSettings.rowCollectionMenager.ResetSettings();

            ReplaceTagsOnce();

            foreach (RowCollectionRow row in (IEnumerable<RowCollectionRow>)outputMenagerSettings.rowCollectionMenager)
            {
                // increment row counter
                outputMenagerSettings.rowCollectionMenager.ActiveObjectInstance.RowCounter++;

                templateVariable = tagsReplace.ReplaceTags(outputMenagerSettings.sourceTemplateVariables, row);
                templateHeader = tagsReplace.ReplaceTags(outputMenagerSettings.sourceTemplateHeader, row);
                templateBody = tagsReplace.ReplaceTags(outputMenagerSettings.sourceTemplateBody, row);
                templateFooter = tagsReplace.ReplaceTags(outputMenagerSettings.sourceTemplateFooter, row);

                if (outputMenagerSettings.destinationType == OutputMenagerSettings.DestinationType.File)
                {
                    this.DestinationFile(templateHeader, templateBody, templateFooter, row, row.Index, row.rowCollection.Rows.Count);
                }
                else if (outputMenagerSettings.destinationType ==  OutputMenagerSettings.DestinationType.Notepad)
                {
                    this.DestinationNotepad(templateHeader, templateBody, templateFooter, row.Index, row.rowCollection.Rows.Count);
                }
                else if (outputMenagerSettings.destinationType == OutputMenagerSettings.DestinationType.DataObjectCompareStrings)
                {
                    this.DestinationObjectData_CompareStrings(templateHeader, templateBody, templateFooter, row, row.Index, row.rowCollection.Rows.Count);
                }
                System.Windows.Forms.Application.DoEvents();
            }

            // Close stream writer object
            if (sw != null)
            {
                sw.Close();
            }

        }
        public void Run_Counter(int counter)
        {
            string templateVariable;
            string templateHeader;
            string templateBody;
            string templateFooter;

            JobProgress.Start();

            // Reset all setings on RowCollections objects
            outputMenagerSettings.rowCollectionMenager.ResetSettings();

            ReplaceTagsOnce();

            for (int i = 0; i < counter; i++)
            {
                // increment row counter
                outputMenagerSettings.rowCollectionMenager.ActiveObjectInstance.RowCounter++;

                templateVariable = tagsReplace.ReplaceTags(outputMenagerSettings.sourceTemplateVariables, null);
                templateHeader = tagsReplace.ReplaceTags(outputMenagerSettings.sourceTemplateHeader, null);
                templateBody = tagsReplace.ReplaceTags(outputMenagerSettings.sourceTemplateBody, null);
                templateFooter = tagsReplace.ReplaceTags(outputMenagerSettings.sourceTemplateFooter, null);

                if (outputMenagerSettings.destinationType == OutputMenagerSettings.DestinationType.File)
                {
                    this.DestinationFile(templateHeader, templateBody, templateFooter, null, i, counter);
                }
                else if (outputMenagerSettings.destinationType == OutputMenagerSettings.DestinationType.Notepad)
                {
                    this.DestinationNotepad(templateHeader, templateBody, templateFooter, i, counter);
                }
                else if (outputMenagerSettings.destinationType == OutputMenagerSettings.DestinationType.DataObjectCompareStrings)
                {
                    this.DestinationObjectData_CompareStrings(templateHeader, templateBody, templateFooter, null, i, counter);
                }
                System.Windows.Forms.Application.DoEvents();
                //JobProgress.Write("Radim ...." + i );
            }
            // Close stream writer object
            if (sw != null)
            {
                sw.Close();
            }
            JobProgress.Ready();
        }

        private void DestinationFile(string templateHeader, string templateBody, string templateFooter, RowCollectionRow row, int rowID, int rowMax)
        {
            string filePath;
            string folder;
            string file;
            bool writeHeader = false;
            bool writeFooter = false;

            folder = tagsReplace.ReplaceTags(outputMenagerSettings.sourceFolder, row);
            file = tagsReplace.ReplaceTags(outputMenagerSettings.sourceFileName, row);
            folder = Common.SetSlashOnEndOfDirectory(folder);
            filePath = folder + file;

            if (!Directory.Exists(folder))
            {
                Common.MakeAllSubFolders(folder);
            }

            //fileName = tagsReplace.ReplaceTags(outputMenagerSettings.sourceFileName, row);

            // Is header text length more then 0 caracther
            if (templateHeader.Length > 0)
            {
                // If append is true then only write header if file dont exist
                if (outputMenagerSettings.AppendFile)
                {
                    if (!File.Exists(filePath))
                    {
                        writeHeader = true;
                    }
                }
                else
                {
                    // Append is false, so write header in each file 
                    writeHeader = true;
                }
            }
            //
            // Is footer text lenght more then 0 charachter
            if (templateFooter.Length > 0)
            {
                // If append is true then only write header if file dont exist
                if (outputMenagerSettings.AppendFile)
                {
                    // Ovdje se mora dodati provjera koja ce kad se svi redovi izvrte pogledati gdje nije upisao footer
                    // Ova ispod provjera je samo zakrpa u slucaju da je destinacion name staticno a nije varijabla
                    if (rowID + 1 >= rowMax)
                    {
                        writeFooter = true;
                    }
                }
                else
                {
                    // Append is false, so write header in each file 
                    writeFooter = true;
                }
            }

            // If stream writer last file path is not current path make new stream writer object
            if (!outputMenagerSettings.AppendFile || (sw_filePath != filePath) || sw == null)
            {
                // Close last sw object and open new
                if (sw != null)
                {
                    sw.Close();
                }
                sw = new StreamWriter(filePath, outputMenagerSettings.AppendFile, outputMenagerSettings.Encoding);
                sw_filePath = filePath;
            }

            if (writeHeader)
            {
                // If header is true then write header
                sw.WriteLine(templateHeader);
            }

            // Write body

            //////////////// TO DO WriteLine bug
            if (rowID + 1 >= rowMax)
            {
                sw.Write(templateBody);
                //ModuleLog.Write("Write", this, "DestinationFile", ModuleLog.LogType.DEBUG);
            }
            else
            {
                sw.Write(templateBody);
                //ModuleLog.Write("WriteLine", this, "DestinationFile", ModuleLog.LogType.DEBUG);
            }


            if (writeFooter)
            {
                // If header is true then write header
                sw.WriteLine(templateFooter);
            }
        }
        private Notepad DestinationNotepad(string templateHeader, string templateBody, string templateFooter, int rowID, int rowMax)
        {
            if (this.notepad == null)
            {
                this.notepad = new Notepad(templateHeader + Environment.NewLine);
                this.notepad.Show(System.Windows.Forms.Application.OpenForms[0]);
            }

            this.notepad.Append(templateBody + Environment.NewLine);

            if (rowID + 1 >= rowMax)
            {
                this.notepad.Append(templateFooter);
            }
            return notepad;
        }
        private void DestinationObjectData_CompareStrings(string templateHeader, string templateBody, string templateFooter, RowCollectionRow row, int rowID, int rowMax)
        {

            TextParser textParser = new TextParser(outputMenagerSettings.rowCollectionMenager);

            textParser.AutomaticAddToRowCollectionMenager(templateBody, outputMenagerSettings.columnSpliterRegEx, outputMenagerSettings.rowSpliterRegEx);
            //ObjectRow objectRow = new ObjectRow(new string[] { templateBody });

            //outputMenagerSettings.rowCollectionMenager.AddRow(objectRow);
        }

    }
}
