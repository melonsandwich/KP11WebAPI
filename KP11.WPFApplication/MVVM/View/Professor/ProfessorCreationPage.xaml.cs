using KP11.Integration.Models;
using KP11.Integration;
using System.Windows;
using System.Windows.Controls;
using System.Text.RegularExpressions;
using System.Windows.Input;

namespace KP11.WPFApplication.MVVM.View
{
    /// <summary>
    /// Interaction logic for ProfessorCreationPage.xaml
    /// </summary>
    public partial class ProfessorCreationPage : Page
    {
        private bool IsFieldEmpty => string.IsNullOrEmpty(TextBoxProfessorName.Text);

        private ProfessorSelection _professorSelection;

        public ProfessorCreationPage(ProfessorSelection professorSelection)
        {
            InitializeComponent();

            _professorSelection = professorSelection;
        }

        private void TextBoxProfessorName_TextChanged(object sender, TextChangedEventArgs e)
        {
            LabelFieldEmptyWarning.Visibility = IsFieldEmpty
                ? Visibility.Visible
                : Visibility.Hidden;
        }

        private void ButtonClose_Click(object sender, RoutedEventArgs e)
        {
            CloseWindow();
        }

        private async void ButtonCreate_Click(object sender, RoutedEventArgs e)
        {
            if (IsFieldEmpty) return;

            Professor professor = new()
            {
                Name = TextBoxProfessorName.Text,
                ImageURL = TextBoxProfessorImageURL.Text,
                Occupation = TextBoxProfessorOccupation.Text,
                AlmaMater = TextBoxProfessorAlmaMater.Text,
                Speciality = TextBoxProfessorSpeciality.Text,
                WorkExperience = !string.IsNullOrEmpty(TextBoxProfessorWorkExperience.Text) ? int.Parse(TextBoxProfessorWorkExperience.Text) : null,
                SpecialWorkExperience = !string.IsNullOrEmpty(TextBoxProfessorSpecialWorkExperience.Text) ? int.Parse(TextBoxProfessorSpecialWorkExperience.Text) : null,
                Email = TextBoxProfessorEmail.Text,
                Phone = TextBoxProfessorPhone.Text
            };

            await API.Professors.Add(AppFields.Client.HttpClient, professor);
            CloseWindow();
            _professorSelection.Update();
        }

        private void CloseWindow()
        {
            _professorSelection.FrameProfessor.Content = null;
        }

        private void NumberValidationTextBox(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }
    }
}
