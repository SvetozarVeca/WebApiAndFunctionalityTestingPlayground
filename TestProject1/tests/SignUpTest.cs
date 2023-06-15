
using OpenQA.Selenium.DevTools.V113.CSS;
using System.Collections;
using TestProject1.pageObjects;
using TestProject1.utilities;

namespace TestProject1.tests
{
    [Parallelizable(ParallelScope.All)]
    public class SignUpTest : BaseTest
    {
        [Test, TestCaseSource("AddTestConfigForValidSignUp")]
        public void SignUpWithValidCredentials(string firstName, string lastName, string email, string passWord)
        {
            if (!ValidateNewUserEmailAndPasswordFormat.IsEmailValidFormat(email))
            {
                throw new ArgumentException("Not valid email");
            }
            else if (!ValidateNewUserEmailAndPasswordFormat.IsPasswordValid(passWord))
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
            yield return new TestCaseData(BaseTest.GetDataParser().ExtractUserData("firstName"), BaseTest.GetDataParser().ExtractUserData("lastName"),
                BaseTest.GetDataParser().ExtractUserData("email"), BaseTest.GetDataParser().ExtractUserData("password"));
        }
    }
   
}