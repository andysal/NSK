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
    public class CatalogControllerWorkerServicesTests
    {
        [TestMethod]
        public void Ctor_should_throw_on_null_database_argument()
        {
            Executing.This(() => new CatalogControllerWorkerServices(null))
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
            var sut = new CatalogControllerWorkerServices(mockedDatabase);
            Assert.AreSame(mockedDatabase, sut.Database);
        }
    }
}
