using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using NUnit.Framework;
using System.Threading;
using System.Windows;
using System.Windows.Forms;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium.Interactions;

namespace Tabs
{
    public class Status
    {
        IWebDriver driver;

        public static string BaseUrl = "http://Shvo:Alphredwhite98@axaxctest01/axcweb/Account";
        public static string LoggedInPageTitle = "http://Shvo:Alphredwhite98@axaxctest01/axcweb/Gauge";

        [SetUp]
        public void SetUp()
        {
            driver = new ChromeDriver();
            driver.Manage().Window.FullScreen();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(70);
            driver.Navigate().GoToUrl(BaseUrl);
            var login = driver.FindElement(By.Id("EmployeeId")); login.SendKeys("system");

            var pswd = driver.FindElement(By.Id("Password")); pswd.SendKeys("system");

            var submit = driver.FindElement(By.ClassName("btn-default")); submit.Click();
            driver.Navigate().GoToUrl(LoggedInPageTitle);
        }
        [Test]
        public void SearchByActiveStatus()
        {
            var showAdvFil = driver.FindElement(By.Id("ShowAdvancedFilters"));
            showAdvFil.Click();
            new WebDriverWait(driver, TimeSpan.FromSeconds(60)).Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(By.XPath(".//*[@id='AdvacedFilters']/ul/li[7]/a")));
            var Status = driver.FindElement(By.XPath(".//*[@id='AdvacedFilters']/ul/li[7]/a"));
            Status.Click();
            var ActiveStatus = driver.FindElement(By.XPath("//*[@id='gauge_filter_statuses']/div[1]/div[1]/div/div/label"));

            Actions action = new Actions(driver);
            action.MoveToElement(ActiveStatus).Click().Build().Perform();

            ActiveStatus.Click();
            new WebDriverWait(driver, TimeSpan.FromSeconds(60)).Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(By.Id("btnSearch")));

            var btnSearch = driver.FindElement(By.Id("btnSearch"));
            btnSearch.Click();
            new WebDriverWait(driver, TimeSpan.FromSeconds(60)).Until(SeleniumExtras.WaitHelpers.ExpectedConditions.InvisibilityOfElementLocated(By.XPath("/html/body/div[27]/div/i/img")));
            String RealValue = driver.FindElement(By.XPath(".//*[@id='gauges']/table/tbody/tr[2]/td[7]")).Text;
            String expText = "A";
            StringAssert.AreEqualIgnoringCase(expText, RealValue);
        }

        [Test]
        public void SearchByInActiveStatus()
        {
            var showAdvFil = driver.FindElement(By.Id("ShowAdvancedFilters"));
            showAdvFil.Click();
            new WebDriverWait(driver, TimeSpan.FromSeconds(60)).Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(By.XPath(".//*[@id='AdvacedFilters']/ul/li[7]/a")));
            var Status = driver.FindElement(By.XPath(".//*[@id='AdvacedFilters']/ul/li[7]/a"));
            Status.Click();
            var InActiveStatus = driver.FindElement(By.XPath("//*[@id='gauge_filter_statuses']/div[2]/div[1]/div/div/label"));
            Actions action = new Actions(driver);
            action.MoveToElement(InActiveStatus).Click().Build().Perform();

            InActiveStatus.Click();
            new WebDriverWait(driver, TimeSpan.FromSeconds(60)).Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(By.Id("btnSearch")));

            var btnSearch = driver.FindElement(By.Id("btnSearch"));
            btnSearch.Click();
            new WebDriverWait(driver, TimeSpan.FromSeconds(60)).Until(SeleniumExtras.WaitHelpers.ExpectedConditions.InvisibilityOfElementLocated(By.XPath("/html/body/div[27]/div/i/img")));
            String RealValue = driver.FindElement(By.XPath(".//*[@id='gauges']/table/tbody/tr[2]/td[7]")).Text;
            String expText = "I";
            StringAssert.AreEqualIgnoringCase(expText, RealValue);
        }

        [Test]
        public void SearchByCalibrationStatus()
        {
            var showAdvFil = driver.FindElement(By.Id("ShowAdvancedFilters"));
            showAdvFil.Click();
            new WebDriverWait(driver, TimeSpan.FromSeconds(60)).Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(By.XPath(".//*[@id='AdvacedFilters']/ul/li[7]/a")));
            var Status = driver.FindElement(By.XPath(".//*[@id='AdvacedFilters']/ul/li[7]/a"));
            Status.Click();
            var CalibrationStatus = driver.FindElement(By.XPath("//*[@id='gauge_filter_statuses']/div[3]/div[1]/div/div/label"));
            Actions action = new Actions(driver);
            action.MoveToElement(CalibrationStatus).Click().Build().Perform();

            CalibrationStatus.Click();
            new WebDriverWait(driver, TimeSpan.FromSeconds(60)).Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(By.Id("btnSearch")));

            var btnSearch = driver.FindElement(By.Id("btnSearch"));
            btnSearch.Click();
            new WebDriverWait(driver, TimeSpan.FromSeconds(60)).Until(SeleniumExtras.WaitHelpers.ExpectedConditions.InvisibilityOfElementLocated(By.XPath("/html/body/div[27]/div/i/img")));
            String RealValue = driver.FindElement(By.XPath(".//*[@id='gauges']/table/tbody/tr[2]/td[7]")).Text;
            String expText = "IC";
            StringAssert.AreEqualIgnoringCase(expText, RealValue);
        }

        [Test]
        public void SearchByServiceStatus()
        {
            var showAdvFil = driver.FindElement(By.Id("ShowAdvancedFilters"));
            showAdvFil.Click();
            new WebDriverWait(driver, TimeSpan.FromSeconds(60)).Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(By.XPath(".//*[@id='AdvacedFilters']/ul/li[7]/a")));
            var Status = driver.FindElement(By.XPath(".//*[@id='AdvacedFilters']/ul/li[7]/a"));
            Status.Click();
            var ServiceStatus = driver.FindElement(By.XPath("//*[@id='gauge_filter_statuses']/div[1]/div[2]/div/div/label"));
            Actions action = new Actions(driver);
            action.MoveToElement(ServiceStatus).Click().Build().Perform();

            ServiceStatus.Click();
            new WebDriverWait(driver, TimeSpan.FromSeconds(60)).Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(By.Id("btnSearch")));

            var btnSearch = driver.FindElement(By.Id("btnSearch"));
            btnSearch.Click();
            new WebDriverWait(driver, TimeSpan.FromSeconds(60)).Until(SeleniumExtras.WaitHelpers.ExpectedConditions.InvisibilityOfElementLocated(By.XPath("/html/body/div[27]/div/i/img")));
            String RealValue = driver.FindElement(By.XPath(".//*[@id='gauges']/table/tbody/tr[2]/td[7]")).Text;
            String expText = "IU";
            StringAssert.AreEqualIgnoringCase(expText, RealValue);
        }

        [Test]
        public void SearchByLentStatus()
        {
            var showAdvFil = driver.FindElement(By.Id("ShowAdvancedFilters"));
            showAdvFil.Click();
            new WebDriverWait(driver, TimeSpan.FromSeconds(60)).Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(By.XPath(".//*[@id='AdvacedFilters']/ul/li[7]/a")));
            var Status = driver.FindElement(By.XPath(".//*[@id='AdvacedFilters']/ul/li[7]/a"));
            Status.Click();
            var LentStatus = driver.FindElement(By.XPath("//*[@id='gauge_filter_statuses']/div[2]/div[2]/div/div/label"));
            Actions action = new Actions(driver);
            action.MoveToElement(LentStatus).Click().Build().Perform();

            LentStatus.Click();
            new WebDriverWait(driver, TimeSpan.FromSeconds(60)).Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(By.Id("btnSearch")));

            var btnSearch = driver.FindElement(By.Id("btnSearch"));
            btnSearch.Click();
            new WebDriverWait(driver, TimeSpan.FromSeconds(60)).Until(SeleniumExtras.WaitHelpers.ExpectedConditions.InvisibilityOfElementLocated(By.XPath("/html/body/div[27]/div/i/img")));
            String RealValue = driver.FindElement(By.XPath(".//*[@id='gauges']/table/tbody/tr[2]/td[7]")).Text;
            String expText = "AL";
            StringAssert.AreEqualIgnoringCase(expText, RealValue);
        }
        [Test]
        public void SearchByStorageStatus()
        {
            var showAdvFil = driver.FindElement(By.Id("ShowAdvancedFilters"));
            showAdvFil.Click();
            new WebDriverWait(driver, TimeSpan.FromSeconds(60)).Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(By.XPath(".//*[@id='AdvacedFilters']/ul/li[7]/a")));
            var Status = driver.FindElement(By.XPath(".//*[@id='AdvacedFilters']/ul/li[7]/a"));
            Status.Click();
            var StorageStatus = driver.FindElement(By.XPath("//*[@id='gauge_filter_statuses']/div[3]/div[2]/div/div/label"));
            Actions action = new Actions(driver);
            action.MoveToElement(StorageStatus).Click().Build().Perform();

            StorageStatus.Click();
            new WebDriverWait(driver, TimeSpan.FromSeconds(60)).Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(By.Id("btnSearch")));

            var btnSearch = driver.FindElement(By.Id("btnSearch"));
            btnSearch.Click();
            new WebDriverWait(driver, TimeSpan.FromSeconds(60)).Until(SeleniumExtras.WaitHelpers.ExpectedConditions.InvisibilityOfElementLocated(By.XPath("/html/body/div[27]/div/i/img")));
            String RealValue = driver.FindElement(By.XPath(".//*[@id='gauges']/table/tbody/tr[2]/td[7]")).Text;
            String expText = "AF";
            StringAssert.AreEqualIgnoringCase(expText, RealValue);
        }
        [Test]
        public void SearchByMissingStatus()
        {
            var showAdvFil = driver.FindElement(By.Id("ShowAdvancedFilters"));
            showAdvFil.Click();
            new WebDriverWait(driver, TimeSpan.FromSeconds(60)).Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(By.XPath(".//*[@id='AdvacedFilters']/ul/li[7]/a")));
            var Status = driver.FindElement(By.XPath(".//*[@id='AdvacedFilters']/ul/li[7]/a"));
            Status.Click();
            var MissingStatus = driver.FindElement(By.XPath("//*[@id='gauge_filter_statuses']/div[1]/div[3]/div/div/label"));
            Actions action = new Actions(driver);
            action.MoveToElement(MissingStatus).Click().Build().Perform();

            MissingStatus.Click();
            new WebDriverWait(driver, TimeSpan.FromSeconds(60)).Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(By.Id("btnSearch")));

            var btnSearch = driver.FindElement(By.Id("btnSearch"));
            btnSearch.Click();
            new WebDriverWait(driver, TimeSpan.FromSeconds(60)).Until(SeleniumExtras.WaitHelpers.ExpectedConditions.InvisibilityOfElementLocated(By.XPath("/html/body/div[27]/div/i/img")));
            String RealValue = driver.FindElement(By.XPath(".//*[@id='gauges']/table/tbody/tr[2]/td[7]")).Text;
            String expText = "AS";
            StringAssert.AreEqualIgnoringCase(expText, RealValue);
        }

        [Test]
        public void SearchByScruppedStatus()
        {
            var showAdvFil = driver.FindElement(By.Id("ShowAdvancedFilters"));
            showAdvFil.Click();
            new WebDriverWait(driver, TimeSpan.FromSeconds(60)).Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(By.XPath(".//*[@id='AdvacedFilters']/ul/li[7]/a")));
            var Status = driver.FindElement(By.XPath(".//*[@id='AdvacedFilters']/ul/li[7]/a"));
            Status.Click();

            var ScruppedStatus = driver.FindElement(By.XPath("//*[@id='gauge_filter_statuses']/div[2]/div[3]/div/div/label"));
            new WebDriverWait(driver, TimeSpan.FromSeconds(60)).Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(By.XPath("//*[@id='gauge_filter_statuses']/div[2]/div[3]/div/div/label")));
            Actions action = new Actions(driver);
            action.MoveToElement(ScruppedStatus).Click().Build().Perform();

            var IncludeScruppedStatus = driver.FindElement(By.XPath("//*[@id='AdvacedFilters']/div[2]/div[1]/div/div/label"));
            new WebDriverWait(driver, TimeSpan.FromSeconds(60)).Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(By.XPath("//*[@id='AdvacedFilters']/div[2]/div[1]/div/div/label")));
            Actions action1 = new Actions(driver);
            action1.MoveToElement(IncludeScruppedStatus).Click().Build().Perform();

            new WebDriverWait(driver, TimeSpan.FromSeconds(60)).Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(By.Id("btnSearch")));

            var btnSearch = driver.FindElement(By.Id("btnSearch"));
            btnSearch.Click();
            new WebDriverWait(driver, TimeSpan.FromSeconds(60)).Until(SeleniumExtras.WaitHelpers.ExpectedConditions.InvisibilityOfElementLocated(By.XPath("/html/body/div[27]/div/i/img")));
            String RealValue = driver.FindElement(By.XPath(".//*[@id='gauges']/table/tbody/tr[2]/td[7]")).Text;
            String expText = "ISK";
            StringAssert.AreEqualIgnoringCase(expText, RealValue);
        }

        [TearDown]
        public void Finish()
        {
            driver.Quit();
        }

    }
}
