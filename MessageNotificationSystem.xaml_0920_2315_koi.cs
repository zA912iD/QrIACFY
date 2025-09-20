// 代码生成时间: 2025-09-20 23:15:46
using System;
using System.Windows;

namespace MessageNotificationSystem
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

        private void ShowNotification(string message)
        {
            try
            {
                // Assuming there is a label or text box to display notifications
                lblNotification.Content = message;
            }
            catch (Exception ex)
            {
                // Log the exception or handle it appropriately
                MessageBox.Show($"Error showing notification: {ex.Message}");
            }
        }
    }
}
