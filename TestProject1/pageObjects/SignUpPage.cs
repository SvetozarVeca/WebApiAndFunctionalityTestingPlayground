using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.PageObjects;

namespace TestProject1.pageObjects
{
    public class SignUpPage
    {
        private IWebDriver _driver;

        public SignUpPage(IWebDriver driver)
        {
            _driver = driver;
            PageFactory.InitElements(driver, this);
        }

        [FindsBy(How = How.XPath, Using = "//input[@id='firstName']")]
        private IWebElement _inputFirstName;

        [FindsBy(How = How.XPath, Using = "//input[@id='lastName']")]
        private IWebElement _inputLastName;

        [FindsBy(How = How.XPath, Using = "//input[@id='email']")]
        private IWebElement _inputEmail;

        [FindsBy(How = How.XPath, Using = "//input[@id='password']")]
        private IWebElement _inputPassword;

        [FindsBy(How = How.XPath, Using = "//button[@id='submit']")]
        private IWebElement _clickSubmit;

        [FindsBy(How = How.XPath, Using = "//button[@id='cancel']")]
        private IWebElement _clickCancel;

        [FindsBy (How=How.Id, Using = "error")]
        private IWebElement _errorMsg;

        public IWebElement GetErrorMsg()
        {
            return _errorMsg;
        }

        public ContactListPage SubmitSignUp(string firstName, string lastName, string email, string password)
        {
            _inputFirstName.SendKeys(firstName);
            _inputLastName.SendKeys(lastName);
            _inputEmail.SendKeys(email);
            _inputPassword.SendKeys(password);

            _clickSubmit.Click();
            return new ContactListPage(_driver);
        }

        public void SubmitSignUpWithFalseCredentials(string firstName, string lastName, string email, string password)
        {
            _inputFirstName.SendKeys(firstName);
            _inputLastName.SendKeys(lastName);
            _inputEmail.SendKeys(email);
            _inputPassword.SendKeys(password);

            _clickSubmit.Click();
        }

        public void WaitForErrorMsg()
        {
            WebDriverWait wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(8));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.Id("error")));
        }
    }
}
