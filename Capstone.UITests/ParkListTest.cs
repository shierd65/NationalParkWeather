using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using Capstone.UITests.PageObjects;

namespace Capstone.UITests
{
    [TestClass]
    public class ParkListTest
    {
        private static IWebDriver driver;

        [TestMethod]
        public void ClickPark_GetDetailView()
        {
            ParkList page = new ParkList(driver);
            page.Navigate();

            ParkDetail result = page.ClickImage_GetDetail();

            Assert.IsNotNull(result);
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
