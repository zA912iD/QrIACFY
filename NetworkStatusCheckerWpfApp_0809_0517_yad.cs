// 代码生成时间: 2025-08-09 05:17:41
using System;
using System.Net.NetworkInformation;
using System.Windows;

namespace NetworkCheckerApp
{
    // MainWindow class of our WPF application
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            this.Loaded += MainWindow_Loaded;
        }

        private void MainWindow_Loaded(object sender, RoutedEventArgs e)
        {
            // Perform network status check when the window is loaded
            CheckNetworkStatus();
        }

        // Method to check network status
        private async void CheckNetworkStatus()
        {
            try
            {
                // Use Ping to check network connectivity
                Ping pingSender = new Ping();
                PingReply reply = await pingSender.SendPingAsync("www.google.com");

                if (reply.Status == IPStatus.Success)
                {
                    MessageBox.Show("Network connection is active. Ping to Google was successful.", "Network Status");
                }
                else
                {
                    MessageBox.Show("Network connection is down or blocked. Ping to Google failed.", "Network Status");
                }
            }
            catch (PingException ex)
            {
                // Handle possible exceptions that can occur while pinging
                MessageBox.Show($"An error occurred while checking the network status: {ex.Message}", "Error");
            }
            catch (Exception ex)
            {
                // Handle any other unexpected exceptions
                MessageBox.Show($"An unexpected error occurred: {ex.Message}", "Error");
            }
        }
    }
}
