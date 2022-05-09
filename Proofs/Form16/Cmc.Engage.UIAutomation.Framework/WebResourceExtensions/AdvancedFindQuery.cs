using Cmc.Engage.UIAutomation.Framework.ApiExtensions;
using Cmc.Engage.UIAutomation.Framework.XPath;
using Microsoft.Dynamics365.UIAutomation.Api.UCI;
using Microsoft.Dynamics365.UIAutomation.Browser;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Cmc.Engage.UIAutomation.Framework.WebResourceExtensions
{
    public class AdvancedFindQuery : BaseWebResource
    {
        public AdvancedFindQuery(WebClient webClient) : base(webClient)
        {
        }

        public void Save()
        {
            //if (_webClient.Browser.Driver.HasElement(By.XPath("//a[@aria-describedby='Mscrm.AdvancedFind.Groups.View.Save_ToolTip']")))
            //{
            //    var tooltip = _webClient.Browser.Driver.FindElement(By.XPath("//a[@aria-describedby='Mscrm.AdvancedFind.Groups.View.Save_ToolTip']"));

            //   // tooltip.Click();
            //}
            //else if (_webClient.Browser.Driver.HasElement(By.XPath("//a[@id='Mscrm.AdvancedFind.Groups.View.Save-Large']")))
            //{

            //    var Large = _webClient.Browser.Driver.FindElement(By.XPath("//a[@id='Mscrm.AdvancedFind.Groups.View.Save-Large']"));
            //    Large.Click();
            //}
            //else
            //    throw new Exception("not found");
            
        }

        public void Close()
        {
            _webClient.Browser.Driver.Close();
        }

        public BrowserCommandResult<bool> DropDownFilter(string fieldName, string fieldTextToSelect)
        {
            return TestSettings.CurrentPersonaDto.XrmApp.WebClient.Execute(BaseExtensions.GetOptionsInternal($"Select option in {fieldName} field"), driver =>
            {
                IWebElement SelectContainer;

                // SelectFrame("contentIFrame0");
                _webClient.Browser.ThinkTime(2000);
                driver.WaitForPageToLoad();

                if (driver.HasElement(By.XPath(CmcAppElements.Xpath[CmcAppReference.AdvancedFind.SelectContainerByID].Replace("[NAME]", fieldName))))

                    SelectContainer = driver.WaitUntilAvailable(By.XPath(CmcAppElements.Xpath[CmcAppReference.AdvancedFind.SelectContainerByID].Replace("[NAME]", fieldName)));

                else if (driver.HasElement(By.XPath(CmcAppElements.Xpath[CmcAppReference.AdvancedFind.SelectContainerByClass].Replace("[NAME]", fieldName))))

                    SelectContainer = driver.WaitUntilAvailable(By.XPath(CmcAppElements.Xpath[CmcAppReference.AdvancedFind.SelectContainerByClass].Replace("[NAME]", fieldName)));
                else
                    throw new Exception($"Select container {fieldName} not found");

                SelectContainer.Click();
                _webClient.Browser.ThinkTime(2000);
                SelectElement Dropdown = new SelectElement(SelectContainer);
                Dropdown.SelectByText(fieldTextToSelect);
                driver.WaitForTransaction();
                return true;
            });
        }
        public BrowserCommandResult<bool> FilterControls(string fieldTextToSelect, string fieldGroup, int rowNo)
        {
            return TestSettings.CurrentPersonaDto.XrmApp.WebClient.Execute(BaseExtensions.GetOptionsInternal($"Select option in {fieldTextToSelect} field"), driver =>
            {
                driver.WaitForPageToLoad();
                var AdvfindDetails = driver.WaitUntilAvailable(By.XPath($"//div[contains(@id,'AdvFindDetailed')]"), "Advanced Find ribbon not found");
               
                _webClient.Browser.ThinkTime(3000);

                var AdvEmptyFields = AdvfindDetails.FindElements(By.XPath("//div[contains(@class,'EmptyField')]"));
                Console.WriteLine(AdvEmptyFields.Count);
                //var element = driver.findElement(By.xpath("xPath goes here"));
              
                _webClient.Browser.ThinkTime(2000);

                

                Console.WriteLine("AdvEmptyFields found");
              
                if (!string.IsNullOrEmpty(fieldGroup))
                {

                    var AutoShowFilter = AdvEmptyFields[rowNo].FindElement(By.XPath(".//div[contains(@class,'AutoShow') and @title='Select']"));
                    Console.WriteLine(AdvEmptyFields.Count);


                    AutoShowFilter.Click(); 
                    driver.WaitForTransaction();
                    Console.WriteLine("Click");

                    IList<IWebElement> SelectOptions = AutoShowFilter.FindElements(By.XPath($"//select/optgroup[contains(@label,'{fieldGroup}')]/option"));
                    Console.WriteLine("SelectOptions");
                    for (int i = 0; i <= SelectOptions.Count; i++)
                    {
                        string option = SelectOptions[i].Text;
                        if (option.Equals(fieldTextToSelect, StringComparison.OrdinalIgnoreCase))
                        {

                            SelectOptions[i].Click();
                            Console.WriteLine(SelectOptions[i].Text);
                            driver.WaitForTransaction();
                            Console.WriteLine("Option selected");

                            _webClient.Browser.ThinkTime(2000);
                            break;
                        }
                      

                    }
                    driver.WaitForTransaction();
                }

                return true;
            });
        }


        public BrowserCommandResult<bool> SubFilters(string fieldTextToSelect, string Fieldname)
        {
            return TestSettings.CurrentPersonaDto.XrmApp.WebClient.Execute(BaseExtensions.GetOptionsInternal($"Select option in {fieldTextToSelect} field"), driver =>
            {

                driver.WaitForPageToLoad();
                var AdvfindDetails = driver.WaitUntilAvailable(By.XPath($"//div[contains(@id,'AdvFindDetailed')]"));

                if (!String.IsNullOrEmpty(Fieldname) && Fieldname != "Select")
                {

                    var AutoShowFilter = AdvfindDetails.FindElement(By.XPath($"//div[contains(@class,'AutoShow') and @title='{Fieldname}']"));
                    AutoShowFilter.Click();
                    var SelectContainer = AutoShowFilter.FindElement(By.XPath(".//select"));

                    Console.WriteLine("SelectContainer found");

                    SelectElement Options = new SelectElement(SelectContainer);
                    Options.SelectByText(fieldTextToSelect);

                }
                return true;
            });
        }


        public BrowserCommandResult<bool> FilterInput(string fieldTextToEnter, string Fieldname)
        {
            return TestSettings.CurrentPersonaDto.XrmApp.WebClient.Execute(BaseExtensions.GetOptionsInternal($"Enter {fieldTextToEnter} in advanced find field"), driver =>
            {
                driver.WaitForPageToLoad();
                var AdvfindDetails = driver.WaitUntilAvailable(By.XPath($"//div[contains(@id,'AdvFindDetailed')]"));


                Console.WriteLine("AdvfindDetails found");

                if (!String.IsNullOrEmpty(Fieldname))
                {

                    var AutoShowFilter = AdvfindDetails.FindElement(By.XPath($".//div[contains(@class,'AutoShow') and @title='{Fieldname}']"));
                    Console.WriteLine("AutoShowFilter found");

                    AutoShowFilter.Click();
                    Console.WriteLine("AutoShowFilter clicked");

                    var InputContainer = AutoShowFilter.FindElement(By.XPath(".//input"));

                    Console.WriteLine("InputContainer found");
                    if (InputContainer != null)
                        InputContainer.SendKeys(fieldTextToEnter);

                    else
                        throw new Exception("Input field not found");

                }
                return true;
            });
        }

        public BrowserCommandResult<bool> RibbonItem(string buttonName, string Groupname)
        {
            return TestSettings.CurrentPersonaDto.XrmApp.WebClient.Execute(BaseExtensions.GetOptionsInternal($"click {buttonName} in advanced find ribbon"), driver =>
            {
              //  driver.WaitForPageToLoad();
               // driver.SwitchTo().DefaultContent();
                var AdvfindRibbonContainer = driver.WaitUntilAvailable(By.XPath("//div[contains(@id,'Mscrm.Ribbon')]"));
                Console.WriteLine("AdvfindRibbonContainer found");
                _webClient.Browser.ThinkTime(3000);

                var listItems = AdvfindRibbonContainer.FindElements(By.XPath(".//ul[@id ='Mscrm.AdvancedFind']//li"));

                Console.WriteLine("listItems found");

                if (listItems.Any(x => x.GetAttribute("id").Equals($"Mscrm.AdvancedFind.Groups.{Groupname}", StringComparison.OrdinalIgnoreCase)))
                {
                    var item = listItems.FirstOrDefault(x => x.GetAttribute("id").Equals($"Mscrm.AdvancedFind.Groups.{Groupname}", StringComparison.OrdinalIgnoreCase));
                    Console.WriteLine("item found");

                    var buttons = item.FindElements(By.TagName("a"));
                    Console.WriteLine("buttons found");
                   
                  
                    if (buttons.Any(x => x.GetAttribute("id").Contains($"Mscrm.AdvancedFind.Groups.{Groupname}.{buttonName}", StringComparison.OrdinalIgnoreCase)))
                    {

                        var buttonToClick = buttons.FirstOrDefault(x => x.GetAttribute("id").Contains($"Mscrm.AdvancedFind.Groups.{Groupname}.{buttonName}", StringComparison.OrdinalIgnoreCase));

                        buttonToClick.Click();

                        Console.WriteLine("buttonToClick is clicked");

                        driver.WaitForTransaction();
                    }
                    else
                        throw new NotFoundException($"{buttonName} button not found");
                }
                else
                    throw new NotFoundException($"{Groupname} not found in the ribbon");



                return true;
            });
        }
        public BrowserCommandResult<bool> CompareResults(string RecordName)
        {
            return TestSettings.CurrentPersonaDto.XrmApp.WebClient.Execute(BaseExtensions.GetOptionsInternal($"verify if {RecordName} is present in  advanced find results"), driver =>
            {


                driver.SwitchTo().Frame("contentIFrame0");

                driver.WaitForTransaction();

                var searchResultsDiv = driver.WaitUntilAvailable(By.XPath("//span[@id ='searchResults']"), "searchResultsDiv not found");

                driver.SwitchTo().Frame("resultFrame");
                driver.WaitForTransaction();

                IWebElement AdvfindResultContainer = driver.WaitUntilAvailable(By.XPath("//div[(@type ='crmGrid')]"));
                Console.WriteLine("AdvfindResultContainer found");
            // AdvfindResultContainer.Click();
            IWebElement tableBody = AdvfindResultContainer.FindElement(By.XPath("//table[@class ='ms-crm-List-Data']//tbody"));

                Console.WriteLine("tableBody found");

                IList<IWebElement> TableCells = tableBody.FindElements(By.XPath(".//td//a[@class ='ms-crm-List-Link']"));

                Console.WriteLine("TableCells found");

                Console.WriteLine(TableCells.Count);


                if (TableCells.Any(x => x.Text.Equals(RecordName, StringComparison.OrdinalIgnoreCase)))
                {
                    var record = TableCells.FirstOrDefault(x => x.Text.Equals(RecordName, StringComparison.OrdinalIgnoreCase));
                    System.Console.WriteLine("record found");
                    String ActualRecordName = record.Text;
                    Console.WriteLine(ActualRecordName);
                    Assert.AreEqual(RecordName, ActualRecordName);

                    driver.WaitForTransaction();



                }

                else
                    throw new NotFoundException($"record not found");





                return true;
            });
        }

    }

    }
