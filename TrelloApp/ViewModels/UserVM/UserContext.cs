using TrelloDBLayer;

namespace TrelloApp.Models
{
    public static class UserContext
    {
        public static User CurrentUser { get; private set; }

        public static void SetCurrentUser(User user)
        {
            CurrentUser = user;
        }

        public static User GetCurrentUser()
        {
            return CurrentUser;
        }
    }
}