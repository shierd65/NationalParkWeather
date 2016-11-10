using Capstone.Web.DAL;
using Capstone.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Capstone.Web.Controllers
{
    public class WeatherController : Controller
    {
        IWeatherSqlDAL dal;

        public WeatherController(IWeatherSqlDAL dal)
        {
            this.dal = dal;
        }

        // GET: Weather
        public ActionResult Forecast(string parkCode)
        {
            WeatherForecastModel model = dal.GetForecast(parkCode);
            if (Session["ShowFahrenheit"] == null)
            {
                Session["ShowFahrenheit"] = true;
            }
            
            
               model.DisplayFahrenheit = (bool)Session["ShowFahrenheit"];
            
           if ((bool)Session["ShowFahrenheit"] == false)
            {
                model.TemperatureConvert(model);
            }

            model.PackingList = model.GetPackList(model);

            return View("Forecast", model);
        }

    }
}