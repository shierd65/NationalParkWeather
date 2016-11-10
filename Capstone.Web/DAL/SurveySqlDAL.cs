using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Capstone.Web.Models;
using System.Data.SqlClient;

namespace Capstone.Web.DAL
{
    public class SurveySqlDAL : ISurveySqlDAL
    {
        private static string connectionString = "Data Source=.\\SQLEXPRESS;Initial Catalog=NPGeek;Persist Security Info=True;User ID=te_student;Password=***********";

        public bool AddSurvey(SurveyModel s)
        {
            int rowsAffected = 0;

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    SqlCommand cmd = new SqlCommand("INSERT INTO survey_result (parkCode, emailAddress, state, activityLevel) VALUES (@parkCode, @email, @state, @activity);", conn);
                    cmd.Parameters.AddWithValue("@parkCode", s.ParkCode);
                    cmd.Parameters.AddWithValue("@email", s.Email);
                    cmd.Parameters.AddWithValue("@state", s.State);
                    cmd.Parameters.AddWithValue("@activity", s.ActivityLevel);

                    rowsAffected = cmd.ExecuteNonQuery();
                }
            }
            catch (SqlException)
            {

                throw;
            }

            return (rowsAffected > 0);
        }

        public List<SurveyModel> GetSurveyResults()
        {
            List<SurveyModel> output = new List<SurveyModel>();

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    SqlCommand cmd = new SqlCommand("SELECT * FROM survey_result;", conn);
                    SqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        SurveyModel s = new SurveyModel();

                        s.ActivityLevel = Convert.ToString(reader["activityLevel"]);
                        s.Email = Convert.ToString(reader["emailAddress"]);
                        s.ParkCode = Convert.ToString(reader["parkCode"]);
                        s.State = Convert.ToString(reader["state"]);
                        s.SurveyID = Convert.ToInt32(reader["surveyId"]);

                        output.Add(s);
                    }
                }
            }
            catch (SqlException)
            {
                throw;
            }

            return output;
        }

        public Dictionary<string, int> GetFavoriteParkResults()
        {
            Dictionary<string, int> output = new Dictionary<string, int>();

            List<string> parks = new List<string>() {"CVNP", "ENP", "GCNP", "GNP", "GSMNP", "GTNP", "MRNP", "RMNP", "YNP", "YNP2" };

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    foreach (string park in parks)
                    {
                        SqlCommand cmd = new SqlCommand("SELECT COUNT(parkCode) AS surveyCount FROM survey_result WHERE parkCode = @park;", conn);
                        cmd.Parameters.AddWithValue("@park", park);

                        SqlDataReader reader = cmd.ExecuteReader();
                        reader.Read();

                        output.Add(park, Convert.ToInt32(reader["surveyCount"]));
                        reader.Close();
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