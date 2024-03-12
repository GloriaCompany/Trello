using System;
using System.Windows;
using TrelloApp.ViewModels.Base;
using TrelloApp.ViewModels.CheckVM;
using TrelloDBLayer;

namespace TrelloApp.ViewModels.ChecklistVM
{
    public class ChecklistViewModel : ViewModelBase
    {
        private Checklist _checklist;
        public Checklist Checklist
        {
            get { return _checklist; }
            set
            {
                _checklist = value;
                OnPropertyChanged(nameof(Checklist));
            }
        }

        private IChecklistRepository _checklistRepository;
        public IChecklistRepository ChecklistRepository
        {
            get { return _checklistRepository; }
            set { _checklistRepository = value; }
        }

        public ChecklistViewModel(Checklist currentChecklist)
        {
            LoadChecks(currentChecklist.ChecklistID);
        }

        public void LoadChecks(int chelistID)
        {
            try
            {
                //Load checks
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
