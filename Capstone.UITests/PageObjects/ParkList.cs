using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capstone.UITests.PageObjects
{
    class ParkList
    {
        private const string url = "http://localhost:55601/Park/Parks";
        private IWebDriver driver;

        public ParkList(IWebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(driver, this);
        }

        [FindsBy(How = How.ClassName, Using = "pic")]
        public IWebElement ParkPicture { get; set; }

        public void Navigate()
        {
            driver.Navigate().GoToUrl(url);
        }

        public ParkDetail ClickImage_GetDetail()
        {
            ParkPicture.Click();

            return new ParkDetail(driver);
        }
    }
}
