using System.Collections.ObjectModel;
using TrelloApp.Models;
using TrelloDBAccess;

namespace TrelloApp.ViewModels
{
    public class ProjectsViewModel
    {
        private readonly TrelloDataClassesDataContext _db = new TrelloDataClassesDataContext();
        public ObservableCollection<ProjectModel> Projects { get; } = new ObservableCollection<ProjectModel>();

        public ProjectsViewModel()
        {
            LoadProjects();
        }

        private void LoadProjects()
        {
            foreach (var project in _db.Projects)
            {
                Projects.Add(new ProjectModel
                {
                    ProjectName = project.ProjectName
                });
            }
        }
    }
}
