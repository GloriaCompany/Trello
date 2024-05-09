using System.Windows;
using System.Windows.Controls;
using TrelloApp.Helpers;
using TrelloApp.ViewModels;
using TrelloApp.ViewModels.Repository;
using TrelloApp.Views.Utils;

namespace TrelloApp.Views
{
    public partial class ProfileView : Page
    {
        public ProfileView()
        {
            InitializeComponent();
            var viewModel = new ProfileViewModel(
                FindResource("Navigation") as INavigator,
                FindResource("UserRepository") as IUserRepository);
            DataContext = viewModel;
        }

        private void ThemesComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ComboBoxUtils.HandleSelectionChanged(sender, e, "/Views/ResourcesTrello/Themes/", null);
        }

        private void LanguagesComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ComboBoxUtils.HandleSelectionChanged(sender, e, null, "/Views/ResourcesTrello/Languages/");
        }

        private void BtnChangeUsername_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            BtnUpdateUsername.Visibility = Visibility.Visible;
            BtnCancelUpdateUsername.Visibility = Visibility.Visible;
            BtnUpdateUsername.IsEnabled = true;
            BtnCancelUpdateUsername.IsEnabled = true;

            UsernameInput.IsEnabled = true;
            UsernameInput.Focus();

            BtnChangeUsername.IsEnabled = false;
        }

        private void BtnChangeEmail_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            BtnUpdateEmail.Visibility = Visibility.Visible;
            BtnCancelUpdateEmail.Visibility = Visibility.Visible;
            BtnUpdateEmail.IsEnabled = true;
            BtnCancelUpdateEmail.IsEnabled = true;

            EmailInput.IsEnabled = true;
            EmailInput.Focus();

            BtnChangeEmail.IsEnabled = false;
        }

        private void BtnChangePassword_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            BtnUpdatePassword.Visibility = Visibility.Visible;
            BtnCancelUpdatePassword.Visibility = Visibility.Visible;
            BtnUpdatePassword.IsEnabled = true;
            BtnCancelUpdatePassword.IsEnabled = true;

            PasswordInput.IsEnabled = true;
            PasswordInput.Focus();

            BtnChangePassword.IsEnabled = false;
        }

        private void BtnGoToDashboard_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new DashboardView());
        }

        private void BtnUpdateUsername_Click(object sender, RoutedEventArgs e)
        {
            BtnUpdateUsername.Visibility = Visibility.Hidden;
            BtnCancelUpdateUsername.Visibility = Visibility.Hidden;
        }

        private void BtnCancelUpdateUsername_Click(object sender, RoutedEventArgs e)
        {
            BtnUpdateUsername.Visibility = Visibility.Hidden;
            BtnCancelUpdateUsername.Visibility = Visibility.Hidden;
        }

        private void BtnUpdateEmail_Click(object sender, RoutedEventArgs e)
        {
            BtnUpdateEmail.Visibility = Visibility.Hidden;
            BtnCancelUpdateEmail.Visibility = Visibility.Hidden;
        }

        private void BtnCancelUpdateEmail_Click(object sender, RoutedEventArgs e)
        {
            BtnUpdateEmail.Visibility = Visibility.Hidden;
            BtnCancelUpdateEmail.Visibility = Visibility.Hidden;
        }

        private void BtnUpdatePassword_Click(object sender, RoutedEventArgs e)
        {
            BtnUpdatePassword.Visibility = Visibility.Hidden;
            BtnCancelUpdatePassword.Visibility = Visibility.Hidden;
        }

        private void BtnCancelUpdatePassword_Click(object sender, RoutedEventArgs e)
        {
            BtnUpdatePassword.Visibility = Visibility.Hidden;
            BtnCancelUpdatePassword.Visibility = Visibility.Hidden;
        }
    }
}
