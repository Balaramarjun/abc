
using Cmc.Engage.UIAutomation.Framework.XPath;
using Microsoft.Dynamics365.UIAutomation.Api.UCI;
using Microsoft.Dynamics365.UIAutomation.Browser;
using OpenQA.Selenium;
using System;
using System.Linq;


using Microsoft.VisualStudio.TestTools.UnitTesting;
using Cmc.Engage.UIAutomation.Framework;
using OpenQA.Selenium.Support.UI;
using System.Collections.Generic;
using OpenQA.Selenium.Interactions;
using System.Collections.ObjectModel;

namespace Cmc.Engage.UIAutomation.Framework.ApiExtensions
{
    public class CmcGrid : Grid
    {
        private readonly WebClient _webClient;
        public CmcGrid(WebClient client) : base(client)
        {
            _webClient = client;
        }

        public BrowserCommandResult<bool> SortEx(string columnName, int thinkTime = Constants.DefaultThinkTime)
        {
            _webClient.Browser.ThinkTime(thinkTime);

            return _webClient.Execute(BaseExtensions.GetOptionsInternal($"Sort by {columnName}"), driver =>
            {
                //IWebElement rows;


                //driver.WaitUntilAvailable(By.XPath(AppElements.Xpath[AppReference.Grid.Container]));

                // var rows = driver.FindElements(By.ClassName("wj-row"));


                IWebElement sortCol;
                System.Console.WriteLine("sort");
                if (driver.HasElement(By.XPath(AppElements.Xpath[AppReference.Grid.GridSortColumn])))
                {
                    sortCol = driver.FindElement(By.XPath(AppElements.Xpath[AppReference.Grid.GridSortColumn].Replace("[COLNAME]", columnName)));

                }
                else
                {
                    throw new NotFoundException($"columnName Container for {columnName} not found on grid.");
                }
                System.Console.WriteLine("sort column container found");

                var cols = sortCol.FindElements(By.XPath($"//div[@title = '{columnName}']"));
                //  var cols = sortCol.FindElements((By.XPath( $"//div[@class ='grid-header-text'] and div[text() = '{columnName}']")));

                System.Console.WriteLine("cols clicked");
                if (cols.Any(x => x.GetAttribute("class").Equals("grid-header-text")))
                {
                    cols.FirstOrDefault(x => x.GetAttribute("class").Equals("grid-header-text")).Click(true);
                    driver.WaitForTransaction();

                    System.Console.WriteLine("cols clicked again");
                }
                return true;

            });

        }

        public BrowserCommandResult<bool> OpenRecordByText(string RecordName, bool checkRecord = false)
        {


            return TestSettings.CurrentPersonaDto.XrmApp.WebClient.Execute(BaseExtensions.GetOptionsInternal($"Click Field {RecordName} and navigatgate"), driver =>
            {

              

                var rows = driver.FindElements(By.ClassName("wj-row"));

                //TODO: The grid only has a small subset of records. Need to load them all
                foreach (var row in rows)
                {
                    if (!string.IsNullOrEmpty(row.GetAttribute("data-lp-id")))
                    {
                        if (rows!=null)
                        {
                            var tag = checkRecord ? "div" : "a";
                            var RowText = row.FindElement(By.TagName(tag));
                            if (RowText.Text.Equals(RecordName, StringComparison.OrdinalIgnoreCase))
                            {

                                RowText.Click(true);
                                driver.WaitForTransaction();
                                System.Console.WriteLine(RowText.Text);

                            }

                            row.FindElement(By.TagName(tag)).Click();
                            break;
                        }

                        
                    }
                }

           

                driver.WaitForTransaction();

                return true;

            });
        }

        public BrowserCommandResult<bool> OpenRecordInSpecificSection(int index, string sectionLabel, int thinkTime = Constants.DefaultThinkTime, bool checkRecord = false)
        {
            _webClient.Browser.ThinkTime(thinkTime);

            return _webClient.Execute(BaseExtensions.GetOptionsInternal($"Open Record in the grid in {sectionLabel}"), driver =>
            {
               

            IWebElement parentElement;
                if (driver.HasElement(By.XPath(CmcAppElements.Xpath[CmcAppReference.Entity.sectionContainer].Replace("[NAME]", sectionLabel))))
                {

                    parentElement = driver.WaitUntilAvailable(By.XPath(CmcAppElements.Xpath[CmcAppReference.Entity.sectionContainer].Replace("[NAME]", sectionLabel)));
                }
                else if (driver.HasElement(By.XPath($"//div[contains(@id,'_{sectionLabel}')]")))
                {
                    parentElement = driver.WaitUntilAvailable(By.XPath(($"//div[contains(@id,'_{sectionLabel}')]")));
                    Console.WriteLine("Div found");
                }
                else
                    throw new NotFoundException($"Subgrid {sectionLabel} not found on form.");

                // var control = parentElement.FindElement(By.XPath(CmcAppElements.Xpath[CmcAppReference.Grid.Container]));
                IWebElement control;
                //driver.ExecuteScrip‌t("arguments[0].style.backgroundColor = 'blue'", control);
                if(parentElement.HasElement(By.XPath(".//div[@data-type=\"Grid\"]")))
                {
                    control = parentElement.FindElement(By.XPath(".//div[@data-type=\"Grid\"]"));
                }
                else if(parentElement.HasElement(By.XPath(".//div[@data-type=\"List\"]")))
                {
                    control = parentElement.FindElement(By.XPath(".//div[@data-type=\"List\"]"));
                }
                else
                {
                    throw new NotFoundException($"Subgrid {sectionLabel} not found on form.");
                }
                var xpathToFind = checkRecord
                        ? $".//div[@data-id='cell-{index}-1']"
                        : $".//div[contains(@data-id, 'cell-{index}')]//a";
                if (control.HasElement(By.XPath(xpathToFind)))
                {
                      control.FindElement(By.XPath(xpathToFind)).Click();
                    //var optionToClick = control.FindElement(By.XPath(xpathToFind));
                    //((IJavaScriptExecutor)driver).ExecuteScrip‌t("arguments[0].click();", optionToClick);
                   // driver.WaitForTransaction();
                   
                     _webClient.Browser.ThinkTime(3000);
                }
                else if(control.HasElement(By.XPath($".//div//ul//li//div//a")))
                {
                    Console.WriteLine("Bala found");
                    control.FindElement(By.XPath($".//div//ul//li//div//a")).Click();
                    _webClient.Browser.ThinkTime(3000);
                }
                else
                    throw new NotFoundException("No records are present in the grid");

                return true;

            });

        }


        //Wave2 Issues

        public new void OpenRecord(int index)

        {
            _webClient.Browser.ThinkTime(2000);
            _webClient.Execute(BaseExtensions.GetOptionsInternal($"open first Record"), driver =>
            {
                var firstrecord = driver.WaitUntilAvailable(By.XPath("//div[contains(@class, 'wj-cell')][contains(@data-lp-id, 'Mscrm')][@tabindex='" + index + "']"));

                if (firstrecord.GetAttribute("aria-selected").Equals("false"))
                {
                    firstrecord.Click();
                }
                
                try
                {
                    if (firstrecord.GetAttribute("aria-selected").Equals("true"))
                    {
                        new Actions(driver).DoubleClick(firstrecord).Perform();
                    }
                }
                catch { StaleElementReferenceException e1; }
                return true;
            });
        }


        public new void HighLightRecord(int num)
        {
            _webClient.Browser.ThinkTime(2000);

            _webClient.Execute(BaseExtensions.GetOptionsInternal($"I select record no.(.*) in the grid"), driver =>
            {
                //var firstrecord = driver.FindElement(By.XPath("//div[contains(@class, 'wj-cell')][contains(@data-lp-id, 'Mscrm')][@tabindex='" + num + "']"));

                var record = driver.WaitUntilAvailable(By.XPath("//div[contains(@class, 'wj-cell')][contains(@data-lp-id, 'Mscrm')][@data-id='cell-" + num + "-1']"));
                record.Click();
                _webClient.Browser.ThinkTime(2000);
                return true;
            });

        }
    }
}
