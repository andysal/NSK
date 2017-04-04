using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Nsk.OnlineStore.Data.ReadModel;
using Nsk.OnlineStore.Web.Site.WorkerServices;
using SharpTestsEx;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nsk.OnlineStore.Web.Site.Tests.WorkerServices
{
    [TestClass]
    public class HomeControllerWorkerServicesTests
    {
        [TestMethod]
        public void Ctor_should_throw_on_null_database_argument()
        {
            Executing.This(() => new HomeControllerWorkerServices(null))
                .Should()
                .Throw<ArgumentNullException>()
                .And
                .ValueOf
                .ParamName
                .Should()
                .Be
                .EqualTo("database");
        }

        [TestMethod]
        public void Ctor_should_set_WorkerServices_property()
        {
            var mockedDatabase = new Mock<IDatabase>().Object;
            var sut = new HomeControllerWorkerServices(mockedDatabase);
            Assert.AreSame(mockedDatabase, sut.Database);
        }
    }
}
