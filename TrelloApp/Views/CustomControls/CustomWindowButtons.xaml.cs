using System.Windows;
using System.Windows.Controls;

namespace TrelloApp.Views.CustomControls
{
    /// <summary>
    /// Логика взаимодействия для CustomWindowButtons.xaml
    /// </summary>
    public partial class CustomWindowButtons : UserControl
    {
        public CustomWindowButtons()
        {
            InitializeComponent();
        }

        private void MinimizeButtonClick(object sender, RoutedEventArgs e)
        {
            if (Window.GetWindow(this) is Window window)
            {
                window.WindowState = WindowState.Minimized;
            }
        }

        private void MaximizeButtonClick(object sender, RoutedEventArgs e)
        {
            if (Window.GetWindow(this) is Window window)
            {
                if (window.WindowState == WindowState.Normal)
                {
                    window.WindowState = WindowState.Maximized;
                }
                else
                {
                    window.WindowState = WindowState.Normal;
                }
            }
        }

        private void CloseButtonClick(object sender, RoutedEventArgs e)
        {
            if (Window.GetWindow(this) is Window window)
            {
                window.Close();
            }
        }
    }
}
