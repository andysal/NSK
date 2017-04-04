using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Nsk.OnlineStore.Commands;
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
    public class CartControllerWorkerServicesTests
    {
        [TestMethod]
        public void Ctor_should_throw_on_null_database_argument()
        {
            var fakeCommands = new Mock<CartCommands>().Object;
            Executing.This(() => new CartControllerWorkerServices(null, fakeCommands))
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
        public void Ctor_should_throw_on_null_commands_argument()
        {
            var fakeDatabase = new Mock<IDatabase>().Object;
            Executing.This(() => new CartControllerWorkerServices(fakeDatabase, null))
                .Should()
                .Throw<ArgumentNullException>()
                .And
                .ValueOf
                .ParamName
                .Should()
                .Be
                .EqualTo("commands");
        }

        [TestMethod]
        public void Ctor_should_set_Database_property()
        {
            var mockedDatabase = new Mock<IDatabase>().Object;
            var mockedCommands = new Mock<CartCommands>().Object;
            var sut = new CartControllerWorkerServices(mockedDatabase, mockedCommands);
            Assert.AreSame(mockedDatabase, sut.Database);
        }

        [TestMethod]
        public void Ctor_should_set_Commands_property()
        {
            var mockedDatabase = new Mock<IDatabase>().Object;
            var mockedCommands = new Mock<CartCommands>().Object;
            var sut = new CartControllerWorkerServices(mockedDatabase, mockedCommands);
            Assert.AreSame(mockedCommands, sut.Commands);
        }
    }
}
