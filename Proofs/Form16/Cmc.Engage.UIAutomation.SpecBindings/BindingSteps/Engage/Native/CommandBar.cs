using Cmc.Engage.UIAutomation.Framework.ApiExtensions;
using System;
using TechTalk.SpecFlow;

namespace Cmc.Engage.UIAutomation.SpecBindings.BindingSteps.Engage.Native
{
    [Binding]
    public class CommandBar : BindingStepBase
    {
        public CommandBar(FeatureContext featureContext, ScenarioContext scenarioContext) : base(featureContext, scenarioContext)
        {
        }

        [Given(@"I have clicked (.*) command in View")]
        [When(@"I have clicked (.*) command in View")]
        [Then(@"I have clicked (.*) command in View")]
        public void GivenIHaveClickedCommandInView(string commandName)
        {
            XrmApp.CommandBar.ClickCommand(commandName);
           XrmApp.ThinkTime(8000);
        }

        [Given(@"I click (.*) command in associated View")]
        [When(@"I click (.*) command in associated View")]
        [Then(@"I click(.*) command in associated View")]
        public void GivenIClickCommandInAssociated(string commandName)
        {
            XrmApp.CommandBar.ClickCommandOnAssociatedSubgrid(commandName);
            XrmApp.ThinkTime(3000);
        }
       
        [Given(@"I open the (.*) window")]
        public void GivenIOpenTheAssignSuccessPlanWindow(string commandName)
        {
            XrmApp.OpenWindow(() => XrmApp.CommandBar.ClickCommand(commandName));
        }
        [Given(@"I have clicked (.*) command on (.*) SubGrid")]
        [When(@"I have clicked (.*) command on (.*) SubGrid")]
        [Then(@"I have clicked (.*) command on (.*) SubGrid")]
        public void GivenIHaveClickCommandOnSubGrid(string subGridButtonName, string subGridName)
        {
            XrmApp.ThinkTime(3000);
            XrmApp.Entity.SubGrid.ClickCommand(subGridName, subGridButtonName);
            //XrmApp.CommandBar.ClickCommandOnSubGrid(subGridButtonName, subGridName);
            XrmApp.ThinkTime(3000);
        }

        [Given(@"I click available command (.*) on (.*) SubGrid")]
        [When(@"I click available command (.*) on (.*) SubGrid")]
        [Then(@"I click available command (.*) on (.*) SubGrid")]
        public void GivenIClickAvailableSubGrid(string subGridButtonName, string subGridName)
        {
            try
            {
                XrmApp.CommandBar.ClickCommandOnSubGrid(subGridButtonName, subGridName);
            }
            catch (Exception ex)
            { 
                if(ex !=null)
                {

                    XrmApp.CommandBar.ClickCommandOnSubGrid("More commands", subGridName);

                }
            }

        }

        [Given(@"I click (.*) command on (.*) SubGrid when available")]
        [When(@"I click (.*) command on (.*) SubGrid when available")]
        [Then(@"I click (.*) command on (.*) SubGrid when available")]
        public void IClickCommandOnSubGridWhenAvailable(string subGridButtonName, string subGridName)
        {
            try
            {
                XrmApp.CommandBar.ClickCommandOnSubGrid(subGridButtonName, subGridName);
                XrmApp.ThinkTime(3000);

            }
            catch (Exception)
            {
                
                Console.WriteLine("tried to find command on subgrid");
            
            }
        }
        [Given(@"I click (.*) button on (.*) SubGrid only if available")]
        [When(@"I click (.*) button on (.*) SubGrid only if available")]
        [Then(@"I click (.*) button on (.*) SubGrid only if available")]

        public void GivenIClickButtonOnSubGrid(string subGridButtonName, string subGridName)
        {
            try
            {
                XrmApp.CommandBar.ClickButtonOnSubGrid(subGridButtonName, subGridName);
                XrmApp.ThinkTime(3000);
            }
            catch (Exception ex)

            {
                if (ex.Message.Contains("Subgrid button not found on form."))
                {

                    XrmApp.CommandBar.ClickCommandOnSubGrid(subGridButtonName, subGridName);

                }
                Console.WriteLine("tried to find the button on subgrid");
            }
        }

        [Given(@"I have clicked (.*) SubGrid option on (.*) SubGrid")]
        [When(@"I have clicked (.*) SubGrid option on (.*) SubGrid")]
        [Then(@"I have clicked (.*) SubGrid option on (.*) SubGrid")]
        public void GivenIHaveClickSubGridOptions(string subGridOption, string subGridButtonName)
        {
            XrmApp.CommandBar.ClickSubGridOptions(subGridOption, subGridButtonName);
        }

        [Given(@"I click (.*) SubGrid option on (.*) SubGrid when available")]
        [When(@"I click (.*) SubGrid option on (.*) SubGrid when available")]
        [Then(@"I click (.*) SubGrid option on (.*) SubGrid when available")]
        public void GivenIClickSubGridOptionsAvailable(string subGridOption, string subGridButtonName)
        {
            try
            {
                XrmApp.CommandBar.ClickSubGridOptions(subGridOption, subGridButtonName);
            }
            catch (Exception)
            {
                Console.WriteLine("Subgrid option if available");
            
            }
        }

        [Given(@"I select (.*) flyout option in the Subgrid")]
        [When(@"I select (.*) flyout option in the Subgrid")]
        [Then(@"I select (.*) flyout option in the Subgrid")]
        public void WhenISelectFlyoutOption(string FlyoutOption)
        {
            XrmApp.CommandBar.SelectSubGridFlyoutOption(FlyoutOption);
            XrmApp.ThinkTime(3000);
        }


        [Given(@"I verify (.*) flyout option exists in the Subgrid")]
        [When(@"I verify (.*) flyout option exists in the Subgrid")]
        [Then(@"I verify (.*) flyout option exists in the Subgrid")]
        public void WhenIVerifyFlyoutOption(string FlyoutOption)
        {
            XrmApp.CommandBar.SelectSubGridFlyoutOption(FlyoutOption,false);
            XrmApp.ThinkTime(3000);
        }

        [Then(@"I verify Ribbon Button (.*) is not present")]
        public void ThenIVerifyRibbonButton(string ButtonName)
        {
            try
            {
                XrmApp.CommandBar.ClickCommand(ButtonName);
                throw new Exception($"Button found");
            }
            catch (Exception ex)
            {
                if (ex.Message == "Button found")
                    throw new Exception($"Button found");
            }




        }

        [Given(@"I click (.*) command in (.*) SubGrid Division")]
        [When(@"I click (.*) command in (.*) SubGrid Division")]
        [Then(@"I click (.*) command in (.*) SubGrid Division")]

        public void GivenIHaveClickCommand(string subGridButtonName, string subGridName)
        {
            XrmApp.CommandBar.ClickCommandInDivSubgrid(subGridButtonName, subGridName);
            XrmApp.ThinkTime(3000);
        }

        [Given(@"I choose to click (.*) command in (.*) SubGrid out of multiple sections in (.*) div if available")]
        [When(@"I choose to click (.*) command in (.*) SubGrid out of multiple sections in (.*) div if available")]
        [Then(@"I choose to click (.*) command in (.*) SubGrid out of multiple sections in (.*) div if available")]

        public void GivenIClickCommandMulti(string CommandToclick, string subGrid, string sectionLabel)
        {
            //try
            //{
                XrmApp.CommandBar.clickCommandMultiSubgrid(CommandToclick, subGrid, sectionLabel);
                XrmApp.ThinkTime(3000);
           // }
           //catch (Exception ex)
           // {
           //     Console.WriteLine("exception is " +ex);
           // }        
        }

        [Given(@"I find (.*) command on (.*) SubGrid as per availability")]
        [When(@"I find (.*) command on (.*) SubGrid as per availability")]
        [Then(@"I find (.*) command on (.*) SubGrid as per availability")]
        public void IFindCommandOnSubGridWhenAvailable(string subGridButtonName, string subGridName)
        {
            try
            {
                XrmApp.CommandBar.ClickCommandOnSubGrid(subGridButtonName, subGridName);
                XrmApp.ThinkTime(3000);

            }
            catch (Exception Ex)
            {
                if (Ex.Message.StartsWith("Subgrid button"))
                {
                    XrmApp.CommandBar.ClickCommandOnSubGrid("More Commands", subGridName);
                    XrmApp.CommandBar.ClickSubGridOptions(subGridButtonName, "More Commands");
                }
                else
                    throw new Exception("Command not found");
                Console.WriteLine("tried to find command on subgrid");

            }
        }

        [Given(@"I select (.*) flow in the flyout option")]
        [When(@"I select (.*) flow in the flyout option")]
        [Then(@"I select (.*) flow in the flyout option")]
        public void WhenISelectFlowFlyoutOption(string FlyoutOption)
        {
            XrmApp.CommandBar.ClickFlowCommand(FlyoutOption);
            XrmApp.ThinkTime(3000);
        }

        [Given(@"I select (.*) flow in the flow menu")]
        [When(@"I select (.*) flow in the flow menu")]
        [Then(@"I select (.*) flow in the flow menu")]
        public void WhenISelectFlowName(string FlowName)
        {
            XrmApp.CommandBar.SelectFlow(FlowName);
            XrmApp.ThinkTime(8000);
        }

        [Given(@"I have clicked (.*) command in a View")]
        [When(@"I have clicked (.*) command in a View")]
        [Then(@"I have clicked (.*) command in a View ")]
        public void clickmore(string commandName)
        {
            XrmApp.Entity.clickmorecommands(commandName);
            XrmApp.ThinkTime(2000);
        }

        [Then(@"I have clicked (.*) command in the View")]
        public void clickrecu(string command)
        {
            XrmApp.Entity.clickreccommands(command);
            XrmApp.ThinkTime(2000);
        }

        [Then(@"I have clicked (.*) command in a View")]
        public void clickflow(string command)
        {
            XrmApp.Entity.clickflowcommands(command);
            XrmApp.ThinkTime(2000);
        }


        [When(@"I have clicked (.*) command in the View")]
        public void clickaflow(string commandName)
        {
            XrmApp.Entity.clickflowcommands(commandName);
            XrmApp.ThinkTime(2000);
        }

        [Given(@"I click (.*) SubGrid option on (.*) in the available SubGrid")]
        [When(@"I click (.*) SubGrid option on (.*) in the available SubGrid")]
        [Then(@"I click (.*) SubGrid option on (.*) in the available SubGrid")]
        public void ClickSubGridOptionsAvailable(string subGridOption, string subGridButtonName)
        {
            try
            {
                XrmApp.CommandBar.Clicksubgridoption(subGridOption, subGridButtonName);
            }
            catch (Exception)
            {
                Console.WriteLine("Subgrid option if available");

            }
        }

        [Given(@"I select (.*) flow in a flyout option")]
        [When(@"I select (.*) flow in a flyout option")]
        [Then(@"I select (.*) flow in a flyout option")]
        public void WhenslectFlow(string FlyoutOption)
        {
            XrmApp.CommandBar.ClickFlow(FlyoutOption);
            XrmApp.ThinkTime(3000);

        }

    }

}