using Microsoft.AspNetCore.Mvc.Rendering;
using Nsk.Web.Site.Models.Catalog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Nsk.Data.Model;

namespace Nsk.Web.Site.WorkerServices.WorkerServicesExtensionMethods
{
    public static class CatalogControllerExtensionMethods
    {
        public static BaseSearchViewModel PopulateCategories(this BaseSearchViewModel model, IQueryable<Category> categories)
        {
            var categoryList = (from c in categories
                              select new SelectListItem
                              {
                                  Value = c.Id.ToString(),
                                  Text = c.Name
                              }).ToList();
            categoryList.Add(new SelectListItem()
            {
                Text = "All Categories",
                Value = "0"
            });
            model.Categories = categoryList.OrderBy(c => c.Text);

            return model;
        }
    }
}
