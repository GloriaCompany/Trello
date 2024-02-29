using System;
using System.Windows;
using System.Windows.Input;
using TrelloApp.Models;
using TrelloApp.ViewModels.Base;
using TrelloDBLayer;

namespace TrelloApp.ViewModels
{
    public class RegisterViewModel : ViewModelBase
    {
        private readonly IUserRepository _userRepository;
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

        public ICommand RegisterCommand { get; set; }

        public RegisterViewModel(IUserRepository userRepository)
        {
            _userRepository = userRepository ?? throw new ArgumentNullException(nameof(userRepository));
            _user = new UserModel();
            RegisterCommand = new RelayCommand(Register, CanRegister);
        }

        private bool CanRegister()
        {
            bool res =
                !string.IsNullOrEmpty(User.Username) &&
                !string.IsNullOrEmpty(User.Email) &&
                !string.IsNullOrEmpty(User.Password) &&
                !string.IsNullOrEmpty(User.ConfirmPassword) &&
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
                    MessageBox.Show("Заповніть усі поля форми, будь-ласка.");
                    return;
                }

                var newUser = new User
                {
                    Username = _user.Username,
                    Email = _user.Email,
                    Password = _user.Password,
                    Avatar = ""
                };

                _userRepository.AddUser(newUser);

                MessageBox.Show("Користувача зареєстровано.");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
