using TrelloDBLayer;

namespace TrelloApp.Models
{
    public class UserModel : User
    {
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
    }
}
