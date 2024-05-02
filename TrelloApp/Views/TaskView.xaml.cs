using System.Windows.Controls;
using TrelloApp.Helpers;
using TrelloApp.ViewModels;
using TrelloApp.ViewModels.Repository;
using TrelloApp.Views.Utils;

namespace TrelloApp.Views
{
    public partial class TaskView : Page
    {
        public TaskView()
        {
            InitializeComponent();
            TaskViewModel vm = new TaskViewModel(
                            FindResource("Navigation") as INavigator,
                            FindResource("TaskRepository") as ITaskRepository,
                            FindResource("UserRepository") as IUserRepository
                        );
            DataContext = vm;
        }

        private void ThemesComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ComboBoxUtils.HandleSelectionChanged(sender, e, "/Views/ResourcesTrello/Themes/", null);
        }

        private void LanguagesComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ComboBoxUtils.HandleSelectionChanged(sender, e, null, "/Views/ResourcesTrello/Languages/");
        }

        private void BtnDelTask_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            (DataContext as TaskViewModel).DelTaskCommand.Execute(null);
        }

        private void BtnUpdateTask_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            (DataContext as TaskViewModel).UpdateTaskCommand.Execute(null);
        }

        private void ChangesButton_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            UsersPopup.IsOpen = !UsersPopup.IsOpen;
        }
    }
}
