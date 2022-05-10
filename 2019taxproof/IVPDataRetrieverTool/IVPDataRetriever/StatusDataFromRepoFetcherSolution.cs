using Microsoft.Office.Interop.Excel;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml;

namespace IVPDataRetriever
{
    internal class StatusDataFetcherSolutions : StatusDataFetcherBase
    {
        private List<SolutionStatusData> m_StatusDataList = new List<SolutionStatusData>();

        private struct SolutionStatusData
        {
            internal string UniqueName { get; set; }
            internal string Version { get; set; }
            internal string Description { get; set; }
            internal string PublisherName { get; set; }
            internal string ManagedStatus { get; set; }
        }
        protected override void OnGetStatusDataFromRepo(List<string> solutionFolders)
        {
            foreach (string solutionFolder in solutionFolders)
            {
                string solutionFolderPath = Path.Combine(solutionFolder, "Other");
                string solutionXMLFile = null;
                try
                {
                    solutionXMLFile = Directory.GetFiles(solutionFolderPath, "Solution.xml", SearchOption.TopDirectoryOnly).ToList().FirstOrDefault();
                }
                catch (Exception)
                {
                }

                if (solutionXMLFile != null)
                {
                    XmlDocument _xmlDoc = new XmlDocument();
                    _xmlDoc.Load(solutionXMLFile);
                    XmlElement root = _xmlDoc.DocumentElement;
                    SolutionStatusData statusData = CreateStatusDataObject(solutionFolder, root);
                    m_StatusDataList.Add(statusData);
                }
            }
        }

        private SolutionStatusData CreateStatusDataObject(string managedSolutionFolder, XmlElement root)
        {
            SolutionStatusData _statusData = new SolutionStatusData();
            _statusData.UniqueName = root.SelectNodes("//SolutionManifest/UniqueName").Item(0).InnerText;
            _statusData.ManagedStatus = root.SelectNodes("//SolutionManifest/Managed").Item(0).InnerText == "0" ? "UnManaged" : "Managed";
            _statusData.Version = root.SelectNodes("//SolutionManifest/Version").Item(0).InnerText;

            XmlNode descriptionsNode = root.SelectNodes("//SolutionManifest/Descriptions").Item(0);
            XmlNode descriptionNode = descriptionsNode.SelectNodes("//Description")?.Item(0);
            _statusData.Description = descriptionNode?.Attributes.GetNamedItem("description").InnerText.Replace(",", ";");

            _statusData.PublisherName = root.SelectNodes("//SolutionManifest/Publisher/UniqueName").Item(0).InnerText;
            return _statusData;
        }

        protected override StringBuilder OnGetDataToBeWrittenToCSV()
        {
            StringBuilder _sb = new StringBuilder();
            _sb.AppendLine($"UniqueName,IsManaged,Version,Description,Publiser Name");
            foreach (var statusData in m_StatusDataList)
            {
                _sb.AppendLine($"{statusData.UniqueName},{statusData.ManagedStatus},{statusData.Version},{statusData.Description},{statusData.PublisherName}");
            }
            return _sb;
        }

        protected override void OnWriteStatusDataToExcel(_Worksheet workSheet)
        {
            WriteHeaderToExcel(workSheet);
            WriteDataToExcel(workSheet);
        }

        private void WriteDataToExcel(_Worksheet workSheet)
        {
            for (int counter = 0; counter < m_StatusDataList.Count; counter++)
            {
                int columnCounter = 0;
                SolutionStatusData data = m_StatusDataList[counter];
                workSheet.Cells[counter + 2, ++columnCounter] = data.UniqueName;
                workSheet.Cells[counter + 2, ++columnCounter] = data.ManagedStatus;
                workSheet.Cells[counter + 2, ++columnCounter] = data.Description;
                workSheet.Cells[counter + 2, ++columnCounter] = data.PublisherName;
            }
        }

        private void WriteHeaderToExcel(_Worksheet workSheet)
        {
            int columnCounter = 0;
            workSheet.Name = "Solution";
            workSheet.Cells[1, ++columnCounter] = "UniqueName";
            workSheet.Cells[1, ++columnCounter] = "IsManaged";
            workSheet.Cells[1, ++columnCounter] = "Description";
            workSheet.Cells[1, ++columnCounter] = "Publiser Name";

            var headerRange = workSheet.Range[workSheet.Cells[1, 1], workSheet.Cells[1, columnCounter]];

            headerRange.Font.Bold = true;
            headerRange.VerticalAlignment = XlVAlign.xlVAlignCenter;
            headerRange.Interior.Color = XlRgbColor.rgbBlue;
            headerRange.Font.Color = XlRgbColor.rgbWhite;
        }
    }

}
