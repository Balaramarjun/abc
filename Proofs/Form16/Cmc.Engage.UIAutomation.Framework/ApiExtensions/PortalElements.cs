using Microsoft.Dynamics365.UIAutomation.Api.UCI;
using Microsoft.Dynamics365.UIAutomation.Browser;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using System;
using System.Security;

namespace Cmc.Engage.UIAutomation.Framework.ApiExtensions
{
    public class PortalElements
    {
        private readonly WebClient _webClient;

        public PortalElements(WebClient client)
        {
            _webClient = client;
        }

        public BrowserCommandResult<bool> TPCLogin(Uri uri, SecureString username, SecureString password, bool RegURL)
        {
            return _webClient.Execute(BaseExtensions.GetOptionsInternal("Login TPC"), driver =>
            {

                driver.Navigate().GoToUrl(uri);

                Console.WriteLine("Navigated to Portal");

                //Enter Email of the user 
                var Email = driver.FindElement(By.XPath(".//input[contains(@id,'UserName')]"));
                Console.WriteLine("username entered");
                Email.SendKeys(username.ToUnsecureString());

                //Enter Password of the user 
                var Password = driver.FindElement(By.XPath(".//input[contains(@id,'Password')]"));
                Console.WriteLine("Password entered");
                Password.SendKeys(password.ToUnsecureString());

                //Click Login button

                var Login = driver.FindElement(By.XPath(".//button[contains(text(),'Log in')]"));
                Console.WriteLine("Login Button Clicked");
                Login.Submit();
                driver.WaitForPageToLoad();
                _webClient.Browser.ThinkTime(2000);

                if (RegURL == true)
                {
                    driver.Navigate().GoToUrl(TestSettings.RegURL);
                }

                return true;
            });
        }
        public BrowserCommandResult<bool> ClickPageButton()
        {
            return _webClient.Execute(BaseExtensions.GetOptionsInternal("Click Page Button"), driver =>
            {


                var div = driver.WaitUntilAvailable(By.XPath("//div[contains(@id, 'PageButtonModel_container')]"));

                var Pagebutton = div.FindElement(By.XPath(".//a"));


                Pagebutton.Click();
                driver.WaitForPageToLoad();
                _webClient.Browser.ThinkTime(4000);
                return true;
            });
        }

        public BrowserCommandResult<bool> VerifyPageTitle(string ExpectedTitle)
        {
            return _webClient.Execute(BaseExtensions.GetOptionsInternal($"I Verify if title is {ExpectedTitle}"), driver =>
            {


                var Title = driver.Title;

                Console.WriteLine("The actual title is " + Title);
                if (ExpectedTitle.Equals(Title, StringComparison.OrdinalIgnoreCase))
                {
                    Console.WriteLine("Strings are equal");
                }
                else
                    throw new Exception($"Title is not as expected");

                return true;
            });
        }


        public BrowserCommandResult<bool> VerifyPageHeading(string ExpectedHeader)
        {
            return _webClient.Execute(BaseExtensions.GetOptionsInternal($"I Verify if title is {ExpectedHeader}"), driver =>
            {
                driver.WaitForPageToLoad();
                var Header = driver.FindElement(By.XPath(".//h3"));
                driver.ExecuteScrip‌t("arguments[0].style.backgroundColor = 'blue'", Header);
                string Heading = Header.Text;


                Console.WriteLine("The actual title is " + Heading);
                if (ExpectedHeader.Equals(Heading, StringComparison.OrdinalIgnoreCase))
                {
                    Console.WriteLine("Strings are equal");
                }
                else
                    throw new Exception($"Heading is not as expected");

                return true;
            });
        }

        public BrowserCommandResult<bool> VerifyPopulatedFieldValue(string FieldName, string FieldValue)
        {
            return _webClient.Execute(BaseExtensions.GetOptionsInternal($"I Verify if {FieldName} has {FieldValue} value "), driver =>
            {


                var field = driver.FindElement(By.XPath($".//span[contains(@id,'{FieldName}') and contains(@class, 'plaintext')]"));

                bool FieldExists = field.Displayed;
                if (FieldExists == true)
                {
                    var value = field.Text;

                    Console.WriteLine("The actual value is " + value);
                    if (FieldValue.Equals(value, StringComparison.OrdinalIgnoreCase))
                    {
                        Console.WriteLine("Strings are equal");
                    }
                    else
                        throw new Exception($"Field value is not as expected");

                }
                else
                    throw new Exception($"Field with name {FieldName} does not exists");

                return true;
            });
        }
        public BrowserCommandResult<bool> ClickActionButton(string ButtonName)
        {
            return _webClient.Execute(BaseExtensions.GetOptionsInternal($"I Click {ButtonName} action button in the page"), driver =>
            {
                Console.WriteLine("Button Name: "+ ButtonName);
                if (ButtonName.Equals("Create/Edit Query") || ButtonName.Equals("Use Existing View") || ButtonName.Equals("Use Query"))
                {
                    var button = driver.FindElement(By.XPath($".//button[text() = '{ButtonName}']"));
                    Console.WriteLine("button name inside if loop: " + button.Text);
                    button.Click();
                    _webClient.Browser.ThinkTime(4000);
                    return true;
                }
              
                var SubmitContainer = driver.FindElement(By.XPath($"//div[contains(@id,'submitbutton_container')]"));
               

                var buttonToClick = SubmitContainer.FindElement(By.XPath($".//button[text() = '{ButtonName}']"));

                bool ButtonExists = buttonToClick.Displayed;
                if (ButtonExists == true)
                {
                    buttonToClick.Click();
                    driver.WaitForPageToLoad();
                }
                else
                    throw new Exception($"Button with name {ButtonName} does not exists");



                return true;
            });
        }

        public BrowserCommandResult<bool> SubListviewButton(string ButtonName)
        {
            return _webClient.Execute(BaseExtensions.GetOptionsInternal($"I click {ButtonName}"), driver =>
            {
                driver.WaitForPageToLoad();
                var SubListContainer = driver.WaitUntilAvailable(By.XPath("//div[contains(@data-tpc-role,'sub-listView-toolbar')]//a"), "Not Found");

                var ButtontoClick = SubListContainer.FindElement(By.XPath($"//span[contains(text(), '{ButtonName}')]"));
                //  ((IJavaScriptExecutor)driver).ExecuteScrip‌t("arguments[0].style.backgroundColor = 'blue'", ButtontoClick);

                if (ButtontoClick != null)
                {
                    Console.WriteLine("Button Found");
                    ((IJavaScriptExecutor)driver).ExecuteScrip‌t("arguments[0].click();", ButtontoClick);

                    driver.WaitForPageToLoad();
                }
                else
                    throw new Exception($"Button with name {ButtonName} does not exists");

                return true;
            });
        }


        //Enter all field details
        //var RegisterUser = driver.FindElement(By.LinkText("Register now"));
        //RegisterUser.Click();
        //        driver.WaitForPageToLoad();


        //var FirstName = driver.FindElement(By.XPath(".//input[contains(@id,'_FirstName')]"));
        //FirstName.SendKeys("Mansa");

        //        var LastName = driver.FindElement(By.XPath(".//input[contains(@id,'_LastName')]"));
        //LastName.SendKeys("Bajaj");

        //        var Email = driver.FindElement(By.XPath(".//input[contains(@id,'Email')]"));
        //Email.SendKeys("mansabajaj@gmail.com");

        //        var Password = driver.FindElement(By.XPath(".//input[contains(@id,'Password')]"));
        //Password.SendKeys("1234567");

        //        var RepeatPassword = driver.FindElement(By.XPath(".//input[contains(@id,'ReTypePassword')]"));
        //RepeatPassword.SendKeys("1234567");

        //        var Register = driver.FindElement(By.XPath(".//button[contains(text(),'Register')]"));
        //Register.Submit();

        public BrowserCommandResult<bool> ClickSetButton()
        {
            return _webClient.Execute(BaseExtensions.GetOptionsInternal($"I Click set button in the form"), driver =>
            {

                var set = driver.FindElement(By.XPath($"//button[@aria-label='Set']']"));
                set.Click();
                return true;
            });
        }
    }
}