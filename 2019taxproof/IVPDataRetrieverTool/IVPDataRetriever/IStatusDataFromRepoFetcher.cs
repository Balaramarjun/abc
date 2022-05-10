using System.Collections.Generic;
using System.Text;

namespace IVPDataRetriever
{
    public interface IStatusDataFetcher
    {
        void GetStatusDataFromRepo(List<string> solutionFolders);
        StringBuilder GetDataToBeWrittenToCSV();
        void WriteStatusDataToExcel(Microsoft.Office.Interop.Excel._Workbook workbook);
    }

}
