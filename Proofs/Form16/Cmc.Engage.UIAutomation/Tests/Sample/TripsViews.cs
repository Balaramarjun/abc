using Cmc.Engage.UIAutomation.Framework;
using Cmc.Engage.UIAutomation.Framework.CustomAttributes;
using Microsoft.Dynamics365.UIAutomation.Api.UCI;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Cmc.Engage.UIAutomation.Tests.Trip
{
    [TestClass]

    public class TripsViews : TestBase
    {
        [TestMethod]
        [TestCategory("Regression")]
        [ExcelDataSource("Trip", "BPFReiewBeforeApproval", "BPFReiewBeforeApproval")]
        public void ViewFlowUCI(string area, string subArea, string ConnectionLookup,
            string AccountName, string RoleLookup)
        {
            //Login
            SwitchPersona("Advisor");
           // XrmApp.ThinkTime(2000);
             SwitchViewUCI();
            ViewSortGridItemsUCI();
        }
        private void SwitchViewUCI()
        {


            XrmApp.Navigation.OpenApp(UCIAppName.Anthology);
            XrmApp.ThinkTime(10000);

            XrmApp.Navigation.OpenSubArea("Recruitment", "Trips");

            XrmApp.Grid.SwitchView("Trips this month");
            XrmApp.Grid.OpenRecord(0);
        }
        private void ViewSortGridItemsUCI()
        {


            XrmApp.Navigation.OpenApp(UCIAppName.Anthology);
            XrmApp.ThinkTime(5000);

            XrmApp.Navigation.OpenSubArea("Recruitment", "Trips");

            XrmApp.Grid.SwitchView("My Trips");
            var items = XrmApp.Grid.GetGridItems();
            System.Console.WriteLine(items.Count);
            XrmApp.Grid.SortEx("Trip Status");
            // XrmApp.ThinkTime(2000);
            XrmApp.Grid.HighLightRecord(0);
            // XrmApp.N

        }
    }
}






    

