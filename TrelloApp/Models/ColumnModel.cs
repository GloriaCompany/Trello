using System;
using System.Collections.Generic;

namespace TrelloApp.Models
{
    public class ColumnModel
    {
        
        public int ColumnID { get; set; }

        
        private string _columnName;
        public string ColumnName
        {
            get => _columnName;
            set
            {
                
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException("Назва стовпця не може бути порожньою або нульовою.");

                _columnName = value;
            }
        }

        
        public List<TaskModel> Tasks { get; set; }
    }
}