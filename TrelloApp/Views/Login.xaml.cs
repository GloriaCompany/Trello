using System;
using System.Configuration;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using TrelloDBLayer;

namespace TrelloApp.Views
{
    public partial class Login : Page
    {
        public Login()
        {
            InitializeComponent();
            DataContext = this;
        }

        private void ViewModel_LoginSuccess(object sender, EventArgs e)
        {
            //Close();
            //var mainWindow = new MainWindow();
            //mainWindow.Show();
        }

        private void BtnRegister_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Register());
        }

        private void BtnLogin_Click(object sender, RoutedEventArgs e)
        {
            if (InputLogin.Text == ConfigurationManager.AppSettings["AdminLogin"].ToString() &&
                InputPassword.Password == ConfigurationManager.AppSettings["AdminPassword"].ToString())
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
            var db = new TrelloDataClassesDataContext();
            if (!db.DatabaseExists()) db.CreateDatabase();
            else MessageBox.Show("База даних вже створена. Ви можете продовжувати роботу.", "Warning", MessageBoxButton.OK, MessageBoxImage.Warning);
        }
    }
}
