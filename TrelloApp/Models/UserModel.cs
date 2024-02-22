using System;

namespace TrelloApp.Models
{
    public class UserModel
    {
        public int Id { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }
        public string Email { get; set; }
        public string Role { get; set; }
        public int Avatar { get; set; }
    }
}
