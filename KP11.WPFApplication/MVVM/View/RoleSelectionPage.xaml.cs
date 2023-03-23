using System;
using System.Windows;
using System.Windows.Controls;

namespace KP11.WPFApplication.MVVM.View
{
    /// <summary>
    /// Interaction logic for RoleSelectionPage.xaml
    /// </summary>
    public partial class RoleSelectionPage : Page
    {
        private bool? isProfessorSelected = null;
        private event Action _selectionChanged;

        public RoleSelectionPage()
        {
            InitializeComponent();
            _selectionChanged += () =>
            {
                LabelRole.Content = (isProfessorSelected != null && isProfessorSelected.Value) ? "Преподаватель" : "Студент";
                ButtonProceed.IsEnabled = true;
            };
        }

        private void ButtonProceed_Click(object sender, RoutedEventArgs e)
        {
            if (isProfessorSelected == null) return;

            if (isProfessorSelected!.Value)
            {
                AppFields.MainWindow.Content = new LoginPage();
            }
            else
            {
                AppFields.MainWindow.Content = new ProfessorSelection(false);
            }
        }

        private void ButtonStudent_Click(object sender, RoutedEventArgs e)
        {
            isProfessorSelected = false;
            _selectionChanged?.Invoke();
        }

        private void ButtonProfessor_Click(object sender, RoutedEventArgs e)
        {
            isProfessorSelected = true;
            _selectionChanged?.Invoke();
        }
    }
}
