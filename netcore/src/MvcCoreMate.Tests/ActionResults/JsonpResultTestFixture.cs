using System;
using System.IO;
using Moq;
using SharpTestsEx;
using NUnit.Framework;
using MvcCoreMate;
using MvcCoreMate.Mvc;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;

namespace MvcCoreMate.Tests
{
    [TestFixture]
    public class JsonpResultTestFixture
    {
        [Test]
        public void Ctor_should_throw_ArgumentNullException_if_data_parameter_is_null()
        {
            Executing.This(() => new JsonpResult(null))
                .Should()
                .Throw<ArgumentNullException>()
                .And
                .ValueOf
                .ParamName
                .Should()
                .Be
                .EqualTo("data");
        }

        [Test]
        public void Ctor_should_set_Data_property_if_data_parameter_has_a_correct_value()
        {
            var data = "101";
            var result = new JsonpResult(data);
            Assert.AreEqual(data, result.Data);
        }

        [Test]
        public void ExecuteResult_should_throw_ArgumentNullException_if_context_parameter_is_null()
        {
            var data = "101";
            var result = new JsonpResult(data);
            Executing.This(() => result.ExecuteResultAsync(null))
                .Should()
                .Throw<ArgumentNullException>()
                .And
                .ValueOf
                .ParamName
                .Should()
                .Be
                .EqualTo("context");
        }

        [Test]
        public void ExecuteResult_should_return_json_mimetype()
        {
            var writer = new StringWriter();
            var responseMock = new Mock<HttpResponse>();
            responseMock.SetupProperty<string>(x => x.ContentType);
            responseMock.SetupGet(x => x.Output).Returns(writer);

            var requestMock = new Mock<HttpRequest>();
            requestMock.SetupGet(x => x["callback"]).Returns("fake");

            var httpContextMock = new Mock<HttpContext>();
            httpContextMock.SetupGet(x => x.Request).Returns(requestMock.Object);
            httpContextMock.SetupGet(x => x.Response).Returns(responseMock.Object);

            var controllerContextMock = new Mock<ControllerContext>();
            controllerContextMock.SetupGet(x => x.HttpContext).Returns(httpContextMock.Object);

            var data = "101";
            var result = new JsonpResult(data);
            result.ExecuteResultAsync(controllerContextMock.Object);

            Assert.AreEqual("application/json", controllerContextMock.Object.HttpContext.Response.ContentType);
        }
    }
}
