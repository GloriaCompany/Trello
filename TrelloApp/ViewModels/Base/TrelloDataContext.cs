using System.Collections.Generic;
using System.Linq;
using TrelloApp.Models;
using TrelloDBLayer;

namespace TrelloApp.ViewModels.Base
{
    internal class TrelloDataContext : ITrelloDataClassesDataContext
    {
        private readonly TrelloDataClassesDataContext _context;

        public TrelloDataContext()
        {
            _context = new TrelloDataClassesDataContext();
        }

        public IQueryable<User> Users => _context.User;
        public IQueryable<Board> Boards => _context.Board;
        public IQueryable<Column> Columns => _context.Column;
        public IQueryable<Task> Tasks => _context.Task;
        public IQueryable<Checklist> Checklists => _context.Checklist;

        public void AddUser(UserModel user)
        {
            _context.User.InsertOnSubmit(user);
            SaveChanges();
        }
        public User GetUserByID(int userID) => _context.User.FirstOrDefault(u => u.UserID == userID);
        public void UpdateUser(UserModel user)
        {
            var existingUser = _context.User.FirstOrDefault(u => u.UserID == user.UserID);

            existingUser.Username = user.Username;
            existingUser.Email = user.Email;
            existingUser.Password = user.Password;
            existingUser.Avatar = user.Avatar;

            SaveChanges();
        }

        public void AddBoard(BoardModel board)
        {
            _context.Board.InsertOnSubmit(board);
            SaveChanges();
        }
        public void DelBoard(int boardID)
        {
            var boardToDelete = _context.Board.FirstOrDefault(b => b.BoardID == boardID);
            _context.Board.DeleteOnSubmit(boardToDelete);

            SaveChanges();
        }
        public void UpdateBoard(BoardModel board)
        {
            var existingBoard = _context.Board.FirstOrDefault(b => b.BoardID == board.BoardID);

            existingBoard.Title = board.Title;

            SaveChanges();
        }
        public List<Board> GetBoardsByUserID(int userID) => _context.Board.Where(b => b.AdminID == userID).ToList();

        public void AddColumn(ColumnModel column)
        {
            _context.Column.InsertOnSubmit(column);
            SaveChanges();
        }
        public void DelColumn(int columnID)
        {
            var columnToDelete = _context.Column.FirstOrDefault(c => c.ColumnID == columnID);
            _context.Column.DeleteOnSubmit(columnToDelete);

            SaveChanges();
        }
        public void UpdateColumn(ColumnModel column)
        {
            var existingColumn = _context.Column.FirstOrDefault(c => c.ColumnID == column.ColumnID);

            existingColumn.Title = column.Title;
            existingColumn.Color = column.Color;

            SaveChanges();
        }
        public List<Column> GetColumnsByBoardID(int boardID) => _context.Column.Where(c => c.BoardID == boardID).ToList();

        public void AddTask(TaskModel task)
        {
            _context.Task.InsertOnSubmit(task);
            SaveChanges();
        }
        public void DelTask(int taskID)
        {
            var taskToDelete = _context.Task.FirstOrDefault(t => t.TaskID == taskID);
            _context.Task.DeleteOnSubmit(taskToDelete);

            SaveChanges();
        }
        public void UpdateTask(TaskModel task)
        {
            var existingTask = _context.Task.FirstOrDefault(t => t.TaskID == t.TaskID);

            existingTask.Title = task.Title;
            existingTask.Description = task.Description;

            SaveChanges();
        }
        public List<Task> GetTasksByColumnID(int columnID) => _context.Task.Where(t => t.ColumnID == columnID).ToList();

        public void AddChecklist(ChecklistModel checklist)
        {
            _context.Checklist.InsertOnSubmit(checklist);
            SaveChanges();
        }
        public void DelChecklist(int checklistID)
        {
            var checklistToDelete = _context.Checklist.FirstOrDefault(ch => ch.ChecklistID == checklistID);
            _context.Checklist.DeleteOnSubmit(checklistToDelete);

            SaveChanges();
        }
        public List<Checklist> GetChecklistsByTaskID(int taskID) => _context.Checklist.Where(ch => ch.TaskID == taskID).ToList();

        public void SaveChanges() => _context.SubmitChanges();
    }
}
