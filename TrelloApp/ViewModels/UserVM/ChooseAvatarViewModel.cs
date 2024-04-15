using Jewelry.ViewModel;
using System.Collections.ObjectModel;
using System.Windows.Input;
using System.Windows.Media.Imaging;
using TrelloApp.ViewModels.Base;
using TrelloApp.ViewModels.UserVM.UserAvatarsLoading;
using TrelloDBLayer;

namespace TrelloApp.ViewModels.UserVM
{
    public class ChooseAvatarViewModel : ViewModelBase
    {
        //Fields
        private IAvatarRepository _avatarRepository;
        private IUserRepository _userRepository;

        private BitmapImage _selectedAvatar;
        private ObservableCollection<BitmapImage> _avatarImages;

        //Properties
        public BitmapImage SelectedAvatar
        {
            get => _selectedAvatar;
            set
            {
                _selectedAvatar = value;
                OnPropertyChanged(nameof(SelectedAvatar));
            }
        }
        public ObservableCollection<BitmapImage> AvatarImages
        {
            get => _avatarImages;
            set
            {
                _avatarImages = value;
                OnPropertyChanged(nameof(AvatarImages));
            }
        }

        //Commands
        public ICommand SelectAvatarCommand { get; set; }

        public ChooseAvatarViewModel(IAvatarRepository avatarRepository, IUserRepository userRepository)
        {
            _avatarRepository = avatarRepository;
            _userRepository = userRepository;

            AvatarImages = new ObservableCollection<BitmapImage>();

            //SelectAvatarCommand = new DelegateCommand((bmp) => {
            //    userRepository.LoggedUser.Avatar = "/TrelloApp;component/Resources/userAvatar.png";
            //    userRepository.AddUser(userRepository.LoggedUser);
            //}, parameter => true);

            SelectAvatarCommand = new ViewModelCommand(ExecuteSelectedAvatarCommand, CanExecuteSelectedAvatarCommand);

            LoadAvatarImages();
        }

        private bool CanExecuteSelectedAvatarCommand(object obj)
        {
            //return SelectedAvatar != null;
            return true;
        }

        private void ExecuteSelectedAvatarCommand(object obj)
        {
            _userRepository.LoggedUser.Avatar = "/TrelloApp;component/Resources/userAvatar.png";
            var user = new User()
            {
                Username = _userRepository.LoggedUser.Username,
                Password = _userRepository.LoggedUser.Password,
                Email = _userRepository.LoggedUser.Email,
                Avatar = _userRepository.LoggedUser.Avatar
            };

            _userRepository.AddUser(user.Username, user.Email, user.Password, user.Avatar);
        }

        private void LoadAvatarImages()
        {
            AvatarImages = _avatarRepository.GetAvatarImages();
        }
    }
}
