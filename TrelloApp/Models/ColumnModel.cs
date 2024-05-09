using System.ComponentModel;
using TrelloDBLayer;

namespace TrelloApp.Models
{
    public class ColumnModel : Column, IDataErrorInfo
    {
        private string _error;

        public string this[string columnName]
        {
            get
            {
                _error = null;
                if (columnName == nameof(Title))
                {
                    if (string.IsNullOrWhiteSpace(Title))
                        _error = "Назва колонки є обов'язковою для заповнення";
                }
                return _error;
            }
        }
        public string Error => _error;
    }
}