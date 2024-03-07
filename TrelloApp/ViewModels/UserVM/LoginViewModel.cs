using System;
using System.ComponentModel;
using System.Windows;
using System.Windows.Input;
using TrelloApp.Models;
using TrelloApp.ViewModels.Base;
using TrelloDBLayer;

namespace TrelloApp.ViewModels.UserVM
{
    public class LoginViewModel : ViewModelBase
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
        public IUserRepository UserRepository { get { return _userRepository; } set { _userRepository = value; } }

        public event EventHandler SuccessfullyLoggedIn;

        public ICommand LoginCommand { get; set; }

        public LoginViewModel()
        {
            _user = new UserModel();
            LoginCommand = new RelayCommand(Login, CanLogin);
        }

        private bool CanLogin()
        {
            return
                User != null &&
                !string.IsNullOrEmpty(User.Username) &&
                !string.IsNullOrEmpty(User.Password);
        }

        private void Login()
        {
            try
            {
                var existingUser = _userRepository.GetUserByID(User.UserID);

                if (existingUser != null && existingUser.Username == User.Username && existingUser.Password == User.Password)
                {
                    SuccessfullyLoggedIn?.Invoke(this, EventArgs.Empty);
                }
                else
                {
                    MessageBox.Show("Помилка: Невірне ім'я користувача або пароль.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Помилка: {ex.Message}");
            }
        }
    }
}