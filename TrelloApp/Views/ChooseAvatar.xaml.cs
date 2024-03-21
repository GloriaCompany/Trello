using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using TrelloApp.ViewModels.UserVM.UserAvatarsLoading;
using TrelloApp.ViewModels.UserVM;
using TrelloApp.Views.CustomControls;

namespace TrelloApp.Views
{
    /// <summary>
    /// Логика взаимодействия для ChooseAvatar.xaml
    /// </summary>
    public partial class ChooseAvatar : Page
    {
        private CircleImage _selectedAvatar;

        public ChooseAvatar()
        {
            var viewModel = new ChooseAvatarViewModel(new ResourceImageLoader(), new FolderImageLoader());
            DataContext = viewModel;
            InitializeComponent();
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

        private void Avatar_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            // ...
        }
    }
}
