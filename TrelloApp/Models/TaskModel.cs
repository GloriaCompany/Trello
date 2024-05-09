using System.ComponentModel;
using TrelloDBLayer;

namespace TrelloApp.Models
{
    public class TaskModel : Task, IDataErrorInfo
    {
        private string _error;

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

                return error;
            }
        }
        public string Error => _error;
    }
}