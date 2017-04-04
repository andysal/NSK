using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using NskServicesClient.Soap;
namespace NskServicesClient
{
    public partial class Form1 : Form
    {
        private readonly string baseSvcUrl = "http://localhost.:1183";

        public Form1()
        {
            InitializeComponent();
        }

        private void btnCategorieSoap_Click(object sender, EventArgs e)
        {
            var svc = new CatalogServicesClient();
            svc.GetProductCategories();
        }

        private void btnCategorieRest_Click(object sender, EventArgs e)
        {
            var svcUrl = string.Format("{0}/Catalog/GetProductCategories", baseSvcUrl);
            var client = HttpWebRequest.Create(svcUrl);
            var response = client.GetResponse();
        }

        private void btnProductsByCategoryS_Click(object sender, EventArgs e)
        {
            var svc = new CatalogServicesClient();
            svc.GetProductsByCategoryId(1);
        }

        private void btnProductsByCategoryR_Click(object sender, EventArgs e)
        {
            var svcUrl = string.Format("{0}/Catalog/GetProductsByCategoryId?categoryId=1", baseSvcUrl);
            var client = HttpWebRequest.Create(svcUrl);
            var response = client.GetResponse();
        }

        private void btnSearchS_Click(object sender, EventArgs e)
        {
            var svc = new CatalogServicesClient();
            svc.SearchInCatalog("c");
        }

        private void btnSearchR_Click(object sender, EventArgs e)
        {
            var svcUrl = string.Format("{0}/Catalog/Search?query=c", baseSvcUrl);
            var client = HttpWebRequest.Create(svcUrl);
            var response = client.GetResponse();
        }
    }
}
