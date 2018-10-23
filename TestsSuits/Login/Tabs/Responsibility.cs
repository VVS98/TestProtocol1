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
    public class Responsibility
    {
        IWebDriver driver;

        public static string BaseUrl = "http://Shvo:Alphredwhite98@axaxctest01/axcweb/Account";
        public static string LoggedInPageTitle = "http://Shvo:Alphredwhite98@axaxctest01/axcweb/Gauge";
        [SetUp]
        public void SetUp()
        {
            driver = new ChromeDriver();
            driver.Manage().Window.FullScreen();
            driver.Navigate().GoToUrl(BaseUrl);
            driver.FindElement(By.Id("EmployeeId")).SendKeys("system");
            driver.FindElement(By.Id("Password")).SendKeys("system");
            driver.FindElement(By.ClassName("btn-default")).Click();
            driver.Navigate().GoToUrl(LoggedInPageTitle);
        }
        [Test]
        public void SearchByResponsiblePerson()
        {
            var showAdvFil = driver.FindElement(By.Id("ShowAdvancedFilters")); showAdvFil.Click(); Thread.Sleep(500);
            var Service = driver.FindElement(By.XPath(".//*[@id='AdvacedFilters']/ul/li[4]/a"));
            Service.Click();
            var ResponsiblePerson = driver.FindElement(By.Id("ResponsiblePerson"));

            Actions actions = new Actions(driver);
            actions.MoveToElement(ResponsiblePerson).Click().Build().Perform();
            Thread.Sleep(1000);

            ResponsiblePerson.SendKeys("F10209 L10209 E10209");
            var btnSearch = driver.FindElement(By.Id("btnSearch")); btnSearch.Click();
            new WebDriverWait(driver, TimeSpan.FromSeconds(60)).Until(SeleniumExtras.WaitHelpers.ExpectedConditions.InvisibilityOfElementLocated(By.XPath("/html/body/div[27]/div/i/img")));

            String RealValue = driver.FindElement(By.XPath(".//*[@id='gauges']/table/tbody/tr[2]/td[5]")).Text;
            String expText = "F10209 L10209 E10209";
            StringAssert.AreEqualIgnoringCase(expText, RealValue);
        }
        [Test]
        public void SortByResponsiblePerson()
        {
            SearchByResponsiblePerson();
            var sortByResponsiblePerson = driver.FindElement(By.XPath(".//*[@id='gauges']/table/tbody/tr[1]/th[5]/a"));
            String valBefore = driver.FindElement(By.XPath(".//*[@id='gauges']/table/tbody/tr[2]/td[1]")).Text;
            sortByResponsiblePerson.Click();
            new WebDriverWait(driver, TimeSpan.FromSeconds(60)).Until(SeleniumExtras.WaitHelpers.ExpectedConditions.InvisibilityOfElementLocated(By.XPath("/html/body/div[27]/div/i/img")));
            String RealText = driver.FindElement(By.XPath(".//*[@id='gauges']/table/tbody/tr[2]/td[1]")).Text;
            StringAssert.AreNotEqualIgnoringCase(valBefore, RealText);
        }
        [Test]
        public void SearchByResponsibleDate()
        {
            var showAdvFil = driver.FindElement(By.Id("ShowAdvancedFilters")); showAdvFil.Click(); Thread.Sleep(500);
            var Service = driver.FindElement(By.XPath(".//*[@id='AdvacedFilters']/ul/li[4]/a"));
            Service.Click();
            var ResponsiblePerson = driver.FindElement(By.Id("ResponsibleDate"));

            Actions actions = new Actions(driver);
            actions.MoveToElement(ResponsiblePerson).Click().Build().Perform();
            Thread.Sleep(1000);

            ResponsiblePerson.SendKeys("1986-12-12 to 1986-12-12");
            var btnSearch = driver.FindElement(By.Id("btnSearch")); btnSearch.Click();
            new WebDriverWait(driver, TimeSpan.FromSeconds(60)).Until(SeleniumExtras.WaitHelpers.ExpectedConditions.InvisibilityOfElementLocated(By.XPath("/html/body/div[27]/div/i/img")));

            String RealValue = driver.FindElement(By.XPath(".//*[@id='gauges']/table/tbody/tr[2]/td[4]")).Text;
            String expText = "1986-12-12";
            StringAssert.AreEqualIgnoringCase(expText, RealValue);
        }
        [Test]
        public void SortByResponsibleDate()
        {
            SearchByResponsiblePerson();
            var sortByResponsiblePerson = driver.FindElement(By.XPath(".//*[@id='gauges']/table/tbody/tr[1]/th[4]/a"));
            String valBefore = driver.FindElement(By.XPath(".//*[@id='gauges']/table/tbody/tr[2]/td[1]")).Text;
            sortByResponsiblePerson.Click();
            new WebDriverWait(driver, TimeSpan.FromSeconds(60)).Until(SeleniumExtras.WaitHelpers.ExpectedConditions.InvisibilityOfElementLocated(By.XPath("/html/body/div[27]/div/i/img")));
            String RealText = driver.FindElement(By.XPath(".//*[@id='gauges']/table/tbody/tr[2]/td[1]")).Text;
            StringAssert.AreNotEqualIgnoringCase(valBefore, RealText);
        }

        [Test]
        public void SearchByCreateDate()
        {
            var Columns = driver.FindElement(By.Id("btnColumns"));
            Columns.Click(); Thread.Sleep(500);
            var addColumn = driver.FindElement(By.XPath(".//*[@id='li_CreateDate']/input[4]"));
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

            var Responsible = driver.FindElement(By.XPath(".//*[@id='AdvacedFilters']/ul/li[4]/a"));
            Responsible.Click();
            var CreateDate = driver.FindElement(By.Id("CreateDate"));

            Actions action = new Actions(driver);
            action.MoveToElement(CreateDate).Click().Build().Perform();
            Thread.Sleep(1000);

            CreateDate.SendKeys("1977-01-01 to 1977-01-01");
            var btnSearch = driver.FindElement(By.Id("btnSearch"));
            btnSearch.Click();
            new WebDriverWait(driver, TimeSpan.FromSeconds(60)).Until(SeleniumExtras.WaitHelpers.ExpectedConditions.InvisibilityOfElementLocated(By.XPath("/html/body/div[27]/div/i/img")));
            String RealValue = driver.FindElement(By.XPath(".//*[@id='gauges']/table/tbody/tr[2]/td[9]")).Text;
            String expText = "1977-01-01";
            StringAssert.AreEqualIgnoringCase(expText, RealValue);
        }
        [Test]
        public void SortByCreateDate()
        {
            //SearchByResponsiblePerson();
            var Columns = driver.FindElement(By.Id("btnColumns"));
            Columns.Click(); Thread.Sleep(500);
            var addColumn = driver.FindElement(By.XPath(".//*[@id='li_CreateDate']/input[4]"));
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
        public void SearchByUpdateDate()
        {
            var Columns = driver.FindElement(By.Id("btnColumns"));
            Columns.Click(); Thread.Sleep(500);
            var addColumn = driver.FindElement(By.XPath(".//*[@id='li_UpdateDate']/input[4]"));
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

            var Responsible = driver.FindElement(By.XPath(".//*[@id='AdvacedFilters']/ul/li[4]/a"));
            Responsible.Click();
            var CreateDate = driver.FindElement(By.Id("UpdateDate"));

            Actions action = new Actions(driver);
            action.MoveToElement(CreateDate).Click().Build().Perform();
            Thread.Sleep(1000);

            CreateDate.SendKeys("2018-09-06 to 2018-09-06");
            var btnSearch = driver.FindElement(By.Id("btnSearch"));
            btnSearch.Click();
            new WebDriverWait(driver, TimeSpan.FromSeconds(60)).Until(SeleniumExtras.WaitHelpers.ExpectedConditions.InvisibilityOfElementLocated(By.XPath("/html/body/div[27]/div/i/img")));
            String RealValue = driver.FindElement(By.XPath(".//*[@id='gauges']/table/tbody/tr[2]/td[9]")).Text;
            String expText = "2018-09-06";
            StringAssert.AreEqualIgnoringCase(expText, RealValue);
        }

        [Test]
        public void SortByUpdateDate()
        {
            //SearchByResponsiblePerson();
            var Columns = driver.FindElement(By.Id("btnColumns"));
            Columns.Click(); Thread.Sleep(500);
            var addColumn = driver.FindElement(By.XPath(".//*[@id='li_UpdateDate']/input[4]"));
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
        public void SearchByGaugeSupplier()
        {
            var Columns = driver.FindElement(By.Id("btnColumns"));
            Columns.Click(); Thread.Sleep(500);
            var addColumn = driver.FindElement(By.XPath(".//*[@id='li_GaugeSupplier']/input[4]"));
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

            var Responsible = driver.FindElement(By.XPath(".//*[@id='AdvacedFilters']/ul/li[4]/a"));
            Responsible.Click();
            var GaugeSupplier = driver.FindElement(By.Id("GaugeSupplier"));

            Actions action = new Actions(driver);
            action.MoveToElement(GaugeSupplier).Click().Build().Perform();
            Thread.Sleep(1000);

            GaugeSupplier.SendKeys("Mora Messger");
            var btnSearch = driver.FindElement(By.Id("btnSearch"));
            btnSearch.Click();
            new WebDriverWait(driver, TimeSpan.FromSeconds(60)).Until(SeleniumExtras.WaitHelpers.ExpectedConditions.InvisibilityOfElementLocated(By.XPath("/html/body/div[27]/div/i/img")));
            String RealValue = driver.FindElement(By.XPath(".//*[@id='gauges']/table/tbody/tr[2]/td[9]")).Text;
            String expText = "Mora Messger";
            StringAssert.AreEqualIgnoringCase(expText, RealValue);
        }

        [Test]
        public void SortByGaugeSupplier()
        {
            var Columns = driver.FindElement(By.Id("btnColumns"));
            Columns.Click(); Thread.Sleep(500);
            var addColumn = driver.FindElement(By.XPath(".//*[@id='li_GaugeSupplier']/input[4]"));
            addColumn.Click();
            Thread.Sleep(500);
            var SaveBtn = driver.FindElement(By.XPath(".//*[@id='gaugeColumns']/div/div/div[3]/button[1]"));
            SaveBtn.Click();
            new WebDriverWait(driver, TimeSpan.FromSeconds(60)).Until(SeleniumExtras.WaitHelpers.ExpectedConditions.InvisibilityOfElementLocated(By.XPath("/html/body/div[27]/div/i/img")));

            var sortByGaugeSupplier = driver.FindElement(By.XPath(".//*[@id='gauges']/table/tbody/tr[1]/th[9]/a"));
            String valBefore = driver.FindElement(By.XPath(".//*[@id='gauges']/table/tbody/tr[2]/td[1]")).Text;
            sortByGaugeSupplier.Click();
            new WebDriverWait(driver, TimeSpan.FromSeconds(60)).Until(SeleniumExtras.WaitHelpers.ExpectedConditions.InvisibilityOfElementLocated(By.XPath("/html/body/div[27]/div/i/img")));
            String RealText = driver.FindElement(By.XPath(".//*[@id='gauges']/table/tbody/tr[2]/td[1]")).Text;
            StringAssert.AreNotEqualIgnoringCase(valBefore, RealText);
        }

        [Test]
        public void SearchByCreateEmploymentNumber()
        {
            var Columns = driver.FindElement(By.Id("btnColumns"));
            Columns.Click(); Thread.Sleep(500);
            var addColumn = driver.FindElement(By.XPath(".//*[@id='li_CreateEmploymentNumber']/input[4]"));
            new WebDriverWait(driver, TimeSpan.FromSeconds(60)).Until(SeleniumExtras.WaitHelpers.ExpectedConditions.VisibilityOfAllElementsLocatedBy(By.XPath(".//*[@id='available_columns']")));
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

            var Responsible = driver.FindElement(By.XPath(".//*[@id='AdvacedFilters']/ul/li[4]/a"));
            Responsible.Click();
            var CreateEmploymentNumber = driver.FindElement(By.Id("CreateEmploymentNumber"));

            Actions action = new Actions(driver);
            action.MoveToElement(CreateEmploymentNumber).Click().Build().Perform();
            Thread.Sleep(1000);

            CreateEmploymentNumber.SendKeys("63960");
            var btnSearch = driver.FindElement(By.Id("btnSearch"));
            btnSearch.Click();
            new WebDriverWait(driver, TimeSpan.FromSeconds(60)).Until(SeleniumExtras.WaitHelpers.ExpectedConditions.InvisibilityOfElementLocated(By.XPath("/html/body/div[27]/div/i/img")));
            String RealValue = driver.FindElement(By.XPath(".//*[@id='gauges']/table/tbody/tr[2]/td[9]")).Text;
            String expText = "63960";
            StringAssert.AreEqualIgnoringCase(expText, RealValue);
        }

        [Test]
        public void SortByCreateEmploymentNumber()
        {
            var Columns = driver.FindElement(By.Id("btnColumns"));
            Columns.Click(); Thread.Sleep(500);
            var addColumn = driver.FindElement(By.XPath(".//*[@id='li_CreateEmploymentNumber']/input[4]"));
            addColumn.Click();
            Thread.Sleep(500);
            var SaveBtn = driver.FindElement(By.XPath(".//*[@id='gaugeColumns']/div/div/div[3]/button[1]"));
            SaveBtn.Click();
            new WebDriverWait(driver, TimeSpan.FromSeconds(60)).Until(SeleniumExtras.WaitHelpers.ExpectedConditions.InvisibilityOfElementLocated(By.XPath("/html/body/div[27]/div/i/img")));

            var sortByCreateEmploymentNumber = driver.FindElement(By.XPath(".//*[@id='gauges']/table/tbody/tr[1]/th[9]/a"));
            String valBefore = driver.FindElement(By.XPath(".//*[@id='gauges']/table/tbody/tr[2]/td[1]")).Text;
            sortByCreateEmploymentNumber.Click();
            new WebDriverWait(driver, TimeSpan.FromSeconds(60)).Until(SeleniumExtras.WaitHelpers.ExpectedConditions.InvisibilityOfElementLocated(By.XPath("/html/body/div[27]/div/i/img")));
            String RealText = driver.FindElement(By.XPath(".//*[@id='gauges']/table/tbody/tr[2]/td[1]")).Text;
            StringAssert.AreNotEqualIgnoringCase(valBefore, RealText);
        }

        [Test]
        public void SearchByUpdatePerson()
        {
            var Columns = driver.FindElement(By.Id("btnColumns"));
            Columns.Click(); Thread.Sleep(500);
            var addColumn = driver.FindElement(By.XPath(".//*[@id='li_UpdatePerson']/input[4]"));
            new WebDriverWait(driver, TimeSpan.FromSeconds(60)).Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath(".//*[@id='li_UpdatePerson']/input[4]")));
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

            var Responsible = driver.FindElement(By.XPath(".//*[@id='AdvacedFilters']/ul/li[4]/a"));
            Responsible.Click();
            var UpdatePerson = driver.FindElement(By.Id("UpdatePerson"));

            Actions action = new Actions(driver);
            action.MoveToElement(UpdatePerson).Click().Build().Perform();
            Thread.Sleep(1000);

            UpdatePerson.SendKeys("F1698 L1698");
            var btnSearch = driver.FindElement(By.Id("btnSearch"));
            btnSearch.Click();
            new WebDriverWait(driver, TimeSpan.FromSeconds(60)).Until(SeleniumExtras.WaitHelpers.ExpectedConditions.InvisibilityOfElementLocated(By.XPath("/html/body/div[27]/div/i/img")));
            String RealValue = driver.FindElement(By.XPath(".//*[@id='gauges']/table/tbody/tr[2]/td[9]")).Text;
            String expText = "F1698 L1698";
            StringAssert.AreEqualIgnoringCase(expText, RealValue);
        }

        [Test]
        public void SortByCreateUpdatePerson()
        {
            var Columns = driver.FindElement(By.Id("btnColumns"));
            Columns.Click(); Thread.Sleep(500);
            var addColumn = driver.FindElement(By.XPath(".//*[@id='li_UpdatePerson']/input[4]"));
            addColumn.Click();
            Thread.Sleep(500);
            var SaveBtn = driver.FindElement(By.XPath(".//*[@id='gaugeColumns']/div/div/div[3]/button[1]"));
            SaveBtn.Click();
            new WebDriverWait(driver, TimeSpan.FromSeconds(60)).Until(SeleniumExtras.WaitHelpers.ExpectedConditions.InvisibilityOfElementLocated(By.XPath("/html/body/div[27]/div/i/img")));

            var sortByUpdatePerson = driver.FindElement(By.XPath(".//*[@id='gauges']/table/tbody/tr[1]/th[9]/a"));
            String valBefore = driver.FindElement(By.XPath(".//*[@id='gauges']/table/tbody/tr[2]/td[1]")).Text;
            sortByUpdatePerson.Click();
            new WebDriverWait(driver, TimeSpan.FromSeconds(60)).Until(SeleniumExtras.WaitHelpers.ExpectedConditions.InvisibilityOfElementLocated(By.XPath("/html/body/div[27]/div/i/img")));
            String RealText = driver.FindElement(By.XPath(".//*[@id='gauges']/table/tbody/tr[2]/td[1]")).Text;
            StringAssert.AreNotEqualIgnoringCase(valBefore, RealText);
        }

        [Test]
        public void SearchByUpdateEmploymentNumber()
        {
            var Columns = driver.FindElement(By.Id("btnColumns"));
            Columns.Click(); Thread.Sleep(500);
            var addColumn = driver.FindElement(By.XPath(".//*[@id='li_UpdateEmploymentNumber']/input[4]"));
            new WebDriverWait(driver, TimeSpan.FromSeconds(60)).Until(SeleniumExtras.WaitHelpers.ExpectedConditions.VisibilityOfAllElementsLocatedBy(By.XPath(".//*[@id='available_columns']")));
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

            var Responsible = driver.FindElement(By.XPath(".//*[@id='AdvacedFilters']/ul/li[4]/a"));
            Responsible.Click();
            var UpdateEmploymentNumber = driver.FindElement(By.Id("UpdateEmploymentNumber"));

            Actions action = new Actions(driver);
            action.MoveToElement(UpdateEmploymentNumber).Click().Build().Perform();
            Thread.Sleep(1000);

            UpdateEmploymentNumber.SendKeys("59382");
            var btnSearch = driver.FindElement(By.Id("btnSearch"));
            btnSearch.Click();
            new WebDriverWait(driver, TimeSpan.FromSeconds(60)).Until(SeleniumExtras.WaitHelpers.ExpectedConditions.InvisibilityOfElementLocated(By.XPath("/html/body/div[27]/div/i/img")));
            String RealValue = driver.FindElement(By.XPath(".//*[@id='gauges']/table/tbody/tr[2]/td[9]")).Text;
            String expText = "59382";
            StringAssert.AreEqualIgnoringCase(expText, RealValue);
        }

        [Test]
        public void SortByUpdateEmploymentNumber()
        {
            var Columns = driver.FindElement(By.Id("btnColumns"));
            Columns.Click(); Thread.Sleep(500);
            var addColumn = driver.FindElement(By.XPath(".//*[@id='li_UpdateEmploymentNumber']/input[4]"));
            addColumn.Click();
            Thread.Sleep(500);
            var SaveBtn = driver.FindElement(By.XPath(".//*[@id='gaugeColumns']/div/div/div[3]/button[1]"));
            SaveBtn.Click();
            new WebDriverWait(driver, TimeSpan.FromSeconds(60)).Until(SeleniumExtras.WaitHelpers.ExpectedConditions.InvisibilityOfElementLocated(By.XPath("/html/body/div[27]/div/i/img")));

            var sortByUpdateEmploymentNumber = driver.FindElement(By.XPath(".//*[@id='gauges']/table/tbody/tr[1]/th[9]/a"));
            String valBefore = driver.FindElement(By.XPath(".//*[@id='gauges']/table/tbody/tr[2]/td[1]")).Text;
            sortByUpdateEmploymentNumber.Click();
            new WebDriverWait(driver, TimeSpan.FromSeconds(60)).Until(SeleniumExtras.WaitHelpers.ExpectedConditions.InvisibilityOfElementLocated(By.XPath("/html/body/div[27]/div/i/img")));
            String RealText = driver.FindElement(By.XPath(".//*[@id='gauges']/table/tbody/tr[2]/td[1]")).Text;
            StringAssert.AreNotEqualIgnoringCase(valBefore, RealText);
        }

        [Test]
        public void SearchByOwner()
        {
            var Columns = driver.FindElement(By.Id("btnColumns"));
            Columns.Click(); Thread.Sleep(500);
            var addColumn = driver.FindElement(By.XPath(".//*[@id='li_OwnerDepartment']/input[4]"));
            new WebDriverWait(driver, TimeSpan.FromSeconds(60)).Until(SeleniumExtras.WaitHelpers.ExpectedConditions.VisibilityOfAllElementsLocatedBy(By.XPath(".//*[@id='available_columns']")));
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

            var Responsible = driver.FindElement(By.XPath(".//*[@id='AdvacedFilters']/ul/li[4]/a"));
            Responsible.Click();
            var Owner = driver.FindElement(By.Id("OwnerDepartment"));

            Actions action = new Actions(driver);
            action.MoveToElement(Owner).Click().Build().Perform();
            Thread.Sleep(1000);

            Owner.SendKeys("92430");
            var btnSearch = driver.FindElement(By.Id("btnSearch"));
            btnSearch.Click();
            new WebDriverWait(driver, TimeSpan.FromSeconds(60)).Until(SeleniumExtras.WaitHelpers.ExpectedConditions.InvisibilityOfElementLocated(By.XPath("/html/body/div[27]/div/i/img")));
            String RealValue = driver.FindElement(By.XPath(".//*[@id='gauges']/table/tbody/tr[2]/td[9]")).Text;
            String expText = "92430";
            StringAssert.AreEqualIgnoringCase(expText, RealValue);
        }

        [Test]
        public void SortByOwnerDepartment()
        {
            var Columns = driver.FindElement(By.Id("btnColumns"));
            Columns.Click(); Thread.Sleep(500);
            var addColumn = driver.FindElement(By.XPath(".//*[@id='li_OwnerDepartment']/input[4]"));
            addColumn.Click();
            Thread.Sleep(500);
            var SaveBtn = driver.FindElement(By.XPath(".//*[@id='gaugeColumns']/div/div/div[3]/button[1]"));
            SaveBtn.Click();
            new WebDriverWait(driver, TimeSpan.FromSeconds(60)).Until(SeleniumExtras.WaitHelpers.ExpectedConditions.InvisibilityOfElementLocated(By.XPath("/html/body/div[27]/div/i/img")));

            var sortByOwnerDepartment = driver.FindElement(By.XPath(".//*[@id='gauges']/table/tbody/tr[1]/th[9]/a"));
            String valBefore = driver.FindElement(By.XPath(".//*[@id='gauges']/table/tbody/tr[2]/td[1]")).Text;
            sortByOwnerDepartment.Click();
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
