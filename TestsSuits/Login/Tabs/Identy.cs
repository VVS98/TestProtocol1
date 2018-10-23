using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using NUnit.Framework;
using System.Threading;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using System.Collections.Generic;
using System.Linq;


namespace Tabs
{
    public class Identy
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
        public void AddAllColumns()
        {
            driver.FindElement(By.Id("btnColumns")).Click();

            new WebDriverWait(driver, TimeSpan.FromSeconds(60))
                .Until(SeleniumExtras.WaitHelpers.ExpectedConditions
                       .InvisibilityOfElementLocated(By.XPath("/html/body/div[27]/div/i/img")));

            driver.FindElement(By.Id("btnSelectAllColumns")).Click();

            driver.FindElement(By.XPath(".//*[@id='gaugeColumns']/div/div/div[3]/button[1]")).Click();
            new WebDriverWait(driver, TimeSpan.FromSeconds(60))
              .Until(SeleniumExtras.WaitHelpers.ExpectedConditions
                     .InvisibilityOfElementLocated(By.XPath("/html/body/div[27]/div/i/img")));

            IList<IWebElement> rowsAft = driver.FindElements(By.XPath(".//*[@id='gauges']/table//th"));
            var rowsAfter = rowsAft.Count;
            Assert.That(rowsAfter, Is.EqualTo(89));
        }

        [Test]
        public void AddColumn()
        {
            driver.FindElement(By.Id("btnColumns")).Click();

            new WebDriverWait(driver, TimeSpan.FromSeconds(60))
                .Until(SeleniumExtras.WaitHelpers.ExpectedConditions
                       .InvisibilityOfElementLocated(By.XPath("/html/body/div[27]/div/i/img")));

            driver.FindElement(By.XPath(".//*[@id='li_Article']/input[4]")).Click();
            driver.FindElement(By.XPath(".//*[@id='gaugeColumns']/div/div/div[3]/button[1]")).Click();

            new WebDriverWait(driver, TimeSpan.FromSeconds(60))
                .Until(SeleniumExtras.WaitHelpers.ExpectedConditions
                       .InvisibilityOfElementLocated(By.XPath("/html/body/div[27]/div/i/img")));
            //Counting elems in array 
            IList <IWebElement> rowsAft = driver.FindElements(By.XPath(".//*[@id='gauges']/table//th"));
            var rowsAfter = rowsAft.Count;
            Assert.That(rowsAfter, Is.EqualTo(9));
        }

        [Test]
        public void RemoveAllColumns()
        {
            driver.FindElement(By.Id("btnColumns")).Click();

            new WebDriverWait(driver, TimeSpan.FromSeconds(60))
                .Until(SeleniumExtras.WaitHelpers.ExpectedConditions
                       .InvisibilityOfElementLocated(By.XPath("/html/body/div[27]/div/i/img")));

            driver.FindElement(By.Id("btnRemoveAllColumns")).Click();
            driver.FindElement(By.XPath(".//*[@id='gaugeColumns']/div/div/div[3]/button[1]")).Click();
            new WebDriverWait(driver, TimeSpan.FromSeconds(60))
              .Until(SeleniumExtras.WaitHelpers.ExpectedConditions
                     .InvisibilityOfElementLocated(By.XPath("/html/body/div[27]/div/i/img")));


            IList<IWebElement> rowsAft = driver.FindElements(By.XPath(".//*[@id='gauges']/table//th"));
            var rowsAfter = rowsAft.Count;
            Assert.That(rowsAfter, Is.EqualTo(0));
        }

        [Test]
        public void RemoveColumn()
        {
            driver.FindElement(By.Id("btnColumns")).Click();
            new WebDriverWait(driver, TimeSpan.FromSeconds(60))
                .Until(SeleniumExtras.WaitHelpers.ExpectedConditions
                       .InvisibilityOfElementLocated(By.XPath("/html/body/div[27]/div/i/img")));

            driver.FindElement(By.XPath(".//*[@id='li_SerialNumber']/input[5]")).Click();
            driver.FindElement(By.XPath(".//*[@id='gaugeColumns']/div/div/div[3]/button[1]")).Click();

            new WebDriverWait(driver, TimeSpan.FromSeconds(60))
                .Until(SeleniumExtras.WaitHelpers.ExpectedConditions
                       .InvisibilityOfElementLocated(By.XPath("/html/body/div[27]/div/i/img")));

            IList<IWebElement> rowsAft = driver.FindElements(By.XPath(".//*[@id='gauges']/table//th"));
            var rowsAfter = rowsAft.Count;
            Assert.That(rowsAfter, Is.EqualTo(7));
        }

        [Test]
        public void SwipingСolumns()
        {
            var valBeforeResp = driver.FindElement(By.XPath(".//*[@id='gauges']/table/tbody/tr[1]/th[5]")).Text;
            var valBeforeEdit = driver.FindElement(By.XPath(".//*[@id='gauges']/table/tbody/tr[1]/th[8]")).Text;

            driver.FindElement(By.Id("btnColumns")).Click(); 
            new WebDriverWait(driver, TimeSpan.FromSeconds(60))
                .Until(SeleniumExtras.WaitHelpers.ExpectedConditions
                       .InvisibilityOfElementLocated(By.XPath("/html/body/div[27]/div/i/img")));
                       
            var from = driver.FindElement(By.XPath(".//*[@id='li_Edit']/span"));
            var to = driver.FindElement(By.XPath(".//*[@id='li_ResponsiblePerson']/span"));
            Actions act = new Actions(driver);
            act.ClickAndHold(from)
               .MoveToElement(to)
               .Build()
               .Perform();
            var SaveBtn = driver.FindElement(By.XPath(".//*[@id='gaugeColumns']/div/div/div[3]/button[1]"));
            SaveBtn.Click();

            new WebDriverWait(driver, TimeSpan.FromSeconds(60))
                .Until(SeleniumExtras.WaitHelpers.ExpectedConditions
                       .InvisibilityOfElementLocated(By.XPath("/html/body/div[27]/div/i/img")));

            var valAfterResp = driver.FindElement(By.XPath(".//*[@id='gauges']/table/tbody/tr[1]/th[5]")).Text;
            var valAfterEdit = driver.FindElement(By.XPath(".//*[@id='gauges']/table/tbody/tr[1]/th[8]")).Text;

            Assert.AreNotEqual(valBeforeResp, valAfterResp);
            Assert.AreNotEqual(valBeforeEdit, valAfterEdit);
        }

        [Test]
        public void ExportWhenSearchResultEqualsTo0()
        {
            driver.FindElement(By.Id("ShowAdvancedFilters")).Click();
            new WebDriverWait(driver, TimeSpan.FromSeconds(60))
                .Until(SeleniumExtras.WaitHelpers.ExpectedConditions
                       .InvisibilityOfElementLocated(By.XPath("/html/body/div[27]/div/i/img")));

            var IdNumber = driver.FindElement(By.Id("IdNumber"));

            Actions actions = new Actions(driver);
            actions.MoveToElement(IdNumber).Click().Build().Perform();

            IdNumber.SendKeys("DATB-768:10"); 
            var btnSearch = driver.FindElement(By.Id("btnSearch")); btnSearch.Click();

            new WebDriverWait(driver, TimeSpan.FromSeconds(60))
                .Until(SeleniumExtras.WaitHelpers.ExpectedConditions
                       .InvisibilityOfElementLocated(By.XPath("/html/body/div[27]/div/i/img")));

            var exportBtn = driver.FindElement(By.Id("btnExport"));
            Boolean flag = exportBtn.Selected;
            Assert.False(flag);
        }

        [Test]
        public void ExportGaugeWhenUserDidntSelectAnyColumn()
        {
            RemoveAllColumns();
            driver.FindElement(By.Id("ShowAdvancedFilters")).Click(); 
            var IdNumber = driver.FindElement(By.Id("IdNumber"));

            Actions actions = new Actions(driver);
            actions.MoveToElement(IdNumber).Click().Build().Perform();

            IdNumber.SendKeys("DATB-768:1"); 
            driver.FindElement(By.Id("btnSearch")).Click();

            new WebDriverWait(driver, TimeSpan.FromSeconds(60))
                .Until(SeleniumExtras.WaitHelpers.ExpectedConditions
                       .InvisibilityOfElementLocated(By.XPath("/html/body/div[27]/div/i/img")));

            var exportBtn = driver.FindElement(By.Id("btnExport"));
            Boolean flag = exportBtn.Selected;
            Assert.False(flag);
        }

        [Test]
        public void SearchByIdNumber()
        {
            driver.FindElement(By.Id("ShowAdvancedFilters")).Click(); 
            var IdNumber = driver.FindElement(By.Id("IdNumber"));

            Actions actions = new Actions(driver);
            actions.MoveToElement(IdNumber).Click().Build().Perform();

            IdNumber.SendKeys("DATB-768:1");
            driver.FindElement(By.Id("btnSearch")).Click();

            new WebDriverWait(driver, TimeSpan.FromSeconds(60))
              .Until(SeleniumExtras.WaitHelpers.ExpectedConditions
                     .InvisibilityOfElementLocated(By.XPath("/html/body/div[27]/div/i/img")));

            String RealValue = driver.FindElement(By.XPath(".//*[@id='gauges']/table/tbody/tr[2]/td[1]")).Text;
            String expText = "DATB-768:1";
            StringAssert.AreEqualIgnoringCase(expText, RealValue);
        }

        [Test]
        public void SortByIdNumber()
        {
            String valBefore = driver.FindElement(By.XPath(".//*[@id='gauges']/table/tbody/tr[2]/td[1]")).Text;
            driver.FindElement(By.XPath(".//*[@id='gauges']/table/tbody/tr[1]/th[1]/a")).Click();
            new WebDriverWait(driver, TimeSpan.FromSeconds(60))
              .Until(SeleniumExtras.WaitHelpers.ExpectedConditions
                     .InvisibilityOfElementLocated(By.XPath("/html/body/div[27]/div/i/img")));
            String RealText = driver.FindElement(By.XPath(".//*[@id='gauges']/table/tbody/tr[2]/td[1]")).Text;
            StringAssert.AreNotEqualIgnoringCase(valBefore, RealText);
        }

        [Test]
        public void SearchBySerialNumber()
        {
            var showAdvFil = driver.FindElement(By.Id("ShowAdvancedFilters")); showAdvFil.Click(); 
            var serialNumber = driver.FindElement(By.Id("SerialNumber"));
            Actions actions = new Actions(driver);
            actions.MoveToElement(serialNumber).Click().Build().Perform();
            serialNumber.SendKeys("FD:730");
            var btnSearch = driver.FindElement(By.Id("btnSearch")); btnSearch.Click();
            new WebDriverWait(driver, TimeSpan.FromSeconds(60))
              .Until(SeleniumExtras.WaitHelpers.ExpectedConditions
                     .InvisibilityOfElementLocated(By.XPath("/html/body/div[27]/div/i/img")));
            String RealValue = driver.FindElement(By.XPath(".//*[@id='gauges']/table/tbody/tr[2]/td[6]")).Text;
            String expText = "FD:730";
            StringAssert.AreEqualIgnoringCase(expText, RealValue);
        }
        [Test]
        public void SortBySerialNumber()
        {
            var sortBySerialNumber = driver.FindElement(By.XPath(".//*[@id='gauges']/table/tbody/tr[1]/th[6]/a"));
            String valBefore = driver.FindElement(By.XPath(".//*[@id='gauges']/table/tbody/tr[10]/td[1]")).Text;
            sortBySerialNumber.Click();
            new WebDriverWait(driver, TimeSpan.FromSeconds(60))
              .Until(SeleniumExtras.WaitHelpers.ExpectedConditions
                     .InvisibilityOfElementLocated(By.XPath("/html/body/div[27]/div/i/img")));
            String RealText = driver.FindElement(By.XPath(".//*[@id='gauges']/table/tbody/tr[10]/td[1]")).Text;
            StringAssert.AreNotEqualIgnoringCase(valBefore, RealText);
        }

        [Test]
        public void SearchByInventoryNumber()
        {
            driver.FindElement(By.Id("btnColumns")).Click(); 
            new WebDriverWait(driver, TimeSpan.FromSeconds(60))
              .Until(SeleniumExtras.WaitHelpers.ExpectedConditions
                     .InvisibilityOfElementLocated(By.XPath("/html/body/div[27]/div/i/img")));
            driver.FindElement(By.XPath(".//*[@id='li_InventoryNumber']/input[4]")).Click();
            new WebDriverWait(driver, TimeSpan.FromSeconds(60))
              .Until(SeleniumExtras.WaitHelpers.ExpectedConditions
                     .InvisibilityOfElementLocated(By.XPath("/html/body/div[27]/div/i/img")));
            driver.FindElement(By.XPath(".//*[@id='gaugeColumns']/div/div/div[3]/button[1]")).Click();
            new WebDriverWait(driver, TimeSpan.FromSeconds(60))
              .Until(SeleniumExtras.WaitHelpers.ExpectedConditions
                     .InvisibilityOfElementLocated(By.XPath("/html/body/div[27]/div/i/img")));
            var showAdvFil = driver.FindElement(By.Id("ShowAdvancedFilters")); showAdvFil.Click(); 
            var inventoryNumber = driver.FindElement(By.Id("InventoryNumber"));
            Actions actions = new Actions(driver);
            actions.MoveToElement(inventoryNumber).Click().Build().Perform();
            inventoryNumber.SendKeys("Volvo 388");
            var btnSearch = driver.FindElement(By.Id("btnSearch")); btnSearch.Click();
            new WebDriverWait(driver, TimeSpan.FromSeconds(60))
              .Until(SeleniumExtras.WaitHelpers.ExpectedConditions
                     .InvisibilityOfElementLocated(By.XPath("/html/body/div[27]/div/i/img")));
            String RealValue = driver.FindElement(By.XPath(".//*[@id='gauges']/table/tbody/tr[2]/td[9]")).Text;
            String expText = "Volvo 388";
            StringAssert.AreEqualIgnoringCase(expText, RealValue);
        }

        [Test]
        public void SortByInventoryNumber()
        {
            var Columns = driver.FindElement(By.Id("btnColumns"));
            Columns.Click();

            new WebDriverWait(driver, TimeSpan.FromSeconds(60))
              .Until(SeleniumExtras.WaitHelpers.ExpectedConditions
                     .InvisibilityOfElementLocated(By.XPath("/html/body/div[27]/div/i/img")));

            var addColumn = driver.FindElement(By.XPath(".//*[@id='li_InventoryNumber']/input[4]"));
            addColumn.Click(); 
            var SaveBtn = driver.FindElement(By.XPath(".//*[@id='gaugeColumns']/div/div/div[3]/button[1]"));
            SaveBtn.Click();
            new WebDriverWait(driver, TimeSpan.FromSeconds(60))
              .Until(SeleniumExtras.WaitHelpers.ExpectedConditions
                     .InvisibilityOfElementLocated(By.XPath("/html/body/div[27]/div/i/img")));

            var sortByInventoryNumber = driver.FindElement(By.XPath(".//*[@id='gauges']/table/tbody/tr[1]/th[9]/a"));
            String valBefore = driver.FindElement(By.XPath(".//*[@id='gauges']/table/tbody/tr[10]/td[1]")).Text;
            sortByInventoryNumber.Click();
            new WebDriverWait(driver, TimeSpan.FromSeconds(60))
              .Until(SeleniumExtras.WaitHelpers.ExpectedConditions
                     .InvisibilityOfElementLocated(By.XPath("/html/body/div[27]/div/i/img")));
            String RealText = driver.FindElement(By.XPath(".//*[@id='gauges']/table/tbody/tr[10]/td[1]")).Text;
            StringAssert.AreNotEqualIgnoringCase(valBefore, RealText);
        }

        [Test]
        public void SearchByArticle()
        {
            var Columns = driver.FindElement(By.Id("btnColumns"));
            Columns.Click();
            new WebDriverWait(driver, TimeSpan.FromSeconds(60))
              .Until(SeleniumExtras.WaitHelpers.ExpectedConditions
                     .InvisibilityOfElementLocated(By.XPath("/html/body/div[27]/div/i/img")));

            var addColumn = driver.FindElement(By.XPath(".//*[@id='li_Article']/input[4]"));
            addColumn.Click(); 
            var SaveBtn = driver.FindElement(By.XPath(".//*[@id='gaugeColumns']/div/div/div[3]/button[1]"));
            SaveBtn.Click();
            new WebDriverWait(driver, TimeSpan.FromSeconds(60))
              .Until(SeleniumExtras.WaitHelpers.ExpectedConditions
                     .InvisibilityOfElementLocated(By.XPath("/html/body/div[27]/div/i/img")));

            var showAdvFil = driver.FindElement(By.Id("ShowAdvancedFilters")); showAdvFil.Click(); 
            var article = driver.FindElement(By.Id("Article"));

            Actions actions = new Actions(driver);
            actions.MoveToElement(article).Click().Build().Perform();

            article.SendKeys("ZFRE5P200");
            var btnSearch = driver.FindElement(By.Id("btnSearch")); btnSearch.Click();
            new WebDriverWait(driver, TimeSpan.FromSeconds(60))
              .Until(SeleniumExtras.WaitHelpers.ExpectedConditions
                     .InvisibilityOfElementLocated(By.XPath("/html/body/div[27]/div/i/img")));

            String RealValue = driver.FindElement(By.XPath(".//*[@id='gauges']/table/tbody/tr[2]/td[9]")).Text;
            String expText = "ZFRE5P200";
            StringAssert.AreEqualIgnoringCase(expText, RealValue);
        }

        [Test]
        public void SortByArticle()
        {
            var Columns = driver.FindElement(By.Id("btnColumns"));
            Columns.Click();
            new WebDriverWait(driver, TimeSpan.FromSeconds(60))
              .Until(SeleniumExtras.WaitHelpers.ExpectedConditions
                     .InvisibilityOfElementLocated(By.XPath("/html/body/div[27]/div/i/img")));
            var addColumn = driver.FindElement(By.XPath(".//*[@id='li_Article']/input[4]"));
            addColumn.Click(); 
            var SaveBtn = driver.FindElement(By.XPath(".//*[@id='gaugeColumns']/div/div/div[3]/button[1]"));
            SaveBtn.Click();

            new WebDriverWait(driver, TimeSpan.FromSeconds(60))
              .Until(SeleniumExtras.WaitHelpers.ExpectedConditions
                     .InvisibilityOfElementLocated(By.XPath("/html/body/div[27]/div/i/img")));

            var sortByArticle = driver.FindElement(By.XPath(".//*[@id='gauges']/table/tbody/tr[1]/th[9]/a"));
            String valBefore = driver.FindElement(By.XPath(".//*[@id='gauges']/table/tbody/tr[10]/td[1]")).Text;
            sortByArticle.Click();
            new WebDriverWait(driver, TimeSpan.FromSeconds(60))
              .Until(SeleniumExtras.WaitHelpers.ExpectedConditions
                     .InvisibilityOfElementLocated(By.XPath("/html/body/div[27]/div/i/img")));
            String RealText = driver.FindElement(By.XPath(".//*[@id='gauges']/table/tbody/tr[10]/td[1]")).Text;
            StringAssert.AreNotEqualIgnoringCase(valBefore, RealText);
        }

        [Test]
        public void SearchByManufacturer()
        {
            var Columns = driver.FindElement(By.Id("btnColumns"));
            Columns.Click();
            new WebDriverWait(driver, TimeSpan.FromSeconds(60))
              .Until(SeleniumExtras.WaitHelpers.ExpectedConditions
                     .InvisibilityOfElementLocated(By.XPath("/html/body/div[27]/div/i/img")));
            var addColumn = driver.FindElement(By.XPath(".//*[@id='li_Manufacturer']/input[4]"));
            addColumn.Click(); 
            var SaveBtn = driver.FindElement(By.XPath(".//*[@id='gaugeColumns']/div/div/div[3]/button[1]"));
            SaveBtn.Click();
            new WebDriverWait(driver, TimeSpan.FromSeconds(60))
              .Until(SeleniumExtras.WaitHelpers.ExpectedConditions
                     .InvisibilityOfElementLocated(By.XPath("/html/body/div[27]/div/i/img")));

            var showAdvFil = driver.FindElement(By.Id("ShowAdvancedFilters")); showAdvFil.Click(); 
            var Manufacturer = driver.FindElement(By.Id("Manufacturer"));

            Actions actions = new Actions(driver);
            actions.MoveToElement(Manufacturer).Click().Build().Perform();

            Manufacturer.SendKeys("EGET");
            var btnSearch = driver.FindElement(By.Id("btnSearch")); btnSearch.Click();
            new WebDriverWait(driver, TimeSpan.FromSeconds(60))
              .Until(SeleniumExtras.WaitHelpers.ExpectedConditions
                     .InvisibilityOfElementLocated(By.XPath("/html/body/div[27]/div/i/img")));

            String RealValue = driver.FindElement(By.XPath(".//*[@id='gauges']/table/tbody/tr[2]/td[9]")).Text;
            String expText = "EGET";
            StringAssert.AreEqualIgnoringCase(expText, RealValue);
        }

        [Test]
        public void SortByManufacturer()
        {
            var Columns = driver.FindElement(By.Id("btnColumns"));
            Columns.Click();
            new WebDriverWait(driver, TimeSpan.FromSeconds(60))
              .Until(SeleniumExtras.WaitHelpers.ExpectedConditions
                     .InvisibilityOfElementLocated(By.XPath("/html/body/div[27]/div/i/img")));
            var addColumn = driver.FindElement(By.XPath(".//*[@id='li_Manufacturer']/input[4]"));
            addColumn.Click(); 
            var SaveBtn = driver.FindElement(By.XPath(".//*[@id='gaugeColumns']/div/div/div[3]/button[1]"));
            SaveBtn.Click();
            new WebDriverWait(driver, TimeSpan.FromSeconds(60))
              .Until(SeleniumExtras.WaitHelpers.ExpectedConditions
                     .InvisibilityOfElementLocated(By.XPath("/html/body/div[27]/div/i/img")));
            var sortByManufacturer = driver.FindElement(By.XPath(".//*[@id='gauges']/table/tbody/tr[1]/th[9]/a"));
            String valBefore = driver.FindElement(By.XPath(".//*[@id='gauges']/table/tbody/tr[10]/td[1]")).Text;
            sortByManufacturer.Click();
            new WebDriverWait(driver, TimeSpan.FromSeconds(60))
              .Until(SeleniumExtras.WaitHelpers.ExpectedConditions
                     .InvisibilityOfElementLocated(By.XPath("/html/body/div[27]/div/i/img")));
            String RealText = driver.FindElement(By.XPath(".//*[@id='gauges']/table/tbody/tr[10]/td[1]")).Text;
            StringAssert.AreNotEqualIgnoringCase(valBefore, RealText);
        }

        [Test]
        public void SearchByDenomination()
        {
            var Columns = driver.FindElement(By.Id("btnColumns"));
            Columns.Click();
            new WebDriverWait(driver, TimeSpan.FromSeconds(60))
              .Until(SeleniumExtras.WaitHelpers.ExpectedConditions
                     .InvisibilityOfElementLocated(By.XPath("/html/body/div[27]/div/i/img")));
            var addColumn = driver.FindElement(By.XPath(".//*[@id='li_Denomination']/input[4]"));
            addColumn.Click(); 
            var SaveBtn = driver.FindElement(By.XPath(".//*[@id='gaugeColumns']/div/div/div[3]/button[1]"));
            SaveBtn.Click();
            new WebDriverWait(driver, TimeSpan.FromSeconds(60))
              .Until(SeleniumExtras.WaitHelpers.ExpectedConditions
                     .InvisibilityOfElementLocated(By.XPath("/html/body/div[27]/div/i/img")));

            var showAdvFil = driver.FindElement(By.Id("ShowAdvancedFilters")); showAdvFil.Click(); Thread.Sleep(500);
            var Denomination = driver.FindElement(By.Id("Denomination"));

            Actions actions = new Actions(driver);
            actions.MoveToElement(Denomination).Click().Build().Perform();

            Denomination.SendKeys("Töjningsgivare preparerad");
            var btnSearch = driver.FindElement(By.Id("btnSearch")); btnSearch.Click();
            new WebDriverWait(driver, TimeSpan.FromSeconds(60))
              .Until(SeleniumExtras.WaitHelpers.ExpectedConditions
                     .InvisibilityOfElementLocated(By.XPath("/html/body/div[27]/div/i/img")));

            String RealValue = driver.FindElement(By.XPath(".//*[@id='gauges']/table/tbody/tr[2]/td[9]")).Text;
            String expText = "Töjningsgivare preparerad";
            StringAssert.AreEqualIgnoringCase(expText, RealValue);
        }

        [Test]
        public void SortByDenomination()
        {
            var Columns = driver.FindElement(By.Id("btnColumns"));
            Columns.Click();
            new WebDriverWait(driver, TimeSpan.FromSeconds(60))
              .Until(SeleniumExtras.WaitHelpers.ExpectedConditions
                     .InvisibilityOfElementLocated(By.XPath("/html/body/div[27]/div/i/img")));
            var addColumn = driver.FindElement(By.XPath(".//*[@id='li_Denomination']/input[4]"));
            addColumn.Click(); 
            var SaveBtn = driver.FindElement(By.XPath(".//*[@id='gaugeColumns']/div/div/div[3]/button[1]"));
            SaveBtn.Click();
            new WebDriverWait(driver, TimeSpan.FromSeconds(60))
              .Until(SeleniumExtras.WaitHelpers.ExpectedConditions
                     .InvisibilityOfElementLocated(By.XPath("/html/body/div[27]/div/i/img")));

            var sortByDenomination = driver.FindElement(By.XPath(".//*[@id='gauges']/table/tbody/tr[1]/th[9]/a"));
            String valBefore = driver.FindElement(By.XPath(".//*[@id='gauges']/table/tbody/tr[10]/td[1]")).Text;
            sortByDenomination.Click();
            new WebDriverWait(driver, TimeSpan.FromSeconds(60))
              .Until(SeleniumExtras.WaitHelpers.ExpectedConditions
                     .InvisibilityOfElementLocated(By.XPath("/html/body/div[27]/div/i/img")));
            String RealText = driver.FindElement(By.XPath(".//*[@id='gauges']/table/tbody/tr[10]/td[1]")).Text;
            StringAssert.AreNotEqualIgnoringCase(valBefore, RealText);
        }

        [Test]
        public void SearchByUserName()
        {
            var Columns = driver.FindElement(By.Id("btnColumns"));
            Columns.Click();

            new WebDriverWait(driver, TimeSpan.FromSeconds(60))
              .Until(SeleniumExtras.WaitHelpers.ExpectedConditions
                     .InvisibilityOfElementLocated(By.XPath("/html/body/div[27]/div/i/img")));
            var addColumn = driver.FindElement(By.XPath(".//*[@id='li_UserName']/input[4]"));
            addColumn.Click();
            var SaveBtn = driver.FindElement(By.XPath(".//*[@id='gaugeColumns']/div/div/div[3]/button[1]"));
            SaveBtn.Click();

            new WebDriverWait(driver, TimeSpan.FromSeconds(60))
              .Until(SeleniumExtras.WaitHelpers.ExpectedConditions
                     .InvisibilityOfElementLocated(By.XPath("/html/body/div[27]/div/i/img")));

            var showAdvFil = driver.FindElement(By.Id("ShowAdvancedFilters")); showAdvFil.Click(); 
            var UserName = driver.FindElement(By.Id("UserName"));

            Actions actions = new Actions(driver);
            actions.MoveToElement(UserName).Click().Build().Perform();


            UserName.SendKeys("x skalan skadad, visar 0.4  fel.");
            var btnSearch = driver.FindElement(By.Id("btnSearch")); btnSearch.Click();

            new WebDriverWait(driver, TimeSpan.FromSeconds(60))
              .Until(SeleniumExtras.WaitHelpers.ExpectedConditions
                     .InvisibilityOfElementLocated(By.XPath("/html/body/div[27]/div/i/img")));

            String RealValue = driver.FindElement(By.XPath(".//*[@id='gauges']/table/tbody/tr[2]/td[9]")).Text;
            String expText = "x skalan skadad, visar 0.4  fel.";
            StringAssert.AreEqualIgnoringCase(expText, RealValue);
        }

        [Test]
        public void SortByUserName()
        {
            var Columns = driver.FindElement(By.Id("btnColumns"));
            Columns.Click();
            new WebDriverWait(driver, TimeSpan.FromSeconds(60))
              .Until(SeleniumExtras.WaitHelpers.ExpectedConditions
                     .InvisibilityOfElementLocated(By.XPath("/html/body/div[27]/div/i/img")));
            var addColumn = driver.FindElement(By.XPath(".//*[@id='li_UserName']/input[4]"));
            addColumn.Click();
            var SaveBtn = driver.FindElement(By.XPath(".//*[@id='gaugeColumns']/div/div/div[3]/button[1]"));
            SaveBtn.Click();
            new WebDriverWait(driver, TimeSpan.FromSeconds(60))
              .Until(SeleniumExtras.WaitHelpers.ExpectedConditions
                     .InvisibilityOfElementLocated(By.XPath("/html/body/div[27]/div/i/img")));

            var sortByUserName = driver.FindElement(By.XPath(".//*[@id='gauges']/table/tbody/tr[1]/th[9]/a"));
            String valBefore = driver.FindElement(By.XPath(".//*[@id='gauges']/table/tbody/tr[10]/td[1]")).Text;

            sortByUserName.Click();
            new WebDriverWait(driver, TimeSpan.FromSeconds(60))
              .Until(SeleniumExtras.WaitHelpers.ExpectedConditions
                     .InvisibilityOfElementLocated(By.XPath("/html/body/div[27]/div/i/img")));

            String RealText = driver.FindElement(By.XPath(".//*[@id='gauges']/table/tbody/tr[10]/td[1]")).Text;
            StringAssert.AreNotEqualIgnoringCase(valBefore, RealText);
        }

        [Test]
        public void SearchByLocation()
        {
            var showAdvFil = driver.FindElement(By.Id("ShowAdvancedFilters")); 
            showAdvFil.Click();
            var location = driver.FindElement(By.Id("Location"));

            Actions actions = new Actions(driver);
            actions.MoveToElement(location).Click().Build().Perform();
                
            location.SendKeys("92430-UTL-PV14");
            var btnSearch = driver.FindElement(By.Id("btnSearch"));
            btnSearch.Click();

            new WebDriverWait(driver, TimeSpan.FromSeconds(60))
              .Until(SeleniumExtras.WaitHelpers.ExpectedConditions
                     .InvisibilityOfElementLocated(By.XPath("/html/body/div[27]/div/i/img")));
            String RealValue = driver.FindElement(By.XPath(".//*[@id='gauges']/table/tbody/tr[2]/td[2]")).Text;
            String expText = "92430-UTL-PV14";
            StringAssert.AreEqualIgnoringCase(expText, RealValue);
        }

        [Test]
        public void SortByLocation()
        {
            var sortByLocation = driver.FindElement(By.XPath(".//*[@id='gauges']/table/tbody/tr[1]/th[2]/a"));
            String valBefore = driver.FindElement(By.XPath(".//*[@id='gauges']/table/tbody/tr[10]/td[1]")).Text;
            sortByLocation.Click();
            new WebDriverWait(driver, TimeSpan.FromSeconds(60))
              .Until(SeleniumExtras.WaitHelpers.ExpectedConditions
                     .InvisibilityOfElementLocated(By.XPath("/html/body/div[27]/div/i/img")));
            String RealText = driver.FindElement(By.XPath(".//*[@id='gauges']/table/tbody/tr[10]/td[1]")).Text;
            StringAssert.AreNotEqualIgnoringCase(valBefore, RealText);
        }

        [Test]
        public void SearchByBorrower()
        {
            var Columns = driver.FindElement(By.Id("btnColumns"));
            Columns.Click();
            new WebDriverWait(driver, TimeSpan.FromSeconds(60))
              .Until(SeleniumExtras.WaitHelpers.ExpectedConditions
                     .InvisibilityOfElementLocated(By.XPath("/html/body/div[27]/div/i/img"))); 
            var addColumn = driver.FindElement(By.XPath(".//*[@id='li_Borrower']/input[4]"));
            addColumn.Click(); 
            var SaveBtn = driver.FindElement(By.XPath(".//*[@id='gaugeColumns']/div/div/div[3]/button[1]"));
            SaveBtn.Click();
            new WebDriverWait(driver, TimeSpan.FromSeconds(60))
              .Until(SeleniumExtras.WaitHelpers.ExpectedConditions
                     .InvisibilityOfElementLocated(By.XPath("/html/body/div[27]/div/i/img")));

            var showAdvFil = driver.FindElement(By.Id("ShowAdvancedFilters"));
            showAdvFil.Click();
            var borrower = driver.FindElement(By.Id("Borrower"));

            Actions actions = new Actions(driver);
            actions.MoveToElement(borrower).Click().Build().Perform();

            borrower.SendKeys("Bo Wilhelmsson");
            var btnSearch = driver.FindElement(By.Id("btnSearch"));
            btnSearch.Click();
            new WebDriverWait(driver, TimeSpan.FromSeconds(80))
              .Until(SeleniumExtras.WaitHelpers.ExpectedConditions
                     .InvisibilityOfElementLocated(By.XPath("/html/body/div[27]/div/i/img")));
            String RealValue = driver.FindElement(By.XPath(".//*[@id='gauges']/table/tbody/tr[2]/td[9]")).Text;
            String expText = "Bo Wilhelmsson";
            StringAssert.AreEqualIgnoringCase(expText, RealValue);
        }

        [Test]
        public void SortByBorrower()
        {
            var Columns = driver.FindElement(By.Id("btnColumns"));
            Columns.Click();
            new WebDriverWait(driver, TimeSpan.FromSeconds(80))
              .Until(SeleniumExtras.WaitHelpers.ExpectedConditions
                     .InvisibilityOfElementLocated(By.XPath("/html/body/div[27]/div/i/img")));
            var addColumn = driver.FindElement(By.XPath(".//*[@id='li_Borrower']/input[4]"));
            addColumn.Click();
            new WebDriverWait(driver, TimeSpan.FromSeconds(80))
              .Until(SeleniumExtras.WaitHelpers.ExpectedConditions
                     .InvisibilityOfElementLocated(By.XPath("/html/body/div[27]/div/i/img")));
            var SaveBtn = driver.FindElement(By.XPath(".//*[@id='gaugeColumns']/div/div/div[3]/button[1]"));
            SaveBtn.Click();
            new WebDriverWait(driver, TimeSpan.FromSeconds(80))
              .Until(SeleniumExtras.WaitHelpers.ExpectedConditions
                     .InvisibilityOfElementLocated(By.XPath("/html/body/div[27]/div/i/img")));

            var sortByBorrower = driver.FindElement(By.XPath(".//*[@id='gauges']/table/tbody/tr[1]/th[9]/a"));
            String valBefore = driver.FindElement(By.XPath(".//*[@id='gauges']/table/tbody/tr[10]/td[1]")).Text;
            sortByBorrower.Click();
            new WebDriverWait(driver, TimeSpan.FromSeconds(80))
              .Until(SeleniumExtras.WaitHelpers.ExpectedConditions
                     .InvisibilityOfElementLocated(By.XPath("/html/body/div[27]/div/i/img")));
            String RealText = driver.FindElement(By.XPath(".//*[@id='gauges']/table/tbody/tr[10]/td[1]")).Text;
            StringAssert.AreNotEqualIgnoringCase(valBefore, RealText);
        }

        [Test]
        public void SearchByBorrowerNumber()
        {
            var Columns = driver.FindElement(By.Id("btnColumns"));
            Columns.Click();
            new WebDriverWait(driver, TimeSpan.FromSeconds(80))
              .Until(SeleniumExtras.WaitHelpers.ExpectedConditions
                     .InvisibilityOfElementLocated(By.XPath("/html/body/div[27]/div/i/img")));
            var addColumn = driver.FindElement(By.XPath(".//*[@id='li_BorrowerNumber']/input[4]"));
            addColumn.Click();
            var SaveBtn = driver.FindElement(By.XPath(".//*[@id='gaugeColumns']/div/div/div[3]/button[1]"));
            SaveBtn.Click();
            new WebDriverWait(driver, TimeSpan.FromSeconds(80))
              .Until(SeleniumExtras.WaitHelpers.ExpectedConditions
                     .InvisibilityOfElementLocated(By.XPath("/html/body/div[27]/div/i/img")));

            var showAdvFil = driver.FindElement(By.Id("ShowAdvancedFilters"));
            showAdvFil.Click();
            var borrowerNum = driver.FindElement(By.Id("BorrowerNumber"));

            Actions actions = new Actions(driver);
            actions.MoveToElement(borrowerNum).Click().Build().Perform();

            borrowerNum.SendKeys("");
            var btnSearch = driver.FindElement(By.Id("btnSearch"));
            btnSearch.Click();
            new WebDriverWait(driver, TimeSpan.FromSeconds(80))
              .Until(SeleniumExtras.WaitHelpers.ExpectedConditions
                     .InvisibilityOfElementLocated(By.XPath("/html/body/div[27]/div/i/img")));
            String RealValue = driver.FindElement(By.XPath(".//*[@id='gauges']/table/tbody/tr[2]/td[9]")).Text;
            String expText = "";
            StringAssert.AreEqualIgnoringCase(expText, RealValue);
        }

        [Test]
        public void SortByBorrowerNumber()
        {
            var Columns = driver.FindElement(By.Id("btnColumns"));
            Columns.Click(); 
            new WebDriverWait(driver, TimeSpan.FromSeconds(80))
              .Until(SeleniumExtras.WaitHelpers.ExpectedConditions
                     .InvisibilityOfElementLocated(By.XPath("/html/body/div[27]/div/i/img")));
            var addColumn = driver.FindElement(By.XPath(".//*[@id='li_BorrowerNumber']/input[4]"));
            addColumn.Click();
            new WebDriverWait(driver, TimeSpan.FromSeconds(80))
              .Until(SeleniumExtras.WaitHelpers.ExpectedConditions
                     .InvisibilityOfElementLocated(By.XPath("/html/body/div[27]/div/i/img")));
            var SaveBtn = driver.FindElement(By.XPath(".//*[@id='gaugeColumns']/div/div/div[3]/button[1]"));
            SaveBtn.Click();
            new WebDriverWait(driver, TimeSpan.FromSeconds(80))
              .Until(SeleniumExtras.WaitHelpers.ExpectedConditions
                     .InvisibilityOfElementLocated(By.XPath("/html/body/div[27]/div/i/img")));

            var sortByBorrower = driver.FindElement(By.XPath(".//*[@id='gauges']/table/tbody/tr[1]/th[9]/a"));
            String valBefore = driver.FindElement(By.XPath(".//*[@id='gauges']/table/tbody/tr[10]/td[1]")).Text;
            sortByBorrower.Click();
            new WebDriverWait(driver, TimeSpan.FromSeconds(80))
              .Until(SeleniumExtras.WaitHelpers.ExpectedConditions
                     .InvisibilityOfElementLocated(By.XPath("/html/body/div[27]/div/i/img")));
            String RealText = driver.FindElement(By.XPath(".//*[@id='gauges']/table/tbody/tr[10]/td[1]")).Text;
            StringAssert.AreNotEqualIgnoringCase(valBefore, RealText);
        }
        [TearDown]
        public void Finish()
        {   
            driver.Quit();
        }
    }

}
