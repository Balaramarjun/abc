using Microsoft.Dynamics365.UIAutomation.Api.UCI;
using Microsoft.Dynamics365.UIAutomation.Browser;
using OpenQA.Selenium;
using System;
using System.Linq;

namespace Cmc.Engage.UIAutomation.Framework.WebResourceExtensions
{
    public class EntityPicker : BaseWebResource
    {
        public EntityPicker(WebClient webClient) : base(webClient)
        {
        }

        public void SetEntity(string entityName)
        {
            SelectFrame("WebResource_EntityPicker");
            var entityDropdown = _webClient.Browser.Driver.FindElement(By.ClassName("k-input"));
            entityDropdown.SendKeys(entityName);
            entityDropdown.SendKeys(Keys.Enter);
            _webClient.Browser.Driver.SwitchTo().DefaultContent();
        }

        public void SetKendoEntity(string entityName, string fieldName)
        {
            var entityDropdown = _webClient.Browser.Driver.FindElement(By.XPath($"//div[contains(@data-id,'{fieldName}.fieldControl_container')]"));
            if (entityDropdown != null)
            {              
                entityDropdown.Click();
                _webClient.Browser.ThinkTime(2000);
                var input = _webClient.Browser.Driver.FindElement(By.ClassName("k-list-filter"));   
                var textBox = _webClient.Browser.Driver.WaitUntilAvailable((By.ClassName("k-textbox")));
                
                textBox.SendKeys(entityName);
                _webClient.Browser.ThinkTime(1000);
                textBox.SendKeys(Keys.Enter);
                _webClient.Browser.ThinkTime(2000);
            }
            
        }
        public void SelectActivity(string activityName)
        {
            SelectFrame("WebResource_ActivitiesCompletedTimeline");
            var ActivityDropdown = _webClient.Browser.Driver.FindElement(By.ClassName("k-input"));
            ActivityDropdown.Click();
            
            _webClient.Browser.Driver.SwitchTo().DefaultContent();
        }
        public void SelectInteractionActivity(string buttonName, string sectionLabel)
        {
            var sectionContainer = _webClient.Browser.Driver.WaitUntilAvailable(By.XPath($"//section[contains(@aria-label, '{sectionLabel}')]"), "Section Container Not Found");
        
            Console.WriteLine("Section found.");
            SelectFrame("WebResource_ActivitiesCompletedTimeline");
    
            var ActivityDivision = _webClient.Browser.Driver.WaitUntilAvailable((By.XPath(".//div[contains(@id, 'timeline')]")), "Division not found");
           
            var ButtonList = ActivityDivision.FindElements(By.XPath(".//input"));

            if (ButtonList.Any(x => x.GetAttribute("aria-label").Equals(buttonName, StringComparison.OrdinalIgnoreCase)))
            {
                var buttonToClick = ButtonList.FirstOrDefault(x => x.GetAttribute("aria-label").Equals(buttonName, StringComparison.OrdinalIgnoreCase));
                _webClient.Browser.Driver.ExecuteScrip‌t("arguments[0].style.backgroundColor = 'blue'", buttonToClick);
                buttonToClick.Click();
                _webClient.Browser.Driver.WaitForTransaction();

            }

            else
                throw new Exception($"Buttom to click {buttonName} not found in the section");

        }

      
        }
}