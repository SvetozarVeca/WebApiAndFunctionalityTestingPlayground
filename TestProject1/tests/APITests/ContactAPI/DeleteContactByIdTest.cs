using Services;

namespace TestProject1.tests.APITests.ContactAPI
{

    public class DeleteContactByIdTest
    {
        [Test, Category("APITests")]
        public async Task DeleteContact()
        {
            IContactService contactService = new ContactService();

            List<ContactDTOFromDB> contacts = await contactService.GetList();

            string response = await contactService.Delete(contacts[2].Id);

            Assert.AreEqual("OK", response);
        }

        [Test, Category("APITests")]
        public async Task DeleteContactWithWrongIdShouldReturnBadRequestMessage()
        {
            IContactService contactService = new ContactService();

            List<ContactDTOFromDB> contacts = await contactService.GetList();

            string response = await contactService.Delete("wrongId");

            Assert.AreEqual("Bad Request", response);

        }
    }
}
