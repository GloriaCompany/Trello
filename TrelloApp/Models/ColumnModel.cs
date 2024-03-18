using System;
using System.Collections.Generic;
using TrelloDBLayer;

namespace TrelloApp.Models
{
    public class ColumnModel
    {
        public int ColumnID { get; set; }
        public string ColumnName { get; set; }
        public List<TaskModel> Tasks { get; set; }

        public ColumnModel(int columnId, string columnname, List<TaskModel> tasks)
        {
            ColumnID = columnId;
            ColumnName = columnname;
            Tasks = tasks;
        }

        #region Валідація
        private string _error;

        public string this[string columnName]
        {
            get
            {
                _error = null;
                if (columnName == nameof(ColumnName))
                {
                    if (string.IsNullOrWhiteSpace(ColumnName))
                        _error = "Назва колонки є обов'язковою для заповнення";
                }
                return _error;
            }
        }
        public string Error => _error;
        #endregion
    }
}