using System;
using System.Collections.Generic;

namespace TrelloApp.Models
{
    public class DashboardModel
    {
        public string Title { get; set; }
        public string CompanyName { get; set; }
        public int CompanyAvatar { get; set; }
        public List<UserModel> Users { get; set; }
        public List<TaskDetailesModel> Tasks { get; set; }

        public DashboardModel()
        {
            Tasks = new List<TaskDetailesModel>();
            Users = new List<UserModel>();
        }
    }
}
