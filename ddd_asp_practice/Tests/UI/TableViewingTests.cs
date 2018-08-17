using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.IE;

namespace ddd_asp_practice.Tests.UI {
    [TestClass]
    public class TableViewingTests {
        private IWebDriver driver = new ChromeDriver();

        private string url = "http://localhost:59356/";

        [TestMethod]
        public void CheckIndexForContainingCorrectTables() {
            driver.Navigate().GoToUrl(url);

            var comingTableEntries = driver.FindElement(By.Id("comingParties")).FindElement(By.TagName("tbody"));
            var firstComingRow = comingTableEntries.FindElements(By.TagName("tr"))[0];
            Assert.IsNotNull(firstComingRow);

            var prevTableEntries = driver.FindElement(By.Id("prevParties")).FindElement(By.TagName("tbody"));
            var firstPrevRow = comingTableEntries.FindElements(By.TagName("tr"))[0];
            Assert.IsNotNull(firstPrevRow);
        }

        [TestMethod]
        public void CheckPartyGoersForContainingCorrectTables() {
            driver.Navigate().GoToUrl(url);
            var tableEntries = driver.FindElement(By.Id("comingParties")).FindElement(By.TagName("tbody"));
            var firstTableRow = tableEntries.FindElements(By.TagName("tr"))[0];
            firstTableRow.FindElements(By.TagName("td"))[0].Click();

            var personTable = driver.FindElement(By.Id("participatingPersons"));
            Assert.IsNotNull(personTable.FindElement(By.TagName("tbody")).FindElements(By.TagName("tr"))[0]);

            var firmTable = driver.FindElement(By.Id("participatingFirms"));
            Assert.IsNotNull(firmTable.FindElement(By.TagName("tbody")).FindElements(By.TagName("tr"))[0]);

        }

        [TestCleanup()]
        public void IndexTestCleanup() {
            driver.Quit();
        }
    }
}
