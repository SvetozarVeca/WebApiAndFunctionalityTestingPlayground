
using OpenQA.Selenium.DevTools.V113.CSS;
using System.Collections;
using TestProject1.pageObjects;

namespace TestProject1.tests
{
    [Parallelizable(ParallelScope.All)]
    public class SignUpTest : BaseTest
    {
        [Test, TestCaseSource("AddTestConfigForValidSignUp")]
        public void SignUpWithValidCredentials(AppUser user)
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
            signUpPage.SubmitSignUp(user.FirstName, user.LastName, user.Email, user.Password);

            signUpPage.WaitForErrorMsg();

            if (signUpPage.GetErrorMsg().Text.Contains("Email address is already in use"))
            {
                throw new ArgumentException("Email already in use");
            }

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
            AppUser user = ConvertJsonToAppUser();

            yield return new TestCaseData(user);
        }
    }
   
}