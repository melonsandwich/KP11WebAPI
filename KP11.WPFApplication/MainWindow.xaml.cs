using KP11.WPFApplication.MVVM.View.Debug;
using System.Windows;

namespace KP11.WPFApplication
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            AppFields.MainWindow = this;
            MainFrame.Content = new BaseAddressDebugPage();
        }

        public void ChangeContent(object content)
        {
            MainFrame.Content = content;
        }
    }
}