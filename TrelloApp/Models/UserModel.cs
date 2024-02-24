using System.ComponentModel;

namespace TrelloApp.Models
{
    public class UserModel : INotifyPropertyChanged
    {
        private string _username;
        private string _password;
        private string _email;
        private string _avatar;
        private string _passwordConfirmation;

        public string Username
        {
            get { return _username; }
            set
            {
                _username = value;
                OnPropertyChanged(nameof(Username));
            }
        }

        public string Password
        {
            get { return _password; }
            set
            {
                _password = value;
                OnPropertyChanged(nameof(Password));
                OnPropertyChanged(nameof(PasswordConfirmation));
            }
        }

        public string PasswordConfirmation
        {
            get { return _passwordConfirmation; }
            set
            {
                _passwordConfirmation = value;
                OnPropertyChanged(nameof(PasswordConfirmation));
            }
        }

        public string Email
        {
            get { return _email; }
            set
            {
                _email = value;
                OnPropertyChanged(nameof(Email));
            }
        }

        public string Avatar
        {
            get { return _avatar; }
            set
            {
                _avatar = value;
                OnPropertyChanged(nameof(Avatar));
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
