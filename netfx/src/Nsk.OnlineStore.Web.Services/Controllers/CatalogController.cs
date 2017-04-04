using Nsk.OnlineStore.Data.ReadModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Nsk.OnlineStore.Web.Services.Controllers
{
    public class CatalogController
    {
        public IDatabase Database { get; private set; }

        public CatalogController(IDatabase database)
        {
            if (database == null)
                throw new ArgumentNullException("database");

            this.Database = database;
        }


    }
}