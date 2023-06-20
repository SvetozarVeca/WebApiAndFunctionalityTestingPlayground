using Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestProject1.tests.APITests
{
    [Parallelizable(ParallelScope.All)]
    public class DeleteContactById
    {
        [Test]
        public async Task DeleteContact()
        {
            IContactService contactService = new ContactService();

            List<ContactDTOFromDB> contacts = await contactService.GetList();

            string response = await contactService.Delete(contacts[2].Id);

            Assert.AreEqual("OK", response);
        }

        [Test]
        public async Task DeleteContactWithWrongIdShouldReturnBadResponseMessage()
        {
            IContactService contactService = new ContactService();

            List<ContactDTOFromDB> contacts = await contactService.GetList();

            string response = await contactService.Delete("wrongId");

            Assert.AreEqual("Contact doesn't exist", response);

        }
    }
}
