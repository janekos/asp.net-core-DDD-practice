using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace ddd_asp_practice.Tests.UI {
    [TestClass]
    public class EditingTests {

        private IWebDriver driver = new ChromeDriver();
        private string url = "http://localhost:59356/";

        [TestMethod]
        public void CheckEditingPersonWorks() {
            driver.Navigate().GoToUrl(url);

            var partyTableEntries = driver.FindElement(By.Id("comingParties")).FindElement(By.TagName("tbody"));
            var firstPartyTableRow = partyTableEntries.FindElements(By.TagName("tr"))[0];
            var firstPartyRowColumns = firstPartyTableRow.FindElements(By.TagName("td"));

            if (firstPartyRowColumns.Count < 2) { Assert.Inconclusive(); }

            firstPartyRowColumns[0].Click();

            var personTable = driver.FindElement(By.Id("participatingPersons")).FindElement(By.TagName("tbody"));
            var firstPersonTableRow = personTable.FindElements(By.TagName("tr"))[0];
            var firstPersonRowColumns = firstPersonTableRow.FindElements(By.TagName("td"));

            if (firstPersonRowColumns.Count < 2) { Assert.Inconclusive(); }
            
            firstPersonRowColumns[5].Click();

            Assert.IsTrue(driver.Url.Contains(url + "Party/EditPersonPartyGoer"));

            var name = driver.FindElements(By.TagName("input"))[0];

            name.SendKeys("editPersonAdd");

            driver.FindElements(By.TagName("button"))[0].Click();
            Assert.IsTrue(driver.Url.Contains(url + "Party/PartyGoers"));
        }

        [TestMethod]
        public void CheckEditingFirmWorks() {
            driver.Navigate().GoToUrl(url);

            var partyTableEntries = driver.FindElement(By.Id("comingParties")).FindElement(By.TagName("tbody"));
            var firstPartyTableRow = partyTableEntries.FindElements(By.TagName("tr"))[0];
            var firstPartyRowColumns = firstPartyTableRow.FindElements(By.TagName("td"));

            if (firstPartyRowColumns.Count < 2) { Assert.Inconclusive(); }

            firstPartyRowColumns[0].Click();

            var personTable = driver.FindElement(By.Id("participatingFirms")).FindElement(By.TagName("tbody"));
            var firstPersonTableRow = personTable.FindElements(By.TagName("tr"))[0];
            var firstPersonRowColumns = firstPersonTableRow.FindElements(By.TagName("td"));

            if (firstPersonRowColumns.Count < 2) { Assert.Inconclusive(); }

            firstPersonRowColumns[5].Click();

            Assert.IsTrue(driver.Url.Contains(url + "Party/EditFirmPartyGoer"));

            var name = driver.FindElements(By.TagName("input"))[0];

            name.SendKeys("editFirmAdd");

            driver.FindElements(By.TagName("button"))[0].Click();
            Assert.IsTrue(driver.Url.Contains(url + "Party/PartyGoers"));
        }

        [TestCleanup()]
        public void IndexTestCleanup() {
            driver.Quit();
        }
    }
}
