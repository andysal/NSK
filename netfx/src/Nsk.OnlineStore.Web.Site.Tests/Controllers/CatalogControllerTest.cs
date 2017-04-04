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
    public class CatalogControllerTest
    {
        [TestMethod]
        public void Ctor_should_throw_on_null_workerServices_argument()
        {
            Executing.This(() => new CatalogController(null))
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
            var workerServices = new CatalogControllerWorkerServices(mockedDatabase);
            var sut = new CatalogController(workerServices);
            Assert.AreSame(workerServices, sut.WorkerServices);
        }
    }
}
