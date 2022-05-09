using System.Security;

namespace Cmc.Engage.UIAutomation.Framework.Dto
{
    public class PersonaDto
    {
        public string PersonaName { get; set; }
        public SecureString UserEmail { get; set; }
        public SecureString Password { get; set; }
        public CmcXrmApp XrmApp { get; set; }
    }
}