using System.Linq;
using TrelloDBLayer;

namespace TrelloApp.ViewModels.Base
{
    public interface ITrelloDataClassesDataContext
    {
        IQueryable<User> Users { get; }

        void AddUser(User user);

        void SaveChanges();
    }
}
