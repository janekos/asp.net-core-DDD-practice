using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;

namespace ddd_asp_practice.Tests.UI {
    [TestClass]
    public class AddingTests {
        private IWebDriver driver = new ChromeDriver();
        private string url = "http://localhost:59356/";

        [TestMethod]
        public void CheckAddingPartyWorks() {
            driver.Navigate().GoToUrl(url);
            driver.FindElement(By.Id("addPartyButton")).Click();

            var inputs = driver.FindElements(By.TagName("input"));
            var textarea = driver.FindElement(By.TagName("textarea"));

            inputs[0].SendKeys("testParty");
            inputs[1].SendKeys(Keys.Tab);
            inputs[1].SendKeys(Keys.Tab);
            inputs[1].SendKeys("2019");
            inputs[2].SendKeys("testLocation");
            textarea.SendKeys("extraInfo");

            driver.FindElement(By.Id("submitPartyForm")).Click();
            Assert.IsTrue(driver.Url.Equals(url));
        }

        [TestMethod]
        public void CheckAddingPersonWorks() {
            driver.Navigate().GoToUrl(url);

            var tableEntries = driver.FindElement(By.Id("comingParties")).FindElement(By.TagName("tbody"));
            var firstTableRow = tableEntries.FindElements(By.TagName("tr"))[0];
            var firstRowColumns = firstTableRow.FindElements(By.TagName("td"));

            if (firstRowColumns.Count < 2) { Assert.Inconclusive();}

            firstRowColumns[4].Click();

            Assert.IsTrue(driver.Url.Contains(url + "Party/AddPersonPartyGoer"));

            var inputs = driver.FindElements(By.TagName("input"));
            var textarea = driver.FindElement(By.TagName("textarea"));

            inputs[0].SendKeys("testPersonName");
            inputs[1].SendKeys("testPersonSurname");
            inputs[2].SendKeys("99999999998");
            textarea.SendKeys("extraInfo");

            driver.FindElements(By.TagName("button"))[0].Click();
            Console.WriteLine(driver.Url);
            Assert.IsTrue(driver.Url.Equals(url));
        }

        [TestMethod]
        public void CheckAddingFirmWorks() {
            driver.Navigate().GoToUrl(url);

            var tableEntries = driver.FindElement(By.Id("comingParties")).FindElement(By.TagName("tbody"));
            var firstTableRow = tableEntries.FindElements(By.TagName("tr"))[0];
            var firstRowColumns = firstTableRow.FindElements(By.TagName("td"));

            if (firstRowColumns.Count < 2) { Assert.Inconclusive(); }

            firstRowColumns[4].Click();

            Assert.IsTrue(driver.Url.Contains(url + "Party/AddPersonPartyGoer"));

            var goerTypeSelect = new SelectElement(driver.FindElement(By.Id("goerType")));
            goerTypeSelect.SelectByText("Ettevõte");

            var inputs = driver.FindElements(By.TagName("input"));
            var textarea = driver.FindElement(By.TagName("textarea"));

            inputs[0].SendKeys("testPersonName");
            inputs[1].SendKeys("999999999");
            inputs[2].SendKeys("10");
            textarea.SendKeys("extraInfo");

            driver.FindElements(By.TagName("button"))[0].Click();
            Console.WriteLine(driver.Url);
            Assert.IsTrue(driver.Url.Equals(url));
        }

        [TestCleanup()]
        public void IndexTestCleanup() {
            driver.Quit();
        }
    }
}
