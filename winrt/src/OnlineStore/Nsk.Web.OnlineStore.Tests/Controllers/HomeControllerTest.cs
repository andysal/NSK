using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using SharpTestsEx;
using SharpTestsEx.Assertions;
using Nsk.Web.OnlineStore;
using Nsk.Web.OnlineStore.Controllers;
using Nsk.Web.OnlineStore.WorkerServices;

namespace Nsk.Web.OnlineStore.Tests.Controllers
{
    [TestClass]
    public class HomeControllerTest
    {
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
                Be("svc");
        }




    }
}
