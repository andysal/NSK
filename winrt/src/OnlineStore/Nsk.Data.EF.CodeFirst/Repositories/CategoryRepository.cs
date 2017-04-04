using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Nsk.Domain.Model;
using Nsk.Domain.Repositories;
using System.Data;
using System.IO;

namespace Nsk.Data.EF.CodeFirst.Repositories
{
    public class CategoryRepository : Repository<Category>//, ICategoryRepository
    {
        #region ICategoryRepository implementation

        public System.Drawing.Image GetThumbnailByCategory(int categoryId)
        {
            byte[] imageRawData = null;
            IDbConnection cn = this.ActiveContext.Database.Connection;
            IDbCommand cmd = cn.CreateCommand();
            cmd.CommandText = string.Format("SELECT Picture FROM Categories WHERE CategoryID={0}", categoryId);
            cmd.Connection = cn;
            IDataReader myReader = cmd.ExecuteReader();
            while (myReader.Read())
            {
                imageRawData = (byte[])myReader.GetValue(0);
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


        #endregion
    }
}
