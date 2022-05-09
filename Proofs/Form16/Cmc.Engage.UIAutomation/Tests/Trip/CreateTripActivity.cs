using Cmc.Engage.UIAutomation.Framework;
using Cmc.Engage.UIAutomation.Framework.CustomAttributes;
using Microsoft.Dynamics365.UIAutomation.Api.UCI;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Cmc.Engage.UIAutomation.Tests.Trip

{
    [TestClass]
    public class CreateTripActivity : TestBase
    {
        public TestContext TestContext { get; set; }

        [TestMethod]
        [TestCategory("Regression")]
        [ExcelDataSource("Trip", "CreateTripActivity", "CreateTripActivity")]
        public void TestCreateTripActivity(string area,
            string subArea,
            string tab,
            string subTab,
            string lookupName,
            string subject,
            string optionSetValue, string tripname, string DialogButton
        )
        {
            SwitchPersona("Advisor");
            //switch to Active trips list
            XrmApp.Navigation.OpenSubArea(area, subArea);
            XrmApp.ThinkTime(2000);
            
            //Search Trip 
            XrmApp.Grid.Search(tripname);
            XrmApp.ThinkTime(1000);
            XrmApp.Grid.OpenRecord(0);
            XrmApp.ThinkTime(1000);

            //Navigate to Trip activity tab
            XrmApp.Entity.SelectTab(tab, subTab);
            XrmApp.ThinkTime(1000);

            //Create New Trip Activity
            XrmApp.CommandBar.ClickCommand("New Trip Activity");
            XrmApp.ThinkTime(1000);

            // Create a new Lookup & select value in lookup field

            XrmApp.Entity.SelectLookup(new LookupItem {Name = lookupName});
            XrmApp.ThinkTime(1000);
            XrmApp.Lookup.New();
           // XrmApp.Entity.SetValue(new LookupItem { Name = lookupName, Value = subject });
            XrmApp.ThinkTime(2000);
            XrmApp.QuickCreate.SetValue("subject", subject);
            XrmApp.QuickCreate.Save();

            //Select an option from the Dropdown
            XrmApp.Entity.SetValue(new OptionSet {Name = "cmc_purpose", Value = optionSetValue});
            XrmApp.ThinkTime(500);
            XrmApp.Entity.Save();
            XrmApp.ThinkTime(1000);


            XrmApp.Dialogs.DialogOK(DialogButton);
        }
    }
}