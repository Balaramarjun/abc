using Microsoft.Office.Interop.Excel;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml;

namespace IVPDataRetriever
{
    internal class StatusDataFetcherSdkMessageProcessingSteps : StatusDataFetcherBase
    {
        private List<SdkMessageProcessingStepStatusData> m_StatusDataList = new List<SdkMessageProcessingStepStatusData>();

        private struct SdkMessageProcessingStepStatusData
        {
            internal string Id { get; set; }
            internal string Name { get; set; }
            internal string Mode { get; set; }
            internal string ModeCode { get; set; }
            internal string PluginTypeName { get; set; }
            internal string BaseEntity { get; set; }
            internal string SolutionName { get; set; }
        }

        protected override void OnGetStatusDataFromRepo(List<string> solutionFolders)
        {
            foreach (string solutionFolder in solutionFolders)
            {
                string SdkMessageProcessingStepFolderPath = Path.Combine(solutionFolder, "SdkMessageProcessingSteps");

                List<string> _XMLFiles = null;
                try
                {
                    _XMLFiles = Directory.GetFiles(SdkMessageProcessingStepFolderPath, "*.xml", SearchOption.AllDirectories).ToList();
                }
                catch (Exception)
                {
                }

                if (_XMLFiles == null)
                    continue;

                foreach (string SdkMessageProcessingStepXMLFile in _XMLFiles)
                {
                    XmlDocument _xmlDoc = new XmlDocument();
                    _xmlDoc.Load(SdkMessageProcessingStepXMLFile);
                    XmlElement root = _xmlDoc.DocumentElement;
                    AddStatusDataToList(solutionFolder, root);
                }
            }
        }

        protected override StringBuilder OnGetDataToBeWrittenToCSV()
        {
            StringBuilder _sb = new StringBuilder();
            _sb.AppendLine($"SdkMessageProcessingStep Id,Name,Mode,ModeCode,PluginTypeName,BaseEntity,SolutionName");
            foreach (var statusData in m_StatusDataList)
            {
                _sb.AppendLine($"{statusData.Id},{statusData.Name},{statusData.Mode}, {statusData.ModeCode},{statusData.PluginTypeName},{statusData.BaseEntity},{statusData.SolutionName}");
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
            SdkMessageProcessingStepStatusData _statusData = new SdkMessageProcessingStepStatusData();
            _statusData.Id = root.Attributes.GetNamedItem("SdkMessageProcessingStepId")?.InnerText.Replace("{",string.Empty).Replace("}", string.Empty);
            _statusData.Name = root.Attributes.GetNamedItem("Name")?.InnerText;
            _statusData.Mode = root.SelectSingleNode("//Mode")?.InnerText=="0"? "Asynchronous" : "Synchronous";
            _statusData.ModeCode = root.SelectSingleNode("//Mode")?.InnerText;
            _statusData.PluginTypeName = root.SelectSingleNode("//PluginTypeName")?.InnerText.Replace(',',';');
            _statusData.BaseEntity = root.SelectSingleNode("//PrimaryEntity")?.InnerText;
            _statusData.SolutionName = Path.GetFileName(solutionFolder);
            m_StatusDataList.Add(_statusData);

        }

        private void WriteDataToExcel(_Worksheet workSheet)
        {
            for (int counter = 0; counter < m_StatusDataList.Count; counter++)
            {
                int columnCounter = 0;
                SdkMessageProcessingStepStatusData data = m_StatusDataList[counter];
                workSheet.Cells[counter + 2, ++columnCounter] = data.Id;
                workSheet.Cells[counter + 2, ++columnCounter] = data.Name;
                workSheet.Cells[counter + 2, ++columnCounter] = data.Mode;
                workSheet.Cells[counter + 2, ++columnCounter] = data.ModeCode;
                workSheet.Cells[counter + 2, ++columnCounter] = data.PluginTypeName;
                workSheet.Cells[counter + 2, ++columnCounter] = data.BaseEntity;
                workSheet.Cells[counter + 2, ++columnCounter] = data.SolutionName;
            }
        }

        private void WriteHeaderToExcel(_Worksheet workSheet)
        {
            int columnCounter = 0;
            workSheet.Name = "SdkMessageProcessingSteps";
            workSheet.Cells[1, ++columnCounter] = "SdkMessageProcessingStep Id";
            workSheet.Cells[1, ++columnCounter] = "Name";
            workSheet.Cells[1, ++columnCounter] = "Mode";
            workSheet.Cells[1, ++columnCounter] = "ModeCode";
            workSheet.Cells[1, ++columnCounter] = "PluginTypeName";
            workSheet.Cells[1, ++columnCounter] = "Base Entity";
            workSheet.Cells[1, ++columnCounter] = "SolutionName";
            var headerRange = workSheet.Range[workSheet.Cells[1, 1], workSheet.Cells[1, columnCounter]];

            headerRange.Font.Bold = true;
            headerRange.VerticalAlignment = XlVAlign.xlVAlignCenter;
            headerRange.Interior.Color = XlRgbColor.rgbBlue;
            headerRange.Font.Color = XlRgbColor.rgbWhite;
        }
    }

}
