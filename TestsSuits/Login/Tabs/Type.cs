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
    public class Type
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
        public void SearchByGaugeType()
        {
            var Columns = driver.FindElement(By.Id("btnColumns"));
            Columns.Click(); Thread.Sleep(500);
            var addColumn = driver.FindElement(By.XPath(".//*[@id='li_GaugeType']/input[4]"));
            addColumn.Click();
            Thread.Sleep(500);
            var SaveBtn = driver.FindElement(By.XPath(".//*[@id='gaugeColumns']/div/div/div[3]/button[1]"));
            SaveBtn.Click();

            Thread.Sleep(1000);

            var gif = driver.FindElement(By.XPath("/html/body/div[27]/div/i/img"));

            new WebDriverWait(driver, TimeSpan.FromSeconds(60)).Until(SeleniumExtras.WaitHelpers.ExpectedConditions.InvisibilityOfElementLocated(By.XPath("/html/body/div[27]/div/i/img")));

            new WebDriverWait(driver, TimeSpan.FromSeconds(60)).Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementExists(By.XPath(".//*[@id='ShowAdvancedFilters']")));

            new WebDriverWait(driver, TimeSpan.FromSeconds(60)).Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(By.XPath(".//*[@id='ShowAdvancedFilters']"))).Click();

            var showAdvFil = driver.FindElement(By.Id("ShowAdvancedFilters"));

            var Type = driver.FindElement(By.XPath(".//*[@id='AdvacedFilters']/ul/li[5]/a"));
            Type.Click();
            var GaugeType = driver.FindElement(By.Id("GaugeType"));

            Actions action = new Actions(driver);
            action.MoveToElement(GaugeType).Click().Build().Perform();
            Thread.Sleep(1000);

            GaugeType.SendKeys("214 PANEL");
            var btnSearch = driver.FindElement(By.Id("btnSearch"));
            btnSearch.Click();
            new WebDriverWait(driver, TimeSpan.FromSeconds(60)).Until(SeleniumExtras.WaitHelpers.ExpectedConditions.InvisibilityOfElementLocated(By.XPath("/html/body/div[27]/div/i/img")));
            String RealValue = driver.FindElement(By.XPath(".//*[@id='gauges']/table/tbody/tr[2]/td[9]")).Text;
            String expText = "214 PANEL";
            StringAssert.AreEqualIgnoringCase(expText, RealValue);
        }
        [Test]
        public void SortByGaugeType()
        {
            var Columns = driver.FindElement(By.Id("btnColumns"));
            Columns.Click(); Thread.Sleep(500);
            var addColumn = driver.FindElement(By.XPath(".//*[@id='li_GaugeType']/input[4]"));
            addColumn.Click();
            Thread.Sleep(500);
            var SaveBtn = driver.FindElement(By.XPath(".//*[@id='gaugeColumns']/div/div/div[3]/button[1]"));
            SaveBtn.Click();
            new WebDriverWait(driver, TimeSpan.FromSeconds(60)).Until(SeleniumExtras.WaitHelpers.ExpectedConditions.InvisibilityOfElementLocated(By.XPath("/html/body/div[27]/div/i/img")));

            var sortByGaugeType = driver.FindElement(By.XPath(".//*[@id='gauges']/table/tbody/tr[1]/th[9]/a"));
            String valBefore = driver.FindElement(By.XPath(".//*[@id='gauges']/table/tbody/tr[2]/td[1]")).Text;
            sortByGaugeType.Click();
            new WebDriverWait(driver, TimeSpan.FromSeconds(60)).Until(SeleniumExtras.WaitHelpers.ExpectedConditions.InvisibilityOfElementLocated(By.XPath("/html/body/div[27]/div/i/img")));
            String RealText = driver.FindElement(By.XPath(".//*[@id='gauges']/table/tbody/tr[2]/td[1]")).Text;
            StringAssert.AreNotEqualIgnoringCase(valBefore, RealText);
        }

        [Test]
        public void SearchByGaugeClass()
        {
            var Columns = driver.FindElement(By.Id("btnColumns"));
            Columns.Click(); Thread.Sleep(500);
            var addColumn = driver.FindElement(By.XPath(".//*[@id='li_GaugeClass']/input[4]"));
            addColumn.Click();
            Thread.Sleep(500);
            var SaveBtn = driver.FindElement(By.XPath(".//*[@id='gaugeColumns']/div/div/div[3]/button[1]"));
            SaveBtn.Click();

            Thread.Sleep(1000);

            var gif = driver.FindElement(By.XPath("/html/body/div[27]/div/i/img"));

            new WebDriverWait(driver, TimeSpan.FromSeconds(60)).Until(SeleniumExtras.WaitHelpers.ExpectedConditions.InvisibilityOfElementLocated(By.XPath("/html/body/div[27]/div/i/img")));

            new WebDriverWait(driver, TimeSpan.FromSeconds(60)).Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementExists(By.XPath(".//*[@id='ShowAdvancedFilters']")));

            new WebDriverWait(driver, TimeSpan.FromSeconds(60)).Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(By.XPath(".//*[@id='ShowAdvancedFilters']"))).Click();

            var showAdvFil = driver.FindElement(By.Id("ShowAdvancedFilters"));

            var Type = driver.FindElement(By.XPath(".//*[@id='AdvacedFilters']/ul/li[5]/a"));
            Type.Click();
            var GaugeClass = driver.FindElement(By.Id("GaugeClass"));

            Actions action = new Actions(driver);
            action.MoveToElement(GaugeClass).Click().Build().Perform();
            Thread.Sleep(1000);

            GaugeClass.SendKeys("test");
            var btnSearch = driver.FindElement(By.Id("btnSearch"));
            btnSearch.Click();
            new WebDriverWait(driver, TimeSpan.FromSeconds(60)).Until(SeleniumExtras.WaitHelpers.ExpectedConditions.InvisibilityOfElementLocated(By.XPath("/html/body/div[27]/div/i/img")));
            String RealValue = driver.FindElement(By.XPath(".//*[@id='gauges']/table/tbody/tr[2]/td[9]")).Text;
            String expText = "test";
            StringAssert.AreEqualIgnoringCase(expText, RealValue);
        }


        [Test]
        public void SearchByGaugeNominal()
        {
            var showAdvFil = driver.FindElement(By.Id("ShowAdvancedFilters"));
            showAdvFil.Click(); Thread.Sleep(500);

            var Type = driver.FindElement(By.XPath(".//*[@id='AdvacedFilters']/ul/li[5]/a"));
            Type.Click(); Thread.Sleep(500);
            var GaugeNominal = driver.FindElement(By.Id("Nominal"));

            Actions action = new Actions(driver);
            action.MoveToElement(GaugeNominal).Click().Build().Perform();
            Thread.Sleep(1000);

            GaugeNominal.SendKeys("-60.000 KPA");
            var btnSearch = driver.FindElement(By.Id("btnSearch"));
            btnSearch.Click();
            new WebDriverWait(driver, TimeSpan.FromSeconds(60)).Until(SeleniumExtras.WaitHelpers.ExpectedConditions.InvisibilityOfElementLocated(By.XPath("/html/body/div[27]/div/i/img")));
            String RealValue = driver.FindElement(By.XPath(".//*[@id='gauges']/table/tbody/tr[2]/td[3]")).Text;
            String expText = "-60.000 KPA";
            StringAssert.AreEqualIgnoringCase(expText, RealValue);
        }
        [Test]
        public void SortByGaugeNominal()
        {
            var sortByGaugeNominal = driver.FindElement(By.XPath(".//*[@id='gauges']/table/tbody/tr[1]/th[3]/a"));
            String valBefore = driver.FindElement(By.XPath(".//*[@id='gauges']/table/tbody/tr[2]/td[1]")).Text;
            sortByGaugeNominal.Click();
            new WebDriverWait(driver, TimeSpan.FromSeconds(60)).Until(SeleniumExtras.WaitHelpers.ExpectedConditions.InvisibilityOfElementLocated(By.XPath("/html/body/div[27]/div/i/img")));
            String RealText = driver.FindElement(By.XPath(".//*[@id='gauges']/table/tbody/tr[3]/td[1]")).Text;
            StringAssert.AreNotEqualIgnoringCase(valBefore, RealText);
        }
        [Test]
        public void SearchByGaugeTolerance()
        {
            var Columns = driver.FindElement(By.Id("btnColumns"));
            Columns.Click(); Thread.Sleep(500);
            var addColumn = driver.FindElement(By.XPath(".//*[@id='li_Tolerance']/input[4]"));
            addColumn.Click();
            Thread.Sleep(500);
            var SaveBtn = driver.FindElement(By.XPath(".//*[@id='gaugeColumns']/div/div/div[3]/button[1]"));
            SaveBtn.Click();

            Thread.Sleep(1000);

            var gif = driver.FindElement(By.XPath("/html/body/div[27]/div/i/img"));

            new WebDriverWait(driver, TimeSpan.FromSeconds(60)).Until(SeleniumExtras.WaitHelpers.ExpectedConditions.InvisibilityOfElementLocated(By.XPath("/html/body/div[27]/div/i/img")));

            new WebDriverWait(driver, TimeSpan.FromSeconds(60)).Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementExists(By.XPath(".//*[@id='ShowAdvancedFilters']")));

            new WebDriverWait(driver, TimeSpan.FromSeconds(60)).Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(By.XPath(".//*[@id='ShowAdvancedFilters']"))).Click();

            var showAdvFil = driver.FindElement(By.Id("ShowAdvancedFilters"));

            var Type = driver.FindElement(By.XPath(".//*[@id='AdvacedFilters']/ul/li[5]/a"));
            Type.Click();
            var Tolerance = driver.FindElement(By.Id("Tolerance"));

            Actions action = new Actions(driver);
            action.MoveToElement(Tolerance).Click().Build().Perform();
            Thread.Sleep(1000);

            Tolerance.SendKeys("Y7965");
            var btnSearch = driver.FindElement(By.Id("btnSearch"));
            btnSearch.Click();
            new WebDriverWait(driver, TimeSpan.FromSeconds(60)).Until(SeleniumExtras.WaitHelpers.ExpectedConditions.InvisibilityOfElementLocated(By.XPath("/html/body/div[27]/div/i/img")));
            String RealValue = driver.FindElement(By.XPath(".//*[@id='gauges']/table/tbody/tr[2]/td[9]")).Text;
            String expText = "Y7965";
            StringAssert.AreEqualIgnoringCase(expText, RealValue);
        }
        [Test]
        public void SortByTolerance()
        {
            var Columns = driver.FindElement(By.Id("btnColumns"));
            Columns.Click(); Thread.Sleep(500);
            var addColumn = driver.FindElement(By.XPath(".//*[@id='li_Tolerance']/input[4]"));
            addColumn.Click();
            Thread.Sleep(500);
            var SaveBtn = driver.FindElement(By.XPath(".//*[@id='gaugeColumns']/div/div/div[3]/button[1]"));
            SaveBtn.Click();
            new WebDriverWait(driver, TimeSpan.FromSeconds(60)).Until(SeleniumExtras.WaitHelpers.ExpectedConditions.InvisibilityOfElementLocated(By.XPath("/html/body/div[27]/div/i/img")));

            var sortByTolerance = driver.FindElement(By.XPath(".//*[@id='gauges']/table/tbody/tr[1]/th[9]/a"));
            String valBefore = driver.FindElement(By.XPath(".//*[@id='gauges']/table/tbody/tr[2]/td[1]")).Text;
            sortByTolerance.Click();
            new WebDriverWait(driver, TimeSpan.FromSeconds(60)).Until(SeleniumExtras.WaitHelpers.ExpectedConditions.InvisibilityOfElementLocated(By.XPath("/html/body/div[27]/div/i/img")));
            String RealText = driver.FindElement(By.XPath(".//*[@id='gauges']/table/tbody/tr[2]/td[1]")).Text;
            StringAssert.AreNotEqualIgnoringCase(valBefore, RealText);
        }

        [TearDown]
        public void Finish()
        {
            driver.Quit();
        }

    }
}
