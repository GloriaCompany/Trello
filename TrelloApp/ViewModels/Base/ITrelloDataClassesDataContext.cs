using System.Linq;
using TrelloDBLayer;

namespace TrelloApp.ViewModels.Base
{
    public interface ITrelloDataClassesDataContext
    {
        IQueryable<User> Users { get; }

        void AddUser(User user);
        User GetUserByID(int userID);
        void UpdateUser(User user);

        void SaveChanges();
    }
}
