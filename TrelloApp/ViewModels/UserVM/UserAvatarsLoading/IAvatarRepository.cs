using System.Collections.ObjectModel;
using System.Windows.Media.Imaging;

namespace TrelloApp.ViewModels.UserVM.UserAvatarsLoading
{
    public interface IAvatarRepository
    {
        ObservableCollection<BitmapImage> GetAvatarImages();
    }
}
