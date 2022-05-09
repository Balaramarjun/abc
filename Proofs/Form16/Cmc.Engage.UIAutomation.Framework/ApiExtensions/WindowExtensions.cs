using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using Microsoft.Dynamics365.UIAutomation.Api.UCI;

namespace Cmc.Engage.UIAutomation.Framework.ApiExtensions
{
    public static class WindowExtensions
    {
        public static string OpenWindow(this XrmApp xrmApp, Action commandToOpenWindow)
        {
            var webDriver = TestSettings.CurrentPersonaDto.XrmApp.WebClient.Browser.Driver;
            // Get the list of existing window handles.
            string foundHandle = null;
            var originalWindowHandle = webDriver.CurrentWindowHandle;
            IList<string> existingHandles = webDriver.WindowHandles;

            //Invoke the command to open the window
            commandToOpenWindow.Invoke();

            xrmApp.ThinkTime(8000);


            // Use a timeout. Alternatively, you could use a WebDriverWait
            // for this operation.
            var timeout = DateTime.Now.Add(TimeSpan.FromSeconds(5));
            while (DateTime.Now < timeout)
            {
                // This method uses LINQ, so it presupposes you are running on
                // .NET 3.5 or above. Alternatively, it's possible to do this
                // without LINQ, but the code is more verbose.
                IList<string> currentHandles = webDriver.WindowHandles;
                IList<string> differentHandles = currentHandles.Except(existingHandles).ToList();
                if (differentHandles.Count > 0)
                {
                    // There will ordinarily only be one handle in this list,
                    // so it should be safe to return the first one here.
                    foundHandle = differentHandles[0];
                    break;
                }

                // Sleep for a very short period of time to prevent starving the driver thread.
                Thread.Sleep(250);
            }

            if (string.IsNullOrEmpty(foundHandle)) throw new Exception("didn't find popup window within timeout");

            webDriver.SwitchTo().Window(foundHandle);
            return foundHandle;
        }

        public static void SwtichWindow(this CmcXrmApp xrmApp, string windowHandle)
        {
            xrmApp.Driver.SwitchTo().Window(windowHandle);
        }
    }
}