// 代码生成时间: 2025-08-29 21:54:17
using System;
using System.Windows;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace JsonDataConverterApp
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
        /// Handles the Convert button click event.
        /// Converts JSON data from a string format to an object and vice versa.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="RoutedEventArgs"/> instance containing the event data.</param>
        private void ConvertButton_Click(object sender, RoutedEventArgs e)
        {
            // Get the input JSON string from the input TextBox
            var inputJson = InputJsonTextBox.Text;

            try
            {
                // Deserialize the JSON string to a dynamic object
                var jsonObject = JsonConvert.DeserializeObject(inputJson);

                // Convert the dynamic object back to JSON string
                var outputJson = JsonConvert.SerializeObject(jsonObject, Formatting.Indented);

                // Update the output TextBox with the converted JSON string
                OutputJsonTextBox.Text = outputJson;
            }
            catch (JsonException ex)
            {
                // Handle JSON parsing errors
                MessageBox.Show($"Error parsing JSON: {ex.Message}", "JSON Conversion Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            catch (Exception ex)
            {
                // Handle any other unexpected errors
                MessageBox.Show($"An unexpected error occurred: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}