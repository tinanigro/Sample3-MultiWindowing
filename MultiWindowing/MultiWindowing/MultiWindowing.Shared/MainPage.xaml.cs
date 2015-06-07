using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
namespace MultiWindowing
{
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
        }

        private async void CreateWindow(object sender, RoutedEventArgs e)
        {
            await WindowingHelper.CreateNewWindow();
        }
    }
}
