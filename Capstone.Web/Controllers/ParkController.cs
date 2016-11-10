using Capstone.Web.DAL;
using Capstone.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Capstone.Web.Controllers
{
    public class ParkController : Controller
    {
        IParkInfoSqlDAL dal;

        public ParkController(IParkInfoSqlDAL dal)
        {
            this.dal = dal;
        }

        public ActionResult Parks()
        {
            List<ParkModel> parks = new List<ParkModel>();

            parks = dal.GetAllParks();

            return View("Parks", parks);
        }

        public ActionResult ParkDetail(string parkCode)
        {
            if (Session["ParkCode"] == null)
            {
                Session["ParkCode"] = parkCode.ToUpper();
            }

            //ParkModel park = dal.GetParkInfo(parkCode);
            ParkModel park = dal.GetAllParks().Find(p => p.ParkCode == Session["ParkCode"] as string);

            return View("ParkDetail", park);
        }
        [HttpPost]
        public ActionResult SavePreferredTemp(string parkCode, bool displayFahrenheit)
        {
            Session["ShowFahrenheit"] = displayFahrenheit;
            return RedirectToAction("ParkDetail", new { parkCode = parkCode });
        }
    }
}