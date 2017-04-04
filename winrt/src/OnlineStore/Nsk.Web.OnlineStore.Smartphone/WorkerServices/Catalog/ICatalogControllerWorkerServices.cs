using Nsk.Web.OnlineStore.Smartphone.Models.Catalog;

namespace Nsk.Web.OnlineStore.Smartphone.WorkerServices.Catalog
{
    public interface ICatalogControllerWorkerServices
    {
        ProductViewModel GetProductViewModelByProductId(int productId);
    }
}
