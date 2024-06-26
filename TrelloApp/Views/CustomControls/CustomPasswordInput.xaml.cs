﻿using System;
using System.Windows;
using System.Windows.Controls;

namespace TrelloApp.Views.CustomControls
{
    public partial class CustomPasswordInput : UserControl
    {
        public static readonly DependencyProperty PlaceholderProperty =
            DependencyProperty.Register("Placeholder", typeof(string), typeof(CustomPasswordInput), new FrameworkPropertyMetadata(string.Empty));

        public static readonly DependencyProperty PasswordProperty =
            DependencyProperty.Register("Password", typeof(string), typeof(CustomPasswordInput), new FrameworkPropertyMetadata(string.Empty, PasswordPropertyChanged));

        private TextBlock PlaceholderTextBlock;
        private UIElement currentInputElement;
        private bool isUpdatingPassword = false;

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

            Loaded += CustomPasswordInput_Loaded;

            PasswordBox.PasswordChanged += PasswordBox_PasswordChanged;
            PasswordBox.LostFocus += PasswordBox_LostFocus;
        }

        private void CustomPasswordInput_Loaded(object sender, RoutedEventArgs e)
        {
            PlaceholderTextBlock = (TextBlock)PasswordBox.Template.FindName("PlaceholderTextBlock", PasswordBox);
            UpdatePlaceholderVisibility();
        }

        private static void PasswordPropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var control = d as CustomPasswordInput;
            if (control != null)
            {
                control.UpdatePassword(e.NewValue as string);
            }
        }

        private void UpdatePlaceholderVisibility()
        {
            if (PlaceholderTextBlock != null)
            {
                PlaceholderTextBlock.Visibility = (currentInputElement == PasswordBox && string.IsNullOrEmpty(PasswordBox.Password)) ||
                                                   (currentInputElement == TextBox && string.IsNullOrEmpty(TextBox.Text))
                                                   ? Visibility.Visible : Visibility.Collapsed;
            }
        }

        private void ToggleButton_Click(object sender, RoutedEventArgs e)
        {
            if (PasswordBox.Visibility == Visibility.Visible)
            {
                Password = PasswordBox.Password;
                PasswordBox.Visibility = Visibility.Collapsed;
                TextBox.Visibility = Visibility.Visible;
                TextBox.Text = Password;
                TextBox.Focus();
                currentInputElement = TextBox;

                if (PlaceholderTextBlock != null)
                {
                    PlaceholderTextBlock.Visibility = Visibility.Visible;
                }
            }
            else
            {
                PasswordBox.Visibility = Visibility.Visible;
                TextBox.Visibility = Visibility.Collapsed;
                PasswordBox.Password = Password;
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

        private void PasswordBox_PasswordChanged(object sender, RoutedEventArgs e)
        {
            if (!isUpdatingPassword)
            {
                if (PasswordBox.Visibility == Visibility.Visible)
                {
                    Password = PasswordBox.Password;
                    UpdatePlaceholderVisibility();
                }
                else
                {
                    int cursorPosition = TextBox.SelectionStart;
                    TextBox.Text = PasswordBox.Password;
                    cursorPosition = Math.Min(cursorPosition, TextBox.Text.Length);
                    TextBox.SelectionStart = cursorPosition;
                }
            }
        }

        private void UpdatePassword(string newPassword)
        {
            isUpdatingPassword = true;
            PasswordBox.Password = newPassword;
            isUpdatingPassword = false;
        }
    }
}