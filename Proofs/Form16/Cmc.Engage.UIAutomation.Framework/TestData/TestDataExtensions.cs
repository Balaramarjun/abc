using System.Text.RegularExpressions;
using Newtonsoft.Json.Linq;

namespace Cmc.Engage.UIAutomation.Framework.TestData
{
    public static class TestDataExtensions
    {
        public static JArray GetJArray(this string input)
        {
            //Remove newline characters
            input = Regex.Replace(input, @"\t|\n|\r", "");
            if (!string.IsNullOrEmpty(input))
                return JArray.Parse(input);
            return new JArray();
        }

        public static JObject GetJObject(this string input)
        {
            //Remove newline characters
            input = Regex.Replace(input, @"\t|\n|\r", "");
            if (!string.IsNullOrEmpty(input))
                return JObject.Parse(input);
            return new JObject();
        }
    }
}