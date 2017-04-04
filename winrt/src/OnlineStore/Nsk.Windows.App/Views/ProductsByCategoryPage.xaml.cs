using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Nsk.Windows.App.Models;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Grouped Items Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234231

namespace Nsk.Windows.App.Views
{
    /// <summary>
    /// A page that displays a grouped collection of items.
    /// </summary>
    public sealed partial class ProductsByCategoryPage : Nsk.Windows.App.Common.LayoutAwarePage
    {
        private int? categoryId = null;

        public ProductsByCategoryPage()
        {
            this.InitializeComponent();
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
            // TODO: Assign a collection of bindable groups to this.DefaultViewModel["Groups"]
        }

        /// <summary>
        /// Invoked when this page is about to be displayed in a Frame.
        /// </summary>
        /// <param name="e">Event data that describes how this page was reached.  The Parameter
        /// property is typically used to configure the page.</param>
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);
            categoryId = (int)e.Parameter;
            RefreshData();
        }

        private void ItemView_ItemClick(object sender, ItemClickEventArgs e)
        {
            int productId = int.Parse((e.ClickedItem as SampleDataItem).UniqueId);
            this.Frame.Navigate(typeof(ProductDetailPage), productId);
        }

        private void RefreshData()
        {
            if (categoryId.HasValue)
            {
                var svc = new CatalogServicesClient();
                var products = from p in svc.GetProductsByCategoryIdAsync(categoryId.Value).Result
                               orderby p.Name
                               select new SampleDataItem(
                                              p.Id.ToString(),
                                              p.Name,
                                              p.UnitPrice.ToString(),
                                              string.Empty,
                                              string.Empty,
                                              string.Empty,
                                              null
                                          );
                this.DefaultViewModel["Items"] = products;
            }
        }

        private void RefreshButton_Click(object sender, RoutedEventArgs e)
        {
            RefreshData();
        }

        private void HelpButton_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
