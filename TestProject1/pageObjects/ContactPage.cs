using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestProject1.pageObjects
{
    public class ContactPage : BaseTest
    {
        private IWebDriver _driver;

        public ContactPage(IWebDriver driver)
        {
            _driver = driver;
            PageFactory.InitElements(driver, this);
        }

        [FindsBy(How = How.Id, Using = "firstName")]
        private IWebElement _inputFirstName;

        [FindsBy(How = How.Id, Using = "lastName")]
        private IWebElement _inputLastName;

        [FindsBy(How = How.Id, Using = "birthdate")]
        private IWebElement _inputBirthday;

        [FindsBy(How = How.Id, Using = "email")]
        private IWebElement _inputEmail;

        [FindsBy(How = How.Id, Using = "phone")]
        private IWebElement _inputPhone;

        [FindsBy(How = How.Id, Using = "street1")]
        private IWebElement _inputStreet1;

        [FindsBy(How = How.Id, Using = "street2")]
        private IWebElement _inputStreet2;

        [FindsBy(How = How.Id, Using = "city")]
        private IWebElement _inputCity;

        [FindsBy(How = How.Id, Using = "stateProvince")]
        private IWebElement _inputState;

        [FindsBy(How = How.Id, Using = "postalCode")]
        private IWebElement _inputPostalCode;

        [FindsBy(How = How.Id, Using = "country")]
        private IWebElement _inputCountry;

        [FindsBy(How = How.Id, Using = "submit")]
        private IWebElement _AddContact;

        public ContactListPage AddContact(string firstname, string lastName, string birthdate, string email, string phone, string street1, string street2,
            string city, string state, string postalCode, string country)
        {
            _inputFirstName.SendKeys(firstname);
            _inputLastName.SendKeys(lastName);
            _inputBirthday.SendKeys(birthdate);
            _inputEmail.SendKeys(email);
            _inputPhone.SendKeys(phone);
            _inputCity.SendKeys(city);
            _inputState.SendKeys(state);
            _inputStreet1.SendKeys(street1);
            _inputStreet2.SendKeys(street2);
            _inputPostalCode.SendKeys(postalCode);
            _inputCountry.SendKeys(country);

            _AddContact.Click();

            return new ContactListPage(_driver);
        }

    }

}
