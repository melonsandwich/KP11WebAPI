using KP11.Integration.Models;
using KP11.WPFApplication.MVVM.Model;
using KP11.WPFApplication.MVVM.ViewModel;
using System.Diagnostics;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;

namespace KP11.WPFApplication.MVVM.View
{
    /// <summary>
    /// Interaction logic for ProfessorSelection.xaml
    /// </summary>
    public partial class ProfessorSelection : Page
    {
        public bool IsAdmin { get; }

        public ProfessorSelection(bool isAdmin = false)
        {
            InitializeComponent();
            DataContext = new ProfessorSelectionViewModel();

            IsAdmin = isAdmin;
            ProcessAdminControls();
        }

        private void ProcessAdminControls()
        {
            // not doing anything because admin controls are on by default
            if (IsAdmin) return;

            ButtonAddProfessor.Visibility = Visibility.Hidden;
        }

        public void Update()
        {
            ((ProfessorSelectionViewModel)DataContext).Update();
        }

        private void HyperlinkPhone_Click(object sender, RoutedEventArgs e)
        {
            if (sender is not Hyperlink hyperlink) return;
            if (hyperlink.DataContext is not ProfessorModel professor) return;

            Clipboard.SetText(professor.Phone);
            MessageBox.Show("Скопировано!", "Буфер обмена", MessageBoxButton.OK, MessageBoxImage.Information);
        }

        private void HyperlinkEmail_Click(object sender, RoutedEventArgs e)
        {
            if (sender is not Hyperlink hyperlink) return;
            if (hyperlink.DataContext is not ProfessorModel professor) return;

            if (MessageBox.Show("Открыть приложение электронной почты?", "Электронная почта", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                ProcessStartInfo processInfo = new($"mailto:{professor.Email}")
                {
                    UseShellExecute = true
                };
                Process.Start(processInfo);
            }
        }

        private void ButtonProfessor_Click(object sender, RoutedEventArgs e)
        {
            if (sender is not Button button) return;
            if (button.DataContext is not ProfessorModel professor) return;

            AppFields.MainWindow.Content = new SubjectSelection(professor, IsAdmin);
        }

        private void ButtonBack_Click(object sender, RoutedEventArgs e)
        {
            AppFields.MainWindow.Content = new RoleSelectionPage();
        }

        private void ButtonAddProfessor_Click(object sender, RoutedEventArgs e)
        {
            FrameProfessor.Content = new ProfessorCreationPage(this);
        }

        private void ButtonEdit_Click(object sender, RoutedEventArgs e)
        {

        }

        private void ButtonEdit_Initialized(object sender, System.EventArgs e)
        {

        }
    }
}
