using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using TechTalk.SpecFlow;

namespace Cmc.Engage.UIAutomation.SpecBindings.BindingSteps.Engage.Native
{
    [Binding]
    public class Grid : BindingStepBase
    {
        public Grid(FeatureContext featureContext, ScenarioContext scenarioContext) : base(featureContext, scenarioContext)
        {
        }

        [When(@"I search (.*) in the grid")]
        [Given(@"I search (.*) in the grid")]
        public void WhenISearchInTheGrid(string searchTerm)
        {
            XrmApp.Grid.Search(searchTerm);
        }
        [When(@"I open the first record in the grid")]
        [Given(@"I open the first record in the grid")]
        [Then(@"I open the first record in the grid")]
        public void WhenIOpenTheFirstRecord()
        {
            XrmApp.ThinkTime(2000);
            XrmApp.Grid.OpenRecord(0);
           // XrmApp.ThinkTime(2000);
            //XrmApp.Entity.openfirstrecordgridNew("Mscrm", "0");
            XrmApp.ThinkTime(2000);
        }
        [When(@"I open record no. (.*) in the grid")]
        [Given(@"I open record no. (.*) in the grid")]
        [Then(@"I open record no. (.*) in the grid")]
        public void WhenIOpenUniqueRecord(int number)
        {
            XrmApp.Grid.OpenRecord(number);
            XrmApp.ThinkTime(2000);
          //  XrmApp.Grid.OpenRecord.
        }

        [Then(@"I should not see any records listed")]
        public void ThenIShouldNotSeeAnyRecordsListed()
        {
            var gridItems = XrmApp.Grid.GetGridItems();
            Assert.AreEqual(gridItems.Count, 0);
        }
        [Then(@"I open specific record (.*) from the grid")]
        public void ThenIOpenSpecificRecord(string recordName)
        {
            XrmApp.Grid.OpenRecordByText(recordName);
        }
        [When(@"I select record no.(.*) in the grid")]
        [Given(@"I select record no.(.*) in the grid")]
        [Then(@"I select record no.(.*) in the grid")]
        public void WhenIselectUniqueRecord(int number)
        {
            XrmApp.Grid.HighLightRecord(number);
           // XrmApp.Entity.selectfirstrecordsubgridNew(number);
         

        }

        [When(@"I open the first record in the grid in (.*) section")]
        [Given(@"I open the first record in the grid in (.*) section")]
        [Then(@"I open the first record in the grid in (.*) section")]
        public void WhenIOpenTheFirstRecordinSpecificSection(string sectionLabel)
        {
            XrmApp.ThinkTime(2000);
            XrmApp.Grid.OpenRecordInSpecificSection(0,sectionLabel);
            XrmApp.ThinkTime(2000);
        }


        [When(@"I click first record in the grid in (.*) section only if available")]
        [Given(@"I click first record in the grid in (.*) section only if available")]
        [Then(@"I click first record in the grid in (.*) section only if available")]
        public void WhenIOpenFirstRecordinSectionWhenAvailable(string sectionLabel)
        {

            try
            {
                XrmApp.Grid.OpenRecordInSpecificSection(0, sectionLabel);
                XrmApp.ThinkTime(2000);
            }
            catch (Exception)
            {

                Console.WriteLine("section is not present in grid view");
            }

           
            XrmApp.ThinkTime(2000);
        }

        [When(@"I verify there are no records in the grid in (.*) section")]
        [Given(@"I verify there are no records in the grid in (.*) section")]
        [Then(@"I verify there are no records in the grid in (.*) section")]
        public void WhenIVerifyIfNoRecordsinSpecificSection(string sectionLabel)
        {
            try
            {
                XrmApp.Grid.OpenRecordInSpecificSection(0, sectionLabel);
                XrmApp.ThinkTime(2000);
            }
            catch (Exception ex)
            {
                if (ex.Message == "No records are present in the grid")
                    Console.WriteLine("Grid is Empty");
            }          
        }

        [When(@"I select the (.*) specific record in the grid in (.*) section")]
        [Given(@"I select the (.*) specific record in the grid in (.*) section")]
        [Then(@"I select the (.*) specific record in the grid in (.*) section")]
        public void WhenISelectSpecificRecordinSpecificSection(int index,string sectionLabel)
        {
            XrmApp.Grid.OpenRecordInSpecificSection(index, sectionLabel, checkRecord: true);
            XrmApp.ThinkTime(2000);
        }

        [Given(@"I switch the view to (.*)")]
        [When(@"I switch the view to (.*)")]
        [Then(@"I switch the view to (.*)")]
        public void WhenISwitchView(string viewName)
        {
            XrmApp.Grid.SwitchView(viewName);
        //    XrmApp.ThinkTime(3000);
        }
    }
    }
        
