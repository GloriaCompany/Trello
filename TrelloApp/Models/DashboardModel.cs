using System.Collections.Generic;

namespace TrelloApp.Models
{
    public class DashboardModel
    {
        public string UserName { get; set; }
        public int AvatarID { get; set; }
        public List<BoardModel> Boards { get; set; }
    }
}
