using System.Windows.Controls;
using TrelloApp.ViewModels.UserVM;

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

            var vm = new RegisterViewModel
            (
                FindResource("UserRepository") as IUserRepository
            );

            DataContext = vm;
        }

        private void BtnLogin_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            NavigationService.Navigate(new Login());
        }

        private void BtnRegister_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            NavigationService.Navigate(new ChooseAvatar());
        }
    }
}
