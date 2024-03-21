using System;
using System.Collections.ObjectModel;
using System.Windows.Media.Imaging;
using TrelloApp.ViewModels.Base;
using TrelloApp.ViewModels.UserVM.UserAvatarsLoading;

namespace TrelloApp.ViewModels.UserVM
{
    public class ChooseAvatarViewModel : ViewModelBase
    {
        // Колекція зображень аватарів.
        public ObservableCollection<BitmapImage> AvatarImages { get; set; }
        // Обране зображення аватара.
        public BitmapImage SelectedAvatar { get; set; }
        // Команда для вибору аватара.
        public DelegateCommand SelectAvatarCommand { get; set; }

        // Конструктор, що ініціалізує ViewModel.
        public ChooseAvatarViewModel(IImageLoader resourceImageLoader, IImageLoader folderImageLoader)
        {
            AvatarImages = new ObservableCollection<BitmapImage>();
            SelectAvatarCommand = new DelegateCommand(SelectAvatar, parameter => true);
            LoadAvatarImages(resourceImageLoader, folderImageLoader);
        }

        // Метод для завантаження зображень аватарів.
        private void LoadAvatarImages(IImageLoader resourceImageLoader, IImageLoader folderImageLoader)
        {
            try
            {
                AvatarImages = new ObservableCollection<BitmapImage>();

                // Завантаження зображень з різних джерел: ресурсів та папки.
                var resourceImages = resourceImageLoader.LoadImages();
                var folderImages = folderImageLoader.LoadImages();

                // Додавання завантажених зображень у колекцію AvatarImages.
                if (resourceImages != null)
                {
                    foreach (var image in resourceImages)
                    {
                        AvatarImages.Add(image);
                    }
                }

                if (folderImages != null)
                {
                    foreach (var image in folderImages)
                    {
                        AvatarImages.Add(image);
                    }
                }
            }
            catch (Exception ex)
            {
                // Обробка винятку у випадку помилки завантаження зображень.
                Console.WriteLine($"Error loading avatar images: {ex.Message}");
            }
        }

        // Метод для вибору аватара.
        private void SelectAvatar(object parameter)
        {
            SelectedAvatar = parameter as BitmapImage;
        }
    }
}
