using Cmc.Engage.UIAutomation.Framework;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Cmc.Engage.UIAutomation.Tests
{
    [TestClass]
    public class CreateScoringModel : TestBase
    {
        [TestMethod]
        //  [ExcelDataSource("Personas","Persona")]
        public void CreateScoringFactor_UseExistingView()
        {
            SwitchPersona("Advisor");
            XrmApp.ThinkTime(6000);

            XrmApp.Navigation.OpenSubArea("Process Config", "Scoring Factors");
            XrmApp.CommandBar.ClickCommand("New");

            XrmApp.Entity.SetValue("cmc_scoringfactorname", TestSettings.GetRandomString(5, 10));
            XrmApp.Entity.SetValueWithThinkTime("cmc_points", "98", 2000);
            XrmApp.Entity.SetValueWithThinkTime("cmc_description", "Scoring Factors description", 2000);
            XrmApp.EntityPicker.SetEntity("Contact");

            // Save scoringfactor 
            XrmApp.Entity.Save();
            XrmApp.ThinkTime(2000);
            XrmApp.Dialogs.ConfirmationDialog(true);

            //Navigate to Query Condition tab
            XrmApp.Entity.SelectTab("Query Condition");

            //Prepare Query Using Existing View
            XrmApp.ViewPicker.ClickUseExistingViewButton();
            XrmApp.ViewPicker.SelectExistingView("Active Contacts");
            XrmApp.ViewPicker.ClickUseQueryButton();

            var querytext = XrmApp.Entity.GetValue("cmc_conditionxml");
            Assert.IsTrue(!string.IsNullOrEmpty(querytext));
            
            XrmApp.Entity.Save();
        }
    }
}