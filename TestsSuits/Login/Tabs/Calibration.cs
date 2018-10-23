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
    public class Calibration
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
        public void SearchByCalibrationSupplier()
        {
            var Columns = driver.FindElement(By.Id("btnColumns"));
            Columns.Click();
            new WebDriverWait(driver, TimeSpan.FromSeconds(60))
                .Until(SeleniumExtras.WaitHelpers.ExpectedConditions
                       .InvisibilityOfElementLocated(By.XPath("/html/body/div[27]/div/i/img")));
            var addColumn = driver.FindElement(By.XPath(".//*[@id='li_CalibrationSupplier']/input[4]"));
            addColumn.Click(); 
            var SaveBtn = driver.FindElement(By.XPath(".//*[@id='gaugeColumns']/div/div/div[3]/button[1]"));
            SaveBtn.Click();
            new WebDriverWait(driver, TimeSpan.FromSeconds(60))
                .Until(SeleniumExtras.WaitHelpers.ExpectedConditions
                       .InvisibilityOfElementLocated(By.XPath("/html/body/div[27]/div/i/img")));

            var showAdvFil = driver.FindElement(By.Id("ShowAdvancedFilters")); 
            showAdvFil.Click(); 
            var Calibration = driver.FindElement(By.XPath(".//*[@id='AdvacedFilters']/ul/li[2]/a")); Calibration.Click();
            var CalibrationSupplier = driver.FindElement(By.Id("CalibrationSupplier"));

            Actions actions = new Actions(driver);
            actions.MoveToElement(CalibrationSupplier).Click().Build().Perform();

            CalibrationSupplier.SendKeys("Volvo internt - 92470 Calibration & Support");
            var btnSearch = driver.FindElement(By.Id("btnSearch"));
            btnSearch.Click();
            new WebDriverWait(driver, TimeSpan.FromSeconds(60))
                 .Until(SeleniumExtras.WaitHelpers.ExpectedConditions
                        .InvisibilityOfElementLocated(By.XPath("/html/body/div[27]/div/i/img")));

            String RealValue = driver.FindElement(By.XPath(".//*[@id='gauges']/table/tbody/tr[2]/td[9]")).Text;
            String expText = "Volvo internt - 92470 Calibration & Support";
            StringAssert.AreEqualIgnoringCase(expText, RealValue);
        }

        [Test]
        public void SortByCalibrationSupplier()
        {
            var Columns = driver.FindElement(By.Id("btnColumns"));
            Columns.Click();
            new WebDriverWait(driver, TimeSpan.FromSeconds(60))
                .Until(SeleniumExtras.WaitHelpers.ExpectedConditions
                       .InvisibilityOfElementLocated(By.XPath("/html/body/div[27]/div/i/img")));
            var addColumn = driver.FindElement(By.XPath(".//*[@id='li_CalibrationSupplier']/input[4]"));
            addColumn.Click();
            var SaveBtn = driver.FindElement(By.XPath(".//*[@id='gaugeColumns']/div/div/div[3]/button[1]"));
            SaveBtn.Click();
            new WebDriverWait(driver, TimeSpan.FromSeconds(60))
                .Until(SeleniumExtras.WaitHelpers.ExpectedConditions
                       .InvisibilityOfElementLocated(By.XPath("/html/body/div[27]/div/i/img")));

            var sortByCalibrationSupplier = driver.FindElement(By.XPath(".//*[@id='gauges']/table/tbody/tr[1]/th[9]/a"));
            String valBefore = driver.FindElement(By.XPath(".//*[@id='gauges']/table/tbody/tr[10]/td[1]")).Text;
            sortByCalibrationSupplier.Click();
            new WebDriverWait(driver, TimeSpan.FromSeconds(60))
                .Until(SeleniumExtras.WaitHelpers.ExpectedConditions
                       .InvisibilityOfElementLocated(By.XPath("/html/body/div[27]/div/i/img")));
            String RealText = driver.FindElement(By.XPath(".//*[@id='gauges']/table/tbody/tr[10]/td[1]")).Text;
            StringAssert.AreNotEqualIgnoringCase(valBefore, RealText);
        }

        [Test]
        public void SearchByCalibrationCost()
        {
            var Columns = driver.FindElement(By.Id("btnColumns"));
            Columns.Click();
            new WebDriverWait(driver, TimeSpan.FromSeconds(60))
                .Until(SeleniumExtras.WaitHelpers.ExpectedConditions
                       .InvisibilityOfElementLocated(By.XPath("/html/body/div[27]/div/i/img")));
            var addColumn = driver.FindElement(By.XPath(".//*[@id='li_CalibrationCost']/input[4]"));
            addColumn.Click();
            var SaveBtn = driver.FindElement(By.XPath(".//*[@id='gaugeColumns']/div/div/div[3]/button[1]"));
            SaveBtn.Click();
            new WebDriverWait(driver, TimeSpan.FromSeconds(60))
                .Until(SeleniumExtras.WaitHelpers.ExpectedConditions
                       .InvisibilityOfElementLocated(By.XPath("/html/body/div[27]/div/i/img")));
            var showAdvFil = driver.FindElement(By.Id("ShowAdvancedFilters"));
            showAdvFil.Click();
            var Calibration = driver.FindElement(By.XPath(".//*[@id='AdvacedFilters']/ul/li[2]/a")); 
            Calibration.Click();
            var CalibrationCost = driver.FindElement(By.Id("CalibrationCost"));

            Actions actions = new Actions(driver);
            actions.MoveToElement(CalibrationCost).Click().Build().Perform();

            CalibrationCost.SendKeys("92710.0000");
            var btnSearch = driver.FindElement(By.Id("btnSearch"));
            btnSearch.Click();
            new WebDriverWait(driver, TimeSpan.FromSeconds(60))
                .Until(SeleniumExtras.WaitHelpers.ExpectedConditions
                       .InvisibilityOfElementLocated(By.XPath("/html/body/div[27]/div/i/img")));

            String RealValue = driver.FindElement(By.XPath(".//*[@id='gauges']/table/tbody/tr[2]/td[9]")).Text;
            String expText = "92710.0000";
            StringAssert.AreEqualIgnoringCase(expText, RealValue);
        }

        [Test]
        public void SortByCalibrationCost()
        {
            var Columns = driver.FindElement(By.Id("btnColumns"));
            Columns.Click();
            new WebDriverWait(driver, TimeSpan.FromSeconds(60))
                .Until(SeleniumExtras.WaitHelpers.ExpectedConditions
                       .InvisibilityOfElementLocated(By.XPath("/html/body/div[27]/div/i/img")));
            var addColumn = driver.FindElement(By.XPath(".//*[@id='li_CalibrationCost']/input[4]"));
            addColumn.Click();
            var SaveBtn = driver.FindElement(By.XPath(".//*[@id='gaugeColumns']/div/div/div[3]/button[1]"));
            SaveBtn.Click();
            new WebDriverWait(driver, TimeSpan.FromSeconds(60))
                .Until(SeleniumExtras.WaitHelpers.ExpectedConditions
                       .InvisibilityOfElementLocated(By.XPath("/html/body/div[27]/div/i/img")));

            var sortByCalibrationCost = driver.FindElement(By.XPath(".//*[@id='gauges']/table/tbody/tr[1]/th[9]/a"));
            String valBefore = driver.FindElement(By.XPath(".//*[@id='gauges']/table/tbody/tr[10]/td[1]")).Text;
            sortByCalibrationCost.Click();
            new WebDriverWait(driver, TimeSpan.FromSeconds(60))
                .Until(SeleniumExtras.WaitHelpers.ExpectedConditions
                       .InvisibilityOfElementLocated(By.XPath("/html/body/div[27]/div/i/img")));
            String RealText = driver.FindElement(By.XPath(".//*[@id='gauges']/table/tbody/tr[10]/td[1]")).Text;
            StringAssert.AreNotEqualIgnoringCase(valBefore, RealText);
        }

        [Test]
        public void SearchByCalibrationCostCenter()
        {
            var Columns = driver.FindElement(By.Id("btnColumns"));
            Columns.Click();
            new WebDriverWait(driver, TimeSpan.FromSeconds(60))
                .Until(SeleniumExtras.WaitHelpers.ExpectedConditions
                       .InvisibilityOfElementLocated(By.XPath("/html/body/div[27]/div/i/img")));
            var addColumn = driver.FindElement(By.XPath(".//*[@id='li_CalibrationCostCenter']/input[4]"));
            addColumn.Click();
            var SaveBtn = driver.FindElement(By.XPath(".//*[@id='gaugeColumns']/div/div/div[3]/button[1]"));
            SaveBtn.Click();
            new WebDriverWait(driver, TimeSpan.FromSeconds(60))
                .Until(SeleniumExtras.WaitHelpers.ExpectedConditions
                       .InvisibilityOfElementLocated(By.XPath("/html/body/div[27]/div/i/img")));

            var showAdvFil = driver.FindElement(By.Id("ShowAdvancedFilters"));
            showAdvFil.Click();
            var Calibration = driver.FindElement(By.XPath(".//*[@id='AdvacedFilters']/ul/li[2]/a"));
            Calibration.Click();
            var CalibrationCostCenter = driver.FindElement(By.Id("CalibrationCostCenter"));

            Actions actions = new Actions(driver);
            actions.MoveToElement(CalibrationCostCenter).Click().Build().Perform();

            CalibrationCostCenter.SendKeys("99919");
            var btnSearch = driver.FindElement(By.Id("btnSearch"));
            btnSearch.Click();
            new WebDriverWait(driver, TimeSpan.FromSeconds(60))
                .Until(SeleniumExtras.WaitHelpers.ExpectedConditions
                       .InvisibilityOfElementLocated(By.XPath("/html/body/div[27]/div/i/img")));

            String RealValue = driver.FindElement(By.XPath(".//*[@id='gauges']/table/tbody/tr[2]/td[9]")).Text;
            String expText = "99919";
            StringAssert.AreEqualIgnoringCase(expText, RealValue);
        }

        [Test]
        public void SortByCalibrationCostCenter()
        {
            var Columns = driver.FindElement(By.Id("btnColumns"));
            Columns.Click();
            new WebDriverWait(driver, TimeSpan.FromSeconds(60))
                .Until(SeleniumExtras.WaitHelpers.ExpectedConditions
                       .InvisibilityOfElementLocated(By.XPath("/html/body/div[27]/div/i/img")));
            var addColumn = driver.FindElement(By.XPath(".//*[@id='li_CalibrationCostCenter']/input[4]"));
            addColumn.Click();
            var SaveBtn = driver.FindElement(By.XPath(".//*[@id='gaugeColumns']/div/div/div[3]/button[1]"));
            SaveBtn.Click();
            new WebDriverWait(driver, TimeSpan.FromSeconds(60))
                .Until(SeleniumExtras.WaitHelpers.ExpectedConditions
                       .InvisibilityOfElementLocated(By.XPath("/html/body/div[27]/div/i/img")));
            var sortByCalibrationCostCenter = driver.FindElement(By.XPath(".//*[@id='gauges']/table/tbody/tr[1]/th[9]/a"));
            String valBefore = driver.FindElement(By.XPath(".//*[@id='gauges']/table/tbody/tr[10]/td[1]")).Text;
            sortByCalibrationCostCenter.Click();
            new WebDriverWait(driver, TimeSpan.FromSeconds(60))
                .Until(SeleniumExtras.WaitHelpers.ExpectedConditions
                       .InvisibilityOfElementLocated(By.XPath("/html/body/div[27]/div/i/img")));
            String RealText = driver.FindElement(By.XPath(".//*[@id='gauges']/table/tbody/tr[10]/td[1]")).Text;
            StringAssert.AreNotEqualIgnoringCase(valBefore, RealText);
        }

        [Test]
        public void SearchByCalibrationLocation()
        {
            var Columns = driver.FindElement(By.Id("btnColumns"));
            Columns.Click();
            new WebDriverWait(driver, TimeSpan.FromSeconds(60))
                .Until(SeleniumExtras.WaitHelpers.ExpectedConditions
                       .InvisibilityOfElementLocated(By.XPath("/html/body/div[27]/div/i/img")));
            var addColumn = driver.FindElement(By.XPath(".//*[@id='li_CalibrationLocation']/input[4]"));
            addColumn.Click();
            var SaveBtn = driver.FindElement(By.XPath(".//*[@id='gaugeColumns']/div/div/div[3]/button[1]"));
            SaveBtn.Click();
            new WebDriverWait(driver, TimeSpan.FromSeconds(60))
                .Until(SeleniumExtras.WaitHelpers.ExpectedConditions
                       .InvisibilityOfElementLocated(By.XPath("/html/body/div[27]/div/i/img")));

            var showAdvFil = driver.FindElement(By.Id("ShowAdvancedFilters"));
            showAdvFil.Click();
            var Calibration = driver.FindElement(By.XPath(".//*[@id='AdvacedFilters']/ul/li[2]/a"));
            Calibration.Click();
            var CalibrationLocation = driver.FindElement(By.Id("CalibrationLocation"));

            Actions actions = new Actions(driver);
            actions.MoveToElement(CalibrationLocation).Click().Build().Perform();

            CalibrationLocation.SendKeys("Hällered");
            var btnSearch = driver.FindElement(By.Id("btnSearch"));
            btnSearch.Click();
            new WebDriverWait(driver, TimeSpan.FromSeconds(60))
                .Until(SeleniumExtras.WaitHelpers.ExpectedConditions
                       .InvisibilityOfElementLocated(By.XPath("/html/body/div[27]/div/i/img")));

            String RealValue = driver.FindElement(By.XPath(".//*[@id='gauges']/table/tbody/tr[2]/td[9]")).Text;
            String expText = "Hällered";
            StringAssert.AreEqualIgnoringCase(expText, RealValue);
        }
        [Test]
        public void SortByCalibrationLocation()
        {
            var Columns = driver.FindElement(By.Id("btnColumns"));
            Columns.Click();
            new WebDriverWait(driver, TimeSpan.FromSeconds(60))
                .Until(SeleniumExtras.WaitHelpers.ExpectedConditions
                       .InvisibilityOfElementLocated(By.XPath("/html/body/div[27]/div/i/img")));
            var addColumn = driver.FindElement(By.XPath(".//*[@id='li_CalibrationLocation']/input[4]"));
            addColumn.Click();
            var SaveBtn = driver.FindElement(By.XPath(".//*[@id='gaugeColumns']/div/div/div[3]/button[1]"));
            SaveBtn.Click();
            new WebDriverWait(driver, TimeSpan.FromSeconds(60))
                .Until(SeleniumExtras.WaitHelpers.ExpectedConditions
                       .InvisibilityOfElementLocated(By.XPath("/html/body/div[27]/div/i/img")));

            var sortByCalibrationLocation = driver.FindElement(By.XPath(".//*[@id='gauges']/table/tbody/tr[1]/th[9]/a"));
            String valBefore = driver.FindElement(By.XPath(".//*[@id='gauges']/table/tbody/tr[10]/td[1]")).Text;
            sortByCalibrationLocation.Click();
            new WebDriverWait(driver, TimeSpan.FromSeconds(60))
                .Until(SeleniumExtras.WaitHelpers.ExpectedConditions
                       .InvisibilityOfElementLocated(By.XPath("/html/body/div[27]/div/i/img")));
            String RealText = driver.FindElement(By.XPath(".//*[@id='gauges']/table/tbody/tr[10]/td[1]")).Text;
            StringAssert.AreNotEqualIgnoringCase(valBefore, RealText);
        }

                [Test]
                public void SearchByNextCalibrationDate()
                {
                    var Columns = driver.FindElement(By.Id("btnColumns"));
                    Columns.Click();
            new WebDriverWait(driver, TimeSpan.FromSeconds(60))
        .Until(SeleniumExtras.WaitHelpers.ExpectedConditions
               .InvisibilityOfElementLocated(By.XPath("/html/body/div[27]/div/i/img")));
            var addColumn = driver.FindElement(By.XPath(".//*[@id='li_NextCalibrationDate']/input[4]"));
                    addColumn.Click();
                    var SaveBtn = driver.FindElement(By.XPath(".//*[@id='gaugeColumns']/div/div/div[3]/button[1]"));
                    SaveBtn.Click();
            new WebDriverWait(driver, TimeSpan.FromSeconds(60))
        .Until(SeleniumExtras.WaitHelpers.ExpectedConditions
               .InvisibilityOfElementLocated(By.XPath("/html/body/div[27]/div/i/img")));

            var showAdvFil = driver.FindElement(By.Id("ShowAdvancedFilters"));
                    showAdvFil.Click();
                    var Calibration = driver.FindElement(By.XPath(".//*[@id='AdvacedFilters']/ul/li[2]/a"));
                    Calibration.Click();
                    var NextCalibrationDate = driver.FindElement(By.Id("NextCalibrationDate"));

                    Actions actions = new Actions(driver);
                    actions.MoveToElement(NextCalibrationDate).Click().Build().Perform();

                    NextCalibrationDate.SendKeys("1986-12-11 to 1986-12-11");
                    var btnSearch = driver.FindElement(By.Id("btnSearch"));
                    btnSearch.Click();
            new WebDriverWait(driver, TimeSpan.FromSeconds(60))
        .Until(SeleniumExtras.WaitHelpers.ExpectedConditions
               .InvisibilityOfElementLocated(By.XPath("/html/body/div[27]/div/i/img")));

            String RealValue = driver.FindElement(By.XPath(".//*[@id='gauges']/table/tbody/tr[2]/td[9]")).Text;
                    String expText = "1986-12-11";
                    StringAssert.AreEqualIgnoringCase(expText, RealValue);

                }

        [Test]
        public void SortByNextCalibrationDate()
        {
            var Columns = driver.FindElement(By.Id("btnColumns"));
            Columns.Click();
            new WebDriverWait(driver, TimeSpan.FromSeconds(60))
                .Until(SeleniumExtras.WaitHelpers.ExpectedConditions
                       .InvisibilityOfElementLocated(By.XPath("/html/body/div[27]/div/i/img")));
            var addColumn = driver.FindElement(By.XPath(".//*[@id='li_NextCalibrationDate']/input[4]"));
            addColumn.Click();
            var SaveBtn = driver.FindElement(By.XPath(".//*[@id='gaugeColumns']/div/div/div[3]/button[1]"));
            SaveBtn.Click();
            new WebDriverWait(driver, TimeSpan.FromSeconds(60))
                .Until(SeleniumExtras.WaitHelpers.ExpectedConditions
                       .InvisibilityOfElementLocated(By.XPath("/html/body/div[27]/div/i/img")));

            var sortByNextCalibrationDate = driver.FindElement(By.XPath(".//*[@id='gauges']/table/tbody/tr[1]/th[9]/a"));
            String valBefore = driver.FindElement(By.XPath(".//*[@id='gauges']/table/tbody/tr[10]/td[1]")).Text;
            sortByNextCalibrationDate.Click();
            new WebDriverWait(driver, TimeSpan.FromSeconds(60))
                .Until(SeleniumExtras.WaitHelpers.ExpectedConditions
                       .InvisibilityOfElementLocated(By.XPath("/html/body/div[27]/div/i/img")));
            String RealText = driver.FindElement(By.XPath(".//*[@id='gauges']/table/tbody/tr[10]/td[1]")).Text;
            StringAssert.AreNotEqualIgnoringCase(valBefore, RealText);
        }

        [Test]
        public void SearchByLatestCalibrationDate()
        {
            var Columns = driver.FindElement(By.Id("btnColumns"));
            Columns.Click();
            new WebDriverWait(driver, TimeSpan.FromSeconds(60))
                .Until(SeleniumExtras.WaitHelpers.ExpectedConditions
                       .InvisibilityOfElementLocated(By.XPath("/html/body/div[27]/div/i/img")));
            var addColumn = driver.FindElement(By.XPath(".//*[@id='li_LatestCalibrationDate']/input[4]"));
            addColumn.Click();
            var SaveBtn = driver.FindElement(By.XPath(".//*[@id='gaugeColumns']/div/div/div[3]/button[1]"));
            SaveBtn.Click();
            new WebDriverWait(driver, TimeSpan.FromSeconds(60))
                .Until(SeleniumExtras.WaitHelpers.ExpectedConditions
                       .InvisibilityOfElementLocated(By.XPath("/html/body/div[27]/div/i/img")));

            var showAdvFil = driver.FindElement(By.Id("ShowAdvancedFilters"));
            showAdvFil.Click();
            var Calibration = driver.FindElement(By.XPath(".//*[@id='AdvacedFilters']/ul/li[2]/a"));
            Calibration.Click();
            var LatestCalibrationDate = driver.FindElement(By.Id("LatestCalibrationDate"));

            Actions actions = new Actions(driver);
            actions.MoveToElement(LatestCalibrationDate).Click().Build().Perform();
            LatestCalibrationDate.SendKeys("2202-09-24 to 2202-09-24");
            var btnSearch = driver.FindElement(By.Id("btnSearch"));
            btnSearch.Click();
            new WebDriverWait(driver, TimeSpan.FromSeconds(60))
                .Until(SeleniumExtras.WaitHelpers.ExpectedConditions
                       .InvisibilityOfElementLocated(By.XPath("/html/body/div[27]/div/i/img")));

            String RealValue = driver.FindElement(By.XPath(".//*[@id='gauges']/table/tbody/tr[2]/td[9]")).Text;
            String expText = "2202-09-24";
            StringAssert.AreEqualIgnoringCase(expText, RealValue);
        }

        [Test]
        public void SortByLatestCalibrationDate()
        {
            var Columns = driver.FindElement(By.Id("btnColumns"));
            Columns.Click();
            new WebDriverWait(driver, TimeSpan.FromSeconds(60))
                .Until(SeleniumExtras.WaitHelpers.ExpectedConditions
                       .InvisibilityOfElementLocated(By.XPath("/html/body/div[27]/div/i/img")));
            var addColumn = driver.FindElement(By.XPath(".//*[@id='li_LatestCalibrationDate']/input[4]"));
            addColumn.Click();
            var SaveBtn = driver.FindElement(By.XPath(".//*[@id='gaugeColumns']/div/div/div[3]/button[1]"));
            SaveBtn.Click();
            new WebDriverWait(driver, TimeSpan.FromSeconds(60))
                .Until(SeleniumExtras.WaitHelpers.ExpectedConditions
                       .InvisibilityOfElementLocated(By.XPath("/html/body/div[27]/div/i/img")));

            var sortByLatestCalibrationDate = driver.FindElement(By.XPath(".//*[@id='gauges']/table/tbody/tr[1]/th[9]/a"));
            String valBefore = driver.FindElement(By.XPath(".//*[@id='gauges']/table/tbody/tr[10]/td[1]")).Text;
            sortByLatestCalibrationDate.Click();
            new WebDriverWait(driver, TimeSpan.FromSeconds(60))
                .Until(SeleniumExtras.WaitHelpers.ExpectedConditions
                       .InvisibilityOfElementLocated(By.XPath("/html/body/div[27]/div/i/img")));
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
             
