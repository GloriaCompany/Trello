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
            // Получаем доступ к ресурсам
            var resourceManager = TrelloApp.Views.ResourcesTrello.UserAvatars.ResourceManager;

            AvatarImages = new ObservableCollection<BitmapImage>();

            // Загружаем изображения аватарок
            for (int i = 1; i <= 21; i++)
            {
                // Формируем имя ресурса
                string resourceName = $"Avatar{i.ToString("D2")}"; // Форматируем номер аватара, чтобы получить его имя

                // Получаем изображение из ресурсов
                var bitmap = (System.Drawing.Bitmap)resourceManager.GetObject(resourceName);
                if (bitmap != null)
                {
                    // Преобразуем Bitmap в BitmapImage
                    using (var memoryStream = new MemoryStream())
                    {
                        bitmap.Save(memoryStream, System.Drawing.Imaging.ImageFormat.Png);
                        memoryStream.Position = 0;

                        var bitmapImage = new BitmapImage();
                        bitmapImage.BeginInit();
                        bitmapImage.CacheOption = BitmapCacheOption.OnLoad;
                        bitmapImage.StreamSource = memoryStream;
                        bitmapImage.EndInit();

                        // Добавляем BitmapImage в коллекцию
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
