using Nsk.Metro.Shopper.Domain.Events;
using Nsk.Metro.Shopper.Soap;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Windows.ApplicationModel.DataTransfer;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Basic Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234237

namespace Nsk.Metro.Shopper.Views
{
    /// <summary>
    /// A basic page that provides characteristics common to most applications.
    /// </summary>
    public sealed partial class ProductDetailPage : Nsk.Metro.Shopper.Common.LayoutAwarePage
    {
        public int ProductId { get; private set; }

        public ProductDetailPage()
        {
            this.InitializeComponent();
            var dataTransferManager = DataTransferManager.GetForCurrentView();
            dataTransferManager.DataRequested += new TypedEventHandler<DataTransferManager, DataRequestedEventArgs>(ProductDetailPage_DataRequested);
        }

        /// <summary>
        /// Populates the page with content passed during navigation.  Any saved state is also
        /// provided when recreating a page from a prior session.
        /// </summary>
        /// <param name="navigationParameter">The parameter value passed to
        /// <see cref="Frame.Navigate(Type, Object)"/> when this page was initially requested.
        /// </param>
        /// <param name="pageState">A dictionary of state preserved by this page during an earlier
        /// session.  This will be null the first time a page is visited.</param>
        protected override void LoadState(Object navigationParameter, Dictionary<String, Object> pageState)
        {
            this.ProductId = (int) navigationParameter;
            RefreshData();
        }

        /// <summary>
        /// Preserves state associated with this page in case the application is suspended or the
        /// page is discarded from the navigation cache.  Values must conform to the serialization
        /// requirements of <see cref="SuspensionManager.SessionState"/>.
        /// </summary>
        /// <param name="pageState">An empty dictionary to be populated with serializable state.</param>
        protected override void SaveState(Dictionary<String, Object> pageState)
        {
            pageState["productId"] = this.ProductId;
        }

        private void RefreshButton_Click(object sender, RoutedEventArgs e)
        {
            RefreshData();
        }

        private void HelpButton_Click(object sender, RoutedEventArgs e)
        {         

        }

        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            var product = GetProduct();
            var @event = new ProductAdded()
            {
                ProductId = this.ProductId,
                UnitPrice = product.UnitPrice.Value
            };
            Bus.Send(@event);

        }

        private void ProductDetailPage_DataRequested(DataTransferManager sender, DataRequestedEventArgs args)
        {            
            if (this.ProductId <= 0)
            {
                args.Request.FailWithDisplayText("No product selected");
            }
            else
            {
                var message = string.Format("Hi, I really think you can't miss <a href=\"http://nsk.manageddesigns.it/Catalog/Product/{0}\">this</a>", this.ProductId);
                string htmlFormat = HtmlFormatHelper.CreateHtmlFormat(message);
                          
                var request = args.Request;
                request.Data.Properties.Description = "NSK is sharing a link to a product";
                request.Data.Properties.Title = "An advice for you from the Northwind Online Store";
                request.Data.SetHtmlFormat(htmlFormat);
            }
        }

        private void RefreshData()
        {
            var product = GetProduct();
            this.DefaultViewModel["ProductName"] = product.Name;
            this.DefaultViewModel["UnitPrice"] = string.Format("List price: {0:0.00} $", product.UnitPrice);
            this.DefaultViewModel["UnitsInStock"] = string.Format("Units in stock: {0}", product.UnitsInStock);
            this.DefaultViewModel["QuantityPerUnit"] = product.QuantityPerUnit;
        }

        private ProductDetailInfo GetProduct()
        {
            var svc = new CatalogServicesClient();
            var product = svc.GetProductDetailInformationsAsync(this.ProductId).Result;
            return product;
        }
    }
}
