using System.IO;
using Moq;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.AspNetCore.Routing;
using Microsoft.AspNetCore.Mvc.ViewEngines;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;

namespace MvcMate.Web.Tests
{
    public class MockFactories
    {
        public static IHtmlHelper CreateFakeHtmlHelper()
        {
            var vd = new ViewDataDictionary();
            var mockViewContext = new Mock<ViewContext>(
                                                    new ControllerContext(
                                                        new Mock<HttpContext>().Object,
                                                        new RouteData(),
                                                        new Mock<ControllerBase>().Object),
                                                    new Mock<IView>().Object,
                                                    vd,
                                                    new TempDataDictionary(),
                                                    new Mock<TextWriter>().Object);
            var mockViewDataContainer = new Mock<IViewDataContainer>();
            mockViewDataContainer
                .Setup(v => v.ViewData)
                .Returns(vd);
            return new HtmlHelper(mockViewContext.Object, mockViewDataContainer.Object);
        }

        public static HtmlHelper<T> CreateFakeHtmlHelper<T>()
        {
            var vd = new ViewDataDictionary();
            var mockViewContext = new Mock<ViewContext>(
                                                    new ControllerContext(
                                                        new Mock<HttpContext>().Object,
                                                        new RouteData(),
                                                        new Mock<ControllerBase>().Object),
                                                    new Mock<IView>().Object,
                                                    vd,
                                                    new TempDataDictionary(),
                                                    new Mock<TextWriter>().Object);
            mockViewContext
                .Setup(c => c.ClientValidationEnabled)
                .Returns(true);
            mockViewContext
                .Setup(c => c.UnobtrusiveJavaScriptEnabled)
                .Returns(true);
            mockViewContext
                .Setup(c => c.FormContext)
                .Returns(new FormContext());
            var mockViewDataContainer = new Mock<IViewDataContainer>();
            mockViewDataContainer
                .Setup(v => v.ViewData)
                .Returns(vd);
            return new HtmlHelper<T>(mockViewContext.Object, mockViewDataContainer.Object);
        }
    }
}
