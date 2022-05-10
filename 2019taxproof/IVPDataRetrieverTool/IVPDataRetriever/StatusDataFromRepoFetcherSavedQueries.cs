using Microsoft.Office.Interop.Excel;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml;

namespace IVPDataRetriever
{
    internal class StatusDataFetcherSavedQueries : StatusDataFetcherBase
    {
        private List<SavedQueryStatusData> m_StatusDataList = new List<SavedQueryStatusData>();

        private struct SavedQueryStatusData
        {
            internal string Id { get; set; }
            internal string Name { get; set; }
            internal string SolutionName { get; set; }
        }

        protected override void OnGetStatusDataFromRepo(List<string> solutionFolders)
        {
            foreach (string solutionFolder in solutionFolders)
            {
                string entitiesFolderPath = Path.Combine(solutionFolder, "Entities");
                List<string> savedQuerriesXMLFiles = null;
                try
                {
                    List<string> savedQueriesXMLDirectories = Directory.GetDirectories(entitiesFolderPath, "SavedQueries", SearchOption.AllDirectories).ToList();
                    foreach (string savedQueriesXMLDirectory in savedQueriesXMLDirectories)
                    {
                        savedQuerriesXMLFiles = savedQuerriesXMLFiles == null ? new List<string>(): savedQuerriesXMLFiles;
                        savedQuerriesXMLFiles.AddRange(Directory.GetFiles(savedQueriesXMLDirectory, "*.xml", SearchOption.TopDirectoryOnly).ToList());
                    }
                }
                catch (Exception)
                {
                }

                if (savedQuerriesXMLFiles == null)
                    continue;

                foreach (string savedQueryXMLFile in savedQuerriesXMLFiles)
                {
                    XmlDocument _xmlDoc = new XmlDocument();
                    _xmlDoc.Load(savedQueryXMLFile);
                    XmlElement root = _xmlDoc.DocumentElement;
                    AddStatusDataToList(solutionFolder, root);
                }
            }
        }

        protected override StringBuilder OnGetDataToBeWrittenToCSV()
        {
            StringBuilder _sb = new StringBuilder();
            _sb.AppendLine($"SavedQueryId,SavedQuery Name,SolutionName");
            foreach (var statusData in m_StatusDataList)
            {
                _sb.AppendLine($"{statusData.Id},{statusData.Name},{statusData.SolutionName}");
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
            XmlNodeList savedQueryList = root.SelectNodes("//savedquery");
            foreach (XmlNode savedQuery in savedQueryList)
            {
                SavedQueryStatusData _statusData = new SavedQueryStatusData();
                _statusData.Id = savedQuery.SelectSingleNode("//savedqueryid").InnerText.Replace("{",string.Empty).Replace("}", string.Empty);
                _statusData.Name = savedQuery.SelectSingleNode("//LocalizedNames/LocalizedName").Attributes.GetNamedItem("description").InnerText.Replace(",",";");
                _statusData.SolutionName = Path.GetFileName(solutionFolder);
                m_StatusDataList.Add(_statusData);

            }
        }

        private void WriteDataToExcel(_Worksheet workSheet)
        {
            for (int counter = 0; counter < m_StatusDataList.Count; counter++)
            {
                int columnCounter = 0;
                SavedQueryStatusData data = m_StatusDataList[counter];
                workSheet.Cells[counter + 2, ++columnCounter] = data.Id;
                workSheet.Cells[counter + 2, ++columnCounter] = data.Name;
                workSheet.Cells[counter + 2, ++columnCounter] = data.SolutionName;
            }
        }

        private void WriteHeaderToExcel(_Worksheet workSheet)
        {
            int columnCounter = 0;
            workSheet.Name = "SavedQueries";
            workSheet.Cells[1, ++columnCounter] = "Id";
            workSheet.Cells[1, ++columnCounter] = "Name";
            workSheet.Cells[1, ++columnCounter] = "SolutionName";
            var headerRange = workSheet.Range[workSheet.Cells[1, 1], workSheet.Cells[1, columnCounter]];

            headerRange.Font.Bold = true;
            headerRange.VerticalAlignment = XlVAlign.xlVAlignCenter;
            headerRange.Interior.Color = XlRgbColor.rgbBlue;
            headerRange.Font.Color = XlRgbColor.rgbWhite;
        }
    }

}
