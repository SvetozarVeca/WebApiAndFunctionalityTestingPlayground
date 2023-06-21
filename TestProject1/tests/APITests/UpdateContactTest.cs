using Services;
using Utilities;

namespace TestProject1.tests.APITests
{
    
    public class UpdateContactTest
    {
        [Test, Category("APITests")]
        public async Task UpdateContact()
        {
            IContactService contactService = new ContactService();

            List<ContactDTOFromDB> contacts = await contactService.GetList();
            ContactDTOFromDB contact = MappingChildToParent.Map<ContactDTOFromDB>(JsonReaderUtility.GetContactEntryFromJsonFile());
            contact.Version = contacts[0].Version;
            contact.Id = contacts[0].Id;
            contact.Owner = contacts[0].Owner;

            string response = await contactService.Update(contacts[0].Id, contact);

            Assert.AreEqual("OK", response);
        }

        [Test, Category("APITests")]
        public async Task UpdateContactWithWrongIdShouldReturnBadRequestMessage()
        {
            IContactService contactService = new ContactService();

            List<ContactDTOFromDB> contacts = await contactService.GetList();

            ContactDTOFromDB contact = MappingChildToParent.Map<ContactDTOFromDB>(JsonReaderUtility.GetContactEntryFromJsonFile());
            contact.Version = contacts[0].Version;
            contact.Id = "wrongId";
            contact.Owner = contacts[0].Owner;
            
            string response = await contactService.Update(contact.Id, contact);

            Assert.AreEqual("Bad Request", response);

        }
    }
}
