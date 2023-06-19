using Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class BaseService
    {
        private readonly HttpClient _httpClient;

        private string _tokenURI = "https://thinking-tester-contact-list.herokuapp.com/users/login";

        public BaseService()
        {
            _httpClient = new();
        }

        public async Task<string> LogInAndGetToken()
        {
            AppUserDTOFromUser userDTO = ConvertJsonToAppUser();
            LogInUser loginUser = new LogInUser { email = userDTO.Email , password = userDTO.Password};

            HttpResponseMessage response = await _httpClient.PostAsJsonAsync(_tokenURI, loginUser);
            string token = response.Content.ReadFromJsonAsync<LogInDTOFromDB>().Result.token;

            return token;
        }

        public HttpClient HttpClient => _httpClient;

        private static AppUserDTOFromUser ConvertJsonToAppUser()
        {
            string userJsonFilePath = "../../../userData.json";
            return JsonConvert.DeserializeObject<AppUserDTOFromUser>(File.ReadAllText(userJsonFilePath));
        }

        private class LogInUser
        {
            public string email { get; set; }

            public string password { get; set; }
        }
    }
}
