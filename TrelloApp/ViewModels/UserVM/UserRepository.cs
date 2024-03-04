using System;
using TrelloApp.ViewModels.Base;
using TrelloDBLayer;

namespace TrelloApp.ViewModels.UserVM
{
    public interface IUserRepository
    {
        void AddUser(User user);
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
    }
}
