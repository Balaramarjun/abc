using TechTalk.SpecFlow;

namespace Cmc.Engage.UIAutomation.SpecBindings.BindingSteps.Engage.WebResources
{
    [Binding]
    public class ViewPicker : BindingStepBase
    {
        public ViewPicker(FeatureContext featureContext, ScenarioContext scenarioContext) : base(featureContext, scenarioContext)
        {
        }
        [Given(@"I click Use Existing View in View Picker")]
        public void GivenISelectUseExistingViewInViewPicker()
        {
            XrmApp.ViewPicker.ClickUseExistingViewButton();
        }

        [Given(@"I select view (.*) in View Picker")]
        public void GivenISelectViewInViewPicker(string viewName)
        {
            XrmApp.ViewPicker.SelectExistingView(viewName);
        }

        [Given(@"I click Use Query in View Picker")]
        public void GivenIClickUseQueryInViewPicker()
        {
            XrmApp.ViewPicker.ClickUseQueryButton();
        }

        [Given(@"I click Edit Query in View Picker which opens the Advanced Find Window")]
        public void GivenIClickEditQueryInViewPicker()
        {
            XrmApp.ViewPicker.ClickEditQuery();
        }


        [Given(@"I select (.*) view in View Picker in Query section")]
        public void GivenISelectViewInViewPickerInQuerySection(string viewName)
        {
            XrmApp.ViewPicker.SelectExistingViewInQuerySection(viewName);
        }

    }
}
