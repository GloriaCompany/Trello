using System.Windows.Controls;
using TrelloApp.ViewModels;
using TrelloApp.ViewModels.Repository;

namespace TrelloApp.Views
{
    public partial class RegisterView : Page
    {
        public RegisterView()
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
            NavigationService.Navigate(new LoginView());
        }

        private void BtnRegister_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            NavigationService.Navigate(new ChooseAvatarView());
        }
    }
}
