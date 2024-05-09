using System;
using System.Collections.ObjectModel;
using System.Windows.Media.Imaging;

namespace TrelloApp.ViewModels.UserVM.UserAvatarsLoading
{
    public class AvatarRepository : IAvatarRepository
    {
        private readonly IImageLoader _resourceImageLoader;
        private readonly IImageLoader _folderImageLoader;

        public AvatarRepository(IImageLoader resourceImageLoader, IImageLoader folderImageLoader)
        {
            _resourceImageLoader = resourceImageLoader ?? throw new ArgumentNullException(nameof(resourceImageLoader));
            _folderImageLoader = folderImageLoader ?? throw new ArgumentNullException(nameof(folderImageLoader));
        }

        public ObservableCollection<BitmapImage> GetAvatarImages()
        {
            var avatarImages = new ObservableCollection<BitmapImage>();

            try
            {
                // Завантаження зображень з різних джерел: ресурсів та папки.
                var resourceImages = _resourceImageLoader.LoadImages();
                var folderImages = _folderImageLoader.LoadImages();

                // Додавання завантажених зображень у колекцію AvatarImages.
                if (resourceImages != null)
                {
                    foreach (var image in resourceImages)
                    {
                        avatarImages.Add(image);
                    }
                }

                if (folderImages != null)
                {
                    foreach (var image in folderImages)
                    {
                        avatarImages.Add(image);
                    }
                }
            }
            catch (Exception ex)
            {
                // Обробка винятку у випадку помилки завантаження зображень.
                Console.WriteLine($"Error loading avatar images: {ex.Message}");
            }

            return avatarImages;
        }
    }
}
