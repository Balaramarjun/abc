using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cmc.Engage.UIAutomation.Framework.ApiExtensions;
using Microsoft.Dynamics365.UIAutomation.Api.UCI;
using OpenQA.Selenium;

namespace Cmc.Engage.UIAutomation.Framework.WebResourceExtensions
{
    public class Connections : BaseWebResource
    {
        private readonly string _ConnectionsFrameName = "WebResource_ConnectionsDashboard";
        public Connections(WebClient webClient) : base(webClient)
        {
          
        }
        public void InternalConnectionButton()
        {
            SelectFrame(_ConnectionsFrameName);
            XrmApp.ThinkTime(2000);
            AppRootButton("Internal Connections");
            XrmApp.ThinkTime(2000);
            XrmApp.Driver.SwitchTo().DefaultContent();
            XrmApp.ThinkTime(2000);
        }


    }
}
