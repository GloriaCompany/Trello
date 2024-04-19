using System;
using System.Linq;
using TrelloApp.ViewModels.Base;
using TrelloDBLayer;

namespace TrelloApp.ViewModels.Repository
{
    public interface IUserRepository
    {
        void AddUser(User user);
        void DelUser(int userID);
        User GetUserByID(int userID);
        void UpdateUser(User user);
        bool AuthenticateUser(string username, string password);

        User CurrentUser { get; set; }
        User SelectedUser { get; set; }
    }

    public class UserRepository : IUserRepository
    {
        private ITrelloDataClassesDataContext _dbContext;
        public ITrelloDataClassesDataContext DbContext
        {
            get { return _dbContext; }
            set { _dbContext = value; }
        }

        public User CurrentUser { get; set; }
        public User SelectedUser { get; set; }

        public UserRepository(ITrelloDataClassesDataContext dbContext)
        {
            _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
        }

        public void AddUser(User user)
        {
            _dbContext.AddUser(user);
        }
        public void DelUser(int userID)
        {
            _dbContext.DelUser(userID);
        }
        public void UpdateUser(User user)
        {
            if (user == null)
            {
                throw new ArgumentNullException(nameof(user));
            }

            try
            {
                _dbContext.UpdateUser(user);
                _dbContext.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception("Failed to update user.", ex);
            }
        }
        public User GetUserByID(int userID)
        {
            return _dbContext.Users.FirstOrDefault(u => u.UserID == userID);
        }
        public bool AuthenticateUser(string username, string password)
        {
            var user = _dbContext.Users.FirstOrDefault(u => u.Username == username && u.Password == password);
            CurrentUser = user;

            return user != null;
        }
    }
}
