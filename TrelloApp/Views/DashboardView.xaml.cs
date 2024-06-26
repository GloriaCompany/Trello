﻿using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using TrelloApp.Helpers;
using TrelloApp.ViewModels;
using TrelloApp.ViewModels.Repository;
using TrelloApp.Views.Utils;
using TrelloDBLayer;

namespace TrelloApp.Views
{
    public partial class DashboardView : Page
    {
        public DashboardView()
        {
            InitializeComponent();

            DashboardViewModel vm = new DashboardViewModel(
                            FindResource("Navigation") as INavigator,
                            FindResource("UserRepository") as IUserRepository,
                            FindResource("BoardRepository") as IBoardRepository
                        );
            DataContext = vm;
        }

        private void AddBoardBtn_Click(object sender, RoutedEventArgs e)
        {
            addBoardPopup.IsOpen = true;
        }

        private void AddConfirmedBoardButton_Click(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(BoardNameInput.Text))
            {
                addBoardPopup.IsOpen = false;
            }
            else
            {
                MessageBox.Show("Please enter a board name.");
            }
        }

        private bool IsMouseOverPopup(MouseButtonEventArgs e)
        {
            if (addBoardPopup.IsOpen)
            {
                Point point = e.GetPosition(null);
                return addBoardPopup
                    .PlacementTarget?
                    .TransformToVisual(this)
                    .TransformBounds(addBoardPopup.PlacementRectangle)
                    .Contains(point)
                    ?? false;
            }
            return false;
        }

        private void ThemesComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ComboBoxUtils.HandleSelectionChanged(sender, e, "/Views/ResourcesTrello/Themes/", null);
        }

        private void LanguagesComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ComboBoxUtils.HandleSelectionChanged(sender, e, null, "/Views/ResourcesTrello/Languages/");
        }

        private void CircleImage_MouseDown(object sender, MouseButtonEventArgs e)
        {
            NavigationService.Navigate(new ProfileView());
        }

        private void addBoardPopup_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (IsMouseOverPopup(e))
            {
                addBoardPopup.ReleaseMouseCapture();
            }
        }

        private void TextBlock_MouseDown(object sender, MouseButtonEventArgs e)
        {
            NavigationService.Navigate(new BoardView());
        }

        private void Border_MouseDown(object sender, MouseButtonEventArgs e)
        {
            (FindResource("BoardRepository") as IBoardRepository).CurrentBoard = ((FrameworkElement)sender).DataContext as Board;
            NavigationService.Navigate(new BoardView());
        }
    }
}
