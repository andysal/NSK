using System.ServiceModel.Syndication;
using Nsk.Web.OnlineStore.Models.Catalog;

namespace Nsk.Web.OnlineStore.WorkerServices
{
    public interface ICatalogControllerWorkerServices
    {
        ProductViewModel GetProductViewModelByProductId(int productId);
        SearchViewModel GetSearchPageViewModel(int categoryId, string query);
        ProductCategoryViewModel GetProductCategoryViewModelByCategoryName(string categoryName, string sort);
        AddToShoppingCartViewModel BuildAddToShoppingCartViewModel();
    }


}
