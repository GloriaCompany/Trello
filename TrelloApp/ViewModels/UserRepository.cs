﻿using System;
using System.Linq;
using TrelloApp.ViewModels.Base;
using TrelloDBLayer;

namespace TrelloApp.ViewModels
{
    public interface IUserRepository
    {
        void AddUser(User user);
    }

    internal class UserRepository : IUserRepository
    {
        private readonly ITrelloDataClassesDataContext _dbContext;

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
                var userList = _dbContext.Users.ToList();
                userList.Add(user);
                _dbContext.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception("Failed to add user.", ex);
            }
        }
    }

}
