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

namespace Nsk.Domain.ReadModel
{
    class NskReadModelFacadeImpl : NskReadModel, IReadModelFacade
    {
        public IQueryable<Category> Categories
        {
            get { return base.Categories; }
        }

        public IQueryable<Customer> Customers
        {
            get { return base.Customers; }
        }

        public IQueryable<Employee> Employees
        {
            get { return base.Employees; }
        }

        public IQueryable<Order> Orders
        {
            get { return base.Orders; }
        }

        public IQueryable<Product> Products
        {
            get { return base.Products; }
        }

        public IQueryable<Region> Regions
        {
            get { return base.Regions; }
        }

        public IQueryable<Shipper> Shippers
        {
            get { return base.Shippers; }
        }

        public IQueryable<Supplier> Suppliers
        {
            get { return base.Suppliers; }
        }

        public IQueryable<Territory> Territories
        {
            get { return base.Territories; }
        }

        public System.Drawing.Image GetThumbnailByCategory(int categoryId)
        {
            byte[] imageRawData = null;
            var cn = (SqlConnection)this.Database.Connection;
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
