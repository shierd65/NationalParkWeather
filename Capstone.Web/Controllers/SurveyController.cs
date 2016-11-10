using Capstone.Web.DAL;
using Capstone.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Capstone.Web.Controllers
{
    public class SurveyController : Controller
    {
        ISurveySqlDAL dal;

        public SurveyController(ISurveySqlDAL dal)
        {
            this.dal = dal;
        }

        public ActionResult SurveyInput()
        {
            if (Session["tookSurvey"] == null || (bool)Session["tookSurvey"] == false)
            {
                ViewBag.ParksList = parks;
                ViewBag.ActivityLevels = activityLevels;

                return View("SurveyInput", new SurveyModel());
            }
            else
            {
                return RedirectToAction("SurveyResult");
            }
        }

        [HttpPost]
        public ActionResult SurveyInput(SurveyModel model)
        {
            if (ModelState.IsValid)
            {
                Session["tookSurvey"] = true;

                dal.AddSurvey(model);

                return RedirectToAction("SurveyResult");
            }
            else
            {
                ViewBag.ParksList = parks;
                ViewBag.ActivityLevels = activityLevels;

                return View("SurveyInput", model);
            }
        }

        public ActionResult SurveyResult()
        {
            //List<SurveyModel> model = dal.GetSurveyResults();
            Dictionary<string, int> model = dal.GetFavoriteParkResults();

            return View("SurveyResult", model);
        }

        private List<SelectListItem> parks = new List<SelectListItem>()
        {
            new SelectListItem() {Text = "Cuyahoga Valley National Park", Value = "CVNP" },
            new SelectListItem() {Text = "Everglades National Park", Value = "ENP" },
            new SelectListItem() {Text = "Grand Canyon National Park", Value = "GCNP" },
            new SelectListItem() {Text = "Glacier National Park", Value = "GNP" },
            new SelectListItem() {Text = "Great Smoky Mountains National Park", Value = "GSMNP" },
            new SelectListItem() {Text = "Grand Teton National Park", Value = "GTNP" },
            new SelectListItem() {Text = "Mount Rainier National Park", Value = "MRNP" },
            new SelectListItem() {Text = "Rocky Mountian National Park", Value = "RMNP" },
            new SelectListItem() {Text = "Yellowstone National Park", Value = "YNP" },
            new SelectListItem() {Text = "Yosemite National Park", Value= "YNP2" },
        };

        private List<SelectListItem> activityLevels = new List<SelectListItem>()
        {
            new SelectListItem() {Text = "Inactive"},
            new SelectListItem() {Text = "Sedentary" },
            new SelectListItem() {Text = "Active" },
            new SelectListItem() {Text = "Extremely Active" },
        };
    }
}