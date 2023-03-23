using KP11.WPFApplication.MVVM.Model;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace KP11.WPFApplication.MVVM.View
{
    /// <summary>
    /// Interaction logic for ManualViewPage.xaml
    /// </summary>
    public partial class ManualViewPage : Page
    {
        public ManualModel Manual { get; set; }

        private ManualSelection _manualSelection;

        public ManualViewPage(ManualModel manual, ManualSelection manualSelection)
        {
            InitializeComponent();
            Manual = manual;
            DataContext = manual;

            _manualSelection = manualSelection;
            DrawIcons();
        }

        private void ButtonClose_Click(object sender, RoutedEventArgs e)
        {
            _manualSelection.FrameSingleManual.Content = null;
        }

        private void Grid_MouseDown(object sender, MouseButtonEventArgs e)
        {
            Process.Start(new ProcessStartInfo(Manual.ContentLink) { UseShellExecute = true });
        }

        private void DrawIcons()
        {
            Uri url = new(Manual.ContentLink);
            string faviconURL = url.Scheme + "://" + url.Host + "/favicon.ico";

            BitmapImage icon = new();
            icon.BeginInit();
            icon.UriSource = new(faviconURL, UriKind.Absolute);
            icon.EndInit();

            ImageWebsiteIcon.Source = icon;
            ImageWebsiteIconCenter.Source = icon;
        }
    }
}
