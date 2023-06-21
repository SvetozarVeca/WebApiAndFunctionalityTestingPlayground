using Models;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using Utilities;

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

        public async Task LogInAndAuthorize()
        {
            AppUserDTOFromUser userDTO = JsonReaderUtility.GetAppUserFromJsonFile();
            LogInUserDTO loginUser = new LogInUserDTO { Email = userDTO.Email , Password = userDTO.Password};

            HttpResponseMessage response = await _httpClient.PostAsJsonAsync(_tokenURI, loginUser);
            string token = response.Content.ReadFromJsonAsync<LogInDTOFromDB>().Result.token;

            HttpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            
        }

        public HttpClient HttpClient => _httpClient;
       
               
    }
}
