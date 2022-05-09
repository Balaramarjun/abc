using Cmc.Engage.UIAutomation.Framework.ApiExtensions;
using Cmc.Engage.UIAutomation.Framework.WebResourceExtensions;
using Microsoft.Dynamics365.UIAutomation.Api.UCI;
using OpenQA.Selenium;

namespace Cmc.Engage.UIAutomation.Framework
{
    public class CmcXrmApp : XrmApp
    {
        public CmcXrmApp(WebClient client) : base(client)
        {
            WebClient = client;
        }

        public WebClient WebClient { get; set; }
        public string MainWindowHandle { get; set; }
        public IWebDriver Driver { get; set; }
        public EntityPicker EntityPicker => new EntityPicker(WebClient);
        public ViewPicker ViewPicker => new ViewPicker(WebClient);
        public AdvancedFindQuery AdvancedFind => new AdvancedFindQuery(WebClient);
        public Connections Connections => new Connections(WebClient);
        public AssignSuccessPlan AssignSuccessPlan => new AssignSuccessPlan(WebClient);
        //  public CmcFullPage FullPage => new CmcFullPage(WebClient);
        public new CmcBusinessProcessFlow BusinessProcessFlow => new CmcBusinessProcessFlow(WebClient);
        public new CmcDialog Dialogs => new CmcDialog(WebClient);
        public new CmcCommandBar CommandBar => new CmcCommandBar(WebClient);
        public new CmcEntity Entity => new CmcEntity(WebClient);
        public new CmcGrid Grid => new CmcGrid(WebClient); 
        public new CmcNavigation Navigation => new CmcNavigation(WebClient);

        public new PortalElements Elements => new PortalElements(WebClient);
        public void SwitchToMainWindow()
        {
            Driver.SwitchTo().Window(MainWindowHandle);
        }
    }
}