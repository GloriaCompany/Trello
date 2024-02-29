using System.ComponentModel;
using System.Configuration;
using System.Linq;
using System.Windows.Input;
using TrelloApp.Models;
using TrelloApp.Views;
using TrelloDBLayer;

namespace TrelloApp.ViewModels
{
    // TODO: Переделать логику

    public class ProfileViewModel : INotifyPropertyChanged
    {
        private UserModel user;
        public ICommand ProfileUpdateCommand { get; set; }

        public ProfileViewModel(UserModel currentUser)
        {
            user = currentUser;
            //ProfileUpdateCommand = new RelayCommand(UpdateProfile, CanUpdateProfile);
        }

        //private bool CanUpdateProfile()
        //{
        //    return
        //        !string.IsNullOrEmpty(user.Username) ||
        //        !string.IsNullOrEmpty(user.Email) ||
        //        !string.IsNullOrEmpty(user.Password) ||
        //        !string.IsNullOrEmpty(user.Avatar);
        //}
        private void UpdateProfile()
        {
            //using (var dbContext = new TrelloDataClassesDataContext(
            //    ConfigurationManager.ConnectionStrings["DefaultConnectionString"].ConnectionString))
            //{
            //    var existingUser = dbContext.User.SingleOrDefault(u => u.UserID == user.UserID);
            //    if (existingUser != null)
            //    {
            //        existingUser.Username = user.Username;
            //        existingUser.Password = user.Password;
            //        existingUser.Email = user.Email;
            //        existingUser.Avatar = user.Avatar;

            //        dbContext.SubmitChanges();

            //        //Изменения успешно сохранены
            //    }
            //    else
            //    {
            //        //Пользователь не найден
            //    }
            //}
        }

        //public int UserID
        //{
        //    get { return user.UserID; }
        //}

        public string Username
        {
            get { return user.Username; }
            set { user.Username = value; OnPropertyChanged(nameof(Username)); }
        }
        public string Password
        {
            get { return user.Password; }
            set { user.Password = value; OnPropertyChanged(nameof(Password)); }
        }
        public string Email
        {
            get { return user.Email; }
            set { user.Email = value; OnPropertyChanged(nameof(Email)); }
        }
        //public string Avatar
        //{
        //    get { return user.Avatar; }
        //    set { user.Avatar = value; OnPropertyChanged(nameof(Avatar)); }
        //}

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
