using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Capstone.Web.Models;
using System.Data.SqlClient;

namespace Capstone.Web.DAL
{
    public class ParkSqlDAL : IParkInfoSqlDAL
    {
        private static string connectionString = "Data Source=.\\SQLEXPRESS;Initial Catalog=NPGeek;Persist Security Info=True;User ID=te_student;Password=techelevator";

        public List<ParkModel> GetAllParks()
        {
            List<ParkModel> output = new List<ParkModel>();

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    SqlCommand cmd = new SqlCommand("SELECT * FROM park", conn);

                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        ParkModel p = new ParkModel();

                        p.Acreage = Convert.ToInt32(reader["acreage"]);
                        p.AnnualVisitors = Convert.ToInt32(reader["annualVisitorCount"]);
                        p.Climate = Convert.ToString(reader["climate"]);
                        p.Description = Convert.ToString(reader["parkDescription"]);
                        p.Elevation = Convert.ToInt32(reader["elevationinFeet"]);
                        p.EntryFee = Convert.ToInt32(reader["entryFee"]);
                        p.MilesOfTrail = Convert.ToDouble(reader["milesOfTrail"]);
                        p.NumberOfCampsites = Convert.ToInt32(reader["numberofCampsites"]);
                        p.NumberOfSpecies = Convert.ToInt32(reader["numberOfAnimalSpecies"]);
                        p.ParkCode = Convert.ToString(reader["parkCode"]);
                        p.ParkName = Convert.ToString(reader["parkName"]);
                        p.Quote = Convert.ToString(reader["inspirationalQuote"]);
                        p.QuoteSource = Convert.ToString(reader["inspirationalQuoteSource"]);
                        p.State = Convert.ToString(reader["state"]);
                        p.YearFounded = Convert.ToInt32(reader["yearFounded"]);

                        output.Add(p);
                    }
                }

            }
            catch (SqlException)
            {
                throw;
            }

            return output;
        }

        public ParkModel GetParkInfo(string parkCode)
        {
            ParkModel p = new ParkModel();

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    SqlCommand cmd = new SqlCommand("SELECT * FROM park WHERE parkCode = '@parkCode';", conn);
                    cmd.Parameters.AddWithValue("@parkCode", parkCode.ToUpper());

                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        p.Acreage = Convert.ToInt32(reader["acreage"]);
                        p.AnnualVisitors = Convert.ToInt32(reader["annualVisitorCount"]);
                        p.Climate = Convert.ToString(reader["climate"]);
                        p.Description = Convert.ToString(reader["parkDescription"]);
                        p.Elevation = Convert.ToInt32(reader["elevationinFeet"]);
                        p.EntryFee = Convert.ToInt32(reader["entryFee"]);
                        p.MilesOfTrail = Convert.ToDouble(reader["milesOfTrail"]);
                        p.NumberOfCampsites = Convert.ToInt32(reader["numberofCampsites"]);
                        p.NumberOfSpecies = Convert.ToInt32(reader["numberOfAnimalSpecies"]);
                        p.ParkCode = Convert.ToString(reader["parkCode"]);
                        p.ParkName = Convert.ToString(reader["parkName"]);
                        p.Quote = Convert.ToString(reader["inspirationalQuote"]);
                        p.QuoteSource = Convert.ToString(reader["inspirationalQuoteSource"]);
                        p.State = Convert.ToString(reader["state"]);
                        p.YearFounded = Convert.ToInt32(reader["yearFounded"]); 
                    }

                }
            }
            catch (SqlException)
            {
                throw;
            }

            return p;
        }
    }
}