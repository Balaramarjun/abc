using System;
using System.Linq;
using Cmc.Engage.UIAutomation.Framework.XPath;
using Microsoft.Dynamics365.UIAutomation.Api.UCI;
using Microsoft.Dynamics365.UIAutomation.Browser;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace Cmc.Engage.UIAutomation.Framework.ApiExtensions
{
    public class CmcDialog : Dialogs
    {
        private readonly WebClient _webClient;

        public CmcDialog(WebClient client) : base(client)
        {
            _webClient = client;
        }

        public BrowserCommandResult<bool> DialogOK(string buttonID)
        {
            return TestSettings.CurrentPersonaDto.XrmApp.WebClient.Execute(BaseExtensions.GetOptionsInternal($"Click button {buttonID} "), driver =>
            {
                Console.WriteLine("section found");

                var parentElement = driver.WaitUntilAvailable(By.XPath("//div[contains(@id,'modalDialogView')]"), "No dialog available");

              
                    Console.WriteLine("parentElement found");
                    var items = parentElement.FindElements(By.XPath(".//button"));
                    Console.WriteLine("items found");
                    //Is the button in the ribbon?
                    if (items.Any(x => x.GetAttribute("id").Equals(buttonID, StringComparison.OrdinalIgnoreCase)))
                    {
                        items.FirstOrDefault(x => x.GetAttribute("id").Equals(buttonID, StringComparison.OrdinalIgnoreCase)).Click();
                        driver.WaitForTransaction();
                        Console.WriteLine("Clicked");
                    }
                    else
                        throw new NotFoundException($"button with name {buttonID} not found on form.");
                
                return true;
            });
        }


    public BrowserCommandResult<bool> HandleDialogAsPerMsg(string buttonID,string WarningMsg)
    {
        return TestSettings.CurrentPersonaDto.XrmApp.WebClient.Execute(BaseExtensions.GetOptionsInternal($"Click button {buttonID} "), driver =>
        {
            Console.WriteLine("section found");

            var parentElement = driver.FindElement(By.XPath("//div[contains(@id,'modalDialogView')]"));


            Console.WriteLine("parentElement found");
            var item = parentElement.FindElement(By.XPath(".//span[contains(@id, 'dialogMessageText')]"));
            if (item.Text.StartsWith(WarningMsg))
            {
                var items = parentElement.FindElements(By.XPath(".//button"));
                Console.WriteLine("items found");
                //Is the button in the ribbon?
                if (items.Any(x => x.GetAttribute("id").Equals(buttonID, StringComparison.OrdinalIgnoreCase)))
                {
                    items.FirstOrDefault(x => x.GetAttribute("id").Equals(buttonID, StringComparison.OrdinalIgnoreCase)).Click();
                    driver.WaitForTransaction();
                    Console.WriteLine("Clicked");
                }
                else
                    throw new NotFoundException($"button with name {buttonID} not found on form.");
                Assert.Fail($"Pop-up with msg {WarningMsg}");
            }
            //Is the button in the ribbon?
         else
                throw new NotFoundException($"button with name {buttonID} not found on form.");

                return true;
    });
        }
public BrowserCommandResult<bool> DialogAction(string buttonLabel)
        {
            return _webClient.Execute(BaseExtensions.GetOptionsInternal($"Click button {buttonLabel}"), driver =>
            {
                IWebElement parentElement;
                if (driver.HasElement(By.XPath(CmcAppElements.Xpath[CmcAppReference.Dialogs.DialogFooterContainer])))
                {
                    parentElement = driver.FindElement(By.XPath(CmcAppElements.Xpath[CmcAppReference.Dialogs.DialogFooterContainer]));
                   
                    Console.WriteLine("parentElement found");
                    
                    var items = parentElement.FindElements(By.TagName("button"));

                    //Is the button in the ribbon?
                    if (items.Any(x => x.GetAttribute("aria-label").Equals(buttonLabel, StringComparison.OrdinalIgnoreCase)))
                    {
                        items.FirstOrDefault(x => x.GetAttribute("aria-label").Equals(buttonLabel, StringComparison.OrdinalIgnoreCase)).Click();
                        _webClient.Browser.ThinkTime(4000);
                    }
                    else
                        throw new NotFoundException($"button with name {buttonLabel} not found on form.");
                   }
                else if (driver.HasElement(By.XPath(CmcAppElements.Xpath[CmcAppReference.Dialogs.mscrmRefreshDialogButton])))
                {
                    parentElement = driver.FindElement(By.XPath(CmcAppElements.Xpath[CmcAppReference.Dialogs.mscrmRefreshDialogButton]));
                    var items = parentElement.FindElements(By.TagName("button"));

                    if (items.Any(x => x.GetAttribute("title").Equals(buttonLabel, StringComparison.OrdinalIgnoreCase)))
                    {

                        items.FirstOrDefault(x => x.GetAttribute("title").Equals(buttonLabel, StringComparison.OrdinalIgnoreCase)).Click();
                        _webClient.Browser.ThinkTime(2000);
                        Console.WriteLine("Clicked");
                    }
                    else
                        throw new NotFoundException($"button with name {buttonLabel} not found on form.");
                }

                else
                    throw new NotFoundException("Footer Container not found on form.");

                return true;
            });
        }

         

      
        public BrowserCommandResult<bool> AcceptAlert()
        {
            return _webClient.Execute(BaseExtensions.GetOptionsInternal("Accept Alert"), driver =>
            {
                 driver.SwitchTo().Alert().Accept();

                return true;
            });
        }

        public BrowserCommandResult<bool> RunFlow(string buttonLabel)
        {
            return _webClient.Execute(BaseExtensions.GetOptionsInternal($"Click button {buttonLabel}"), driver =>
            {
            IWebElement parentElement;

            driver.SwitchTo().ActiveElement();
            parentElement = driver.FindElement(By.XPath("//div[contains(@id, 'dialogView')]"));

            _webClient.Browser.ThinkTime(2000);
            driver.SwitchTo().Frame("MicrosoftFlows_iframe");
            Console.WriteLine("Frame 1 switched.");

            var frame2 = driver.SwitchTo().Frame("widgetIFrame");
            Console.WriteLine("Frame 2 switched.");
            _webClient.Browser.ThinkTime(2000);
            var Footer = frame2.FindElement(By.XPath(".//div[contains(@class, 'InvokeFlowFooter-buttonContainer')]"));
            
            var buttons = Footer.FindElements(By.XPath(".//span"));
            Console.WriteLine("Button count is: " + buttons.Count);
            
            if (buttons.Any(x => x.Text.Equals(buttonLabel, StringComparison.OrdinalIgnoreCase)))
            {
                Console.WriteLine("Text found");
                    var buttonToClick = buttons.FirstOrDefault(x => x.Text.Equals(buttonLabel, StringComparison.OrdinalIgnoreCase));
                    driver.WaitForTransaction();                    
                    buttonToClick.Click();
                }
                else
                {
                    Console.WriteLine($"{buttonLabel} not available.");
                }

                return true;
            });
        }


    }
}