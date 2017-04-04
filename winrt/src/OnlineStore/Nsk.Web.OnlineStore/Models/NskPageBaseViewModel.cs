using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Nsk.Web.OnlineStore.Models
{
    public class NskPageBaseViewModel : HtmlPageViewModel
    {
        public string Description { get; set; }

        public IEnumerable<CategoryInfo> ProductCategories { get; set; }
        public int SelectedCategoryId { get; set; }
        
        [Required(ErrorMessage="*")]
        public string SearchQuery { get; set; }

        public class CategoryInfo
        {
            public int Id { get; set; }
            public string Name { get; set; }
        }

        public NskPageBaseViewModel()
        {
            var categories = new List<CategoryInfo>();
            categories.Add(new CategoryInfo() { Id=0, Name="All categories" });
            ProductCategories = categories;
        }
    }
}