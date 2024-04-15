using System.Configuration;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using TrelloApp.Helpers;
using TrelloApp.ViewModels.UserVM;
using TrelloDBLayer;

namespace TrelloApp.Views
{
    public partial class Login : Page
    {
        public Login()
        {
            InitializeComponent();
            var vm = new LoginViewModel(FindResource("UserRepository") as IUserRepository,
                                        FindResource("Navigation") as INavigator);
            DataContext = vm;
        }

        private void BtnRegister_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Register());
        }

        private void BtnLogin_Click(object sender, RoutedEventArgs e)
        {

            if (InputLogin.Text == ConfigurationManager.AppSettings["AdminLogin"].ToString() &&
                InputPassword.Text == ConfigurationManager.AppSettings["AdminPassword"].ToString())
            {
                BtnCreateDatabase.Visibility = Visibility.Visible;
            }
            else
            {
                BtnCreateDatabase.Visibility = Visibility.Hidden;
            }
        }

        private void BtnCreateDatabase_Click(object sender, RoutedEventArgs e)
        {
            var db = new TrelloDataClassesDataContext(ConfigurationManager.ConnectionStrings["DefaultConnectionString"].ConnectionString);
            if (db.DatabaseExists())
            {
                db.DeleteDatabase();
                MessageBox.Show("База даних вже створена. Видаляємо! Можете продовжувати роботу.", "Warning", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
            db.CreateDatabase();
        }
    }
}
