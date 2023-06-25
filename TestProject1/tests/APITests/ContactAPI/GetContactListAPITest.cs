using Services;

namespace TestProject1.tests.APITests.ContactAPI
{

    public class GetContactListAPITest
    {
        [Test, Category("APITests")]
        public async Task GetContactListShouldReturnList()
        {
            IContactService contactService = new ContactService();

            List<ContactDTOFromDB> contacts = await contactService.GetList();

            Assert.IsNotNull(contacts);
        }
    }

}

