using System;
using System.Windows.Input;
using TrelloApp.Helpers;
using TrelloApp.ViewModels.Base;
using TrelloApp.ViewModels.Repository;
using TrelloDBLayer;

namespace TrelloApp.ViewModels
{
    public class ProfileViewModel : ViewModelBase
    {
        //Fields
        private User _user;
        private string _errorMessage;

        private string _originalUsername;
        private string _originalEmail;
        private string _originalPassword;

        private IUserRepository _userRepository;
        private INavigator _navigator;

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
        public string ErrorMessage
        {
            get => _errorMessage;
            set
            {
                _errorMessage = value;
                OnPropertyChanged(nameof(ErrorMessage));
            }
        }

        public string OriginalUsername
        {
            get => _originalUsername;
            set
            {
                _originalUsername = value;
                OnPropertyChanged(nameof(OriginalUsername));
            }
        }
        public string OriginalEmail
        {
            get => _originalEmail;
            set
            {
                _originalEmail = value;
                OnPropertyChanged(nameof(OriginalEmail));
            }
        }
        public string OriginalPassword
        {
            get => _originalPassword;
            set
            {
                _originalPassword = value;
                OnPropertyChanged(nameof(OriginalPassword));
            }
        }

        //Commands
        public ICommand LoadUserCommand { get; set; }
        public ICommand UpdateUserCommand { get; set; }
        public ICommand CancelUpdateUserCommand { get; set; }
        public ICommand SetDefaultUserAvatarCommand { get; set; }
        public ICommand DelUserCommand { get; set; }
        public ICommand LogoutCommand { get; set; }
        public ICommand LoadLoginViewCommand { get; set; }
        public ICommand LoadChooseAvatarView { get; set; }

        public ProfileViewModel(INavigator navigator, IUserRepository userRepository)
        {
            User = userRepository.CurrentUser;

            _userRepository = userRepository;
            _navigator = navigator;

            OriginalUsername = User.Username;
            OriginalEmail = User.Email;
            OriginalPassword = User.Password;

            //Initialize commands
            LoadUserCommand = new ViewModelCommand(ExecuteLoadUserCommand, CanExecuteLoadUserCommand);
            UpdateUserCommand = new ViewModelCommand(ExecuteUpdateUserCommand, CanExecuteUpdateUserCommand);
            CancelUpdateUserCommand = new ViewModelCommand(ExecuteCancelUpdateUserCommand, CanExecuteCancelUpdateUserCommand);
            SetDefaultUserAvatarCommand = new ViewModelCommand(ExecuteSetDefaultUserAvatarCommand, CanExecuteSetDefaultUserAvatarCommand);
            DelUserCommand = new ViewModelCommand(ExecuteDelUserCommand, CanExecuteDelUserCommand);
            LogoutCommand = new ViewModelCommand(ExecuteLogoutCommand, CanExecuteLogoutCommand);
            LoadLoginViewCommand = new ViewModelCommand(ExecuteLoadLoginViewCommand, CanExecuteLoadLoginViewCommand);
            LoadChooseAvatarView = new ViewModelCommand(ExecuteLoadChooseAvatarView, CanExecuteLoadChooseAvatarView);

            ExecuteLoadUserCommand(null);
        }

        //Checks
        private bool CanExecuteLoadUserCommand(object obj)
        {
            return
                User != null;
        }
        private bool CanExecuteUpdateUserCommand(object obj)
        {
            return
                !string.IsNullOrEmpty(User.Username) ||
                !string.IsNullOrEmpty(User.Email) ||
                !string.IsNullOrEmpty(User.Password) ||
                !string.IsNullOrEmpty(User.Avatar);
        }
        private bool CanExecuteCancelUpdateUserCommand(object obj)
        {
            return true;
        }
        private bool CanExecuteSetDefaultUserAvatarCommand(object obj)
        {
            return true;
        }
        private bool CanExecuteDelUserCommand(object obj)
        {
            return
                User != null;
        }
        private bool CanExecuteLogoutCommand(object obj)
        {
            return
                User != null;
        }
        private bool CanExecuteLoadLoginViewCommand(object obj)
        {
            return true;
        }
        private bool CanExecuteLoadChooseAvatarView(object obj)
        {
            return true;
        }

        //Executes
        private void ExecuteLoadUserCommand(object obj)
        {
            User = _userRepository.CurrentUser;
        }
        private void ExecuteUpdateUserCommand(object obj)
        {
            _userRepository.UpdateUser(User);
        }
        private void ExecuteCancelUpdateUserCommand(object obj)
        {
            OriginalUsername = User.Username;
            OriginalEmail = User.Email;
            OriginalPassword = User.Password;
        }
        private void ExecuteSetDefaultUserAvatarCommand(object obj)
        {
            User.Avatar = "/TrelloApp;component/Resources/userAvatar.png";
            _userRepository.UpdateUser(User);
        }
        private void ExecuteDelUserCommand(object obj)
        {
            _userRepository.DelUser(User.UserID);
            _userRepository.CurrentUser = null;
            ExecuteLoadLoginViewCommand(null);
        }
        private void ExecuteLogoutCommand(object obj)
        {
            _userRepository.CurrentUser = null;
            ExecuteLoadLoginViewCommand(null);
        }
        private void ExecuteLoadLoginViewCommand(object obj)
        {
            _navigator.GoTo("LoginView.xaml");
        }
        private void ExecuteLoadChooseAvatarView(object obj)
        {
            _navigator.GoTo("ChooseAvatarView.xaml");
        }
    }
}
