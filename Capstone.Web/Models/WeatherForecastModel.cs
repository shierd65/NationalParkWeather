using Capstone.Web.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Capstone.Web.Models
{
    public class WeatherForecastModel
    {
        public string ParkCode { get; set; }
        //public int Day { get; set; }
        public List<int> Low { get; set; } = new List<int>();
        public List<int> High { get; set; } = new List<int>();
        public List<string> Forecast { get; set; } = new List<string>();
        public bool DisplayFahrenheit { get; set; } = true;
        public HashSet<string> PackingList { get; set; } = new HashSet<string>();
        public HashSet<string> Warning { get; set; } = new HashSet<string>();

        public WeatherForecastModel TemperatureConvert(WeatherForecastModel forecast)
        {
            if (DisplayFahrenheit == false)
            {
                for (int i = 0; i < 5; i++)
                {
                    forecast.High[i] = (int)((forecast.High[i] - 32) * (5.0 / 9.0));
                    forecast.Low[i] = (int)((forecast.Low[i] - 32) * (5.0 / 9.0));
                }
            }

            return forecast;
        }
        public HashSet<string> GetPackList(WeatherForecastModel model)
        {
            HashSet<string> PackingList = new HashSet<string>();
                             Warning = new HashSet<string>();
            for (int i = 0; i < 5; i++)
            {
                if (model.Forecast[i]=="snow")
                {
                    PackingList.Add("snowshoes");
                }
                if (model.Forecast[i] == "rain")
                {
                    PackingList.Add("rain gear");
                    PackingList.Add("waterproof shoes");
                }
                if (model.Forecast[i] == "sun")
                {
                    PackingList.Add("sunblock");
                }
                if(model.High[i] > 75)
                {
                    PackingList.Add("an extra gallon of water");
                }
                if(model.High[i] - model.Low[i] > 20)
                {
                    PackingList.Add("wear breathable layers");
                }
                if (model.Forecast[i] == "thunderstorms")
                {
                    PackingList.Add("WARNING: Thunderstorms are expected. Be prepared to seek shelter and avoid exposed ridges!");
                }
                if (model.Low[i] < 20)
                {
                    PackingList.Add("WARNING: Frigid temperatures are expected. Please take caution. Wear warm socks!");
                }
            }
            return PackingList;
           
            
        }
    }
}