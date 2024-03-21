using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows.Media.Imaging;

namespace TrelloApp.ViewModels.UserVM.UserAvatarsLoading
{
    // Клас FolderImageLoader відповідає за завантаження зображень з папки.
    public class FolderImageLoader : IImageLoader
    {
        // Хеш-множина для збереження шляхів до вже завантажених зображень.
        private HashSet<string> _loadedImagePaths = new HashSet<string>();

        // Метод LoadImages завантажує зображення з папки і повертає їх у вигляді колекції BitmapImage.
        public ObservableCollection<BitmapImage> LoadImages()
        {
            var folderImages = new ObservableCollection<BitmapImage>();

            try
            {
                // Отримання шляху до папки з аватарками користувачів.
                string projectDirectory = System.IO.Directory.GetParent(System.IO.Directory.GetCurrentDirectory()).Parent.FullName;
                string avatarsFolderPath = System.IO.Path.Combine(projectDirectory, "UserAvatars");

                // Отримання переліку файлів з розширенням .png у вказаній папці.
                var files = System.IO.Directory.GetFiles(avatarsFolderPath, "*.png");

                // Прохід по кожному файлу.
                foreach (var file in files)
                {
                    // Перевірка чи файл не був вже завантажений.
                    if (!_loadedImagePaths.Contains(file))
                    {
                        // Створення об'єкту BitmapImage для поточного файлу та його додавання у колекцію.
                        var bitmapImage = new BitmapImage(new Uri(file));
                        folderImages.Add(bitmapImage);
                        // Додавання шляху файлу до списку вже завантажених.
                        _loadedImagePaths.Add(file);
                    }
                }
            }
            catch (Exception ex)
            {
                // Обробка винятку, якщо виникла помилка під час завантаження зображень з папки.
                Console.WriteLine($"Error loading images from folder: {ex.Message}");
            }

            // Повернення колекції завантажених зображень.
            return folderImages;
        }
    }
}
