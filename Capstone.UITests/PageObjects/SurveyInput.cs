using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capstone.UITests.PageObjects
{
    class SurveyInput
    {
        private const string url = "http://localhost:55601/Survey/SurveyInput";
        private IWebDriver driver;

        public SurveyInput(IWebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(driver, this);
        }

        public void Navigate()
        {
            driver.Navigate().GoToUrl(url);
        }

        [FindsBy(How = How.Name , Using = "Email")]
        public IWebElement Email { get; set; }

        [FindsBy(How = How.Name, Using = "State")]
        public IWebElement State { get; set; }

        [FindsBy(How = How.Name, Using = "ActivityLevel")]
        public IWebElement ActivityLevel { get; set; }

        [FindsBy(How = How.Name, Using = "ParkCode")]
        public IWebElement FavoritePark { get; set; }

        [FindsBy(How = How.TagName, Using = "button")]
        public IWebElement SubmitButton { get; set; }

        [FindsBy(How = How.ClassName, Using = "field-validation-error")]
        public IList<IWebElement> ValidationErrors { get; set; }

        public SurveyResult SubmitWithValidData_ReturnResultsPage()
        {
            Email.SendKeys("a@a.co");
            State.SendKeys("ak");
            FavoritePark.SendKeys("Glacier National Park");
            ActivityLevel.SendKeys("Inactive");

            SubmitButton.Click();

            return new SurveyResult(driver);
        }

        public SurveyInput SubmitWithInvalidData_ReturnToInputPage()
        {
            SubmitButton.Click();

            return new SurveyInput(driver);
        }
    }
}
