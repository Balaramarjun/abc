using System;
using Microsoft.Dynamics365.UIAutomation.Api.UCI;
using Microsoft.Dynamics365.UIAutomation.Browser;
using OpenQA.Selenium;

namespace Cmc.Engage.UIAutomation.Framework.WebResourceExtensions
{
    public class AssignSuccessPlan : BaseWebResource
    {
        public AssignSuccessPlan(WebClient webClient) : base(webClient)
        {
        }

        public void SelectSuccessPlan(string successPlan)
        {
            SelectFrame("FullPageWebResource");
            var succesplantemplate = XrmApp.Driver.FindElement(By.ClassName("k-input"));
            succesplantemplate.SendKeys(successPlan);
            var popupselect = XrmApp.Driver.WaitUntilAvailable(By.ClassName("k-item"), new TimeSpan(0, 0, 6));
            //var popupselect = XrmApp.Driver.FindElement(By.ClassName("k-item"));
            popupselect.Click();
        }

        public void ClickAssignButton()
        {
            var Assignbutton = XrmApp.Driver.FindElement(By.Id("assignButton"));
            Assignbutton.Click();
            //XrmApp.ThinkTime(6000);
            //var Okconfirmation = XrmApp.Driver.FindElement(By.Id("okButton"));
            //XrmApp.ThinkTime(6000);
        }
    }
}