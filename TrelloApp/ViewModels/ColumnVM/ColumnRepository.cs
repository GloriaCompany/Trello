using System;
using System.Collections.Generic;
using TrelloApp.Models;
using TrelloApp.ViewModels.Base;
using TrelloDBLayer;

namespace TrelloApp.ViewModels.ColumnVM
{
    public interface IColumnRepository
    {
        void AddColumn(Column column);
        void DelColumn(int columnID);
        void UpdateColumn(Column column);
        List<Column> GetColumnsByBoardID(int boardID);
    }

    internal class ColumnRepository : IColumnRepository
    {
        private ITrelloDataClassesDataContext _dbContext;
        public ITrelloDataClassesDataContext DbContext
        {
            get { return _dbContext; }
            set { _dbContext = value; }
        }

        public ColumnRepository() { }
        public ColumnRepository(ITrelloDataClassesDataContext dbContext)
        {
            _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
        }

        public void AddColumn(Column column)
        {
            if (column == null)
            {
                throw new ArgumentNullException(nameof(column));
            }

            try
            {
                _dbContext.AddColumn(column);
                _dbContext.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception("Failed to add column.", ex);
            }
        }

        public void DelColumn(int columnID)
        {
            if (columnID < 0)
            {
                throw new ArgumentNullException(nameof(columnID));
            }

            try
            {
                _dbContext.DelColumn(columnID);
                _dbContext.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception("Failed to delete column.", ex);
            }
        }

        public void UpdateColumn(Column column)
        {
            if (column == null)
            {
                throw new ArgumentNullException(nameof(column));
            }

            try
            {
                _dbContext.UpdateColumn(column);
                _dbContext.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception("Failed to update column.", ex);
            }
        }

        public List<Column> GetColumnsByBoardID(int boardID)
        {
            if (boardID < 0)
            {
                throw new ArgumentNullException(nameof(boardID));
            }

            try
            {
                return _dbContext.GetColumnsByBoardID(boardID);
            }
            catch (Exception ex)
            {
                throw new Exception("Failed to get columns.", ex);
            }
        }
    }
}
