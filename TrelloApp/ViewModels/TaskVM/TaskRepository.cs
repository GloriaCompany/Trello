using System;
using System.Collections.Generic;
using TrelloApp.ViewModels.Base;
using TrelloDBLayer;

namespace TrelloApp.ViewModels.TaskVM
{
    public interface ITaskRepository
    {
        void AddTask(Task task);
        void DelTask(int taskID);
        void UpdateTask(Task task);
        List<Task> GetTasksByColumnID(int columnID);
    }

    internal class TaskRepository : ITaskRepository
    {
        private ITrelloDataClassesDataContext _dbContext;
        public ITrelloDataClassesDataContext DbContext
        {
            get { return _dbContext; }
            set { _dbContext = value; }
        }

        public TaskRepository() { }
        public TaskRepository(ITrelloDataClassesDataContext dbContext)
        {
            _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
        }

        public void AddTask(Task task)
        {
            if (task == null)
            {
                throw new ArgumentNullException(nameof(task));
            }

            try
            {
                _dbContext.AddTask(task);
                _dbContext.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception("Failed to add task.", ex);
            }
        }

        public void DelTask(int taskID)
        {
            if (taskID < 0)
            {
                throw new ArgumentNullException(nameof(taskID));
            }

            try
            {
                _dbContext.DelTask(taskID);
                _dbContext.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception("Failed to delete task.", ex);
            }
        }

        public void UpdateTask(Task task)
        {
            if (task == null)
            {
                throw new ArgumentNullException(nameof(task));
            }

            try
            {
                _dbContext.UpdateTask(task);
                _dbContext.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception("Failed to update task.", ex);
            }
        }

        public List<Task> GetTasksByColumnID(int columnID)
        {
            //Сделать isExist тут или в DataContext
            if (columnID < 0)
            {
                throw new ArgumentNullException(nameof(columnID));
            }

            try
            {
                return _dbContext.GetTasksByColumnID(columnID);
            }
            catch (Exception ex)
            {
                throw new Exception("Failed to get tasks.", ex);
            }
        }
    }
}
