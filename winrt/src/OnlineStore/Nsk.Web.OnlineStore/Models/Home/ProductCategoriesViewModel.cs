using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Nsk.Web.OnlineStore.WorkerServices;

namespace Nsk.Web.OnlineStore.Models.Home
{
    public class ProductCategoriesViewModel : HtmlPageViewModel
    {
        public IEnumerable<ProductCategoryDescriptor> Categories { get; set; }

        public class ProductCategoryDescriptor
        {
            /// <summary>
            /// Represents the Id of the product category
            /// </summary>
            public int CategoryId { get; set; }

            /// <summary>
            /// Represents the name of the product category
            /// </summary>
            public string CategoryName { get; set; }

            /// <summary>
            /// Define the number of products included within the category which are availabe in store at the moment
            /// </summary>
            public int AvailableProductsCount { get; set; }

            /// <summary>
            /// Define the number of products included within the category
            /// </summary>
            public int ProductsCount { get; set; }
        }
    }


}