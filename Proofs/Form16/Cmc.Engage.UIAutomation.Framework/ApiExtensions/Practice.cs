using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cmc.Engage.UIAutomation.Framework.ApiExtensions
{
    class Practice
    {
        //Code to highlight an element

        //    driver.ExecuteScrip‌t("arguments[0].style.backgroundColor = 'red'", AdvEmptyFields[rowNo]);
        //    Console.WriteLine("Highlighted" + rowNo);

        // _webClient.Browser.ThinkTime(1000);
        //driver.ExecuteScrip‌t("arguments[0].style.backgroundColor = 'blue'", AdvEmptyFields[0]);
        //Console.WriteLine("Highlighted");

        //public BrowserCommandResult<bool> DialogOptionSetAction(string Option, string fieldName)
        //{
        //    return _webClient.Execute(BaseExtensions.GetOptionsInternal($"select option {Option}"), driver =>
        //    {
        //        IWebElement parentElement;
        //        if (driver.HasElement(By.XPath(CmcAppElements.Xpath[CmcAppReference.Dialogs.DialogFooterContainer])))
        //        {
        //            parentElement = driver.FindElement(By.XPath($"//div[contains(@id,'{fieldName}-FieldSectionItemContainer')]"));
        //            // var items = parentElement.FindElements(By.TagName("button"));

        //            var select = parentElement.FindElement(By.XPath($"//select[contains(@id,'{fieldName}')]"));

        //            select.Click();
        //            _webClient.Browser.ThinkTime(2000);

        //            SelectElement Dropdown = new SelectElement(select);
        //            Dropdown.SelectByText(Option);
        //            _webClient.Browser.ThinkTime(2000);
        //            driver.WaitForTransaction();
        //        }

        //        else
        //            throw new NotFoundException($"field with name {fieldName} not found on form.");

        //        return true;
        //    });
        //}
       //[BeforeFeature]
        //public static void BeforeFeature()
        //{

        //}
        //[AfterFeature]
        //public static void AfterFeature()
        //{
        //    PersonaManager.CleanUp();
        //}


    }
}
