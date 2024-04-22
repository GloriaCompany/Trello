using System.Configuration;
using System.Windows;
using System.Windows.Controls;
using TrelloApp.Helpers;
using TrelloApp.ViewModels;
using TrelloApp.ViewModels.Repository;
using TrelloDBLayer;

namespace TrelloApp.Views
{
    public partial class LoginView : Page
    {
        public LoginView()
        {
            InitializeComponent();
            var vm = new LoginViewModel(FindResource("UserRepository") as IUserRepository,
                                        FindResource("Navigation") as INavigator);
            DataContext = vm;
        }

        private void BtnCreateDatabase_Click(object sender, RoutedEventArgs e)
        {
            // Вынести в вм, как команду и биндить на ErrorMessage
            var db = new TrelloDataClassesDataContext(ConfigurationManager.ConnectionStrings["DefaultConnectionString"].ConnectionString);
            if (db.DatabaseExists())
            {
                db.DeleteDatabase();
                // ErrorMessage
                //MessageBox.Show("База даних вже створена. Видаляємо! Можете продовжувати роботу.", "Warning", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
            db.CreateDatabase();
        }
    }
}
