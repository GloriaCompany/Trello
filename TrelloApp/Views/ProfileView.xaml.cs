using System.Windows.Controls;
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

        private void BtnChangeAvatar_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            (DataContext as ProfileViewModel).UpdateUserCommand.Execute(null);
        }

        private void BtnChangeUsername_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            (DataContext as ProfileViewModel).UpdateUserCommand.Execute(null);
        }

        private void BtnChangeEmail_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            (DataContext as ProfileViewModel).UpdateUserCommand.Execute(null);
        }

        private void BtnLogout_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            (DataContext as ProfileViewModel).LogoutCommand.Execute(null);
        }

        private void BtnDelAccount_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            (DataContext as ProfileViewModel).DelUserCommand.Execute(null);
        }
    }
}
