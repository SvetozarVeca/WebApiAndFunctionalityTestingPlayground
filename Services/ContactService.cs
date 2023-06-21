using Models;
using System.Net.Http.Json;

namespace Services
{
    public class ContactService : BaseService, IContactService
    {      

        public async Task<ContactDTOFromDB> Get(string id)
        {


            string uri = $"https://thinking-tester-contact-list.herokuapp.com/contacts/{id}";
            
            ContactDTOFromDB? response = await HttpClient.GetFromJsonAsync<ContactDTOFromDB>(uri);

            return response;
        }

        public async Task<List<ContactDTOFromDB>> GetList()
        {
            await LogInAndAuthorize();

            string uri = "https://thinking-tester-contact-list.herokuapp.com/contacts";
           
            List<ContactDTOFromDB>? response = await HttpClient.GetFromJsonAsync<List<ContactDTOFromDB>>(uri);

            return response;
        }

        public async Task<string> Update(string id, ContactDTOFromDB newContact)
        {
            await LogInAndAuthorize();

            string uri = $"https://thinking-tester-contact-list.herokuapp.com/contacts/{id}";
           
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
            await LogInAndAuthorize();

            string uri = $"https://thinking-tester-contact-list.herokuapp.com/contacts/{id}";

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
