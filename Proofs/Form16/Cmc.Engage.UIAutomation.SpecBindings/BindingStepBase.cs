using System;
using Cmc.Engage.UIAutomation.Framework;
using Cmc.Engage.UIAutomation.Framework.Persona;
using TechTalk.SpecFlow;

namespace Cmc.Engage.UIAutomation.SpecBindings
{
    public class BindingStepBase
    {
        protected CmcXrmApp XrmApp
        {
            get
            {
                if (_featureContext.ContainsKey("XrmApp"))
                    return _featureContext["XrmApp"] as CmcXrmApp;
                return null;
            }
        }
        protected FeatureContext _featureContext;
        protected ScenarioContext _scenarioContext;

        public BindingStepBase(FeatureContext featureContext, ScenarioContext scenarioContext)
        {
            _featureContext = featureContext;
            _scenarioContext = scenarioContext;
        }

        protected void SwitchPersona(string personaName)
        {


          PersonaManager.SwitchLogin(personaName);
            _featureContext["XrmApp"] = TestSettings.CurrentPersonaDto.XrmApp;
           
        }
        protected void SwitchLoginSpecificBrowser(string personaName)
        {


            PersonaManager.SwitchLoginSpecificBrowser(personaName);
            _featureContext["XrmApp"] = TestSettings.CurrentPersonaDto.XrmApp;

        }

        protected void AppRegNavigation(string personaName)
        {
            PersonaManager.AppRegNavigation(personaName);
            _featureContext["XrmApp"] = TestSettings.CurrentPersonaDto.XrmApp;

        }

        protected void AddFieldValueToFeatureContext(string fieldName, object fieldValue)
        {
            _featureContext[fieldName] = fieldValue;
            _featureContext[_scenarioContext.ScenarioInfo.Title + "-" + fieldName] = fieldValue;
        }

        protected object GetFieldValueFromFeatureContext(string fieldName, string scenarioTitle = "")
        {
            if (String.IsNullOrWhiteSpace(scenarioTitle))
            {
                if (_featureContext.ContainsKey(fieldName))
                    return _featureContext[fieldName];
            }
            else
            {
                var key = scenarioTitle + "-" + fieldName;
                if (_featureContext.ContainsKey(key))
                    return _featureContext[key];
            }
            
            return null;
        }
    }
}