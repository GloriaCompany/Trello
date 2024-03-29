﻿using System.Windows;
using System.Windows.Controls;

namespace TrelloApp.Views.CustomControls
{
    public partial class CustomPasswordInput : UserControl
    {
        public static readonly DependencyProperty PlaceholderProperty =
            DependencyProperty.Register("Placeholder", typeof(string), typeof(CustomPasswordInput), new FrameworkPropertyMetadata(string.Empty));

        public static readonly DependencyProperty PasswordProperty =
            DependencyProperty.Register("Password", typeof(string), typeof(CustomPasswordInput), new FrameworkPropertyMetadata(string.Empty));

        private TextBlock PlaceholderTextBlock;
        private UIElement currentInputElement;

        public string Placeholder
        {
            get { return (string)GetValue(PlaceholderProperty); }
            set { SetValue(PlaceholderProperty, value); }
        }

        public string Password
        {
            get { return (string)GetValue(PasswordProperty); }
            set { SetValue(PasswordProperty, value); }
        }

        public CustomPasswordInput()
        {
            InitializeComponent();
            DataContext = this;

            PasswordBox.Visibility = Visibility.Visible;
            TextBox.Visibility = Visibility.Collapsed;

            Loaded += (sender, e) =>
            {
                PlaceholderTextBlock = (TextBlock)PasswordBox.Template.FindName("PlaceholderTextBlock", PasswordBox);
                UpdatePlaceholderVisibility();
            };

            PasswordBox.PasswordChanged += PasswordBox_TextChanged;
            PasswordBox.LostFocus += PasswordBox_LostFocus;
        }

        private void UpdatePlaceholderVisibility()
        {
            PlaceholderTextBlock.Visibility = (currentInputElement == PasswordBox && string.IsNullOrEmpty(PasswordBox.Password)) ||
                                               (currentInputElement == TextBox && string.IsNullOrEmpty(TextBox.Text))
                                               ? Visibility.Visible : Visibility.Collapsed;
        }

        private void ToggleButton_Click(object sender, RoutedEventArgs e)
        {
            if (PasswordBox.Visibility == Visibility.Visible)
            {
                PasswordBox.Visibility = Visibility.Collapsed;
                TextBox.Visibility = Visibility.Visible;
                TextBox.Text = PasswordBox.Password;
                PasswordBox.Password = "";
                TextBox.Focus();
                currentInputElement = TextBox;
                PlaceholderTextBlock.Visibility = Visibility.Visible;
            }
            else
            {
                PasswordBox.Visibility = Visibility.Visible;
                TextBox.Visibility = Visibility.Collapsed;
                PasswordBox.Password = TextBox.Text;
                TextBox.Text = "";
                PasswordBox.Focus();
                currentInputElement = PasswordBox;
            }
        }

        private void PasswordBox_GotFocus(object sender, RoutedEventArgs e)
        {
            currentInputElement = PasswordBox;
            UpdatePlaceholderVisibility();
        }

        private void TextBox_GotFocus(object sender, RoutedEventArgs e)
        {
            currentInputElement = TextBox;
            UpdatePlaceholderVisibility();
        }

        private void PasswordBox_LostFocus(object sender, RoutedEventArgs e)
        {
            UpdatePlaceholderVisibility();
        }

        private void PasswordBox_TextChanged(object sender, RoutedEventArgs e)
        {
            if (PasswordBox.Visibility == Visibility.Visible)
            {
                UpdatePlaceholderVisibility();
            }
        }

        private void PasswordBox_PasswordChanged(object sender, RoutedEventArgs e)
        {
            //StackOverflowException при биндинге на пароль пользователя
            //Password = PasswordBox.Password;
        }
    }
}