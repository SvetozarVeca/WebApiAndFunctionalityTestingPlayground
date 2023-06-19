using AventStack.ExtentReports.Utils;
using Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace TestProject1.tests.APITests
{
    public class GetContactListAPITest
    {
        [Test]
        public async Task GetContactListShouldReturnList()
        {
            IContactService contactService = new ContactService();

            List<ContactDTOFromDB> contacts = await contactService.GetList();                     

            Assert.IsNotNull(contacts);
        }
    }
    
}

