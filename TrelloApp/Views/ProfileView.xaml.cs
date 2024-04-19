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
            //Change Username input active
        }

        private void BtnChangeEmail_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            //Change Email input active
        }

        private void BtnChangePassword_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            //Change password input active
        }
    }
}
