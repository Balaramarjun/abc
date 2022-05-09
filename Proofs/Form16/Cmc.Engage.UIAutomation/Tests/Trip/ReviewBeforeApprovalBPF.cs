using Cmc.Engage.UIAutomation.Framework;
using Cmc.Engage.UIAutomation.Framework.CustomAttributes;
using Microsoft.Dynamics365.UIAutomation.Api.UCI;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Cmc.Engage.UIAutomation.Tests.Trip
{
    [TestClass]
    public class TestReiewBeforeApproval : TestBase
    {
        [TestMethod]
        [ExcelDataSource("Trip", "BPFReiewBeforeApproval", "BPFReiewBeforeApproval")]
        public void ReiewBeforeApprovalBPF(string area,
            string subArea,
            string stage1,
            string stage2, string tripname
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

            // complete stage Review Before Approval in BPF
            XrmApp.BusinessProcessFlow.NextStage(stage1);
            XrmApp.BusinessProcessFlow.SelectStage(stage2);

            XrmApp.BusinessProcessFlow.SetValue(new BooleanItem {Name = "cmc_travelersdetails"});
            XrmApp.BusinessProcessFlow.SetValue(new BooleanItem {Name = "cmc_tripactivitydetails"});
            XrmApp.BusinessProcessFlow.SetValue(new BooleanItem {Name = "cmc_estimatedexpensedetails"});
            XrmApp.BusinessProcessFlow.NextStage(stage2);
            XrmApp.ThinkTime(1000);
        }
    }
}