using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using SharpTestsEx;
using Nsk.OnlineStore.Web.Site;
using Nsk.OnlineStore.Web.Site.Controllers;
using Nsk.OnlineStore.Web.Site.WorkerServices;
using Nsk.OnlineStore.Data.ReadModel;

namespace Nsk.OnlineStore.Web.Site.Tests.Controllers
{
    [TestClass]
    public class HomeControllerTest
    {
        [TestMethod]
        public void Ctor_should_throw_on_null_workerServices_argument()
        {
            Executing.This(() => new HomeController(null)).Should().Throw<ArgumentNullException>().And.ValueOf.ParamName.Should().Be.EqualTo("workerServices");
        }

        [TestMethod]
        public void Ctor_should_set_WorkerServices_property()
        {
            var mockedDatabase = new Mock<IDatabase>().Object;
            var workerServices = new HomeControllerWorkerServices(mockedDatabase);
            var sut = new HomeController(workerServices);
            Assert.AreSame(workerServices, sut.WorkerServices);
        }
    //[TestMethod]
    //public void Index()
    //{
    //    // Arrange
    //    HomeController controller = new HomeController();
    //    // Act
    //    ViewResult result = controller.Index() as ViewResult;
    //    // Assert
    //    Assert.IsNotNull(result);
    //}
    //[TestMethod]
    //public void About()
    //{
    //    // Arrange
    //    HomeController controller = new HomeController();
    //    // Act
    //    ViewResult result = controller.About() as ViewResult;
    //    // Assert
    //    Assert.AreEqual("Your application description page.", result.ViewBag.Message);
    //}
    //[TestMethod]
    //public void Contact()
    //{
    //    // Arrange
    //    HomeController controller = new HomeController();
    //    // Act
    //    ViewResult result = controller.Contact() as ViewResult;
    //    // Assert
    //    Assert.IsNotNull(result);
    //}
    }
}