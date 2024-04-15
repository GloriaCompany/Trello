using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using TrelloApp.ViewModels.BoardVM;
using TrelloApp.ViewModels.UserVM;
using TrelloApp.Views.Utils;

namespace TrelloApp.Views
{
    /// <summary>
    /// Логика взаимодействия для Dashboard.xaml
    /// </summary>
    public partial class Dashboard : Page
    {
        public Dashboard()
        {
            InitializeComponent();

            DashboardViewModel vm = new DashboardViewModel(
                            FindResource("UserRepository") as IUserRepository,
                            FindResource("BoardRepository") as IBoardRepository
                        );
            DataContext = vm;

            PreviewMouseDown += Dashboard_PreviewMouseDown;
        }

        private void AddBoardBtn_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            addBoardPopup.IsOpen = true;
        }

        private void AddConfirmedBoardButton_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(BoardNameInput.Text))
            {
                // Додавання дошки
                addBoardPopup.IsOpen = false;
            }
            else
            {
                MessageBox.Show("Please enter a board name.");
            }
        }

        private void Dashboard_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            if (!IsMouseOverPopup(e))
            {
                addBoardPopup.IsOpen = false;
            }
        }

        private bool IsMouseOverPopup(MouseButtonEventArgs e)
        {
            if (addBoardPopup.IsOpen)
            {
                Point point = e.GetPosition(null);
                return addBoardPopup
                    .PlacementTarget?
                    .TransformToVisual(this)
                    .TransformBounds(addBoardPopup.PlacementRectangle)
                    .Contains(point)
                    ?? false;
            }
            return false;
        }

        private void ThemesComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ComboBoxUtils.HandleSelectionChanged(sender, e, "/Views/ResourcesTrello/Themes/", null);
        }

        private void LanguagesComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ComboBoxUtils.HandleSelectionChanged(sender, e, null, "/Views/ResourcesTrello/Languages/");
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            (DataContext as DashboardViewModel).LoadBoardsCommand.Execute(null);
        }
    }
}
