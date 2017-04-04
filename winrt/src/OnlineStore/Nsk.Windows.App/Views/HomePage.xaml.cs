using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
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

// The Basic Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234237

namespace Nsk.Windows.App.Views
{
    /// <summary>
    /// A basic page that provides characteristics common to most applications.
    /// </summary>
    public sealed partial class HomePage : Nsk.Windows.App.Common.LayoutAwarePage
    {
        public HomePage()
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
            // TODO: Assign a bindable collection of items to this.DefaultViewModel["Items"]
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
        }

        /// <summary>
        /// Invoked when this page is about to be displayed in a Frame.
        /// </summary>
        /// <param name="e">Event data that describes how this page was reached.  The Parameter
        /// property is typically used to configure the page.</param>
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);
            RefreshData();
        }

        private async void RefreshData()
        {
            var svc = new CatalogServicesClient();
            Task<ObservableCollection<ProductCategoryInfo>> categoryFetcher = svc.GetProductCategoriesAsync();
            var categories = await categoryFetcher;
            this.DefaultViewModel["Items"] = from c in categories
                                             orderby c.Name
                                             select new SampleDataItem(
                                                 c.Id.ToString(),
                                                 c.Name,
                                                 c.Description,
                                                 svc.GetImageUrlByCategoryIdAsync(c.Id).Result,
                                                 c.Description,
                                                 string.Empty,
                                                 null
                                             );
        }

        private void ItemView_ItemClick(object sender, ItemClickEventArgs e)
        {
            int categoryId = int.Parse((e.ClickedItem as SampleDataItem).UniqueId);
            this.Frame.Navigate(typeof(ProductsByCategoryPage), categoryId);
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
