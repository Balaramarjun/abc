using Microsoft.Office.Interop.Excel;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml;

namespace IVPDataRetriever
{
    internal class StatusDataFetcherPlugins : StatusDataFetcherBase
    {
        private List<PluginStatusData> m_StatusDataList = new List<PluginStatusData>();

        private struct PluginStatusData
        {
            internal string PluginTypeId { get; set; }
            internal string Name { get; set; }
            internal string PluginAssemblyName { get; set; }
            internal string SolutionName { get; set; }
        }

        protected override void OnGetStatusDataFromRepo(List<string> solutionFolders)
        {
            foreach (string solutionFolder in solutionFolders)
            {
                string pluginFolderPath = Path.Combine(solutionFolder, "PluginAssemblies");

                List<string> pluginXMLFiles = null;
                try
                {
                    pluginXMLFiles = Directory.GetFiles(pluginFolderPath, "*.xml", SearchOption.AllDirectories).ToList();
                }
                catch (Exception)
                {
                }

                if (pluginXMLFiles == null)
                    continue;

                foreach (string pluginXMLFile in pluginXMLFiles)
                {
                    XmlDocument _xmlDoc = new XmlDocument();
                    _xmlDoc.Load(pluginXMLFile);
                    XmlElement root = _xmlDoc.DocumentElement;
                    AddStatusDataToList(solutionFolder, root);
                }
            }
        }

        protected override StringBuilder OnGetDataToBeWrittenToCSV()
        {
            StringBuilder _sb = new StringBuilder();
            _sb.AppendLine($"PluginTypeId,Plugin Name,PluginAssemblyName,SolutionName");
            foreach (var statusData in m_StatusDataList)
            {
                _sb.AppendLine($"{statusData.PluginTypeId},{statusData.Name},{statusData.PluginAssemblyName},{statusData.SolutionName}");
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
            XmlNodeList pluginTypes = root.SelectNodes("//PluginTypes/PluginType");
            foreach (XmlNode pluginType in pluginTypes)
            {
                PluginStatusData _statusData = new PluginStatusData();
                _statusData.PluginTypeId = pluginType.Attributes.GetNamedItem("PluginTypeId")?.InnerText;
                _statusData.Name = pluginType.Attributes.GetNamedItem("Name")?.InnerText;
                _statusData.PluginAssemblyName = pluginType.Attributes.GetNamedItem("AssemblyQualifiedName")?.InnerText.Split(',').FirstOrDefault();
                _statusData.SolutionName = Path.GetFileName(solutionFolder);
                m_StatusDataList.Add(_statusData);
            }
        }

        private void WriteDataToExcel(_Worksheet workSheet)
        {
            for (int counter = 0; counter < m_StatusDataList.Count; counter++)
            {
                int columnCounter = 0;
                PluginStatusData data = m_StatusDataList[counter];
                workSheet.Cells[counter + 2, ++columnCounter] = data.PluginTypeId;
                workSheet.Cells[counter + 2, ++columnCounter] = data.Name;
                workSheet.Cells[counter + 2, ++columnCounter] = data.PluginAssemblyName;
                workSheet.Cells[counter + 2, ++columnCounter] = data.SolutionName;
            }
        }

        private void WriteHeaderToExcel(_Worksheet workSheet)
        {
            int columnCounter = 0;
            workSheet.Name = "Plugins";
            workSheet.Cells[1, ++columnCounter] = "PluginTypeId";
            workSheet.Cells[1, ++columnCounter] = "Plugin Name";
            workSheet.Cells[1, ++columnCounter] = "PluginAssemblyName";
            workSheet.Cells[1, ++columnCounter] = "SolutionName";
            var headerRange = workSheet.Range[workSheet.Cells[1, 1], workSheet.Cells[1, columnCounter]];

            headerRange.Font.Bold = true;
            headerRange.VerticalAlignment = XlVAlign.xlVAlignCenter;
            headerRange.Interior.Color = XlRgbColor.rgbBlue;
            headerRange.Font.Color = XlRgbColor.rgbWhite;
        }
    }

}
