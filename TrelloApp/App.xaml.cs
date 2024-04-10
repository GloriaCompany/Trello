using System.Windows;
using TrelloApp.ViewModels.Base;
using TrelloApp.ViewModels.UserVM.UserAvatarsLoading;
using TrelloApp.ViewModels.UserVM;
using TrelloApp.ViewModels.BoardVM;

namespace TrelloApp
{
    /// <summary>
    /// Логика взаимодействия для App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            var userRepository = new UserRepository(new TrelloDataContext());
            Resources.Add("UserRepository", userRepository);

            var boardRepository = new BoardRepository(new TrelloDataContext());
            Resources.Add("BoardRepository", boardRepository);

            var av = new AvatarRepository(new ResourceImageLoader(), new FolderImageLoader());
            Resources.Add("AvatarRepository", av);
        }
    }
}
