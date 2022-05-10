using Microsoft.Office.Interop.Excel;
using System.Collections.Generic;
using System.Text;

namespace IVPDataRetriever
{
    internal class StatusDataFetcherBase : IStatusDataFetcher
    {
        void IStatusDataFetcher.GetStatusDataFromRepo(List<string> solutionFolders)
        {
            OnGetStatusDataFromRepo(solutionFolders);
        }

        protected virtual void OnGetStatusDataFromRepo(List<string> solutionFolders)
        {
            return;
        }

        StringBuilder IStatusDataFetcher.GetDataToBeWrittenToCSV()
        {
            return OnGetDataToBeWrittenToCSV();
        }

        protected virtual StringBuilder OnGetDataToBeWrittenToCSV()
        {
            return null;
        }

        void IStatusDataFetcher.WriteStatusDataToExcel(_Workbook workbook)
        {
            _Worksheet workSheet = (_Worksheet)workbook.Sheets.Add();
            OnWriteStatusDataToExcel(workSheet);
        }

        protected virtual void OnWriteStatusDataToExcel(_Worksheet workbook)
        {
            return;
        }
    }

}
