using System;
using System.IO;
using Moq;
using SharpTestsEx;
using NUnit.Framework;
using MvcCoreMate.Mvc;
using MvcCoreMate.Mvc.Model;
using Microsoft.AspNetCore.Http;

namespace MvcMate.Web.Mvc.Tests
{
    [TestFixture]
    public class Rss20ResultTestFixture
    {
        [Test]
        public void Ctor_should_throw_ArgumentNullException_if_feed_parameter_is_null()
        {
            Executing.This(() => new RssResult(null))
                .Should()
                .Throw<ArgumentNullException>()
                .And
                .ValueOf
                .ParamName
                .Should()
                .Be
                .EqualTo("feed");
        }

        [Test]
        public void Ctor_should_set_Feed_property_if_feed_parameter_has_a_correct_value()
        {
            var feed = new SyndicationFeed("fake");
            var result = new RssResult(feed);
            Assert.AreEqual(feed, result.Feed);
        }

        [Test]
        public void ExecuteResult_should_throw_ArgumentNullException_if_context_parameter_is_null()
        {
            var feed = new SyndicationFeed("fake");
            var result = new RssResult(feed);
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
        public void ExecuteResult_should_return_rss_mimetype()
        {
            var writer = new StringWriter();
            var responseMock = new Mock<HttpResponse>();
            responseMock.SetupProperty<string>(x => x.ContentType);
            responseMock.SetupGet(x => x.Output).Returns(writer);
            var httpContextMock = new Mock<HttpResponse>();
            httpContextMock.SetupGet(x => x.Response).Returns(responseMock.Object);
            var controllerContextMock = new Mock<ControllerContext>();
            controllerContextMock.SetupGet(x => x.HttpContext).Returns(httpContextMock.Object);


            var feed = new SyndicationFeed("fake");
            var result = new RssResult(feed);
            result.ExecuteResultAsync(controllerContextMock.Object);

            Assert.AreEqual("application/rss+xml", controllerContextMock.Object.HttpContext.Response.ContentType);
        }
    }
}
