using TestProject1.pageObjects;
using Utilities;

namespace TestProject1.tests
{
    [Parallelizable(ParallelScope.All)]
    public class SignInTest : BaseTest
    {
        [Test, TestCaseSource("AddValidLogInCredentials"), Category("SignInTests")]
        public void ValidSignIn(AppUserDTOFromUser user)
        {
            MainPage mainPage = new MainPage(Driver);
            ContactListPage contactListPage = mainPage.ClickSubmitWithValidCredentials(user.Email, user.Password);

            Assert.IsNotNull(contactListPage);

        }

        [Test, Category("SignInTests")]
        public void InvalidSignInCatchErrorMsg()
        {
            MainPage mainPage = new MainPage(Driver);
            mainPage.ClickSubmitWithInvalidCredentials("testertwerrwwerester@test.com", "test111");

            mainPage.WaitForErrorMsg();

            Assert.IsTrue(mainPage.GetErrorMsg().Displayed);
        }

        public static IEnumerable<TestCaseData> AddValidLogInCredentials()
        {
            AppUserDTOFromUser user = JsonReaderUtility.GetAppUserFromJsonFile();

            yield return new TestCaseData(user);
        }
    }


}
