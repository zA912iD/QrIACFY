// 代码生成时间: 2025-08-24 05:02:30
using System;
using System.Windows;
using System.Windows.Controls;

namespace WpfNotificationSystem
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Button click event handler to trigger a message notification.
        /// </summary>
        /// <param name="sender">The sender of the event.</param>
        /// <param name="e">The event arguments.</param>
        private void NotifyButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string message = "Hello, this is a notification message!";
                MessageBox.Show(message, "Notification", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            catch (Exception ex)
            {
                // Error handling for any unexpected issues during notification.
                MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}