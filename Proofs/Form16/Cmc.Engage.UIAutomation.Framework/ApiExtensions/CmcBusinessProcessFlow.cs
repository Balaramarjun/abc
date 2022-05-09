using System;
using Cmc.Engage.UIAutomation.Framework.XPath;
using Microsoft.Dynamics365.UIAutomation.Api.UCI;
using Microsoft.Dynamics365.UIAutomation.Browser;
using OpenQA.Selenium;

namespace Cmc.Engage.UIAutomation.Framework.ApiExtensions
{
    public class CmcBusinessProcessFlow : BusinessProcessFlow
    {
        private readonly WebClient _webClient;

        public CmcBusinessProcessFlow(WebClient client) : base(client)
        {
            _webClient = client;
        }

        public BrowserCommandResult<bool> Finish(int thinkTime = Constants.DefaultThinkTime)
        {
            _webClient.Browser.ThinkTime(thinkTime);

            return _webClient.Execute("Finish BPF", driver =>
            {
                if (!driver.HasElement(By.XPath(CmcAppElements.Xpath[CmcAppReference.BusinessProcessFlow.Finish])))
                    throw new Exception("Business Process Flow Finish Element does not exist");

                //  if (driver.FindElement(By.XPath(CmcAppElements.Xpath[CmcAppReference.BusinessProcessFlow.Finish])).GetAttribute("aria-label").Contains("Finished"))
                //      throw new Exception("The Business Process is already finished");

                driver.ClickWhenAvailable(By.XPath(CmcAppElements.Xpath[CmcAppReference.BusinessProcessFlow.Finish]));

                driver.WaitUntilVisible(By.XPath(CmcAppElements.Xpath[CmcAppReference.BusinessProcessFlow.FinishedLabel]));

                if (!driver.FindElement(By.XPath(CmcAppElements.Xpath[CmcAppReference.BusinessProcessFlow.Finish])).GetAttribute("class").Contains("hidden"))
                    throw new Exception("The finish operation did not complete as expected.");


                return true;
            });
        }
    }
}