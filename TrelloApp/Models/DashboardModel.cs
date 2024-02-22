using System;
using System.Collections.Generic;

namespace TrelloApp.Models
{
    public class DashboardModel
    {
        public UserModel User { get; set; } = new UserModel();
        public List<BoardModel> Boards { get; set; } = new List<BoardModel>();
    }
}
