using Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace TestProject1.tests.APITests
{
    [Parallelizable(ParallelScope.All)]
    public class UpdateContactTest
    {
        [Test]
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

        [Test]
        public async Task UpdateContactWithWrongIdShouldReturnBadResponseMessage()
        {
            IContactService contactService = new ContactService();

            List<ContactDTOFromDB> contacts = await contactService.GetList();

            ContactDTOFromDB contact = MappingChildToParent.Map<ContactDTOFromDB>(JsonReaderUtility.GetContactEntryFromJsonFile());
            contact.Version = contacts[0].Version;
            contact.Id = "wrongId";
            contact.Owner = contacts[0].Owner;
            
            string response = await contactService.Update(contact.Id, contact);

            Assert.AreEqual("No such contact", response);

        }
    }
}
