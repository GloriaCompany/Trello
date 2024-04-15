using System.Collections.ObjectModel;
using System.Windows.Controls;
using TrelloApp.Models;
using TrelloApp.Views.Utils;

namespace TrelloApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Page
    {
        public ObservableCollection<TaskModel> ColumnTasks { get; set; }
        public ObservableCollection<ColumnModel> Columns { get; set; }

        public MainWindow()
        {
            InitializeComponent();
            Columns = new ObservableCollection<ColumnModel>();
            ColumnTasks = new ObservableCollection<TaskModel>();
            DataContext = this;
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
    }
}
