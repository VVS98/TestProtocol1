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
using OpenQA.Selenium.Support;
using OpenQA.Selenium.Interactions;

namespace Tabs
{
    public class Service
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
        public void SearchByServiceSupplier()
        {
            var Columns = driver.FindElement(By.Id("btnColumns"));
            Columns.Click();
            new WebDriverWait(driver, TimeSpan.FromSeconds(60))
              .Until(SeleniumExtras.WaitHelpers.ExpectedConditions
                     .InvisibilityOfElementLocated(By.XPath("/html/body/div[27]/div/i/img")));
            var addColumn = driver.FindElement(By.XPath(".//*[@id='li_ServiceSupplier']/input[4]"));
            addColumn.Click();
            var SaveBtn = driver.FindElement(By.XPath(".//*[@id='gaugeColumns']/div/div/div[3]/button[1]"));
            SaveBtn.Click();

            new WebDriverWait(driver, TimeSpan.FromSeconds(60))
               .Until(SeleniumExtras.WaitHelpers.ExpectedConditions
                      .InvisibilityOfElementLocated(By.XPath("/html/body/div[27]/div/i/img")));

            var gif = driver.FindElement(By.XPath("/html/body/div[27]/div/i/img"));

            new WebDriverWait(driver, TimeSpan.FromSeconds(60)).Until(SeleniumExtras.WaitHelpers.ExpectedConditions.InvisibilityOfElementLocated(By.XPath("/html/body/div[27]/div/i/img")));

            new WebDriverWait(driver, TimeSpan.FromSeconds(60)).Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementExists(By.XPath(".//*[@id='ShowAdvancedFilters']")));

            new WebDriverWait(driver, TimeSpan.FromSeconds(60)).Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(By.XPath(".//*[@id='ShowAdvancedFilters']"))).Click();

            var showAdvFil = driver.FindElement(By.Id("ShowAdvancedFilters"));
          
            var Service = driver.FindElement(By.XPath(".//*[@id='AdvacedFilters']/ul/li[3]/a"));
            Service.Click();
            var ServiceSupplier = driver.FindElement(By.Id("ServiceSupplier"));

            Actions action = new Actions(driver);
            action.MoveToElement(ServiceSupplier).Click().Build().Perform();
            new WebDriverWait(driver, TimeSpan.FromSeconds(60))
               .Until(SeleniumExtras.WaitHelpers.ExpectedConditions
                      .InvisibilityOfElementLocated(By.XPath("/html/body/div[27]/div/i/img")));

            ServiceSupplier.SendKeys("Volvo internt - 92470 Calibration & Support");
            var btnSearch = driver.FindElement(By.Id("btnSearch"));
            btnSearch.Click();
            new WebDriverWait(driver, TimeSpan.FromSeconds(60)).Until(SeleniumExtras.WaitHelpers.ExpectedConditions.InvisibilityOfElementLocated(By.XPath("/html/body/div[27]/div/i/img")));
            String RealValue = driver.FindElement(By.XPath(".//*[@id='gauges']/table/tbody/tr[2]/td[9]")).Text;
            String expText = "Volvo internt - 92470 Calibration & Support";
            StringAssert.AreEqualIgnoringCase(expText, RealValue);
        }

        [Test]
        public void SortByServiceSupplier()
        {
            var Columns = driver.FindElement(By.Id("btnColumns"));
            Columns.Click();
            new WebDriverWait(driver, TimeSpan.FromSeconds(60)).Until(SeleniumExtras.WaitHelpers.ExpectedConditions.InvisibilityOfElementLocated(By.XPath("/html/body/div[27]/div/i/img")));

            var addColumn = driver.FindElement(By.XPath(".//*[@id='li_ServiceSupplier']/input[4]"));
            addColumn.Click();
            var SaveBtn = driver.FindElement(By.XPath(".//*[@id='gaugeColumns']/div/div/div[3]/button[1]"));
            SaveBtn.Click();
            new WebDriverWait(driver, TimeSpan.FromSeconds(60)).Until(SeleniumExtras.WaitHelpers.ExpectedConditions.InvisibilityOfElementLocated(By.XPath("/html/body/div[27]/div/i/img")));


            var sortByServiceSupplier = driver.FindElement(By.XPath(".//*[@id='gauges']/table/tbody/tr[1]/th[9]/a"));
            String valBefore = driver.FindElement(By.XPath(".//*[@id='gauges']/table/tbody/tr[10]/td[1]")).Text;
            sortByServiceSupplier.Click();
            new WebDriverWait(driver, TimeSpan.FromSeconds(60)).Until(SeleniumExtras.WaitHelpers.ExpectedConditions.InvisibilityOfElementLocated(By.XPath("/html/body/div[27]/div/i/img")));

            String RealText = driver.FindElement(By.XPath(".//*[@id='gauges']/table/tbody/tr[10]/td[1]")).Text;
            StringAssert.AreNotEqualIgnoringCase(valBefore, RealText);
        }

        [Test]
        public void SearchByServiceCost()
        {
            var Columns = driver.FindElement(By.Id("btnColumns"));
            Columns.Click(); new WebDriverWait(driver, TimeSpan.FromSeconds(60)).Until(SeleniumExtras.WaitHelpers.ExpectedConditions.InvisibilityOfElementLocated(By.XPath("/html/body/div[27]/div/i/img")));

            var addColumn = driver.FindElement(By.XPath(".//*[@id='li_ServiceCost']/input[4]"));
            addColumn.Click();
            var SaveBtn = driver.FindElement(By.XPath(".//*[@id='gaugeColumns']/div/div/div[3]/button[1]"));
            SaveBtn.Click();
            new WebDriverWait(driver, TimeSpan.FromSeconds(60)).Until(SeleniumExtras.WaitHelpers.ExpectedConditions.InvisibilityOfElementLocated(By.XPath("/html/body/div[27]/div/i/img")));
            var showAdvFil = driver.FindElement(By.Id("ShowAdvancedFilters"));
            showAdvFil.Click(); 
            var Service = driver.FindElement(By.XPath(".//*[@id='AdvacedFilters']/ul/li[3]/a"));
            Service.Click();
            var ServiceCost = driver.FindElement(By.Id("ServiceCost"));

            Actions actions = new Actions(driver);
            actions.MoveToElement(ServiceCost).Click().Build().Perform();

            ServiceCost.SendKeys("100000000.0000");
            var btnSearch = driver.FindElement(By.Id("btnSearch"));
            btnSearch.Click();
            new WebDriverWait(driver, TimeSpan.FromSeconds(60)).Until(SeleniumExtras.WaitHelpers.ExpectedConditions.InvisibilityOfElementLocated(By.XPath("/html/body/div[27]/div/i/img")));

            String RealValue = driver.FindElement(By.XPath(".//*[@id='gauges']/table/tbody/tr[2]/td[9]")).Text;
            String expText = "100000000.0000";
            StringAssert.AreEqualIgnoringCase(expText, RealValue);
        }

        [Test]
        public void SortByServiceCost()
        {
            var Columns = driver.FindElement(By.Id("btnColumns"));
            Columns.Click(); new WebDriverWait(driver, TimeSpan.FromSeconds(60)).Until(SeleniumExtras.WaitHelpers.ExpectedConditions.InvisibilityOfElementLocated(By.XPath("/html/body/div[27]/div/i/img")));
            var addColumn = driver.FindElement(By.XPath(".//*[@id='li_ServiceCost']/input[4]"));
            addColumn.Click();
            var SaveBtn = driver.FindElement(By.XPath(".//*[@id='gaugeColumns']/div/div/div[3]/button[1]"));
            SaveBtn.Click();
            new WebDriverWait(driver, TimeSpan.FromSeconds(60)).Until(SeleniumExtras.WaitHelpers.ExpectedConditions.InvisibilityOfElementLocated(By.XPath("/html/body/div[27]/div/i/img")));
            var sortByServiceCost = driver.FindElement(By.XPath(".//*[@id='gauges']/table/tbody/tr[1]/th[9]/a"));
            String valBefore = driver.FindElement(By.XPath(".//*[@id='gauges']/table/tbody/tr[10]/td[1]")).Text;
            sortByServiceCost.Click();
            new WebDriverWait(driver, TimeSpan.FromSeconds(60)).Until(SeleniumExtras.WaitHelpers.ExpectedConditions.InvisibilityOfElementLocated(By.XPath("/html/body/div[27]/div/i/img")));
            String RealText = driver.FindElement(By.XPath(".//*[@id='gauges']/table/tbody/tr[10]/td[1]")).Text;
            StringAssert.AreNotEqualIgnoringCase(valBefore, RealText);
        }

        [Test]
        public void SearchByServiceCostCenter()
        {
            var Columns = driver.FindElement(By.Id("btnColumns"));
            Columns.Click(); new WebDriverWait(driver, TimeSpan.FromSeconds(60)).Until(SeleniumExtras.WaitHelpers.ExpectedConditions.InvisibilityOfElementLocated(By.XPath("/html/body/div[27]/div/i/img")));

            var addColumn = driver.FindElement(By.XPath(".//*[@id='li_ServiceCostCenter']/input[4]"));
            addColumn.Click();
            var SaveBtn = driver.FindElement(By.XPath(".//*[@id='gaugeColumns']/div/div/div[3]/button[1]"));
            SaveBtn.Click();
            new WebDriverWait(driver, TimeSpan.FromSeconds(60)).Until(SeleniumExtras.WaitHelpers.ExpectedConditions.InvisibilityOfElementLocated(By.XPath("/html/body/div[27]/div/i/img")));

            var showAdvFil = driver.FindElement(By.Id("ShowAdvancedFilters"));
            showAdvFil.Click();
            var Service = driver.FindElement(By.XPath(".//*[@id='AdvacedFilters']/ul/li[3]/a"));
            Service.Click();
            var ServiceCostCenter = driver.FindElement(By.Id("ServiceCostCenter"));

            Actions actions = new Actions(driver);
            actions.MoveToElement(ServiceCostCenter).Click().Build().Perform();

            ServiceCostCenter.SendKeys("100000000");
            var btnSearch = driver.FindElement(By.Id("btnSearch"));
            btnSearch.Click();
            new WebDriverWait(driver, TimeSpan.FromSeconds(60)).Until(SeleniumExtras.WaitHelpers.ExpectedConditions.InvisibilityOfElementLocated(By.XPath("/html/body/div[27]/div/i/img")));

            String RealValue = driver.FindElement(By.XPath(".//*[@id='gauges']/table/tbody/tr[2]/td[9]")).Text;
            String expText = "100000000";
            StringAssert.AreEqualIgnoringCase(expText, RealValue);
        }

        [Test]
        public void SortByServiceCostCenter()
        {
            var Columns = driver.FindElement(By.Id("btnColumns"));
            Columns.Click(); new WebDriverWait(driver, TimeSpan.FromSeconds(60)).Until(SeleniumExtras.WaitHelpers.ExpectedConditions.InvisibilityOfElementLocated(By.XPath("/html/body/div[27]/div/i/img")));
            var addColumn = driver.FindElement(By.XPath(".//*[@id='li_ServiceCostCenter']/input[4]"));
            addColumn.Click();
            var SaveBtn = driver.FindElement(By.XPath(".//*[@id='gaugeColumns']/div/div/div[3]/button[1]"));
            SaveBtn.Click();
            new WebDriverWait(driver, TimeSpan.FromSeconds(60)).Until(SeleniumExtras.WaitHelpers.ExpectedConditions.InvisibilityOfElementLocated(By.XPath("/html/body/div[27]/div/i/img")));


            var sortByCalibrationCostCenter = driver.FindElement(By.XPath(".//*[@id='gauges']/table/tbody/tr[1]/th[9]/a"));
            String valBefore = driver.FindElement(By.XPath(".//*[@id='gauges']/table/tbody/tr[10]/td[1]")).Text;
            sortByCalibrationCostCenter.Click();
            new WebDriverWait(driver, TimeSpan.FromSeconds(60)).Until(SeleniumExtras.WaitHelpers.ExpectedConditions.InvisibilityOfElementLocated(By.XPath("/html/body/div[27]/div/i/img")));

            String RealText = driver.FindElement(By.XPath(".//*[@id='gauges']/table/tbody/tr[10]/td[1]")).Text;
            StringAssert.AreNotEqualIgnoringCase(valBefore, RealText);
        }

        [Test]
        public void SearchByOrderNumber()
        {
            var Columns = driver.FindElement(By.Id("btnColumns"));
            Columns.Click(); new WebDriverWait(driver, TimeSpan.FromSeconds(60)).Until(SeleniumExtras.WaitHelpers.ExpectedConditions.InvisibilityOfElementLocated(By.XPath("/html/body/div[27]/div/i/img")));
            var addColumn = driver.FindElement(By.XPath(".//*[@id='li_OrderNumber']/input[4]"));
            addColumn.Click();
            var SaveBtn = driver.FindElement(By.XPath(".//*[@id='gaugeColumns']/div/div/div[3]/button[1]"));
            SaveBtn.Click();
            new WebDriverWait(driver, TimeSpan.FromSeconds(60)).Until(SeleniumExtras.WaitHelpers.ExpectedConditions.InvisibilityOfElementLocated(By.XPath("/html/body/div[27]/div/i/img")));

            var showAdvFil = driver.FindElement(By.Id("ShowAdvancedFilters"));
            showAdvFil.Click();
            var Service = driver.FindElement(By.XPath(".//*[@id='AdvacedFilters']/ul/li[3]/a"));
            Service.Click();
            var OrderNumber = driver.FindElement(By.Id("OrderNumber"));

            Actions actions = new Actions(driver);
            actions.MoveToElement(OrderNumber).Click().Build().Perform();

            OrderNumber.SendKeys("21-333266");
            var btnSearch = driver.FindElement(By.Id("btnSearch"));
            btnSearch.Click();
            new WebDriverWait(driver, TimeSpan.FromSeconds(60)).Until(SeleniumExtras.WaitHelpers.ExpectedConditions.InvisibilityOfElementLocated(By.XPath("/html/body/div[27]/div/i/img")));
            String RealValue = driver.FindElement(By.XPath(".//*[@id='gauges']/table/tbody/tr[2]/td[9]")).Text;
            String expText = "21-333266";
            StringAssert.AreEqualIgnoringCase(expText, RealValue);
        }

        [Test]
        public void SortByOrderNumber()
        {
            var Columns = driver.FindElement(By.Id("btnColumns"));
            Columns.Click(); new WebDriverWait(driver, TimeSpan.FromSeconds(60)).Until(SeleniumExtras.WaitHelpers.ExpectedConditions.InvisibilityOfElementLocated(By.XPath("/html/body/div[27]/div/i/img")));

            var addColumn = driver.FindElement(By.XPath(".//*[@id='li_OrderNumber']/input[4]"));
            addColumn.Click();
            var SaveBtn = driver.FindElement(By.XPath(".//*[@id='gaugeColumns']/div/div/div[3]/button[1]"));
            SaveBtn.Click();
            new WebDriverWait(driver, TimeSpan.FromSeconds(60)).Until(SeleniumExtras.WaitHelpers.ExpectedConditions.InvisibilityOfElementLocated(By.XPath("/html/body/div[27]/div/i/img")));

            var sortByOrderNumber = driver.FindElement(By.XPath(".//*[@id='gauges']/table/tbody/tr[1]/th[9]/a"));
            String valBefore = driver.FindElement(By.XPath(".//*[@id='gauges']/table/tbody/tr[10]/td[1]")).Text;
            sortByOrderNumber.Click();
            new WebDriverWait(driver, TimeSpan.FromSeconds(60)).Until(SeleniumExtras.WaitHelpers.ExpectedConditions.InvisibilityOfElementLocated(By.XPath("/html/body/div[27]/div/i/img")));
            String RealText = driver.FindElement(By.XPath(".//*[@id='gauges']/table/tbody/tr[10]/td[1]")).Text;
            StringAssert.AreNotEqualIgnoringCase(valBefore, RealText);
        }

        [Test]
        public void SearchByServiceRegistrator()
        {
            var Columns = driver.FindElement(By.Id("btnColumns"));
            Columns.Click(); new WebDriverWait(driver, TimeSpan.FromSeconds(60)).Until(SeleniumExtras.WaitHelpers.ExpectedConditions.InvisibilityOfElementLocated(By.XPath("/html/body/div[27]/div/i/img")));
            var addColumn = driver.FindElement(By.XPath(".//*[@id='li_ServiceRegistrator']/input[4]"));
            addColumn.Click();
            var SaveBtn = driver.FindElement(By.XPath(".//*[@id='gaugeColumns']/div/div/div[3]/button[1]"));
            SaveBtn.Click();
            new WebDriverWait(driver, TimeSpan.FromSeconds(60)).Until(SeleniumExtras.WaitHelpers.ExpectedConditions.InvisibilityOfElementLocated(By.XPath("/html/body/div[27]/div/i/img")));

            var showAdvFil = driver.FindElement(By.Id("ShowAdvancedFilters"));
            showAdvFil.Click();

            var Service = driver.FindElement(By.XPath(".//*[@id='AdvacedFilters']/ul/li[3]/a"));
            Service.Click();
            var ServiceRegistrator = driver.FindElement(By.Id("ServiceRegistrator"));

            Actions actions = new Actions(driver);
            actions.MoveToElement(ServiceRegistrator).Click().Build().Perform();


            ServiceRegistrator.SendKeys("21-333266");
            var btnSearch = driver.FindElement(By.Id("btnSearch"));
            btnSearch.Click();
            new WebDriverWait(driver, TimeSpan.FromSeconds(60)).Until(SeleniumExtras.WaitHelpers.ExpectedConditions.InvisibilityOfElementLocated(By.XPath("/html/body/div[27]/div/i/img")));
            String RealValue = driver.FindElement(By.XPath(".//*[@id='gauges']/table/tbody/tr[2]/td[9]")).Text;
            String expText = "21-333266";
            StringAssert.AreEqualIgnoringCase(expText, RealValue);
        }

        [Test]
        public void SortByServiceRegistrator()
        {
            var Columns = driver.FindElement(By.Id("btnColumns"));
            Columns.Click(); new WebDriverWait(driver, TimeSpan.FromSeconds(60)).Until(SeleniumExtras.WaitHelpers.ExpectedConditions.InvisibilityOfElementLocated(By.XPath("/html/body/div[27]/div/i/img")));

            var addColumn = driver.FindElement(By.XPath(".//*[@id='li_ServiceRegistrator']/input[4]"));
            addColumn.Click();
            var SaveBtn = driver.FindElement(By.XPath(".//*[@id='gaugeColumns']/div/div/div[3]/button[1]"));
            SaveBtn.Click();
            new WebDriverWait(driver, TimeSpan.FromSeconds(60)).Until(SeleniumExtras.WaitHelpers.ExpectedConditions.InvisibilityOfElementLocated(By.XPath("/html/body/div[27]/div/i/img")));

            var sortByServiceRegistrator = driver.FindElement(By.XPath(".//*[@id='gauges']/table/tbody/tr[1]/th[9]/a"));
            String valBefore = driver.FindElement(By.XPath(".//*[@id='gauges']/table/tbody/tr[10]/td[1]")).Text;
            sortByServiceRegistrator.Click();
            new WebDriverWait(driver, TimeSpan.FromSeconds(60)).Until(SeleniumExtras.WaitHelpers.ExpectedConditions.InvisibilityOfElementLocated(By.XPath("/html/body/div[27]/div/i/img")));

            String RealText = driver.FindElement(By.XPath(".//*[@id='gauges']/table/tbody/tr[10]/td[1]")).Text;
            StringAssert.AreNotEqualIgnoringCase(valBefore, RealText);
        }

        [Test]
        public void SearchByNextServiceDate()
        {
            var Columns = driver.FindElement(By.Id("btnColumns"));
            Columns.Click(); new WebDriverWait(driver, TimeSpan.FromSeconds(60)).Until(SeleniumExtras.WaitHelpers.ExpectedConditions.InvisibilityOfElementLocated(By.XPath("/html/body/div[27]/div/i/img")));
            var addColumn = driver.FindElement(By.XPath(".//*[@id='li_NextServiceDate']/input[4]"));
            addColumn.Click();
            var SaveBtn = driver.FindElement(By.XPath(".//*[@id='gaugeColumns']/div/div/div[3]/button[1]"));
            SaveBtn.Click();
            new WebDriverWait(driver, TimeSpan.FromSeconds(60)).Until(SeleniumExtras.WaitHelpers.ExpectedConditions.InvisibilityOfElementLocated(By.XPath("/html/body/div[27]/div/i/img")));
            var showAdvFil = driver.FindElement(By.Id("ShowAdvancedFilters"));
            showAdvFil.Click();
            var Service = driver.FindElement(By.XPath(".//*[@id='AdvacedFilters']/ul/li[3]/a"));
            Service.Click();
            var NextServiceDate = driver.FindElement(By.Id("NextServiceDate"));

            Actions actions = new Actions(driver);
            actions.MoveToElement(NextServiceDate).Click().Build().Perform();

            NextServiceDate.SendKeys("1986-12-11 to 1986-12-11");
            var btnSearch = driver.FindElement(By.Id("btnSearch"));
            btnSearch.Click();
            new WebDriverWait(driver, TimeSpan.FromSeconds(60)).Until(SeleniumExtras.WaitHelpers.ExpectedConditions.InvisibilityOfElementLocated(By.XPath("/html/body/div[27]/div/i/img")));

            String RealValue = driver.FindElement(By.XPath(".//*[@id='gauges']/table/tbody/tr[2]/td[9]")).Text;
            String expText = "1986-12-11";
            StringAssert.AreEqualIgnoringCase(expText, RealValue);
        }

        [Test]
        public void SortByNextServiceDate()
        {
            var Columns = driver.FindElement(By.Id("btnColumns"));
            Columns.Click(); Thread.Sleep(500);
            var addColumn = driver.FindElement(By.XPath(".//*[@id='li_NextServicenDate']/input[4]"));
            addColumn.Click();
            Thread.Sleep(500);
            var SaveBtn = driver.FindElement(By.XPath(".//*[@id='gaugeColumns']/div/div/div[3]/button[1]"));
            SaveBtn.Click();
            Thread.Sleep(15000);

            var sortByNextServiceDate = driver.FindElement(By.XPath(".//*[@id='gauges']/table/tbody/tr[1]/th[9]/a"));
            String valBefore = driver.FindElement(By.XPath(".//*[@id='gauges']/table/tbody/tr[10]/td[1]")).Text;
            sortByNextServiceDate.Click();
            Thread.Sleep(30000);
            sortByNextServiceDate.Click();
            Thread.Sleep(30000);
            String RealText = driver.FindElement(By.XPath(".//*[@id='gauges']/table/tbody/tr[10]/td[1]")).Text;
            StringAssert.AreNotEqualIgnoringCase(valBefore, RealText);
        }

        [Test]
        public void SearchByLatestServiceDate()
        {
            var Columns = driver.FindElement(By.Id("btnColumns"));
            Columns.Click(); new WebDriverWait(driver, TimeSpan.FromSeconds(60)).Until(SeleniumExtras.WaitHelpers.ExpectedConditions.InvisibilityOfElementLocated(By.XPath("/html/body/div[27]/div/i/img")));
            var addColumn = driver.FindElement(By.XPath(".//*[@id='li_LatestServiceDate']/input[4]"));
            addColumn.Click();
            var SaveBtn = driver.FindElement(By.XPath(".//*[@id='gaugeColumns']/div/div/div[3]/button[1]"));
            SaveBtn.Click();
            new WebDriverWait(driver, TimeSpan.FromSeconds(80)).Until(SeleniumExtras.WaitHelpers.ExpectedConditions.InvisibilityOfElementLocated(By.XPath("/html/body/div[27]/div/i/img")));
            var showAdvFil = driver.FindElement(By.Id("ShowAdvancedFilters"));
            showAdvFil.Click();
            var Service = driver.FindElement(By.XPath(".//*[@id='AdvacedFilters']/ul/li[3]/a"));
            Service.Click();
            var LatestServiceDate = driver.FindElement(By.Id("LatestServiceDate"));

            Actions actions = new Actions(driver);
            actions.MoveToElement(LatestServiceDate).Click().Build().Perform();
            LatestServiceDate.SendKeys("2017-06-08 to 2017-06-08");
            var btnSearch = driver.FindElement(By.Id("btnSearch"));
            btnSearch.Click();
            new WebDriverWait(driver, TimeSpan.FromSeconds(60)).Until(SeleniumExtras.WaitHelpers.ExpectedConditions.InvisibilityOfElementLocated(By.XPath("/html/body/div[27]/div/i/img")));

            String RealValue = driver.FindElement(By.XPath(".//*[@id='gauges']/table/tbody/tr[2]/td[9]")).Text;
            String expText = "2017-06-08";
            StringAssert.AreEqualIgnoringCase(expText, RealValue);
        }

        [Test]
        public void SortByLatestServiceDate()
        {
            var Columns = driver.FindElement(By.Id("btnColumns"));
            Columns.Click(); 
            new WebDriverWait(driver, TimeSpan.FromSeconds(60)).Until(SeleniumExtras.WaitHelpers.ExpectedConditions.InvisibilityOfElementLocated(By.XPath("/html/body/div[27]/div/i/img")));
            var addColumn = driver.FindElement(By.XPath(".//*[@id='li_LatestServiceDate']/input[4]"));
            addColumn.Click();
            var SaveBtn = driver.FindElement(By.XPath(".//*[@id='gaugeColumns']/div/div/div[3]/button[1]"));
            SaveBtn.Click();
            new WebDriverWait(driver, TimeSpan.FromSeconds(60)).Until(SeleniumExtras.WaitHelpers.ExpectedConditions.InvisibilityOfElementLocated(By.XPath("/html/body/div[27]/div/i/img")));
          

            var sortByLatestServiceDate = driver.FindElement(By.XPath(".//*[@id='gauges']/table/tbody/tr[1]/th[9]/a"));
            String valBefore = driver.FindElement(By.XPath(".//*[@id='gauges']/table/tbody/tr[10]/td[1]")).Text;
            sortByLatestServiceDate.Click();
            new WebDriverWait(driver, TimeSpan.FromSeconds(60)).Until(SeleniumExtras.WaitHelpers.ExpectedConditions.InvisibilityOfElementLocated(By.XPath("/html/body/div[27]/div/i/img")));

            sortByLatestServiceDate.Click();

            String RealText = driver.FindElement(By.XPath(".//*[@id='gauges']/table/tbody/tr[10]/td[1]")).Text;
            StringAssert.AreNotEqualIgnoringCase(valBefore, RealText);
        }

        [TearDown]
        public void Finish()
        {
            driver.Close();
        }

    }
}
