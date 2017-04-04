using Nsk.OnlineStore.Data.ReadModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Nsk.OnlineStore.Web.Site.WorkerServices
{
    public class AccountControllerWorkerServices
    {
        public IDatabase Database { get; private set; }

        public AccountControllerWorkerServices(IDatabase database)
        {
            if (database == null)
                throw new ArgumentNullException("database");
            this.Database = database;
        }

        public bool IsExistingCustomerId(string customerId)
        {
            return Database.Customers
                            .Where(c => c.Id == customerId)
                            .Count() > 0;
        }
    }
}