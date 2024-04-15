using System;
using System.Linq;
using TrelloApp.ViewModels.Base;
using TrelloDBLayer;

namespace TrelloApp.ViewModels.UserVM
{
    public interface IUserRepository
    {
        void AddUser(string username, string email, string password, string avatar);
        User GetUserByID(int userID);
        bool AuthenticateUser(string username, string password);
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

        public void AddUser(string username, string email, string password, string avatar)
        {
            var user = new User
            {
                Username = username,
                Email = email,
                Password = password,
                Avatar = avatar
            };
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
            LoggedUser = user;

            return user != null;
        }
    }
}
