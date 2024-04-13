using System.Windows;
using TrelloApp.ViewModels.Base;
using TrelloApp.ViewModels.UserVM.UserAvatarsLoading;
using TrelloApp.ViewModels.UserVM;
using TrelloApp.ViewModels.BoardVM;
using System;
using System.Windows.Navigation;
using TrelloApp.Helpers;

namespace TrelloApp
{
    /// <summary>
    /// Логика взаимодействия для App.xaml
    /// </summary>
    /// 
    public partial class App : Application, INavigator
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            var dc = new TrelloDataContext();
            var userRepository = new UserRepository(dc);
            Resources.Add("UserRepository", userRepository);

            var boardRepository = new BoardRepository(dc);
            Resources.Add("BoardRepository", boardRepository);

            var av = new AvatarRepository(new ResourceImageLoader(), new FolderImageLoader());
            Resources.Add("AvatarRepository", av);

            Resources.Add("Navigation", this);
        }
        public void GoTo(string path) 
        {
            (MainWindow as NavigationWindow).Source = new Uri(path, UriKind.Relative);
        }
    }
}
