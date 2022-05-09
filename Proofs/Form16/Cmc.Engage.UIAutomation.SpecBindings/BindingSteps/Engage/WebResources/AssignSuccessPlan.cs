using TechTalk.SpecFlow;

namespace Cmc.Engage.UIAutomation.SpecBindings.BindingSteps.Engage.WebResources
{
    [Binding]
    public class AssignSuccessPlan : BindingStepBase
    {
        public AssignSuccessPlan(FeatureContext featureContext, ScenarioContext scenarioContext) : base(featureContext, scenarioContext)
        {
        }

        [Given(@"I select (.*) Success Plan")]
        public void GivenISelectSuccessPlan(string successPlanName)
        {
            XrmApp.AssignSuccessPlan.SelectSuccessPlan(successPlanName);
        }

        [When(@"I click Assign Success Plan button")]
        public void GivenIClickAssignSuccessPlanButton()
        {
            XrmApp.AssignSuccessPlan.ClickAssignButton();
        }

    }
}
