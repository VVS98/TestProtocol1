using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using NUnit.Framework;
using System.Threading;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium.Interactions;

namespace Tabs
{
    class Login
    {
        IWebDriver driver;

        public static string BaseUrl = "http://Shvo:Alphredwhite98@axaxctest01/axcweb/Account";
        public static string LoggedInPageTitle = "http://Shvo:Alphredwhite98@axaxctest01/axcweb/Gauge";

        [SetUp]
        public void SetUp()
        {
            driver = new ChromeDriver();
            driver.Manage().Window.FullScreen();
        }

        [Test]
        public void LogInWithCorrectEmployeeIdPassword()
        {
            driver.Navigate().GoToUrl(BaseUrl);
            driver.FindElement(By.Id("EmployeeId")).SendKeys("system");
            driver.FindElement(By.Id("Password")).SendKeys("system");
            driver.FindElement(By.ClassName("btn-default")).Click();

            new WebDriverWait(driver, TimeSpan.FromSeconds(60)).Until(SeleniumExtras.WaitHelpers.ExpectedConditions.UrlContains("axaxctest01/axcweb/Gauge"));

            String currentURL = driver.Url;
            Assert.AreEqual(currentURL, LoggedInPageTitle);
        }

        [Test]
        public void LogInWithCorrectEmployeeIdIncorrectPassword()
        {
            driver.Navigate().GoToUrl(BaseUrl);
            driver.FindElement(By.Id("EmployeeId")).SendKeys("system");
            driver.FindElement(By.Id("Password")).SendKeys("syste");
            driver.FindElement(By.ClassName("btn-default")).Click();

            new WebDriverWait(driver, TimeSpan.FromSeconds(60)).Until(SeleniumExtras.WaitHelpers.ExpectedConditions.UrlContains("axaxctest01/axcweb/Account"));

            String currentURL = driver.Url;
            Assert.AreEqual(currentURL, currentURL);
        }

        [Test]
        public void LogInWithInCorrectEmployeeIdCorrectPassword()
        {
            driver.Navigate().GoToUrl(BaseUrl);
            driver.FindElement(By.Id("EmployeeId")).SendKeys("ystem");
            driver.FindElement(By.Id("Password")).SendKeys("system");
            driver.FindElement(By.ClassName("btn-default")).Click();

            new WebDriverWait(driver, TimeSpan.FromSeconds(60)).Until(SeleniumExtras.WaitHelpers.ExpectedConditions.UrlContains("axaxctest01/axcweb/Account"));
            String currentURL = driver.Url;
            Assert.AreEqual(currentURL, currentURL);
        }

        [Test]
        public void LogInWithoutEmployeeId()
        {
            driver.Navigate().GoToUrl(BaseUrl);
            driver.FindElement(By.Id("Password")).SendKeys("system");
            driver.FindElement(By.ClassName("btn-default")).Click();

            new WebDriverWait(driver, TimeSpan.FromSeconds(60)).Until(SeleniumExtras.WaitHelpers.ExpectedConditions.UrlContains("axaxctest01/axcweb/Account"));

            String currentURL = driver.Url;
            Assert.AreEqual(currentURL, currentURL);
        }

        [Test]
        public void LogInWithoutPassword()
        {
            driver.Navigate().GoToUrl(BaseUrl);
            driver.FindElement(By.Id("EmployeeId")).SendKeys("system");
            driver.FindElement(By.ClassName("btn-default")).Click();

            new WebDriverWait(driver, TimeSpan.FromSeconds(60)).Until(SeleniumExtras.WaitHelpers.ExpectedConditions.UrlContains("axaxctest01/axcweb/Account"));
            String currentURL = driver.Url;
            Assert.AreEqual(currentURL, currentURL);
        }

        [Test]                   
        public void CopyPassword()
        {
            driver.Navigate().GoToUrl(BaseUrl);
            var login = driver.FindElement(By.Id("EmployeeId")); login.SendKeys("");
            Thread.Sleep(2000);
            var pswd = driver.FindElement(By.Id("Password")); pswd.SendKeys("system");
            Thread.Sleep(2000);

            pswd.Click();
            pswd.SendKeys(Keys.Command + "A");
            Thread.Sleep(2000);
            pswd.SendKeys(Keys.Command + "c");
            login.SendKeys(Keys.Command + "v");
            Thread.Sleep(2000);

            string actVal = login.Text;
            Assert.AreEqual("", actVal);
        }

        [Test]
        public void PressBackButton()
        {
            driver.Navigate().GoToUrl(BaseUrl);
            driver.FindElement(By.Id("EmployeeId")).SendKeys("system");
            driver.FindElement(By.Id("Password")).SendKeys("system");
            driver.FindElement(By.ClassName("btn-default")).Click();

            new WebDriverWait(driver, TimeSpan.FromSeconds(60)).Until(SeleniumExtras.WaitHelpers.ExpectedConditions.UrlContains("axaxctest01/axcweb/Account"));


            driver.Navigate().Back();

            String currentURL = driver.Url;
            Assert.AreEqual(LoggedInPageTitle, currentURL);
        }

        [Test]
        public void PasteLinkWithOutAuthorization()
        {
            driver.Navigate().GoToUrl(LoggedInPageTitle);
            Thread.Sleep(2000);

            String currentURL = driver.Url;
            Assert.AreEqual(BaseUrl, currentURL);
        }
        [Test]
        public void ErrorMessage()
        {
            driver.Navigate().GoToUrl(BaseUrl);
            driver.FindElement(By.Id("EmployeeId")).SendKeys("system");
            driver.FindElement(By.ClassName("btn-default")).Click();
            var errorMessage = driver.FindElement(By.XPath("/html/body/div/div/div/div/div/div/form/div[3]/div/span"));
            new WebDriverWait(driver, TimeSpan.FromSeconds(60))
                .Until(SeleniumExtras.WaitHelpers.ExpectedConditions.
                       TextToBePresentInElement(errorMessage, "Login or password is incorrect"));
        }
        [TearDown]
        public void Finish()
        {
            driver.Close();
        }
    }
}