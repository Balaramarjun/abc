using System;
using System.IO;
using System.Text;
using Microsoft.Office.Interop.Excel;

namespace IVPDataRetriever
{
    public enum TypeOfData
    {
        Solution,
        Workflows,
        Plugin,
        SdkMessageProcessingSteps,
        DuplicateRules,
        Forms,
        Entities,
        Fields,
        SavedQueries
    }
    public class CSVWriterHelper
    {
        internal void WriteDataToCSV(string csvFilePath, StringBuilder dataToBeWrittenToCSV)
        {
            File.WriteAllText(csvFilePath, dataToBeWrittenToCSV.ToString());
        }
    }


    public class ExcelWriterHelper
    {
        private readonly string _excelPath;
        private Application excelApplication;
        private _Workbook excelWorkbook;

        internal ExcelWriterHelper(string excelPath)
        {
            _excelPath = excelPath;
        }

        internal _Workbook GetExcelWorkbook()
        {
            excelApplication = new Application();
            excelApplication.DisplayAlerts = false;
            return excelWorkbook = excelApplication.Workbooks.Add();
        }

        internal void SaveExcelWorkbook()
        {
            excelWorkbook.SaveAs(_excelPath);
            excelWorkbook.Close();
            excelApplication.Quit();
        }


    }

}
