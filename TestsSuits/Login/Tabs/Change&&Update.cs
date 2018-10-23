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
    public class Change__Update
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
        public void SearchByDeliveryDate()
        {
            var Columns = driver.FindElement(By.Id("btnColumns"));
            Columns.Click(); Thread.Sleep(500);
            var addColumn = driver.FindElement(By.XPath(".//*[@id='li_DeliveryDate']/input[4]"));
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

            var ChangeUpdate = driver.FindElement(By.XPath(".//*[@id='AdvacedFilters']/ul/li[6]/a"));
            ChangeUpdate.Click();
            var DeliverDate = driver.FindElement(By.Id("DeliveryDate"));

            Actions action = new Actions(driver);
            action.MoveToElement(DeliverDate).Click().Build().Perform();
            Thread.Sleep(1000);

            DeliverDate.SendKeys("1998-08-03 to 1998-08-03");
            var btnSearch = driver.FindElement(By.Id("btnSearch"));
            btnSearch.Click();
            new WebDriverWait(driver, TimeSpan.FromSeconds(60)).Until(SeleniumExtras.WaitHelpers.ExpectedConditions.InvisibilityOfElementLocated(By.XPath("/html/body/div[27]/div/i/img")));
            String RealValue = driver.FindElement(By.XPath(".//*[@id='gauges']/table/tbody/tr[2]/td[9]")).Text;
            String expText = "1998-08-03";
            StringAssert.AreEqualIgnoringCase(expText, RealValue);
        }
        [Test]
        public void SortByDeliveryDate()
        {
            var Columns = driver.FindElement(By.Id("btnColumns"));
            Columns.Click(); Thread.Sleep(500);
            var addColumn = driver.FindElement(By.XPath(".//*[@id='li_DeliveryDate']/input[4]"));
            addColumn.Click();
            Thread.Sleep(500);
            var SaveBtn = driver.FindElement(By.XPath(".//*[@id='gaugeColumns']/div/div/div[3]/button[1]"));
            SaveBtn.Click();
            new WebDriverWait(driver, TimeSpan.FromSeconds(60)).Until(SeleniumExtras.WaitHelpers.ExpectedConditions.InvisibilityOfElementLocated(By.XPath("/html/body/div[27]/div/i/img")));

            var sortByCreateDate = driver.FindElement(By.XPath(".//*[@id='gauges']/table/tbody/tr[1]/th[9]/a"));
            String valBefore = driver.FindElement(By.XPath(".//*[@id='gauges']/table/tbody/tr[2]/td[1]")).Text;
            sortByCreateDate.Click();
            new WebDriverWait(driver, TimeSpan.FromSeconds(60)).Until(SeleniumExtras.WaitHelpers.ExpectedConditions.InvisibilityOfElementLocated(By.XPath("/html/body/div[27]/div/i/img")));
            String RealText = driver.FindElement(By.XPath(".//*[@id='gauges']/table/tbody/tr[2]/td[1]")).Text;
            StringAssert.AreNotEqualIgnoringCase(valBefore, RealText);
        }

        [Test]
        public void SearchByWarrantyDate()
        {
            var Columns = driver.FindElement(By.Id("btnColumns"));
            Columns.Click(); Thread.Sleep(500);
            var addColumn = driver.FindElement(By.XPath(".//*[@id='li_WarrantyDate']/input[4]"));
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

            var ChangeUpdate = driver.FindElement(By.XPath(".//*[@id='AdvacedFilters']/ul/li[6]/a"));
            ChangeUpdate.Click();
            var WarrantyDate = driver.FindElement(By.Id("WarrantyDate"));

            Actions action = new Actions(driver);
            action.MoveToElement(WarrantyDate).Click().Build().Perform();
            Thread.Sleep(1000);

            WarrantyDate.SendKeys("2014-06-19 to 2014-06-19");
            var btnSearch = driver.FindElement(By.Id("btnSearch"));
            btnSearch.Click();
            new WebDriverWait(driver, TimeSpan.FromSeconds(60)).Until(SeleniumExtras.WaitHelpers.ExpectedConditions.InvisibilityOfElementLocated(By.XPath("/html/body/div[27]/div/i/img")));
            String RealValue = driver.FindElement(By.XPath(".//*[@id='gauges']/table/tbody/tr[2]/td[9]")).Text;
            String expText = "2014-06-19";
            StringAssert.AreEqualIgnoringCase(expText, RealValue);
        }
        [Test]
        public void SortByWarrantyDate()
        {
            var Columns = driver.FindElement(By.Id("btnColumns"));
            Columns.Click(); Thread.Sleep(500);
            var addColumn = driver.FindElement(By.XPath(".//*[@id='li_WarrantyDate']/input[4]"));
            addColumn.Click();
            Thread.Sleep(500);
            var SaveBtn = driver.FindElement(By.XPath(".//*[@id='gaugeColumns']/div/div/div[3]/button[1]"));
            SaveBtn.Click();
            new WebDriverWait(driver, TimeSpan.FromSeconds(60)).Until(SeleniumExtras.WaitHelpers.ExpectedConditions.InvisibilityOfElementLocated(By.XPath("/html/body/div[27]/div/i/img")));

            var sortByWarrantyDate = driver.FindElement(By.XPath(".//*[@id='gauges']/table/tbody/tr[1]/th[9]/a"));
            String valBefore = driver.FindElement(By.XPath(".//*[@id='gauges']/table/tbody/tr[2]/td[1]")).Text;
            sortByWarrantyDate.Click();
            new WebDriverWait(driver, TimeSpan.FromSeconds(60)).Until(SeleniumExtras.WaitHelpers.ExpectedConditions.InvisibilityOfElementLocated(By.XPath("/html/body/div[27]/div/i/img")));
            String RealText = driver.FindElement(By.XPath(".//*[@id='gauges']/table/tbody/tr[2]/td[1]")).Text;
            StringAssert.AreNotEqualIgnoringCase(valBefore, RealText);
        }


        [Test]
        public void SearchByReceptionDate()
        {
            var Columns = driver.FindElement(By.Id("btnColumns"));
            Columns.Click(); Thread.Sleep(500);
            var addColumn = driver.FindElement(By.XPath(".//*[@id='li_ReceptionDate']/input[4]"));
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

            var ChangeUpdate = driver.FindElement(By.XPath(".//*[@id='AdvacedFilters']/ul/li[6]/a"));
            ChangeUpdate.Click();
            var ReceptionDate = driver.FindElement(By.Id("ReceptionDate"));

            Actions action = new Actions(driver);
            action.MoveToElement(ReceptionDate).Click().Build().Perform();
            Thread.Sleep(1000);

            ReceptionDate.SendKeys("2018-05-25 to 2018-05-25");
            var btnSearch = driver.FindElement(By.Id("btnSearch"));
            btnSearch.Click();
            new WebDriverWait(driver, TimeSpan.FromSeconds(60)).Until(SeleniumExtras.WaitHelpers.ExpectedConditions.InvisibilityOfElementLocated(By.XPath("/html/body/div[27]/div/i/img")));
            String RealValue = driver.FindElement(By.XPath(".//*[@id='gauges']/table/tbody/tr[2]/td[9]")).Text;
            String expText = "2018-05-25";
            StringAssert.AreEqualIgnoringCase(expText, RealValue);
        }
        [Test]
        public void SortByReceptionDate()
        {
            var Columns = driver.FindElement(By.Id("btnColumns"));
            Columns.Click(); Thread.Sleep(500);
            var addColumn = driver.FindElement(By.XPath(".//*[@id='li_ReceptionDate']/input[4]"));
            addColumn.Click();
            Thread.Sleep(500);
            var SaveBtn = driver.FindElement(By.XPath(".//*[@id='gaugeColumns']/div/div/div[3]/button[1]"));
            SaveBtn.Click();
            new WebDriverWait(driver, TimeSpan.FromSeconds(60)).Until(SeleniumExtras.WaitHelpers.ExpectedConditions.InvisibilityOfElementLocated(By.XPath("/html/body/div[27]/div/i/img")));

            var sortByReceptionDate = driver.FindElement(By.XPath(".//*[@id='gauges']/table/tbody/tr[1]/th[9]/a"));
            String valBefore = driver.FindElement(By.XPath(".//*[@id='gauges']/table/tbody/tr[2]/td[1]")).Text;
            sortByReceptionDate.Click();
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
