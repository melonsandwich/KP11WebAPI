using KP11.Integration.Models.Auth;
using System;
using System.Windows.Controls;

namespace KP11.WPFApplication.MVVM.View
{
    /// <summary>
    /// Interaction logic for LoginPage.xaml
    /// </summary>
    public partial class LoginPage : Page
    {
        private bool AreFieldsEmpty => string.IsNullOrEmpty(TextBoxLogin.Text) || string.IsNullOrEmpty(TextBoxPassword.Text);

        private enum WarningLabelVariant
        {
            Empty = 0,
            FieldsEmpty,
            IncorrectLoginOrPassword
        }

        public LoginPage()
        {
            InitializeComponent();
        }

        private async void ButtonLogin_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            if (AreFieldsEmpty)
            {
                ShowWarning(WarningLabelVariant.FieldsEmpty);
                return;
            }

            ClientAuthConfiguration config = new(TextBoxLogin.Text, TextBoxPassword.Text);

            if (await AppFields.Client.Authorize(config))
            {
                AppFields.MainWindow.Content = new ProfessorSelection(true);
            }
            else
            {
                ShowWarning(WarningLabelVariant.IncorrectLoginOrPassword);
            }
        }

        private void ShowWarning(WarningLabelVariant variant)
        {
            string text = variant switch
            {
                WarningLabelVariant.Empty => "",
                WarningLabelVariant.FieldsEmpty => "Поля не могут быть пустыми!",
                WarningLabelVariant.IncorrectLoginOrPassword => "Неверный логин или пароль",
                _ => throw new ArgumentOutOfRangeException(nameof(variant), variant, null),
            };
            LabelWarning.Content = text;
        }
    }
}
