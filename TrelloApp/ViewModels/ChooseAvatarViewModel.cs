using System.Collections.ObjectModel;
using System.Windows.Input;
using System.Windows.Media.Imaging;
using TrelloApp.Helpers;
using TrelloApp.ViewModels.Base;
using TrelloApp.ViewModels.Repository;
using TrelloApp.ViewModels.UserVM.UserAvatarsLoading;
using TrelloDBLayer;

namespace TrelloApp.ViewModels
{
    public class ChooseAvatarViewModel : ViewModelBase
    {
        //Fields
        private IAvatarRepository _avatarRepository;
        private IUserRepository _userRepository;
        private INavigator _navigator;

        private User _user;

        private string _selectedAvatar;
        private ObservableCollection<BitmapImage> _avatarImages;

        //Properties
        public User User
        {
            get => _user;
            set
            {
                _user = value;
                OnPropertyChanged(nameof(User));
            }
        }
        public string SelectedAvatar
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
        public ICommand LoadLoginViewCommand { get; set; }
        public ICommand LoadUserCommand { get; set; }

        public ChooseAvatarViewModel(INavigator navigator, IAvatarRepository avatarRepository, IUserRepository userRepository)
        {
            User = userRepository.CurrentUser;

            _avatarRepository = avatarRepository;
            _userRepository = userRepository;
            _navigator = navigator;

            //Initialize collections
            AvatarImages = new ObservableCollection<BitmapImage>();

            //Initialize commands
            SelectAvatarCommand = new ViewModelCommand(ExecuteSelectAvatarCommand, CanExecuteSelectAvatarCommand);
            LoadLoginViewCommand = new ViewModelCommand(ExecuteLoadLoginViewCommand, CanExecuteLoadLoginViewCommand);
            LoadUserCommand = new ViewModelCommand(ExecuteLoadUserCommand, CanExecuteLoadUserCommand);

            //Default view
            ExecuteLoadUserCommand(null);
            LoadAvatarImages();
        }

        //Checks
        private bool CanExecuteLoadUserCommand(object obj)
        {
            return true;
        }
        private bool CanExecuteLoadLoginViewCommand(object obj)
        {
            return true;
        }
        private bool CanExecuteSelectAvatarCommand(object obj)
        {
            //return SelectedAvatar != null;
            return true;
        }

        //Executes
        private void ExecuteLoadUserCommand(object obj)
        {
            User = _userRepository.CurrentUser;
        }
        private void ExecuteSelectAvatarCommand(object obj)
        {
            _userRepository.CurrentUser.Avatar = SelectedAvatar;

            _userRepository.UpdateUser(_userRepository.CurrentUser, _userRepository.CurrentUser.UserID);

            ExecuteLoadLoginViewCommand(null);
        }
        private void ExecuteLoadLoginViewCommand(object obj)
        {
            _navigator.GoTo("ProfileView.xaml");
        }
        private void LoadAvatarImages()
        {
            AvatarImages = _avatarRepository.GetAvatarImages();
        }
    }
}
