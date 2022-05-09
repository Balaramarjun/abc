using System.Collections.Concurrent;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading;
using Cmc.Engage.UIAutomation.Framework.Dto;
using ExcelDataReader;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Cmc.Engage.UIAutomation.Framework.TestData
{
    public static class TestDataManager
    {
        private static readonly ReaderWriterLockSlim DataCacheLock = new ReaderWriterLockSlim();
        private static readonly IDictionary<string, IList<TestDataDto>> MapofExcelSheetToData = new ConcurrentDictionary<string, IList<TestDataDto>>();

        private static string GetKey(string excelName, string sheetName)
        {
            return $"{excelName}={sheetName}";
        }

        public static IList<TestDataDto> GetExcelSheetData(string excelName, string sheetName, string keyName = "TestName")
        {
            if (!MapofExcelSheetToData.ContainsKey(GetKey(excelName, sheetName))) FetchSheetData(excelName, sheetName, keyName);

            return ReadSheetData(excelName, sheetName);
        }

        public static IList<dynamic> GetTestCaseData(string excelName, string sheetName, string testName)
        {
            var mapOfTestToRowData = ReadSheetData(excelName, sheetName);
            dynamic rowObject = mapOfTestToRowData.Where(x => x.TestName.Equals(testName));
            return rowObject;
        }

        private static IList<TestDataDto> ReadSheetData(string excelName, string sheetName)
        {
            DataCacheLock.EnterReadLock();
            try
            {
                return MapofExcelSheetToData[GetKey(excelName, sheetName)];
            }
            finally
            {
                DataCacheLock.ExitReadLock();
            }
        }

        private static void FetchSheetData(string excelName, string sheetName, string keyName)
        {
            DataCacheLock.EnterWriteLock();
            try
            {
                if (MapofExcelSheetToData.ContainsKey(GetKey(excelName, sheetName)))
                    return;

                var filePath = Path.Combine(Directory.GetCurrentDirectory(), "TestData", excelName + ".xlsx");

                using (var stream = File.Open(filePath, FileMode.Open, FileAccess.Read))
                {
                    using (var reader = ExcelReaderFactory.CreateReader(stream))
                    {
                        var dataSet = reader.AsDataSet(new ExcelDataSetConfiguration
                        {
                            ConfigureDataTable = tableReader => new ExcelDataTableConfiguration
                            {
                                UseHeaderRow = true
                            }
                        });
                        var excelJson = JsonConvert.SerializeObject(dataSet);

                        var excelJObject = JsonConvert.DeserializeObject<JObject>(excelJson);

                        foreach (var property in excelJObject.Properties())
                        {
                            var sheetRowData = property.Value as JArray;
                            var testDataDtos = new List<TestDataDto>();
                            if (sheetRowData != null)
                                foreach (var rowData in sheetRowData)
                                    if (rowData is JObject rowJObject)
                                        testDataDtos.Add(new TestDataDto
                                        {
                                            TestName = rowData[keyName].ToString(),
                                            RowData = rowJObject
                                        });

                            MapofExcelSheetToData[GetKey(excelName, property.Name)] = testDataDtos;
                        }
                    }
                }
            }
            finally
            {
                DataCacheLock.ExitWriteLock();
            }
        }
    }
}