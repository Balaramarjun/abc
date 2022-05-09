using System;
using Cmc.Engage.UIAutomation.Framework;
using Cmc.Engage.UIAutomation.Framework.CustomAttributes;
using Microsoft.Dynamics365.UIAutomation.Api.UCI;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Cmc.Engage.UIAutomation.Tests.Trip
{
    [TestClass]
    public class TestSubmittedForReiew : TestBase
    {
        [TestMethod]
        [ExcelDataSource("Trip", "BPFSubmittedForReiew", "BPFSubmittedForReiew")]
        public void SubmittedForReviewBPF(string area,
            string subArea,
            string Stage1, string Reviewer, string stage2, string tripname
        )

        {
            SwitchPersona("Reviewer");
            
            //switch to Active trips list
            XrmApp.Navigation.OpenSubArea(area, subArea);
            XrmApp.ThinkTime(2000);

            //Search Trip 
            XrmApp.Grid.Search(tripname);
            XrmApp.Grid.OpenRecord(0);
            XrmApp.ThinkTime(1000);

            //Complete Submitted For Review stage in BPF
            XrmApp.BusinessProcessFlow.SelectStage(Stage1);
            var fields = new Field {Name = "header_process_cmc_approvalcomment", Value = "Test Comment"};

            XrmApp.BusinessProcessFlow.NextStage(Stage1, fields);
            XrmApp.ThinkTime(1000);

            XrmApp.BusinessProcessFlow.SelectStage(stage2);
            XrmApp.BusinessProcessFlow.Finish();

            //  XrmApp.BusinessProcessFlow.Close(stage2);
           // var getField = XrmApp.Entity.GetField("cmc_approvedby");
           // Console.WriteLine(getField.Value);
            //XrmApp.ThinkTime(1000);
           // Assert.IsTrue(getField.Value.Equals(Reviewer));
        }
    }
}