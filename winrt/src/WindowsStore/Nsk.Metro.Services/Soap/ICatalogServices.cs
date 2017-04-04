using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace Nsk.Metro.Services.Soap
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "ICatalogServices" in both code and config file together.
    [ServiceContract]
    public interface ICatalogServices
    {
        [OperationContract]
        IEnumerable<ProductCategoryInfo> GetProductCategories();

        [OperationContract]
        IEnumerable<ProductInfo> GetProductsByCategoryId(int categoryId);

        [OperationContract]
        IEnumerable<ProductInfo> GetProductsByCategoryName(string categoryName);

        [OperationContract]
        SearchResult SearchInCatalog(string query);

        [OperationContract]
        string GetImageUrlByCategoryId(int id);

        [OperationContract]
        ProductDetailInfo GetProductDetailInformations(int productId);
    }

    [DataContract]
    public class ProductCategoryInfo
    {
        [DataMember]
        public int Id { get; set; }
        
        [DataMember]
        public string Name { get; set; }
        
        [DataMember]
        public string Description { get; set; }
    }

    [DataContract]
    public class ProductInfo
    {
        [DataMember]
        public int Id { get; set; }

        [DataMember]
        public string Name { get; set; }

        [DataMember]
        public decimal? UnitPrice { get; set; }
    }

    [DataContract]
    public class ProductDetailInfo
    {
        [DataMember]
        public int Id { get; set; }

        [DataMember]
        public string Name { get; set; }

        [DataMember]
        public string QuantityPerUnit { get; set; }

        [DataMember]
        public decimal? UnitPrice { get; set; }

        [DataMember]
        public int? UnitsInStock { get; set; }
    }

    [DataContract]
    public class SearchResult
    {
        [DataMember]
        public IEnumerable<ProductCategoryInfo> Categories { get; set; }

        [DataMember]
        public IEnumerable<ProductInfo> Products { get; set; }
    }
}
