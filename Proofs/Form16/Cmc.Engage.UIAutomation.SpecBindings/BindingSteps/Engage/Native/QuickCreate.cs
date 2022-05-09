
using Microsoft.Dynamics365.UIAutomation.Api.UCI;
using TechTalk.SpecFlow;

namespace Cmc.Engage.UIAutomation.SpecBindings.BindingSteps.Engage.Native
{
    [Binding]
    public class QuickCreate : BindingStepBase
    {
        public QuickCreate(FeatureContext featureContext, ScenarioContext scenarioContext) : base(featureContext, scenarioContext)
        {
        }

        [Given(@"I have set (.*) to (.*) text field in the QuickCreate")]
        [When(@"I have set (.*) to (.*) text field in the QuickCreate")]
        public void GivenIHaveSetValueToTextFieldInQuickCreate(string fieldValue, string fieldName)
        {
            XrmApp.QuickCreate.SetValue(fieldValue, fieldName);
            XrmApp.ThinkTime(2000);

        }
        [When(@"I press Save in QuickCreate")]
        [Given(@"I press Save in QuickCreate")]
        [Then(@"I press Save in QuickCreate")]
        public void WhenIPressSaveInQuickCreate()
        {
            XrmApp.QuickCreate.Save();
            XrmApp.ThinkTime(5000);
        }

        [Then(@"the QuickCreate should be saved")]
        public void ThenQuickCreateShouldBeSaved()
        {

        }
        [Given(@"I have set (.*) to (.*) lookup field in the QuickCreate")]
        [When(@"I have set (.*) to (.*) lookup field in the QuickCreate")]
        public void GivenIHaveSetValueToLookupFieldInQuickCreate(string fieldValue, string fieldName)
        {
            var lookupItem = new LookupItem
            {
                Name = fieldName,
                Value = fieldValue,
                Index = 0
            };
         
            XrmApp.QuickCreate.SetValue(lookupItem);
            XrmApp.ThinkTime(2000);
        }
    }
}
