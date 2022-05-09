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


namespace Cmc.Engage.UIAutomation.Tests.Contacts
{
    [TestClass]
    public class InternalConnection : TestBase
    {

        [TestMethod]
        [TestCategory("Regression")]
        [ExcelDataSource("Contacts", "InternalConnection", "AddConnection")]
        public void TestConnection(string area, string subArea, string ConnectionLookup, 
             string AccountName, string RoleLookup
           
       )
        {
            //Login
            SwitchPersona("Advisor");
            XrmApp.ThinkTime(2000);

            //Navigate to existing Contact
            XrmApp.Navigation.OpenSubArea(area, subArea);
            XrmApp.Grid.OpenRecord(0);
            XrmApp.ThinkTime(2000);
          
     
            XrmApp.ThinkTime(2000);

            //Create New Connection & Save
            XrmApp.CommandBar.ClickCommand("Connect"); 
            XrmApp.Entity.SetValue(new LookupItem { Name = ConnectionLookup, Value = AccountName });
            XrmApp.ThinkTime(2000);
            XrmApp.Lookup.Search(new LookupItem { Name = RoleLookup }, "Student Worker");

            //XrmApp.Entity.SearchLookupField(new LookupItem { Name = RoleLookup }, "Student Worker");
           
            
            XrmApp.Entity.Save();

            //Navigate back to same Contact
             XrmApp.Navigation.OpenSubArea(area, subArea);
             XrmApp.Grid.OpenRecord(0);

            //select role & save Connection
            XrmApp.Connections.InternalConnectionButton();
            XrmApp.Entity.VerifyConnection("Active Connections", "Account Connection Student Worker");
            
            //Additional methods created or explored in this test case 
            //XrmApp.Entity.LookupRelatedEntityEx(ConnectionLookup, EntityName);
            //XrmApp.ThinkTime(2000);
            //XrmApp.Entity.SearchLookupField(new LookupItem { Name = RoleLookup }, "Student Worker");



        }
    }
}
