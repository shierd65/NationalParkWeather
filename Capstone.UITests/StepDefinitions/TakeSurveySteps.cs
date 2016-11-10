using Capstone.UITests.PageObjects;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using TechTalk.SpecFlow;

namespace Capstone.UITests.StepDefinitions
{
    [Binding]
    public class TakeSurveySteps
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

        [Given(@"I am on the Survey Input Page")]
        public void GivenIAmOnTheSurveyInputPage()
        {
            SurveyInput page = new SurveyInput(driver);
            page.Navigate();

            ScenarioContext.Current.Set(page, "CurrentPage");
        }

        [When(@"I enter valid information and submit the survey")]
        public void WhenIEnterValidInformationAndSubmitTheSurvey()
        {
            SurveyInput page = ScenarioContext.Current.Get<SurveyInput>("CurrentPage");

            SurveyResult resultPage = page.SubmitWithValidData_ReturnResultsPage();
            ScenarioContext.Current.Set(resultPage, "CurrentPage");
        }


        [Then(@"I should see the survey result page")]
        public void ThenIShouldSeeTheSurveyResultPage()
        {
            SurveyResult page = ScenarioContext.Current.Get<SurveyResult>("CurrentPage");

            Assert.IsNotNull(page);
        }
    }
}
