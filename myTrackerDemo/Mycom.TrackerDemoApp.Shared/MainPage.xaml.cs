using System;
using System.Collections.Generic;
using Windows.ApplicationModel.Store;
using Windows.Storage;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Input;
using Mycom.Tracker;

namespace Mycom.TrackerDemoApp
{
    public sealed partial class MainPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private void OnTrackCustomClick(Object sender, RoutedEventArgs e)
        {
            var customParams = new Dictionary<String, String>
                               {
                                   { "param0", "value0" },
                                   { "param1", "value1" },
                                   { "param2", "value2" }
                               };
            MyTracker.TrackEvent("CustoEvent", customParams);
        }

        private async void OnTrackInAppPurchaseClick(Object sender, TappedRoutedEventArgs e)
        {
            var file = await StorageFile.GetFileFromApplicationUriAsync(new Uri("ms-appx:///WindowsStoreProxy.xml"));

            await CurrentAppSimulator.ReloadSimulatorAsync(file);

            const String productId = "Durable1";

            var purchaseResults = await CurrentAppSimulator.RequestProductPurchaseAsync(productId);

            MyTracker.TrackPurchaseEvent(productId,
                                         purchaseResults.TransactionId,
                                         purchaseResults.OfferId,
                                         purchaseResults.ReceiptXml,
                                         purchaseResults.Status);
        }

        private void OnTrackInviteClick(Object sender, RoutedEventArgs e)
        {
            MyTracker.TrackInviteEvent();
        }

        private void OnTrackLevelClick(Object sender, RoutedEventArgs e)
        {
            var text = Level.Text;
            Int32 level;
            if (Int32.TryParse(text, out level))
            {
                MyTracker.TrackLevelEvent(level);
            }
        }

        private void OnTrackLoginClick(Object sender, RoutedEventArgs e)
        {
            MyTracker.TrackLoginEvent();
        }

        private void OnTrackRegistrationClick(Object sender, RoutedEventArgs e)
        {
            MyTracker.TrackRegistrationEvent();
        }
    }
}