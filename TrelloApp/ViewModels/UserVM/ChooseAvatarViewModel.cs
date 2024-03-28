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
        // Репозиторій для методології завантаження зображень
        private readonly IAvatarRepository _avatarRepository;

        // Конструктор, що ініціалізує ViewModel.
        public ChooseAvatarViewModel(IAvatarRepository avatarRepository)
        {
            _avatarRepository = avatarRepository;
            AvatarImages = new ObservableCollection<BitmapImage>();
            SelectAvatarCommand = new DelegateCommand(SelectAvatar, parameter => true);
            LoadAvatarImages();
        }

        // Метод для завантаження зображень аватарів.
        private void LoadAvatarImages()
        {
            try
            {
                AvatarImages = _avatarRepository.GetAvatarImages();
            }
            catch (Exception ex)
            {
                // Обработка исключения при ошибке загрузки изображений
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
