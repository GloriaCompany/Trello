using System;
using System.Windows;
using TrelloApp.ViewModels;

namespace TrelloApp.Views
{
    /// <summary>
    /// Логика взаимодействия для Register.xaml
    /// </summary>
    public partial class Register : Window
    {
        public Register()
        {
            InitializeComponent();
            DataContext = new UsersViewModel();
            var viewModel = (UsersViewModel)DataContext;
            viewModel.SignUpSuccess += ViewModel_SignUpSuccess;
        }

        private void ViewModel_SignUpSuccess(object sender, EventArgs e)
        {
            Close();
            var mainWindow = new MainWindow();
            mainWindow.Show();
        }
    }
}
