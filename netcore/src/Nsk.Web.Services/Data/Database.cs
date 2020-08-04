using System;
using System.IO;
using System.Data;
using System.Data.SqlClient;
using SixLabors.ImageSharp;
using SixLabors.ImageSharp.PixelFormats;

namespace Nsk.Web.Services.Data
{
    public class Database : IDatabase
    {
        public string ConnectionString
        {
            get;
            private set;
        }

        public Database(string connectionString)
        {
            ConnectionString = connectionString ?? throw new ArgumentNullException(nameof(connectionString));    
        }

        public Image<Rgba32> GetCategoryThumbnail(int categoryId)
        {
            byte[] imageRawData = null;
            var connectionString = this.ConnectionString;
            using(var cn = new SqlConnection(connectionString))
            using(IDbCommand cmd = cn.CreateCommand())
            {
                cmd.CommandText = $"SELECT Picture FROM Categories WHERE CategoryID={categoryId}";
                cmd.Connection = cn;
                cn.Open();
                using IDataReader myReader = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                while (myReader.Read())
                {
                    imageRawData = (byte[])myReader.GetValue(0);
                }
            }
            return ByteArrayToImage(imageRawData, true);
        }

        public Image<Rgba32> GetProductThumbnail(int productId)
        {
            var connectionString = this.ConnectionString;
            using (var cn = new SqlConnection(connectionString))
            using (IDbCommand cmd = cn.CreateCommand())
            {
                cmd.CommandText = $"SELECT CategoryID FROM Products WHERE ProductID={productId}";
                cmd.Connection = cn;
                cn.Open();
                var categoryId = (int) cmd.ExecuteScalar();
                return GetCategoryThumbnail(categoryId);
            }
        }

        private Image<Rgba32> ByteArrayToImage(byte[] byteArrayIn, bool stripOleHeader)
        {
            int strippedImageLength = byteArrayIn.Length - (stripOleHeader ? 78 : 0);
            byte[] strippedImageData = new byte[strippedImageLength];
            Array.Copy(byteArrayIn, (stripOleHeader ? 78 : 0), strippedImageData, 0, strippedImageLength);
            var ms = new MemoryStream(strippedImageData);
            return Image.Load(ms);
        }
    }
}
