using Cmc.Engage.UIAutomation.Framework;
using Cmc.Engage.UIAutomation.Framework.CustomAttributes;
using Microsoft.Dynamics365.UIAutomation.Api.UCI;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Cmc.Engage.UIAutomation.Tests.Trip
{
    [TestClass]
    public class DUpdateTripActivity : TestBase
    {
        [TestMethod]
        [TestCategory("Regression")]
        [ExcelDataSource("Trip", "UpdateTripActivity", "UpdateTripActivity")]
        public void UpdateTripActivity(string area,
            string subArea,
            string tab,
            string subTab,
            string subGridName,
            string subGridButtonName,
            string subGridOption,
            string lookupDialogName,
            string lookupDialogValue,
            string tab2,
            string subTab2,
            string transportValue,
            string tabName3,
            string subTabName3,
            string comment, string tripname
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
            XrmApp.Entity.SelectTab("Trip Activities");
            XrmApp.Grid.OpenRecord(0);
            XrmApp.ThinkTime(2000);
            //Navigate to Staff & Volunteers
            XrmApp.Entity.SelectTab(tab, subTab);
            XrmApp.ThinkTime(1000);
            //Select an option from the SubGrid
            XrmApp.CommandBar.ClickCommandOnSubGrid(subGridName, subGridButtonName);
            XrmApp.ThinkTime(1000);
            XrmApp.CommandBar.ClickSubGridOptions(subGridButtonName, subGridOption);
            XrmApp.ThinkTime(1000);

            //Search in the Lookup Field for exisitng user 
            XrmApp.Entity.SetLookupDialogEx(new LookupItem {Name = lookupDialogName, Value = lookupDialogValue});
            XrmApp.ThinkTime(3000);
            XrmApp.Entity.LookupDialogAction(true);

            XrmApp.ThinkTime(1000);
            XrmApp.Entity.SelectTab(tab2, subTab2);
            XrmApp.Entity.SetValue("cmc_estdtransportation", transportValue);
            XrmApp.Entity.Save();

            XrmApp.Entity.SelectTab(tabName3, subTabName3);
            XrmApp.ThinkTime(1000);
            XrmApp.Entity.SetValue("cmc_ratingcomments", comment);
            XrmApp.Entity.Save();
        }
    }
}