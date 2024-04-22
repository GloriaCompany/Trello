using System.ComponentModel;
using TrelloDBLayer;

namespace TrelloApp.Models
{
    public class UserModel : User, IDataErrorInfo
    {
        #region Валідація
        private string _error;

        public string this[string columnName]
        {
            get
            {
                _error = null;
                if (columnName == nameof(Username))
                {
                    if (string.IsNullOrWhiteSpace(Username))
                        _error = "Поле є обов'язковим для заповнення";
                    else if (Username.Length < 5 || Username.Length > 10)
                        _error = "Мінімальна довжина Логіну - 5 символів, максимальна - 10";
                }
                if (columnName == nameof(Email))
                {
                    if (string.IsNullOrWhiteSpace(Email))
                        _error = "Поле є обов'язковим для заповнення";
                    else if (!Email.Contains("@") || Email.IndexOf('.') == -1 || Email.IndexOf('.') <= Email.IndexOf('@'))
                        _error = "Некоректний формат пошти";
                }
                if (columnName == nameof(Password))
                {
                    if (string.IsNullOrWhiteSpace(Password))
                        _error = "Поле є обов'язковим для заповнення";
                    else if (Password.Length < 8 || Password.Length > 20)
                        _error = "Мінімальна довжина Паролю - 8 символів, максимальна - 20";
                }
                if (columnName == nameof(ConfirmPassword))
                {
                    if (string.IsNullOrWhiteSpace(ConfirmPassword))
                        _error = "Поле є обов'язковим для заповнення";
                    else if (ConfirmPassword != Password)
                        _error = "Паролі мають співпадати";
                }
                if (columnName == nameof(Avatar))
                {
                    if (string.IsNullOrWhiteSpace(Avatar))
                        _error = "Поле є обов'язковим для заповнення";
                }
                return _error;
            }
        }
        public string Error => _error;
        #endregion

        #region Специфічні поля
        public string _сonfirmPassword { get; set; }
        public string ConfirmPassword
        {
            get
            {
                return _сonfirmPassword;
            }
            set
            {
                if (_сonfirmPassword != value)
                {
                    _сonfirmPassword = value;
                    SendPropertyChanged(nameof(ConfirmPassword));
                }
            }
        }
        #endregion
    }
}
