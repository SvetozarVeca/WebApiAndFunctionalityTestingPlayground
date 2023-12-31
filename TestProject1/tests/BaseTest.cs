﻿using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;
using NUnit.Framework.Interfaces;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Firefox;
using Utilities;
using WebDriverManager.DriverConfigs.Impl;

namespace TestProject1.tests
{
    public class BaseTest
    {
        private ThreadLocal<IWebDriver> _driver = new ThreadLocal<IWebDriver>();
        private string _browserName;
        private ExtentReports _extent;
        private ExtentTest _extentTest;

        [OneTimeSetUp]
        public void Setup()
        {
            string reportPath = $"{FileSystemUtility.GetProjectDirectory()}//index.html";

            ExtentHtmlReporter htmlReporter = new ExtentHtmlReporter(reportPath);

            _extent = new ExtentReports();

            _extent.AttachReporter(htmlReporter);
            _extent.AddSystemInfo("Host Name", "Local Host");
            _extent.AddSystemInfo("Enviroment", "QA");
            _extent.AddSystemInfo("Username", "zmijojed");
        }

        [SetUp]
        public void StartBrowser()
        {
            _extentTest = _extent.CreateTest(TestContext.CurrentContext.Test.Name);
            _browserName = TestContext.Parameters["browserName"];

            if (_browserName == null)
            {
                _browserName = TestContext.Parameters["browserName"];
            }

            InitBrowser(_browserName);

            _driver.Value.Manage().Window.Maximize();
            _driver.Value.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
            _driver.Value.Navigate().GoToUrl("https://thinking-tester-contact-list.herokuapp.com/");

        }

        [TearDown]
        public void AfterTest()
        {
            TestStatus result = TestContext.CurrentContext.Result.Outcome.Status;
            string stackTrace = TestContext.CurrentContext.Result.StackTrace;
            DateTime time = DateTime.Now;
            string fileName = $"Screenshot_{time.ToString("hh mm ss")}.png";

            if (result == TestStatus.Failed)
            {
                _extentTest.Fail("Test Failed", CaptureScreenshot(_driver.Value, fileName));
                _extentTest.Log(Status.Fail, $"test failed with logtrace {stackTrace}");
            }

            _extent.Flush();
            _driver.Value.Close();
        }

        public IWebDriver Driver => _driver.Value;


        public void InitBrowser(string browserName)
        {
            switch (browserName)
            {
                case "Firefox":
                    new WebDriverManager.DriverManager().SetUpDriver(new FirefoxConfig());
                    _driver.Value = new FirefoxDriver();
                    break;
                case "Edge":
                    new WebDriverManager.DriverManager().SetUpDriver(new EdgeConfig());
                    _driver.Value = new EdgeDriver();
                    break;
                case "Chrome":
                    new WebDriverManager.DriverManager().SetUpDriver(new ChromeConfig());
                    _driver.Value = new ChromeDriver();
                    break;
            }
        }

        public MediaEntityModelProvider CaptureScreenshot(IWebDriver driver, string screenshotName)
        {
            ITakesScreenshot ts = (ITakesScreenshot)driver;
            string screenshot = ts.GetScreenshot().AsBase64EncodedString;
            return MediaEntityBuilder.CreateScreenCaptureFromBase64String(screenshot, screenshotName).Build();
        }
    }
}
