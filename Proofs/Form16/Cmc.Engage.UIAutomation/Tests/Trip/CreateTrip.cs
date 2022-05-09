using System;
using Cmc.Engage.UIAutomation.Framework;
using Cmc.Engage.UIAutomation.Framework.CustomAttributes;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Cmc.Engage.UIAutomation.Tests.Trip
{
    [TestClass]
    public class CreateTrip : TestBase
    {
        [TestMethod]
        [TestCategory("Regression")]
        [TestCategory("Trip")]
        [ExcelDataSource("Trip", "CreateTrip", "CreateTrip")]
        public void TestCreateTrip(string area,
            string subArea,
            string tripName,
            string startDate,
            string endDate, string DialogButton
        )
        {
            SwitchPersona("Advisor");
            XrmApp.ThinkTime(2000);

            XrmApp.Navigation.OpenSubArea(area, subArea);
            XrmApp.CommandBar.ClickCommand("New");

            //Enter all the required details 
            XrmApp.Entity.SetValueWithThinkTime("tripname", tripName + TestSettings.GetRandomString(5, 10), 2000);
            XrmApp.ThinkTime(2000);

            XrmApp.Entity.SetValueWithThinkTime("startdate", startDate, 2000);
            XrmApp.ThinkTime(2000);

            XrmApp.Entity.SetValueWithThinkTime("enddate", endDate, 2000);
         
            //Save Trip 
            XrmApp.Entity.Save();
            XrmApp.ThinkTime(1000);
           // XrmApp.Dialogs.DialogOK(DialogButton);
        }
    }
}