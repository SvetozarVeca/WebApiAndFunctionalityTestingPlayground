using Models;
using System.Net.Http.Headers;
using System.Net.Http.Json;

namespace Services
{
    public class ContactService : BaseService, IContactService
    {      

        public async Task<ContactDTOFromDB> Get(string id)
        {

            string uri = $"https://thinking-tester-contact-list.herokuapp.com/contacts/{id}";
            string token = await LogInAndGetToken();

            HttpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

            ContactDTOFromDB? response = await HttpClient.GetFromJsonAsync<ContactDTOFromDB>(uri);

            return response;
        }

        public async Task<List<ContactDTOFromDB>> GetList()
        {
            string uri = "https://thinking-tester-contact-list.herokuapp.com/contacts";
            string token = await LogInAndGetToken();

            HttpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

            List<ContactDTOFromDB>? response = await HttpClient.GetFromJsonAsync<List<ContactDTOFromDB>>(uri);

            return response;
        }

        public async Task<string> Update(string id, ContactDTOFromDB newContact)
        {
            string uri = $"https://thinking-tester-contact-list.herokuapp.com/contacts/{id}";
            string token = await LogInAndGetToken();

            HttpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

            List<ContactDTOFromDB> contacts = await GetList();

            if (contacts.FirstOrDefault(x=>x.Id == id)==null)
            {
                return "No such contact";
            }            

            var result = await HttpClient.PutAsJsonAsync<ContactDTOFromDB>(uri, newContact);

            return result.ReasonPhrase;
        }

        public async Task<string> Delete(string id)
        {
            string uri = $"https://thinking-tester-contact-list.herokuapp.com/contacts/{id}";
            string token = await LogInAndGetToken();

            HttpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

            List<ContactDTOFromDB> contacts = await GetList();

            if (contacts.FirstOrDefault(x => x.Id == id) == null)
            {
                return "Contact doesn't exist";
            }

            ContactDTOFromDB? contact = contacts.FirstOrDefault(x => x.Id == id);

            var result = await HttpClient.DeleteAsync(uri);

            return result.ReasonPhrase;
        }
    }
}
