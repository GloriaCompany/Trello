using System;
using System.Windows;
using System.Windows.Input;
using TrelloApp.Models;
using TrelloApp.ViewModels.Base;
using TrelloDBLayer;

namespace TrelloApp.ViewModels.UserVM
{
    public class RegisterViewModel : ViewModelBase
    {
        private UserModel _user;
        public UserModel User
        {
            get { return _user; }
            set
            {
                _user = value;
                OnPropertyChanged(nameof(User));
            }
        }

        private IUserRepository _userRepository;
        public IUserRepository UserRepository
        {
            get { return _userRepository; }
            set { _userRepository = value; }
        }

        public ICommand RegisterCommand { get; set; }

        public RegisterViewModel()
        {
            _user = new UserModel();
            RegisterCommand = new RelayCommand(Register, CanRegister);
        }

        private bool CanRegister()
        {
            bool res =
                User != null &&
                User.Error == null &&
                User.Password == User.ConfirmPassword;

            ((RelayCommand)RegisterCommand).RaiseCanExecuteChanged();

            return res;
        }

        private void Register()
        {
            try
            {
                if (!CanRegister())
                {
                    MessageBox.Show("Паролі мають співпадати. Перевірте правильність введених даних, будь-ласка.");
                    return;
                }

                var newUser = new User()
                {
                    Username = User.Username,
                    Email = User.Email,
                    Password = User.Password,
                    Avatar = null
                };
                _userRepository.AddUser(newUser);
                UserContext.SetCurrentUser(newUser);

                MessageBox.Show("Користувача зареєстровано.");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
