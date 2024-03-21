using System.Collections.ObjectModel;
using System.Windows.Controls;
using System.Windows.Input;
using TrelloApp.Models;
using TrelloApp.ViewModels;

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
    }
}
