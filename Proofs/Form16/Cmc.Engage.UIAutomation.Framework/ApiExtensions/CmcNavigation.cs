using System;
using Cmc.Engage.UIAutomation.Framework.XPath;
using Microsoft.Dynamics365.UIAutomation.Api.UCI;
using Microsoft.Dynamics365.UIAutomation.Browser;
using OpenQA.Selenium;
using System.Linq;

namespace Cmc.Engage.UIAutomation.Framework.ApiExtensions
{
    public class CmcNavigation : Navigation
    {
        private readonly WebClient _webClient;

        public CmcNavigation(WebClient client) : base(client)
        {
            _webClient = client;
        }

     
           private static void SwitchToMainFrame(IWebDriver driver)
        {

            driver.WaitForPageToLoad();
            driver.SwitchTo().Frame(0);
            driver.WaitForPageToLoad();
          
        }

        private static void SwitchToDefaultContent(IWebDriver driver)
        {

            SwitchToMainFrame(driver);
           driver.SwitchTo().DefaultContent();
            Console.WriteLine("Navigated to Portal");

            //Switch Back to Default Content for Navigation Steps
        
        }


       

        public BrowserCommandResult<bool> TPCPaymentClick()
        {
            return _webClient.Execute(BaseExtensions.GetOptionsInternal("Login TPC"), driver =>
            {

                driver.Navigate().GoToUrl("https://900083engagecms-qa2.azurewebsites.net/campusnexus-portal/application/registration/invoicegeneration?isNew=false&cmc_applicationregistrationid=d3afb36a-648b-ce9a-4979-3e3a68c9dce7&cmc_applicationdecisionid=00000000-0000-0000-0000-000000000000");
                 var Pay = driver.FindElement(By.XPath(".//button[contains(@type,'submit')]"));
                Console.WriteLine("Password entered");
                Pay.Submit();

                return true;
            });
        }


        public BrowserCommandResult<bool> NavigateToGlobalCommand(string name)
        {
            return _webClient.Execute(BaseExtensions.GetOptionsInternal($"Open Global Command{name}"), driver =>
            {
                IWebElement ribbon;

                //Find the button in the CommandBar
                if (driver.HasElement(By.XPath(CmcAppElements.Xpath[CmcAppReference.CommandBar.Container])))
                {
                    ribbon = driver.FindElement(By.XPath(CmcAppElements.Xpath[CmcAppReference.CommandBar.Container]));

                    if (ribbon == null)
                    {
                        if (driver.HasElement(By.XPath(CmcAppElements.Xpath[CmcAppReference.CommandBar.ContainerGrid])))
                            ribbon = driver.FindElement(By.XPath(AppElements.Xpath[AppReference.CommandBar.ContainerGrid]));
                        else
                            throw new InvalidOperationException("Unable to find the ribbon.");

                    }

                    //Get the CommandBar buttons
                    var items = ribbon.FindElements((By.XPath($"//li/button[@aria-label='{name}']")));

                    //Is the button in the ribbon?
                    if (items.Any(x => x.GetAttribute("aria-label").StartsWith(name, StringComparison.OrdinalIgnoreCase)))
                    {
                        items.FirstOrDefault(x => x.GetAttribute("aria-label").StartsWith(name, StringComparison.OrdinalIgnoreCase)).Click();
                        driver.WaitForTransaction();
                        _webClient.Browser.ThinkTime(5000);
                    }
                    else
                        throw new InvalidOperationException("Unable to find the command.");
                }
                return true;

            });
        }



        public BrowserCommandResult<bool> AdditionalLoginSteps()
        {
            return _webClient.Execute(BaseExtensions.GetOptionsInternal($"Additional steps"), driver =>
            {
                IWebElement Next;

                //Find the button in the CommandBar
                if (driver.HasElement(By.XPath(CmcAppElements.Xpath[CmcAppReference.Navigation.NextButton])))
                {
                    Next = driver.FindElement(By.XPath(CmcAppElements.Xpath[CmcAppReference.Navigation.NextButton]));

                    if (Next != null)
                    {
                        Next.Click();


                    }
                    else
                        throw new InvalidOperationException("Unable to find the button.");
                }
               
                _webClient.Browser.ThinkTime(8000);
                var linkToClick = driver.WaitUntilAvailable(By.LinkText("Skip setup"));               
               _webClient.Browser.ThinkTime(2000);
                if (linkToClick != null)
                {
                    linkToClick.Click();
                    Console.WriteLine("clicked");
                }


                return true;

            });
        }
        public BrowserCommandResult<bool> RedirectAppSwitch(string AppName)
        {
            return _webClient.Execute(BaseExtensions.GetOptionsInternal("Redirect App Switch"), driver =>
            {
                IWebElement NavBar;

                // try to find the Nav Bar (in case of RC2)
                if (driver.HasElement(By.XPath(CmcAppElements.Xpath[CmcAppReference.Navigation.NavBar])))
                {
                    NavBar = driver.FindElement(By.XPath(CmcAppElements.Xpath[CmcAppReference.Navigation.NavBar]));
                    Console.WriteLine("NavBar found");

                    var spans = NavBar.FindElements(By.TagName("span"));
                    // Console.WriteLine("Span elements found");
                    if (spans.Any(x => x.GetAttribute("title").Equals("Switch to another app", StringComparison.OrdinalIgnoreCase)))
                    {

                        var Applist = spans.FirstOrDefault(x => x.GetAttribute("title").Equals("Switch to another app", StringComparison.OrdinalIgnoreCase));

                        Applist.Click();

                        //       Console.WriteLine("App list ready");
                        //driver.SwitchTo().Window(driver.WindowHandles[0]);
                      //  driver.SwitchTo().Window();

                        driver.WaitForTransaction();
                    }
                    else
                        throw new NotFoundException("Switch to another app button not found ");
                }
                else if (driver.HasElement(By.XPath("//div[contains(@data-id,'topBar')]")))
                //  if (driver.HasElement(By.XPath("//div[contains(@data-id,'topBar')]")))
                {
                    NavBar = driver.FindElement(By.XPath("//div[contains(@data-id,'topBar')]"));
                    Console.WriteLine("TopBar found");

                    try
                    {

                        var buttons = NavBar.FindElements(By.XPath(".//button"));
                        Console.WriteLine("button elements found");
                        Console.WriteLine(buttons.Count);
                        if (buttons.Any(x => x.GetAttribute("title").Equals("Switch to another app button", StringComparison.OrdinalIgnoreCase)))
                        {

                            var Applist = buttons.FirstOrDefault(x => x.GetAttribute("title").Equals("Switch to another app button", StringComparison.OrdinalIgnoreCase));

                            Applist.Click();

                            Console.WriteLine("App list ready");

                            // driver.WaitForTransaction();
                            _webClient.Browser.ThinkTime(3000);

                            var AppSection = driver.WaitUntilAvailable(By.XPath("//div[contains(@id,'taskpane-scroll-container')]"), "App Section Not found");
                            //   Console.WriteLine("App Section found");
                           // var AppSection = driver.WaitUntilAvailable(By.XPath("//div[contains(@id,'AppLandingPageContentContainer')]"), "App Section Not found");
                            var AppItems = AppSection.FindElements(By.XPath("//div[contains(@class,'item-label-container')]//span[contains(@class,'item-label')]"));
                          //  var AppItems = AppSection.FindElements(By.XPath("//div[contains(@id,'AppDetailsSec')]//div[contains(@data-type,'app-title')]"));

                            
                            //   Console.WriteLine("App Items  found");
                            //   Console.WriteLine(AppItems.Count);


                            if (AppItems.Any(x => x.Text.Equals(AppName, StringComparison.OrdinalIgnoreCase)))
                            {

                                var AppToSelect = AppItems.FirstOrDefault(x => x.Text.Equals(AppName, StringComparison.OrdinalIgnoreCase));

                                AppToSelect.Click();

                                Console.WriteLine("App Selected");

                                driver.WaitForTransaction();
                            }
                            else
                                throw new NotFoundException($"App {UCIAppName.Anthology} not found ");
                        }
                        else
                            throw new NotFoundException("Navigate to another application button not found");
                    }
                    catch (Exception ex)
                    {
                        if (ex.Message == "Navigate to another application button not found")
                        {

                            //NavBar = driver.FindElement(By.XPath("//div[contains(@data-id,'topBar')]"));
                            Console.WriteLine("Searching app in dialog");

                            var applink = NavBar.FindElement(By.XPath($".//a//span[contains(text(),'{UCIAppName.Anthology}')]"));
                            applink.Click();
                            _webClient.Browser.ThinkTime(5000);


                            driver.SwitchTo().Frame("AppLandingPage");

                            var ApplistContainer = driver.FindElement(By.XPath("//div[contains(@id,'AppLandingPageContentContainer')]"));
                            driver.ExecuteScript("arguments[0].style.backgroundColor = 'blue'", ApplistContainer);
                            var AppToSelect = ApplistContainer.FindElement(By.XPath($".//a[contains(@aria-label, '{AppName}')]"));
                            AppToSelect.Click();
                            _webClient.Browser.ThinkTime(3000);

                            driver.SwitchTo().DefaultContent();
                        }
                        else
                            throw new NotFoundException($"App {AppName} not found in the dialog");

                    }
                }

                else
                    throw new NotFoundException("TopBar not found");
                return true;

            });
        }





    }
}