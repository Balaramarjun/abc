using Microsoft.Dynamics365.UIAutomation.Browser;
using OpenQA.Selenium;

namespace Cmc.Engage.UIAutomation.Framework.ApiExtensions
{
    public class BaseExtensions
    {
        public static BrowserCommandOptions GetOptionsInternal(string commandName)
        {
            return new BrowserCommandOptions(Constants.DefaultTraceSource,
                commandName,
                0,
                0,
                null,
                true,
                typeof(NoSuchElementException), typeof(StaleElementReferenceException));
        }
    }
}