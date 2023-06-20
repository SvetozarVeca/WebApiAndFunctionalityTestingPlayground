using Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestProject1.tests.APITests
{
    [Parallelizable(ParallelScope.All)]
    public class GetContactByIdTest
    {
        [Test]
        public async Task GetContactByIdShouldReturnContact()
        {
            IContactService contactService = new ContactService();

            List<ContactDTOFromDB> contacts = await contactService.GetList();
            ContactDTOFromDB contact = await contactService.Get(contacts[0].Id);

            Assert.IsNotNull(contact);
        }

        [Test]
        public async Task GetContactByFailIdShouldReturnNull()
        {
            IContactService contactService = new ContactService();

            List<ContactDTOFromDB> contacts = await contactService.GetList();

            string wrongId = "wrongId";
            ContactDTOFromDB? wrongContact = null;

            foreach (var contact in contacts)
            {
                if (contact.Id==wrongId)
                {
                    wrongContact = contact;
                    break;
                }
            }

            Assert.IsNull(wrongContact);
        }
    }
}
