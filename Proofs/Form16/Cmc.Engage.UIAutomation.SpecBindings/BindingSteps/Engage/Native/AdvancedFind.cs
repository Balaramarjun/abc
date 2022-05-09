using TechTalk.SpecFlow;

namespace Cmc.Engage.UIAutomation.SpecBindings.BindingSteps.Engage.Native
{
    [Binding]
    public class AdvancedFind : BindingStepBase
    {
        public AdvancedFind(FeatureContext featureContext, ScenarioContext scenarioContext) : base(featureContext, scenarioContext)
        {
        }
        [Given(@"I click Save in the Advanced Find Window")]
        public void GivenIClickSaveInTheAdvancedFindWindow()
        {
            XrmApp.AdvancedFind.Save();
        }
        [Given(@"I close the Advanced Find Window")]
        [When(@"I close the Advanced Find Window")]
        [Then(@"I close the Advanced Find Window")]
        public void GivenICloseTheAdvancedFindWindow()
        {
            XrmApp.AdvancedFind.Close();
            XrmApp.SwitchToMainWindow();
        }
        [Given(@"I select (.*) dropdown filter value as (.*)")]
        [When(@"I select (.*) dropdown filter value as (.*)")]
        [Then(@"I select (.*) dropdown filter value as (.*)")]

        public void WhenISelectOptionInDropDownFilter(string fieldName, string fieldValue)
        {
            XrmApp.AdvancedFind.DropDownFilter(fieldName, fieldValue);

        }

        [Given(@"I select sub filter option as (.*) from (.*) option group in row (.*)")]
        [When(@"I select sub filter option as (.*) from (.*) option group in row (.*)")]
        [Then(@"I select sub filter option as (.*) from (.*) option group in row (.*)")]

        public void WhenISelectSubFilter(string fieldTextToSelect, string fieldGroup, int rowNo)
        {
            XrmApp.AdvancedFind.FilterControls(fieldTextToSelect, fieldGroup, rowNo);

        }

        [Given(@"I select filter option as (.*) for (.*) field")]
        [When(@"I select filter option as (.*) for (.*) field")]
        [Then(@"I select filter option as (.*) for (.*) field")]

        public void WhenISelectSpecificFilter(string fieldTextToSelect, string Fieldname)
        {
            XrmApp.AdvancedFind.SubFilters(fieldTextToSelect, Fieldname);

        }

        [Given(@"I enter (.*) in (.*) field")]
        [When(@"I enter (.*) in (.*) field")]
        [Then(@"I enter (.*) in (.*) field")]

        public void WhenIEnterValueInFilter(string fieldTextToEnter, string Fieldname)
        {
            XrmApp.AdvancedFind.FilterInput(fieldTextToEnter, Fieldname);
        }

        [Given(@"I click (.*) in (.*) group of advanced find ribbon")]
        [When(@"I click (.*) in (.*) group of advanced find ribbon")]
        [Then(@"I click (.*) in (.*) group of advanced find ribbon")]

        public void WhenIClickAdvancedFindRibbon(string buttonName, string Groupname)
        {
            XrmApp.AdvancedFind.RibbonItem(buttonName, Groupname);
        }


        [Given(@"I verify (.*) in advanced find results")]
        [When(@"I verify (.*) in advanced find results")]
        [Then(@"I verify (.*) in advanced find results")]

        public void WhenIClickAdvancedFindRibbon(string RecordName)
        {
            XrmApp.AdvancedFind.CompareResults(RecordName);
        }


    }
}
