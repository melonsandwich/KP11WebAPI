using KP11.WPFApplication.MVVM.Model;
using KP11.WPFApplication.MVVM.ViewModel;
using System.Windows.Controls;
using System.Windows;

namespace KP11.WPFApplication.MVVM.View
{
    /// <summary>
    /// Interaction logic for ManualSelection.xaml
    /// </summary>
    public partial class ManualSelection : Page
    {
        public SubjectModel Subject { get; private set; }

        public bool IsAdmin { get; private set; }

        public ManualSelection(SubjectModel subject, bool isAdmin = false)
        {
            InitializeComponent();

            Subject = subject;
            IsAdmin = isAdmin;

            ManualSelectionViewModel viewModel = new(Subject);
            DataContext = viewModel;

            LabelProfessor.Content = AppFields.LastSelectedProfessor.Name;
            LabelSubject.Content = subject.Name;

            viewModel.FinishedPopulating += () =>
            {
                LabelNoManuals.Visibility = viewModel.Manuals.Count == 0 ? Visibility.Visible : Visibility.Collapsed;
            };

            ButtonAdd.Visibility = IsAdmin ? Visibility.Visible : Visibility.Collapsed;
        }

        public void Update()
        {
            ((ManualSelectionViewModel)DataContext).Update();
        }

        private void ButtonBack_Click(object sender, RoutedEventArgs e)
        {
            MainWindow window = AppFields.MainWindow;
            ProfessorModel professor = AppFields.LastSelectedProfessor;

            window.Content = professor is not null
                                ? new SubjectSelection(professor, IsAdmin)
                                : new ProfessorSelection(IsAdmin);
        }

        private void ButtonManual_Click(object sender, RoutedEventArgs e)
        {
            if (sender is not Button button) return;
            if (button.DataContext is not ManualModel manual) return;

            FrameSingleManual.Content = new ManualViewPage(manual, this);
        }

        private void ButtonEdit_Click(object sender, RoutedEventArgs e)
        {
            if (sender is not Button button) return;
            if (button.DataContext is not ManualModel manual) return;

            FrameSingleManual.Content = new ManualEditPage(manual, this);
        }

        private void ButtonManual_Initialized(object sender, System.EventArgs e)
        {
            if (sender is not Button button) return;

            button.SetValue(Grid.ColumnSpanProperty, IsAdmin ? 1 : 2);
        }

        private void ButtonEdit_Initialized(object sender, System.EventArgs e)
        {
            if (sender is not Button button) return;

            button.Visibility = IsAdmin ? Visibility.Visible : Visibility.Collapsed;
        }

        private void ButtonAdd_Click(object sender, RoutedEventArgs e)
        {
            if (sender is not Button button) return;

            FrameSingleManual.Content = new ManualCreationPage(this);
        }
    }
}
