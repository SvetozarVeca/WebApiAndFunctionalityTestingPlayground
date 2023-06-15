

using OpenQA.Selenium;
using SeleniumExtras.PageObjects;

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

    }
}
