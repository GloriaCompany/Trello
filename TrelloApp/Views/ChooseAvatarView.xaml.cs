using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using TrelloApp.Helpers;
using TrelloApp.ViewModels;
using TrelloApp.ViewModels.Repository;
using TrelloApp.ViewModels.UserVM.UserAvatarsLoading;
using TrelloApp.Views.CustomControls;
using TrelloApp.Views.Utils;

namespace TrelloApp.Views
{
    /// <summary>
    /// Interaction logic for ChooseAvatarView.xaml
    /// </summary>
    public partial class ChooseAvatarView : Page
    {
        private CircleImage _selectedAvatar;

        public ChooseAvatarView()
        {
            InitializeComponent();
            var viewModel = new ChooseAvatarViewModel(
                FindResource("Navigation") as INavigator,
                FindResource("AvatarRepository") as IAvatarRepository,
                FindResource("UserRepository") as IUserRepository);
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

        private void ThemesComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ComboBoxUtils.HandleSelectionChanged(sender, e, "/Views/ResourcesTrello/Themes/", null);
        }

        private void LanguagesComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ComboBoxUtils.HandleSelectionChanged(sender, e, null, "/Views/ResourcesTrello/Languages/");
        }
    }
}
