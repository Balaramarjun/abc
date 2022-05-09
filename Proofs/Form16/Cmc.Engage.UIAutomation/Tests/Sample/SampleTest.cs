using System;
using Cmc.Engage.UIAutomation.Framework;
using Cmc.Engage.UIAutomation.Framework.CustomAttributes;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Cmc.Engage.UIAutomation.Tests.Trips
{
    /// <summary>
    ///     Summary description for CreateContact
    /// </summary>
    [TestClass]
    public class SampleTest : TestBase
    {
        /// <summary>
        ///     Gets or sets the test context which provides
        ///     information about and functionality for the current test run.
        /// </summary>
        public TestContext TestContext { get; set; }

        [TestMethod]
        [TestCategory("Trip")]
        [TestCategory("SmokeTest")]
        [TestCategory("Regression")]
        [ExcelDataSource("Sample", "Account", "Test1")]
        public void CreateAccount_Test(string testName,
            string name
        )
        {
            SwitchPersona("Advisor");
            XrmApp.Navigation.OpenSubArea("Constituents", "Accounts");
            XrmApp.CommandBar.ClickCommand("New");
            var accountName = name + TestSettings.GetRandomString(3, 5);
            XrmApp.Entity.SetValue("name", accountName);

            XrmApp.Entity.Save();

            SwitchPersona("Reviewer");
            XrmApp.Navigation.OpenSubArea("Constituents", "Accounts");
            XrmApp.Grid.Search(accountName);
            XrmApp.Grid.OpenRecord(0);
            XrmApp.Entity.SetValue("name", name + TestSettings.GetRandomString(3, 5));
            XrmApp.Entity.Save();
        }

        [TestMethod]
        [ExcelDataSource("Sample", "Contact")]
        public void CreateContact_Test(string testName,
            string firstName,
            string lastName,
            string email,
            DateTime birthDate,
            int mobilePhone,
            string contactType
        )
        {
            SwitchPersona("Advisor");
            XrmApp.Navigation.OpenSubArea("Constituents", "Contacts");
            XrmApp.CommandBar.ClickCommand("New");
            //XrmApp.Entity.SelectForm("Contact(Engage)");
            XrmApp.Entity.SetValue("firstname", firstName);
            XrmApp.Entity.SetValue("lastname", lastName);
            XrmApp.Entity.SetValue("emailaddress1", email);
            XrmApp.Entity.SetValue("mobilephone", mobilePhone.ToString());
            //XrmApp.Entity.SetValueInternal(new MultiValueOptionSet
            //{
            //    Name = "mshied_contacttype",
            //    Values = new string[] { contactType }
            //});

            XrmApp.Entity.SelectTab("Contact Overview");
            XrmApp.Entity.SetValue("birthdate", birthDate, "M/d/yyyy");


            XrmApp.Entity.Save();
        }
    }
}