using Cmc.Engage.UIAutomation.Framework.Persona;

namespace Cmc.Engage.UIAutomation.Framework
{
    public class TestBase
    {
        protected CmcXrmApp XrmApp;

        protected virtual void SwitchPersona(string personaName)
        {
            PersonaManager.SwitchLogin(personaName);
            XrmApp = TestSettings.CurrentPersonaDto.XrmApp;
        }
    }
}