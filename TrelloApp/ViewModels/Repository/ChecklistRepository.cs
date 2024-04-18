using System;
using System.Collections.Generic;
using TrelloApp.Models;
using TrelloApp.ViewModels.Base;
using TrelloDBLayer;

namespace TrelloApp.ViewModels.Repository
{
    public interface IChecklistRepository
    {
        void AddChecklist(ChecklistModel checklist);
        void DelChecklist(int checklistID);
        List<Checklist> GetChecklistsByTaskID(int taskID);
    }

    public class ChecklistRepository : IChecklistRepository
    {
        private ITrelloDataClassesDataContext _dbContext;
        public ITrelloDataClassesDataContext DbContext
        {
            get { return _dbContext; }
            set { _dbContext = value; }
        }

        public ChecklistRepository() { }
        public ChecklistRepository(ITrelloDataClassesDataContext dbContext)
        {
            _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
        }

        public void AddChecklist(ChecklistModel checklist)
        {
            if (checklist == null)
            {
                throw new ArgumentNullException(nameof(checklist));
            }

            try
            {
                _dbContext.AddChecklist(checklist);
                _dbContext.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception("Failed to add checklist.", ex);
            }
        }

        public void DelChecklist(int checklistID)
        {
            if (checklistID < 0)
            {
                throw new ArgumentNullException(nameof(checklistID));
            }

            try
            {
                _dbContext.DelChecklist(checklistID);
                _dbContext.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception("Failed to delete checklist.", ex);
            }
        }

        public List<Checklist> GetChecklistsByTaskID(int taskID)
        {
            if (taskID < 0)
            {
                throw new ArgumentNullException(nameof(taskID));
            }

            try
            {
                return _dbContext.GetChecklistsByTaskID(taskID);
            }
            catch (Exception ex)
            {
                throw new Exception("Failed to get checklist.", ex);
            }
        }
    }
}
