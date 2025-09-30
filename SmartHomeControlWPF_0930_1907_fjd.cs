// 代码生成时间: 2025-09-30 19:07:53
using System;
using System.Windows;
using System.Windows.Controls;

// Define a namespace for the Smart Home application
namespace SmartHomeApp
{
    // Define a ViewModel that will serve as the back-end logic for the Smart Home controls
    public class SmartHomeViewModel
    {
        public event Action<string> OnCommandExecuted;

        // Method to simulate turning on a light
        public void TurnOnLight(string lightName)
        {
            try
            {
                // Simulate the action of turning on the light
                OnCommandExecuted?.Invoke($"Light {lightName} turned on.");
            }
            catch (Exception ex)
            {
                // Error handling
                OnCommandExecuted?.Invoke($"Error turning on light {lightName}: {ex.Message}");
            }
        }

        // Method to simulate turning off a light
        public void TurnOffLight(string lightName)
        {
            try
            {
                // Simulate the action of turning off the light
                OnCommandExecuted?.Invoke($"Light {lightName} turned off.");
            }
            catch (Exception ex)
            {
                // Error handling
                OnCommandExecuted?.Invoke($"Error turning off light {lightName}: {ex.Message}");
            }
        }
    }

    // Define the MainWindow for the WPF application
    public partial class MainWindow : Window
    {
        private SmartHomeViewModel viewModel;

        public MainWindow()
        {
            InitializeComponent();

            // Initialize the ViewModel and assign it to the DataContext
            viewModel = new SmartHomeViewModel();
            this.DataContext = viewModel;
        }

        // Event handler for turning on a light
        private void TurnOnButton_Click(object sender, RoutedEventArgs e)
        {
            var lightName = ((Button)sender).Name;
            viewModel.TurnOnLight(lightName);
        }

        // Event handler for turning off a light
        private void TurnOffButton_Click(object sender, RoutedEventArgs e)
        {
            var lightName = ((Button)sender).Name;
            viewModel.TurnOffLight(lightName);
        }
    }
}
