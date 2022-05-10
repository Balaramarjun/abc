using Microsoft.Office.Interop.Excel;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml;

namespace IVPDataRetriever
{
    internal class StatusDataFetcherFields : StatusDataFetcherBase
    {
        private List<FieldStatusData> m_StatusDataList = new List<FieldStatusData>();

        private struct FieldStatusData
        {
            internal string LogicalName { get; set; }
            internal string DisplayName { get; set; }
            internal string Type { get; set; }
            internal string RequiredLevel { get; set; }
            internal string EntityName { get; set; }
            internal string SolutionName { get; set; }
        }

        protected override void OnGetStatusDataFromRepo(List<string> solutionFolders)
        {
            foreach (string solutionFolder in solutionFolders)
            {
                string entitiesFolderPath = Path.Combine(solutionFolder, "Entities");

                List<string> entityXMLFiles = null;
                try
                {
                    entityXMLFiles = Directory.GetFiles(entitiesFolderPath, "Entity.xml", SearchOption.AllDirectories).ToList();
                }
                catch (Exception)
                {
                }

                if (entityXMLFiles == null)
                    continue;

                foreach (string entityXMLFile in entityXMLFiles)
                {
                    XmlDocument _xmlDoc = new XmlDocument();
                    _xmlDoc.Load(entityXMLFile);
                    XmlElement root = _xmlDoc.DocumentElement;
                    List<FieldStatusData> statusDataList = CreateStatusDataObject(solutionFolder, root);
                    m_StatusDataList.AddRange(statusDataList);
                }
            }
        }

        protected override StringBuilder OnGetDataToBeWrittenToCSV()
        {
            StringBuilder _sb = new StringBuilder();
            _sb.AppendLine($"AttributeLogicalName,AttributeDisplayName,AttributeType,RequireLevel,EntityName,SolutionName");
            foreach (var statusData in m_StatusDataList)
            {
                _sb.AppendLine($"{statusData.LogicalName},{statusData.DisplayName},{statusData.Type},{statusData.RequiredLevel},{statusData.EntityName},{statusData.SolutionName}");
            }
            return _sb;
        }

        protected override void OnWriteStatusDataToExcel(_Worksheet workSheet)
        {
            WriteHeaderToExcel(workSheet);
            WriteDataToExcel(workSheet);
        }

        private List<FieldStatusData> CreateStatusDataObject(string solutionFolder, XmlElement root)
        {
            List<FieldStatusData> _statusDataList = new List<FieldStatusData>();
            XmlNode entityNode = root.SelectNodes("//EntityInfo/entity").Item(0);
            XmlNodeList attributeNodeList = entityNode?.SelectNodes("//attributes/attribute");

            if (attributeNodeList != null)
                foreach (XmlNode atributeNode in attributeNodeList)
                {
                    FieldStatusData _statusData = new FieldStatusData();
                    _statusData.EntityName = entityNode?.Attributes.GetNamedItem("Name")?.InnerText;

                    _statusData.LogicalName = atributeNode.SelectNodes(".//LogicalName")?.Item(0)?.InnerText;
                    _statusData.DisplayName = atributeNode.SelectNodes(".//displaynames")?.Item(0)?.SelectSingleNode("displayname")?.Attributes.GetNamedItem("description")?.InnerText;
                    _statusData.Type = atributeNode.SelectNodes(".//Type")?.Item(0)?.InnerText;
                    _statusData.RequiredLevel = atributeNode.SelectNodes(".//RequiredLevel")?.Item(0)?.InnerText;
                    _statusData.SolutionName = Path.GetFileName(solutionFolder);
                    _statusDataList.Add(_statusData);
                }
            return _statusDataList;
        }

        private void WriteDataToExcel(_Worksheet workSheet)
        {
            for (int counter = 0; counter < m_StatusDataList.Count; counter++)
            {
                int columnCounter = 0;
                FieldStatusData data = m_StatusDataList[counter];
                workSheet.Cells[counter + 2, ++columnCounter] = data.LogicalName;
                workSheet.Cells[counter + 2, ++columnCounter] = data.DisplayName;
                workSheet.Cells[counter + 2, ++columnCounter] = data.Type;
                workSheet.Cells[counter + 2, ++columnCounter] = data.RequiredLevel;
                workSheet.Cells[counter + 2, ++columnCounter] = data.EntityName;
                workSheet.Cells[counter + 2, ++columnCounter] = data.SolutionName;
            }
        }

        private void WriteHeaderToExcel(_Worksheet workSheet)
        {
            int columnCounter = 0;
            workSheet.Name = "Fields";
            workSheet.Cells[1, ++columnCounter] = "AttributeLogicalName";
            workSheet.Cells[1, ++columnCounter] = "EntityDisplayName";
            workSheet.Cells[1, ++columnCounter] = "AttributeType";
            workSheet.Cells[1, ++columnCounter] = "RequireLevel";
            workSheet.Cells[1, ++columnCounter] = "EntityName";
            workSheet.Cells[1, ++columnCounter] = "SolutionName";
            var headerRange = workSheet.Range[workSheet.Cells[1, 1], workSheet.Cells[1, columnCounter]];

            headerRange.Font.Bold = true;
            headerRange.VerticalAlignment = XlVAlign.xlVAlignCenter;
            headerRange.Interior.Color = XlRgbColor.rgbBlue;
            headerRange.Font.Color = XlRgbColor.rgbWhite;

            workSheet.Activate();
            workSheet.Application.ActiveWindow.SplitRow = 1;
            workSheet.Application.ActiveWindow.FreezePanes = true;
        }
    }

}
