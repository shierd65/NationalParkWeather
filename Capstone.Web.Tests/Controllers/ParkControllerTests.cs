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
    public class ParkControllerTests
    {
        [TestMethod]
        public void Parks_PingReturnsParkView()
        {
            Mock<IParkInfoSqlDAL> mockParkInfo = new Mock<IParkInfoSqlDAL>();
            mockParkInfo.Setup(m => m.GetAllParks());
            ParkController controller = new ParkController(mockParkInfo.Object);
            var result = controller.Parks();
            Assert.IsTrue(result is ViewResult);
            var viewResult = result as ViewResult;
            Assert.AreEqual("Parks", viewResult.ViewName);
        }

        [TestMethod]
        public void Parks_PingReturnsParkDetail()
        {
            Mock<HttpSessionStateBase> mockSession = new Mock<HttpSessionStateBase>();
            mockSession.Object["ParkCode"] = "GND";

            Mock<HttpContextBase> mockContext = new Mock<HttpContextBase>();

            mockContext.Setup(c => c.Session).Returns(mockSession.Object);

            var fakePark = new ParkModel()
            {
                ParkCode = "GND",
                ParkName = "GinaNatalieDan"
            };

            Mock<IParkInfoSqlDAL> mockParkInfo = new Mock<IParkInfoSqlDAL>();
            mockParkInfo.Setup(m => m.GetParkInfo("GND")).Returns(fakePark);
            mockParkInfo.Setup(m => m.GetAllParks()).Returns(new List<ParkModel>() {fakePark});
            ParkController controller = new ParkController(mockParkInfo.Object);

            controller.ControllerContext = new ControllerContext(mockContext.Object, new System.Web.Routing.RouteData(), controller);
            var result = controller.ParkDetail("GND");

            Assert.IsTrue(result is ViewResult);
            var viewResult = result as ViewResult;
            Assert.AreEqual("ParkDetail", viewResult.ViewName);
        }

    }
}
