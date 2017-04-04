using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SharpTestsEx;
using Moq;
using Nsk.OnlineStore.Web.Services.Controllers;
using Nsk.OnlineStore.Data.ReadModel;

namespace Nsk.OnlineStore.Web.Services.Tests.Controllers
{
    [TestClass]
    public class ImageControllerTests
    {
        [TestMethod]
        public void Ctor_should_throw_on_null_workerServices_argument()
        {
            Executing.This(() => new ImageController(null))
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
            var sut = new ImageController(mockedDatabase);
            Assert.AreSame(mockedDatabase, sut.Database);
        }

    }
}
