using Capstone.UITests.PageObjects;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using TechTalk.SpecFlow;

namespace Capstone.UITests.StepDefinitions
{
    [Binding]
    public class ParkListToParkDetailSteps
    {
        private static IWebDriver driver;

        [BeforeFeature]
        public static void Setup()
        {
            driver = new ChromeDriver();
        }

        [AfterFeature]
        public static void CleanUp()
        {
            driver.Close();
            driver.Quit();
        }

        [Given(@"I am on the park list page")]
        public void GivenIAmOnTheParkListPage()
        {
            ParkList page = new ParkList(driver);
            page.Navigate();

            ScenarioContext.Current.Set(page, "CurrentPage");
        }
        
        [When(@"I click on a park picture")]
        public void WhenIClickOnAParkPicture()
        {
            ParkList listPage = ScenarioContext.Current.Get<ParkList>("CurrentPage");

            ParkDetail detailPage = listPage.ClickImage_GetDetail();
            ScenarioContext.Current.Set(detailPage, "CurrentPage");
        }
        
        [Then(@"I should see the park detail page")]
        public void ThenIShouldSeeTheParkDetailPage()
        {
            ParkDetail detailPage = ScenarioContext.Current.Get<ParkDetail>("CurrentPage");

            Assert.IsNotNull(detailPage);
        }
    }
}
