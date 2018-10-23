using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using NUnit.Framework;
using System.Threading;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium.Interactions;

namespace Tabs
{
    class Person
    {
        IWebDriver driver;

        public static string BaseUrl = "http://Shvo:Alphredwhite98@axaxctest01/axcweb/Account";
        public static string LoggedInPageTitle = "http://Shvo:Alphredwhite98@axaxctest01/axcweb/Person";
        
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
        public void SearchByEmploymentNumber()
        {          
            driver.FindElement(By.Id("ShowAdvancedFilters")).Click();   
            var EmploymentNumber = driver.FindElement(By.Id("EmploymentNumber"));
           
            Actions actions = new Actions(driver);
            actions.MoveToElement(EmploymentNumber).Click().Build().Perform();            

            EmploymentNumber.SendKeys("E10000");
            driver.FindElement(By.Id("btnSearch")).Click();
            new WebDriverWait(driver, TimeSpan.FromSeconds(60))
                .Until(SeleniumExtras.WaitHelpers
                      .ExpectedConditions.InvisibilityOfElementLocated(By.XPath("/html/body/div[2]/div/i/img")));

            String RealText = driver.FindElement(By.XPath(".//*[@id='persons']/table/tbody/tr[2]/td[1]")).Text;
            String expText = "E10000";
            Assert.AreEqual(expText, RealText);            
        }

        [Test]
        public void SearchByLastName()
        {
            driver.FindElement(By.Id("ShowAdvancedFilters")).Click();
            var LastName = driver.FindElement(By.Id("LastName"));

            Actions actions = new Actions(driver);
            actions.MoveToElement(LastName).Click().Build().Perform();

            LastName.SendKeys("L10000");
            driver.FindElement(By.Id("btnSearch")).Click();

            new WebDriverWait(driver, TimeSpan.FromSeconds(60))
                .Until(SeleniumExtras.WaitHelpers
                      .ExpectedConditions.InvisibilityOfElementLocated(By.XPath("/html/body/div[2]/div/i/img")));

            String RealText = driver.FindElement(By.XPath(".//*[@id='persons']/table/tbody/tr[2]/td[2]")).Text;            
            String expText = "L10000";
            StringAssert.AreEqualIgnoringCase(expText, RealText);
        }

        [Test]
        public void SearchByFirstName()
        {
            driver.FindElement(By.Id("ShowAdvancedFilters")).Click();
            var FirstName = driver.FindElement(By.Id("FirstName"));

            Actions actions = new Actions(driver);
            actions.MoveToElement(FirstName).Click().Build().Perform();
            Thread.Sleep(1000);

            FirstName.SendKeys("F10000");
            driver.FindElement(By.Id("btnSearch")).Click();

            new WebDriverWait(driver, TimeSpan.FromSeconds(60))
            .Until(SeleniumExtras.WaitHelpers
                .ExpectedConditions.InvisibilityOfElementLocated(By.XPath("/html/body/div[2]/div/i/img")));

            String RealText = driver.FindElement(By.XPath(".//*[@id='persons']/table/tbody/tr[2]/td[3]")).Text;
            String expText = "F10000";
            StringAssert.AreEqualIgnoringCase(expText, RealText);
        }

        [Test]
        public void SearchByTelephone()
        {
            driver.FindElement(By.Id("ShowAdvancedFilters")).Click();
            var Telephone = driver.FindElement(By.Id("Telephone"));

            Actions actions = new Actions(driver);
            actions.MoveToElement(Telephone).Click().Build().Perform();

            Telephone.SendKeys("46 36 33 20 600");
            driver.FindElement(By.Id("btnSearch")).Click();

            new WebDriverWait(driver, TimeSpan.FromSeconds(60))
            .Until(SeleniumExtras.WaitHelpers
                .ExpectedConditions.InvisibilityOfElementLocated(By.XPath("/html/body/div[2]/div/i/img")));

            String RealText = driver.FindElement(By.XPath(".//*[@id='persons']/table/tbody/tr[2]/td[4]")).Text;
            String expText = "46 36 33 20 600";
            StringAssert.AreEqualIgnoringCase(expText, RealText);
        }

        [Test]
        public void SearchByEmail()
        {
            driver.FindElement(By.Id("ShowAdvancedFilters")).Click();
            var Email = driver.FindElement(By.Id("Email"));

            Actions actions = new Actions(driver);
            actions.MoveToElement(Email).Click().Build().Perform();

            Email.SendKeys("homi@axxos.com");
            driver.FindElement(By.Id("btnSearch")).Click();

            new WebDriverWait(driver, TimeSpan.FromSeconds(60))
            .Until(SeleniumExtras.WaitHelpers
              .ExpectedConditions.InvisibilityOfElementLocated(By.XPath("/html/body/div[2]/div/i/img")));

            String RealText = driver.FindElement(By.XPath(".//*[@id='persons']/table/tbody/tr[2]/td[5]")).Text;
            String expText = "homi@axxos.com";
            StringAssert.AreEqualIgnoringCase(expText, RealText);
        }

        [Test]
        public void SortByEmploymentNumber()
        {       
            var sortByEmplNumFirst = driver.FindElement(By.XPath(".//*[@id='persons']/table/tbody/tr[1]/th[1]/a"));            
            String valBefore = driver.FindElement(By.XPath(".//*[@id='persons']/table/tbody/tr[3]/td[1]")).Text;            
            sortByEmplNumFirst.Click();
            new WebDriverWait(driver, TimeSpan.FromSeconds(60))
            .Until(SeleniumExtras.WaitHelpers
            .ExpectedConditions.InvisibilityOfElementLocated(By.XPath("/html/body/div[2]/div/i/img")));
            String RealText = driver.FindElement(By.XPath(".//*[@id='persons']/table/tbody/tr[3]/td[1]")).Text;            
            StringAssert.AreNotEqualIgnoringCase(valBefore, RealText);
        }

        [Test]
        public void SortByLastName()
        {
            var sortByLastName = driver.FindElement(By.XPath(".//*[@id='persons']/table/tbody/tr[1]/th[2]/a"));
            String valBefore = driver.FindElement(By.XPath(".//*[@id='persons']/table/tbody/tr[3]/td[2]")).Text;
            sortByLastName.Click();
            new WebDriverWait(driver, TimeSpan.FromSeconds(60))
            .Until(SeleniumExtras.WaitHelpers
            .ExpectedConditions.InvisibilityOfElementLocated(By.XPath("/html/body/div[2]/div/i/img")));
            String RealText = driver.FindElement(By.XPath(".//*[@id='persons']/table/tbody/tr[3]/td[2]")).Text;
            StringAssert.AreNotEqualIgnoringCase(valBefore, RealText);
        }

        [Test]
        public void SortByFirstName()
        {
            var sortByFirstName = driver.FindElement(By.XPath(".//*[@id='persons']/table/tbody/tr[1]/th[3]/a"));
            String valBefore = driver.FindElement(By.XPath(".//*[@id='persons']/table/tbody/tr[3]/td[3]")).Text;
            sortByFirstName.Click();
            new WebDriverWait(driver, TimeSpan.FromSeconds(60))
            .Until(SeleniumExtras.WaitHelpers
            .ExpectedConditions.InvisibilityOfElementLocated(By.XPath("/html/body/div[2]/div/i/img")));
            String RealText = driver.FindElement(By.XPath(".//*[@id='persons']/table/tbody/tr[3]/td[3]")).Text;
            StringAssert.AreNotEqualIgnoringCase(valBefore, RealText);
        }
        [Test]
        public void SortByTelephone()
        {
            var sortByTelephone = driver.FindElement(By.XPath(".//*[@id='persons']/table/tbody/tr[1]/th[4]/a"));
            String valBefore = driver.FindElement(By.XPath(".//*[@id='persons']/table/tbody/tr[3]/td[4]")).Text;
            sortByTelephone.Click();
            new WebDriverWait(driver, TimeSpan.FromSeconds(60))
            .Until(SeleniumExtras.WaitHelpers
            .ExpectedConditions.InvisibilityOfElementLocated(By.XPath("/html/body/div[2]/div/i/img")));
            String RealText = driver.FindElement(By.XPath(".//*[@id='persons']/table/tbody/tr[3]/td[4]")).Text;
            StringAssert.AreNotEqualIgnoringCase(valBefore, RealText);
        }

        [Test]
        public void SortByEmal()
        {
            var sortByEmal = driver.FindElement(By.XPath(".//*[@id='persons']/table/tbody/tr[1]/th[5]/a"));
            String valBefore = driver.FindElement(By.XPath(".//*[@id='persons']/table/tbody/tr[3]/td[5]")).Text;
            sortByEmal.Click();
            new WebDriverWait(driver, TimeSpan.FromSeconds(60))
            .Until(SeleniumExtras.WaitHelpers
            .ExpectedConditions.InvisibilityOfElementLocated(By.XPath("/html/body/div[2]/div/i/img")));
            String RealText = driver.FindElement(By.XPath(".//*[@id='persons']/table/tbody/tr[3]/td[5]")).Text;
            StringAssert.AreNotEqualIgnoringCase(valBefore, RealText);
        }

        [TearDown]
        public void Finish()
        {
            driver.Close();
        }            
    }
}
