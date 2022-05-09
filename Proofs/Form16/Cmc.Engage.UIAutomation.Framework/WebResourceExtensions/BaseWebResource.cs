using Microsoft.Dynamics365.UIAutomation.Api.UCI;
using System;
using Cmc.Engage.UIAutomation.Framework.XPath;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using Microsoft.Dynamics365.UIAutomation.Browser;
using OpenQA.Selenium;
using Cmc.Engage.UIAutomation.Framework.ApiExtensions; 
using OpenQA.Selenium.Support.UI;
using System.Collections.Generic;
using System.Linq;
namespace Cmc.Engage.UIAutomation.Framework.WebResourceExtensions
{
    public class BaseWebResource
    {
        protected WebClient _webClient;
        protected CmcXrmApp XrmApp;

        public BaseWebResource(WebClient webClient)
        {
            _webClient = webClient;
            XrmApp = TestSettings.CurrentPersonaDto.XrmApp;
        }

        protected void SelectFrame(string frameName)
        {
            XrmApp.Driver.SwitchTo().Frame(frameName);
        }
        public BrowserCommandResult<bool> AppRootButton(string buttonName)
        {
            return _webClient.Execute(BaseExtensions.GetOptionsInternal($"Click button {buttonName} "), driver =>
            {
                IWebElement parentElement;


                if (driver.HasElement(By.TagName("app-root")))
                {
                    parentElement = driver.FindElement(By.TagName("app-root"));
                    //  System.Console.WriteLine("parentElement found");
                }

                else
                {
                    throw new NotFoundException($"ButtonName Container {buttonName} not found on form.");
                }


                var items = parentElement.FindElements(By.TagName("button"));
                //  System.Console.WriteLine("items found");

                if (items.Count >= 0)
                {
                    foreach (var item in items)
                    {
                        Console.WriteLine(item.Text);
                        Console.WriteLine(buttonName);
                        if (item.Text == buttonName)
                        {
                            item.Click();
                            break;
                        }
                    }

                    // System.Console.WriteLine("items clicked");

                }
                else
                {
                    throw new InvalidOperationException($"buttonName: {buttonName} Does not exist");
                }
                return true;
            });


        }


    }
}