using System;
using System.Diagnostics;
using System.Threading.Tasks;
using Windows.ApplicationModel.Core;
using Windows.UI.ViewManagement;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace MultiWindowing
{
    public static class WindowingHelper
    {
        public static async Task CreateNewWindow()
        {
            var newCoreAppView = CoreApplication.CreateNewView();
            var appView = ApplicationView.GetForCurrentView();
            await newCoreAppView.Dispatcher.RunAsync(Windows.UI.Core.CoreDispatcherPriority.Low, async () =>
            {
                var window = Window.Current;
                var newAppView = ApplicationView.GetForCurrentView();

                var frame = new Frame();
                window.Content = frame;
                frame.Navigate(typeof(MainPage));
                window.Activate();

                await ApplicationViewSwitcher.TryShowAsStandaloneAsync(newAppView.Id, ViewSizePreference.UseMore, appView.Id, ViewSizePreference.Default);

#if WINDOWS_UAP
                var success = newAppView.TryResizeView(new Windows.Foundation.Size(400, 400));

                if (success)
                {
                    Debug.WriteLine(success);
                }
#endif
            });
        }
    }
}
