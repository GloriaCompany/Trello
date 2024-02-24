using System.Collections.Generic;

namespace TrelloApp.Models
{
    public class TaskModel
    {
        public int TaskID { get; }
        public int UserID { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public List<CheckBoxModel> CheckBoxes { get; set; }
    }
}
