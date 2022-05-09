using AutoIt;
using Cmc.Engage.UIAutomation.Framework.XPath;
using Microsoft.Dynamics365.UIAutomation.Api.UCI;
using Microsoft.Dynamics365.UIAutomation.Browser;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.Events;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using Cmc.Engage.UIAutomation.Framework;
using WindowsInput;
using WindowsInput.Native;
using System.IO;
using Cmc.Engage.UIAutomation.Framework.Extensions;
namespace Cmc.Engage.UIAutomation.Framework.ApiExtensions
{
    public class CmcEntity : Entity
    {
        private readonly WebClient _webClient;

        public CmcEntity(WebClient client) : base(client)
        {
            _webClient = client;
        }

        public void SetValueWithThinkTime(string field, string value, int thinkTime)
        {
            SetValue(field, "");
            _webClient.Browser.ThinkTime(thinkTime);
            SetValue(field, value);

        }

        public BrowserCommandResult<bool> SetLookupSearcBox(LookupItem control, int index = 0, bool SetValue = true)
        {
            return _webClient.Execute(BaseExtensions.GetOptionsInternal($"Set Lookup Value: {control.Name}"), driver =>
            {

                if (driver.HasElement(By.XPath($"//div[contains(@id,'{control.Name}')]")))
                {

                    var fieldContainer = driver.FindElement(By.XPath($"//div[contains(@id,'{control.Name}')]"));

                    Console.WriteLine("fieldContainer found");

                    var input = fieldContainer.FindElements(By.TagName("input")).Count > 0
                         ? fieldContainer.FindElement(By.TagName("input"))
                         : null;
                    Console.WriteLine("input tags found");
                    if (input != null)
                    {
                        //input.SendKeys(Keys.Control + "a");
                        //input.SendKeys(Keys.Backspace);
                        input.SendKeys(control.Value, true);
                        _webClient.Browser.ThinkTime(7000);
                        //  driver.WaitForTransaction();

                    }
                }
                else
                    throw new NotFoundException("field not found");

                if (SetValue)
                {
                    if (control.Value != null && control.Value != "")
                    {
                        SetDialogByValue(driver, control, index);
                        Console.WriteLine("SetLookupByValue");
                    }
                    else if (control.Value == "")
                    {
                        SetLookupByIndex(driver, control, index);
                        Console.WriteLine("SetLookupByIndex");
                    }
                    else if (control.Value == null) throw new InvalidOperationException($"No value has been provided for the LookupItem {control.Name}. Please provide a value or an empty string and try again.");
                }
                else
                {
                    SetValueBySelection(driver, control);
                    Console.WriteLine("SetValueBySelection");
                }

                return true;
            });
        }

        private void SetValueBySelection(IWebDriver driver, LookupItem control)
        {

            var searchResults = driver.FindElement(By.XPath("//div[contains(@class, 'ms-ChoiceField-wrapper')]//label"));
            Console.WriteLine("searchResults found");

            var searchItems = searchResults.FindElements(By.XPath(".//span[@class='titleText']"));

            Console.WriteLine(searchItems.Count);
            //   Console.WriteLine(searchItems.GetAttribute("aria-label"));
            //if (searchItems.GetAttribute("aria-label").Contains(control.Value))

            //{
            //    searchItems.Click();
            //}
            Console.WriteLine(searchItems.FirstOrDefault().Text);

            if (searchItems.Any(x => x.Text.Equals(control.Value, StringComparison.OrdinalIgnoreCase)))
            {
                var item = searchItems.FirstOrDefault(x => x.Text.Equals(control.Value, StringComparison.OrdinalIgnoreCase));
                driver.WaitForTransaction();
                item.Click();

                System.Console.WriteLine(item.Text);

            }
            else
                throw new Exception($"Field with name {control.Value} does not exist.");

            //if (searchItems.Any(x => x.GetAttribute("aria-label").Contains(control.Value, StringComparison.OrdinalIgnoreCase)))
            //{
            //    var item = searchItems.FirstOrDefault(x => x.GetAttribute("aria-label").Contains(control.Value, StringComparison.OrdinalIgnoreCase));
            // driver.WaitForTransaction();
            //    item.Click();

            //    System.Console.WriteLine(item.GetAttribute("aria-label"));

            //}
            //else
            //   throw new Exception($"Field with name {control.Value} does not exist.");


        }

        public BrowserCommandResult<bool> SetFieldsInDialog(string FieldValue, string FieldName, string sectionName)
        {
            return _webClient.Execute(BaseExtensions.GetOptionsInternal($"Set kendo field Value: {sectionName}"), driver =>
            {
                IWebElement optionToSelect;

                if (driver.HasElement(By.XPath($"//div[contains(@class,'{sectionName}')]")))
                {
                    //var fieldContainer = driver.FindElement(By.XPath($"//div[contains(@class,'{sectionName}')]"));
                    var fieldContainer = driver.WaitUntilAvailable(By.XPath($"//div[contains(@class,'{sectionName}')]"), "Dialog not found");
                    Console.WriteLine("fieldContainer found");
                    var input = fieldContainer.FindElements(By.TagName("input"));
                    Console.WriteLine("input tags found");

                    bool ByID = input.Any(x => x.GetAttribute("id").StartsWith(FieldName, StringComparison.OrdinalIgnoreCase));
                    bool ByClass = input.Any(x => x.GetAttribute("class").StartsWith(FieldName, StringComparison.OrdinalIgnoreCase));
                    if (ByID == true)
                    {
                        Console.WriteLine("inside the loop");
                        optionToSelect = input.FirstOrDefault(x => x.GetAttribute("id").StartsWith(FieldName, StringComparison.OrdinalIgnoreCase));
                        driver.WaitForTransaction();
                        ((IJavaScriptExecutor)driver).ExecuteScrip‌t("arguments[0].click();", optionToSelect);
                        _webClient.Browser.ThinkTime(2000);

                        try
                        {
                            optionToSelect.SendKeys(FieldValue);
                            //optionToSelect.SendKeys(Keys.Enter);
                            optionToSelect.Click();
                            _webClient.Browser.ThinkTime(2000);
                        }
                        catch (Exception ex)
                        {
                            if (ex.Message.StartsWith("OpenQA.Selenium.ElementNotInteractableException: element not interactable"))
                                Console.WriteLine("passing on to scroller");
                        }
                    }
                    else if (ByClass == true)
                    {
                        optionToSelect = input.FirstOrDefault(x => x.GetAttribute("class").StartsWith(FieldName, StringComparison.OrdinalIgnoreCase));
                        ((IJavaScriptExecutor)driver).ExecuteScrip‌t("arguments[0].click();", optionToSelect);
                        try
                        {
                            optionToSelect.SendKeys(FieldValue);
                            optionToSelect.Click();
                            _webClient.Browser.ThinkTime(2000);
                        }
                        catch (Exception ex)
                        {
                            if (ex.Message.StartsWith("OpenQA.Selenium.ElementNotInteractableException: element not interactable"))
                                Console.WriteLine("passing on to scroller");
                        }

                    }
                    else
                        throw new Exception($"value with name {FieldValue} does not exist.");

                    // driver.WaitForTransaction();

                    _webClient.Browser.ThinkTime(2000);
                    var scroller = driver.WaitUntilAvailable(By.ClassName("k-list-scroller"), "scroller not found");

                    Console.WriteLine("scroller found");

                    var listItems = scroller.FindElements(By.XPath(".//li"));
                    Console.WriteLine("lis elements  found");
                    _webClient.Browser.ThinkTime(2000);

                    if (listItems.Any(x => x.Text.StartsWith(FieldValue, StringComparison.OrdinalIgnoreCase)))
                    {
                        Console.WriteLine("inside the loop");
                        optionToSelect = listItems.FirstOrDefault(x => x.Text.StartsWith(FieldValue, StringComparison.OrdinalIgnoreCase));
                        driver.WaitForTransaction();
                        // optionToSelect.Click();
                        ((IJavaScriptExecutor)driver).ExecuteScrip‌t("arguments[0].click();", optionToSelect);
                        System.Console.WriteLine(optionToSelect.Text);

                    }
                    else
                        throw new Exception($"value with name {FieldValue} does not exist.");
                }

                else
                    throw new NotFoundException($"field  {FieldName} not found in dialog");


                return true;
            });
        }

        public BrowserCommandResult<bool> LookupDialogAction(bool clickButton)
        {
            //Passing true clicks the confirm button.  Passing false clicks the Cancel button.
            return _webClient.Execute(BaseExtensions.GetOptionsInternal("Confirm or Cancel Confirmation Dialog"), driver =>
            {
                var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
                wait.Until(d => d.FindElement(By.XPath(CmcAppElements.Xpath[CmcAppReference.Entity.LookupFooterContainer])));
                Console.WriteLine("LookupFooterContainer found");

                //Wait until the buttons are available to click
                var lookupFooter = driver.WaitUntilAvailable(By.XPath(CmcAppElements.Xpath[CmcAppReference.Entity.LookupAdd]));

                if (
                    !(lookupFooter?.FindElements(By.XPath(CmcAppElements.Xpath[CmcAppReference.Entity.LookupAdd])).Count >
                      0)) return true;
                System.Console.WriteLine("lookupFooter found");
                //Click the Add or Cancel button
                IWebElement buttonToClick;

                if (clickButton)
                    buttonToClick = lookupFooter;
                // .FindElement(By.XPath(AppElements.Xpath[CmcAppReference.Entity.LookupAdd]));
                else
                    buttonToClick = lookupFooter.FindElement(By.XPath(CmcAppElements.Xpath[CmcAppReference.Entity.LookupCancel]));


                if (buttonToClick.Displayed && buttonToClick.Enabled)
                {
                    // buttonToClick.Click();
                    ((IJavaScriptExecutor)driver).ExecuteScrip‌t("arguments[0].click();", buttonToClick);
                    //  driver.WaitForTransaction();
                    _webClient.Browser.ThinkTime(2000);
                    Console.WriteLine("button displayed");
                }
                else
                {
                    throw new ElementNotSelectableException("Button is not clickable");
                }


                return true;
            });
        }

        private void SetDialogByValueEx(IWebDriver driver, LookupItem control, int index)
        {
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(30));
            wait.Until(d => d.FindElement(By.XPath(CmcAppElements.Xpath[CmcAppReference.Entity.LookupDialogResultContainer])));

            var lookupResultContainer = driver.FindElement(By.XPath(CmcAppElements.Xpath[CmcAppReference.Entity.LookupDialogResultContainer]));
            _webClient.Browser.ThinkTime(2000);


            //  driver.WaitForTransaction();

            var lookupResultsItems = lookupResultContainer.FindElements(By.XPath(CmcAppElements.Xpath[CmcAppReference.Entity.LookupDialogResultListItem].Replace("[NAME]", control.Name)));

            if (lookupResultsItems == null)
                throw new NotFoundException($"No Results Matching {control.Value} Were Found.");

            _webClient.Browser.ThinkTime(2000);
            //   driver.WaitForTransaction();
            if (lookupResultsItems.Count == 0)
                throw new InvalidOperationException($"List does not contain a record with the name:  {control.Value}");

            if (index + 1 > lookupResultsItems.Count)
                throw new InvalidOperationException($"List does not contain {index + 1} records. Please provide an index value less than {lookupResultsItems.Count} ");

            var dialogItem = lookupResultsItems[index];

            // dialogItem.Click();

            ((IJavaScriptExecutor)driver).ExecuteScrip‌t("arguments[0].click();", dialogItem);
            //   driver.WaitForTransaction();
            _webClient.Browser.ThinkTime(2000);

        }

        private void SetLookupByIndex(IWebDriver driver, LookupItem control, int index)
        {

            //driver.WaitUntilVisible(By.XPath(CmcAppElements.Xpath[CmcAppReference.Entity.LookupResultsDropdown].Replace("[NAME]", control.Name)));
            //var lookupResultsDialog = driver.WaitUntilAvailable(By.XPath(CmcAppElements.Xpath[CmcAppReference.Entity.LookupResultsDropdown].Replace("[NAME]", control.Name)));

            //driver.WaitForTransaction();
            //driver.Wait(d => d.FindElements(By.XPath(AppElements.Xpath[CmcAppReference.Entity.LookupFieldResultListItem].Replace("[NAME]", control.Name))).Count > 0);
            //var lookupResults = TestSettings.CurrentPersonaDto.XrmApp.WebClient.LookupResultsDropdown(lookupResultsDialog).Value;

            //driver.WaitForTransaction();
            //if (lookupResults.Count == 0)
            //    throw new InvalidOperationException($"No results exist in the Recently Viewed flyout menu. Please provide a text value for {control.Name}");

            //if (index + 1 > lookupResults.Count)
            //    throw new InvalidOperationException($"Recently Viewed list does not contain {index + 1} records. Please provide an index value less than {lookupResults.Count}");

            //var lookupResult = lookupResults[index];
            //driver.ClickWhenAvailable(By.Id(lookupResult.Id));

            //driver.WaitForTransaction();
        }



        public BrowserCommandResult<bool> LookupRelatedEntityEx(string lookupname, string entityName)
        {
            //Click the Related Entity on the Lookup Flyout
            return TestSettings.CurrentPersonaDto.XrmApp.WebClient.Execute(BaseExtensions.GetOptionsInternal($"Select Lookup {lookupname} Related Entity {entityName}"), driver =>
            {
                IWebElement EntityPopup;
                if (driver.HasElement(By.XPath(CmcAppElements.Xpath[CmcAppReference.Entity.RelatedEntityPopup].Replace("[NAME]", lookupname))))
                {
                    EntityPopup = driver.FindElement(By.XPath(CmcAppElements.Xpath[CmcAppReference.Entity.RelatedEntityPopup].Replace("[NAME]", lookupname)));
                    // System.Console.WriteLine("EntityPopup found");
                }

                else
                    throw new NotFoundException($"Lookup Entity {entityName} not found");

                List<IWebElement> results = EntityPopup.FindElements(By.TagName("li")).ToList();
                if (results.Count > 0)
                {
                    var result = driver.FindElement(By.XPath($"//div[@title = \"{entityName}\"]"));
                    if (result.Text == entityName)
                    {
                        System.Console.WriteLine("result yet to be clicked");
                        result.Click(true);

                    }
                    System.Console.WriteLine("result clicked ");
                    //    driver.WaitForTransaction();
                    _webClient.Browser.ThinkTime(2000);
                }




                else
                    throw new NotFoundException("No rows found");
                return true;
            });
        }

        public BrowserCommandResult<bool> SearchLookupField(LookupItem control, string searchCriteria)
        {
            return TestSettings.CurrentPersonaDto.XrmApp.WebClient.Execute(BaseExtensions.GetOptionsInternal($"Search Lookup {control} Record"), driver =>
            {
                //Click in the field and enter values
                control.Value = searchCriteria;
                TestSettings.CurrentPersonaDto.XrmApp.Entity.SetValue(control);
                driver.WaitForTransaction();

                return true;
            });
        }
        public BrowserCommandResult<bool> VerifyConnection(string ListName, string ListItem)
        {
            //Click the Related Entity on the Lookup Flyout
            return TestSettings.CurrentPersonaDto.XrmApp.WebClient.Execute(BaseExtensions.GetOptionsInternal($"verify list  {ListName} has {ListItem} present"), driver =>
            {
                IWebElement GridList;
                if (driver.HasElement(By.XPath(CmcAppElements.Xpath[CmcAppReference.Entity.GridListContainer].Replace("[NAME]", ListName))))
                {
                    GridList = driver.FindElement(By.XPath(CmcAppElements.Xpath[CmcAppReference.Entity.GridListContainer].Replace("[NAME]", ListName)));
                    // System.Console.WriteLine("EntityPopup found");
                }//GridListItem

                else
                    throw new NotFoundException($"GridList {ListName} not found");

                List<IWebElement> results = GridList.FindElements(By.TagName("li")).ToList();
                if (results.Count > 0)
                {
                    var result = driver.FindElement(By.XPath(CmcAppElements.Xpath[CmcAppReference.Entity.GridListContainer].Replace("[NAME]", ListItem)));
                    int Flag = 0;
                    if (result != null)
                    {
                        //  System.Console.WriteLine("result yet to be clicked");
                        result.Click(true);
                        Flag = 1;
                    }

                    Assert.IsTrue(Flag == 1, "Connection is present");
                    //  System.Console.WriteLine("result clicked ");
                    //    driver.WaitForTransaction();
                    _webClient.Browser.ThinkTime(2000);

                }
                else
                    throw new NotFoundException("No item found");
                return true;
            });
        }

        public BrowserCommandResult<bool> ClickFieldToUpdate(string field, string input)
        {
            return TestSettings.CurrentPersonaDto.XrmApp.WebClient.Execute(BaseExtensions.GetOptionsInternal($"Click Field {field} and navigate"), driver =>
            {
                var clickablefield = driver.WaitUntilAvailable(By.XPath(CmcAppElements.Xpath[CmcAppReference.Entity.ClickableField].Replace("[NAME]", field)));

                if (clickablefield.FindElements(By.TagName("label")).Count > 0)
                {
                    var label = clickablefield.FindElement(By.TagName("label"));
                    if (label.Text != input)
                    {
                        label.Click();
                    }

                }
                else
                    throw new Exception($"Field with name {field} does not exist.");


                return true;

            });
        }

        public BrowserCommandResult<bool> ClickLockedLookupField(string fieldName, string sectionLabel)
        {
            return TestSettings.CurrentPersonaDto.XrmApp.WebClient.Execute(BaseExtensions.GetOptionsInternal($"Click locked Field {fieldName} and navigatgate"), driver =>
            {
                var sectionContainer = driver.WaitUntilAvailable(By.XPath(CmcAppElements.Xpath[CmcAppReference.Entity.sectionContainer].Replace("[NAME]", sectionLabel)), "Section Container Not Found");
                _webClient.Browser.ThinkTime(2000);

                if (sectionContainer.HasElement(By.XPath($".//ul[contains(@id,'{fieldName}')]")))
                {
                    var div = sectionContainer.FindElement(By.XPath($".//ul[contains(@id,'{fieldName}')]"));

                    var label = div.FindElements(By.TagName("li"));

                    if (label != null)
                    {
                        label.FirstOrDefault().Click();
                        System.Console.WriteLine("clicked");
                        _webClient.Browser.ThinkTime(3000);
                        //driver.WaitForTransaction();
                        //driver.WaitForPageToLoad();
                    }
                    else
                        throw new Exception($"Field with name {fieldName} does not exist.");
                }
                else
                    throw new Exception($"No lookup value is selcted in the field");

                return true;
            });
        }
        public BrowserCommandResult<bool> VerifyFieldsInSectionAreLocked(string sectionLabel, Field FormField = null)
        {
            return TestSettings.CurrentPersonaDto.XrmApp.WebClient.Execute(BaseExtensions.GetOptionsInternal($"Verify if field {FormField} is present in the section as read-only"), driver =>
            {
                var sectionContainer = driver.FindElement(By.XPath(CmcAppElements.Xpath[CmcAppReference.Entity.sectionContainer].Replace("[NAME]", sectionLabel)));
                if (driver.HasElement((By.XPath(CmcAppElements.Xpath[CmcAppReference.Entity.sectionContainer].Replace("[NAME]", sectionLabel)))))
                {
                    var divContainer = sectionContainer.FindElements(By.XPath(CmcAppElements.Xpath[CmcAppReference.Entity.divLockedFieldContainer]));

                    if (divContainer.Any(x => x.GetAttribute("aria-label").Contains(FormField.Name, StringComparison.OrdinalIgnoreCase)))
                    {
                        String FieldText = divContainer.FirstOrDefault(x => x.GetAttribute("aria-label").Contains(FormField.Name, StringComparison.OrdinalIgnoreCase)).Text;
                        //     driver.WaitForTransaction();
                        _webClient.Browser.ThinkTime(2000);
                        System.Console.WriteLine("FieldText is found " + FieldText);
                    }

                    else
                        throw new Exception($"Field with name {FormField.Name} is not locked");
                }
                else
                    throw new Exception($"Section with name {sectionLabel} is not found");

                return true;

            });
        }
        public BrowserCommandResult<bool> VerifyFieldIsPresentInSection(string sectionLabel, Field FormField = null)
        {
            return TestSettings.CurrentPersonaDto.XrmApp.WebClient.Execute(BaseExtensions.GetOptionsInternal($"Verify if field {FormField} is present in the section"), driver =>
            {


                var sectionContainer = driver.FindElement(By.XPath(CmcAppElements.Xpath[CmcAppReference.Entity.sectionContainer].Replace("[NAME]", sectionLabel)));

                if (driver.HasElement(By.XPath(CmcAppElements.Xpath[CmcAppReference.Entity.sectionContainer].Replace("[NAME]", sectionLabel))))
                {

                    var Label = sectionContainer.FindElements(By.XPath(CmcAppElements.Xpath[CmcAppReference.Entity.fieldLabel]));

                    if (Label.Any(x => x.Text.StartsWith(FormField.Name, StringComparison.OrdinalIgnoreCase)))
                    {
                        Label.FirstOrDefault(x => x.Text.StartsWith(FormField.Name, StringComparison.OrdinalIgnoreCase)).Click();
                        //  driver.WaitForTransaction();
                        _webClient.Browser.ThinkTime(2000);
                        System.Console.WriteLine(FormField.Name);

                    }
                    else
                        throw new Exception($"Field with name {FormField.Name} does not exist.");

                }
                else
                    throw new Exception($"Section with name {sectionLabel} is not found");

                return true;
            });
        }
        //wave2 fix
        public BrowserCommandResult<bool> BrowseAttachment(string File, string sectionLabel)
        {
            return TestSettings.CurrentPersonaDto.XrmApp.WebClient.Execute(BaseExtensions.GetOptionsInternal($" Upload {File} in the section {sectionLabel}"), driver =>
            {
                String localPath = @"TestFile\";
                string currentDir = Environment.CurrentDirectory;
                DirectoryInfo directory = new DirectoryInfo(Path.GetFullPath(Path.Combine(currentDir, @"..\..\" + localPath + File)));
                String path = directory.ToString();
                Console.WriteLine(path);

                var sectionContainer = driver.FindElementWithWait(By.XPath(CmcAppElements.Xpath[CmcAppReference.Entity.sectionContainer].Replace("[NAME]", sectionLabel)));

                if (driver.HasElement(By.XPath(CmcAppElements.Xpath[CmcAppReference.Entity.sectionContainer].Replace("[NAME]", sectionLabel))))
                {

                    var Icon = sectionContainer.FindElement(By.XPath(CmcAppElements.Xpath[CmcAppReference.Entity.AttachmentIcon]));
                    System.Console.WriteLine("Icon Found");
                    if (Icon.Displayed == true)
                    {
                        Icon.Click();
                        //   driver.WaitForTransaction();
                        _webClient.Browser.ThinkTime(2000);
                        System.Console.WriteLine("Icon Clicked");
                    }
                    else
                        throw new Exception($"Attachment Icon does not exist");


                    driver.FindElement(By.Id("filepickerid")).SendKeys(path);
                    _webClient.Browser.ThinkTime(2000);
                    Console.WriteLine("files");


                    AutoItX.WinClose("Open");
                    _webClient.Browser.ThinkTime(2000);

                    //driver.FindElement(By.CssSelector("#create_note_add_btn > span")).Click();
                    //driver.SwitchTo().Window(driver.WindowHandles.Last());
                    //var handle = driver.SwitchTo().Window("Open");
                    //var handle =  driver.SwitchTo().Window(driver.WindowHandles.Last());
                    //var handle = driver.SwitchTo().ActiveElement();

                    //Closing the file upload windows pop-up using keyboard action
                    //InputSimulator I = new InputSimulator();
                    //I.Keyboard.KeyPress(VirtualKeyCode.TAB);
                    //I.Keyboard.KeyPress(VirtualKeyCode.TAB);
                    //I.Keyboard.KeyPress(VirtualKeyCode.TAB);
                    //I.Keyboard.KeyDown(VirtualKeyCode.RETURN);
                    //driver.SwitchTo().ActiveElement();



                }
                else
                    throw new Exception($"Section with name {sectionLabel} is not found");

                return true;
            });
        }


        public BrowserCommandResult<bool> CreateNoteAction(bool ClickAddButton)
        {
            return TestSettings.CurrentPersonaDto.XrmApp.WebClient.Execute(BaseExtensions.GetOptionsInternal($" Click button in Note section"), driver =>
            {

                //    var EnterNote = driver.FindElement(By.XPath(".//button[contains(@id, 'create_module_placeholder')]"));
                //EnterNote.Click();

                var NoteContainer = driver.FindElementWithWait((By.XPath("//div[contains(@id, 'timeline_wall_container')]")));
                ((IJavaScriptExecutor)driver).ExecuteScrip‌t("arguments[0].style.backgroundColor = 'blue'", NoteContainer);
                //if (
                //  !(driver.FindElements(By.XPath(CmcAppElements.Xpath[CmcAppReference.Entity.NoteAddButton])).Count >
                //    0)) return true;
                //System.Console.WriteLine("Buttons present");

                //driver.SwitchTo().Frame(driver.FindElement(By.XPath(".//iframe[contains(@class,'cke_reset')]")));
                //Console.WriteLine("frame found");
                _webClient.Browser.ThinkTime(2000);
                IWebElement buttonToClick;
                if (ClickAddButton)
                {
                    Console.WriteLine("inside add loop");
                    buttonToClick = NoteContainer.FindElement(By.XPath(CmcAppElements.Xpath[CmcAppReference.Entity.NoteAddButton]));
                    buttonToClick = driver.FindElementWithWait(By.XPath(".//button[contains(@id,'notescontrol-undefinedsave_button')]"));
                    ((IJavaScriptExecutor)driver).ExecuteScrip‌t("arguments[0].style.backgroundColor = 'blue'", buttonToClick);
                    buttonToClick.Click();
                }
                else
                {
                    Console.WriteLine("inside cancel loop");
                    buttonToClick = NoteContainer.FindElement(By.XPath(CmcAppElements.Xpath[CmcAppReference.Entity.NoteCancelButton]));
                    buttonToClick.Click();
                }

                System.Console.WriteLine("Button clicked");
                _webClient.Browser.ThinkTime(3000);

                return true;

            });
        }

        public BrowserCommandResult<bool> CloseCurrentWindow()
        {
            return TestSettings.CurrentPersonaDto.XrmApp.WebClient.Execute(BaseExtensions.GetOptionsInternal($" Close current window"), driver =>
            {
                driver.SwitchTo().Window(driver.WindowHandles.Last());


                _webClient.Browser.ThinkTime(2000);

                driver.Close();
                return true;

            });

        }
        public BrowserCommandResult<bool> SwitchToSpecificWindow(string title)
        {
            return TestSettings.CurrentPersonaDto.XrmApp.WebClient.Execute(BaseExtensions.GetOptionsInternal($" switch to specific window {title}"), driver =>
            {
                //driver.SwitchTo().Window(driver.WindowHandles.Last()).Manage().Window.Maximize();
                _webClient.Browser.ThinkTime(10000);
                string ActualTitle = driver.SwitchTo().Window(driver.WindowHandles.Last()).Title;
                System.Console.WriteLine("ActualTitle is " + ActualTitle);
                if (title.StartsWith(ActualTitle, StringComparison.OrdinalIgnoreCase))
                {
                    Console.WriteLine("Window Found");
                    // var handle = driver.SwitchTo().Window(driver.WindowHandles.Last());
                    //handle.Manage().Window.Maximize();
                    _webClient.Browser.ThinkTime(2000);
                    driver.WaitForPageToLoad();
                }
                else
                    throw new Exception($"Window wtih Name {title} is not found");

                return true;

            });
        }
        public BrowserCommandResult<bool> SetKendoTextFieldInDialog(string FieldValue, string FieldID)
        {
            return TestSettings.CurrentPersonaDto.XrmApp.WebClient.Execute(BaseExtensions.GetOptionsInternal($"Set value as {FieldValue} to Kendo text field {FieldID}"), driver =>
            {

                IWebElement inputField;

                if (driver.HasElement(By.Id(FieldID)))
                {
                    inputField = driver.FindElement(By.Id(FieldID));
                    inputField.SendKeys(FieldValue);

                    System.Console.WriteLine("Field searched by ID");

                    if (driver.HasElement(By.ClassName("k-input")))
                    {

                        var inputContainer = inputField.FindElements(By.ClassName("k-input"));
                        if (inputContainer.Any(x => x.GetAttribute("id").Equals(FieldID, StringComparison.OrdinalIgnoreCase)))
                        {
                            var input = inputContainer.FirstOrDefault(x => x.GetAttribute("id").Equals(FieldID, StringComparison.OrdinalIgnoreCase));
                            input.SendKeys(FieldValue);
                            _webClient.Browser.ThinkTime(2000);
                            System.Console.WriteLine("Field searched by classname");

                        }
                    }

                }

                else
                    throw new NotFoundException($"Field not found");


                _webClient.Browser.ThinkTime(2000);
                driver.WaitUntilAvailable(By.ClassName("k-item"));

                if (driver.HasElement(By.ClassName("k-item")))
                {
                    var searchResults = driver.FindElements(By.ClassName("k-item"));
                    if (searchResults.Any(x => x.Text.Equals(FieldValue, StringComparison.OrdinalIgnoreCase)))
                    {
                        var item = searchResults.FirstOrDefault(x => x.Text.Equals(FieldValue, StringComparison.OrdinalIgnoreCase));

                        System.Console.WriteLine("Text is" + item.Text);

                        item.Click();
                        //     driver.WaitForTransaction();
                        _webClient.Browser.ThinkTime(2000);
                        System.Console.WriteLine("Item Clicked");

                    }

                }
                else
                    throw new NotFoundException($"search results not found");

                return true;

            });
        }
        public BrowserCommandResult<bool> SwitchToSpecificFrame(string frameName)
        {
            return TestSettings.CurrentPersonaDto.XrmApp.WebClient.Execute(BaseExtensions.GetOptionsInternal($"Switch to specific Frame {frameName}|"), driver =>
            {

                driver.SwitchTo().Frame(frameName);
                //((IJavaScriptExecutor)driver).ExecuteScrip‌t("arguments[0].style.backgroundColor = 'blue'", frame);

                return true;
            });
        }

        public BrowserCommandResult<bool> SwitchToDynamicFrame(string frameID)
        {
            return TestSettings.CurrentPersonaDto.XrmApp.WebClient.Execute(BaseExtensions.GetOptionsInternal($"Switch to specific Frame {frameID}"), driver =>
            {


                driver.SwitchTo().Frame(driver.FindElement(By.XPath($"//iframe[contains(@id,'{frameID}')]")));
                return true;
            });
        }

        public BrowserCommandResult<bool> SwitchToDefaultFrame()
        {
            return TestSettings.CurrentPersonaDto.XrmApp.WebClient.Execute(BaseExtensions.GetOptionsInternal($"Switch to default Frame"), driver =>
            {
                driver.SwitchTo().DefaultContent();
                string title = driver.SwitchTo().DefaultContent().Title;
                System.Console.WriteLine("Title of frame  is " + title);

                return true;
            });
        }
        public BrowserCommandResult<bool> ClickActionButtoninWIndow(string ButtonLabel)
        {
            return TestSettings.CurrentPersonaDto.XrmApp.WebClient.Execute(BaseExtensions.GetOptionsInternal($" Click button {ButtonLabel}in Window"), driver =>
            {
                var divContainer = driver.WaitUntilAvailable(By.XPath("//div[contains(@class,'button-container')]"), "button container not forund");

                Console.WriteLine("div found");

                var buttonToClick = divContainer.FindElement(By.XPath(CmcAppElements.Xpath[CmcAppReference.Entity.WindowActionButton].Replace("[NAME]", ButtonLabel)));
                Console.WriteLine("button found");

                if (buttonToClick.Displayed && buttonToClick.Enabled)
                {
                    buttonToClick.Click();
                    // ((IJavaScriptExecutor)driver).ExecuteScrip‌t("arguments[0].click();", buttonToClick);
                    //    driver.WaitForTransaction();
                    _webClient.Browser.ThinkTime(2000);
                    Console.WriteLine("Click Button");
                }
                else
                    throw new Exception($"Button{ButtonLabel}not found");
                return true;

            });
        }

        public BrowserCommandResult<bool> SwitchToCurrentWindow()
        {
            return TestSettings.CurrentPersonaDto.XrmApp.WebClient.Execute(BaseExtensions.GetOptionsInternal($"Switch to current window"), driver =>
            {
                var handle = driver.SwitchTo().Window(driver.CurrentWindowHandle);

                return true;


            });
        }

        //public BrowserCommandResult<bool> SwitchBackToMainWindow( )
        //{
        //    return TestSettings.CurrentPersonaDto.XrmApp.WebClient.Execute(BaseExtensions.GetOptionsInternal($"Switch to current window"), driver =>
        //    {
        //        var handle = driver.SwitchTo().Window();

        //        return true;


        //    });
        //}

        public BrowserCommandResult<bool> Screenshot(string featureName, string scenarioName)
        {
            return TestSettings.CurrentPersonaDto.XrmApp.WebClient.Execute(BaseExtensions.GetOptionsInternal($"I capture screenshot"), driver =>
            {
                try
                {
                    //Take the screenshot
                    Screenshot image = ((ITakesScreenshot)driver).GetScreenshot();
                    //Save the screenshot
                    image.SaveAsFile($"../../ScreenShots/Screenshot-{featureName}-{scenarioName}" + System.DateTime.Now.ToString("yyyyMMddHHmmssFFF") + ".jpeg", ScreenshotImageFormat.Jpeg);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                    Assert.Fail("An error occured while capturing screenshot: " + e);
                }
                return true;
            });
        }

        public BrowserCommandResult<bool> SwitchToActiveElement()
        {
            return TestSettings.CurrentPersonaDto.XrmApp.WebClient.Execute(BaseExtensions.GetOptionsInternal($"Switch to Active ELement"), driver =>
            {
                driver.SwitchTo().ActiveElement();
                // ((IJavaScriptExecutor)driver).ExecuteScrip‌t("arguments[0].click();", ActiveElement);
                return true;
            });

        }

        public BrowserCommandResult<bool> ValidateNotification(string Message)
        {
            return TestSettings.CurrentPersonaDto.XrmApp.WebClient.Execute(BaseExtensions.GetOptionsInternal($"Verify {Message} is displayed"), driver =>
            {
                //IWebElement SingleNotificationWrapper;
                //IWebElement GroupNotificationWrapper;

                if (driver.HasElement(By.XPath(CmcAppElements.Xpath[CmcAppReference.Entity.SingleNotificationWrapper])))
                {
                    var SingleNotificationWrapper = driver.FindElement(By.XPath(CmcAppElements.Xpath[CmcAppReference.Entity.SingleNotificationWrapper]));
                    //  var SingleNotificationWrapper = driver.FindElement(By.XPath($"//div[contains(@id, 'notificationMessageAndButtons')]"));
                    Console.WriteLine("SingleNotificationWrapper");
                    var Meassages = driver.FindElements(By.XPath("//div[contains(@id, 'notificationMessageAndButtons')]"));
                    Console.WriteLine(Meassages.Count);
                    Console.WriteLine(" text: " + Meassages[0].Text);

                    var Msgformat1 = Meassages.FirstOrDefault(a => a.GetAttribute("title").StartsWith(Message, StringComparison.OrdinalIgnoreCase));
                    if (Msgformat1 != null)
                    {

                        Console.WriteLine("Notification 1 is present: "+ Msgformat1.Text);
                    }
                    var Msgformat2 = Meassages.FirstOrDefault(a => a.Text.StartsWith(Message, StringComparison.OrdinalIgnoreCase));
                    if(Msgformat2 != null)
                    {
                        Console.WriteLine("Notification 1 is present: "+ Msgformat2.Text);
                    }
                    else
                        throw new NotFoundException($"Notification is not present for field");
                }

                else if (driver.HasElement(By.XPath(CmcAppElements.Xpath[CmcAppReference.Entity.GroupNotificationWrapper])))
                {
                    var GroupNotificationWrapper = driver.FindElement(By.XPath(CmcAppElements.Xpath[CmcAppReference.Entity.GroupNotificationWrapper]));
                    Console.WriteLine("GroupNotificationWrapper" + GroupNotificationWrapper.Text);
                    GroupNotificationWrapper.SendKeys(Keys.Enter);

                    driver.WaitUntilVisible(By.XPath(CmcAppElements.Xpath[CmcAppReference.Entity.NotificationFlyout]));
                    //Console.WriteLine("NotificationFlyout");
                    var flyout = driver.FindElement(By.XPath(CmcAppElements.Xpath[CmcAppReference.Entity.NotificationFlyout]));

                    Console.WriteLine("flyout " + flyout.Text);
                    var Meassages = flyout.FindElements(By.XPath("//div[contains(@id, 'notificationMessageAndButtons')]"));
                    //var Meassages = flyout.FindElements(By.XPath("//div[contains(@id, 'notificationWrapper3')].//span]"));
                    Console.WriteLine(Meassages.Count);

                    Console.WriteLine(Meassages[1].Text + " text");

                    if (GroupNotificationWrapper.Text.Contains(Message, StringComparison.OrdinalIgnoreCase))
                    {
                        Console.WriteLine("Given text is available in wrapper text >" + GroupNotificationWrapper.Text);
                    }

                    else if (Meassages.Any(a => a.Text.Contains(Message, StringComparison.OrdinalIgnoreCase)))
                    {
                        Console.WriteLine("found by text");
                        var Msg = Meassages.FirstOrDefault(a => a.Text.Contains(Message, StringComparison.OrdinalIgnoreCase));
                        // driver.WaitForTransaction();
                        _webClient.Browser.ThinkTime(2000);
                        Console.WriteLine(Msg.Text);
                    }

                    else if (Meassages.Any(a => a.GetAttribute("aria-label").StartsWith(Message, StringComparison.OrdinalIgnoreCase)))
                    {
                        Console.WriteLine("found by aria - label");
                        var Msg = Meassages.FirstOrDefault(a => a.GetAttribute("aria-label").StartsWith(Message, StringComparison.OrdinalIgnoreCase));
                        // driver.WaitForTransaction();
                        _webClient.Browser.ThinkTime(2000);
                        Console.WriteLine(Msg.Text);
                    }

                    else
                        throw new NotFoundException($"Group Notification is not present for field");
                }
                else
                    throw new NotFoundException("Unable to find Notification Wrapper in the form");

                return true;
            });
        }
        public new BrowserCommandResult<bool> SetValue(MultiValueOptionSet option, bool removeExistingValues = false)
        {
            return TestSettings.CurrentPersonaDto.XrmApp.WebClient.Execute(BaseExtensions.GetOptionsInternal($"set value of {option.Name} multivalue optionset "), driver =>
            {
                driver.WaitUntilVisible(By.Id(option.Name));
                // IWebElement parentElement = driver.FindElement(By.Id(option.Name));
                //Console.WriteLine("Size is "+parentElement.Size);
                // int elementPosition = parentElement.Location.Y;
                // int Width = parentElement.Size.Width;
                // int Height = parentElement.Size.Height;
                // int MyX = (Width * 95) / 100;//spot to click is at 95% of the width
                // int MyY = 1;//anywhere above Height/2 works
                // Actions Actions = new Actions(driver);

                // Actions.MoveToElement(parentElement, MyX, MyY);
                // Actions.ClickAndHold();
                // Actions.Release();
                // Actions.Perform();


                // Actions actions = new Actions(driver);

                //string jse = string.Format("window.scroll(0,2000)", elementPosition);
                //IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
                //          //js.ExecuteScript(jse);
                //          actions.MoveToElement(parentElement)
                //.MoveByOffset(parentElement.Location.X, elementPosition).Build().Perform();
                //          _webClient.Browser.ThinkTime(2000);

                if (driver.HasElement(By.Id(option.Name)))
                {
                    var container = driver.ClickWhenAvailable(By.Id(option.Name));
                    if (removeExistingValues)
                    {
                        //Remove Existing Values
                        var values = container.FindElements(By.ClassName(CmcAppElements.CssClass[CmcAppReference.SetValue.MultiSelectPicklistDeleteClass]));
                        foreach (var value in values)
                            value.Click(true);

                    }

                    var input = container.FindElement(By.TagName("input"));
                    // var arrowButton = container.FindElement(By.XPath("div[@class ='msos-caret-container']"));

                    input.Click();
                    input.SendKeys(" ");

                    var options = container.FindElements(By.XPath(".//li/label"));

                    Console.WriteLine(options.Count);
                    foreach (var op in options)
                    {
                        if (option.Values.Contains(op.GetAttribute("title")) || option.Values.Contains(op.GetAttribute("value")) || option.Values.Contains(op.GetAttribute("title")))
                            op.Click(true);
                    }

                    input.Click();
                    input.Clear();

                    var arrowButton = container.FindElement(By.XPath(".//button[@aria-label ='Toggle menu']"));

                    driver.ExecuteScrip‌t("arguments[0].style.backgroundColor = 'blue'", arrowButton);

                    Console.WriteLine("arrowButton found");
                    arrowButton.Click();
                    //     driver.WaitForTransaction();
                    _webClient.Browser.ThinkTime(2000);



                }
                else
                    throw new InvalidOperationException($"Field: {option.Name} Does not exist");

                return true;
            });

        }
        public BrowserCommandResult<bool> SetLookupDialogEx(LookupItem control, int index = 0)
        {
            return _webClient.Execute(BaseExtensions.GetOptionsInternal($"Set Lookup Value: {control.Name}"), driver =>
            {
                //     driver.WaitForTransaction();
                _webClient.Browser.ThinkTime(2000);

                if (driver.HasElement(By.XPath(CmcAppElements.Xpath[CmcAppReference.Entity.TextFieldLookupContainer].Replace("[NAME]", control.Name))))
                {
                    var fieldContainer = driver.FindElement(By.XPath(CmcAppElements.Xpath[CmcAppReference.Entity.TextFieldLookupContainer].Replace("[NAME]", control.Name)));

                    IWebElement input;
                    bool found = fieldContainer.TryFindElement(By.TagName("input"), out input);

                    if (!found)
                        throw new NoSuchElementException($"Field with name {control.Name} does not exist.");

                    if (input != null)
                    {
                        input.SendKeys(Keys.Control + "a");
                        input.SendKeys(Keys.Backspace);
                        input.SendKeys(control.Value, true);


                        //      driver.WaitForTransaction();
                        _webClient.Browser.ThinkTime(2000);

                    }
                }

                if (control.Value != null && control.Value != "")
                    SetDialogByValueEx(driver, control, index);
                else if (control.Value == "")
                    SetLookupByIndex(driver, control, index);
                else if (control.Value == null) throw new InvalidOperationException($"No value has been provided for the LookupItem {control.Name}. Please provide a value or an empty string and try again.");

                return true;
            });
        }


        private void SetDialogByValue(IWebDriver driver, LookupItem control, int index)
        {
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(20));
            wait.Until(d => d.FindElement(By.XPath(CmcAppElements.Xpath[CmcAppReference.Entity.LookupDialogResultContainer1])));

            var lookupResultContainer = driver.FindElement(By.XPath(CmcAppElements.Xpath[CmcAppReference.Entity.LookupDialogResultContainer1]));
            //driver.WaitForTransaction();
            _webClient.Browser.ThinkTime(2000);
            var lookupResultsItems = lookupResultContainer.FindElements(By.TagName("li"));

            if (lookupResultsItems == null)
                throw new NotFoundException($"No Results Matching {control.Value} Were Found.");
            _webClient.Browser.ThinkTime(2000);

            //   driver.WaitForTransaction();
            if (lookupResultsItems.Count == 0)
                throw new InvalidOperationException($"List does not contain a record with the name:  {control.Value}");

            if (index + 1 > lookupResultsItems.Count)
                throw new InvalidOperationException($"List does not contain {index + 1} records. Please provide an index value less than {lookupResultsItems.Count} ");


            var dialogItem = lookupResultsItems[index];

            // dialogItem.Click();
            ((IJavaScriptExecutor)driver).ExecuteScrip‌t("arguments[0].click();", dialogItem);
            System.Console.WriteLine("clicked");
            driver.WaitForTransaction();

        }
        public BrowserCommandResult<bool> SetKendoDateFieldInDialog(string FieldValue, string FieldID)
        {
            return TestSettings.CurrentPersonaDto.XrmApp.WebClient.Execute(BaseExtensions.GetOptionsInternal($" Click button in Note section"), driver =>
            {
                driver.WaitUntilAvailable(By.ClassName("k-select"), "Field Not Found");

                if (driver.HasElement(By.ClassName("k-select")))
                {
                    var inputContainer = driver.FindElements(By.ClassName("k-select"));
                    if (inputContainer.Any(x => x.GetAttribute("aria-controls").Equals(FieldID, StringComparison.OrdinalIgnoreCase)))
                    {
                        var input = inputContainer.FirstOrDefault(x => x.GetAttribute("aria-controls").Equals(FieldID, StringComparison.OrdinalIgnoreCase));
                        input.Click();
                        //     driver.WaitForTransaction();
                        _webClient.Browser.ThinkTime(2000);
                    }
                    else
                        throw new NotFoundException($"Calender Icon not found");
                    _webClient.Browser.ThinkTime(2000);

                    //button to move next in calendar
                    //  var nextLink = driver.FindElement(By.XPath($"//div[@id='{FieldID}']//div[@class='k-header']//a[contains(@class,'k-nav-next')]"));
                    // nextLink.Click();
                    // _webClient.Browser.ThinkTime(4000);
                    //button to click in center of calendar header
                    //var midLink = driver.FindElement(By.XPath($"//div[@id='{FieldID}']//div[@class='k-header']//a[contains(@class,'k-nav-fast')]"));

                    IWebElement dateTable = driver.FindElement(By.XPath("//table[@class='k-content']//tbody"));

                    IList<IWebElement> dateTableCells = dateTable.FindElements(By.XPath("//td/a[@class ='k-link']"));

                    if (dateTableCells.Any(x => x.Text.Equals(FieldValue, StringComparison.OrdinalIgnoreCase)))
                    {
                        var DateToClick = dateTableCells.FirstOrDefault(x => x.Text.Equals(FieldValue, StringComparison.OrdinalIgnoreCase));
                        DateToClick.Click();
                        //      driver.WaitForTransaction();
                        _webClient.Browser.ThinkTime(2000);
                        System.Console.WriteLine("date selected");
                        System.Console.WriteLine("date cells found with text " + DateToClick.Text);

                    }

                    else
                        throw new NotFoundException($"Date not available for selection");
                }
                return true;

            });

        }

        public new BrowserCommandResult<bool> ManageMembersAdd(string buttonName, string sectionLabel)
        {

            return TestSettings.CurrentPersonaDto.XrmApp.WebClient.Execute(BaseExtensions.GetOptionsInternal($"Click {buttonName} in {sectionLabel} section of manage members window"), driver =>
            {

                var div = driver.WaitUntilAvailable(By.XPath("//div[contains(@id,'dialogView')]"), "division not found");

                var sectionContainer = div.FindElement(By.XPath($"//section[contains(@data-id,'{sectionLabel}')]"));

                Console.WriteLine("sectionContainer found");

                var buttonToclick = sectionContainer.FindElement(By.XPath($".//button//span[contains(text(),'Add')]"));
                Console.WriteLine("buttonToclick found");

                buttonToclick.Click();

                var DivOptions = driver.WaitUntilAvailable(By.XPath($"//div[contains(@class,'ms-Callout-main')]"), "option div not found");

                Console.WriteLine("DivOptions found");

                var options = DivOptions.FindElements(By.XPath(".//ul[contains(@class, 'ms-ContextualMenu')]/li"));
                Console.WriteLine("options found");

                for (int i = 0; i <= options.Count; i++)
                {
                    var option = options[i].FindElement(By.XPath($".//span"));
                    Console.WriteLine("option found");
                    if (option.Text == buttonName)

                        option.Click();
                    Console.WriteLine(i);
                    Console.WriteLine("option clicked");

                }

                return true;
            });

        }
        public new BrowserCommandResult<bool> ManageMemberTextFields(string FieldName, string InputValue, int RowNo)
        {
            IWebElement ValueInputField;

            return TestSettings.CurrentPersonaDto.XrmApp.WebClient.Execute(BaseExtensions.GetOptionsInternal($"set {InputValue} & {FieldName} of manage members window"), driver =>
            {

                var div = driver.WaitUntilAvailable(By.XPath("//div[contains(@id,'dialogView')]"), "division not found");

                Console.WriteLine("div found");

                var groupDiv = div.FindElement(By.XPath($".//div[contains(@class,'GroupExpressionView-RootExpression')]"));
                Console.WriteLine("groupDiv found");

                var fieldRows = groupDiv.FindElements(By.XPath("//div[@class ='eb-TreeLineGutter']"));
                Console.WriteLine(RowNo - 1);
                if (fieldRows[RowNo - 1].HasElement(By.XPath($"//input[@value ='{FieldName}']")))
                {
                    //set input value field

                    ValueInputField = fieldRows[RowNo - 1].FindElement(By.XPath(".//div[@class ='DataTypeTemplate-Value']"));
                    Console.WriteLine("ValueInputField found");

                    var Input = ValueInputField.FindElement(By.XPath(".//input"));
                    Input.Click();
                    Input.Clear();
                    //   driver.WaitForTransaction();
                    _webClient.Browser.ThinkTime(2000);
                    Input.SendKeys(InputValue);
                    //   driver.WaitForTransaction();
                    _webClient.Browser.ThinkTime(2000);


                }
                else
                {

                    var InputDropdown = fieldRows[RowNo - 1].FindElement(By.XPath(".//button"));
                    driver.WaitForTransaction();

                    Console.WriteLine("Inputfield found");
                    driver.WaitForTransaction();

                    _webClient.Browser.ThinkTime(3000);

                    InputDropdown.Click();

                    driver.WaitForTransaction();

                    _webClient.Browser.ThinkTime(3000);

                    var optionList = driver.WaitUntilAvailable(By.XPath("//div[contains(@class, 'optionsContainerWrapper')]"));

                    Console.WriteLine("optionList found");

                    var options = optionList.FindElements(By.TagName("button"));

                    if (options.Any(x => x.GetAttribute("aria-label").Equals(FieldName, StringComparison.OrdinalIgnoreCase)))
                    {
                        var OptionToSelect = options.FirstOrDefault(x => x.GetAttribute("aria-label").Equals(FieldName, StringComparison.OrdinalIgnoreCase));

                        OptionToSelect.Click();

                        driver.WaitForTransaction();
                    }
                    else
                        throw new Exception($"No option found with name {FieldName}");
                    //set input value field

                    ValueInputField = fieldRows[RowNo - 1].FindElement(By.XPath(".//div[@class ='DataTypeTemplate-Value']"));
                    Console.WriteLine("ValueInputFuield found");
                    var Input = ValueInputField.FindElement(By.XPath(".//input"));
                    Input.Click();
                    Input.Clear();
                    Input.SendKeys(InputValue);
                    driver.WaitForTransaction();

                }


                return true;
            });

        }
        public BrowserCommandResult<bool> TimePicker(string FieldValue, string FieldName, int fieldNo)
        {
            return TestSettings.CurrentPersonaDto.XrmApp.WebClient.Execute(BaseExtensions.GetOptionsInternal($"Set value as {FieldValue} to Kendo time field {FieldName}"), driver =>
            {
                if (driver.HasElement(By.ClassName("k-dateinput-wrap")))
                {

                    var inputcontainer = driver.FindElements(By.ClassName("k-input"));
                    inputcontainer[fieldNo - 1].SendKeys(FieldValue);


                    //if (inputContainer.Any(x => x.GetAttribute("aria-valuetext").Equals(FieldName, StringComparison.OrdinalIgnoreCase)))
                    //{
                    //var input = inputContainer.FirstOrDefault(x => x.GetAttribute("aria-valuetext").Equals(FieldName, StringComparison.OrdinalIgnoreCase));


                    //  driver.WaitForTransaction();
                    System.Console.WriteLine("Field searched by classname");

                    //}
                }


                else
                    throw new NotFoundException($"searched kendo field not found");

                return true;

            });
        }

        public BrowserCommandResult<bool> SelectWeekDay(string FieldValue)
        {
            return TestSettings.CurrentPersonaDto.XrmApp.WebClient.Execute(BaseExtensions.GetOptionsInternal($"Select weekday {FieldValue}|"), driver =>
            {
                var option = driver.FindElement(By.XPath(".//div[@class ='container']"));
                System.Console.WriteLine("Testnjcshnjd");
                var Input = option.FindElement(By.XPath(".//input[@type='checkbox']"));
                Input.Click();

                return true;
            });
        }

        public BrowserCommandResult<bool> BookAppointmentBtn(string FieldValue)
        {
            return TestSettings.CurrentPersonaDto.XrmApp.WebClient.Execute(BaseExtensions.GetOptionsInternal($"Click on  {FieldValue} Button"), driver =>
            {
                var ButtonId = driver.FindElement(By.XPath("//div[contains(@class,'m')]"));
                // ((IJavaScriptExecutor)driver).ExecuteScrip‌t("arguments[0].style.backgroundColor = 'blue'", ButtonId);

                var Input = ButtonId.FindElement(By.XPath(".//button[contains(@id,'btnGoToBookAppointment')]"));
                //((IJavaScriptExecutor)driver).ExecuteScrip‌t("arguments[0].style.backgroundColor = 'blue'", Input);
                if (Input.Displayed && Input.Enabled)
                {
                    Console.WriteLine("button displayed");
                    //  ((IJavaScriptExecutor)driver).ExecuteScrip‌t("arguments[0].click();", Input);
                    //   ((IJavaScriptExecutor)driver).ExecuteScrip‌t("arguments[0].style.backgroundColor = 'blue'", Input);
                    //Input.Click();
                    //  driver.SwitchTo().ActiveElement();
                    //Input.Submit();
                    //  Input.SendKeys(Keys.Tab);
                    //  Input.SendKeys(Keys.Tab);
                    _webClient.Browser.ThinkTime(1000);
                    Input.Click();

                    driver.WaitForTransaction();
                }
                else
                {
                    //throw new ElementNotSelectableException("Button is not clickable");
                }

                return true;
            });
        }

        public BrowserCommandResult<bool> SelectFieldValue(string FieldValue, string FieldType, bool optionlabel = false)
        {
            return TestSettings.CurrentPersonaDto.XrmApp.WebClient.Execute(BaseExtensions.GetOptionsInternal($"I Select {FieldType} as {FieldValue} "), driver =>
            {

                var entityDropdown = driver.WaitUntilAvailable(By.XPath($"//label[contains(@for,'{FieldType}')]/following-sibling::span"), "Dropdown not found");
                entityDropdown.Click();
                _webClient.Browser.ThinkTime(2000);

                if (driver.HasElement(By.XPath($"//div[contains(@class,'k-list-scroller')]//ul[contains(@id,'{FieldType}')]")))
                {
                    Console.WriteLine("scroller found");
                    var scroller = driver.FindElement(By.XPath($"//div[contains(@class,'k-list-scroller')]//ul[contains(@id,'{FieldType}')]"));
                    ((IJavaScriptExecutor)driver).ExecuteScrip‌t("arguments[0].style.backgroundColor = 'blue'", scroller);
                    _webClient.Browser.ThinkTime(5000);

                    if (optionlabel == true)
                    {
                        var options = scroller.FindElements(By.XPath(".//li"));
                        _webClient.Browser.ThinkTime(2000);
                        Console.WriteLine(options.Count);
                        Console.WriteLine("span element");
                        _webClient.Browser.ThinkTime(2000);

                        if (options.Any(x => x.Text.Equals(FieldValue, StringComparison.OrdinalIgnoreCase)))
                        {

                            var OptionToSelect = options.FirstOrDefault(x => x.Text.Equals(FieldValue, StringComparison.OrdinalIgnoreCase));
                            Console.WriteLine(OptionToSelect.Text);
                            ((IJavaScriptExecutor)driver).ExecuteScrip‌t("arguments[0].style.backgroundColor = 'blue'", OptionToSelect);
                            ((IJavaScriptExecutor)driver).ExecuteScrip‌t("arguments[0].click();", OptionToSelect);
                            //  OptionToSelect.SendKeys(Keys.Enter);
                            //OptionToSelect.Click();
                            _webClient.Browser.ThinkTime(2000);
                            driver.WaitForTransaction();
                        }
                        else
                        {
                            throw new ElementNotSelectableException("Option set value not present");
                        }

                    }
                    else
                    {
                        //var SelectContainer


                        // SelectElement Dropdown = new SelectElement(SelectContainer);
                        // Dropdown.SelectByText(fieldTextToSelect);
                        var options = scroller.FindElements(By.XPath(".//li/span"));
                        Console.WriteLine(options.Count);
                        _webClient.Browser.ThinkTime(2000);
                        foreach (var option in options)
                        {

                            // var span = option.FindElement(By.XPath("span"));
                            //  Console.WriteLine(option.Text);
                            ((IJavaScriptExecutor)driver).ExecuteScrip‌t("arguments[0].style.backgroundColor = 'blue'", option); Actions actions = new Actions(driver);

                            //if (option.Text.Contains(FieldValue, StringComparison.OrdinalIgnoreCase))
                            actions.MoveToElement(option).Click().Build().Perform();
                            //{
                            //    ((IJavaScriptExecutor)driver).ExecuteScrip‌t("arguments[0].click();", option

                            //                                    option.Click();
                            //    driver.WaitForTransaction();
                            //}

                            if (options.Any(x => x.Text.Equals(FieldValue, StringComparison.OrdinalIgnoreCase)))
                            {
                                Console.WriteLine("in the loop");

                                var OptionToSelect = options.FirstOrDefault(x => x.Text == FieldValue);
                                Console.WriteLine(OptionToSelect.Text);
                                ((IJavaScriptExecutor)driver).ExecuteScrip‌t("arguments[0].style.backgroundColor = 'blue'", OptionToSelect);
                                ((IJavaScriptExecutor)driver).ExecuteScrip‌t("arguments[0].click();", OptionToSelect);
                                //  OptionToSelect.SendKeys(Keys.Enter);
                                //OptionToSelect.Click();
                                _webClient.Browser.ThinkTime(2000);
                                driver.WaitForTransaction();
                            }
                            else
                            {
                                throw new ElementNotSelectableException("Option set value not present");
                            }
                        }
                    }
                }


                return true;

            });

        }


        public BrowserCommandResult<bool> SelectRelatedOptionField(string FieldValue, string FieldType)
        {
            return TestSettings.CurrentPersonaDto.XrmApp.WebClient.Execute(BaseExtensions.GetOptionsInternal($"I Select {FieldType} as {FieldValue} "), driver =>
            {

                var entityDropdown = driver.WaitUntilAvailable(By.XPath($"//label[contains(@for,'{FieldType}')]/following-sibling::span"), "Dropdown not found");

                ((IJavaScriptExecutor)driver).ExecuteScrip‌t("arguments[0].style.backgroundColor = 'blue'", entityDropdown);

                //var div = driver.FindElement(By.XPath("//div[contains(@class,'form-group')]"));
                // entityDropdown.Click();

                Console.WriteLine("entityDropdown");
                var SelectContainer = entityDropdown.FindElements(By.XPath($".//select[contains(@id,'{FieldType}')]/option"));
                Console.WriteLine("selectContainer");
                Console.WriteLine(SelectContainer.Count);
                // entityDropdown.Click();
                _webClient.Browser.ThinkTime(3000);
                // SelectContainer.Click();
                //    Console.WriteLine("SelectOptions");
                for (int i = 0; i < SelectContainer.Count; i++)
                {
                    //SelectElement Dropdown = new SelectElement(SelectContainer[i]);
                    //Dropdown.SelectByText(FieldValue);

                    Actions actions = new Actions(driver);

                    actions.MoveToElement(SelectContainer[i]);
                    string option = SelectContainer[i].Text;

                    Console.WriteLine(option);
                    if (option.Equals(FieldValue, StringComparison.OrdinalIgnoreCase))
                    {

                        actions.MoveToElement(SelectContainer[i]).Click().Build().Perform();
                        //    SelectContainer[i].Click();
                        //    Console.WriteLine(SelectContainer[i].Text);
                        //    driver.WaitForTransaction();
                        Console.WriteLine("Option selected");

                        //    _webClient.Browser.ThinkTime(2000);
                        //    break;
                        //}
                        _webClient.Browser.ThinkTime(3000);

                    }
                }
                return true;

            });

        }



        public BrowserCommandResult<bool> ShowAvailability(string FieldValue)
        {
            return TestSettings.CurrentPersonaDto.XrmApp.WebClient.Execute(BaseExtensions.GetOptionsInternal($"Click on  {FieldValue} Button"), driver =>
            {
                var ButtonId = driver.FindElement(By.XPath(".//div[@class ='form-group']"));

                var Input = ButtonId.FindElement(By.XPath($"//button[contains(text(),'{FieldValue}')]"));
                if (Input.Displayed && Input.Enabled)
                {
                    Console.WriteLine("button displayed");
                    Input.Click(true);
                    _webClient.Browser.ThinkTime(4000);
                    driver.WaitForTransaction();
                }
                else
                {
                    throw new ElementNotSelectableException("Button is not clickable");
                }

                return true;
            });
        }

        public BrowserCommandResult<bool> ClickOnAvailableDay(string FieldValue)
        {
            return TestSettings.CurrentPersonaDto.XrmApp.WebClient.Execute(BaseExtensions.GetOptionsInternal($"Click on  {FieldValue} Button"), driver =>
            {
                var ButtonId = driver.FindElement(By.XPath(".//div[@class ='k-scheduler-header-wrap']"));

                var Input = ButtonId.FindElement(By.XPath($"//div[contains(@currentdate,'{FieldValue}')]"));
                if (Input.Displayed && Input.Enabled)
                {
                    Console.WriteLine("button displayed");
                    Input.Click();
                    _webClient.Browser.ThinkTime(4000);
                    driver.WaitForTransaction();
                }
                else
                {
                    throw new ElementNotSelectableException("Button is not clickable");
                }

                return true;
            });
        }

        public BrowserCommandResult<bool> ClickOnAvailableSlot(string FieldValue)
        {
            return TestSettings.CurrentPersonaDto.XrmApp.WebClient.Execute(BaseExtensions.GetOptionsInternal($"Click on  {FieldValue} Button"), driver =>
            {
                var ButtonId = driver.FindElement(By.XPath(".//div[@class ='k-scheduler-content']"));

                IWebElement Input = ButtonId.FindElement(By.XPath("//i[@id='appt']"));
                Console.WriteLine("Book Appointment slot Available");
                //var Input = ButtonId.FindElement(By.XPath("//span[contains(text(),' Book Appointment')]"));
                IJavaScriptExecutor executor = (IJavaScriptExecutor)driver;
                executor.ExecuteScript("arguments[0].click();", Input);
                Console.WriteLine("Book Appointment slot is clicked");
                return true;
                
                throw new ElementNotSelectableException("Button is not clickable");

            });
        }

        public BrowserCommandResult<bool> ClickOnCalendarView(string FieldValue)
        {
            return TestSettings.CurrentPersonaDto.XrmApp.WebClient.Execute(BaseExtensions.GetOptionsInternal($"Click on  {FieldValue} Button"), driver =>
            {
                var View = driver.FindElement(By.XPath($"//a[contains(.,'{FieldValue}')]"));

                View.Click(true);

                _webClient.Browser.ThinkTime(4000);
                driver.WaitForTransaction();


                return true;
            });
        }

        public BrowserCommandResult<bool> OpenArea(string AreaName)
        {
            return TestSettings.CurrentPersonaDto.XrmApp.WebClient.Execute(BaseExtensions.GetOptionsInternal($"Click on  {AreaName} Area"), driver =>
            {
                var ButtonId = driver.FindElement(By.XPath(".//div[@id ='areaSwitcherContainer']"));
                ButtonId.Click(true);
                _webClient.Browser.ThinkTime(4000);
                Console.WriteLine("Area found");
                var Input = driver.FindElement(By.XPath($"//span[contains(text(),'{AreaName}')]"));
                Input.Click(true);

                _webClient.Browser.ThinkTime(4000);

                return true;
            });
        }
        public BrowserCommandResult<bool> LocateAppointment(string AppointmentName)
        {
            return TestSettings.CurrentPersonaDto.XrmApp.WebClient.Execute(BaseExtensions.GetOptionsInternal($"Locate Appointment  {AppointmentName} in the Staff Calendar"), driver =>
            {
                var AppointmentId = driver.FindElement(By.XPath(".//div[@class ='k-event']"));

                var Input = AppointmentId.FindElement(By.XPath($"//div[contains(text(), '{AppointmentName}')]"));
                Input.Click(true);
                Console.WriteLine("Appointment present in the staff calendar");
                _webClient.Browser.ThinkTime(4000);

                return true;
            });
        }

        public BrowserCommandResult<bool> CancelAppointment(string AppointmentName)
        {
            return TestSettings.CurrentPersonaDto.XrmApp.WebClient.Execute(BaseExtensions.GetOptionsInternal($"Locate Appointment  {AppointmentName} in the Staff Calendar"), driver =>
            {
                var AppointmentId = driver.FindElement(By.XPath(".//div[@class ='k-event']"));

                var Input = AppointmentId.FindElement(By.XPath($"//div[contains(text(), '{AppointmentName}')]"));

                var Cancel = Input.FindElement(By.XPath("//span[contains(text(),  '$0')]"));

                Console.WriteLine("Hello");


                //var Cancel = CancelButton.FindElement(By.XPath($"//span[@class ='k-icon k-i-close')]"));
                // var CancelApt = Cancel.FindElement(By.XPath($"//a[@href = '#')]"));

                Console.WriteLine("Cancel button clicked");
                Cancel.Click(true);
                _webClient.Browser.ThinkTime(4000);

                return true;
            });
        }

        public BrowserCommandResult<bool> SelectFieldOption(string option, string FieldName)
        {
            return TestSettings.CurrentPersonaDto.XrmApp.WebClient.Execute(BaseExtensions.GetOptionsInternal($"Locate {FieldName} in the form"), driver =>
            {
                if (driver.HasElement(By.XPath($".//div[contains(@id, '{FieldName}.fieldControl-checkbox-select')]")))
                {

                    var FieldId = driver.FindElement(By.XPath($".//select[contains(@id, '{FieldName}.fieldControl-checkbox-select')]"));
                    //Console.WriteLine(FieldId.Count);
                    ((IJavaScriptExecutor)driver).ExecuteScrip‌t("arguments[0].style.backgroundColor = 'blue'", FieldId);

                    ((IJavaScriptExecutor)driver).ExecuteScrip‌t("arguments[0].click();", FieldId);
                    //FieldId.Click();
                    _webClient.Browser.ThinkTime(2000);
                    var options = FieldId.FindElements(By.XPath(".//option"));
                    if (options.Any(x => x.Text.Equals(option, StringComparison.OrdinalIgnoreCase)))
                    {
                        var optionToSelect = options.FirstOrDefault(x => x.Text.Equals(option, StringComparison.OrdinalIgnoreCase));

                        optionToSelect.Click();
                        _webClient.Browser.ThinkTime(2000);
                        System.Console.WriteLine(optionToSelect.Text);

                    }
                    else
                        throw new Exception($"Option with name {option} does not exist.");

                    Console.WriteLine("Option selected");
                }
                else
                    throw new Exception($"field with name {FieldName} does not exist.");
                _webClient.Browser.ThinkTime(2000);

                return true;
            });
        }

        public BrowserCommandResult<bool> SelectReport(string ReportName)
        {
            return TestSettings.CurrentPersonaDto.XrmApp.WebClient.Execute(BaseExtensions.GetOptionsInternal($"Locate Report  {ReportName} in the Dashboard"), driver =>
            {

                driver.SwitchTo().Frame(driver.FindElement(By.XPath("//iframe[contains(@id,'WebResource_CoccupationInsight')]")));
                Console.WriteLine("frame switched");

                var select = driver.FindElement(By.Id("reportDropDown-select"));

                select.Click();
                _webClient.Browser.ThinkTime(2000);

                SelectElement Dropdown = new SelectElement(select);
                Dropdown.SelectByText(ReportName);
                _webClient.Browser.ThinkTime(2000);
                driver.WaitForTransaction();
                Console.WriteLine("Option selected");
                return true;
            });
        }

        public BrowserCommandResult<bool> ClearValueEx(LookupItem Control, bool removeAll = true)
        {
            return TestSettings.CurrentPersonaDto.XrmApp.WebClient.Execute(BaseExtensions.GetOptionsInternal($"Clear value of exisiting {Control.Name} lookup field "), driver =>
            {



                if (driver.HasElement(By.XPath($"//ul[contains(@id,'{Control.Name}')]")))
                {
                    var lookupField = driver.FindElement(By.XPath($"//ul[contains(@id,'{Control.Name}')]"));



                    //lookupField.Click();
                    Console.WriteLine("field clicked");



                    var DeleteTags = driver.FindElements(By.XPath($".//*[contains(@data-id, '{Control.Name}.fieldControl-LookupResultsDropdown_{Control.Name}_selected_tag_delete')]"));



                    Console.WriteLine("existing values to be deleted are found");



                    if (DeleteTags != null)
                    {
                        foreach (var Tag in DeleteTags)
                        {
                            Tag.Click(true);
                            Console.WriteLine("existing data deleted");
                        }



                    }
                    //else
                    //    throw new Exception($"There are no existing values to be deleted");
                }
                else
                    throw new Exception($"Lookup field {Control.Name} is not found");



                return true;
            });
        }
        public BrowserCommandResult<bool> HighlightElement(IWebElement Element)
        {
            return TestSettings.CurrentPersonaDto.XrmApp.WebClient.Execute(BaseExtensions.GetOptionsInternal($"Highlight element {Element}"), driver =>
            {
                driver.ExecuteScrip‌t("arguments[0].style.backgroundColor = 'blue'", Element);

                return true;
            });

        }

        //public BrowserCommandResult<bool> PressTab()
        //{
        //    return TestSettings.CurrentPersonaDto.XrmApp.WebClient.Execute(BaseExtensions.GetOptionsInternal($"Press Tab key"), driver =>
        //    {
        //        //driver.ExecuteScrip‌t("arguments[0].style.backgroundColor = 'blue'", Element);

        //        // AutoItX.Send("{TAB}");
        //        //InputSimulator I = new InputSimulator();
        //        //I.Keyboard.KeyPress(VirtualKeyCode.TAB);
        //        //I.Keyboard.KeyPress(VirtualKeyCode.TAB);

        //        Actions actions = new Actions(driver);
        //        actions.SendKeys(Keys.Tab).Build().Perform();

        //        return true;
        //    });

        //}

        public BrowserCommandResult<bool> ScrollFocusSection(string sectionLabel)
        {
            return TestSettings.CurrentPersonaDto.XrmApp.WebClient.Execute(BaseExtensions.GetOptionsInternal($"focuss section {sectionLabel}"), driver =>
            {
                IWebElement parentElement = driver.FindElementWithWait(By.XPath($"//section[contains(@aria-label,'{sectionLabel}')]"));
                Console.WriteLine("Section found");
                IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
                js.ExecuteScript("arguments[0].scrollIntoView(true);", parentElement);

                _webClient.Browser.ThinkTime(2000);
                //((IJavaScriptExecutor)driver).ExecuteScript("window.scrollTo(0, document.body.scrollHeight)");

                return true;
            });

        }
        public BrowserCommandResult<bool> ScrollToEndOfSection(string sectionLabel)
        {
            return TestSettings.CurrentPersonaDto.XrmApp.WebClient.Execute(BaseExtensions.GetOptionsInternal($"focuss section {sectionLabel}"), driver =>
            {
                var parentElement = driver.FindElement(By.XPath($"//section[contains(@aria-label,'{sectionLabel}')]"));
                Console.WriteLine("Section found");
                ((IJavaScriptExecutor)driver).ExecuteScript("arguments[0].scrollIntoView(false);", parentElement);
                _webClient.Browser.ThinkTime(2000);

                //  ((IJavaScriptExecutor)driver).ExecuteScript("window.scrollTo(0, document.body.scrollHeight)");
                return true;
            });

        }

        public BrowserCommandResult<bool> ScrollToBottomOfPage(string sectionLabel, string fieldLabel)
        {
            return TestSettings.CurrentPersonaDto.XrmApp.WebClient.Execute(BaseExtensions.GetOptionsInternal($"scroll to section {sectionLabel} having field  {fieldLabel}"), driver =>
            {

                var sectionContainer = driver.FindElement(By.XPath(CmcAppElements.Xpath[CmcAppReference.Entity.sectionContainer].Replace("[NAME]", sectionLabel)));
                ((IJavaScriptExecutor)driver).ExecuteScript("arguments[0].scrollIntoView();", sectionContainer);
                if (driver.HasElement(By.XPath(CmcAppElements.Xpath[CmcAppReference.Entity.sectionContainer].Replace("[NAME]", sectionLabel))))
                {

                    var Label = sectionContainer.FindElements(By.XPath(CmcAppElements.Xpath[CmcAppReference.Entity.fieldLabel]));

                    var field = Label.FirstOrDefault(x => x.Text.StartsWith(fieldLabel, StringComparison.OrdinalIgnoreCase));
                    ((IJavaScriptExecutor)driver).ExecuteScript("arguments[0].scrollIntoView();", field);

                    //  driver.WaitForTransaction();
                    _webClient.Browser.ThinkTime(2000);
                    System.Console.WriteLine(field.Text);

                }
                else
                    throw new Exception($"Section does not exist.");


                _webClient.Browser.ThinkTime(2000);
                return true;
            });

        }
        public BrowserCommandResult<bool> SetDateValue(string fieldValue, string fieldName)
        {
            return TestSettings.CurrentPersonaDto.XrmApp.WebClient.Execute(BaseExtensions.GetOptionsInternal($"focuss section {fieldName}"), driver =>
            {
                var parentElement = driver.FindElement(By.XPath($"//input[contains(@id, 'DatePicker') and contains(@aria-label,'{fieldName}')]"));
                Console.WriteLine("field found");
                parentElement.SendKeys(fieldValue);
                _webClient.Browser.ThinkTime(2000);
                return true;
            });

        }
        public BrowserCommandResult<bool> SetDateTimeValue(string fieldValue, string fieldName)
        {
            return TestSettings.CurrentPersonaDto.XrmApp.WebClient.Execute(BaseExtensions.GetOptionsInternal($"focuss section {fieldName}"), driver =>
            {
                IWebElement parentElement = null;
                // var divElement = driver.FindElement(By.XPath("//div[contains(@class, 'ms-DatePicker')]"));

                var divElements = driver.FindElements(By.XPath(CmcAppElements.Xpath[CmcAppReference.Entity.Entity_DivDatePicker]));

                parentElement = divElements.FirstOrDefault().FindElement(By.XPath(CmcAppElements.Xpath[CmcAppReference.Entity.Entity_InputDateField].Replace("[NAME]", fieldName)));

                //parentElement.Clear();
                // parentElement.Click();
                var existingValue = parentElement.GetAttribute("Value");
                if (!existingValue.IsEmptyValue())
                {
                    Console.WriteLine("field has value" + existingValue);

                    parentElement.SendKeys(Keys.Control + "A");

                    ((IJavaScriptExecutor)driver).ExecuteScript("arguments[0].value ='';", parentElement);


                }

                parentElement.SendKeys(fieldValue);

                return true;
            });

        }
        //public BrowserCommandResult<bool> ScrollFocusLookup(string FieldName, string sectionLabel)
        //{
        //    return TestSettings.CurrentPersonaDto.XrmApp.WebClient.Execute(BaseExtensions.GetOptionsInternal($"focuss on lookup {FieldName}"), driver =>
        //    {
        //        var section = driver.FindElement(By.XPath($"//section[contains(@aria-label,'{sectionLabel}')]"));
        //        Console.WriteLine("section found");
        //        var parentElement = section.FindElement(By.XPath($".//input[contains(@data-id,'{FieldName}.fieldControl-LookupResultsDropdown')]"));
        //        Console.WriteLine("lookup found");
        //        ((IJavaScriptExecutor)driver).ExecuteScript("arguments[0].scrollIntoView(true);", parentElement);
        //        _webClient.Browser.ThinkTime(2000);
        //        return true;
        //    });

        //}


        public BrowserCommandResult<bool> SelectQuestionType(string QuestionType, string QuestionValue, string OptionValue = null)
        {
            return TestSettings.CurrentPersonaDto.XrmApp.WebClient.Execute(BaseExtensions.GetOptionsInternal($"I Select {QuestionType} and {QuestionValue} and also {OptionValue} "), driver =>
            {
                if (QuestionType == "Text Field")
                {
                    var frameName = driver.SwitchTo().Frame("WebResource_SurveyTemplate");
                    Console.WriteLine("Frame found");

                    var div = frameName.FindElement(By.XPath(".//div[@id='questions']"));
                    var selectDropdown = div.FindElement(By.XPath(".//select[contains(@class,'questionType')]"));
                    var optionText = selectDropdown.FindElement(By.XPath(".//option[text() = 'Text Field']"));
                    optionText.Click();
                    _webClient.Browser.ThinkTime(4000);

                    var questiontextfield = driver.FindElement(By.XPath(".//input[@placeholder='Enter a question']"));
                    questiontextfield.SendKeys(QuestionValue);
                    _webClient.Browser.ThinkTime(4000);
                    driver.WaitForTransaction();
                }
                else if (QuestionType != "Text Field")
                {
                    var SelectContainer = driver.FindElement(By.XPath(".//select[contains(@class,'questionType')]"));
                    SelectElement Options = new SelectElement(SelectContainer);
                    Options.SelectByText(QuestionType);

                    //var optionNotText = SelectContainer.FindElement(By.XPath($".//option[text()='{QuestionType}']"));
                    //Console.WriteLine("Option other than text Field found");
                    //optionNotText.Click();
                    _webClient.Browser.ThinkTime(4000);

                    var questiontextfield1 = driver.FindElement(By.XPath(".//input[@placeholder='Enter a question']"));
                    questiontextfield1.SendKeys(QuestionValue);
                    _webClient.Browser.ThinkTime(4000);
                    driver.WaitForTransaction();

                    var optionfield = driver.FindElement(By.XPath(".//input[@placeholder='Enter an option']"));
                    optionfield.SendKeys(OptionValue);
                    _webClient.Browser.ThinkTime(4000);
                    driver.WaitForTransaction();
                }

                else
                {
                    throw new ElementNotSelectableException("Question type not found");
                }
                return true;

            });

        }


        public BrowserCommandResult<bool> ClickButtonInQuestionSection(string ButtonLabel)
        {
            return TestSettings.CurrentPersonaDto.XrmApp.WebClient.Execute(BaseExtensions.GetOptionsInternal($" Click button {ButtonLabel}in question section in the form"), driver =>
            {
                var div = driver.FindElement(By.XPath(".//div[@class='col-md-7 questionsDiv']"));
                var AddQuestionButton = div.FindElement(By.XPath(".//button[text()='Add Question']"));
                //Console.WriteLine("Button found");
                if (driver.HasElement(By.XPath(".//button[text()='Add Question']")))
                {
                    _webClient.Browser.ThinkTime(4000);
                    AddQuestionButton.Click();
                    Console.WriteLine("Button Clicked");
                    _webClient.Browser.ThinkTime(4000);
                    driver.WaitForTransaction();
                }

                else
                    throw new Exception($"Button{ButtonLabel}not found");



                return true;

            });
        }

        public BrowserCommandResult<bool> SelectExistingView(string viewName, string FieldName, string sectionName)
        {
            return TestSettings.CurrentPersonaDto.XrmApp.WebClient.Execute(BaseExtensions.GetOptionsInternal($" Click button {viewName}in question section in the form"), driver =>
            {


                if (driver.HasElement(By.XPath($"//section[@aria-label='{sectionName}']")))
                {
                    var parentElement = driver.FindElement(By.XPath($"//section[contains(@aria-label,'{sectionName}')]"));
                    var div = parentElement.FindElement(By.XPath($".//div[contains(@data-id,'{FieldName}')]"));
                    _webClient.Browser.ThinkTime(2000);


                    var viewDropdown = div.FindElement(By.XPath(".//span[contains(@class,'k-dropdown-wrap')]"));
                    Console.WriteLine("span element found");
                    if (viewDropdown != null)
                    {
                        viewDropdown.Click();
                        _webClient.Browser.ThinkTime(2000);

                        var scroller = driver.WaitUntilAvailable(By.XPath($"//div[contains(@class, 'k-list-container') and contains(@id, '{FieldName}')]"), "container not available");

                        _webClient.Browser.ThinkTime(2000);

                        var listItems = scroller.FindElements(By.XPath(".//li"));
                        Console.WriteLine("listItems " + listItems.Count);

                        //foreach (var item in listItems)
                        //{
                        //    driver.ExecuteScrip‌t("arguments[0].style.backgroundColor = 'blue'", item);
                        //    Console.WriteLine(item.Text);
                        //}

                        if (listItems.Any(x => x.Text.Equals(viewName, StringComparison.OrdinalIgnoreCase)))

                        {
                            Console.WriteLine("items found");
                            var optionToSelect = listItems.FirstOrDefault(x => x.Text.Equals(viewName, StringComparison.OrdinalIgnoreCase));
                            driver.WaitForTransaction();
                            optionToSelect.Click();

                            System.Console.WriteLine(optionToSelect.Text);

                        }
                        else
                            throw new Exception($"View/Entity with name {viewName} does not exist.");
                        Console.WriteLine("skipping section menthod");

                    }
                }
                else
                    throw new Exception("Section not found");

                //}
                //else
                //    throw new Exception("Dropdown not found");

                return true;

            });
        }


        public BrowserCommandResult<bool> SelectPCFControlOption(string viewName, string FieldName, string sectionName)
        {
            return TestSettings.CurrentPersonaDto.XrmApp.WebClient.Execute(BaseExtensions.GetOptionsInternal($" Click button {viewName}in question section in the form"), driver =>
            {
                if (driver.HasElement(By.XPath($"//section[@aria-label='{sectionName}']")))
                {
                    var parentElement = driver.FindElement(By.XPath($"//section[contains(@aria-label,'{sectionName}')]"));

                    var div = parentElement.FindElement(By.XPath($".//div[contains(@data-id,'{FieldName}')]"));
                    _webClient.Browser.ThinkTime(2000);

                    var viewDropdown = div.FindElement(By.XPath(".//span[contains(@class,'k-dropdown-wrap')]"));
                    Console.WriteLine("span element found");
                    if (viewDropdown != null)
                    {
                        viewDropdown.Click();
                        _webClient.Browser.ThinkTime(2000);

                        var listContainer = driver.WaitUntilAvailable(By.XPath("//div[contains(@class, 'k-animation-container')]"));


                        driver.ExecuteScrip‌t("arguments[0].style.backgroundColor = 'blue'", listContainer);

                        var scroller = listContainer.FindElement(By.XPath(".//div[contains(@class, 'k-list-scroller')]"));

                        var listItems = scroller.FindElements(By.XPath(".//li"));
                        Console.WriteLine("listItems" + listItems.Count);

                        foreach (var item in listItems)
                        {
                            driver.ExecuteScrip‌t("arguments[0].style.backgroundColor = 'blue'", item);
                            //Console.WriteLine(item.Text);
                        }



                        if (listItems.Any(x => x.Text == viewName))

                        {


                            Console.WriteLine("items found");
                            var optionToSelect = listItems.FirstOrDefault(x => x.Text.Equals(viewName, StringComparison.OrdinalIgnoreCase));
                            driver.WaitForTransaction();
                            optionToSelect.Click();

                            System.Console.WriteLine(optionToSelect.Text);

                        }
                        else
                            throw new Exception($"View/Entity with name {viewName} does not exist.");

                    }
                    else
                        throw new Exception("Dropdown not found");
                }
                else
                    throw new Exception("Section not found");

                return true;

            });
        }
        public BrowserCommandResult<bool> MultiSelectTreeSection(string option, string FieldName)
        {
            return TestSettings.CurrentPersonaDto.XrmApp.WebClient.Execute(BaseExtensions.GetOptionsInternal($" Click button in question section in the form"), driver =>
            {
                if (driver.HasElement(By.XPath($"//div[contains(@data-id,'{FieldName}')]")))
                {
                    // var parentElement = _webClient.Browser.Driver.FindElement(By.XPath($"//div[contains(@data-id,'{FieldName}')]"));

                    var div = driver.FindElement(By.XPath($"//div[contains(@data-id,'{FieldName}')]"));


                    var listItems = div.FindElements(By.XPath(".//li//span"));

                    //foreach (var item in listItems)
                    //{
                    //    Console.WriteLine(item.Text);

                    //}

                    if (listItems.Any(x => x.Text.Equals(option, StringComparison.OrdinalIgnoreCase)))
                    {
                        var optionToSelect = listItems.FirstOrDefault(x => x.Text.Equals(option, StringComparison.OrdinalIgnoreCase));
                        driver.WaitForTransaction();
                        optionToSelect.Click();

                        System.Console.WriteLine(optionToSelect.Text);

                    }
                    else
                        throw new Exception($"Option with name {option} does not exist.");


                }
                else
                    throw new Exception($"field with name {FieldName} not found");


                return true;

            });
        }
        public BrowserCommandResult<bool> ClickButtonInSection(string ButtonName, string sectionName)
        {
            return _webClient.Execute(BaseExtensions.GetOptionsInternal($"Select section {ButtonName} button {sectionName}"), driver =>
            {

                IWebElement parentElement;


                if (driver.HasElement(By.XPath($"//section[@aria-label='{sectionName}']")))
                {
                    parentElement = driver.FindElement(By.XPath($"//section[contains(@aria-label,'{sectionName}')]"));
                    Console.WriteLine("Section found in section area label");

                    var div = parentElement.FindElement(By.XPath(".//div[contains(@class,'Cmc.Engage.CustomControls.viewPicker')]"));
                    Console.WriteLine("div found");
                    var buttons = div.FindElements(By.XPath(".//button"));

                    if (buttons.Count >= 0)
                    {

                        if (buttons.Any(x => x.Text == ButtonName))
                        {
                            var buttonToClick = buttons.FirstOrDefault(x => x.Text == ButtonName);

                            buttonToClick.Click();
                            _webClient.Browser.ThinkTime(2000);
                            Console.WriteLine("button clicked");
                        }

                        else
                            throw new NotFoundException($"section button {ButtonName} not found on form.");
                    }
                    else

                        throw new NotFoundException("No buttons are present inside form group div");

                }
                else

                    throw new NotFoundException($"section {sectionName} not found on form.");

                return true;
            });
        }

        public BrowserCommandResult<bool> FieldNotPresentInForm(string fieldName, string sectionName)
        {
            return _webClient.Execute(BaseExtensions.GetOptionsInternal($"Select section {sectionName} and field {fieldName}"), driver =>
            {
                IWebElement parentElement;
                if (driver.HasElement(By.XPath($"//section[@aria-label='{sectionName}']")))
                {
                    parentElement = driver.FindElement(By.XPath($"//section[contains(@aria-label,'{sectionName}')]"));
                    Console.WriteLine("Section found in section area label");

                    var fields = parentElement.FindElements(By.XPath($".//label[text()='{fieldName}']"));

                    if (fields.Count <= 0)
                    {

                        Assert.IsFalse(driver.HasElement(By.XPath($".//label[text()='{fieldName}']")));
                        Console.WriteLine("Given field is not present in the section as expected");

                    }
                    else
                        throw new Exception("Given field is present in the section");

                }
                else
                    throw new NotFoundException($"section name {sectionName} not found on form.");

                return true;

            });
        }

        public BrowserCommandResult<bool> SelectRadioButton(string ButtonToselect)
        {
            return _webClient.Execute(BaseExtensions.GetOptionsInternal($"Select radio button {ButtonToselect} in dialog window"), driver =>
            {

                if (driver.HasElement(By.XPath($"//input[contains(@type,'radio')]")))
                {

                    var radioButtons = driver.FindElements(By.XPath($"//input[contains(@type,'radio')]"));

                    Console.WriteLine("radioButtons found");

                    if (radioButtons.Any(x => x.GetAttribute("id").Equals(ButtonToselect, StringComparison.OrdinalIgnoreCase)))
                    {
                        var optionToSelect = radioButtons.FirstOrDefault(x => x.GetAttribute("id").Equals(ButtonToselect, StringComparison.OrdinalIgnoreCase));
                        driver.WaitForTransaction();
                        optionToSelect.Click();

                        System.Console.WriteLine(optionToSelect.Text);

                    }
                    else
                        throw new Exception($"Button with name {ButtonToselect} does not exist.");

                }
                else
                    throw new NotFoundException($"RadioButton section not found on form.");

                return true;

            });
        }

        public BrowserCommandResult<bool> ClickAppointmentSlot(string slotname)
        {
            return TestSettings.CurrentPersonaDto.XrmApp.WebClient.Execute(BaseExtensions.GetOptionsInternal($"Click on {slotname}"), driver =>
            {
                var parentid = driver.FindElement(By.XPath(".//div[contains(@class,'bookappointment')]"));
                var input = parentid.FindElement(By.XPath("//i[contains(@class,'text-success')]"));
                System.Console.WriteLine("parent: " + input);
                input.Click();
                return true;
            });
        }

        public BrowserCommandResult<bool> ValidateRequiredString(string AppointmentTitle)
        {
            return TestSettings.CurrentPersonaDto.XrmApp.WebClient.Execute(BaseExtensions.GetOptionsInternal($"Click on {AppointmentTitle}"), driver =>
            {
                var parent = driver.FindElement(By.XPath(".//div[contains(@class, 'k-dialog')]"));
                //var btn = parent.FindElement(By.XPath(".//ul[contains(@class, 'k-dialog')]//li[text() = 'Yes']"));
                var btn = parent.FindElement(By.XPath(".//button[text() = 'Yes']"));
                btn.Click();
                Console.WriteLine("Div found", parent);
                var lable = parent.FindElement(By.XPath(".//label[@id= 'labelCancelReasonRequired']"));
                Console.WriteLine(lable.Text);
                if (lable.Text == AppointmentTitle)
                {
                    Console.WriteLine("String Matched");
                }
                else
                {
                    Console.WriteLine("String NOT Matched");
                }
                return true;
            });
        }

        public BrowserCommandResult<bool> ClickOnCancelIcon(string AppointmentTitle)
        {
            return TestSettings.CurrentPersonaDto.XrmApp.WebClient.Execute(BaseExtensions.GetOptionsInternal($"Click on {AppointmentTitle}"), driver =>
            {
                var table = driver.FindElement(By.XPath(".//table[contains(@class, 'k-scrollbar-v')]"));
                Console.WriteLine("table found");
                var AllAppointments = table.FindElements(By.XPath($".//div[contains(@class, 'k-event')]//div[contains(@class, 'pointer bookappointment')]//span"));
                Console.WriteLine(AllAppointments.Count);

                if (AllAppointments.Any(x => x.Text.StartsWith(AppointmentTitle, StringComparison.OrdinalIgnoreCase)))
                {
                    var BookedAppointment = AllAppointments.FirstOrDefault(x => x.Text.StartsWith(AppointmentTitle, StringComparison.OrdinalIgnoreCase));
                    driver.WaitForTransaction();
                    Actions actions = new Actions(driver);
                    actions.MoveToElement(BookedAppointment).Perform();
                    _webClient.Browser.ThinkTime(2000);
                    var CloseIcon = driver.FindElement(By.XPath("//a[contains(@title, 'Cancel')]"));

                    ((IJavaScriptExecutor)driver).ExecuteScrip‌t("arguments[0].style.backgroundColor = 'blue'", CloseIcon);

                    ((IJavaScriptExecutor)driver).ExecuteScrip‌t("arguments[0].click();", CloseIcon);

                    _webClient.Browser.ThinkTime(2000);
                }
                else
                    throw new Exception($"Appointment with name {AppointmentTitle} does not exist.");
                return true;
            });
        }

        public BrowserCommandResult<bool> ClickBlockCheckbox()
        {
            return TestSettings.CurrentPersonaDto.XrmApp.WebClient.Execute(BaseExtensions.GetOptionsInternal($"Click on Block"), driver =>
            {
                var parent = driver.FindElement(By.XPath(".//div[contains(@class, 'k-dialog')]"));
                var checkbox = parent.FindElement(By.XPath(".//input[@id= 'chkOfficeHoursBlock']"));
                checkbox.Click();
                return true;
            });
        }


        public BrowserCommandResult<bool> InputReason(string resaon, string btn_name)
        {
            return TestSettings.CurrentPersonaDto.XrmApp.WebClient.Execute(BaseExtensions.GetOptionsInternal($"Click on {resaon}"), driver =>
            {
                var parent = driver.FindElement(By.XPath(".//div[contains(@class, 'k-dialog')]"));
                var checkbox = parent.FindElement(By.XPath(".//textarea[@id= 'cancelReason']"));
                checkbox.SendKeys(resaon);

                if (btn_name == "Yes")
                {
                    Console.WriteLine("Condition Passed");
                    var parent1 = driver.FindElement(By.XPath(".//div[contains(@class, 'k-dialog')]"));
                    //var btn = parent1.FindElement(By.XPath(".//ul[contains(@class, 'k-dialog')]//li[text() = 'Yes']"));
                    var btn = parent1.FindElement(By.XPath(".//button[text() = 'Yes']"));
                    btn.Click();
                }
                return true;
            });
        }

        public BrowserCommandResult<bool> CloseCancelAppointmentWindow()
        {
            return TestSettings.CurrentPersonaDto.XrmApp.WebClient.Execute(BaseExtensions.GetOptionsInternal($"Click Cancel Window"), driver =>
            {
                var parent1 = driver.FindElement(By.XPath(".//div[contains(@class, 'k-dialog')]"));
                //var btn = parent1.FindElement(By.XPath(".//ul[contains(@class, 'k-dialog')]//li[text() = 'No']"));
                var btn = parent1.FindElement(By.XPath(".//button[text() = 'No']"));
                btn.Click();
                return true;
            });

        }

        public BrowserCommandResult<bool> NoAppointment(string AppointmentTitle)
        {
            return TestSettings.CurrentPersonaDto.XrmApp.WebClient.Execute(BaseExtensions.GetOptionsInternal($"Click on {AppointmentTitle}"), driver =>
            {
                var table = driver.FindElement(By.XPath(".//table[contains(@class, 'k-scrollbar-v')]"));
                Console.WriteLine("table found");
                var AllAppointments = table.FindElements(By.XPath($".//div[contains(@class, 'k-event')]//div[contains(@class, 'pointer bookappointment')]//span"));
                Console.WriteLine(AllAppointments.Count);

                if (AllAppointments.Any(x => x.Text.StartsWith(AppointmentTitle, StringComparison.OrdinalIgnoreCase)))
                {
                    throw new Exception($"Appointment with name {AppointmentTitle} is exist.");
                }
                else
                {
                    Console.WriteLine("No Appointment is Available with Title ", AppointmentTitle);
                    return true;
                }
            });
        }

        public BrowserCommandResult<bool> VerifyBlockCount(string AppointmentTitle, string PageName)
        {
            string myappointmentpage = "MyAppointments";
            string bookappointmentpage = "BookedAppointments";

            return TestSettings.CurrentPersonaDto.XrmApp.WebClient.Execute(BaseExtensions.GetOptionsInternal($"Click on {AppointmentTitle}"), driver =>
            {
                var table = driver.FindElement(By.XPath(".//table[contains(@class, 'k-scrollbar-v')]"));
                Console.WriteLine("table found");
                var AllAppointments = table.FindElements(By.XPath($".//div[contains(@class, 'k-event')]//div[contains(@class, 'pointer bookappointment')]"));
                Console.WriteLine("Blocked Count in BookedAppointment Page: " + AllAppointments.Count);

                var BlockedAppointments = table.FindElements(By.XPath($".//div[contains(@class, 'k-event')]//div[contains(@title, 'Blocked')]"));
                Console.WriteLine("Blocked Count in MyAppointment Page: " + BlockedAppointments.Count);

                if (AllAppointments.Any(x => x.Text.StartsWith(AppointmentTitle, StringComparison.OrdinalIgnoreCase)) && PageName == bookappointmentpage)
                {
                    Console.WriteLine("Under Bookedappointmentpage");
                    var BookedAppointment = AllAppointments.FirstOrDefault(x => x.Text.Equals(AppointmentTitle, StringComparison.OrdinalIgnoreCase));
                    Console.WriteLine("Under Bookedappointmentpage", BookedAppointment);
                    driver.WaitForTransaction();
                    Actions actions = new Actions(driver);
                    actions.MoveToElement(BookedAppointment).Perform();
                    _webClient.Browser.ThinkTime(2000);
                }
                else if (BlockedAppointments.Any(x => x.Text.StartsWith(AppointmentTitle, StringComparison.OrdinalIgnoreCase)) && PageName == myappointmentpage)
                {
                    Console.WriteLine("Under myappointmentpage");
                    var BookedAppointment = BlockedAppointments.FirstOrDefault(x => x.Text.Equals(AppointmentTitle, StringComparison.OrdinalIgnoreCase));
                    driver.WaitForTransaction();
                    Actions actions = new Actions(driver);
                    actions.MoveToElement(BookedAppointment).Perform();
                    _webClient.Browser.ThinkTime(2000);
                }
                else
                    throw new Exception($"Appointment with name {AppointmentTitle} does not exist.");

                return true;
            });

        }

        public BrowserCommandResult<bool> AddressTypeAhead(string AddressLine1, string fieldName)
        {
            return TestSettings.CurrentPersonaDto.XrmApp.WebClient.Execute(BaseExtensions.GetOptionsInternal($"Search {AddressLine1}"), driver =>
            {

                var inputField = driver.WaitUntilAvailable(By.XPath($"//input[contains(@id, '{fieldName}')]"), "input field not found");

                inputField.SendKeys(AddressLine1);
                _webClient.Browser.ThinkTime(4000);
                var scroller = driver.WaitUntilAvailable(By.XPath($"//div[contains(@class, 'k-list-container') and contains(@id, '{fieldName}')]"), "type ahead are not visible");

                _webClient.Browser.ThinkTime(2000);

                var listItems = scroller.FindElements(By.XPath(".//li"));
                Console.WriteLine("listItems" + listItems.Count);

                foreach (var item in listItems)
                {
                    // driver.executescrip‌t("arguments[0].style.backgroundcolor = 'blue'", item);
                    Console.WriteLine(item.Text);
                }

                if (listItems.Any(x => x.Text.StartsWith(AddressLine1, StringComparison.OrdinalIgnoreCase)))

                {

                    Console.WriteLine("items found");
                    var optionToSelect = listItems.FirstOrDefault(x => x.Text.StartsWith(AddressLine1, StringComparison.OrdinalIgnoreCase));
                    driver.WaitForTransaction();
                    optionToSelect.Click();
                    _webClient.Browser.ThinkTime(3000);

                    System.Console.WriteLine(optionToSelect.Text);

                }
                else
                    throw new Exception($"Address matching to {AddressLine1} does not exist.");
                Console.WriteLine("skipping section method");

                return true;
            });

        }

        public BrowserCommandResult<bool> CompareValue(string fieldName, string AddressLine1, string sectionLabel)
        {
            return TestSettings.CurrentPersonaDto.XrmApp.WebClient.Execute(BaseExtensions.GetOptionsInternal($"Search {AddressLine1}"), driver =>
            {
                var sectionContainer = driver.WaitUntilAvailable(By.XPath(CmcAppElements.Xpath[CmcAppReference.Entity.sectionContainer].Replace("[NAME]", sectionLabel)), "Section Container Not Found");
                driver.WaitForTransaction();
                var inputField = sectionContainer.FindElement(By.XPath($".//input[contains(@id, '{fieldName}')]"));

                // inputField.SendKeys(AddressLine1);

                var FieldValue = inputField.GetAttribute("value");
                Console.WriteLine("Value: " + FieldValue);
                if (FieldValue.Equals(AddressLine1, StringComparison.OrdinalIgnoreCase))
                {
                    Console.WriteLine("field value is same as expected");
                }
                else
                    throw new Exception($"field value is not same as {AddressLine1}");
                // Assert.AreEqual(AddressLine1, FieldValue);                 

                return true;
            });

        }

        public BrowserCommandResult<bool> ClickButtonQuickCreate(string buttonName)
        {
            return TestSettings.CurrentPersonaDto.XrmApp.WebClient.Execute(BaseExtensions.GetOptionsInternal($"click button {buttonName}"), driver =>
            {



                var QuickCreateSection = driver.FindElement(By.XPath("//section[contains(@id, 'quickCreateRoot')]"));

                Console.WriteLine("section found");

                var buttons = QuickCreateSection.FindElements(By.XPath(".//button"));


                if (buttons.Any(x => x.GetAttribute("aria-label").StartsWith(buttonName, StringComparison.OrdinalIgnoreCase)))
                {
                    Console.WriteLine("button found");
                    var buttonToClick = buttons.FirstOrDefault(x => x.GetAttribute("aria-label").StartsWith(buttonName, StringComparison.OrdinalIgnoreCase));
                    Console.WriteLine(buttonToClick.GetAttribute("aria-label"));

                    ((IJavaScriptExecutor)driver).ExecuteScrip‌t("arguments[0].click();", buttonToClick);
                    //  buttonToClick.Click();
                    _webClient.Browser.ThinkTime(2000);
                    // System.Console.WriteLine(buttonToClick.Text);



                }



                return true;
            });




        }

        public BrowserCommandResult<bool> LiveAssist()
        {
            return TestSettings.CurrentPersonaDto.XrmApp.WebClient.Execute(BaseExtensions.GetOptionsInternal($"click live assist link"), driver =>
            {



                var LiveAssist = driver.WaitUntilAvailable(By.XPath("//div[contains(@id, 'Side_Panel')]"), "not found");

                Console.WriteLine("live assist division found");

                var link = LiveAssist.FindElement(By.XPath(".//span"));

                ((IJavaScriptExecutor)driver).ExecuteScrip‌t("arguments[0].click();", link);


                return true;
            });



        }


        public BrowserCommandResult<bool> SelectOptionFromDialog(string fieldName, string optionName)
        {
            return TestSettings.CurrentPersonaDto.XrmApp.WebClient.Execute(BaseExtensions.GetOptionsInternal($"click option {optionName}"), driver =>
            {

                SelectElement list = new SelectElement(driver.FindElement(By.XPath($"//select[contains(@data-id,'{fieldName}')]")));
                Console.WriteLine("Dropdown found");
                _webClient.Browser.ThinkTime(2000);
                list.SelectByText(optionName);
                _webClient.Browser.ThinkTime(2000);
                Console.WriteLine("Selected option is: " + optionName);

                return true;
            });



        }

        public BrowserCommandResult<bool> SaveNew()
        {
            return TestSettings.CurrentPersonaDto.XrmApp.WebClient.Execute(BaseExtensions.GetOptionsInternal($"Click Save button in the view"), driver =>
            {
                //   var div = driver.FindElement(By.XPath("//div[contains(@id, 'outerHeaderContainer')]"));
                var CommandBar = driver.FindElement(By.XPath(".//ul[contains(@aria-label,'Commands') and contains(@data-lp-id, 'commandbar-Form')]"));
                //((IJavaScriptExecutor)driver).ExecuteScrip‌t("arguments[0].style.backgroundColor = 'blue'", CommandBar);

                var listitems = CommandBar.FindElements(By.XPath(".//li"));

                Console.WriteLine(listitems.Count);

                if (listitems.Any(x => x.GetAttribute("title").StartsWith("Save", StringComparison.OrdinalIgnoreCase)))
                {
                    var item = listitems.FirstOrDefault(x => x.GetAttribute("title").StartsWith("Save", StringComparison.OrdinalIgnoreCase));
                    //  driver.WaitForTransaction();
                    item.Click();



                }
                else
                    throw new Exception($"List item is not found");

                return true;
            });

        }
        public bool VerifyReviewBundleMethod(string reviewByBundle, string revieMethod)
        {

            return TestSettings.CurrentPersonaDto.XrmApp.WebClient.Execute(BaseExtensions.GetOptionsInternal($"check for Review Details"), driver =>
            {
                //var reviewElement=  driver.FindElement(By.XPath("//app-review-summary-page/div[2]/div/div[1]/div/div"));
                //if(reviewElement.Text==reviewByBundle)
                //{
                //    return false;
                //}

                var reviewNamEelement = driver.FindElement(By.XPath("//div[contains(@id,'reviewer-status')]"));
                if (reviewNamEelement.Text.Contains(revieMethod))
                {
                    return false;
                }
                return true;
            });
        }

     
public void switchtotab(int tabnum)
        {
            TestSettings.CurrentPersonaDto.XrmApp.WebClient.Execute(BaseExtensions.GetOptionsInternal($"I switch to second browser tab if available"), driver =>
            {
                var tabs = driver.WindowHandles; if (tabs.Count > 1 && tabs.Count >= tabnum)
                {
                    driver.SwitchTo().Window(tabs[tabnum - 1]);
                }
                else
                {
                    Console.WriteLine("Browser window is not available");
                }
                return true;
            });
        }


        public void SwitchSystemview(String viewName)
        {
            TestSettings.CurrentPersonaDto.XrmApp.WebClient.Execute(BaseExtensions.GetOptionsInternal($"I switched the SystemView to (.*)"), driver =>
            {
                _webClient.Browser.ThinkTime(3000);



                try
                {
                    var drpdwn = driver.WaitUntilVisible(By.XPath("//div[@title='Select a view']"));
                    drpdwn.Click();
                    driver.WaitUntilAvailable(By.XPath("//li[@title='" + viewName + "']")).Click();
                    return true;
                }
                catch { Exception e1; return false; }



            });
        }
        public BrowserCommandResult<bool> clickmorecommands(string commandName)
        {
            return TestSettings.CurrentPersonaDto.XrmApp.WebClient.Execute(BaseExtensions.GetOptionsInternal($" click More Commands for Appointment"), driver =>
            {
                _webClient.Browser.ThinkTime(2000);
                try
                {
                    var click = driver.FindElement(By.XPath($"//li[@title='{commandName}']"));
                    click.Click();
                    return true;
                }
                catch
                {
                    var click = driver.FindElement(By.XPath($"//button[@aria-label='{commandName}']"));
                    click.Click();
                    return true;
                }

            });

        }

        public BrowserCommandResult<bool> clickreccommands(string command)
        {
            return TestSettings.CurrentPersonaDto.XrmApp.WebClient.Execute(BaseExtensions.GetOptionsInternal($" click Recurrence command"), driver =>
            {
                var click = driver.FindElement(By.XPath("//button[@aria-label='Recurrence']"));
                click.Click();
                return true;

            });

        }

        public BrowserCommandResult<bool> clickflowcommands(string command)
        {
            return TestSettings.CurrentPersonaDto.XrmApp.WebClient.Execute(BaseExtensions.GetOptionsInternal($" click Flow command"), driver =>
            {
                var click = driver.FindElement(By.XPath("//button[@aria-label='Flow. Run Flow']"));
                click.Click();
                return true;

            });

        }

        public BrowserCommandResult<bool> SwitchToaFrame()
        {
            return TestSettings.CurrentPersonaDto.XrmApp.WebClient.Execute(BaseExtensions.GetOptionsInternal($"Switch to a frame"), driver =>
            {
                var items = driver.FindElement(By.XPath("//div[@data-id='UCIRecurrenceDialog']"));
                //var buttonToClick = items.FirstOrDefault(x => x.GetAttribute("title").Contains(subgridButtonName, StringComparison.CurrentCultureIgnoreCase));
                var buttonToClick = items.GetAttribute("title");
                Console.WriteLine(buttonToClick);
                return true;
            });
        }

        /*public BrowserCommandResult<bool> SwitchToFrame(string frameID)
         {
             return TestSettings.CurrentPersonaDto.XrmApp.WebClient.Execute(BaseExtensions.GetOptionsInternal($"Switch to specific Frame {frameID}"), driver =>
             {


                 driver.SwitchTo().Frame(driver.FindElement(By.XPath($"//div[contains(@data-id,'{frameID}')]")));
                 return true;
             });
         }*/

        public BrowserCommandResult<bool> clickmorecommandsact(string commandName)
        {
            return TestSettings.CurrentPersonaDto.XrmApp.WebClient.Execute(BaseExtensions.GetOptionsInternal($" click More Commands for Appointment"), driver =>
            {
                var click = driver.FindElement(By.XPath("//button[@aria-label='More commands for Activity']"));
                click.Click();
                return true;

            });

        }


        public BrowserCommandResult<bool> Attachment(string File)
        {
            return TestSettings.CurrentPersonaDto.XrmApp.WebClient.Execute(BaseExtensions.GetOptionsInternal($" Upload {File} in the File section"), driver =>
            {
                String localPath = @"TestFile\";
                string currentDir = Environment.CurrentDirectory;
                DirectoryInfo directory = new DirectoryInfo(Path.GetFullPath(Path.Combine(currentDir, @"..\..\" + localPath + File)));
                String path = directory.ToString();
                Console.WriteLine(path);
                driver.FindElement(By.Id("filepickerid")).SendKeys(path);
                _webClient.Browser.ThinkTime(2000);
                Console.WriteLine("files");
                AutoItX.WinClose("Open");
                _webClient.Browser.ThinkTime(2000);

                return true;
            });
        }

        public BrowserCommandResult<bool> ThenISwitchToSpecificFrame(int frameIndex)
        {
            return TestSettings.CurrentPersonaDto.XrmApp.WebClient.Execute(BaseExtensions.GetOptionsInternal($"Switch to specific Frame"), driver =>
            {
                //var frame = driver.FindElement(By.XPath("//div[@role='dialog']"));
                driver.SwitchTo().Frame(frameIndex);
                //((IJavaScriptExecutor)driver).ExecuteScrip‌t("arguments[0].style.backgroundColor = 'blue'", frameName);

                return true;
            });
        }

        public BrowserCommandResult<bool> SelectOptioninDialog(string fieldName, string optionName)
        {
            return TestSettings.CurrentPersonaDto.XrmApp.WebClient.Execute(BaseExtensions.GetOptionsInternal($"click option {optionName}"), driver =>
            {

                SelectElement list = new SelectElement(driver.FindElement(By.XPath($"//select[contains(@aria-label,'{fieldName}')]")));
                Console.WriteLine("Dropdown found");
                _webClient.Browser.ThinkTime(2000);
                list.SelectByText(optionName);
                _webClient.Browser.ThinkTime(2000);
                Console.WriteLine("Selected option is: " + optionName);

                return true;
            });



        }

        public BrowserCommandResult<bool> CLearKendoTextFieldInDialog(string FieldID)
        {
            return TestSettings.CurrentPersonaDto.XrmApp.WebClient.Execute(BaseExtensions.GetOptionsInternal($"I have clear text in {FieldID} Kendo text field in dialog window"), driver =>
            {



                IWebElement inputField;
                if (driver.HasElement(By.Id(FieldID)))
                {
                    inputField = driver.FindElement(By.Id(FieldID));
                    inputField.Clear();
                    System.Console.WriteLine("Field Cleared");
                    return true;



                }
                else { return false; }
            });

        }

        public BrowserCommandResult<bool> SelectKdropdown(String value)
        {
            return TestSettings.CurrentPersonaDto.XrmApp.WebClient.Execute(BaseExtensions.GetOptionsInternal($"I set {value} in the dialog window drop down"), driver =>
            {
                var select = driver.FindElement(By.XPath("//span[@class='k-widget k-dropdown']"));
                Console.WriteLine("Element is selected");
                select.Click();
                _webClient.Browser.ThinkTime(2000);
                IList<IWebElement> listItems = driver.FindElements(By.XPath($"//ul[@id='dpDecisionPublishStatus_listbox']//li[text()='{value}']"));

                _webClient.Browser.ThinkTime(2000);
                for (int i = 0; i < listItems.Count; i++)

                {

                    if ((listItems[i].GetAttribute("textContent").Equals("Published")) || (listItems[i].GetAttribute("textContent").Equals("Not Published")))
                    {

                        listItems[i].Click();
                        break;

                    }

                }
                return true;
            });
        }
    }
}


