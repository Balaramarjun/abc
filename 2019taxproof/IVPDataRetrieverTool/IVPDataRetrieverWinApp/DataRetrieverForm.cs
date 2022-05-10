using Microsoft.Office.Interop.Excel;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace IVPDataRetriever.WinApp
{
    public partial class DataRetrieverForm : Form
    {
        string s_ManagedSolutionFolderSuffix = "Managed";

        Dictionary<TypeOfData, Func<IStatusDataFetcher>> s_TypeOfDataToObjectCreationFuncMappings = new Dictionary<TypeOfData, Func<IStatusDataFetcher>>()
        {
            {TypeOfData.SdkMessageProcessingSteps ,()=> new StatusDataFetcherSdkMessageProcessingSteps()},
            {TypeOfData.SavedQueries ,()=> new StatusDataFetcherSavedQueries()},
            {TypeOfData.Forms ,()=> new StatusDataFetcherForms()},
            {TypeOfData.DuplicateRules ,()=> new StatusDataFetcherDuplicateRules()},
            {TypeOfData.Plugin ,()=> new StatusDataFetcherPlugins()},
            {TypeOfData.Workflows,()=> new StatusDataFetcherWorkFlows()},
            {TypeOfData.Entities,()=> new StatusDataFetcherEntities()},
            {TypeOfData.Fields,()=> new StatusDataFetcherFields()},
            {TypeOfData.Solution,()=> new StatusDataFetcherSolutions() }
        };

        public DataRetrieverForm()
        {
            InitializeComponent();
        }

        private void BtnGenerateFile_Click(object sender, EventArgs e)
        {
            try
            {
                btnGenerateFile.Enabled = false;
                string tempFolderPath = GetTempDirectory();

                if (!chkboxOnlyManagedSolutions.Checked)
                {
                    GenerateStatusDataFiles(tempFolderPath, false);
                }
                GenerateStatusDataFiles(tempFolderPath, true);

                ClearControls();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void ClearControls()
        {
            txtRepositoryPath.Text = string.Empty;
            btnGenerateFile.Enabled = true;
            chkboxGenerateExcel.Checked = false;
            chkboxOnlyManagedSolutions.Checked = false;
        }

        private void BtnOpenFD_Click(object sender, EventArgs e)
        {
            using (var folderBrowserDialog = new FolderBrowserDialog())
            {
                DialogResult result = folderBrowserDialog.ShowDialog();
                if (result == DialogResult.OK && !string.IsNullOrWhiteSpace(folderBrowserDialog.SelectedPath))
                {
                    txtRepositoryPath.Text = folderBrowserDialog.SelectedPath;
                }
            }
        }

        private string GetTempDirectory()
        {
            string tempFolderPath = Path.Combine(Path.GetTempPath(), "StatusData_" + DateTime.Now.ToString("dd_MM_yy_hh_mm"));

            if (Directory.Exists(tempFolderPath))
                Directory.Delete(tempFolderPath,true);
            Directory.CreateDirectory(tempFolderPath);
            return tempFolderPath;
        }

        private void GenerateStatusDataFiles(string tempFolderPath, bool forManagedSolutions)
        {
            List<string> _solutionFolders = GetSolutionFolders(forManagedSolutions);
            string solutionType = forManagedSolutions ? $"_{s_ManagedSolutionFolderSuffix}" : $"_Un{s_ManagedSolutionFolderSuffix}";

            CSVWriterHelper csvWriter = new CSVWriterHelper();
            string excelWorkBookPath = Path.Combine(tempFolderPath, $"StatusData{solutionType}.xlsx");

            ExcelWriterHelper excelWriter = null;
            _Workbook excelWorkBook = null;

            if (chkboxGenerateExcel.Checked == true)
            {
                excelWriter = new ExcelWriterHelper(excelWorkBookPath);
                excelWorkBook = excelWriter.GetExcelWorkbook();
            }

            foreach (var typeOfDataToObjectCreationFuncMapping in s_TypeOfDataToObjectCreationFuncMappings)
            {
                IStatusDataFetcher statusDataFromRepoFetcher = typeOfDataToObjectCreationFuncMapping.Value.Invoke();
                statusDataFromRepoFetcher.GetStatusDataFromRepo(_solutionFolders);

                string csvFileName = Path.Combine(tempFolderPath, $"{Enum.GetName(typeof(TypeOfData), typeOfDataToObjectCreationFuncMapping.Key)}{solutionType}.csv");
                csvWriter.WriteDataToCSV(csvFileName, statusDataFromRepoFetcher.GetDataToBeWrittenToCSV());

                if (excelWorkBook != null)
                    statusDataFromRepoFetcher.WriteStatusDataToExcel(excelWorkBook);
            }

            excelWriter?.SaveExcelWorkbook();
        }

        private List<string> GetSolutionFolders(bool forManagedSolutions)
        {
            string repositoryPath = txtRepositoryPath.Text;
            if (forManagedSolutions)
                return Directory.GetDirectories(repositoryPath, $"*{s_ManagedSolutionFolderSuffix}", SearchOption.TopDirectoryOnly).ToList();
            else
                return Directory.GetDirectories(repositoryPath, "*", SearchOption.TopDirectoryOnly).
                    Except(Directory.GetDirectories(repositoryPath, $"*{s_ManagedSolutionFolderSuffix}", SearchOption.TopDirectoryOnly)).ToList();
        }

    }
}
