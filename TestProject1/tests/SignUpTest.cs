
using OpenQA.Selenium.DevTools.V113.CSS;
using System.Collections;
using TestProject1.pageObjects;

namespace TestProject1.tests
{
    [Parallelizable(ParallelScope.All)]
    public class SignUpTest : BaseTest
    {
        [Test, TestCaseSource("AddTestConfigForValidSignUp")]
        public void SignUpWithValidCredentials(string firstName, string lastName, string email, string passWord)
        {
            if (!ValidateNewUserEmailAndPasswordFormatUtility.IsEmailValidFormat(email))
            {
                throw new ArgumentException("Not valid email");
            }
            else if (!ValidateNewUserEmailAndPasswordFormatUtility.IsPasswordValid(passWord))
            {
                throw new ArgumentException("Not valid password");
            }

            MainPage mainPage = new(GetDriver());
            SignUpPage signUpPage = mainPage.ClickToSignUp();
            signUpPage.SubmitSignUp(firstName, lastName, email, passWord);

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

            Assert.IsTrue(signUpPage.GetErrorMsg() != null);
        }


        public static IEnumerable<TestCaseData> AddTestConfigForValidSignUp()
        {
            yield return new TestCaseData(JsonReaderUtility.ExtractUserData("firstName"), JsonReaderUtility.ExtractUserData("lastName"),
                JsonReaderUtility.ExtractUserData("email"), JsonReaderUtility.ExtractUserData("password"));
        }
    }
   
}