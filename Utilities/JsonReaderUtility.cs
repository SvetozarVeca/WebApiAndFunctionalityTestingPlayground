using Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Utilities
{
    public static class JsonReaderUtility
    {

        public static string? ExtractUserData(string tokenName)
        {
            return ExtractUserJToken()?.SelectToken(tokenName)?.Value<string>();
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

        public static AppUserDTOFromUser GetAppUserFromJsonFile()
        {
            string userJsonFilePath = $"{FileSystemUtility.GetProjectDirectory()}\\userData.json";

            return JsonConvert.DeserializeObject<AppUserDTOFromUser>(File.ReadAllText(userJsonFilePath));
        }

        public static ContactDTOFromUser GetContactEntryFromJsonFile()
        {
            string contactJsonFilePath = $"{FileSystemUtility.GetProjectDirectory()}\\contactData.json";

            return JsonConvert.DeserializeObject<ContactDTOFromUser>(File.ReadAllText(contactJsonFilePath));
        }




    }
}
