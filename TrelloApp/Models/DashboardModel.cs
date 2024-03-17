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
        #region Валідація
        public string this[string columnName]
        {
            get
            {
                string error = null;

                if (columnName == nameof(Username))
                {
                    if (string.IsNullOrWhiteSpace(Username))
                        error = "Ім'я користувача є обов'язковим";
                    else if (Username.Length > 20)
                        error = "Максимальна довжина імені користувача - 20 символів";
                    else if (Username.Length < 2)
                        error = "Мінімальна довжина імені користувача - 2 символи";
                }
                else if (columnName == nameof(Avatar))
                {
                    if (string.IsNullOrWhiteSpace(Avatar))
                        error = "Аватар є обов'язковим";
                }
                else if (columnName == nameof(Boards))
                {
                    if (Boards == null || Boards.Count == 0)
                        error = "Список дошок не може бути порожнім";
                }
                return error;
            }
        }
        #endregion
    }
}