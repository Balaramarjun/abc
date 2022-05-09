using Cmc.Engage.UIAutomation.Framework;
using Cmc.Engage.UIAutomation.Framework.CustomAttributes;
using Microsoft.Dynamics365.UIAutomation.Api.UCI;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Cmc.Engage.UIAutomation.Tests.Contacts
{


    [TestClass]
    public class MultiValueOptionset : TestBase
    {
        [TestMethod]
        public void SelectValue() 
        
        {
            //Login
            SwitchPersona("Advisor");
            XrmApp.ThinkTime(2000);

            //Navigate to existing Contact
            XrmApp.Navigation.OpenSubArea("Constituents", "Contacts");
            XrmApp.Grid.Search("contact");
            XrmApp.Grid.OpenRecord(0);
            string[] Values = { "Recommender" };
            XrmApp.Entity.SetValue(new MultiValueOptionSet {Name = "mshied_contacttype", Values =Values});
            XrmApp.ThinkTime(2000);


        }
    }
}
