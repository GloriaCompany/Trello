using System.Collections.Generic;

namespace TrelloApp.Models
{
    public class ColumnModel
    {
        // TODO: New Specific Model + Validations
        public int ColumnID { get; }
        public string ColumnName { get; set; }
        public List<TaskModel> TaskDetailes { get; set; }
    }
}
