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
    [TestClass()]
    public class SurveyControllerTests
    {

        [TestMethod]
        public void SurveyResult_PingReturnsSurveyResultView()
        {
        Mock<ISurveySqlDAL> mockSurvey = new Mock<ISurveySqlDAL>();
        mockSurvey.Setup(m => m.GetFavoriteParkResults());
        SurveyController controller = new SurveyController(mockSurvey.Object);
        var result = controller.SurveyResult();
        Assert.IsTrue(result is ViewResult);
        var viewResult = result as ViewResult;
        Assert.AreEqual("SurveyResult", viewResult.ViewName);
        }


    }
}
