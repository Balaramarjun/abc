using Microsoft.Office.Interop.Excel;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml;


namespace IVPDataRetriever
{
    internal class StatusDataFetcherWorkFlows : StatusDataFetcherBase
    {
        private List<WorkFlowStatusData> m_StatusDataList = new List<WorkFlowStatusData>();

        private struct WorkFlowStatusData
        {
            internal string WorkflowId { get; set; }
            internal string Name { get; set; }
            internal string BaseEntity { get; set; }
            internal string Mode { get; set; }
            internal string StatusCode { get; set; }
            internal string Status { get; set; }
            internal string StateCode { get; set; }
            internal string State { get; set; }
            internal string Category { get; set; }
            internal string SolutionName { get; set; }
            internal string Description { get; set; }
            internal string Type { get; set; }



        }

        private enum WorkflowCategory
        {
            Workflow = 0,
            Dialog = 1,
            BusinessRule = 2,
            Action = 3,
            BusinessProcessFlow = 4,
            Flow = 5
        }

        protected override void OnGetStatusDataFromRepo(List<string> solutionFolders)
        {
            foreach (string solutionFolder in solutionFolders)
            {
                string workflowFolderPath = Path.Combine(solutionFolder, "Workflows");

                List<string> workflowXMLFiles = null;
                List<string> workflowJsonFiles = null;
                try
                {
                    workflowXMLFiles = Directory.GetFiles(workflowFolderPath, "*.xml", SearchOption.TopDirectoryOnly).ToList();
                    workflowJsonFiles = Directory.GetFiles(workflowFolderPath, "*.json", SearchOption.TopDirectoryOnly).ToList();
                }
                catch (Exception ex)
                {
                   
                    
                }

                if (workflowXMLFiles == null || workflowJsonFiles == null)
                    continue;

                foreach (string workflowXMLFile in workflowXMLFiles)
                {
                    XmlDocument _xmlDoc = new XmlDocument();
                    _xmlDoc.Load(workflowXMLFile);
                    XmlElement root = _xmlDoc.DocumentElement;
                    string flowtype = null;
                    if (workflowJsonFiles.Count > 0)
                    {
                        var jsonFilePath = workflowJsonFiles.Where(x => x.Contains(workflowXMLFile.Substring(0, workflowXMLFile.Length - 15))).FirstOrDefault();
                        if (jsonFilePath != null)
                        {
                            flowtype = GetWorkflowType(jsonFilePath, workflowFolderPath);
                        }
                    }

                    WorkFlowStatusData statusData = CreateStatusDataObject(solutionFolder, root, flowtype);
                    m_StatusDataList.Add(statusData);
                }
            }
        }

        protected string GetWorkflowType(string path, string workflowFolderPath)
        {
            string flowtype = null;

            using (StreamReader r = new StreamReader(path))
            {
                string json = r.ReadToEnd();
                JObject rss = JObject.Parse(json);
                string trigger = rss["properties"]["definition"]["triggers"].ToString();
                dynamic array = JsonConvert.DeserializeObject(trigger);

                foreach (var item in array)
                {
                    foreach (var triggerobj in item)
                    {
                        foreach (var type in triggerobj)
                        {
                            if (((Newtonsoft.Json.Linq.JProperty)type).Name ==
                        "type")
                            {
                                flowtype = ((Newtonsoft.Json.Linq.JProperty)type)
                                    .First.ToString();
                            }
                        }
                    }

                }

            }

            return flowtype;
        }

        protected override StringBuilder OnGetDataToBeWrittenToCSV()
        {
            StringBuilder _sb = new StringBuilder();
            _sb.AppendLine($"WorkfowId,Name,Mode,StateCode,State,StatusCode,Status,Category,BaseEntity," +
                           $"SolutionName,Description,Type");
            foreach (var statusData in m_StatusDataList)
            {
                _sb.AppendLine($"{statusData.WorkflowId},{statusData.Name},{statusData.Mode},{statusData.StateCode}, {statusData.State}, {statusData.StatusCode}, {statusData.Status},{statusData.Category},{statusData.BaseEntity},{statusData.SolutionName}" +
                    $",{statusData.Description},{statusData.Type}");
            }
            return _sb;
        }

        protected override void OnWriteStatusDataToExcel(_Worksheet workSheet)
        {
            WriteHeaderToExcel(workSheet);
            WriteDataToExcel(workSheet);
        }


        private WorkFlowStatusData CreateStatusDataObject(string managedSolutionFolder, XmlElement root, string flowtype)
        {
          
            WorkFlowStatusData _statusData = new WorkFlowStatusData();
            _statusData.WorkflowId = root.Attributes.GetNamedItem("WorkflowId").InnerText.Replace("{", string.Empty).Replace("}", string.Empty);
            _statusData.Name = root.Attributes.GetNamedItem("Name").InnerText;
            _statusData.Mode = root.SelectNodes("//Mode").Item(0).InnerText == "0" ? "Background" : "Real-time";
            _statusData.StatusCode = root.SelectNodes("//StatusCode").Item(0).InnerText == "1" ? "Draft" : "Activated";
            _statusData.Status = root.SelectNodes("//StatusCode").Item(0).InnerText;
            _statusData.StateCode = root.SelectNodes("//StateCode").Item(0).InnerText == "0" ? "Draft" : "Activated";
            _statusData.State = root.SelectNodes("//StateCode").Item(0).InnerText;
            int categoryText = Convert.ToInt32(root.SelectNodes("//Category").Item(0).InnerText);
            _statusData.Category = Enum.IsDefined(typeof(WorkflowCategory), categoryText) ? ((WorkflowCategory)categoryText).ToString() : "NotKnown";
            _statusData.BaseEntity = root.SelectNodes("//PrimaryEntity").Item(0).InnerText;
            _statusData.SolutionName = Path.GetFileName(managedSolutionFolder);
            XmlNode nodeToFind = root.SelectSingleNode("//Descriptions");
            if (nodeToFind != null)
            {
              
                _statusData.Description = "\"" + (((root.SelectNodes("//Descriptions/Description").Item(0)).Attributes[1].Value.ToString())) + "\""; 
                if (_statusData.Description == "")
                {
                    _statusData.Description = null;
                }

            }
            else
            {
                _statusData.Description = null;
            }

            _statusData.Type = flowtype;


            return _statusData;
        }

        private void WriteDataToExcel(_Worksheet workSheet)
        {
            for (int counter = 0; counter < m_StatusDataList.Count; counter++)
            {
                int columnCounter = 0;
                WorkFlowStatusData data = m_StatusDataList[counter];

                workSheet.Cells[counter + 2, ++columnCounter] = data.WorkflowId;
                workSheet.Cells[counter + 2, ++columnCounter] = data.Name;
                workSheet.Cells[counter + 2, ++columnCounter] = data.Mode;
                workSheet.Cells[counter + 2, ++columnCounter] = data.StateCode;
                workSheet.Cells[counter + 2, ++columnCounter] = data.State;
                workSheet.Cells[counter + 2, ++columnCounter] = data.StatusCode;
                workSheet.Cells[counter + 2, ++columnCounter] = data.Status;
                workSheet.Cells[counter + 2, ++columnCounter] = data.Category;
                workSheet.Cells[counter + 2, ++columnCounter] = data.BaseEntity;
                workSheet.Cells[counter + 2, ++columnCounter] = data.SolutionName;
                workSheet.Cells[counter + 2, ++columnCounter] = data.Description;

                workSheet.Cells[counter + 2, ++columnCounter] = data.Type;


            }
        }

        private void WriteHeaderToExcel(_Worksheet workSheet)
        {
            int columnCounter = 0;
            workSheet.Name = "Workflows";
            workSheet.Cells[1, ++columnCounter] = "WorkfowId";
            workSheet.Cells[1, ++columnCounter] = "Name";
            workSheet.Cells[1, ++columnCounter] = "Mode";
            workSheet.Cells[1, ++columnCounter] = "StateCode";
            workSheet.Cells[1, ++columnCounter] = "State";
            workSheet.Cells[1, ++columnCounter] = "StatusCode";
            workSheet.Cells[1, ++columnCounter] = "Status";
            workSheet.Cells[1, ++columnCounter] = "Category";
            workSheet.Cells[1, ++columnCounter] = "BaseEntity";
            workSheet.Cells[1, ++columnCounter] = "SolutionName";
            workSheet.Cells[1, ++columnCounter] = "Description";
            workSheet.Cells[1, ++columnCounter] = "Type";

            var headerRange = workSheet.Range[workSheet.Cells[1, 1], workSheet.Cells[1, columnCounter]];

            headerRange.Font.Bold = true;
            headerRange.VerticalAlignment = XlVAlign.xlVAlignCenter;
            headerRange.Interior.Color = XlRgbColor.rgbBlue;
            headerRange.Font.Color = XlRgbColor.rgbWhite;
            workSheet.Columns.ColumnWidth = 100;
            workSheet.Columns.EntireColumn.ColumnWidth = 100;

            workSheet.Activate();
            workSheet.Application.ActiveWindow.SplitRow = 1;
            workSheet.Application.ActiveWindow.FreezePanes = true;

        }
    }

}
