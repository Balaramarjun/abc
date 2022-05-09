using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cmc.Engage.UIAutomation.Framework.Persona;
using TechTalk.SpecFlow;
using Cmc.Engage.UIAutomation.Framework;
using OpenQA.Selenium;

namespace Cmc.Engage.UIAutomation.SpecBindings.Hooks
{
    [Binding]
    public class TestCaseEventHandler
    {

        [AfterScenario]
        public static void AfterTestScenario(ScenarioContext scenarioContext)
        {
            if (scenarioContext.ScenarioExecutionStatus != ScenarioExecutionStatus.OK)
            {
                var driver = TestSettings.CurrentPersonaDto.XrmApp.Driver;

                    Screenshot image = ((ITakesScreenshot)driver).GetScreenshot();

                //Save the screenshot
                image.SaveAsFile($"../../ScreenShots/Screenshot-{scenarioContext.ScenarioInfo.Title}" + System.DateTime.Now.ToString("yyyyMMddHHmmssFFF") + ".jpeg", ScreenshotImageFormat.Jpeg);


                PersonaManager.CleanUp();
            }
            

        }

        
        [AfterFeature]
        public static void AfterTestFeature()
        {
            PersonaManager.CleanUp();
        }

      
    }

}
