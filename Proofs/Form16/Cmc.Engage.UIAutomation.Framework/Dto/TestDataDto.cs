using Newtonsoft.Json.Linq;

namespace Cmc.Engage.UIAutomation.Framework.Dto
{
    public class TestDataDto
    {
        public string TestName { get; set; }
        public JObject RowData { get; set; }
    }
}