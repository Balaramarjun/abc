using Cmc.Engage.UIAutomation.Framework.Persona;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Cmc.Engage.UIAutomation.Base
{
    [TestClass]
    public class InitializeTest
    {
        [AssemblyInitialize]
        public static void AssemblyInitialize(TestContext context)
        {
            //var client = new WebClient(TestSettings.Options);
            //TestSettings.XrmApp = new XrmApp(client);
            //TestSettings.WebClient = client;

            //var xrmApp = TestSettings.XrmApp;
            //xrmApp.OnlineLogin.Login(TestSettings.XrmUri, TestSettings.Username, TestSettings.Password);
            //xrmApp.Navigation.OpenApp(UCIAppName.CEngage);
        }

        [AssemblyCleanup]
        public static void AssemblyCleanup()
        {
            PersonaManager.CleanUp();
        }
    }
}