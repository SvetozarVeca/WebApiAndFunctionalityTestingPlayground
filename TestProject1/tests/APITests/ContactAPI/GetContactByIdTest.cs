using Services;

namespace TestProject1.tests.APITests.ContactAPI
{

    public class GetContactByIdTest
    {
        [Test, Category("APITests")]
        public async Task GetContactByIdShouldReturnContact()
        {
            IContactService contactService = new ContactService();

            List<ContactDTOFromDB> contacts = await contactService.GetList();
            ContactDTOFromDB contact = await contactService.Get(contacts[0].Id);

            Assert.IsNotNull(contact);
        }

        [Test, Category("APITests")]
        public async Task GetContactByFailIdShouldReturnNull()
        {
            IContactService contactService = new ContactService();

            List<ContactDTOFromDB> contacts = await contactService.GetList();

            string wrongId = "wrongId";
            ContactDTOFromDB? wrongContact = null;

            foreach (var contact in contacts)
            {
                if (contact.Id == wrongId)
                {
                    wrongContact = contact;
                    break;
                }
            }

            Assert.IsNull(wrongContact);
        }
    }
}
