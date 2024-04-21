using System.Windows;
using System.Windows.Controls;
using TrelloApp.Helpers;
using TrelloApp.ViewModels;
using TrelloApp.ViewModels.Repository;
using TrelloApp.Views;
using TrelloApp.Views.Utils;

namespace TrelloApp
{
    public partial class BoardView : Page
    {
        public BoardView()
        {
            InitializeComponent();
            var viewModel = new BoardViewModel(
                FindResource("Navigation") as INavigator,
                FindResource("UserRepository") as IUserRepository,
                FindResource("BoardRepository") as IBoardRepository,
                FindResource("ColumnRepository") as IColumnRepository);
            DataContext = viewModel;
        }

        private void TeamUsersListBtn_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            UsersPopup.IsOpen = !UsersPopup.IsOpen;
        }

        private void ThemesComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ComboBoxUtils.HandleSelectionChanged(sender, e, "/Views/ResourcesTrello/Themes/", null);
        }

        private void LanguagesComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ComboBoxUtils.HandleSelectionChanged(sender, e, null, "/Views/ResourcesTrello/Languages/");
        }

        private void CircleImage_MouseDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            NavigationService.Navigate(new ProfileView());
        }

        private void BtnChangeBoardTitle_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            UpdateBoardBtn.Visibility = Visibility.Visible;
            CancelUpdateBoardBtn.Visibility = Visibility.Visible;
            UpdateBoardBtn.IsEnabled = true;
            CancelUpdateBoardBtn.IsEnabled = true;

            BoardNameInput.IsEnabled = true;
            BoardNameInput.Focus();

            BtnChangeBoardTitle.IsEnabled = false;
        }

        private void BoardNameInput_LostFocus(object sender, RoutedEventArgs e)
        {
            UpdateBoardBtn.Visibility = Visibility.Hidden;
            CancelUpdateBoardBtn.Visibility = Visibility.Hidden;
            UpdateBoardBtn.IsEnabled = false;
            CancelUpdateBoardBtn.IsEnabled = false;

            BoardNameInput.IsEnabled = false;

            BtnChangeBoardTitle.IsEnabled = true;
        }
    }
}
