using Microsoft.Office.Interop.Excel;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml;

namespace IVPDataRetriever
{
    internal class StatusDataFetcherEntities : StatusDataFetcherBase
    {
        private List<EntityStatusData> m_StatusDataList = new List<EntityStatusData>();

        private struct EntityStatusData
        {
            internal string EntityLogicalName { get; set; }
            internal string EntityDisplayName { get; set; }
            internal string EntitySetName { get; set; }
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
                    EntityStatusData statusData = CreateStatusDataObject(solutionFolder, root);
                    m_StatusDataList.Add(statusData);
                }
            }
        }

        protected override StringBuilder OnGetDataToBeWrittenToCSV()
        {
            StringBuilder _sb = new StringBuilder();
            _sb.AppendLine($"EntityLogicalName,EntityDisplayName,EntitySetName,SolutionName");
            foreach (var statusData in m_StatusDataList)
            {
                _sb.AppendLine($"{statusData.EntityLogicalName},{statusData.EntityDisplayName},{statusData.EntitySetName},{statusData.SolutionName}");
            }
            return _sb;
        }

        protected override void OnWriteStatusDataToExcel(_Worksheet workSheet)
        {           
            WriteHeaderToExcel(workSheet);
            WriteDataToExcel(workSheet);
        }

        private EntityStatusData CreateStatusDataObject(string solutionFolder, XmlElement root)
        {
            EntityStatusData _statusData = new EntityStatusData();
            XmlNode entityNode = root.SelectNodes("//EntityInfo/entity").Item(0);
            _statusData.EntityLogicalName = entityNode?.Attributes.GetNamedItem("Name")?.InnerText;
            _statusData.EntityDisplayName = root?.SelectNodes("//Name").Item(0)?.Attributes.GetNamedItem("LocalizedName")?.InnerText;
            _statusData.EntitySetName = entityNode?.SelectNodes("//EntitySetName")?.Item(0)?.InnerText;
            _statusData.SolutionName = Path.GetFileName(solutionFolder);
            return _statusData;
        }

        private void WriteDataToExcel(_Worksheet workSheet)
        {
            for (int counter = 0; counter < m_StatusDataList.Count; counter++)
            {
                int columnCounter = 0;
                EntityStatusData data = m_StatusDataList[counter];
                workSheet.Cells[counter + 2, ++columnCounter] = data.EntityLogicalName;
                workSheet.Cells[counter + 2, ++columnCounter] = data.EntityDisplayName;
                workSheet.Cells[counter + 2, ++columnCounter] = data.EntitySetName;
                workSheet.Cells[counter + 2, ++columnCounter] = data.SolutionName;
            }
        }

        private void WriteHeaderToExcel(_Worksheet workSheet)
        {
            int columnCounter = 0;
            workSheet.Name = "Entities";
            workSheet.Cells[1, ++columnCounter] = "EntityLogicalName";
            workSheet.Cells[1, ++columnCounter] = "EntityDisplayName";
            workSheet.Cells[1, ++columnCounter] = "EntitySetName";
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
