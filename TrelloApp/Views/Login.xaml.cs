using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;

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
    }
}
