using KP11.Integration;
using KP11.Integration.Models;
using System.Windows;
using System.Windows.Controls;

namespace KP11.WPFApplication.MVVM.View
{
    /// <summary>
    /// Interaction logic for SubjectCreationPage.xaml
    /// </summary>
    public partial class SubjectCreationPage : Page
    {
        private bool IsFieldEmpty => string.IsNullOrEmpty(TextBoxSubjectName.Text);

        private SubjectSelection _subjectSelection;

        public SubjectCreationPage(SubjectSelection subjectSelection)
        {
            InitializeComponent();

            _subjectSelection = subjectSelection;
        }

        private void ButtonClose_Click(object sender, RoutedEventArgs e)
        {
            CloseWindow();
        }

        private async void ButtonCreate_Click(object sender, RoutedEventArgs e)
        {
            if (IsFieldEmpty) return;

            Subject subject = new()
            {
                Name = TextBoxSubjectName.Text,
                ProfessorID = _subjectSelection.Professor.ID
            };

            await API.Subjects.Add(AppFields.Client.HttpClient, subject);
            CloseWindow();
            _subjectSelection.Update();
        }

        private void TextBoxSubjectName_TextChanged(object sender, TextChangedEventArgs e)
        {
            LabelFieldEmptyWarning.Visibility = IsFieldEmpty
                ? Visibility.Visible
                : Visibility.Hidden;
        }

        private void CloseWindow()
        {
            _subjectSelection.FrameSubject.Content = null;
        }
    }
}
