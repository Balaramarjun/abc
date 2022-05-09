using System.Collections.Concurrent;
using System.Collections.Generic;
using Cmc.Engage.UIAutomation.Framework.Dto;
using Cmc.Engage.UIAutomation.Framework.TestData;
using Microsoft.Dynamics365.UIAutomation.Api.UCI;
using Microsoft.Dynamics365.UIAutomation.Browser;
using System;
using System.Configuration;

namespace Cmc.Engage.UIAutomation.Framework.Persona
{
    public static class PersonaManager 
    {

   

        private static readonly IDictionary<string, PersonaDto> MapOfPersonaNameToPersonas = new ConcurrentDictionary<string, PersonaDto>();

        static PersonaManager()
        {
            var personaDtos = TestDataManager.GetExcelSheetData("Personas", "Persona", "PersonaName");

            foreach (var personaDto in personaDtos)
            {
                dynamic persona = personaDto.RowData;
                string email = persona.UserEmail.ToString();
                string password = persona.Password.ToString();
                MapOfPersonaNameToPersonas.Add(personaDto.TestName, new PersonaDto
                {
                    PersonaName = personaDto.TestName,
                    UserEmail = email.ToSecureString(),
                    Password = password.ToSecureString()
                });
            }
        }

        public static void SwitchLogin(string personaName)
        {
            var personaDto = MapOfPersonaNameToPersonas[personaName];
           
            if (personaDto.XrmApp == null)
            {
                var client = new WebClient(TestSettings.Options);
                var xrmApp = new CmcXrmApp(client);
                if (TestSettings.Options.BrowserType == BrowserType.Firefox)
                {
                    client = new WebClient(TestSettings.OptionsFirefox);
                    xrmApp = new CmcXrmApp(client);
                    Console.WriteLine("Firefox settings applied");
                    xrmApp.OnlineLogin.Login(TestSettings.XrmUri, personaDto.UserEmail, personaDto.Password, ConfigurationManager.AppSettings["MfaEngage"].ToSecureString());
                    xrmApp.ThinkTime(5000);
                }
                else
                {
                    Console.WriteLine("other browser settings applied");
                    xrmApp.OnlineLogin.Login(TestSettings.XrmUri, personaDto.UserEmail, personaDto.Password, ConfigurationManager.AppSettings["MfaEngage"].ToSecureString());
                    xrmApp.ThinkTime(5000);
                }
                try
                {
                    xrmApp.Navigation.OpenApp(UCIAppName.Anthology);
                    xrmApp.ThinkTime(10000);
                }
                catch (Exception ex)
                {
                    if (ex.Message.Contains("Frame AppLandingPage is not loaded") || ex.Message.Contains("App Not Found"))
                    {
                        xrmApp.Navigation.RedirectAppSwitch(UCIAppName.Anthology);
                        xrmApp.ThinkTime(15000);
                    }
                    else
                        Console.WriteLine("App Switched");
                }
              
                personaDto.XrmApp = xrmApp;
              
                    xrmApp.MainWindowHandle = client.Browser.Driver.CurrentWindowHandle;
                xrmApp.Driver = client.Browser.Driver;
                xrmApp.Driver.SwitchTo().Window(xrmApp.Driver.WindowHandles[0]);
                TestSettings.CurrentPersonaDto = personaDto;

            }
           

            
        }
        public static void AppRegNavigation(string personaName)
        {
            var personaDto = MapOfPersonaNameToPersonas[personaName];
            if (personaDto.XrmApp == null)
            {
                var client = new WebClient(TestSettings.Options);
                var xrmApp = new CmcXrmApp(client);
                xrmApp.Elements.TPCLogin(TestSettings.XrmUri, personaDto.UserEmail, personaDto.Password, true);
                personaDto.XrmApp = xrmApp;

                xrmApp.MainWindowHandle = client.Browser.Driver.CurrentWindowHandle;
                xrmApp.Driver = client.Browser.Driver;
                xrmApp.Driver.SwitchTo().Window(xrmApp.Driver.WindowHandles[0]);
                TestSettings.CurrentPersonaDto = personaDto;
            }

        }
        public static void SwitchLoginSpecificBrowser(string personaName)
        {
            var personaDto = MapOfPersonaNameToPersonas[personaName];
           
            if (personaDto.XrmApp == null)
            {
                var client = new WebClient(TestSettings.OptionsEdge);
                var xrmApp = new CmcXrmApp(client);


                xrmApp.OnlineLogin.Login(TestSettings.XrmUri, personaDto.UserEmail, personaDto.Password, ConfigurationManager.AppSettings["MfaEngageEdge"].ToSecureString());
                xrmApp.ThinkTime(5000);

                try
                {
                    xrmApp.Navigation.OpenApp(UCIAppName.Anthology);
                    xrmApp.ThinkTime(10000);
                }
                catch (Exception ex)
                {
                    if (ex.Message.Contains("Frame AppLandingPage is not loaded") || ex.Message.Contains("App Not Found"))
                    {
                        xrmApp.Navigation.RedirectAppSwitch(UCIAppName.Anthology);
                        xrmApp.ThinkTime(15000);
                    }
                    else
                        Console.WriteLine("App Switched");
                }

                personaDto.XrmApp = xrmApp;

                xrmApp.MainWindowHandle = client.Browser.Driver.CurrentWindowHandle;
                xrmApp.Driver = client.Browser.Driver;
                xrmApp.Driver.SwitchTo().Window(xrmApp.Driver.WindowHandles[0]);
                TestSettings.CurrentPersonaDto = personaDto;

            }



        }

        public static void PortalLogin(string personaName)
        {
            var personaDto = MapOfPersonaNameToPersonas[personaName];
            if (personaDto.XrmApp == null)
            {
                var client = new WebClient(TestSettings.Options);
                var xrmApp = new CmcXrmApp(client);
                xrmApp.Elements.TPCLogin(TestSettings.XrmUri, personaDto.UserEmail, personaDto.Password, false);

                personaDto.XrmApp = xrmApp;

                xrmApp.MainWindowHandle = client.Browser.Driver.CurrentWindowHandle;
                xrmApp.Driver = client.Browser.Driver;
                xrmApp.Driver.SwitchTo().Window(xrmApp.Driver.WindowHandles[0]);
                TestSettings.CurrentPersonaDto = personaDto;
            }



        }

        public static void CleanUp()
        {
            foreach (var key in MapOfPersonaNameToPersonas.Keys)
            {
                var personaDto = MapOfPersonaNameToPersonas[key];
                personaDto.XrmApp?.Dispose();
                personaDto.XrmApp = null;
            }
        }
    }
}