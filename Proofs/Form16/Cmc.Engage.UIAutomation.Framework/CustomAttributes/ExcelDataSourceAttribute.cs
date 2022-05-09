using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Reflection;
using Cmc.Engage.UIAutomation.Framework.Dto;
using Cmc.Engage.UIAutomation.Framework.TestData;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json.Linq;

namespace Cmc.Engage.UIAutomation.Framework.CustomAttributes
{
    [AttributeUsage(AttributeTargets.Method, AllowMultiple = true)]
    public class ExcelDataSourceAttribute : Attribute, ITestDataSource
    {
        public ExcelDataSourceAttribute(string excelFileName, string sheetName) : this(excelFileName, sheetName, "")
        {
        }

        public ExcelDataSourceAttribute(string excelFileName, string sheetName, string testName)
        {
            ExcelFileName = excelFileName;
            SheetName = sheetName;
            TestName = testName;
        }

        private string ExcelFileName { get; }
        private string SheetName { get; }
        private string TestName { get; }

        public IEnumerable<object[]> GetData(MethodInfo methodInfo)
        {
            var testDataDtos = TestDataManager.GetExcelSheetData(ExcelFileName, SheetName);
            foreach (var testDataDto in testDataDtos)
                if (IsTestCaseMarkedForExecution(testDataDto))
                {
                    var rowDataTestName = testDataDto.TestName;
                    if (string.IsNullOrEmpty(TestName)
                        || !string.IsNullOrEmpty(TestName) && rowDataTestName != null && rowDataTestName.Equals(TestName))
                        yield return PrepareRowData(testDataDto.RowData, methodInfo);
                }
        }

        public string GetDisplayName(MethodInfo methodInfo, object[] data)
        {
            if (data.Length > 0) return $"{ExcelFileName}-{SheetName} {methodInfo.Name} - {data[0]}";

            return methodInfo.Name;
        }

        private object[] PrepareRowData(JObject rowData, MethodInfo methodInfo)
        {
            var parameters = methodInfo.GetParameters();
            IList<object> paramData = new List<object>();

            //Supported data types 
            foreach (var parameterInfo in parameters)
            {
                var paramName = parameterInfo.Name;
                var paramType = parameterInfo.ParameterType;
                var property = rowData.Properties().FirstOrDefault(x => x.Name.ToLower().Replace(" ", "").Equals(paramName.ToLower()));
                switch (paramType.Name)
                {
                    case nameof(Int32):
                    {
                        int.TryParse(property?.Value.ToString(), out var data);
                        paramData.Add(data);
                    }
                        break;
                    case nameof(String):
                    {
                        paramData.Add(property?.Value?.ToString());
                    }
                        break;
                    case nameof(DateTime):
                    {
                        DateTime.TryParseExact(property?.Value?.ToString(), "dd-MM-yyyy hh:mm:ss", null, DateTimeStyles.None, out var dateTime);
                        paramData.Add(dateTime);
                    }
                        break;
                }
            }

            return paramData.ToArray();
        }

        private bool IsTestCaseMarkedForExecution(TestDataDto testDataDto)
        {
            dynamic rowData = testDataDto.RowData;
            var execute = rowData?.Execute?.ToString();
            if (execute != null && execute.Equals("No")) return false;

            return true;
        }
    }
}