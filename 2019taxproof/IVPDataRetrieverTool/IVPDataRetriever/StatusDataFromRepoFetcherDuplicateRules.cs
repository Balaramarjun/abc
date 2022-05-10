using Microsoft.Office.Interop.Excel;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml;

namespace IVPDataRetriever
{
    internal class StatusDataFetcherDuplicateRules : StatusDataFetcherBase
    {
        private List<DuplicateRuleStatusData> m_StatusDataList = new List<DuplicateRuleStatusData>();

        private struct DuplicateRuleStatusData
        {
            internal string Id { get; set; }
            internal string Name { get; set; }
            internal string StateCode { get; set; }
            internal string State { get; set; }
            internal string StatusCode { get; set; }
            internal string Status { get; set; }
            internal string BaseEntity { get; set; }
            internal string SolutionName { get; set; }
        }

        protected override void OnGetStatusDataFromRepo(List<string> solutionFolders)
        {
            foreach (string solutionFolder in solutionFolders)
            {
                if (!(Path.GetFileName(solutionFolder).Equals("CampusManagementDefaultData") || Path.GetFileName(solutionFolder).Equals("CampusManagementDefaultData_Upgrade")))
                    continue;

                string duplicateRuleFolderPath = Path.Combine(solutionFolder, "CampusManagement");

                string duplicateRuleXMLFile = null;
                try
                {
                    duplicateRuleXMLFile = Directory.GetFiles(duplicateRuleFolderPath, "data.xml", SearchOption.TopDirectoryOnly).ToList().FirstOrDefault();
                }
                catch (Exception)
                {
                }

                if (duplicateRuleXMLFile == null)
                    continue;

                XmlDocument _xmlDoc = new XmlDocument();
                _xmlDoc.Load(duplicateRuleXMLFile);
                XmlElement root = _xmlDoc.DocumentElement;
                AddStatusDataToList(solutionFolder, root);
            }
        }

        protected override StringBuilder OnGetDataToBeWrittenToCSV()
        {
            StringBuilder _sb = new StringBuilder();
            _sb.AppendLine($"DuplicateRuleId,DuplicateRule Name,StateCode,State,StatusCode,Status,BaseEntity,SolutionName");
            foreach (var statusData in m_StatusDataList)
            {
                _sb.AppendLine($"{statusData.Id},{statusData.Name},{statusData.StateCode},{statusData.State},{statusData.StatusCode},{statusData.Status},{statusData.BaseEntity},{statusData.SolutionName}");
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
            XmlNodeList duplicateRuleRecords = root.SelectNodes("//entity[@name='duplicaterule']/records/record");
            foreach (XmlNode duplicateRuleRecord in duplicateRuleRecords)
            {
                DuplicateRuleStatusData _statusData = new DuplicateRuleStatusData();
                _statusData.Id = duplicateRuleRecord.Attributes.GetNamedItem("id")?.InnerText;
                _statusData.Name = duplicateRuleRecord.SelectNodes(".//field[@name='name']").Item(0).Attributes.GetNamedItem("value").InnerText.Replace(',',';');
                _statusData.StateCode = duplicateRuleRecord.SelectNodes(".//field[@name='statecode']").Item(0).Attributes.GetNamedItem("value").InnerText;
                _statusData.State = duplicateRuleRecord.SelectNodes(".//field[@name='statecode']").Item(0).Attributes.GetNamedItem("value").InnerText == "0" ? "InActive" : "Active";
                string statusCode = duplicateRuleRecord.SelectNodes(".//field[@name='statuscode']").Item(0).Attributes.GetNamedItem("value").InnerText;
                _statusData.StatusCode = statusCode;
                _statusData.Status = statusCode == "0" ? "Unpublished" : statusCode == "1" ? "Publishing" : "Published";
                _statusData.BaseEntity = duplicateRuleRecord.SelectNodes(".//field[@name='baseentityname']").Item(0).Attributes.GetNamedItem("value").InnerText;
                _statusData.SolutionName = Path.GetFileName(solutionFolder);
                m_StatusDataList.Add(_statusData);
            }
        }

        private void WriteDataToExcel(_Worksheet workSheet)
        {
            for (int counter = 0; counter < m_StatusDataList.Count; counter++)
            {
                int columnCounter = 0;
                DuplicateRuleStatusData data = m_StatusDataList[counter];
                workSheet.Cells[counter + 2, ++columnCounter] = data.Id;
                workSheet.Cells[counter + 2, ++columnCounter] = data.Name;
                workSheet.Cells[counter + 2, ++columnCounter] = data.StateCode;
                workSheet.Cells[counter + 2, ++columnCounter] = data.State;
                workSheet.Cells[counter + 2, ++columnCounter] = data.StatusCode;
                workSheet.Cells[counter + 2, ++columnCounter] = data.Status;
                workSheet.Cells[counter + 2, ++columnCounter] = data.BaseEntity;
                workSheet.Cells[counter + 2, ++columnCounter] = data.SolutionName;
            }
        }

        private void WriteHeaderToExcel(_Worksheet workSheet)
        {
            int columnCounter = 0;
            workSheet.Name = "Duplicate Rules";
            workSheet.Cells[1, ++columnCounter] = "Duplicate Rule Id";
            workSheet.Cells[1, ++columnCounter] = "Duplicate Rule Name";
            workSheet.Cells[1, ++columnCounter] = "State Code";
            workSheet.Cells[1, ++columnCounter] = "State";
            workSheet.Cells[1, ++columnCounter] = "Status Code";
            workSheet.Cells[1, ++columnCounter] = "Status";
            workSheet.Cells[1, ++columnCounter] = "Base Entity"; ;
            workSheet.Cells[1, ++columnCounter] = "Solution Name"; ;
            var headerRange = workSheet.Range[workSheet.Cells[1, 1], workSheet.Cells[1, columnCounter]];

            headerRange.Font.Bold = true;
            headerRange.VerticalAlignment = XlVAlign.xlVAlignCenter;
            headerRange.Interior.Color = XlRgbColor.rgbBlue;
            headerRange.Font.Color = XlRgbColor.rgbWhite;
        }
    }

}
