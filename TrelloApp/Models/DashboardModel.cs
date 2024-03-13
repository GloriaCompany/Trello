using System.Collections.Generic;
using TrelloDBLayer;

namespace TrelloApp.Models
{
    public class DashboardModel
    {
        public string Username { get; set; }
        public string Avatar { get; set; }
        public List<Board> Boards { get; set; }

        public DashboardModel(string username, string avatar, List<Board> boards)
        {
            Username = username;
            Avatar = avatar;
            Boards = boards;
        }
    }
}