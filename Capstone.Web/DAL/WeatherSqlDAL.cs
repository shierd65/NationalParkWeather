using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Capstone.Web.Models;
using System.Data.SqlClient;

namespace Capstone.Web.DAL
{
    public class WeatherSqlDAL : IWeatherSqlDAL
    {
        private const string connectionString = "Data Source=.\\SQLEXPRESS;Initial Catalog=NPGeek;Persist Security Info=True;User ID=te_student;Password=***********";
        
        //public List<WeatherForecastModel> GetForecast(string parkCode)
        //{
        //    throw new NotImplementedException();
        //}

        public WeatherForecastModel GetForecast(string parkCode)
        {
            WeatherForecastModel output = new WeatherForecastModel();

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    SqlCommand cmd = new SqlCommand("SELECT * FROM weather WHERE parkCode = @parkCode", conn);
                    cmd.Parameters.AddWithValue("@parkCode", parkCode);

                    SqlDataReader reader = cmd.ExecuteReader();

                    output.ParkCode = parkCode;
                    int i = 0;
                    while (reader.Read())
                    {
                        i = Convert.ToInt32(reader["fiveDayForecastValue"]);
                        output.High.Add(Convert.ToInt32(reader["high"]));
                        output.Low.Add(Convert.ToInt32(reader["low"]));
                        output.Forecast.Add(Convert.ToString(reader["forecast"]));
                    }
                }
            }
            catch (SqlException)
            {

                throw;
            }

            return output;
        }
    }
}