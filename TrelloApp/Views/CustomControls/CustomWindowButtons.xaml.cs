using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

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
