using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using Nsk.Web.OnlineStore.Models.Home;

namespace Nsk.Web.OnlineStore.WorkerServices
{
    public interface IHomeControllerWorkerServices
    {
        IEnumerable<ProductCategoriesViewModel.ProductCategoryDescriptor> GetAllProductCategories();
        IEnumerable<ProductCategoriesViewModel.ProductCategoryDescriptor> GetBestSellingProductCategories();
        IndexViewModel GetIndexViewModel();
        Image GetThumbnailForCategoryId(int categoryId);
        bool UserNameIsAlreadyUsed(string userName);
    }


}
