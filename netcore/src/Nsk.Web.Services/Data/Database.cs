using System;
using System.IO;
using System.Drawing;
using System.Data;
using System.Data.SqlClient;

namespace Nsk.Web.Services.Data
{
    public class Database : IDatabase
    {
        public Image GetCategoryThumbnail(int categoryId)
        {
            byte[] imageRawData = null;
            var connectionString = Startup.ConnectionString;
            using(var cn = new SqlConnection(connectionString))
            using(IDbCommand cmd = cn.CreateCommand())
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

        public Image GetProductThumbnail(int productId)
        {
            var connectionString = Startup.ConnectionString;
            using (var cn = new SqlConnection(connectionString))
            using (IDbCommand cmd = cn.CreateCommand())
            {
                cmd.CommandText = "SELECT CategoryID FROM Products WHERE ProductID=" + productId.ToString();
                cmd.Connection = cn;
                cn.Open();
                var categoryId = (int) cmd.ExecuteScalar();
                return GetCategoryThumbnail(categoryId);
            }
        }

        private System.Drawing.Image byteArrayToImage(byte[] byteArrayIn, bool stripOleHeader)
        {
            int strippedImageLength = byteArrayIn.Length - (stripOleHeader ? 78 : 0);
            byte[] strippedImageData = new byte[strippedImageLength];
            Array.Copy(byteArrayIn, (stripOleHeader ? 78 : 0), strippedImageData, 0, strippedImageLength);
            var ms = new MemoryStream(strippedImageData);
            return System.Drawing.Image.FromStream(ms);
        }
    }
}
