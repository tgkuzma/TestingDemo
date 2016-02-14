using System;
using System.IO;
using System.Reflection;
using AcceptanceTests.Extensions;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.IE;

namespace AcceptanceTests
{
    [TestFixture]
    public class HomeTests
    {
        private IWebDriver _driver;
        private readonly string _baseUrl = "http://localhost/Testing/";

        #region Setup / Tear Down

        /// <summary>
        /// This runs only once at the beginning of all tests and is used for all tests in the
        /// class.
        /// </summary>
        [OneTimeSetUp]
        public void InitialSetup()
        {
            var codeBase = Assembly.GetExecutingAssembly().CodeBase;
            var uri = new UriBuilder(codeBase);
            var path = Uri.UnescapeDataString(uri.Path);
            var webDriversLocation = Path.GetFullPath(Path.Combine(Path.GetDirectoryName(path), @"../../WebDrivers")) + @"\";

            var environmentPath = Environment.GetEnvironmentVariable("PATH");
            Environment.SetEnvironmentVariable("PATH", environmentPath + ";" + webDriversLocation);
        }

        /// <summary>
        /// This runs only once at the end of all tests and is used for all tests in the class.
        /// </summary>
        [OneTimeTearDown]
        public void FinalTearDown()
        {
        }

        /// <summary>
        /// This setup funcitons runs before each test method
        /// </summary>
        [SetUp]
        public void SetupForEachTest()
        {
        }

        /// <summary>
        /// This setup funcitons runs after each test method
        /// </summary>
        [TearDown]
        public void TearDownForEachTest()
        {
            _driver.Quit();
        }

        #endregion Setup / Tear Down

        [TestCase("CH", "10/1/1970")]
        [TestCase("IE", "10/2/1970")]
        [TestCase("FF", "10/3/1970")]
        public void ClickingAdd_AddsNewCustomerToList(string driverName, string birthday)
        {
            //Arrange

            _driver = GetDriver(driverName);
            _driver.Navigate().GoToUrl(_baseUrl);
            _driver.FindElement(By.Id("newCustomerFirstName")).SendKeys("Martin");
            _driver.FindElement(By.Id("newCustomerLastName")).SendKeys("Fowler");
            _driver.FindElement(By.Id("newCustomerDOB")).SendKeys(birthday);

            //Act
            _driver.FindElement(By.XPath("//p[@onclick='addNewCustomer();']")).ClickAndWait(1);
            var nameCell = _driver.FindElement(By.XPath("//table[@id='customerDisplayTable']/tbody/tr[last()]/td"));
            var birthdayCell = _driver.FindElement(By.XPath("//table[@id='customerDisplayTable']/tbody/tr[last()]/td[last()]"));

            //Assert
            Assert.AreEqual("Martin Fowler", nameCell.Text);
            Assert.AreEqual(birthday, birthdayCell.Text);
        }

        private static IWebDriver GetDriver(string driverName)
        {
            switch (driverName)
            {
                case "CH":
                    return new ChromeDriver();
                case "IE":
                    var options = new InternetExplorerOptions
                    {
                        IgnoreZoomLevel = true
                    };
                    return new InternetExplorerDriver(options);
            }
            return new FirefoxDriver();
        }
    }
}
