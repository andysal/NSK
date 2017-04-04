using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nsk.Metro.Shopper.Services
{
    public static class CatalogServices
    {
        public static ICatalogServices Current { get; private set; }

        static CatalogServices()
        {
            Current = new JsonCatalogServices();
        }
    }
}
