using Nsk.Data.ReadModel;
using System;
using System.Linq;

namespace Nsk.Web.Site.WorkerServices
{
    public class AccountControllerWorkerServices
    {
        public IDatabase Database { get; private set; }

        public AccountControllerWorkerServices(IDatabase database)
        {
            this.Database = database ?? throw new ArgumentNullException(nameof(database));
        }

        public bool IsExistingCustomerId(string customerId)
        {
            return Database.Customers
                            .Where(c => c.Id == customerId)
                            .Count() > 0;
        }
    }
}