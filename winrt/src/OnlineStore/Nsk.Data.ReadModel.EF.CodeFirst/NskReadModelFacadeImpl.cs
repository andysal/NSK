using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text;
using Nsk.Domain.ReadModel;
using Nsk.Data.ReadModel.EF.CodeFirst.Mapping;

namespace Nsk.Data.ReadModel.EF.CodeFirst
{
    public class NskReadModelFacadeImpl : DbContext, IReadModelFacade
    {
        public NskReadModelFacadeImpl()
            : base("NskEntities")
        {
            _categories = base.Set<Category>();
            _products = base.Set<Product>();
            _employees = base.Set<Employee>();
            _orders = base.Set<Order>();
            _orderItems = base.Set<OrderItem>();
            _products = base.Set<Product>();
            _regions = base.Set<Region>();
            _shippers = base.Set<Shipper>();
            _suppliers = base.Set<Supplier>();
            _territories = base.Set<Territory>();
        }

        private DbSet<Category> _categories = null;
        private DbSet<Customer> _customers = null;
        private DbSet<Employee> _employees = null;
        private DbSet<Order> _orders = null;
        private DbSet<OrderItem> _orderItems = null;
        private DbSet<Product> _products = null;
        private DbSet<Region> _regions = null;
        private DbSet<Shipper> _shippers = null;
        private DbSet<Supplier> _suppliers = null;
        private DbSet<Territory> _territories = null;

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<IncludeMetadataConvention>();
            modelBuilder.Conventions.Remove<System.Data.Entity.ModelConfiguration.Conventions.OneToManyCascadeDeleteConvention>();

            modelBuilder.ComplexType<PostalAddress>();
            modelBuilder.Configurations.Add(new CategoryMap());
            modelBuilder.Configurations.Add(new CustomerMap());
            modelBuilder.Configurations.Add(new EmployeeMap());
            modelBuilder.Configurations.Add(new OrderItemMap());
            modelBuilder.Configurations.Add(new OrderMap());
            modelBuilder.Configurations.Add(new ProductMap());
            modelBuilder.Configurations.Add(new RegionMap());
            modelBuilder.Configurations.Add(new ShipperMap());
            modelBuilder.Configurations.Add(new SupplierMap());
            modelBuilder.Configurations.Add(new TerritoryMap());
        }
     
        static NskReadModelFacadeImpl()
        {
            Database.SetInitializer<NskReadModelFacadeImpl>(null);
        }

        public IQueryable<Category> Categories
        {
            get { return _categories; }
        }

        public IQueryable<Customer> Customers
        {
            get { return _customers; }
        }

        public IQueryable<Employee> Employees
        {
            get { return _employees; }
        }

        public IQueryable<Order> Orders
        {
            get { return _orders; }
        }

        public IQueryable<Product> Products
        {
            get { return _products; }
        }

        public IQueryable<Region> Regions
        {
            get { return _regions; }
        }

        public IQueryable<Shipper> Shippers
        {
            get { return _shippers; }
        }

        public IQueryable<Supplier> Suppliers
        {
            get { return _suppliers; }
        }

        public IQueryable<Territory> Territories
        {
            get { return _territories; }
        }

        public System.Drawing.Image GetThumbnailByCategory(int categoryId)
        {
            byte[] imageRawData = null;
            var cn = (SqlConnection) this.Database.Connection;
            using (var cmd = new SqlCommand("SELECT Picture FROM Categories WHERE CategoryID=" + categoryId, cn))
            {
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
