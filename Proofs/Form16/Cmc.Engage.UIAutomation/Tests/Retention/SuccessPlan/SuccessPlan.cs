using Cmc.Engage.UIAutomation.Framework;
using Cmc.Engage.UIAutomation.Framework.ApiExtensions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Cmc.Engage.UIAutomation.Tests.Retention.SuccessPlan
{
    [TestClass]
    public class SuccessPlan : TestBase
    {
        [TestMethod]
        //  [ExcelDataSource("Personas","Persona")]
        public void Successplanassginment()
        {
            SwitchPersona("Advisor");

            XrmApp.Navigation.OpenSubArea("Constituents", "Contacts");
            XrmApp.Grid.Search("Bala ram");
            XrmApp.Grid.OpenRecord(0);
            XrmApp.OpenWindow(() => XrmApp.CommandBar.ClickCommand("Assign Success Plan"));

            XrmApp.AssignSuccessPlan.SelectSuccessPlan("Ewj37IiHw4MT");
            XrmApp.AssignSuccessPlan.ClickAssignButton();

            // And switch back to the original window.
            XrmApp.SwitchToMainWindow();
        }
    }
}