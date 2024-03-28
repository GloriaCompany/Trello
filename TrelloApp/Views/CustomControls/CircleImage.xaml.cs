using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;

namespace TrelloApp.Views.CustomControls
{
    /// <summary>
    /// Логика взаимодействия для CircleImage.xaml
    /// </summary>
    public partial class CircleImage : UserControl
    {
        public CircleImage()
        {
            InitializeComponent();
        }

        public static readonly DependencyProperty ButtonsProperty =
            DependencyProperty.Register("Buttons", typeof(ObservableCollection<string>), typeof(CircleImage), new PropertyMetadata(new ObservableCollection<string>()));
        public static readonly DependencyProperty ImageSourceProperty =
            DependencyProperty.Register("ImageSource", typeof(ImageSource), typeof(CircleImage), new PropertyMetadata(null, ImageSourceChanged));
        public static readonly DependencyProperty IsPopupEnabledProperty =
            DependencyProperty.Register("IsPopupEnabled", typeof(bool), typeof(CircleImage), new PropertyMetadata(true));

        public ImageSource ImageSource
        {
            get { return (ImageSource)GetValue(ImageSourceProperty); }
            set { SetValue(ImageSourceProperty, value); }
        }

        public ObservableCollection<string> Buttons
        {
            get { return (ObservableCollection<string>)GetValue(ButtonsProperty); }
            set { SetValue(ButtonsProperty, value); }
        }

        public bool IsPopupEnabled
        {
            get { return (bool)GetValue(IsPopupEnabledProperty); }
            set { SetValue(IsPopupEnabledProperty, value); }
        }

        private static void ImageSourceChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var control = d as CircleImage;
            control?.UpdateImageSource(e.NewValue as ImageSource);
        }

        private void UpdateImageSource(ImageSource source)
        {
            imageBrush.ImageSource = source;
        }

        private void Ellipse_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (IsPopupEnabled)
            {
                popup.IsOpen = !popup.IsOpen;
            }
        }
    }
}
