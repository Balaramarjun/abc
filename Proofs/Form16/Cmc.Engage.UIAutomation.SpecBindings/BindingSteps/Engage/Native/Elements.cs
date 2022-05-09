
using Cmc.Engage.UIAutomation.Framework;
using Cmc.Engage.UIAutomation.Framework.ApiExtensions;
using Microsoft.Dynamics365.UIAutomation.Api.UCI;
using System;
using System.Diagnostics;
using TechTalk.SpecFlow;


namespace Cmc.Engage.UIAutomation.SpecBindings.BindingSteps.Engage.Native
{
    [Binding]
    public class Elements : BindingStepBase
    {
        public Elements(FeatureContext featureContext, ScenarioContext scenarioContext) : base(featureContext, scenarioContext)
        {
        }



        [Given(@"I enter (.*) in the (.*) text field")]
        [When(@"I enter (.*) in the (.*) text field")]
        [Then(@"I enter (.*) in the (.*) text field")]
        public void WhenIEnterTextInTheField(string TextValue, string FieldName)
        {
            //XrmApp.Elements.
            // XrmApp.ThinkTime(2000);
        }


        [Given(@"I click Page button")]
        [When(@"I click Page button")]
        [Then(@"I click Page button")]
        public void WhenIClickPageButton()
        {
            XrmApp.Elements.ClickPageButton();
            XrmApp.ThinkTime(2000);
        }

        [Given(@"I verify (.*) field has (.*) value")]
        [When(@"I verify (.*) field has (.*) value")]
        [Then(@"I verify (.*) field has (.*) value")]
        public void WhenIVerifyReadOnlyFieldValue(string FieldName, string FieldValue)
        {
            XrmApp.Elements.VerifyPopulatedFieldValue(FieldName, FieldValue);
            XrmApp.ThinkTime(2000);
        }

        [Given(@"I verify multiple fields")]
        [When(@"I verify multiple fields")]
        [Then(@"I verify multiple fields")]
        public void GivenIVerifyMultipleFields(Table table)
        {
            foreach (var tableRow in table.Rows)
            {
                var fieldType = tableRow["Type"];
                var fieldName = tableRow["FieldName"];
                var fieldValue = tableRow["FieldValue"];

                switch (fieldType)
                {

                    case "ReadOnlyFields":
                        WhenIVerifyReadOnlyFieldValue(fieldName, fieldValue);
                        break;

                }
            }
        }

        [Given(@"I click (.*) button in the page")]
        [When(@"I click (.*) button in the page")]
        [Then(@"I click (.*) button in the page")]
        public void WhenIClickButtonInPage(string ButtonName)
        {
            XrmApp.Elements.ClickActionButton(ButtonName);
            XrmApp.ThinkTime(2000);
        }
        [Given(@"In the sublist view, I click (.*) button")]
        [When(@"In the sublist view, I click (.*) button")]
        [Then(@"In the sublist view, I click (.*) button")]
        public void WhenIClickButtoninSublistContainer(string ButtonName)
        {
            XrmApp.Elements.SubListviewButton(ButtonName);
            XrmApp.ThinkTime(2000);
        }




        [Given(@"I verify title of the page is (.*)")]
        [When(@"I verify title of the page is (.*)")]
        [Then(@"I verify title of the page is (.*)")]
        public void WhenIVerifyTitleOfPage(string ExpectedTitle)
        {
            XrmApp.Elements.VerifyPageTitle(ExpectedTitle);
            XrmApp.ThinkTime(2000);
        }
        [Given(@"I verify Heading of the page is (.*)")]
        [When(@"I verify Heading of the page is (.*)")]
        [Then(@"I verify Heading of the page is (.*)")]

        public void WhenIVerifyHeadingOfPage(string ExpectedHeader)
        {
            XrmApp.Elements.VerifyPageHeading(ExpectedHeader);
            XrmApp.ThinkTime(2000);
        }
        //[Given(@"I click the payment button")]
        //[When(@"I click the payment button")]
        //[Then(@"I click the payment button")]
        //public void WhenIClickPaymentButton(string TextValue, string FieldName)
        //{
        //    XrmApp.Navigation.TPCPaymentClick();
        //    XrmApp.ThinkTime(2000);
        //}

        [Given(@"I click Set button in the form")]
        [When(@"I click Set button in the form")]
        [Then(@"I click Set button in the form")]
        public void WhenIClickButtonInform()
        {
            XrmApp.Elements.ClickSetButton();
            XrmApp.ThinkTime(2000);
        }

    }
}

