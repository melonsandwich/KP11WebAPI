using KP11.Integration;
using KP11.WPFApplication.Extensions;
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
    /// Interaction logic for ManualEditPage.xaml
    /// </summary>
    public partial class ManualEditPage : Page
    {
        public ManualModel Manual { get; set; }

        private ManualSelection _manualSelection;

        private bool AreFieldsEmpty => string.IsNullOrEmpty(TextBoxManualName.Text) || string.IsNullOrEmpty(TextBoxManualName.Text);

        public ManualEditPage(ManualModel manual, ManualSelection manualSelection)
        {
            InitializeComponent();

            DataContext = manual;

            Manual = manual;
            _manualSelection = manualSelection;
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            LabelFieldEmptyWarning.Visibility = AreFieldsEmpty
                ? Visibility.Visible
                : Visibility.Hidden;
        }

        private async void ButtonSave_Click(object sender, RoutedEventArgs e)
        {
            if (AreFieldsEmpty) return;

            ManualModel manual = new()
            {
                ID = Manual.ID,
                Name = TextBoxManualName.Text,
                ContentLink = TextBoxManualContentLink.Text,
                SubjectID = Manual.SubjectID
            };

            await API.Manuals.Update(AppFields.Client.HttpClient, manual.ConvertToAPIModel());
            CloseWindow();
            _manualSelection.Update();
        }

        private async void ButtonDelete_Click(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show("Вы действительно хотите удалить данное пособие?", "Опасно", MessageBoxButton.YesNo, MessageBoxImage.Exclamation) == MessageBoxResult.Yes)
            {
                await API.Manuals.Delete(AppFields.Client.HttpClient, Manual.ID);
                CloseWindow();
                _manualSelection.Update();
            }
        }

        private void ButtonClose_Click(object sender, RoutedEventArgs e)
        {
            CloseWindow();
        }

        private void CloseWindow()
        {
            _manualSelection.FrameSingleManual.Content = null;
        }
    }
}
