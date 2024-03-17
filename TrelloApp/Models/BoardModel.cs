using System.Collections.Generic;
using TrelloDBLayer;

namespace TrelloApp.Models
{
    public class BoardModel : Board
    {
        public string BoardTitle { get; set; }
        public List<ColumnModel> Columns { get; set; }
        public List<UserModel> Users { get; set; }

        public BoardModel(string boardtitle, List<ColumnModel> colums, List<UserModel> users)
        {
            BoardTitle = boardtitle;
            Columns = colums;
            Users = users;
        }
        #region Валідація
        public string this[string columnName]
        {
            get
            {
                string error = null;

                if (columnName == nameof(BoardTitle))
                {
                    if (string.IsNullOrWhiteSpace(BoardTitle))
                        error = "Назва дошки є обов'язковою";
                    else if (BoardTitle.Length > 100)
                        error = "Максимальна довжина назви дошки - 100 символів";
                    else if (BoardTitle.Length < 3)
                        error = "Мінімальна довжина назви дошки - 3 символи";
                }
                else if (columnName == nameof(Columns))
                {
                    if (Columns == null || Columns.Count == 0)
                        error = "Список стовпців не може бути порожнім";
                }
                else if (columnName == nameof(Users))
                {
                    if (Users == null || Users.Count == 0)
                        error = "Список користувачів не може бути порожнім";
                }
                return error;
            }
        }
        #endregion
    }
}