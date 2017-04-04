using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Mvc;
using Nsk.Domain.ReadModel;
using Nsk.Domain.Services;
using Nsk.Metro.Services.Models.Catalog;
using Nsk.Web.Mvc;

namespace Nsk.Metro.Services.Controllers
{
    public class CatalogController : Controller
    {
        public readonly IReadModelFacade Database;
        public readonly ICatalogServices CatalogServices; 

        public CatalogController(IReadModelFacade database, ICatalogServices catalogServices)
        {
            Contract.Requires<ArgumentNullException>(database != null, "database");
            Contract.Requires<ArgumentNullException>(catalogServices != null, "catalogServices");
            Contract.Ensures(this.Database == database, "database");
            Contract.Ensures(this.CatalogServices == catalogServices, "catalogServices");
            
            Database = database;
            CatalogServices = catalogServices;
        }

        [HttpGet]
        public JsonResult GetProductCategories()
        {
            var categories = from c in Database.Categories
                                orderby c.Name
                                select new ProductCategoryInfo
                                {
                                    Id = c.Id,
                                    Name = c.Name,
                                    Description = c.Description
                                };
            return Json(categories, JsonRequestBehavior.AllowGet); ;
        }

        [HttpGet]
        public JsonResult GetProductsByCategoryId(int categoryId)
        {
            var products = from p in CatalogServices.GetProductsOnSale()
                            where p.Category.Id == categoryId
                            orderby p.Name
                            select new ProductInfo
                            {
                                Id = p.Id,
                                Name = p.Name,
                                UnitPrice = p.UnitPrice
                            };
            return Json(products, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public JsonResult GetProductsByCategoryName(string categoryName)
        {
            var products = from p in Database.Products
                            where p.Category.Name == categoryName && p.IsDiscontinued == false
                            orderby p.Name
                            select new ProductInfo
                            {
                                Id = p.Id,
                                Name = p.Name,
                                UnitPrice = p.UnitPrice
                            };
            return Json(products, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        //[Minify(ApplyCompression=true)]
        public JsonResult Search(string query)
        {
            var model = new SearchResult();
            model.Categories = (from c in Database.Categories
                                where c.Name.StartsWith(query)
                                orderby c.Name
                                select new SearchResult.ProductCategoryInfo
                                {
                                    Id = c.Id,
                                    Name = c.Name,
                                    Description = c.Description
                                }).ToArray();

            model.Products = (from p in Database.Products
                                where p.Name.StartsWith(query) && p.IsDiscontinued == false
                                orderby p.Name
                              select new SearchResult.ProductInfo
                                {
                                    Id = p.Id,
                                    Name = p.Name,
                                    UnitPrice = p.UnitPrice
                                }).ToArray();
            return Json(model, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public JsonResult GetImageUrlByCategoryId(int id)
        {
            var url = string.Format("http://{0}/Image/GetCategoryThumbnail/{1}", this.Request.Headers["Host"], id);
            return Json(url, JsonRequestBehavior.AllowGet);
        }
    }
}
