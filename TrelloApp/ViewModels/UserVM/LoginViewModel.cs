using System;
using System.Configuration;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using TrelloApp.Models;
using TrelloApp.ViewModels.Base;

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
        public IUserRepository UserRepository
        {
            get { return _userRepository; }
            set { _userRepository = value; }
        }

        public event EventHandler SuccessfullyLoggedIn;

        public ICommand LoginCommand { get; set; }

        private Visibility _createDatabaseButtonVisibility;
        public Visibility CreateDatabaseButtonVisibility
        {
            get { return _createDatabaseButtonVisibility; }
            set
            {
                _createDatabaseButtonVisibility = value;
                OnPropertyChanged(nameof(CreateDatabaseButtonVisibility));
            }
        }

        public LoginViewModel()
        {
            _user = new UserModel();
            _createDatabaseButtonVisibility = Visibility.Hidden;
            LoginCommand = new RelayCommand(Login, CanLogin);
        }

        private bool CanLogin()
        {
            string adminLogin = ConfigurationManager.AppSettings["AdminLogin"];
            string adminPassword = ConfigurationManager.AppSettings["AdminPassword"];

            return User != null &&
                   User.Username == adminLogin &&
                   User.Password == adminPassword;
        }

        private void Login()
        {
            try
            {
                var existingUser = _userRepository.GetUserByID(User.UserID);

                if (existingUser != null && existingUser.Username == User.Username && existingUser.Password == User.Password)
                {
                    UserContext.SetCurrentUser(User);
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