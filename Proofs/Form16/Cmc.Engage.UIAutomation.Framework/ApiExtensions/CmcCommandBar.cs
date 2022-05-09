using System;
using Cmc.Engage.UIAutomation.Framework.XPath;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.Dynamics365.UIAutomation.Api.UCI;
using Cmc.Engage.UIAutomation.Framework;
using Microsoft.Dynamics365.UIAutomation.Browser;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System.Collections.Generic;
using System.Linq;
//using AutoIt;
using System.Threading;
using System.Windows.Forms;
using System.Runtime.InteropServices.ComTypes;
namespace Cmc.Engage.UIAutomation.Framework.ApiExtensions
{
    public class CmcCommandBar : CommandBar
    {
        private readonly WebClient _webClient;

        public CmcCommandBar(WebClient client) : base(client)
        {
            _webClient = client;
        }
        public BrowserCommandResult<bool> ClickCommandOnAssociatedSubgrid(string CommandName)
        {
            return _webClient.Execute(BaseExtensions.GetOptionsInternal($"click command {CommandName} associated subgrid"), driver =>
            {

                //IWebElement parentElement;


              //  if (driver.HasElement(By.XPath($"//ul[contains(@data-lp-id = 'SubGridAssociated:customeraddress')]")))
              //  {
                    var divElement = driver.WaitUntilAvailable(By.XPath("//ul[contains(@data-lp-id,'commandbar-SubGridAssociated')]"), "Associated Subgrid not found");
               
                var items = divElement.FindElements(By.XPath(".//li"));

                Console.WriteLine("count" + items.Count);

                ////Is the button in the ribbon?
                 if (items.Any(x => x.GetAttribute("title").Contains(CommandName, StringComparison.OrdinalIgnoreCase)))
                {

                    Console.WriteLine("button found");

                    var buttonToClick = items.FirstOrDefault(x => x.GetAttribute("title").Contains(CommandName, StringComparison.OrdinalIgnoreCase));

                    Console.WriteLine("buttonToClick found");
                    ((IJavaScriptExecutor)driver).ExecuteScrip‌t("arguments[0].style.backgroundColor = 'blue'", buttonToClick);
                    ((IJavaScriptExecutor)driver).ExecuteScrip‌t("arguments[0].click();", buttonToClick);
                    //   buttonToClick.Click();
                    Console.WriteLine("Subgrid button clicked");
                    _webClient.Browser.ThinkTime(3000);
                    driver.WaitForTransaction();
                }
                else if (items.Any(x => x.GetAttribute("aria-label").Equals(CommandName, StringComparison.OrdinalIgnoreCase)))
                {

                    Console.WriteLine("button found");

                    var buttonToClick = items.FirstOrDefault(x => x.GetAttribute("aria-label").Equals(CommandName, StringComparison.OrdinalIgnoreCase));

                    Console.WriteLine("buttonToClick found");
                    ((IJavaScriptExecutor)driver).ExecuteScrip‌t("arguments[0].style.backgroundColor = 'blue'", buttonToClick);
                    ((IJavaScriptExecutor)driver).ExecuteScrip‌t("arguments[0].click();", buttonToClick);
                    //   buttonToClick.Click();
                    Console.WriteLine("Subgrid button clicked");
                    _webClient.Browser.ThinkTime(3000);
                    driver.WaitForTransaction();
                }
                else
                    throw new NotFoundException($"Command button {CommandName} not found in the associated commandbar ");



                return true;
            });
        }
        

        public BrowserCommandResult<bool> ClickCommandOnSubGrid(string subgridButtonName,string subgridName)
        {
            return _webClient.Execute(BaseExtensions.GetOptionsInternal($"Select Subgrid {subgridButtonName} button {subgridName}"), driver =>
            {
                

                IWebElement parentElement;
                if (driver.HasElement(By.XPath($"//section[contains(@aria-label,'{subgridName}')]")))
                {
                    parentElement = driver.FindElement(By.XPath($"//section[contains(@aria-label,'{subgridName}')]"));
                    Console.WriteLine("Section found");
                    ((IJavaScriptExecutor)driver).ExecuteScript("arguments[0].scrollIntoView(true);", parentElement);
                    ((IJavaScriptExecutor)driver).ExecuteScrip‌t("arguments[0].style.backgroundColor = 'blue'", parentElement);

                }

                else if(driver.HasElement(By.XPath($"//div[text() = '{subgridName}']")))
                {
                    var divElement = driver.FindElement(By.XPath($"//div[text() = '{subgridName}']"));
                    parentElement = divElement.FindElement(By.XPath("parent::*"));
                    Console.WriteLine("div found");
                }
                else
                {
                    throw new NotFoundException($"Subgrid {subgridName} not found on form.");
                }
                Console.WriteLine(""+ parentElement.GetAttribute("aria-label"));
                _webClient.Browser.ThinkTime(3000);

      
                    var items = parentElement.FindElements(By.XPath(".//ul//li"));
             
                    Console.WriteLine("count" + items.Count);

                ////Is the button in the ribbon?
               
                 if(items.Any(x => x.GetAttribute("title").Contains(subgridButtonName, StringComparison.CurrentCultureIgnoreCase)))
                {
                    var buttonToClick = items.FirstOrDefault(x => x.GetAttribute("title").Contains(subgridButtonName, StringComparison.CurrentCultureIgnoreCase));

                    Console.WriteLine("list item found by title");
                    ((IJavaScriptExecutor)driver).ExecuteScrip‌t("arguments[0].style.backgroundColor = 'blue'", buttonToClick);
                    ((IJavaScriptExecutor)driver).ExecuteScrip‌t("arguments[0].click();", buttonToClick);
                    //   buttonToClick.Click();
                   
                    Console.WriteLine("Subgrid button clicked");
                    _webClient.Browser.ThinkTime(3000);
                    driver.WaitForTransaction();
                }
              else  if (items.Any(x => x.GetAttribute("aria-label").StartsWith(subgridButtonName, StringComparison.CurrentCultureIgnoreCase)))
                {

                    Console.WriteLine("list item found by aria label");

                    var buttonToClick = items.FirstOrDefault(x => x.GetAttribute("aria-label").StartsWith(subgridButtonName, StringComparison.CurrentCultureIgnoreCase));

                    Console.WriteLine("buttonToClick found");
                    ((IJavaScriptExecutor)driver).ExecuteScrip‌t("arguments[0].style.backgroundColor = 'blue'", buttonToClick);
                    ((IJavaScriptExecutor)driver).ExecuteScrip‌t("arguments[0].click();", buttonToClick);
                    //   buttonToClick.Click();
                    Console.WriteLine("Subgrid button clicked");
                    _webClient.Browser.ThinkTime(3000);
                    driver.WaitForTransaction();
                }
                else
                    throw new NotFoundException($"Subgrid button {subgridButtonName} not found on form.");

                
              
                return true;
            });
        }
        public BrowserCommandResult<bool> ClickButtonOnSubGrid(string subgridButtonName, string subgridName)
        {
            return _webClient.Execute(BaseExtensions.GetOptionsInternal($"Select Subgrid {subgridButtonName} button {subgridName}"), driver =>
            {

                IWebElement parentElement;


                if (driver.HasElement(By.XPath($"//div[text() = '{subgridName}']")))
                {
                    var divElement = driver.FindElement(By.XPath($"//div[text() = '{subgridName}']"));
                    parentElement = divElement.FindElement(By.XPath("parent::*"));
                    Console.WriteLine("div found");
                }
                else if (driver.HasElement(By.XPath($"//section[@aria-label='{subgridName}']")))
                {
                    parentElement = driver.FindElement(By.XPath($"//section[contains(@aria-label,'{subgridName}')]"));
                    Console.WriteLine("Section found");
                    ((IJavaScriptExecutor)driver).ExecuteScript("arguments[0].scrollIntoView(true);", parentElement);

                    // ((IJavaScriptExecutor)driver).ExecuteScrip‌t("arguments[0].style.backgroundColor = 'blue'", parentElement);
                    //_webClient.Browser.ThinkTime(2000);
                }
                else
                {
                    throw new NotFoundException($"Subgrid not found on form.");
                }

                var items = parentElement.FindElements(By.XPath(".//button"));
                Console.WriteLine(items.Count);
              
                //Is the button in the ribbon?
                if (items.Any(x => x.GetAttribute("aria-label") == subgridButtonName))
                {

                    Console.WriteLine("button found");

                    var buttonToClick = items.FirstOrDefault(x => x.GetAttribute("aria-label").Equals(subgridButtonName, StringComparison.CurrentCulture));

                    Console.WriteLine("buttonToClick found");
                    ((IJavaScriptExecutor)driver).ExecuteScrip‌t("arguments[0].style.backgroundColor = 'blue'", buttonToClick);
                    ((IJavaScriptExecutor)driver).ExecuteScrip‌t("arguments[0].click();", buttonToClick);
                    //   buttonToClick.Click();
                    Console.WriteLine("Subgrid button clicked");
                    _webClient.Browser.ThinkTime(3000);
                    driver.WaitForTransaction();
                }
                else
                    throw new NotFoundException("Subgrid button not found on form.");
                return true;
            });
        }

        public BrowserCommandResult<bool> ClickSubGridOptions( string options, string subgridButtonName)
        {
            return _webClient.Execute(BaseExtensions.GetOptionsInternal($"Select Subgrid {subgridButtonName} button {options}"), driver =>
            {
                IWebElement parentElement;          
               
                if (driver.HasElement(By.XPath($"//ul[@aria-label='{subgridButtonName}']")))
                {
                    Console.WriteLine("parentElement 1");
                      parentElement = driver.WaitUntilAvailable(By.XPath($"//ul[@aria-label='{subgridButtonName}']"));
                  
                }

                else if (driver.HasElement(By.XPath("//div[contains(@id,'OverflowButton_button')]")))
                { 
                    Console.WriteLine("parentElement 2");
                   parentElement = driver.WaitUntilAvailable(By.XPath("//div[contains(@id,'OverflowButton_button')]"));
                   // parentElement = parentElement2;
                }
                else
                {
                    throw new NotFoundException($"Subgrid {subgridButtonName} not found on form.");
                }
                Console.WriteLine("Subgrid found");

                var menuList = parentElement.FindElements(By.XPath(".//button"));

                Console.WriteLine(menuList.Count);

                //Is the button in the ribbon?
                if (menuList.Any(x => x.GetAttribute("aria-label") .Contains(options)))
                {
                    Console.WriteLine(menuList.Count);
                    //  var optionToClick = menuList.FirstOrDefault(x => x.GetAttribute("aria-label").Equals(options, StringComparison.CurrentCultureIgnoreCase));
                    var optionToClick = menuList.FirstOrDefault(x => x.GetAttribute("aria-label") .Contains(options));


                    driver.WaitForTransaction();

                    Console.WriteLine(menuList.FirstOrDefault().GetAttribute("aria-label"));

                    _webClient.Browser.ThinkTime(2000);


                    ((IJavaScriptExecutor)driver).ExecuteScrip‌t("arguments[0].style.backgroundColor = 'blue'", optionToClick);

                    //bool clickCheck =  optionToClick.IsEnable() && optionToClick.IsVisible() && optionToClick.IsClickable();
                    //if (clickCheck)
                    //{

                    // Console.WriteLine(clickCheck);
                    ((IJavaScriptExecutor)driver).ExecuteScrip‌t("arguments[0].click();", optionToClick);

                    driver.WaitForPageToLoad();


                    //}
                    //else
                    //    throw new NotFoundException("Element not clickable");
                }   

                return true;
            });
        }
        public BrowserCommandResult<bool> SelectSubGridFlyoutOption(string FlyoutOption, bool clickOption = true)
        {
            return _webClient.Execute(BaseExtensions.GetOptionsInternal($"Select option {FlyoutOption} in subgrid"), driver =>
            {
                IWebElement parentElement;
                if (driver.HasElement(By.XPath(CmcAppElements.Xpath[CmcAppReference.CommandBar.FlyoutNode])))
                {
                    parentElement = driver.FindElement(By.XPath(CmcAppElements.Xpath[CmcAppReference.CommandBar.FlyoutNode]));
                    Console.WriteLine("parentElement found");
                    //else if (driver.HasElement(By.XPath(CmcAppElements.Xpath[CmcAppReference.CommandBar.FlyoutNode])
                    // // var ActiveElement = driver.SwitchTo().ActiveElement();
                    // // var ActionList = parentElement.FindElement(By.XPath(CmcAppElements.Xpath[CmcAppReference.CommandBar.ActivityList]));
                    // Console.WriteLine("ActionList found");
                    _webClient.Browser.ThinkTime(5000);
                    var menuList = parentElement.FindElements(By.XPath(".//li"));
                    if (menuList.Any(x => x.GetAttribute("aria-label") == FlyoutOption))
                    {
                        var option = menuList.FirstOrDefault(x => x.GetAttribute("aria-label") == FlyoutOption);
                        Console.WriteLine("option found" + option.GetAttribute("aria-label")); if (clickOption)
                        {
                            option.Click(); Console.WriteLine("option clicked");
                        }
                        //Assert.AreEqual(option.GetAttribute("aria-label"), FlyoutOption); Console.WriteLine("FlyoutOption found");
                        //driver.WaitForTransaction();
                    }
                    else
                        throw new NotFoundException($"FlyoutOption {FlyoutOption} not found in menu list.");
                }
                else
                    throw new NotFoundException($"FlyoutOption section not found on grid."); return true;
            });
        }


        public BrowserCommandResult<bool> ClickCommandInDivSubgrid(string subgridButtonName, string subgridName)
        {
            return _webClient.Execute(BaseExtensions.GetOptionsInternal($"Select Subgrid {subgridButtonName} button {subgridName}"), driver =>
            {
            //    IWebElement parentElement;
                    
               var parentElement = driver.FindElement(By.XPath(CmcAppElements.Xpath[CmcAppReference.Entity.SubgridDiv].Replace("[NAME]", subgridName)));
                    Console.WriteLine("div found");
                
                   ((IJavaScriptExecutor)driver).ExecuteScript("arguments[0].scrollIntoView(true);", parentElement);
                ((IJavaScriptExecutor)driver).ExecuteScrip‌t("arguments[0].style.backgroundColor = 'blue'", parentElement);

                  if (parentElement != null)
                 {
                Console.WriteLine("parentElement found");
                    //var items = new parentElement;
                var items = parentElement.FindElements(By.XPath(CmcAppElements.Xpath[CmcAppReference.Entity.CommandsList]));

                _webClient.Browser.ThinkTime(3000);
                Console.WriteLine("count" + items.Count);
                    ////Is the button in the ribbon?
                    if (items.Any(x => x.GetAttribute("title").Contains(subgridButtonName, StringComparison.OrdinalIgnoreCase)))
                    {

                        Console.WriteLine("button found");

                        var buttonToClick = items.FirstOrDefault(x => x.GetAttribute("title").Contains(subgridButtonName, StringComparison.OrdinalIgnoreCase));

                        Console.WriteLine("buttonToClick found");
                        ((IJavaScriptExecutor)driver).ExecuteScrip‌t("arguments[0].style.backgroundColor = 'blue'", buttonToClick);
                        ((IJavaScriptExecutor)driver).ExecuteScrip‌t("arguments[0].click();", buttonToClick);
                        Console.WriteLine("Subgrid button clicked");
                        _webClient.Browser.ThinkTime(3000);
                        driver.WaitForTransaction();
                    }
                    else
                        throw new NotFoundException($"Subgrid button {subgridButtonName} not found on form.");
               }
                else
                   throw new NotFoundException($"Subgrid division {subgridName} not found on form.");

                return true;
            });
        }

        public BrowserCommandResult<bool> clickCommandMultiSubgrid(string subgridButtonName, string subgridName, string sectionLabel)
        {
            return _webClient.Execute(BaseExtensions.GetOptionsInternal($"Select Subgrid {subgridButtonName} button {subgridName}"), driver =>
            {
              
                var sectiondiv = driver.FindElement(By.XPath($"//div[contains(@aria-label,'{sectionLabel}')]"));
               // Console.WriteLine("Section found");

                var parentElement = sectiondiv.FindElement(By.XPath($".//div[contains(@id,'dataSetRoot_{subgridName}') and contains(@data-id,'dataSetRoot_{subgridName}')]"));
               // var parentElement = sectiondiv.FindElement(By.XPath($".//div[contains(@data - control - name, '{subgridName}') and contains(@data-id,'dataSetRoot_{subgridName}']"));
//Console.WriteLine("div found");
                
              
                

                if (parentElement != null)
                {
                    Console.WriteLine("parentElement found");
                    //var items = new parentElement;
                    var items = parentElement.FindElements(By.XPath(CmcAppElements.Xpath[CmcAppReference.Entity.CommandsList]));
                    _webClient.Browser.ThinkTime(3000);
                    Console.WriteLine("count" + items.Count);
                    ////Is the button in the ribbon?
                    if (items.Any(x => x.GetAttribute("title").Contains(subgridButtonName, StringComparison.OrdinalIgnoreCase)))
                    {

                        Console.WriteLine("button found");

                        var buttonToClick = items.FirstOrDefault(x => x.GetAttribute("title").Contains(subgridButtonName, StringComparison.OrdinalIgnoreCase));

                        Console.WriteLine("buttonToClick found");
                      //  ((IJavaScriptExecutor)driver).ExecuteScrip‌t("arguments[0].style.backgroundColor = 'blue'", buttonToClick);
                        ((IJavaScriptExecutor)driver).ExecuteScrip‌t("arguments[0].click();", buttonToClick);
                        Console.WriteLine("Subgrid button clicked");
                        _webClient.Browser.ThinkTime(8000);
                       // driver.WaitForTransaction();
                    }
                    else
                        throw new NotFoundException($"Subgrid button {subgridButtonName} not found on form.");
                }
                else
                    throw new NotFoundException($"Subgrid division {subgridName} not found on form.");

                return true;
            });
        }

        public BrowserCommandResult<bool> ClickFlowCommand(string FlyoutOption, bool clickOption = true)
        {
            return _webClient.Execute(BaseExtensions.GetOptionsInternal($"Select option {FlyoutOption} in subgrid"), driver =>
            {
                IWebElement parentElement;   
                
                parentElement = driver.FindElement(By.XPath(".//div[contains(@data-id, 'commandBar')]"));
                Console.WriteLine("Command bar found.");

                var commandBar = parentElement.FindElement(By.XPath(".//ul[contains(@data-id, 'CommandBar')]"));
                
                var moreCommands = commandBar.FindElement(By.XPath(".//li[contains(@id,'OverflowButton')]"));
                ((IJavaScriptExecutor)driver).ExecuteScrip‌t("arguments[0].style.backgroundColor = 'blue'", moreCommands);

                moreCommands.Click();
                ((IJavaScriptExecutor)driver).ExecuteScrip‌t("arguments[0].click();", moreCommands);
                _webClient.Browser.ThinkTime(3000);

                var flyoutlist = driver.WaitUntilAvailable(By.XPath(".//div[contains(@id, 'OverflowButton')]"), "flylist not found");
                
                Console.WriteLine("Fly list found");

                var FlowCommand = flyoutlist.FindElements(By.XPath(".//li"));                

                if (FlowCommand.Any(x => x.GetAttribute("title").Contains(FlyoutOption, StringComparison.CurrentCultureIgnoreCase)))
                {                    
                    var item = FlowCommand.FirstOrDefault(x => x.GetAttribute("title").Contains(FlyoutOption, StringComparison.CurrentCultureIgnoreCase));
                    driver.WaitForTransaction();
                    item.Click();
                    _webClient.Browser.ThinkTime(8000);                                      
                }
                else
                {
                    Console.WriteLine("No flow button is Available");
                }

                return true;
            });
        }

        public BrowserCommandResult<bool> SelectFlow(string FlowName, bool clickOption = true)
        {
            return _webClient.Execute(BaseExtensions.GetOptionsInternal($"Select option {FlowName} in flow menu"), driver =>
            {
                IWebElement parentElement;

                parentElement = driver.WaitUntilAvailable(By.XPath(".//ul[contains(@data-id, 'Flows.RefreshCommandBar')]"));

                _webClient.Browser.ThinkTime(3000);
                Console.WriteLine("flyout found");

                var childElement = parentElement.FindElements(By.XPath(".//li"));
                
                _webClient.Browser.ThinkTime(3000);
                string RunFlow = $"Run {FlowName}";
                
                if (childElement.Any(x => x.GetAttribute("aria-label") == RunFlow))
                {                    
                    var item = childElement.FirstOrDefault(x => x.GetAttribute("aria-label") == RunFlow);
                    driver.WaitForTransaction();
                    _webClient.Browser.ThinkTime(3000);
                    item.Click();
                    _webClient.Browser.ThinkTime(8000);
                }
                else
                {
                    Console.WriteLine($"{FlowName} not available.");
                }

                return true;
            });
        }

        public BrowserCommandResult<bool> Clicksubgridoption(string options, string subgridButtonName)
        {
            return _webClient.Execute(BaseExtensions.GetOptionsInternal($"Select Subgrid {subgridButtonName} button {options}"), driver =>
            {
                IWebElement parentElement;

                if (driver.HasElement(By.XPath($"//ul[@aria-label='{subgridButtonName}']")))
                {
                    Console.WriteLine("parentElement 1");
                    parentElement = driver.WaitUntilAvailable(By.XPath($"//ul[@aria-label='{subgridButtonName}']"));

                }

                else if (driver.HasElement(By.XPath("//div[contains(@id,'OverflowButton_button')]")))
                {
                    Console.WriteLine("parentElement 2");
                    parentElement = driver.WaitUntilAvailable(By.XPath("//div[contains(@id,'OverflowButton_button')]"));
                    // parentElement = parentElement2;
                }
                else
                {
                    throw new NotFoundException($"Subgrid {subgridButtonName} not found on form.");
                }
                Console.WriteLine("Subgrid found");

                var menuList = parentElement.FindElements(By.XPath(".//button"));

                Console.WriteLine(menuList.Count);

                //Is the button in the ribbon?
                if (menuList.Any(x => x.GetAttribute("aria-label").Contains(options)))
                {
                    Console.WriteLine(menuList.Count);
                    //  var optionToClick = menuList.FirstOrDefault(x => x.GetAttribute("aria-label").Equals(options, StringComparison.CurrentCultureIgnoreCase));
                    var optionToClick = menuList.FirstOrDefault(x => x.GetAttribute("aria-label").Contains(options));
                    optionToClick.Click();

                    /*driver.WaitForTransaction();

                    Console.WriteLine(menuList.FirstOrDefault().GetAttribute("aria-label"));

                    _webClient.Browser.ThinkTime(2000);


                    ((IJavaScriptExecutor)driver).ExecuteScrip‌t("arguments[0].style.backgroundColor = 'blue'", optionToClick);

           
                    ((IJavaScriptExecutor)driver).ExecuteScrip‌t("arguments[0].click();", optionToClick);

                    driver.WaitForPageToLoad();
                    */


                }

                return true;
            });
        }

        public BrowserCommandResult<bool> ClickFlow(string FlyoutOption, bool clickOption = true)
        {
            return _webClient.Execute(BaseExtensions.GetOptionsInternal($"Select option {FlyoutOption} in subgrid"), driver =>
            {
                IWebElement parentElement;

                parentElement = driver.FindElement(By.XPath(".//div[contains(@data-id, 'commandBar')]"));
                Console.WriteLine("Command bar found.");

                var commandBar = parentElement.FindElement(By.XPath(".//ul[contains(@data-id, 'CommandBar')]"));

                var moreCommands = commandBar.FindElement(By.XPath(".//li[contains(@id,'OverflowButton')]"));
                ((IJavaScriptExecutor)driver).ExecuteScrip‌t("arguments[0].style.backgroundColor = 'blue'", moreCommands);

                moreCommands.Click();
                ((IJavaScriptExecutor)driver).ExecuteScrip‌t("arguments[0].click();", moreCommands);
                _webClient.Browser.ThinkTime(3000);

                var flyoutlist = driver.WaitUntilAvailable(By.XPath(".//div[contains(@id, 'OverflowButton')]"));

                Console.WriteLine("Fly list found");

                var FlowCommand = flyoutlist.FindElements(By.XPath(".//li"));
                //button[contains(@aria-label, 'Flow')]

                if (FlowCommand.Any(x => x.GetAttribute("aria-label").Contains(FlyoutOption, StringComparison.CurrentCultureIgnoreCase)))
                {
                    var item = FlowCommand.FirstOrDefault(x => x.GetAttribute("aria-label").Contains(FlyoutOption, StringComparison.CurrentCultureIgnoreCase));
                    driver.WaitForTransaction();
                    item.Click();
                    _webClient.Browser.ThinkTime(8000);
                }
                else
                {
                    Console.WriteLine("No flow button is Available");
                }

                return true;
            });
        }




    }
}