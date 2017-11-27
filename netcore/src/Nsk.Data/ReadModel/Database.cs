using System.Linq;
using Nsk.Data.Model;
using Microsoft.EntityFrameworkCore;
using System;

namespace Nsk.Data.ReadModel
{
    public class Database : IDatabase
    {
        private NorthwindContext Context;

        public Database(NorthwindContext context)
        {
            Context = context ?? throw new ArgumentNullException(nameof(context));
            Context.ChangeTracker.AutoDetectChangesEnabled = false;
        }

        public IQueryable<Category> Categories
        {
            get
            {
                return Context.Categories;
            }
        }

        public IQueryable<Customer> Customers
        {
            get
            {
                return Context.Customers;
            }
        }

        public IQueryable<Product> Products
        {
            get
            {
                return Context.Products;
            }
        }

        public IQueryable<Supplier> Suppliers
        {
            get
            {
                return Context.Suppliers;
            }
        }

        public ShoppingCart GetCurrentCart()
        {
            return ShoppingCart.GetCart();
        }

        //public Image GetCategoryThumbnail(int categoryId)
        //{
        //    byte[] imageRawData = null;
        //    var cn = (SqlConnection)this.Context.Database.Connection;
        //    using (IDbCommand cmd = cn.CreateCommand())
        //    {
        //        cmd.CommandText = "SELECT Picture FROM Categories WHERE CategoryID=" + categoryId;
        //        cmd.Connection = cn;
        //        cn.Open();
        //        using (IDataReader myReader = cmd.ExecuteReader(CommandBehavior.CloseConnection))
        //        {
        //            while (myReader.Read())
        //            {
        //                imageRawData = (byte[])myReader.GetValue(0);
        //            }
        //        }
        //    }
        //    return byteArrayToImage(imageRawData, true);
        //}

        //private System.Drawing.Image byteArrayToImage(byte[] byteArrayIn, bool stripOleHeader)
        //{
        //    int strippedImageLength = byteArrayIn.Length - (stripOleHeader ? 78 : 0);
        //    byte[] strippedImageData = new byte[strippedImageLength];
        //    Array.Copy(byteArrayIn, (stripOleHeader ? 78 : 0), strippedImageData, 0, strippedImageLength);
        //    var ms = new MemoryStream(strippedImageData);
        //    return System.Drawing.Image.FromStream(ms);
        //}
    }
}
