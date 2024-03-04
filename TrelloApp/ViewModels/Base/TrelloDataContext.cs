using System.Linq;
using TrelloDBLayer;

namespace TrelloApp.ViewModels.Base
{
    internal class TrelloDataContext : ITrelloDataClassesDataContext
    {
        private readonly TrelloDataClassesDataContext _context;

        public TrelloDataContext()
        {
            _context = new TrelloDataClassesDataContext();
        }

        public IQueryable<User> Users
        {
            get
            {
                return _context.User;
            }
        }

        public void AddUser(User user)
        {
            _context.User.InsertOnSubmit(user);
            SaveChanges();
        }

        public void SaveChanges()
        {
            _context.SubmitChanges();
        }
    }
}
