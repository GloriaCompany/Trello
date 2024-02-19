using System;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Windows;
using System.Windows.Input;
using TrelloApp.Models;
using TrelloDBAccess;

namespace TrelloApp.ViewModels
{
    public class UsersViewModel
    {
        private readonly TrelloDataClassesDataContext _db = new TrelloDataClassesDataContext();
        public readonly UserModel userModel = new UserModel();

        public ICommand LoginCommand { get; }
        public ICommand SignUpCommand { get; }

        public event EventHandler<EventArgs> LoginSuccess;
        public event EventHandler<EventArgs> SignUpSuccess;

        public UsersViewModel()
        {
            LoginCommand = new RelayCommand(LoginUser, CanLogin);
            SignUpCommand = new RelayCommand(SignUpUser, CanSignUp);
        }

        private bool CanLogin()
        {
            return !string.IsNullOrWhiteSpace(userModel.Login) && !string.IsNullOrWhiteSpace(userModel.Password);
        }

        private bool CanSignUp()
        {
            return !string.IsNullOrWhiteSpace(userModel.Login) && !string.IsNullOrWhiteSpace(userModel.Email) &&
                   !string.IsNullOrWhiteSpace(userModel.Password) && !string.IsNullOrWhiteSpace(userModel.ConfirmPassword) &&
                   userModel.Password == userModel.ConfirmPassword && IsValidEmail(userModel.Email);
        }

        private static bool IsValidEmail(string email)
        {
            try
            {
                var address = new System.Net.Mail.MailAddress(email);
                return address.Address == email;
            }
            catch
            {
                return false;
            }
        }

        private void OnLoginSuccess()
        {
            LoginSuccess?.Invoke(this, EventArgs.Empty);
        }

        private void LoginUser()
        {
            var hashedPassword = HashPassword(userModel.Password);
            var user = _db.Users.FirstOrDefault(u => u.Login == userModel.Login && u.Password == hashedPassword);
            if (user != null)
            {
                OnLoginSuccess();
            }
        }

        private void OnSignUpSuccess()
        {
            SignUpSuccess?.Invoke(this, EventArgs.Empty);
        }

        private static string HashPassword(string password)
        {
            using (SHA256 sha256 = SHA256.Create())
            {
                byte[] hashedBytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(password));
                return BitConverter.ToString(hashedBytes).Replace("-", "").ToLower();
            }
        }

        private void SignUpUser()
        {
            var existingUser = _db.Users.FirstOrDefault(u => u.Login == userModel.Login || u.Email == userModel.Email);
            if (existingUser != null)
            {
                MessageBox.Show("ПОМИЛКА: Користувач з такою електронною поштою вже існує.\nВведіть нову електронну пошту та повторіть спробу.");
                return;
            }

            var newUser = new Users
            {
                Login = userModel.Login,
                Email = userModel.Email,
                Password = HashPassword(userModel.Password),
                Avatar = userModel.Avatar
            };

            try
            {
                _db.Users.InsertOnSubmit(newUser);
                _db.SubmitChanges();

                OnSignUpSuccess();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка при регистрации пользователя: " + ex.Message);
            }
        }
    }
}
