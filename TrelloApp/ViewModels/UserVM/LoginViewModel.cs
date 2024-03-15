using System;
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
            _createDatabaseButtonVisibility = Visibility.Hidden; // Початково приховуємо кнопку "CREATE DATABASE"
            LoginCommand = new RelayCommand(Login, CanLogin);
        }

        private bool CanLogin()
        {
            // Перевірка на ім'я користувача та пароль admin
            return User != null && !string.IsNullOrEmpty(User.Username) &&
                   !string.IsNullOrEmpty(User.Password) &&
                   !(User.Username == "admin" && User.Password == "admin");
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

        private void InputTextChanged(object sender, TextChangedEventArgs e)
        {
            // Перевірка, чи введені значення є "admin"
            if (User.Username == "admin" && User.Password == "admin")
            {
                // Показати кнопку "CREATE DATABASE"
                CreateDatabaseButtonVisibility = Visibility.Visible;
            }
            else
            {
                // Сховати кнопку "CREATE DATABASE"
                CreateDatabaseButtonVisibility = Visibility.Hidden;
            }
        }
    }
}