using System.Collections.Generic;
using System.Linq;
using TrelloDBLayer;

namespace TrelloApp.ViewModels.Base
{
    public interface ITrelloDataClassesDataContext
    {
        IQueryable<User> Users { get; }
        IQueryable<Board> Boards { get; }
        IQueryable<Column> Columns { get; }
        IQueryable<Task> Tasks { get; }
        IQueryable<Checklist> Checklists { get; }

        void AddUser(User user);
        User GetUserByID(int userID);
        void UpdateUser(User user);

        void AddBoard(Board board);
        void DelBoard(int boardID);
        void UpdateBoard(Board board);
        List<Board> GetBoardsByUserID(int userID);

        void AddColumn(Column column);
        void DelColumn(int columnID);
        void UpdateColumn(Column column);
        List<Column> GetColumnsByBoardID(int boardID);

        void AddTask(Task task);
        void DelTask(int taskID);
        void UpdateTask(Task task);
        List<Task> GetTasksByColumnID(int columnID);

        void AddChecklist(Checklist checklist);
        void DelChecklist(int checklistID);
        List<Checklist> GetChecklistsByTaskID(int taskID);

        void SaveChanges();
    }
}