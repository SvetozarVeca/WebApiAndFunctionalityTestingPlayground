using OpenQA.Selenium;
using TestProject1.pageObjects;

namespace TestProject1.tests
{
    [Parallelizable(ParallelScope.All)]
    public class SignInTest : BaseTest
    {
        [Test, TestCaseSource("AddValidLogInCredentials")]
        public void ValidSignIn(AppUser user)
        {
            MainPage mainPage = new MainPage(GetDriver());
            mainPage.ClickSubmitWithValidCredentials(user.Email, user.Password);

        }

        [Test]
        public void InvalidSignInCatchErrorMsg()
        {
            MainPage mainPage = new MainPage(GetDriver());
            mainPage.ClickSubmitWithInvalidCredentials("wrongUsername", "wrongPassword");

            mainPage.WaitForErrorMsg();

            Assert.IsTrue(mainPage.GetErrorMsg().Displayed);
        }

        public static IEnumerable<TestCaseData> AddValidLogInCredentials()
        {
            AppUser user = ConvertJsonToAppUser();

            yield return new TestCaseData(user);
        }
    }


}
