using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Nsk.Domain.Model;

namespace Nsk.Web.OnlineStore.Models.Catalog
{
    public class ProductCategoryViewModel : NskPageBaseViewModel
    {
        public class ProductInfo
        {
            public int Id { get; set; }
            public string Name { get; set; }
            public string SupplierName { get; set; }
            public decimal Price { get; set; }
            public decimal UnitsInStock { get; set; }
        }

        #region Sorting criteria
        public abstract class SortingCriterion
        {
            internal readonly static IEnumerable<SortingCriterion> Criteria = new List<SortingCriterion>() {   
                                                                        new SortByName(),
                                                                        new SortByPriceAscending(), 
                                                                        new SortByPriceDescending() };


            public static SortingCriterion CreateCriterionByName(string criterionName)
            {
                return string.IsNullOrWhiteSpace(criterionName) ? Criteria.First() : Criteria.Where(c => c.CriterionName == criterionName).First();
            }

            public abstract string CriterionName { get; }
            public abstract string Text { get; }
            
            public abstract IQueryable<ProductInfo> Sort(IQueryable<ProductInfo> products);

            public override string ToString()
            {
                return CriterionName;
            }


        }

        public class SortByName : SortingCriterion
        {
            public override string CriterionName
            {
                get
                {
                    return "name";
                }
            }

            public override string Text
            {
                get
                {
                    return "Name";
                }
            }

            public override IQueryable<ProductInfo> Sort(IQueryable<ProductInfo> products)
            {
                return products.OrderBy(p => p.Name);
            }
        }

        public class SortByPriceAscending : SortingCriterion
        {
            public override string CriterionName
            {
                get
                {
                    return "price";
                }
            }

            public override string Text
            {
                get
                {
                    return "Price: Low to High";
                }
            }

            public override IQueryable<ProductInfo> Sort(IQueryable<ProductInfo> products)
            {
                return products.OrderBy(p => p.Price);
            }
        }

        public class SortByPriceDescending : SortingCriterion
        {
            public override string CriterionName
            {
                get
                {
                    return "-price";
                }
            }

            public override string Text
            {
                get
                {
                    return "Price: High to Low";
                }
            }

            public override IQueryable<ProductInfo> Sort(IQueryable<ProductInfo> products)
            {
                return products.OrderByDescending(p => p.Price);
            }
        }
        #endregion

        public string CategoryName { get; set; }
        public IEnumerable<ProductInfo> Products { get; set; }
     
        public string SelectedSortingCriterionName { get; set; }
        public IEnumerable<ProductCategoryViewModel.SortingCriterion> SortingCriteria
        {
            get
            {
                return ProductCategoryViewModel.SortingCriterion.Criteria;
            }
        }       
    }
}