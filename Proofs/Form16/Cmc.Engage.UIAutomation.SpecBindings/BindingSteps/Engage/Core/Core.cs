using TechTalk.SpecFlow;

namespace Cmc.Engage.UIAutomation.SpecBindings.BindingSteps.Engage.Core
{
    [Binding]
    public class Core : BindingStepBase
    {
        public Core(FeatureContext featureContext, ScenarioContext scenarioContext) : base(featureContext, scenarioContext)
        {
        }

        [Then(@"I return to main window")]
        public void ThenIReturnToMainWindow()
        {
            XrmApp.SwitchToMainWindow();
        }

        [When(@"I capture screenshot")]
        [Then(@"I capture screenshot")]
        public void ThenICaptureScreenshot()
        {
            var featureName = _featureContext.FeatureInfo.Title;
            var scenarioName = _scenarioContext.ScenarioInfo.Title;
            XrmApp.Entity.Screenshot(featureName, scenarioName);

            XrmApp.ThinkTime(2000);
        }
    }

    
}
