using KP11.WPFApplication.MVVM.Model;
using KP11.WPFApplication.MVVM.ViewModel;
using System.Windows.Controls;
using System.Windows;

namespace KP11.WPFApplication.MVVM.View
{
    /// <summary>
    /// Interaction logic for SubjectSelection.xaml
    /// </summary>
    public partial class SubjectSelection : Page
    {
        public ProfessorModel Professor { get; private set; }

        public bool IsAdmin { get; private set; }

        public SubjectSelection(ProfessorModel professor, bool isAdmin = false)
        {
            InitializeComponent();

            Professor = professor;
            AppFields.LastSelectedProfessor = professor;
            LabelProfessorName.Content = Professor.Name;

            IsAdmin = isAdmin;

            SubjectSelectionViewModel viewModel = new(professor);
            DataContext = viewModel;

            viewModel.FinishedPopulating += () =>
            {
                LabelNoSubjects.Visibility = viewModel.Subjects.Count == 0 ? Visibility.Visible : Visibility.Collapsed;
            };

            ProcessAdminControls();
        }

        public void Update()
        {
            ((SubjectSelectionViewModel)DataContext).Update();
        }

        private void ProcessAdminControls()
        {
            // not doing anything because admin controls are on by default
            if (IsAdmin) return;

            ButtonAddSubject.Visibility = Visibility.Hidden;
        }

        private void ButtonBack_Click(object sender, RoutedEventArgs e)
        {
            AppFields.MainWindow.Content = new ProfessorSelection(IsAdmin);
        }

        private void ButtonSubject_Click(object sender, RoutedEventArgs e)
        {
            if (sender is not Button button) return;
            if (button.DataContext is not SubjectModel subject) return;

            AppFields.MainWindow.Content = new ManualSelection(subject, IsAdmin);
        }

        private void ButtonEdit_Click(object sender, RoutedEventArgs e)
        {

        }

        private void ButtonEdit_Initialized(object sender, System.EventArgs e)
        {
            if (sender is not Button button) return;

            button.Visibility = IsAdmin ? Visibility.Visible : Visibility.Collapsed;
        }

        private void ButtonSubject_Initialized(object sender, System.EventArgs e)
        {
            if (sender is not Button button) return;

            button.SetValue(Grid.ColumnSpanProperty, IsAdmin ? 1 : 2);
        }

        private void ButtonAddSubject_Click(object sender, RoutedEventArgs e)
        {
            FrameSubject.Content = new SubjectCreationPage(this);
        }
    }
}
