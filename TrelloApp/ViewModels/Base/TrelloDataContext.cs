using System;
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

        public User GetUserByID(int userID)
        {
            return _context.User.FirstOrDefault(u => u.UserID == userID);
        }

        public void UpdateUser(User user) 
        {
            var existingUser = _context.User.FirstOrDefault(u => u.UserID == user.UserID);

            existingUser.Username = user.Username;
            existingUser.Email = user.Email;
            existingUser.Password = user.Password;
            existingUser.Avatar = user.Avatar;

            SaveChanges();
        }

        public void SaveChanges()
        {
            _context.SubmitChanges();
        }
    }
}
