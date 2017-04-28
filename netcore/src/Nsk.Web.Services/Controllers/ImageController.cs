using Microsoft.AspNetCore.Mvc;
using Nsk.Web.Services.Data;
using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;

namespace Nsk.Web.Services.Controllers
{
    public class ImageController : Controller
    {
        public IDatabase Database { get; private set; }

        public ImageController(IDatabase database)
        {
            this.Database = database ?? throw new ArgumentNullException(nameof(database));
        }

        [HttpGet]
        [ResponseCache(Duration = 30)]
        public HttpResponseMessage Category(int id)
        {          
            var image = Database.GetCategoryThumbnail(id);
            var result = BuildHttpResponse(image);

            return result;
        }

        [HttpGet]
        [ResponseCache(Duration = 30)]
        public HttpResponseMessage Product(int id)
        {
            var image = Database.GetProductThumbnail(id);
            var result = BuildHttpResponse(image);

            return result;
        }

        private static HttpResponseMessage BuildHttpResponse(Image image)
        {
            var memoryStream = new MemoryStream();
            image.Save(memoryStream, ImageFormat.Jpeg);
            var result = new HttpResponseMessage(HttpStatusCode.OK);
            result.Content = new ByteArrayContent(memoryStream.ToArray());
            result.Content.Headers.ContentType = new MediaTypeHeaderValue("image/jpeg");
            return result;
        }
    }
}
