using Nsk.Metro.Shopper.Domain.Events;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nsk.Metro.Shopper
{
    class Bus
    {
        static string dbPath = null;

        static Bus()
        {
            dbPath = Path.Combine(Windows.Storage.ApplicationData.Current.LocalFolder.Path, "db.sqlite");
        }

        public static void Init()
        {           
            using (var db = new SQLite.SQLiteConnection(dbPath))
            {
                db.CreateTable<ProductAdded>();
            }
        }

        public static void Send<T>(T @event)
        {
            using (var db = new SQLite.SQLiteConnection(dbPath))
            {
                db.Insert(@event);
            }
        }
    }
}
