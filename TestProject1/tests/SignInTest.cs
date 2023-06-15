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
        public void ValidSignIn(string email,string password)
        {
            MainPage mainPage = new MainPage(GetDriver());
            mainPage.ClickSubmitWithValidCredentials(email,password);

        }

        public static IEnumerable<TestCaseData> AddValidLogInCredentials()
        {
            yield return new TestCaseData(GetDataParser().ExtractUserData("email"), GetDataParser().ExtractUserData("password"));
        }
    }


}
