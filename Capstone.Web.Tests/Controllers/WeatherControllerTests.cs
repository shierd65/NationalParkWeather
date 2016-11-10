using Capstone.Web.Controllers;
using Capstone.Web.DAL;
using Capstone.Web.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace Capstone.Web.Tests.Controllers
{
    [TestClass]
    public class WeatherControllerTests
    {
        [TestMethod]
        public void Weather_PingReturnsForecastView()
        {
            Mock<IWeatherSqlDAL> mockWeather = new Mock<IWeatherSqlDAL>();


            Mock<HttpContextBase> mockContext = new Mock<HttpContextBase>();

            mockContext.SetupGet(m => m.Session["ParkCode"]).Returns("GND");
            mockContext.SetupGet(m => m.Session["ShowFahrenheit"]).Returns(true);

            var fakePark = new ParkModel()
            {
                ParkCode = "GND",
                ParkName = "GinaNatalieDan"
            };

            var fakeWeather = new WeatherForecastModel();

            fakeWeather.Forecast.Add("fakecloudy");
            fakeWeather.High.Add(78);
            fakeWeather.Low.Add(20);
            fakeWeather.Forecast.Add("fakesnow");
            fakeWeather.High.Add(78);
            fakeWeather.Low.Add(20);
            fakeWeather.Forecast.Add("fakecloudy");
            fakeWeather.High.Add(78);
            fakeWeather.Low.Add(20);
            fakeWeather.Forecast.Add("fakesnow");
            fakeWeather.High.Add(78);
            fakeWeather.Low.Add(20);
            fakeWeather.Forecast.Add("fakesnow");
            fakeWeather.High.Add(78);
            fakeWeather.Low.Add(20);

            mockWeather.Setup(m => m.GetForecast("GND")).Returns(fakeWeather);

            WeatherController controller = new WeatherController(mockWeather.Object);

            controller.ControllerContext = new ControllerContext(mockContext.Object, new System.Web.Routing.RouteData(), controller);
            var result = controller.Forecast("GND");

            Assert.IsTrue(result is ViewResult);
            var viewResult = result as ViewResult;
            Assert.AreEqual("Forecast", viewResult.ViewName);
        }
    }
}
