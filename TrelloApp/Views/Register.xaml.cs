using System.Windows.Controls;

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

        private void BtnLogin_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            NavigationService.Navigate(new Login());
        }
    }
}
