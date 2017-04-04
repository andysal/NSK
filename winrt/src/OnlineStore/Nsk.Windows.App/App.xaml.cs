using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Nsk.Windows.App.Views;
using Windows.ApplicationModel;
using Windows.ApplicationModel.Activation;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.System;
using Windows.UI.ApplicationSettings;
using Windows.UI.Core;
using Windows.UI.Popups;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Application template is documented at http://go.microsoft.com/fwlink/?LinkId=234227

namespace Nsk.Windows.App
{
    /// <summary>
    /// Provides application-specific behavior to supplement the default Application class.
    /// </summary>
    sealed partial class App : Application
    {
        Popup _settingsPopup;

        /// <summary>
        /// Initializes the singleton application object.  This is the first line of authored code
        /// executed, and as such is the logical equivalent of main() or WinMain().
        /// </summary>
        public App()
        {
            this.InitializeComponent();
            this.Suspending += OnSuspending;
            DebugSettings.BindingFailed += OnDebugSettingsOnBindingFailed;
        }

        private void OnDebugSettingsOnBindingFailed(object sender, BindingFailedEventArgs e)
        {
            new MessageDialog(e.Message).ShowAsync();
        }

        /// <summary>
        /// Invoked when the application is launched normally by the end user.  Other entry points
        /// will be used when the application is launched to open a specific file, to display
        /// search results, and so forth.
        /// </summary>
        /// <param name="args">Details about the launch request and process.</param>
        protected override void OnLaunched(LaunchActivatedEventArgs args)
        {
            Frame rootFrame = Window.Current.Content as Frame;

            // Do not repeat app initialization when the Window already has content,
            // just ensure that the window is active
            if (rootFrame == null)
            {
                // Create a Frame to act as the navigation context and navigate to the first page
                rootFrame = new Frame();

                if (args.PreviousExecutionState == ApplicationExecutionState.Terminated)
                {
                    //TODO: Load state from previously suspended application
                }

                // Place the frame in the current Window
                Window.Current.Content = rootFrame;
            }

            if (rootFrame.Content == null)
            {
                // When the navigation stack isn't restored navigate to the first page,
                // configuring the new page by passing required information as a navigation
                // parameter
                if (!rootFrame.Navigate(typeof(MainPage), args.Arguments))
                {
                    throw new Exception("Failed to create initial page");
                }
            }
            // Ensure the current window is active
            Window.Current.Activate();
        }

        /// <summary>
        /// Invoked when application execution is being suspended.  Application state is saved
        /// without knowing whether the application will be terminated or resumed with the contents
        /// of memory still intact.
        /// </summary>
        /// <param name="sender">The source of the suspend request.</param>
        /// <param name="e">Details about the suspend request.</param>
        private void OnSuspending(object sender, SuspendingEventArgs e)
        {
            var deferral = e.SuspendingOperation.GetDeferral();
            //TODO: Save application state and stop any background activity
            deferral.Complete();
        }

        private void App_CommandsRequested(SettingsPane sender, SettingsPaneCommandsRequestedEventArgs args)
        {
            args.Request.ApplicationCommands.Add(new SettingsCommand("visit", "Visit ManagedDesigns.it",
                                                    a =>
                                                    {
                                                        Launcher.LaunchUriAsync(new Uri("http://www.manageddesigns.it"));
                                                    }));
            args.Request.ApplicationCommands.Add(new SettingsCommand("about", "About",
                                                    a =>
                                                    {
                                                        ((Frame)Window.Current.Content).Navigate(typeof(AboutPage));
                                                    }));
            //var SettingsWidth = 346;
            //args.Request.ApplicationCommands.Add(
            //        new SettingsCommand("settings", "Settings",
            //            a =>
            //            {
            //                _settingsPopup = new Popup();
            //                _settingsPopup.Closed += OnPopupClosed;
            //                Window.Current.Activated += OnWindowActivated;

            //                _settingsPopup.IsLightDismissEnabled = true;
            //                _settingsPopup.Width = SettingsWidth;
            //                _settingsPopup.Height = Window.Current.Bounds.Height;

            //                var mypane = new SettingsUserControl();
            //                mypane.Width = SettingsWidth;
            //                mypane.Height = Window.Current.Bounds.Height;
            //                _settingsPopup.Child = mypane;
            //                _settingsPopup.SetValue(Canvas.LeftProperty, Window.Current.Bounds.Width - SettingsWidth);
            //                _settingsPopup.SetValue(Canvas.TopProperty, 0);
            //                _settingsPopup.IsOpen = true;
            //            }));
        }

        private void OnWindowActivated(object sender, WindowActivatedEventArgs e)
        {
            //throw new NotImplementedException();
        }

        private void OnPopupClosed(object sender, object e)
        {
            //throw new NotImplementedException();
        }

        /// <summary>
        /// Invoked when the application is activated to display search results.
        /// </summary>
        /// <param name="args">Details about the activation request.</param>
        protected override void OnSearchActivated(SearchActivatedEventArgs args)
        {
            var previousContent = Window.Current.Content;
            var frame = previousContent as Frame;

            if (frame != null)
            {
                // If the app is already running and uses top-level frame navigation we can just
                // navigate to the search results
                frame.Navigate(typeof(SearchResultPage), args.QueryText);
            }
            else
            {
                // Otherwise bypass navigation and provide the tools needed to emulate the back stack
                //SearchResultsView page = new SearchResultsView();
                //page._previousContent = previousContent;
                //page._previousExecutionState = previousExecutionState;
                //page.LoadState( queryText, null );
                //Window.Current.Content = page;
            }

            // Either way, active the window
            Window.Current.Activate();
        }
    }
}
