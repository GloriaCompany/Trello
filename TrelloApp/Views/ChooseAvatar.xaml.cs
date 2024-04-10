using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using TrelloApp.ViewModels.UserVM.UserAvatarsLoading;
using TrelloApp.ViewModels.UserVM;
using TrelloApp.Views.CustomControls;

namespace TrelloApp.Views
{
    /// <summary>
    /// Interaction logic for ChooseAvatar.xaml
    /// </summary>
    public partial class ChooseAvatar : Page
    {
        private CircleImage _selectedAvatar;

        public ChooseAvatar()
        {
            InitializeComponent();
            var viewModel = new ChooseAvatarViewModel(
                FindResource("AvatarRepository") as IAvatarRepository,
                FindResource("UserRepository") as IUserRepository
               );
            DataContext = viewModel;
        }

        // Обробник події натискання кнопки миші на аватарці.
        private void Avatar_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            // Зміна кольору фону обраної аватарки на прозорий.
            if (_selectedAvatar != null)
            {
                _selectedAvatar.Background = Brushes.Transparent;
            }

            // Оновлення змінної _selectedAvatar на обрану аватарку.
            _selectedAvatar = (CircleImage)sender;

            // Зміна кольору фону обраної аватарки на AliceBlue.
            if (_selectedAvatar != null)
            {
                _selectedAvatar.Background = Brushes.AliceBlue;
            }
        }

        private void BtnSubmitAvatar_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            NavigationService.Navigate(new Login());
        }
    }
}
