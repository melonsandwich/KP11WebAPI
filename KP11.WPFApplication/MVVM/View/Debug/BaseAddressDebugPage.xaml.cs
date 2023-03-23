using System.Windows;
using System.Windows.Controls;

namespace KP11.WPFApplication.MVVM.View.Debug
{
    /// <summary>
    /// Interaction logic for BaseAddressDebugPage.xaml
    /// </summary>
    public partial class BaseAddressDebugPage : Page
    {
        public BaseAddressDebugPage()
        {
            InitializeComponent();
        }

        private void ButtonStart_Click(object sender, RoutedEventArgs e)
        {
            AppFields.Client = new(TextBoxIP.Text);
            AppFields.MainWindow.Content = new MainPage();
        }
    }
}
