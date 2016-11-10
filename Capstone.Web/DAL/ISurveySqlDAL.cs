using Capstone.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capstone.Web.DAL
{
    public interface ISurveySqlDAL
    {
        List<SurveyModel> GetSurveyResults();
        bool AddSurvey(SurveyModel s);
        Dictionary<string, int> GetFavoriteParkResults();
    }
}
