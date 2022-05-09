using Cmc.Engage.UIAutomation.Framework;
using Cmc.Engage.UIAutomation.Framework.ApiExtensions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Cmc.Engage.UIAutomation.Tests
{
    [TestClass]
    public class CreateScoringModelscoringFactor : TestBase
    {
        [TestMethod]
        //  [ExcelDataSource("Personas","Persona")]
        public void CreateScoringFactor_CreateEditQuery()
        {
            SwitchPersona("Advisor");

            XrmApp.ThinkTime(6000);
            XrmApp.Navigation.OpenSubArea("Process Config", "Scoring Factors");
            XrmApp.CommandBar.ClickCommand("New");

            //Set Fields
            XrmApp.Entity.SetValue("cmc_scoringfactorname", TestSettings.GetRandomString(5, 10));
            XrmApp.Entity.SetValueWithThinkTime("cmc_points", "98",2000);
            XrmApp.Entity.SetValueWithThinkTime("cmc_description", "Scoring Factors description", 2000);
            XrmApp.EntityPicker.SetEntity("Contact");

            // Save scoringfactor 
            XrmApp.Entity.Save();
            XrmApp.ThinkTime(2000);
            XrmApp.Dialogs.ConfirmationDialog(true);

            //Navigate to Query Condition tab
            XrmApp.Entity.SelectTab("Query Condition");
            XrmApp.ViewPicker.ClickEditQuery();

            //Click on save button in the Advanced Find Dialog
            XrmApp.AdvancedFind.Save();
            XrmApp.ThinkTime(2000);
            XrmApp.AdvancedFind.Close();

            // And switch back to the original window handle.
            XrmApp.SwitchToMainWindow();
            XrmApp.Entity.Save();

            var querytext = XrmApp.Entity.GetValue("cmc_conditionxml");
            Assert.IsTrue(!string.IsNullOrEmpty(querytext));
        }
    }
}