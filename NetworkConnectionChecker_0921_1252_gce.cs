// 代码生成时间: 2025-09-21 12:52:38
using System;
using System.Net;
using System.Net.NetworkInformation;
using System.Windows;

namespace NetworkCheckerApp
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

        private async void CheckNetworkConnection(object sender, RoutedEventArgs e)
        {
            try
            {
                // Check if there is a network connection
                bool isConnected = await IsNetworkConnectedAsync();

                // Display the result
                if (isConnected)
                {
                    MessageBox.Show("Connected to the network", "Network Status");
                }
                else
                {
                    MessageBox.Show("No network connection detected", "Network Status");
                }
            }
            catch (Exception ex)
            {
                // Handle any exceptions that occur during the check
                MessageBox.Show($"An error occurred: {ex.Message}", "Error");
            }
        }

        /// <summary>
        /// Asynchronously checks if the network connection is available.
        /// </summary>
        /// <returns>A boolean indicating whether the network is connected.</returns>
        private async Task<bool> IsNetworkConnectedAsync()
        {
            // Get the first active network interface
            NetworkInterface[] interfaces = NetworkInterface.GetAllNetworkInterfaces();
            foreach (NetworkInterface ni in interfaces)
            {
                if (ni.OperationalStatus == OperationalStatus.Up)
                {
                    // Attempt to ping a known address to check connectivity
                    try
                    {
                        Ping pingSender = new Ping();
                        PingReply reply = await pingSender.SendPingAsync(ni.Name);
                        return reply.Status == IPStatus.Success;
                    }
                    catch (PingException)
                    {
                        // Handle ping exceptions
                        continue;
                    }
                }
            }
            return false;
        }
    }
}