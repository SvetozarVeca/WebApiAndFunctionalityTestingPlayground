
using OpenQA.Selenium.DevTools.V113.CSS;
using System.Collections;
using TestProject1.pageObjects;

namespace TestProject1.tests
{
    [Parallelizable(ParallelScope.All)]
    public class SignUpTest : BaseTest
    {
        [Test, TestCaseSource("AddTestConfigForValidSignUp")]
        public void SignUpWithValidCredentials(AppUserDTOFromUser user)
        {
            if (!ValidateNewUserEmailAndPasswordFormatUtility.IsEmailValidFormat(user.Email))
            {
                throw new ArgumentException("Not valid email");
            }
            else if (!ValidateNewUserEmailAndPasswordFormatUtility.IsPasswordValid(user.Password))
            {
                throw new ArgumentException("Not valid password");
            }

            MainPage mainPage = new(GetDriver());
            SignUpPage signUpPage = mainPage.ClickToSignUp();
            ContactListPage contactListPage = signUpPage.SubmitSignUp(user.FirstName, user.LastName, user.Email, user.Password);

            signUpPage.WaitForErrorMsg();

            Assert.False(signUpPage.GetErrorMsg().Text.Contains("Email address is already in use"));
            Assert.IsNotNull(contactListPage);

        }

        [Test]
        public void SignUpWithFalseCredentialsShouldCatchErrorMsg()
        {
            MainPage mainPage = new(GetDriver());
            SignUpPage signUpPage = mainPage.ClickToSignUp();
            signUpPage.SubmitSignUpWithFalseCredentials("somefirstname", "somelastname", "falseemail", "short");

            signUpPage.WaitForErrorMsg();

            Assert.IsTrue(signUpPage.GetErrorMsg().Displayed);
        }


        public static IEnumerable<TestCaseData> AddTestConfigForValidSignUp()
        {
            AppUserDTOFromUser user = JsonReaderUtility.GetAppUserFromJsonFile();

            yield return new TestCaseData(user);
        }
    }
   
}