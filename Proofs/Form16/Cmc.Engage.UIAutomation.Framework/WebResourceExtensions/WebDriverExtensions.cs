using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.ObjectModel;

namespace Cmc.Engage.UIAutomation.Framework.Extensions
{
    public  static class WebDriverExtensions
    {
        public new static IWebElement FindElementWithWait(this IWebDriver driver, By by)
        {
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(5));
            // return wait.Until(drv => (drv.FindElement(by)));
            // return driver.FindElement(by);
            return wait.Until(ExpectedConditions.ElementExists(by));
        }
        public new static ReadOnlyCollection<IWebElement> FindElementsWithWait(this IWebDriver driver, By by)
        {
                var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(5));
                return wait.Until(drv => (drv.FindElements(by).Count > 0) ? drv.FindElements(by) : null);
        }
        
    }
}
