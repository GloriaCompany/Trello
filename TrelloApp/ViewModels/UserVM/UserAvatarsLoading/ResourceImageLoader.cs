using System.Collections.ObjectModel;
using System.Windows.Media.Imaging;

namespace TrelloApp.ViewModels.UserVM.UserAvatarsLoading
{
    public class ResourceImageLoader : IImageLoader
    {
        // Метод LoadImages завантажує зображення аватарів з ресурсів і повертає їх у вигляді колекції BitmapImage.
        public ObservableCollection<BitmapImage> LoadImages()
        {
            var resourceImages = new ObservableCollection<BitmapImage>();

            // Доступ до менеджера ресурсів, де зберігаються аватари.
            var resourceManager = Views.ResourcesTrello.UserAvatars.ResourceManager;

            // Прохід по номерам ресурсів (аватарів) та їх завантаження.
            for (int i = 1; i <= 21; i++)
            {
                // Формування імені ресурсу.
                string resourceName = $"Avatar{i:D2}";

                // Отримання ресурсу з менеджера ресурсів.
                var bitmap = (System.Drawing.Bitmap)resourceManager.GetObject(resourceName);

                // Якщо ресурс не пустий, то конвертуємо його в BitmapImage та додаємо до колекції.
                if (bitmap != null)
                {
                    // Конвертування Bitmap у BitmapImage.
                    using (var memoryStream = new System.IO.MemoryStream())
                    {
                        bitmap.Save(memoryStream, System.Drawing.Imaging.ImageFormat.Png);
                        memoryStream.Position = 0;

                        var bitmapImage = new BitmapImage();
                        bitmapImage.BeginInit();
                        bitmapImage.CacheOption = BitmapCacheOption.OnLoad;
                        bitmapImage.StreamSource = memoryStream;
                        bitmapImage.EndInit();

                        resourceImages.Add(bitmapImage);
                    }
                }
            }

            // Повернення колекції завантажених зображень.
            return resourceImages;
        }
    }
}
