using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Nsk.Web.Site.Models.Catalog
{
    public class BaseSearchViewModel
    {
        [DisplayName("Category")]
        public int SelectedCategoryId { get; set; }

        public IEnumerable<SelectListItem> Categories { get; set; }

        [DisplayName("Product Name")]
        [Required]
        public string Query { get; set; }

    }
}
