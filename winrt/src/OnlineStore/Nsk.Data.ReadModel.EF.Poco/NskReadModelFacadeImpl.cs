using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.Entity;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text;
using Nsk.Domain.ReadModel;
using System.Data.Entity.Core.Objects;
using System.Data.Entity.Core.EntityClient;

namespace Nsk.Data.ReadModel.EF.Poco
{
    public class NskReadModelFacadeImpl : ObjectContext, IReadModelFacade
    {
        private static readonly string ConnectionString = ConfigurationManager.ConnectionStrings["NskReadModel"].ConnectionString;
        private ObjectSet<Category> categories = null;
        private ObjectSet<Customer> customers = null;
        private ObjectSet<Employee> employees = null;
        private ObjectSet<Order> orders = null;
        private ObjectSet<Product> products = null;
        private ObjectSet<Region> regions = null;
        private ObjectSet<Shipper> shippers = null;
        private ObjectSet<Supplier> suppliers = null;
        private ObjectSet<Territory> territories = null;

        public NskReadModelFacadeImpl()
            : base(ConnectionString) 
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

        public IQueryable<Category> Categories
        {
            get { return categories; }
        }

        public IQueryable<Customer> Customers
        {
            get { return customers; }
        }

        public IQueryable<Employee> Employees
        {
            get { return employees; }
        }

        public IQueryable<Order> Orders
        {
            get { return orders; }
        }

        public IQueryable<Product> Products
        {
            get { return products; }
        }

        public IQueryable<Region> Regions
        {
            get { return regions; }
        }

        public IQueryable<Shipper> Shippers
        {
            get { return shippers; }
        }

        public IQueryable<Supplier> Suppliers
        {
            get { return suppliers; }
        }

        public IQueryable<Territory> Territories
        {
            get { return territories; }
        }

        public System.Drawing.Image GetThumbnailByCategory(int categoryId)
        {
            byte[] imageRawData = null;
            IDbConnection cn = (this.Connection as EntityConnection).StoreConnection;
            using (IDbCommand cmd = cn.CreateCommand())
            {
                cmd.CommandText = "SELECT Picture FROM Categories WHERE CategoryID=" + categoryId;
                cmd.Connection = cn;
                cn.Open();
                using (IDataReader myReader = cmd.ExecuteReader(CommandBehavior.CloseConnection))
                {
                    while (myReader.Read())
                    {
                        imageRawData = (byte[])myReader.GetValue(0);
                    }
                }    
            }
            return byteArrayToImage(imageRawData, true);
        }

        private System.Drawing.Image byteArrayToImage(byte[] byteArrayIn, bool stripOleHeader)
        {
            int strippedImageLength = byteArrayIn.Length - (stripOleHeader ? 78 : 0);
            byte[] strippedImageData = new byte[strippedImageLength];
            Array.Copy(byteArrayIn, (stripOleHeader ? 78 : 0), strippedImageData, 0, strippedImageLength);
            MemoryStream ms = new MemoryStream(strippedImageData);
            return System.Drawing.Image.FromStream(ms);
        }
    }
}
