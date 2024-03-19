﻿using System;
using System.Windows;
using System.Windows.Controls;

namespace TrelloApp.Views.CustomControls
{
    public partial class TaskControl : UserControl
    {
        public event EventHandler<EventArgs> ChangeColumnClicked;
        public event EventHandler<EventArgs> ChangePlaceClicked;

        public static readonly DependencyProperty AssignedUserAvatarProperty =
            DependencyProperty.Register("AssignedUserAvatar", typeof(string), typeof(TaskControl), new PropertyMetadata(null));

        public static readonly DependencyProperty TaskNameProperty =
            DependencyProperty.Register("TaskName", typeof(string), typeof(TaskControl), new PropertyMetadata("Task Name"));

        public string AssignedUserAvatar
        {
            get { return (string)GetValue(AssignedUserAvatarProperty); }
            set { SetValue(AssignedUserAvatarProperty, value); }
        }

        public string TaskName
        {
            get { return (string)GetValue(TaskNameProperty); }
            set { SetValue(TaskNameProperty, value); }
        }

        public TaskControl()
        {
            InitializeComponent();
        }

        private void ChangePlaceButton_Click(object sender, RoutedEventArgs e)
        {
            ChangePlaceClicked?.Invoke(this, EventArgs.Empty);
        }

        private void ChangeColumnButton_Click(object sender, RoutedEventArgs e)
        {
            ChangeColumnClicked?.Invoke(this, EventArgs.Empty);
        }
    }
}
