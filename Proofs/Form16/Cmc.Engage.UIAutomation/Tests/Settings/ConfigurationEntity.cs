using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cmc.Engage.UIAutomation.Framework;
using Cmc.Engage.UIAutomation.Framework.CustomAttributes;
using Microsoft.Dynamics365.UIAutomation.Api.UCI;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Cmc.Engage.UIAutomation.Framework.ApiExtensions;
using Cmc.Engage.UIAutomation.Framework.WebResourceExtensions;

namespace Cmc.Engage.UIAutomation.Tests.Settings
{
    [TestClass]
    public class ConfigurationEntity : TestBase
    {
        
    

        [TestMethod]
        [TestCategory("Regression")]
        [ExcelDataSource("Contacts", "Configuration", "UpdateLifeCycleBPF")]
        public void UpdateLifeCycleBPF(string area, string subArea, string ConnectionLookup,
             string AccountName, string RoleLookup)

        {
            SwitchPersona("Advisor");
            XrmApp.ThinkTime(2000);
            XrmApp.Navigation.OpenSubArea(area, subArea);
            XrmApp.Grid.OpenRecord(0);
            XrmApp.Entity.SelectTab("Lifecycle BPF");
            XrmApp.Entity.SetValue(new OptionSet{Name = "", Value = "" });
           
        }

    }
}
