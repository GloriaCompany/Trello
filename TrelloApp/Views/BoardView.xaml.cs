using System.Windows.Controls;
using TrelloApp.ViewModels;
using TrelloApp.ViewModels.Repository;
using TrelloApp.Views.Utils;

namespace TrelloApp
{
    public partial class BoardView : Page
    {
        public BoardView()
        {
            InitializeComponent();
            var viewModel = new BoardViewModel(
                FindResource("UserRepository") as IUserRepository,
                FindResource("BoardRepository") as IBoardRepository);
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

        private void BtnChangeBoardTitle_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            (DataContext as BoardViewModel).UpdateBoardCommand.Execute(null);
        }

        private void BtnAddColumn_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            (DataContext as BoardViewModel).AddColumnCommand.Execute(null);
        }

        private void BtnDelBoard_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            (DataContext as BoardViewModel).DelBoardCommand.Execute(null);
        }
    }
}
