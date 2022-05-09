using System;
using System.Collections.Generic;
using System.Configuration;
using Cmc.Engage.UIAutomation.Framework.Dto;
using Microsoft.Dynamics365.UIAutomation.Browser;

namespace Cmc.Engage.UIAutomation.Framework
{
    public static class TestSettings
    {
        private static readonly string Type = ConfigurationManager.AppSettings["BrowserType"];
        private static readonly string GoogleSync = ConfigurationManager.AppSettings["GoogleSyncBrowser"];    
        private static readonly string RemoteType = ConfigurationManager.AppSettings["RemoteBrowserType"];
        private static readonly string RemoteHubServerURL = ConfigurationManager.AppSettings["RemoteHubServer"];
        public static Uri XrmUri = new Uri(ConfigurationManager.AppSettings["OnlineCrmUrl"]);
        public static Uri RegURL = new Uri(ConfigurationManager.AppSettings["RegUrl"]);
        public static IDictionary<string,object> TestPropertiesMap = new Dictionary<string, object>();

        public static BrowserOptions Options = new BrowserOptions
        {
            BrowserType = (BrowserType) Enum.Parse(typeof(BrowserType), Type),
            PrivateMode = true,
            FireEvents = false,
            Headless = false,          
           //NoSandbox =true,
           // PageLoadTimeout = new TimeSpan(0, 0 , 0),
        UserAgent = false,
            DefaultThinkTime = 2000,
            RemoteBrowserType = (BrowserType) Enum.Parse(typeof(BrowserType), RemoteType),
            RemoteHubServer = new Uri(RemoteHubServerURL),
            UCITestMode = true,
            //StartMaximized=true 
            
        };
        public static BrowserOptions OptionsEdge = new BrowserOptions
        {
            BrowserType = (BrowserType)Enum.Parse(typeof(BrowserType), GoogleSync),
            PrivateMode = true,
            FireEvents = false,
            Headless = false,
            //NoSandbox =false,
            // PageLoadTimeout = new TimeSpan(0, 0, 0),
            UserAgent = false,
            DefaultThinkTime = 2000,
            RemoteBrowserType = (BrowserType)Enum.Parse(typeof(BrowserType), RemoteType),
            RemoteHubServer = new Uri(RemoteHubServerURL),
            UCITestMode = true,
            //StartMaximized = true,
            //Height =1080,
            //Width= 1920
        };
        public static BrowserOptions OptionsFirefox = new BrowserOptions
        {
            BrowserType = (BrowserType)Enum.Parse(typeof(BrowserType), Type),
            PrivateMode = true,
            FireEvents = false,
            Headless = false,
          // NoSandbox =false,
           // PageLoadTimeout = new TimeSpan(0, 0, 5),
            UserAgent = false,
            DefaultThinkTime = 2000,
            RemoteBrowserType = (BrowserType)Enum.Parse(typeof(BrowserType), RemoteType),
            RemoteHubServer = new Uri(RemoteHubServerURL),
            UCITestMode = true,
            //StartMaximized=true,
            // Height = 1080,
            //Width = 1920
        };
        public static PersonaDto CurrentPersonaDto { get; set; }


        public static string GetRandomString(int minLen, int maxLen)
        {
            var Alphabet = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcefghijklmnopqrstuvwxyz0123456789".ToCharArray();
            var m_randomInstance = new Random();
            var m_randLock = new object();

            var alphabetLength = Alphabet.Length;
            int stringLength;
            lock (m_randLock)
            {
                stringLength = m_randomInstance.Next(minLen, maxLen);
            }

            var str = new char[stringLength];

            // max length of the randomizer array is 5
            var randomizerLength = stringLength > 5 ? 5 : stringLength;

            var rndInts = new int[randomizerLength];
            var rndIncrements = new int[randomizerLength];

            // Prepare a "randomizing" array
            for (var i = 0; i < randomizerLength; i++)
            {
                var rnd = m_randomInstance.Next(alphabetLength);
                rndInts[i] = rnd;
                rndIncrements[i] = rnd;
            }

            // Generate "random" string out of the alphabet used
            for (var i = 0; i < stringLength; i++)
            {
                var indexRnd = i % randomizerLength;
                var indexAlphabet = rndInts[indexRnd] % alphabetLength;
                str[i] = Alphabet[indexAlphabet];

                // Each rndInt "cycles" characters from the array, 
                // so we have more or less random string as a result
                rndInts[indexRnd] += rndIncrements[indexRnd];
            }

            return new string(str);
        }
    }

    public static class UCIAppName
    {
        public static string Anthology = "Anthology Reach";
        public static string AppReview = "Application Review";
        public static string Sales = "Sales Hub";
        public static string CustomerService = "Customer Service Hub";
        public static string Project = "Project Resource Hub";
        public static string FieldService = "Field Resource Hub";
    }
}