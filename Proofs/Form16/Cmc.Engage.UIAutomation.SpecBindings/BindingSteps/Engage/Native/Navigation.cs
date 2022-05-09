
using Cmc.Engage.UIAutomation.Framework;
using Cmc.Engage.UIAutomation.Framework.ApiExtensions;
using Microsoft.Dynamics365.UIAutomation.Api.UCI;
using System.Diagnostics;
using TechTalk.SpecFlow;

namespace Cmc.Engage.UIAutomation.SpecBindings.BindingSteps.Engage.Native
{
    [Binding]
    public class Navigation : BindingStepBase
    {
        public Navigation(FeatureContext featureContext, ScenarioContext scenarioContext) : base(featureContext, scenarioContext)
        {
        }

        [Given(@"I have navigated to the Area (.*) and SubArea (.*)")]
        [When(@"I have navigated to the Area (.*) and SubArea (.*)")]
        [Then(@"I have navigated to the Area (.*) and SubArea (.*)")]
        public void WhenIHaveNavigatedToTheSubArea(string area, string subArea)
        {
            XrmApp.ThinkTime(2000);
            XrmApp.Navigation.OpenSubArea(area, subArea);

            XrmApp.ThinkTime(2000);
        }

        [Given(@"I navigate to main Area and SubArea (.*)")]
        [When(@"I navigate to main Area and SubArea (.*)")]
        [Then(@"I navigate to main Area and SubArea (.*)")]
        public void WhenINavigateToMainArea(string subArea)
        {
            XrmApp.ThinkTime(2000);
            XrmApp.Navigation.OpenSubArea("Reach", subArea);
            XrmApp.ThinkTime(2000);
        }

        [Given(@"I click (.*) global command")]
        [When(@"I click (.*) global command")]
        [Then(@"I click (.*) global command")]
        public void WhenIOpenAdvancedFindWindow(string Name)
        {
            XrmApp.Navigation.NavigateToGlobalCommand(Name);
            XrmApp.Entity.SwitchToSpecificWindow("Advanced Find - Microsoft Dynamics 365");
        }

        [Given(@"I wait for (.*) specific time")]
        [When(@"I wait for (.*) specific time")]
        [Then(@"I wait for (.*) specific time")]
        public void WhenIWaitforlowTime(int time)
        {
            XrmApp.ThinkTime(time);
           
        }
        //Select Dashboard
        [Then(@"I Select (.*) dashboard")]
        public void ThenISelectDashboard(string DashboardName)
        {
            XrmApp.Dashboard.SelectDashboard(DashboardName);
        }

        [Then(@"I navigate to quick create (.*)")]
        public void ThenIopenQuickCreate(string Name)
        {
            XrmApp.Navigation.QuickCreate(Name);
        }

        [Given(@"I switch to (.*) App")]
       
        public void GivenISwitchApp(string AppName)
        {
            //XrmApp.SwitchToMainWindow();
            XrmApp.Navigation.RedirectAppSwitch(AppName);

            XrmApp.ThinkTime(2000);

        }

        [Then(@"I Select (.*) webresource from (.*) group")]
        [When(@"I Select (.*) webresource from (.*) group")]
        public void ThenISelectWebResource(string WebresourceName,string GroupName)
        {
            
            XrmApp.Navigation.OpenGroupSubArea(GroupName, WebresourceName);
           
        }

        [Then(@"I navigate to the Area (.*)")]
        [When(@"I navigate to the Area (.*)")]
        public void AndINavigatedToArea(string AreaName)
        {

            XrmApp.Entity.OpenArea(AreaName);

        }


    }


}