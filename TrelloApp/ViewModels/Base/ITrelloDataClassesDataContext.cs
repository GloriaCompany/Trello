using System.Collections.Generic;
using System.Linq;
using TrelloDBLayer;

namespace TrelloApp.ViewModels.Base
{
    public interface ITrelloDataClassesDataContext
    {
        IQueryable<User> Users { get; }
        IQueryable<Board> Boards { get; }

        void AddUser(User user);
        User GetUserByID(int userID);
        void UpdateUser(User user);

        void AddBoard(Board board);
        void DelBoard(int boardID);
        List<Board> GetBoardsByUserID(int userID);

        void SaveChanges();
    }
}