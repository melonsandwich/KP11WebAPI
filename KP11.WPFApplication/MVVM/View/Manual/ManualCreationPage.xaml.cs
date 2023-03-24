using KP11.Integration.Models;
using KP11.Integration;
using KP11.WPFApplication.MVVM.Model;
using System;
using System.Collections.Generic;
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
    /// Interaction logic for ManualCreationPage.xaml
    /// </summary>
    public partial class ManualCreationPage : Page
    {
        private bool AreFieldsEmpty => string.IsNullOrEmpty(TextBoxManualName.Text) || string.IsNullOrEmpty(TextBoxManualName.Text);

        private readonly ManualSelection _manualSelection;

        public ManualCreationPage(ManualSelection manualSelection)
        {
            _manualSelection = manualSelection;
            InitializeComponent();
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            LabelFieldEmptyWarning.Visibility = AreFieldsEmpty
                ? Visibility.Visible
                : Visibility.Hidden;
        }

        private void ButtonClose_Click(object sender, RoutedEventArgs e)
        {
            CloseWindow();
        }

        private async void ButtonCreate_Click(object sender, RoutedEventArgs e)
        {
            if (AreFieldsEmpty) return;

            Manual manual = new()
            {
                Name = TextBoxManualName.Text,
                ContentLink = TextBoxManualContentLink.Text,
                SubjectID = _manualSelection.Subject.ID
            };

            await API.Manuals.Add(AppFields.Client.HttpClient, manual);
            CloseWindow();
            _manualSelection.Update();
        }

        private void CloseWindow()
        {
            _manualSelection.FrameSingleManual.Content = null;
        }
    }
}
