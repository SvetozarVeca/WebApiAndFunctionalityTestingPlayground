using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using RazorEngine.Compilation.ImpromptuInterface;
using SeleniumExtras.PageObjects;
using TestProject1.tests;

namespace TestProject1.pageObjects
{
    public class MainPage : BaseTest
    {
        private IWebDriver _driver;

        public MainPage(IWebDriver driver)
        {
           _driver = driver;
            PageFactory.InitElements(driver, this);
        }

        [FindsBy(How = How.Id, Using = "signup")]
        private IWebElement _signUpBtn;

        [FindsBy(How = How.Id, Using = "submit")]
        private IWebElement _logIn;

        [FindsBy(How = How.Id, Using = "email")]
        private IWebElement _inputEmail;

        [FindsBy(How = How.Id, Using = "password")]
        private IWebElement _inputPassword;

        [FindsBy(How = How.Id, Using = "error")]
        private IWebElement _errorMsg;

        public IWebElement GetErrorMsg()
        {
            return _errorMsg;
        }

        public ContactListPage ClickSubmitWithValidCredentials(string email, string password)
        {
            _inputEmail.SendKeys(email);
            _inputPassword.SendKeys(password);

            _logIn.Click();

            return new ContactListPage(_driver);
        }

        public void ClickSubmitWithInvalidCredentials(string email, string password)
        {
            _inputEmail.SendKeys(email);
            _inputPassword.SendKeys(password);

            _logIn.Click();
        }

        public SignUpPage ClickToSignUp()
        {
            _signUpBtn.Click();
            return new SignUpPage(_driver);
        }

        public void WaitForErrorMsg()
        {
            WebDriverWait wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(8));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.Id("error")));
        }
    }
}
