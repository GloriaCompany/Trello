using System.Collections.ObjectModel;
using System.Windows.Media.Imaging;

namespace TrelloApp.ViewModels.UserVM.UserAvatarsLoading
{
    public interface IImageLoader
    {
        // Метод завантаження зображень
        ObservableCollection<BitmapImage> LoadImages();
    }
}
