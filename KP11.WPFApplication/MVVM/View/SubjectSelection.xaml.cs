using KP11.WPFApplication.MVVM.Model;
using KP11.WPFApplication.MVVM.ViewModel;
using System.Windows.Controls;

namespace KP11.WPFApplication.MVVM.View
{
    /// <summary>
    /// Interaction logic for SubjectSelection.xaml
    /// </summary>
    public partial class SubjectSelection : Page
    {
        public ProfessorModel Professor { get; private set; }

        public SubjectSelection(ProfessorModel professor)
        {
            InitializeComponent();

            Professor = professor;
            AppFields.LastSelectedProfessor = professor;
            LabelProfessorName.Content = Professor.Name;

            DataContext = new SubjectSelectionViewModel(professor);
        }

        private void ButtonBack_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            AppFields.MainWindow.Content = new ProfessorSelection();
        }

        private void ButtonSubject_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            if (sender is not Button button) return;
            if (button.DataContext is not SubjectModel subject) return;

            AppFields.MainWindow.Content = new ManualSelection(subject);
        }
    }
}
