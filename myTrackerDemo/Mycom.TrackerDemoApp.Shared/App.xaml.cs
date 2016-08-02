using System;
using Windows.ApplicationModel;
using Windows.ApplicationModel.Activation;
using Windows.UI;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Media.Animation;
using Windows.UI.Xaml.Navigation;
using Mycom.Tracker;
using Mycom.Tracker.Enums;

namespace Mycom.TrackerDemoApp
{
    sealed partial class App
    {
        private static void OnSuspending(Object sender, SuspendingEventArgs e)
        {
            var deferral = e.SuspendingOperation.GetDeferral();

            deferral.Complete();
        }

        public App()
        {
            InitializeComponent();
            Suspending += OnSuspending;
        }

        protected override void OnLaunched(LaunchActivatedEventArgs e)
        {
            var rootFrame = Window.Current.Content as Frame;
            if (rootFrame == null)
            {
                rootFrame = new Frame
                            {
                                CacheSize = 1,
                                Background = new SolidColorBrush(Colors.Black),
                                ContentTransitions = null,
                                Transitions = new TransitionCollection()
                            };
                Window.Current.Content = rootFrame;
            }

            MyTracker.IsDebugMode = true;
            MyTracker.Create("89232805149757155048");

            var trackerParams = MyTracker.TrackerParams;

            trackerParams.Age = 21;
            trackerParams.Gender = GenderEnum.Male;
            
            MyTracker.Init();

            if (rootFrame.Content == null)
            {
                NavigatedEventHandler firstNavigated = null;
                firstNavigated = (sender, args) =>
                                 {
                                     rootFrame.ContentTransitions = new TransitionCollection { new EdgeUIThemeTransition { Edge = EdgeTransitionLocation.Bottom } };
                                     rootFrame.Navigated -= firstNavigated;
                                 };
                rootFrame.Navigated += firstNavigated;

                if (!rootFrame.Navigate(typeof (MainPage), e.Arguments))
                {
                    throw new Exception("Failed to create initial page");
                }
            }

            Window.Current.Activate();
        }
    }
}