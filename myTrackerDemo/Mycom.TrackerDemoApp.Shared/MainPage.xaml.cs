using System;
using System.Collections.Generic;
using Windows.UI.Xaml;
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