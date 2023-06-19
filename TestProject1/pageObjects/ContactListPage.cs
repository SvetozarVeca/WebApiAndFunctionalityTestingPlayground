

using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.PageObjects;
using TestProject1.tests;

namespace TestProject1.pageObjects
{
    public class ContactListPage : BaseTest
    {
        private IWebDriver _driver;

        public ContactListPage(IWebDriver driver)
        {
            _driver = driver;
            PageFactory.InitElements(driver, this);
        }

        [FindsBy(How = How.Id, Using = "add-contact")]
        private IWebElement _addNewContact;

        public ContactPage AddNewContact()
        {
            _addNewContact.Click();

            return new ContactPage(_driver);

        }

        public void WaitForAddNewContact()
        {
            WebDriverWait wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(8));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.Id("add-contact")));
        }
    }
}
