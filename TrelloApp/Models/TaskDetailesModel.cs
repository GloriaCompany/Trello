using System;

namespace TrelloApp.Models
{
    public class TaskDetailesModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public bool IsCompleted { get; set; }
        public UserModel AssignedUser { get; set; } // Інформація про призначеного користувача


        public TaskDetailesModel()
        {
            
            AssignedUser = new UserModel();
        }
    }
}
