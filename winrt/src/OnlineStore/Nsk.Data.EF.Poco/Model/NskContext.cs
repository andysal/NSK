using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.Entity.Core.Objects;
using System.Linq;
using System.Text;
using Nsk.Domain.Model;

namespace Nsk.Data.EF.Poco.Model
{
    public class NskContext : ObjectContext
    {
        private static readonly string ConnectionString = ConfigurationManager.ConnectionStrings["NskEntities"].ConnectionString;
        private ObjectSet<Category> categories = null;
        private ObjectSet<Customer> customers = null;
        private ObjectSet<Employee> employees = null;
        private ObjectSet<Order> orders = null;
        private ObjectSet<Product> products = null;
        private ObjectSet<Region> regions = null;
        private ObjectSet<Shipper> shippers = null;
        private ObjectSet<Supplier> suppliers = null;
        private ObjectSet<Territory> territories = null;

        public NskContext()
            : base(ConnectionString, "NskEntities") 
        {
            categories = CreateObjectSet<Category>();
            customers = CreateObjectSet<Customer>();
            employees = CreateObjectSet<Employee>();
            orders = CreateObjectSet<Order>();
            products = CreateObjectSet<Product>();
            regions = CreateObjectSet<Region>();
            shippers = CreateObjectSet<Shipper>();
            suppliers = CreateObjectSet<Supplier>();
            territories = CreateObjectSet<Territory>();
        } 
 
        public ObjectSet<Category> Categories 
        { 
            get { return categories; } 
        }

        public ObjectSet<Customer> Customers
        {
            get { return customers; }
        }

        public ObjectSet<Employee> Employees
        {
            get { return employees; }
        }

        public ObjectSet<Order> Orders
        {
            get { return orders; }
        }

        public ObjectSet<Product> Products
        {
            get { return products; }
        }

        public ObjectSet<Region> Regions
        {
            get { return regions; }
        }

        public ObjectSet<Shipper> Shippers
        {
            get { return shippers; }
        }

        public ObjectSet<Supplier> Suppliers
        {
            get { return suppliers; }
        }

        public ObjectSet<Territory> Territories
        {
            get { return territories; }
        }
    }
}
