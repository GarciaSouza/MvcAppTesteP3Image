using System.Web.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MvcAppTesteP3Image;
using MvcAppTesteP3Image.Controllers;

namespace MvcAppTesteP3Image.Tests.Controllers
{
    [TestClass]
    public class HomeControllerTest
    {
        [TestMethod]
        public void Index()
        {
            // Arrange
            HomeController controller = new HomeController();

            // Act
            ViewResult result = controller.Index() as ViewResult;

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual("Home Page", result.ViewBag.Title);
        }

        [TestMethod]
        public void Admin()
        {
            // Arrange
            HomeController controller = new HomeController();

            // Act
            ViewResult result = controller.Admin() as ViewResult;

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual("Admin", result.ViewBag.Title);
        }
    }
}
