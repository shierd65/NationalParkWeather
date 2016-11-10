using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Capstone.UITests.PageObjects;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace Capstone.UITests
{
    [TestClass]
    public class SurveyTest
    {
        private static IWebDriver driver;

        [TestMethod]
        public void SubmitWithValidData_ExpectResultPage()
        {
            SurveyInput page = new SurveyInput(driver);
            page.Navigate();

            SurveyResult result = page.SubmitWithValidData_ReturnResultsPage();

            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void SubmitWithInvalidData_ExpectInputPageWithErrors()
        {
            SurveyInput page = new SurveyInput(driver);
            page.Navigate();

            SurveyInput result = page.SubmitWithInvalidData_ReturnToInputPage();

            Assert.IsNotNull(result);
            Assert.IsTrue(result.ValidationErrors.Count > 0);
        }

        [ClassInitialize]
        public static void Setup(TestContext context)
        {
            driver = new ChromeDriver();
        }

        [ClassCleanup]
        public static void CleanUp()
        {
            driver.Close();
            driver.Quit();
        }
    }
}
