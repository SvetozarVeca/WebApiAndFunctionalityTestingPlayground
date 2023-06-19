using Models;

namespace Services
{
    public interface IContactService
    {
        public Task<ContactDTOFromDB> Get(string id);

        public Task<List<ContactDTOFromDB>> GetList();

        public Task<string> Update(string id, ContactDTOFromDB newContact);
    }

}
