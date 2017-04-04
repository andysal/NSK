using Nsk.Domain.ReadModel;
using Nsk.Web.Mvc;
using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Drawing;
using System.Linq;
using System.Net.Mime;
using System.Web;
using System.Web.Mvc;

namespace Nsk.Metro.Services.Controllers
{
    public class ImageController : Controller
    {
        public readonly IReadModelFacade Database;

        public ImageController(IReadModelFacade database)
        {
            Contract.Requires<ArgumentNullException>(database != null, "database");
            Contract.Ensures(this.Database != null, "database");
            Contract.Ensures(this.Database == database, "database");
            
            Database = database;
        }

        [HttpGet]
        [OutputCache(Duration = 60, VaryByParam = "categoryId")]
        public ActionResult GetCategoryThumbnail(int? id)
        {
            if (!id.HasValue)
            {
                return new EmptyResult();
            }
            else
            {
                Image image = this.Database.GetThumbnailByCategory(id.Value);
                return new ImageResult(image, MediaTypeNames.Image.Jpeg, image.Size);
            }
        }

    }
}
