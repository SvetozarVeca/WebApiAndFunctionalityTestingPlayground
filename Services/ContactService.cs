using Models;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Web.Http.ModelBinding;

namespace Services
{
    public class ContactService : BaseService, IContactService
    {

        private string _token;

        private async Task<string> GetToken()
        {
            _token = await LogInAndGetToken();
            return _token;
        }

        public async Task<ContactDTOFromDB> Get(string id)
        {
            
            string uri = $"https://thinking-tester-contact-list.herokuapp.com/contacts/{id}";

            HttpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", await GetToken()) ;

            ContactDTOFromDB? response = await HttpClient.GetFromJsonAsync<ContactDTOFromDB>(uri);

            return response;
        }

        public async Task<List<ContactDTOFromDB>> GetList()
        {
            string uri = "https://thinking-tester-contact-list.herokuapp.com/contacts";
            HttpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", await GetToken());

            List<ContactDTOFromDB>? response = await HttpClient.GetFromJsonAsync<List<ContactDTOFromDB>>(uri);

            return response;
        }

        public async Task<string> Update(string id, ContactDTOFromDB newContact)
        {
            string uri = $"https://thinking-tester-contact-list.herokuapp.com/contacts/{id}";            
            HttpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", await GetToken());

            var result = await HttpClient.PutAsJsonAsync<ContactDTOFromDB>(uri, newContact);

            return result.ReasonPhrase;
        }
    }
}
