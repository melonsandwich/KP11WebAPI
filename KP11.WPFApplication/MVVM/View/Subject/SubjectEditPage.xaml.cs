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
using KP11.WPFApplication.Extensions;

namespace KP11.WPFApplication.MVVM.View
{
    /// <summary>
    /// Interaction logic for SubjectEditPage.xaml
    /// </summary>
    public partial class SubjectEditPage : Page
    {
        public SubjectModel Subject { get; private set; }

        private bool IsFieldEmpty => string.IsNullOrEmpty(TextBoxSubjectName.Text);

        private SubjectSelection _subjectSelection;

        public SubjectEditPage(SubjectModel subject, SubjectSelection subjectSelection)
        {
            InitializeComponent();

            DataContext = subject;

            Subject = subject;
            _subjectSelection = subjectSelection;
        }

        private void TextBoxSubjectName_TextChanged(object sender, TextChangedEventArgs e)
        {
            LabelFieldEmptyWarning.Visibility = IsFieldEmpty
                ? Visibility.Visible
                : Visibility.Hidden;
        }

        private void ButtonClose_Click(object sender, RoutedEventArgs e)
        {
            CloseWindow();
        }

        private async void ButtonDelete_Click(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show("Вы действительно хотите удалить данный предмет? Это удалит за собой все пособия по нему.", "Опасно", MessageBoxButton.YesNo, MessageBoxImage.Exclamation) == MessageBoxResult.Yes)
            {
                await API.Subjects.Delete(AppFields.Client.HttpClient, Subject.ID);
                CloseWindow();
                _subjectSelection.Update();
            }
        }

        private async void ButtonSave_Click(object sender, RoutedEventArgs e)
        {
            if (IsFieldEmpty) return;

            Subject subject = new()
            {
                ID = Subject.ID,
                Name = TextBoxSubjectName.Text,
                ProfessorID = Subject.ProfessorID
            };

            await API.Subjects.Update(AppFields.Client.HttpClient, subject);
            CloseWindow();
            _subjectSelection.Update();
        }

        private void CloseWindow()
        {
            _subjectSelection.FrameSubject.Content = null;
        }
    }
}
