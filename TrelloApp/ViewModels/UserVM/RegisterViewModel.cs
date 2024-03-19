using System;
using System.Collections.ObjectModel;
using System.IO;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media.Imaging;
using TrelloApp.Models;
using TrelloApp.ViewModels.Base;

namespace TrelloApp.ViewModels.UserVM
{
    public class RegisterViewModel : ViewModelBase
    {
        private UserModel _user;
        public UserModel User
        {
            get { return _user; }
            set
            {
                _user = value;
                OnPropertyChanged(nameof(User));
            }
        }

        private ObservableCollection<BitmapImage> _avatarImages;
        public ObservableCollection<BitmapImage> AvatarImages
        {
            get { return _avatarImages; }
            set
            {
                _avatarImages = value;
                OnPropertyChanged(nameof(AvatarImages));
            }
        }

        private IUserRepository _userRepository;
        public IUserRepository UserRepository
        {
            get { return _userRepository; }
            set { _userRepository = value; }
        }

        public ICommand RegisterCommand { get; set; }

        public RegisterViewModel()
        {
            _user = new UserModel();
            RegisterCommand = new RelayCommand(Register, CanRegister);
            LoadAvatarImagesFromResources();
        }

        private void LoadAvatarImagesFromResources()
        {
            // Отримуємо доступ до ресурсів
            var resourceManager = TrelloApp.Views.ResourcesTrello.UserAvatars.ResourceManager;

            AvatarImages = new ObservableCollection<BitmapImage>();

            // Завантажуємо зображення аватарок
            for (int i = 1; i <= 21; i++)
            {
                // Формуємо ім'я ресурсу
                string resourceName = $"Avatar{i.ToString("D2")}"; // Форматуємо номер аватара, щоб отримати його ім'я

                // Отримуємо зображення з ресурсів
                var bitmap = (System.Drawing.Bitmap)resourceManager.GetObject(resourceName);
                if (bitmap != null)
                {
                    // Перетворюємо Bitmap в BitmapImage
                    using (var memoryStream = new MemoryStream())
                    {
                        bitmap.Save(memoryStream, System.Drawing.Imaging.ImageFormat.Png);
                        memoryStream.Position = 0;

                        var bitmapImage = new BitmapImage();
                        bitmapImage.BeginInit();
                        bitmapImage.CacheOption = BitmapCacheOption.OnLoad;
                        bitmapImage.StreamSource = memoryStream;
                        bitmapImage.EndInit();

                        // Додаємо BitmapImage до колекції
                        AvatarImages.Add(bitmapImage);
                    }
                }
            }
        }

        private bool CanRegister()
        {
            bool res =
                User != null &&
                User.Password == User.ConfirmPassword;

            ((RelayCommand)RegisterCommand).RaiseCanExecuteChanged();

            return res;
        }

        private void Register()
        {
            try
            {
                if (!CanRegister())
                {
                    MessageBox.Show("Паролі мають співпадати. Перевірте правильність введених даних, будь-ласка.");
                    return;
                }

                _userRepository.AddUser(User);

                MessageBox.Show("Користувача зареєстровано.");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
