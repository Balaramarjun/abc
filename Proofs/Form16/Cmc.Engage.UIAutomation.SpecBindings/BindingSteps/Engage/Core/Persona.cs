using TechTalk.SpecFlow;

namespace Cmc.Engage.UIAutomation.SpecBindings.BindingSteps.Engage.Core
{
    [Binding]
    public class Persona : BindingStepBase
    {
        public Persona(FeatureContext featureContext, ScenarioContext scenarioContext) : base(featureContext, scenarioContext)
        {
        }

        [Given(@"I have logged in as a (.*)")]
        public void GivenIHaveLoggedInAsPersona(string personaName)
        {
            SwitchPersona(personaName);
        }

        [Given(@"I logged in as a (.*) in specific browser")]
        public void GivenILogInSpecificBrowser(string personaName)
        {
            SwitchLoginSpecificBrowser(personaName);
        }

        [Given(@"I navigate to Registration URL as (.*)")]
        [When(@"I navigate to Registration URL as (.*)")]
        [Then(@"I navigate to Registration URL as (.*)")]
        public void WhenINavigateInToPortal(string personaName)
        {
            AppRegNavigation(personaName);
        }



    }
}