using System;
using System.Windows;
using System.Windows.Controls;
using TrelloApp.ViewModels;

namespace TrelloApp.Views
{
    /// <summary>
    /// Логика взаимодействия для Register.xaml
    /// </summary>
    public partial class Register : Page
    {
        public Register()
        {
            InitializeComponent();
        }

        private void ViewModel_SignUpSuccess(object sender, EventArgs e)
        {
            //Close();
            //var mainWindow = new MainWindow();
            //mainWindow.Show();
        }
    }
}
