using System.Collections.Generic;

namespace TrelloApp.Models
{
    public class DashboardModel
    {
        // TODO: New Specific Model + Validations
        public string Username { get; set; }
        public string Avatar { get; set; }
        public List<BoardModel> Boards { get; set; }
    }
}
