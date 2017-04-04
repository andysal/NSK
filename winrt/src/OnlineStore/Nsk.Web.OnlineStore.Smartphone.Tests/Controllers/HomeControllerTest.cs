using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using SharpTestsEx;
using SharpTestsEx.Assertions;
using Nsk.Web.OnlineStore.Smartphone;
using Nsk.Web.OnlineStore.Smartphone.Controllers;
using Nsk.Web.OnlineStore.Smartphone.WorkerServices.Home;

namespace Nsk.Web.OnlineStore.Smartphone.Tests.Controllers
{
    [TestClass]
    public class HomeControllerTest
    {
        //[TestMethod]
        //public void Index()
        //{
        //    // Arrange
        //    HomeController controller = new HomeController();

        //    // Act
        //    ViewResult result = controller.Index() as ViewResult;

        //    // Assert
        //    ViewDataDictionary viewData = result.ViewData;
        //    Assert.AreEqual("Welcome to ASP.NET MVC!", viewData["Message"]);
        //}

        [TestMethod()]
        public void HomeController_Constructor_should_Throw_on_null_WorkerService()
        {
            IHomeControllerWorkerServices svc = null;
            Executing.This(
                    () => new HomeController(svc)
                ).
                Should().
                Throw<ArgumentNullException>().
                And.
                ValueOf.
                ParamName.
                Should().
                Be("workerService");
        }

        [TestMethod]
        public void ValidateUniqueUserName_should_return_False_on_existing_UserName()
        {
            string userName = "andysal74";

            var mock = new Mock<IHomeControllerWorkerServices>();
            mock.Setup(o => o.UserNameIsAlreadyUsed(userName)).Returns(true);

            var ctrl = new HomeController(mock.Object);

            var result = ctrl.ValidateUniqueUserName(userName);
            Assert.IsFalse((bool)result.Data);
        }

        [TestMethod]
        public void ValidateUniqueUserName_should_return_True_on_non_existing_UserName()
        {
            string userName = "andysal74";

            var mock = new Mock<IHomeControllerWorkerServices>();
            mock.Setup(o => o.UserNameIsAlreadyUsed(userName)).Returns(true);

            var ctrl = new HomeController(mock.Object);

            var result = ctrl.ValidateUniqueUserName(userName + "L");
            Assert.IsTrue((bool)result.Data);
        }
    }
}
