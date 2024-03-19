using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
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
            InitializeComponent();
        }

        private void Avatar_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (_selectedAvatar != null)
            {
                _selectedAvatar.Background = Brushes.Transparent;
            }
            _selectedAvatar = (CircleImage)sender;
            _selectedAvatar.Background = Brushes.AliceBlue;
        }

        private void Avatar_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            // ...
        }
    }
}
