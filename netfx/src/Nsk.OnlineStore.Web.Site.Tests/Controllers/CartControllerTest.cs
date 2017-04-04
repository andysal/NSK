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
using Nsk.OnlineStore.Commands;

namespace Nsk.OnlineStore.Web.Site.Tests.Controllers
{
    [TestClass]
    public class CartControllerTest
    {
        [TestMethod]
        public void Ctor_should_throw_on_null_workerServices_argument()
        {
            Executing.This(() => new CartController(null))
                .Should()
                .Throw<ArgumentNullException>()
                .And
                .ValueOf
                .ParamName
                .Should()
                .Be
                .EqualTo("workerServices");
        }

        [TestMethod]
        public void Ctor_should_set_WorkerServices_property()
        {
            var mockedDatabase = new Mock<IDatabase>().Object;
            var mockedCommands = new Mock<CartCommands>().Object;
            var workerServices = new CartControllerWorkerServices(mockedDatabase, mockedCommands);
            var sut = new CartController(workerServices);
            Assert.AreSame(workerServices, sut.WorkerServices);
        }
    }
}
