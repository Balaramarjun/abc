using Cmc.Engage.UIAutomation.Framework.ApiExtensions;
using Microsoft.Dynamics365.UIAutomation.Api.UCI;
using OpenQA.Selenium;

namespace Cmc.Engage.UIAutomation.Framework.WebResourceExtensions
{
    public class ViewPicker : BaseWebResource
    {
        private readonly string _viewPickerFrameName = "WebResource_viewPicker";

        public ViewPicker(WebClient webClient) : base(webClient)
        {
        }

        public string ClickEditQuery()
        {
            SelectFrame(_viewPickerFrameName);
            XrmApp.ThinkTime(2000);
            var advancedFindWindowHandle = XrmApp.OpenWindow(() => { AppRootButton("Create/Edit Query"); });
            return advancedFindWindowHandle;
        }

        public void ClickUseExistingViewButton()
        {
            SelectFrame(_viewPickerFrameName);
            XrmApp.ThinkTime(2000);
            AppRootButton("Use Existing View");
            XrmApp.ThinkTime(2000);
        }

        public void SelectExistingView(string viewName)
        {
            var savedQuerydropdown = XrmApp.Driver.FindElement(By.ClassName("k-input"));
            savedQuerydropdown.SendKeys(viewName);
            savedQuerydropdown.SendKeys(Keys.Enter);
            XrmApp.ThinkTime(2000);
        }

        public void ClickUseQueryButton()
        {
            AppRootButton("Use Query");
            XrmApp.ThinkTime(4000);
            XrmApp.Driver.SwitchTo().DefaultContent();
            XrmApp.ThinkTime(2000);
        }

        public void SelectExistingViewInQuerySection(string viewName)
        {
            var savedQuerydropdown1 = XrmApp.Driver.FindElement(By.XPath("//*[@class='k-input'][normalize-space()='']"));
            savedQuerydropdown1.Click();
            XrmApp.ThinkTime(2000);
            var savedQuerydropdown = XrmApp.Driver.FindElement(By.XPath("//*[@class='k-textbox'][@aria-disabled='false']"));
            savedQuerydropdown.SendKeys(viewName);
            XrmApp.ThinkTime(2000);
            savedQuerydropdown.SendKeys(Keys.Enter);
            XrmApp.ThinkTime(2000);
        }

    }
}