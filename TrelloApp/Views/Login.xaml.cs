using System;
using System.Windows;
using TrelloApp.ViewModels;

namespace TrelloApp.Views
{
    public partial class Login : Window
    {
        public Login()
        {
            InitializeComponent();
            DataContext = new UsersViewModel();
            var viewModel = (UsersViewModel)DataContext;
            viewModel.LoginSuccess += ViewModel_LoginSuccess;
        }

        private void ViewModel_LoginSuccess(object sender, EventArgs e)
        {
            Close();
            var mainWindow = new MainWindow();
            mainWindow.Show();
        }
    }
}
