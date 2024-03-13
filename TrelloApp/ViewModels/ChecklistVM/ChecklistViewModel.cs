using System;
using System.Windows;
using System.Windows.Input;
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

        public ICommand LoadChecksCommand { get; set; }

        public ChecklistViewModel(Checklist currentChecklist)
        {
            _checklist = currentChecklist;
            LoadChecksCommand = new RelayCommand(() => LoadChecks(_checklist.ChecklistID), CanLoadChecks);
        }

        private bool CanLoadChecks()
        {
            bool res = true;
            // ?Check != null;

            ((RelayCommand)LoadChecksCommand).RaiseCanExecuteChanged();

            return res;
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
