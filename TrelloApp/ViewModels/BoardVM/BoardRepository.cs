using System;
using System.Collections.Generic;
using TrelloApp.ViewModels.Base;
using TrelloDBLayer;

namespace TrelloApp.ViewModels.BoardVM
{
    public interface IBoardRepository
    {
        void AddBoard(Board board);
        void DelBoard(int boardID);
        void UpdateBoard(Board board);
        List<Board> GetBoardsByUserID(int userID);
    }

    internal class BoardRepository : IBoardRepository
    {
        private ITrelloDataClassesDataContext _dbContext;
        public ITrelloDataClassesDataContext DbContext
        {
            get { return _dbContext; }
            set { _dbContext = value; }
        }

        public BoardRepository() { }
        public BoardRepository(ITrelloDataClassesDataContext dbContext)
        {
            _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
        }

        public void AddBoard(Board board)
        {
            if (board == null)
            {
                throw new ArgumentNullException(nameof(board));
            }

            try
            {
                _dbContext.AddBoard(board);
                _dbContext.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception("Failed to add board.", ex);
            }
        }

        public void DelBoard(int boardID)
        {
            //Сделать isExist тут или в DataContext
            if (boardID < 0)
            {
                throw new ArgumentNullException(nameof(boardID));
            }

            try
            {
                _dbContext.DelBoard(boardID);
                _dbContext.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception("Failed to delete board.", ex);
            }
        }

        public void UpdateBoard(Board board)
        {
            if (board == null)
            {
                throw new ArgumentNullException(nameof(board));
            }

            try
            {
                _dbContext.UpdateBoard(board);
                _dbContext.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception("Failed to update board.", ex);
            }
        }

        public List<Board> GetBoardsByUserID(int userID)
        {
            //Сделать isExist тут или в DataContext
            if (userID < 0)
            {
                throw new ArgumentNullException(nameof(userID));
            }

            try
            {
                return _dbContext.GetBoardsByUserID(userID);
            }
            catch (Exception ex)
            {
                throw new Exception("Failed to get boards.", ex);
            }
        }
    }
}
