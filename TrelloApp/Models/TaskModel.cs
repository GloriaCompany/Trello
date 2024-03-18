using System.Collections.Generic;

namespace TrelloApp.Models
{
    public class TaskModel
    {
        public int? TaskID { get; set; }
        public int UserID { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public List<ChecklistModel> CheckBoxes { get; set; }

        public TaskModel(int userId, string title, string description, List<ChecklistModel> checkBoxes)
        {
            UserID = userId;
            Title = title;
            Description = description;
            CheckBoxes = checkBoxes;
        }

        #region Валідація
        public string Error => null;

        public string this[string columnName]
        {
            get
            {
                string error = null;

                if (columnName == nameof(Title))
                {
                    if (string.IsNullOrWhiteSpace(Title))
                        error = "Назва завдання є обов'язковою";
                    else if (Title.Length > 100)
                        error = "Максимальна довжина назви - 100 символів";
                }
                else if (columnName == nameof(Description))
                {
                    if (string.IsNullOrWhiteSpace(Description))
                        error = "Опис завдання є обов'язковим";
                    else if (Description.Length > 500)
                        error = "Максимальна довжина опису - 500 символів";
                }
                else if (columnName == nameof(UserID))
                {
                    if (UserID <= 0)
                        error = "Ідентифікатор користувача повинен бути більше 0";
                }
                else if (columnName == nameof(CheckBoxes))
                {
                    if (CheckBoxes == null || CheckBoxes.Count == 0)
                        error = "Список чекбоксів не може бути порожнім";
                }

                return error;
            }
        }
        #endregion
    }
}