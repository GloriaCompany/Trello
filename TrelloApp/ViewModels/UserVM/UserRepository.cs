using System;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Security;
using TrelloApp.ViewModels.Base;
using TrelloDBLayer;

namespace TrelloApp.ViewModels.UserVM
{
    public interface IUserRepository
    {
        void AddUser(User user);
        User GetUserByID(int userID);
        bool AuthenticateUser(string username, SecureString password);
        void UpdateUser(User user);
    }

    internal class UserRepository : IUserRepository
    {
        private ITrelloDataClassesDataContext _dbContext;
        public ITrelloDataClassesDataContext DbContext
        {
            get { return _dbContext; }
            set { _dbContext = value; }
        }

        public UserRepository() { }
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

        public bool AuthenticateUser(string username, SecureString password)
        {
            bool validUser = _dbContext.Users.FirstOrDefault(u => u.Username == username && u.Password == password.ToString()) != null;
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
