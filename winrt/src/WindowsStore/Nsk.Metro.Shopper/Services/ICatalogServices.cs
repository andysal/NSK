using Nsk.Metro.Shopper.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nsk.Metro.Shopper.Services
{
    public interface ICatalogServices
    {
        IEnumerable<SampleDataItem> GetProductCategories();
        IEnumerable<SampleDataItem> GetProductsByCategoryId(int categoryId);
        IEnumerable<SampleDataGroup> Search(string query);
    }
}
