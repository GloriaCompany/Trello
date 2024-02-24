namespace TrelloApp.Models
{
    public class UserModel
    {
        public int UserID { get; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public string Avatar { get; set; }
    }
}
