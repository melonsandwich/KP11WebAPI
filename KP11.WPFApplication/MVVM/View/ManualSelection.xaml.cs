using KP11.WPFApplication.MVVM.Model;
using KP11.WPFApplication.MVVM.ViewModel;
using System.Windows.Controls;

namespace KP11.WPFApplication.MVVM.View
{
    /// <summary>
    /// Interaction logic for ManualSelection.xaml
    /// </summary>
    public partial class ManualSelection : Page
    {
        public SubjectModel Subject { get; private set; }

        public ManualSelection(SubjectModel subject)
        {
            InitializeComponent();

            Subject = subject;
            DataContext = new ManualSelectionViewModel(Subject);

            LabelProfessor.Content = AppFields.LastSelectedProfessor.Name;
            LabelSubject.Content = subject.Name;
        }

        private void ButtonBack_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            MainWindow window = AppFields.MainWindow;
            ProfessorModel professor = AppFields.LastSelectedProfessor;

            window.Content = professor is not null
                                ? new SubjectSelection(professor)
                                : new ProfessorSelection();
        }

        private void ButtonManual_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            if (sender is not Button button) return;
            if (button.DataContext is not ManualModel manual) return;

            FrameSingleManual.Content = new ManualViewPage(manual, this);
        }
    }
}
