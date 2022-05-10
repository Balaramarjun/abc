using Microsoft.Office.Interop.Excel;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IVPDataRetriever.ConsoleApp
{
    public class Program
    {
        private static string s_ManagedSolutionFolderSuffix = "Managed";

        private static Dictionary<TypeOfData, Func<IStatusDataFetcher>> s_TypeOfDataToObjectCreationFuncMappings = new Dictionary<TypeOfData, Func<IStatusDataFetcher>>()
        {
            {TypeOfData.SdkMessageProcessingSteps ,()=> new StatusDataFetcherSdkMessageProcessingSteps()},
            {TypeOfData.SavedQueries ,()=> new StatusDataFetcherSavedQueries()},
            {TypeOfData.Forms ,()=> new StatusDataFetcherForms()},
            {TypeOfData.DuplicateRules ,()=> new StatusDataFetcherDuplicateRules()},
            {TypeOfData.Plugin ,()=> new StatusDataFetcherPlugins()},
            {TypeOfData.Workflows,()=> new StatusDataFetcherWorkFlows()},
            //{TypeOfData.Entities,()=> new StatusDataFetcherEntities()},
            //{TypeOfData.Fields,()=> new StatusDataFetcherFields()},
            {TypeOfData.Solution,()=> new StatusDataFetcherSolutions() }
        };

        static int Main(string[] args)
        {
            if (args.Length != 2)
            {
                Console.WriteLine("Two arguments are needed: 1-Solutions Directory 2-Output Directory!!!");
                return 1;
            }

            string solutionsFolder = args[0];
            string outputFolder = args[1];
            GeenerateIVPDataFiles(solutionsFolder, outputFolder);
            return 0;
        }

        private static void GeenerateIVPDataFiles(string solutionsFolder, string outputFolder)
        {
            GenerateStatusDataFiles(solutionsFolder, outputFolder, false);
            GenerateStatusDataFiles(solutionsFolder, outputFolder, true);
        }

        private static void GenerateStatusDataFiles(string solutionsFolder, string ivpDataFolderPath, bool forManagedSolutions)
        {
            List<string> _solutionFolders = GetSolutionFolders(solutionsFolder, forManagedSolutions);
            string solutionType = forManagedSolutions ? $"_{s_ManagedSolutionFolderSuffix}" : $"_Un{s_ManagedSolutionFolderSuffix}";

            CSVWriterHelper csvWriter = new CSVWriterHelper();
            string excelWorkBookPath = Path.Combine(ivpDataFolderPath, $"StatusData{solutionType}.xlsx");

            //ExcelWriterHelper excelWriter = new ExcelWriterHelper(excelWorkBookPath);
            //_Workbook excelWorkBook = excelWriter.GetExcelWorkbook();

            foreach (var typeOfDataToObjectCreationFuncMapping in s_TypeOfDataToObjectCreationFuncMappings)
            {
                try
                {
                    IStatusDataFetcher statusDataFromRepoFetcher = typeOfDataToObjectCreationFuncMapping.Value.Invoke();
                    statusDataFromRepoFetcher.GetStatusDataFromRepo(_solutionFolders);

                    string csvFileName = Path.Combine(ivpDataFolderPath, $"{Enum.GetName(typeof(TypeOfData), typeOfDataToObjectCreationFuncMapping.Key)}{solutionType}.csv");
                    csvWriter.WriteDataToCSV(csvFileName, statusDataFromRepoFetcher.GetDataToBeWrittenToCSV());
                }
                catch (Exception ex)
                {

                    throw;
                }
                //statusDataFromRepoFetcher.WriteStatusDataToExcel(excelWorkBook);
            }

            //excelWriter.SaveExcelWorkbook();
        }

        private static List<string> GetSolutionFolders(string solutionsFolder, bool forManagedSolutions)
        {
            if (forManagedSolutions)
                return Directory.GetDirectories(solutionsFolder, $"*{s_ManagedSolutionFolderSuffix}", SearchOption.TopDirectoryOnly).ToList();
            else
                return Directory.GetDirectories(solutionsFolder, "*", SearchOption.TopDirectoryOnly).
                    Except(Directory.GetDirectories(solutionsFolder, $"*{s_ManagedSolutionFolderSuffix}", SearchOption.TopDirectoryOnly)).ToList();
        }
    }
}
