﻿using OpenQA.Selenium;
using RazorEngine.Compilation.ImpromptuInterface;
using SeleniumExtras.PageObjects;
using TestProject1.utilities;

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

        public ContactListPage ClickSubmitWithValidCredentials(string email, string password)
        {
            _inputEmail.SendKeys(email);
            _inputPassword.SendKeys(password);

            _logIn.Click();

            return new ContactListPage(_driver);
        }

        public SignUpPage ClickToSignUp()
        {
            _signUpBtn.Click();
            return new SignUpPage(_driver);
        }
    }
}