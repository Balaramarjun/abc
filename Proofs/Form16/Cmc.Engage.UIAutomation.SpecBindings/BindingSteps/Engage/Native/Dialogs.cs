using System;
using TechTalk.SpecFlow;

namespace Cmc.Engage.UIAutomation.SpecBindings.BindingSteps.Engage.Native
{
    [Binding]
    public class Dialogs : BindingStepBase
    {
        public Dialogs(FeatureContext featureContext, ScenarioContext scenarioContext) : base(featureContext, scenarioContext)
        {
        }

        [Given(@"I click (.*) in Confirmation dialog")]
        [Then(@"I click (.*) in Confirmation dialog")]
        public void GivenIClickOkInConfirmationDialog(string buttonClicked)
        {
            XrmApp.ThinkTime(3000);
            if (buttonClicked.Equals("Ok"))
            {
                XrmApp.Dialogs.ConfirmationDialog(true);
            }
            else
            {
                XrmApp.Dialogs.ConfirmationDialog(false);
            }

        }
        [Then(@"I verify (.*) in Confirmation dialog")]
        public void VerifyWarningMsg(string warningmessage)
        {
            XrmApp.ThinkTime(3000);

            XrmApp.Dialogs.Equals(warningmessage);
        }

        [Given(@"I click (.*) button in dialog")]
        [When(@"I click (.*) button in dialog")]
        [Then(@"I click (.*) button in dialog")]
        public void GivenIClickActionButtoninDialog(string buttonLabel)
        {

            XrmApp.Dialogs.DialogAction(buttonLabel);
            

        }
        //[Given(@"I select (.*) option in (.*) field in the dialog")]
        //[When(@"I select (.*) option in (.*) field in the dialog")]
        //[Then(@"I select (.*) option in (.*) field in the dialog")]
        //public void GivenISelectFieldOptionInDialog(string Option, string fieldName)
        //{

        //    XrmApp.Dialogs.DialogOptionSetAction(Option, fieldName);


        //}

        [Given(@"I handle the dialog action button (.*) only if available")]
        [When(@"I handle the dialog action button (.*) only if available")]
        [Then(@"I handle the dialog action button (.*) only if available")]
        public void GivenIClickButtoninDialogWhenAvailable(string buttonID)
        {
            try
            {
            XrmApp.Dialogs.DialogOK(buttonID);
            }
            catch (Exception)
            {
               XrmApp.ThinkTime(500);

            }


        }
        [Given(@"I click (.*) button in dialog only if available")]
        [When(@"I click (.*) button in dialog only if available")]
        [Then(@"I click (.*) button in dialog only if available")]
        public void WhenIClickActionButtoninDialogWhenAvialable(string buttonLabel)
        {
            try
            {
                XrmApp.Dialogs.DialogAction(buttonLabel);
               
            }
            catch (Exception ex)
            {

                if (ex.Message == "Footer Container not found on form.")

                    XrmApp.ThinkTime(500);

            }


        }

        [Given(@"I handle dialog with button (.*)")]
        [When(@"I handle dialog with button (.*)")]
        [Then(@"I handle dialog with button (.*)")]
        public void GivenIhandleDialogWithOneButton(string buttonID)
        {

            XrmApp.Dialogs.DialogOK(buttonID);
     


    }

        [Given(@"Handle dialog with button (.*) with message (.*) only if available")] 
        [When(@"Handle dialog with button (.*) with message (.*) only if available")]
        [Then(@"Handle dialog with button (.*) with message (.*) only if available")]
        public void ThrowErrorForMsgDialog(string buttonID, string WarningMsg)
        {
            try
            {
                XrmApp.Dialogs.HandleDialogAsPerMsg(buttonID, WarningMsg);
            }
            catch (Exception)
            {
                XrmApp.ThinkTime(500);

            }
          
        }

        [Given(@"I accept the alert pop-up")]
        [When(@"I accept the alert pop-up")]
        [Then(@"I accept the alert pop-up")]
        public void GivenIAcceptAlert()
        {
            XrmApp.Dialogs.AcceptAlert();
        }

        [Given(@"I click the flow dialog action button (.*)")]
        [When(@"I click the flow dialog action button (.*)")]
        [Then(@"I click the flow dialog action button (.*)")]
        public void GivenIClickButtoninFlowDialogWhenAvailable(string buttonLabel)
        {
            try
            {
                XrmApp.Dialogs.RunFlow(buttonLabel);
            }
            catch (Exception)
            {
                XrmApp.ThinkTime(500);
            }
        }

    }
 
}

   