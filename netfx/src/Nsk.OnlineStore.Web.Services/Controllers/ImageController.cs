using Nsk.OnlineStore.Data.ReadModel;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web.Http;

namespace Nsk.OnlineStore.Web.Services.Controllers
{
    public class ImageController : ApiController
    {
        public IDatabase Database { get; private set; }

        public ImageController(IDatabase database)
        {
            if (database == null)
                throw new ArgumentNullException("database");
            this.Database = database;
        }

        [HttpGet]
        public HttpResponseMessage Category(int id)
        {
            var image = Database.GetCategoryThumbnail(id);
            var result = BuildHttpResponse(image);
            return result;
        }

        [HttpGet]
        public HttpResponseMessage Product(int id)
        {
            var categoryId = (
                from p in Database.Products
                where p.Id == id
                select p.CategoryID.Value).First();
            var image = Database.GetCategoryThumbnail(categoryId);
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