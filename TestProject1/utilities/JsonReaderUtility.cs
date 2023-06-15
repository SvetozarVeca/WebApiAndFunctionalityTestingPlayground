using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestProject1.utilities
{
    public static class JsonReaderUtility
    {

        public static string ExtractUserData(string tokenName)
        {
            return ExtractUserJToken().SelectToken(tokenName).Value<string>();
        }
        public static string ExtractContactData(string tokenName)
        {
            return ExtractContactJToken().SelectToken(tokenName).Value<string>();
        }

        private static JToken ExtractUserJToken()
        {
            string myJsonString = File.ReadAllText($"../../../userData.json");
            return JToken.Parse(myJsonString);
        }

        private static JToken ExtractContactJToken()
        {
            string myJsonString = File.ReadAllText($"../../../contactData.json");
            return JToken.Parse(myJsonString);
        }
    }
}
