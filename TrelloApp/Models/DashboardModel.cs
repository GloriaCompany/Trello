using System.Collections.Generic;

namespace TrelloApp.Models
{
    public class DashboardModel
    {
        public string Username { get; set; }
        public string Avatar { get; set; }
        public List<BoardModel> Boards { get; set; }
    }
}
