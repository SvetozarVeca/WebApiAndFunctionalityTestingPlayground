using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestProject1.pageObjects;

namespace TestProject1.tests
{
    [Parallelizable(ParallelScope.All)]
    public class SignInTest : BaseTest
    {
        [Test,TestCaseSource("AddValidLogInCredentials")]
        public void ValidSignIn(AppUser user)
        {
            MainPage mainPage = new MainPage(GetDriver());
            mainPage.ClickSubmitWithValidCredentials(user.Email,user.Password);

        }

        public static IEnumerable<TestCaseData> AddValidLogInCredentials()
        {
            AppUser user = new AppUser
            {
                Email = JsonReaderUtility.ExtractUserData("email"),
                Password = JsonReaderUtility.ExtractUserData("password")
            };
            yield return new TestCaseData(user);
        }
    }


}
