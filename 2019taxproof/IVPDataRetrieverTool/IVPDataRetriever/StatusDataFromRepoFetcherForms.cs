using Microsoft.Office.Interop.Excel;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml;

namespace IVPDataRetriever
{
    internal class StatusDataFetcherForms : StatusDataFetcherBase
    {
        private List<FormStatusData> m_StatusDataList = new List<FormStatusData>();

        private struct FormStatusData
        {
            internal string Id { get; set; }
            internal string Name { get; set; }
            internal string FormActivationStateCode { get; set; }
            internal string FormActivationState { get; set; }
            internal string SolutionName { get; set; }
        }

        protected override void OnGetStatusDataFromRepo(List<string> solutionFolders)
        {
            foreach (string solutionFolder in solutionFolders)
            {
                string entitiesFolderPath = Path.Combine(solutionFolder, "Entities");
                List<string> formXMLFiles = null;
                try
                {                    
                    List<string> formXMLDirectories = Directory.GetDirectories(entitiesFolderPath, "FormXml", SearchOption.AllDirectories).ToList();
                    foreach (string formXMLDirectory in formXMLDirectories)
                    {
                        formXMLFiles = formXMLFiles == null ? new List<string>() : formXMLFiles;
                        var fromXMLFileList = Directory.GetFiles(formXMLDirectory, "*.xml", SearchOption.AllDirectories).ToList();                        
                        formXMLFiles.AddRange(fromXMLFileList.Where(filePath => !Path.GetDirectoryName(filePath).EndsWith("mobile")));
                    }
                }
                catch (Exception)
                {
                }

                if (formXMLFiles == null)
                    continue;

                foreach (string formXMLFile in formXMLFiles)
                {
                    try
                    {
                        XmlDocument _xmlDoc = new XmlDocument();
                        _xmlDoc.Load(formXMLFile);
                        XmlElement root = _xmlDoc.DocumentElement;
                        AddStatusDataToList(solutionFolder, root);
                    }
                    catch (Exception ex)
                    {

                        throw;
                    }
                }
            }
        }

        protected override StringBuilder OnGetDataToBeWrittenToCSV()
        {
            StringBuilder _sb = new StringBuilder();
            _sb.AppendLine($"FormId,Form Name,Form Activation State Code,Form Activation State,SolutionName");
            foreach (var statusData in m_StatusDataList)
            {
                _sb.AppendLine($"{statusData.Id},{statusData.Name},{statusData.FormActivationStateCode},{statusData.FormActivationState},{statusData.SolutionName}");
            }
            return _sb;
        }

        protected override void OnWriteStatusDataToExcel(_Worksheet workSheet)
        {
            WriteHeaderToExcel(workSheet);
            WriteDataToExcel(workSheet);
        }

        private void AddStatusDataToList(string solutionFolder, XmlElement root)
        {

            FormStatusData _statusData = new FormStatusData();
            _statusData.Id = root.SelectSingleNode("//systemform/formid").InnerText.Replace("{", string.Empty).Replace("}", string.Empty);
            _statusData.Name = root.SelectSingleNode("//systemform/LocalizedNames/LocalizedName").Attributes.GetNamedItem("description").InnerText.Replace(",", ";");
            _statusData.FormActivationStateCode = root.SelectSingleNode("//systemform/FormActivationState").InnerText;
            _statusData.FormActivationState = root.SelectSingleNode("//systemform/FormActivationState").InnerText == "0" ? "InActive" : "Active";
            _statusData.SolutionName = Path.GetFileName(solutionFolder);
            m_StatusDataList.Add(_statusData);
        }

        private void WriteDataToExcel(_Worksheet workSheet)
        {
            for (int counter = 0; counter < m_StatusDataList.Count; counter++)
            {
                int columnCounter = 0;
                FormStatusData data = m_StatusDataList[counter];
                workSheet.Cells[counter + 2, ++columnCounter] = data.Id;
                workSheet.Cells[counter + 2, ++columnCounter] = data.Name;
                workSheet.Cells[counter + 2, ++columnCounter] = data.FormActivationStateCode;
                workSheet.Cells[counter + 2, ++columnCounter] = data.FormActivationState;
                workSheet.Cells[counter + 2, ++columnCounter] = data.SolutionName;
            }
        }

        private void WriteHeaderToExcel(_Worksheet workSheet)
        {
            int columnCounter = 0;
            workSheet.Name = "Forms";
            workSheet.Cells[1, ++columnCounter] = "FormId";
            workSheet.Cells[1, ++columnCounter] = "Form Name";
            workSheet.Cells[1, ++columnCounter] = "Form Activation State Code";
            workSheet.Cells[1, ++columnCounter] = "Form Activation State";
            workSheet.Cells[1, ++columnCounter] = "SolutionName";
            var headerRange = workSheet.Range[workSheet.Cells[1, 1], workSheet.Cells[1, columnCounter]];

            headerRange.Font.Bold = true;
            headerRange.VerticalAlignment = XlVAlign.xlVAlignCenter;
            headerRange.Interior.Color = XlRgbColor.rgbBlue;
            headerRange.Font.Color = XlRgbColor.rgbWhite;
        }
    }

}
