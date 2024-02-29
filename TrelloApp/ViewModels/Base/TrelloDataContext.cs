﻿using System.Linq;
using TrelloDBLayer;

namespace TrelloApp.ViewModels.Base
{
    internal class TrelloDataContext : ITrelloDataClassesDataContext
    {
        private readonly TrelloDataClassesDataContext _context;

        public TrelloDataContext(string connectionString)
        {
            _context = new TrelloDataClassesDataContext(connectionString);
        }

        public IQueryable<User> Users => _context.User;

        public void SaveChanges()
        {
            _context.SubmitChanges();
        }
    }
}