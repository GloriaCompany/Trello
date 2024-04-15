using System.Collections.Generic;
using System.Linq;
using TrelloApp.Models;
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
        void DelUser(int userID);
        void UpdateUser(User user);
        User GetUserByID(int userID);
        bool AuthenticateUser(string username, string password);

        void AddBoard(BoardModel board);
        void DelBoard(int boardID);
        void UpdateBoard(BoardModel board);
        List<Board> GetBoardsByUserID(int userID);

        void AddColumn(ColumnModel column);
        void DelColumn(int columnID);
        void UpdateColumn(ColumnModel column);
        List<Column> GetColumnsByBoardID(int boardID);

        void AddTask(TaskModel task);
        void DelTask(int taskID);
        void UpdateTask(TaskModel task);
        List<Task> GetTasksByColumnID(int columnID);

        void AddChecklist(ChecklistModel checklist);
        void DelChecklist(int checklistID);
        List<Checklist> GetChecklistsByTaskID(int taskID);

        void SaveChanges();
    }
}