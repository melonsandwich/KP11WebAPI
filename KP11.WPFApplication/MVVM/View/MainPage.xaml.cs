using System.Windows.Controls;

namespace KP11.WPFApplication.MVVM.View;

public partial class MainPage : Page
{
    public MainPage()
    {
        InitializeComponent();
        TextBlockAppInfo.Text = "Данное приложение создано в целях помощи обучающимся студентам в ГАПОУ \"КП №11\" ЦИКТ с поиском пособий для подготовки к учебной сессии, или же просто повышения знаний для улучшения текущих оценок по определенной дисциплине.";
    }

    private void ButtonProceed_Click(object sender, System.Windows.RoutedEventArgs e)
    {
        AppFields.MainWindow.Content = new RoleSelectionPage();
    }
}