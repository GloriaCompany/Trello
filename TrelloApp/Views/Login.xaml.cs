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
        }

        private void ViewModel_LoginSuccess(object sender, EventArgs e)
        {
            Close();
            var mainWindow = new MainWindow();
            mainWindow.Show();
        }
    }
}
