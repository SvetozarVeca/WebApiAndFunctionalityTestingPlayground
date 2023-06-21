using Services;

namespace TestProject1.tests.APITests
{
    
    public class DeleteContactById
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
        public async Task DeleteContactWithWrongIdShouldReturnBadResponseMessage()
        {
            IContactService contactService = new ContactService();

            List<ContactDTOFromDB> contacts = await contactService.GetList();

            string response = await contactService.Delete("wrongId");

            Assert.AreEqual("Bad Request", response);

        }
    }
}
