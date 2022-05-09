using TechTalk.SpecFlow;

namespace Cmc.Engage.UIAutomation.SpecBindings.BindingSteps.Engage.WebResources
{
    [Binding]
    public class EntityPicker : BindingStepBase
    {
        public EntityPicker(FeatureContext featureContext, ScenarioContext scenarioContext) : base(featureContext, scenarioContext)
        {
        }

        [Given(@"I have set (.*) to Entity in Entity Picker in the Form")]
        public void GivenIHaveSetEntityToInEntityPickerInTheForm(string entityName)
        {
            XrmApp.EntityPicker.SetEntity(entityName);
        }
        [Then(@"I click activity button (.*) in (.*) Timeline Section")]
        public void ThenIClickAcitvityButton(string buttonName, string sectionLabel)
        {
            XrmApp.EntityPicker.SelectInteractionActivity(buttonName, sectionLabel);
        }

        [Then(@"I select Activity (.*) under Lifecycle Dropdown in the Timeline")]
        public void ThenISelectAcitvity(string activityName)
        {
            XrmApp.EntityPicker.SelectActivity(activityName);
        }

        [Given(@"I have set (.*) Entity to (.*) Entity Picker in the Form")]
        public void GivenIHaveSetKendoToEntityPickerInTheForm(string entityName, string fieldName)
        {
            XrmApp.EntityPicker.SetKendoEntity(entityName, fieldName);
        }

       

        [Given(@"I click Internal connections button in Connections section")]
        [When(@"I click Internal connections button in Connections section")]
        [Then(@"I click Internal connections button in Connections section")]
        public void GivenIClickButtonInternalConnection()
        {
            XrmApp.Connections.InternalConnectionButton();
            

        }


    }
}
