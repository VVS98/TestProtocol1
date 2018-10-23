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
    public class Other
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
            var login = driver.FindElement(By.Id("EmployeeId")); login.SendKeys("system");

            var pswd = driver.FindElement(By.Id("Password")); pswd.SendKeys("system");

            var submit = driver.FindElement(By.ClassName("btn-default")); submit.Click();
            driver.Navigate().GoToUrl(LoggedInPageTitle);
        }
        [Test]
        public void SearchByDeliveryPrice()
        {
            var Columns = driver.FindElement(By.Id("btnColumns"));
            Columns.Click();
            new WebDriverWait(driver, TimeSpan.FromSeconds(60)).Until(SeleniumExtras.WaitHelpers.ExpectedConditions.VisibilityOfAllElementsLocatedBy(By.XPath(".//*[@id='gaugeColumnsForm']/div[2]")));

            var addColumn = driver.FindElement(By.XPath(".//*[@id='li_DeliveryPrice']/input[4]"));
            addColumn.Click();
            new WebDriverWait(driver, TimeSpan.FromSeconds(60)).Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(By.XPath(".//*[@id='gaugeColumns']/div/div/div[3]/button[1]")));

            var SaveBtn = driver.FindElement(By.XPath(".//*[@id='gaugeColumns']/div/div/div[3]/button[1]"));
            SaveBtn.Click();
            new WebDriverWait(driver, TimeSpan.FromSeconds(60)).Until(SeleniumExtras.WaitHelpers.ExpectedConditions.InvisibilityOfElementLocated(By.XPath("/html/body/div[27]/div/i/img")));

            var showAdvFil = driver.FindElement(By.Id("ShowAdvancedFilters"));
            showAdvFil.Click();
            new WebDriverWait(driver, TimeSpan.FromSeconds(60)).Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(By.XPath(".//*[@id='AdvacedFilters']/ul/li[7]/a")));
            var Other = driver.FindElement(By.XPath(".//*[@id='AdvacedFilters']/ul/li[8]/a"));
            Other.Click();
            var DeliveryPrice = driver.FindElement(By.Id("DeliveryPrice"));

            Actions action = new Actions(driver);
            action.MoveToElement(DeliveryPrice).Click().Build().Perform();
            
            DeliveryPrice.SendKeys("1234.0000");
            new WebDriverWait(driver, TimeSpan.FromSeconds(60)).Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(By.Id("btnSearch")));

            var btnSearch = driver.FindElement(By.Id("btnSearch"));
            btnSearch.Click();
            new WebDriverWait(driver, TimeSpan.FromSeconds(60)).Until(SeleniumExtras.WaitHelpers.ExpectedConditions.InvisibilityOfElementLocated(By.XPath("/html/body/div[27]/div/i/img")));
            String RealValue = driver.FindElement(By.XPath(".//*[@id='gauges']/table/tbody/tr[2]/td[9]")).Text;
            String expText = "1234.0000";
            StringAssert.AreEqualIgnoringCase(expText, RealValue);
        }
        [Test]
        public void SortByDeliveryPrice()
        {
            var Columns = driver.FindElement(By.Id("btnColumns"));
            Columns.Click(); Thread.Sleep(500);
            var addColumn = driver.FindElement(By.XPath(".//*[@id='li_DeliveryPrice']/input[4]"));
            addColumn.Click();
            Thread.Sleep(500);
            var SaveBtn = driver.FindElement(By.XPath(".//*[@id='gaugeColumns']/div/div/div[3]/button[1]"));
            SaveBtn.Click();
            new WebDriverWait(driver, TimeSpan.FromSeconds(60)).Until(SeleniumExtras.WaitHelpers.ExpectedConditions.InvisibilityOfElementLocated(By.XPath("/html/body/div[27]/div/i/img")));

            var sortByDeliveryPrice = driver.FindElement(By.XPath(".//*[@id='gauges']/table/tbody/tr[1]/th[9]/a"));
            String valBefore = driver.FindElement(By.XPath(".//*[@id='gauges']/table/tbody/tr[2]/td[1]")).Text;
            sortByDeliveryPrice.Click();
            new WebDriverWait(driver, TimeSpan.FromSeconds(60)).Until(SeleniumExtras.WaitHelpers.ExpectedConditions.InvisibilityOfElementLocated(By.XPath("/html/body/div[27]/div/i/img")));
            String RealText = driver.FindElement(By.XPath(".//*[@id='gauges']/table/tbody/tr[2]/td[1]")).Text;
            StringAssert.AreNotEqualIgnoringCase(valBefore, RealText);
        }
        [Test]
        public void SearchByMonthlyCost()
        {
            var Columns = driver.FindElement(By.Id("btnColumns"));
            Columns.Click();
            new WebDriverWait(driver, TimeSpan.FromSeconds(60)).Until(SeleniumExtras.WaitHelpers.ExpectedConditions.VisibilityOfAllElementsLocatedBy(By.XPath(".//*[@id='gaugeColumnsForm']/div[2]")));

            var addColumn = driver.FindElement(By.XPath(".//*[@id='li_MonthlyCost']/input[4]"));
            addColumn.Click();
            new WebDriverWait(driver, TimeSpan.FromSeconds(60)).Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(By.XPath(".//*[@id='gaugeColumns']/div/div/div[3]/button[1]")));

            var SaveBtn = driver.FindElement(By.XPath(".//*[@id='gaugeColumns']/div/div/div[3]/button[1]"));
            SaveBtn.Click();
            new WebDriverWait(driver, TimeSpan.FromSeconds(60)).Until(SeleniumExtras.WaitHelpers.ExpectedConditions.InvisibilityOfElementLocated(By.XPath("/html/body/div[27]/div/i/img")));

            var showAdvFil = driver.FindElement(By.Id("ShowAdvancedFilters"));
            showAdvFil.Click();
            new WebDriverWait(driver, TimeSpan.FromSeconds(60)).Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(By.XPath(".//*[@id='AdvacedFilters']/ul/li[7]/a")));
            var Other = driver.FindElement(By.XPath(".//*[@id='AdvacedFilters']/ul/li[8]/a"));
            Other.Click();
            var MonthlyCost = driver.FindElement(By.Id("MonthlyCost"));

            Actions action = new Actions(driver);
            action.MoveToElement(MonthlyCost).Click().Build().Perform();

            MonthlyCost.SendKeys("0.0000");
            new WebDriverWait(driver, TimeSpan.FromSeconds(60)).Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(By.Id("btnSearch")));

            var btnSearch = driver.FindElement(By.Id("btnSearch"));
            btnSearch.Click();
            new WebDriverWait(driver, TimeSpan.FromSeconds(60)).Until(SeleniumExtras.WaitHelpers.ExpectedConditions.InvisibilityOfElementLocated(By.XPath("/html/body/div[27]/div/i/img")));
            String RealValue = driver.FindElement(By.XPath(".//*[@id='gauges']/table/tbody/tr[2]/td[9]")).Text;
            String expText = "0.0000";
            StringAssert.AreEqualIgnoringCase(expText, RealValue);
        }
        [Test]
        public void SearchByReceptionPerson()
        {
            var Columns = driver.FindElement(By.Id("btnColumns"));
            Columns.Click();
            new WebDriverWait(driver, TimeSpan.FromSeconds(60)).Until(SeleniumExtras.WaitHelpers.ExpectedConditions.VisibilityOfAllElementsLocatedBy(By.XPath(".//*[@id='gaugeColumnsForm']/div[2]")));

            var addColumn = driver.FindElement(By.XPath(".//*[@id='li_ReceptionPerson']/input[4]"));
            addColumn.Click();
            new WebDriverWait(driver, TimeSpan.FromSeconds(60)).Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(By.XPath(".//*[@id='gaugeColumns']/div/div/div[3]/button[1]")));

            var SaveBtn = driver.FindElement(By.XPath(".//*[@id='gaugeColumns']/div/div/div[3]/button[1]"));
            SaveBtn.Click();
            new WebDriverWait(driver, TimeSpan.FromSeconds(60)).Until(SeleniumExtras.WaitHelpers.ExpectedConditions.InvisibilityOfElementLocated(By.XPath("/html/body/div[27]/div/i/img")));

            var showAdvFil = driver.FindElement(By.Id("ShowAdvancedFilters"));
            showAdvFil.Click();
            new WebDriverWait(driver, TimeSpan.FromSeconds(60)).Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(By.XPath(".//*[@id='AdvacedFilters']/ul/li[7]/a")));
            var Other = driver.FindElement(By.XPath(".//*[@id='AdvacedFilters']/ul/li[8]/a"));
            Other.Click();
            var ReceptionPerson = driver.FindElement(By.Id("ReceptionPerson"));

            Actions action = new Actions(driver);
            action.MoveToElement(ReceptionPerson).Click().Build().Perform();

            ReceptionPerson.SendKeys("Åke Brodén / Peter Svensson");
            new WebDriverWait(driver, TimeSpan.FromSeconds(60)).Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(By.Id("btnSearch")));

            var btnSearch = driver.FindElement(By.Id("btnSearch"));
            btnSearch.Click();
            new WebDriverWait(driver, TimeSpan.FromSeconds(60)).Until(SeleniumExtras.WaitHelpers.ExpectedConditions.InvisibilityOfElementLocated(By.XPath("/html/body/div[27]/div/i/img")));
            String RealValue = driver.FindElement(By.XPath(".//*[@id='gauges']/table/tbody/tr[2]/td[9]")).Text;
            String expText = "Åke Brodén / Peter Svensson";
            StringAssert.AreEqualIgnoringCase(expText, RealValue);
        }

        [Test]
        public void SearchByReceptionCost()
        {
            var Columns = driver.FindElement(By.Id("btnColumns"));
            Columns.Click();
            new WebDriverWait(driver, TimeSpan.FromSeconds(60)).Until(SeleniumExtras.WaitHelpers.ExpectedConditions.VisibilityOfAllElementsLocatedBy(By.XPath(".//*[@id='gaugeColumnsForm']/div[2]")));

            var addColumn = driver.FindElement(By.XPath(".//*[@id='li_ReceptionCost']/input[4]"));
            addColumn.Click();
            new WebDriverWait(driver, TimeSpan.FromSeconds(60)).Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(By.XPath(".//*[@id='gaugeColumns']/div/div/div[3]/button[1]")));

            var SaveBtn = driver.FindElement(By.XPath(".//*[@id='gaugeColumns']/div/div/div[3]/button[1]"));
            SaveBtn.Click();
            new WebDriverWait(driver, TimeSpan.FromSeconds(60)).Until(SeleniumExtras.WaitHelpers.ExpectedConditions.InvisibilityOfElementLocated(By.XPath("/html/body/div[27]/div/i/img")));

            var showAdvFil = driver.FindElement(By.Id("ShowAdvancedFilters"));
            showAdvFil.Click();
            new WebDriverWait(driver, TimeSpan.FromSeconds(60)).Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(By.XPath(".//*[@id='AdvacedFilters']/ul/li[7]/a")));
            var Other = driver.FindElement(By.XPath(".//*[@id='AdvacedFilters']/ul/li[8]/a"));
            Other.Click();
            var ReceptionCost = driver.FindElement(By.Id("ReceptionCost"));

            Actions action = new Actions(driver);
            action.MoveToElement(ReceptionCost).Click().Build().Perform();

            ReceptionCost.SendKeys("0.0000");
            new WebDriverWait(driver, TimeSpan.FromSeconds(60)).Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(By.Id("btnSearch")));

            var btnSearch = driver.FindElement(By.Id("btnSearch"));
            btnSearch.Click();
            new WebDriverWait(driver, TimeSpan.FromSeconds(60)).Until(SeleniumExtras.WaitHelpers.ExpectedConditions.InvisibilityOfElementLocated(By.XPath("/html/body/div[27]/div/i/img")));
            String RealValue = driver.FindElement(By.XPath(".//*[@id='gauges']/table/tbody/tr[2]/td[9]")).Text;
            String expText = "0.0000";
            StringAssert.AreEqualIgnoringCase(expText, RealValue);
        }

        [Test]
        public void SearchBySensorManufacturer()
        {
            var Columns = driver.FindElement(By.Id("btnColumns"));
            Columns.Click();
            new WebDriverWait(driver, TimeSpan.FromSeconds(60)).Until(SeleniumExtras.WaitHelpers.ExpectedConditions.VisibilityOfAllElementsLocatedBy(By.XPath(".//*[@id='gaugeColumnsForm']/div[2]")));

            var addColumn = driver.FindElement(By.XPath(".//*[@id='li_SensorManufacturer']/input[4]"));
            addColumn.Click();
            new WebDriverWait(driver, TimeSpan.FromSeconds(60)).Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(By.XPath(".//*[@id='gaugeColumns']/div/div/div[3]/button[1]")));

            var SaveBtn = driver.FindElement(By.XPath(".//*[@id='gaugeColumns']/div/div/div[3]/button[1]"));
            SaveBtn.Click();
            new WebDriverWait(driver, TimeSpan.FromSeconds(60)).Until(SeleniumExtras.WaitHelpers.ExpectedConditions.InvisibilityOfElementLocated(By.XPath("/html/body/div[27]/div/i/img")));

            var showAdvFil = driver.FindElement(By.Id("ShowAdvancedFilters"));
            showAdvFil.Click();
            new WebDriverWait(driver, TimeSpan.FromSeconds(60)).Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(By.XPath(".//*[@id='AdvacedFilters']/ul/li[7]/a")));
            var Other = driver.FindElement(By.XPath(".//*[@id='AdvacedFilters']/ul/li[8]/a"));
            Other.Click();
            var SensorManufacturer = driver.FindElement(By.Id("SensorManufacturer"));

            Actions action = new Actions(driver);
            action.MoveToElement(SensorManufacturer).Click().Build().Perform();

            SensorManufacturer.SendKeys("WIKA");
            new WebDriverWait(driver, TimeSpan.FromSeconds(60)).Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(By.Id("btnSearch")));

            var btnSearch = driver.FindElement(By.Id("btnSearch"));
            btnSearch.Click();
            new WebDriverWait(driver, TimeSpan.FromSeconds(60)).Until(SeleniumExtras.WaitHelpers.ExpectedConditions.InvisibilityOfElementLocated(By.XPath("/html/body/div[27]/div/i/img")));
            String RealValue = driver.FindElement(By.XPath(".//*[@id='gauges']/table/tbody/tr[2]/td[9]")).Text;
            String expText = "WIKA";
            StringAssert.AreEqualIgnoringCase(expText, RealValue);
        }


        [Test]
        public void SearchByCreateLastName()
        {
            var Columns = driver.FindElement(By.Id("btnColumns"));
            Columns.Click();
            new WebDriverWait(driver, TimeSpan.FromSeconds(60)).Until(SeleniumExtras.WaitHelpers.ExpectedConditions.VisibilityOfAllElementsLocatedBy(By.XPath(".//*[@id='gaugeColumnsForm']/div[2]")));

            var addColumn = driver.FindElement(By.XPath(".//*[@id='li_CreateLastName']/input[4]"));
            addColumn.Click();
            new WebDriverWait(driver, TimeSpan.FromSeconds(60)).Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(By.XPath(".//*[@id='gaugeColumns']/div/div/div[3]/button[1]")));

            var SaveBtn = driver.FindElement(By.XPath(".//*[@id='gaugeColumns']/div/div/div[3]/button[1]"));
            SaveBtn.Click();
            new WebDriverWait(driver, TimeSpan.FromSeconds(60)).Until(SeleniumExtras.WaitHelpers.ExpectedConditions.InvisibilityOfElementLocated(By.XPath("/html/body/div[27]/div/i/img")));

            var showAdvFil = driver.FindElement(By.Id("ShowAdvancedFilters"));
            showAdvFil.Click();
            new WebDriverWait(driver, TimeSpan.FromSeconds(60)).Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(By.XPath(".//*[@id='AdvacedFilters']/ul/li[7]/a")));
            var Other = driver.FindElement(By.XPath(".//*[@id='AdvacedFilters']/ul/li[8]/a"));
            Other.Click();
            var CreateLastName = driver.FindElement(By.Id("CreateLastName"));

            Actions action = new Actions(driver);
            action.MoveToElement(CreateLastName).Click().Build().Perform();

            CreateLastName.SendKeys("Andersson");
            new WebDriverWait(driver, TimeSpan.FromSeconds(60)).Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(By.Id("btnSearch")));

            var btnSearch = driver.FindElement(By.Id("btnSearch"));
            btnSearch.Click();
            new WebDriverWait(driver, TimeSpan.FromSeconds(60)).Until(SeleniumExtras.WaitHelpers.ExpectedConditions.InvisibilityOfElementLocated(By.XPath("/html/body/div[27]/div/i/img")));
            String RealValue = driver.FindElement(By.XPath(".//*[@id='gauges']/table/tbody/tr[2]/td[9]")).Text;
            String expText = "Andersson";
            StringAssert.AreEqualIgnoringCase(expText, RealValue);
        }
        [Test]
        public void SearchByCreateFirstName()
        {
            var Columns = driver.FindElement(By.Id("btnColumns"));
            Columns.Click();
            new WebDriverWait(driver, TimeSpan.FromSeconds(60)).Until(SeleniumExtras.WaitHelpers.ExpectedConditions.VisibilityOfAllElementsLocatedBy(By.XPath(".//*[@id='gaugeColumnsForm']/div[2]")));

            var addColumn = driver.FindElement(By.XPath(".//*[@id='li_CreateFirstName']/input[4]"));
            addColumn.Click();
            new WebDriverWait(driver, TimeSpan.FromSeconds(60)).Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(By.XPath(".//*[@id='gaugeColumns']/div/div/div[3]/button[1]")));

            var SaveBtn = driver.FindElement(By.XPath(".//*[@id='gaugeColumns']/div/div/div[3]/button[1]"));
            SaveBtn.Click();
            new WebDriverWait(driver, TimeSpan.FromSeconds(60)).Until(SeleniumExtras.WaitHelpers.ExpectedConditions.InvisibilityOfElementLocated(By.XPath("/html/body/div[27]/div/i/img")));

            var showAdvFil = driver.FindElement(By.Id("ShowAdvancedFilters"));
            showAdvFil.Click();
            new WebDriverWait(driver, TimeSpan.FromSeconds(60)).Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(By.XPath(".//*[@id='AdvacedFilters']/ul/li[7]/a")));
            var Other = driver.FindElement(By.XPath(".//*[@id='AdvacedFilters']/ul/li[8]/a"));
            Other.Click();
            var CreateFirstName = driver.FindElement(By.Id("CreateFirstName"));

            Actions action = new Actions(driver);
            action.MoveToElement(CreateFirstName).Click().Build().Perform();

            CreateFirstName.SendKeys("  Per");
            new WebDriverWait(driver, TimeSpan.FromSeconds(60)).Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(By.Id("btnSearch")));

            var btnSearch = driver.FindElement(By.Id("btnSearch"));
            btnSearch.Click();
            new WebDriverWait(driver, TimeSpan.FromSeconds(60)).Until(SeleniumExtras.WaitHelpers.ExpectedConditions.InvisibilityOfElementLocated(By.XPath("/html/body/div[27]/div/i/img")));
            String RealValue = driver.FindElement(By.XPath(".//*[@id='gauges']/table/tbody/tr[2]/td[9]")).Text;
            String expText = "Per";
            StringAssert.AreEqualIgnoringCase(expText, RealValue);
        }

        [Test]
        public void SearchByUpdateLastName()
        {
            var Columns = driver.FindElement(By.Id("btnColumns"));
            Columns.Click();
            new WebDriverWait(driver, TimeSpan.FromSeconds(60)).Until(SeleniumExtras.WaitHelpers.ExpectedConditions.VisibilityOfAllElementsLocatedBy(By.XPath(".//*[@id='gaugeColumnsForm']/div[2]")));

            var addColumn = driver.FindElement(By.XPath(".//*[@id='li_UpdateLastName']/input[4]"));
            addColumn.Click();
            new WebDriverWait(driver, TimeSpan.FromSeconds(60)).Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(By.XPath(".//*[@id='gaugeColumns']/div/div/div[3]/button[1]")));

            var SaveBtn = driver.FindElement(By.XPath(".//*[@id='gaugeColumns']/div/div/div[3]/button[1]"));
            SaveBtn.Click();
            new WebDriverWait(driver, TimeSpan.FromSeconds(60)).Until(SeleniumExtras.WaitHelpers.ExpectedConditions.InvisibilityOfElementLocated(By.XPath("/html/body/div[27]/div/i/img")));

            var showAdvFil = driver.FindElement(By.Id("ShowAdvancedFilters"));
            showAdvFil.Click();
            new WebDriverWait(driver, TimeSpan.FromSeconds(60)).Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(By.XPath(".//*[@id='AdvacedFilters']/ul/li[7]/a")));
            var Other = driver.FindElement(By.XPath(".//*[@id='AdvacedFilters']/ul/li[8]/a"));
            Other.Click();
            var UpdateLastName = driver.FindElement(By.Id("UpdateLastName"));

            Actions action = new Actions(driver);
            action.MoveToElement(UpdateLastName).Click().Build().Perform();

            UpdateLastName.SendKeys("Aaltonen");
            new WebDriverWait(driver, TimeSpan.FromSeconds(60)).Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(By.Id("btnSearch")));

            var btnSearch = driver.FindElement(By.Id("btnSearch"));
            btnSearch.Click();
            new WebDriverWait(driver, TimeSpan.FromSeconds(60)).Until(SeleniumExtras.WaitHelpers.ExpectedConditions.InvisibilityOfElementLocated(By.XPath("/html/body/div[27]/div/i/img")));
            String RealValue = driver.FindElement(By.XPath(".//*[@id='gauges']/table/tbody/tr[2]/td[9]")).Text;
            String expText = "Aaltonen";
            StringAssert.AreEqualIgnoringCase(expText, RealValue);
        }

        [Test]
        public void SearchByUpdateFirstName()
        {
            var Columns = driver.FindElement(By.Id("btnColumns"));
            Columns.Click();
            new WebDriverWait(driver, TimeSpan.FromSeconds(60)).Until(SeleniumExtras.WaitHelpers.ExpectedConditions.VisibilityOfAllElementsLocatedBy(By.XPath(".//*[@id='gaugeColumnsForm']/div[2]")));

            var addColumn = driver.FindElement(By.XPath(".//*[@id='li_UpdateFirstName']/input[4]"));
            addColumn.Click();
            new WebDriverWait(driver, TimeSpan.FromSeconds(60)).Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(By.XPath(".//*[@id='gaugeColumns']/div/div/div[3]/button[1]")));

            var SaveBtn = driver.FindElement(By.XPath(".//*[@id='gaugeColumns']/div/div/div[3]/button[1]"));
            SaveBtn.Click();
            new WebDriverWait(driver, TimeSpan.FromSeconds(60)).Until(SeleniumExtras.WaitHelpers.ExpectedConditions.InvisibilityOfElementLocated(By.XPath("/html/body/div[27]/div/i/img")));

            var showAdvFil = driver.FindElement(By.Id("ShowAdvancedFilters"));
            showAdvFil.Click();
            new WebDriverWait(driver, TimeSpan.FromSeconds(60)).Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(By.XPath(".//*[@id='AdvacedFilters']/ul/li[7]/a")));
            var Other = driver.FindElement(By.XPath(".//*[@id='AdvacedFilters']/ul/li[8]/a"));
            Other.Click();
            var UpdateFirstName = driver.FindElement(By.Id("UpdateFirstName"));

            Actions action = new Actions(driver);
            action.MoveToElement(UpdateFirstName).Click().Build().Perform();

            UpdateFirstName.SendKeys("Joakim");
            new WebDriverWait(driver, TimeSpan.FromSeconds(60)).Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(By.Id("btnSearch")));

            var btnSearch = driver.FindElement(By.Id("btnSearch"));
            btnSearch.Click();
            new WebDriverWait(driver, TimeSpan.FromSeconds(60)).Until(SeleniumExtras.WaitHelpers.ExpectedConditions.InvisibilityOfElementLocated(By.XPath("/html/body/div[27]/div/i/img")));
            String RealValue = driver.FindElement(By.XPath(".//*[@id='gauges']/table/tbody/tr[2]/td[9]")).Text;
            String expText = "Joakim";
            StringAssert.AreEqualIgnoringCase(expText, RealValue);
        }
        [Test]
        public void SearchBySensorBarCode()
        {
            var Columns = driver.FindElement(By.Id("btnColumns"));
            Columns.Click();
            new WebDriverWait(driver, TimeSpan.FromSeconds(60)).Until(SeleniumExtras.WaitHelpers.ExpectedConditions.VisibilityOfAllElementsLocatedBy(By.XPath(".//*[@id='gaugeColumnsForm']/div[2]")));

            var addColumn = driver.FindElement(By.XPath(".//*[@id='li_SensorBarCode']/input[4]"));
            addColumn.Click();
            new WebDriverWait(driver, TimeSpan.FromSeconds(60)).Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(By.XPath(".//*[@id='gaugeColumns']/div/div/div[3]/button[1]")));

            var SaveBtn = driver.FindElement(By.XPath(".//*[@id='gaugeColumns']/div/div/div[3]/button[1]"));
            SaveBtn.Click();
            new WebDriverWait(driver, TimeSpan.FromSeconds(60)).Until(SeleniumExtras.WaitHelpers.ExpectedConditions.InvisibilityOfElementLocated(By.XPath("/html/body/div[27]/div/i/img")));

            var showAdvFil = driver.FindElement(By.Id("ShowAdvancedFilters"));
            showAdvFil.Click();
            new WebDriverWait(driver, TimeSpan.FromSeconds(60)).Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(By.XPath(".//*[@id='AdvacedFilters']/ul/li[7]/a")));
            var Other = driver.FindElement(By.XPath(".//*[@id='AdvacedFilters']/ul/li[8]/a"));
            Other.Click();
            var SensorBarCode = driver.FindElement(By.Id("SensorBarCode"));

            Actions action = new Actions(driver);
            action.MoveToElement(SensorBarCode).Click().Build().Perform();

            SensorBarCode.SendKeys("test2");
            new WebDriverWait(driver, TimeSpan.FromSeconds(60)).Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(By.Id("btnSearch")));

            var btnSearch = driver.FindElement(By.Id("btnSearch"));
            btnSearch.Click();
            new WebDriverWait(driver, TimeSpan.FromSeconds(60)).Until(SeleniumExtras.WaitHelpers.ExpectedConditions.InvisibilityOfElementLocated(By.XPath("/html/body/div[27]/div/i/img")));
            String RealValue = driver.FindElement(By.XPath(".//*[@id='gauges']/table/tbody/tr[2]/td[9]")).Text;
            String expText = "test2";
            StringAssert.AreEqualIgnoringCase(expText, RealValue);
        }
        [Test]
        public void SearchByTsuNumber()
        {
            var Columns = driver.FindElement(By.Id("btnColumns"));
            Columns.Click();
            new WebDriverWait(driver, TimeSpan.FromSeconds(60)).Until(SeleniumExtras.WaitHelpers.ExpectedConditions.VisibilityOfAllElementsLocatedBy(By.XPath(".//*[@id='gaugeColumnsForm']/div[2]")));

            var addColumn = driver.FindElement(By.XPath(".//*[@id='li_TsuNumber']/input[4]"));
            addColumn.Click();
            new WebDriverWait(driver, TimeSpan.FromSeconds(60)).Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(By.XPath(".//*[@id='gaugeColumns']/div/div/div[3]/button[1]")));

            var SaveBtn = driver.FindElement(By.XPath(".//*[@id='gaugeColumns']/div/div/div[3]/button[1]"));
            SaveBtn.Click();
            new WebDriverWait(driver, TimeSpan.FromSeconds(60)).Until(SeleniumExtras.WaitHelpers.ExpectedConditions.InvisibilityOfElementLocated(By.XPath("/html/body/div[27]/div/i/img")));

            var showAdvFil = driver.FindElement(By.Id("ShowAdvancedFilters"));
            showAdvFil.Click();
            new WebDriverWait(driver, TimeSpan.FromSeconds(60)).Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(By.XPath(".//*[@id='AdvacedFilters']/ul/li[7]/a")));
            var Other = driver.FindElement(By.XPath(".//*[@id='AdvacedFilters']/ul/li[8]/a"));
            Other.Click();
            var TsuNumber = driver.FindElement(By.Id("TsuNumber"));

            Actions action = new Actions(driver);
            action.MoveToElement(TsuNumber).Click().Build().Perform();

            TsuNumber.SendKeys("ZZT095");
            new WebDriverWait(driver, TimeSpan.FromSeconds(60)).Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(By.Id("btnSearch")));

            var btnSearch = driver.FindElement(By.Id("btnSearch"));
            btnSearch.Click();
            new WebDriverWait(driver, TimeSpan.FromSeconds(60)).Until(SeleniumExtras.WaitHelpers.ExpectedConditions.InvisibilityOfElementLocated(By.XPath("/html/body/div[27]/div/i/img")));
            String RealValue = driver.FindElement(By.XPath(".//*[@id='gauges']/table/tbody/tr[2]/td[9]")).Text;
            String expText = "ZZT095";
            StringAssert.AreEqualIgnoringCase(expText, RealValue);
        }

        [Test]
        public void SearchByCS012()
        {
            var Columns = driver.FindElement(By.Id("btnColumns"));
            Columns.Click();
            new WebDriverWait(driver, TimeSpan.FromSeconds(60)).Until(SeleniumExtras.WaitHelpers.ExpectedConditions.VisibilityOfAllElementsLocatedBy(By.XPath(".//*[@id='gaugeColumnsForm']/div[2]")));

            var addColumn0 = driver.FindElement(By.XPath(".//*[@id='li_CS0']/input[4]"));
            var addColumn1 = driver.FindElement(By.XPath(".//*[@id='li_CS1']/input[4]"));
            var addColumn2 = driver.FindElement(By.XPath(".//*[@id='li_CS2']/input[4]"));
            addColumn0.Click();
            addColumn1.Click();
            addColumn2.Click();
            new WebDriverWait(driver, TimeSpan.FromSeconds(60)).Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(By.XPath(".//*[@id='gaugeColumns']/div/div/div[3]/button[1]")));

            var SaveBtn = driver.FindElement(By.XPath(".//*[@id='gaugeColumns']/div/div/div[3]/button[1]"));
            SaveBtn.Click();
            new WebDriverWait(driver, TimeSpan.FromSeconds(60)).Until(SeleniumExtras.WaitHelpers.ExpectedConditions.InvisibilityOfElementLocated(By.XPath("/html/body/div[27]/div/i/img")));

            var showAdvFil = driver.FindElement(By.Id("ShowAdvancedFilters"));
            showAdvFil.Click();
            new WebDriverWait(driver, TimeSpan.FromSeconds(60)).Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(By.XPath(".//*[@id='AdvacedFilters']/ul/li[7]/a")));
            var Other = driver.FindElement(By.XPath(".//*[@id='AdvacedFilters']/ul/li[8]/a"));
            Other.Click();
            var CS0 = driver.FindElement(By.Id("CS0"));
            var CS1 = driver.FindElement(By.Id("CS1"));
            var CS2 = driver.FindElement(By.Id("CS2"));

            Actions action = new Actions(driver);
            action.MoveToElement(CS0).Click().Build().Perform();

            CS0.SendKeys("RIGG 99999999999999999999 ");
            CS1.SendKeys("RIGG 99999999999999999999 ");
            CS2.SendKeys("RIGG 99999999999999999999 ");
            new WebDriverWait(driver, TimeSpan.FromSeconds(60)).Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(By.Id("btnSearch")));

            var btnSearch = driver.FindElement(By.Id("btnSearch"));
            btnSearch.Click();
            new WebDriverWait(driver, TimeSpan.FromSeconds(60)).Until(SeleniumExtras.WaitHelpers.ExpectedConditions.InvisibilityOfElementLocated(By.XPath("/html/body/div[27]/div/i/img")));
            String RealValue0 = driver.FindElement(By.XPath(".//*[@id='gauges']/table/tbody/tr[2]/td[9]")).Text;
            String expText0 = "RIGG 99999999999999999999";
            StringAssert.AreEqualIgnoringCase(expText0, RealValue0);

            String RealValue1 = driver.FindElement(By.XPath(".//*[@id='gauges']/table/tbody/tr[2]/td[9]")).Text;
            String expText1 = "RIGG 99999999999999999999";
            StringAssert.AreEqualIgnoringCase(expText1, RealValue1);

            String RealValue2 = driver.FindElement(By.XPath(".//*[@id='gauges']/table/tbody/tr[2]/td[9]")).Text;
            String expText2 = "RIGG 99999999999999999999";
            StringAssert.AreEqualIgnoringCase(expText2, RealValue2);
        }

        [Test]
        public void SearchByRig()
        {
            var Columns = driver.FindElement(By.Id("btnColumns"));
            Columns.Click();
            new WebDriverWait(driver, TimeSpan.FromSeconds(60)).Until(SeleniumExtras.WaitHelpers.ExpectedConditions.VisibilityOfAllElementsLocatedBy(By.XPath(".//*[@id='gaugeColumnsForm']/div[2]")));

            var addColumn = driver.FindElement(By.XPath(".//*[@id='li_Rig']/input[4]"));
            addColumn.Click();
            new WebDriverWait(driver, TimeSpan.FromSeconds(60)).Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(By.XPath(".//*[@id='gaugeColumns']/div/div/div[3]/button[1]")));

            var SaveBtn = driver.FindElement(By.XPath(".//*[@id='gaugeColumns']/div/div/div[3]/button[1]"));
            SaveBtn.Click();
            new WebDriverWait(driver, TimeSpan.FromSeconds(60)).Until(SeleniumExtras.WaitHelpers.ExpectedConditions.InvisibilityOfElementLocated(By.XPath("/html/body/div[27]/div/i/img")));

            var showAdvFil = driver.FindElement(By.Id("ShowAdvancedFilters"));
            showAdvFil.Click();
            new WebDriverWait(driver, TimeSpan.FromSeconds(60)).Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(By.XPath(".//*[@id='AdvacedFilters']/ul/li[7]/a")));
            var Other = driver.FindElement(By.XPath(".//*[@id='AdvacedFilters']/ul/li[8]/a"));
            Other.Click();
            var Rig = driver.FindElement(By.Id("Rig"));

            Actions action = new Actions(driver);
            action.MoveToElement(Rig).Click().Build().Perform();

            Rig.SendKeys("FJK178");
            new WebDriverWait(driver, TimeSpan.FromSeconds(60)).Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(By.Id("btnSearch")));

            var btnSearch = driver.FindElement(By.Id("btnSearch"));
            btnSearch.Click();
            new WebDriverWait(driver, TimeSpan.FromSeconds(60)).Until(SeleniumExtras.WaitHelpers.ExpectedConditions.InvisibilityOfElementLocated(By.XPath("/html/body/div[27]/div/i/img")));
            String RealValue = driver.FindElement(By.XPath(".//*[@id='gauges']/table/tbody/tr[2]/td[9]")).Text;
            String expText = "FJK178";
            StringAssert.AreEqualIgnoringCase(expText, RealValue);
        }

        [TearDown]
        public void Finish()
        {
            driver.Close();
        }
    }
}
