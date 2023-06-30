using Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestProject1.tests.APITests.UserAPI
{
    public class AddUserTest
    {
        [Test]
        public async Task AddUser()
        {
            IUserService userService = new UserService();

            AppUserDTOFromUser user = new AppUserDTOFromUser
            {
                Email = "randomeeemail22@email.com",
                FirstName = "Saban",
                LastName = "Saulic",
                Password = "randompassword12"
            };

            string? response = await userService.AddUser(user);

            Assert.AreEqual("Created", response);
        }

    }
}
