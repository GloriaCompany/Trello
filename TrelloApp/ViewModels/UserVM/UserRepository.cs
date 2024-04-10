using System;
using System.Linq;
using TrelloApp.ViewModels.Base;
using TrelloDBLayer;

namespace TrelloApp.ViewModels.UserVM
{
    public interface IUserRepository
    {
        void AddUser(User user);
        User GetUserByID(int userID);
        bool AuthenticateUser(string username, String password);
        void UpdateUser(User user);

        User LoggedUser { get; set; }
    }

    internal class UserRepository : IUserRepository
    {
        private ITrelloDataClassesDataContext _dbContext;
        public ITrelloDataClassesDataContext DbContext
        {
            get { return _dbContext; }
            set { _dbContext = value; }
        }

        public User LoggedUser { get; set; }

        public UserRepository(ITrelloDataClassesDataContext dbContext)
        {
            _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
        }

        public void AddUser(User user)
        {
            if (user == null)
            {
                throw new ArgumentNullException(nameof(user));
            }

            try
            {
                _dbContext.AddUser(user);
                _dbContext.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception("Failed to add user.", ex);
            }
        }

        public User GetUserByID(int userID)
        {
            try
            {
                return _dbContext.Users.FirstOrDefault(u => u.UserID == userID);
            }
            catch (Exception ex)
            {
                throw new Exception("Failed to get user.", ex);
            }
        }

        public bool AuthenticateUser(string username, String password)
        {            
            var user =  _dbContext.Users.FirstOrDefault(u => u.Username == username && u.Password == password.ToString());
            LoggedUser = user;
            bool validUser = user != null;
            return validUser;
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
    }
}
