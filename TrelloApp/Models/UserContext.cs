namespace TrelloApp.Models
{
    public static class UserContext
    {
        public static UserModel CurrentUser { get; private set; }

        public static void SetCurrentUser(UserModel user)
        {
            CurrentUser = user;
        }
    }
}