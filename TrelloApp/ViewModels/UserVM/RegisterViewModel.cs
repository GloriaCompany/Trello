using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media.Imaging;
using System.Windows.Threading;
using TrelloApp.Models;
using TrelloApp.ViewModels.Base;

namespace TrelloApp.ViewModels.UserVM
{
    public class RegisterViewModel : ViewModelBase
    {
        private DispatcherTimer _timer;
        private HashSet<string> _loadedImagePaths = new HashSet<string>();

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
            _timer = new DispatcherTimer()
            {
                Interval = TimeSpan.FromSeconds(5)
            };
            _timer.Interval = TimeSpan.FromSeconds(5);
            _timer.Tick += Timer_Tick;
            _timer.Start();
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            // Перевіряємо наявність нових файлів у папці UserAvatars та додаємо їх до колекції AvatarImages
            UpdateAvatars();
        }

        private void UpdateAvatars()
        {
            try
            {
                // Отримуємо шлях до папки UserAvatars
                string projectDIrectory = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.FullName;
                string avatarsFolderPath = Path.Combine(projectDIrectory, "UserAvatars");

                // Отримуємо список файлів у папці UserAvatars
                var files = Directory.GetFiles(avatarsFolderPath, "*.png"); // Можна використовувати інші розширення файлів

                // Завантажуємо лише нові зображення та додаємо їх до колекції AvatarImages
                foreach (var file in files)
                {
                    if (!_loadedImagePaths.Contains(file))
                    {
                        var bitmapImage = new BitmapImage(new Uri(file));
                        AvatarImages.Add(bitmapImage);
                        _loadedImagePaths.Add(file);
                    }
                }
            }
            catch (Exception ex)
            {
                // Обробка помилки під час завантаження зображень
                MessageBox.Show($"Помилка завантаження зображень: {ex.Message}", "Помилка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
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
