// 代码生成时间: 2025-08-14 19:28:40
using System;
using System.Windows;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace WpfJsonDataFormatter
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

        private void FormatJson_Click(object sender, RoutedEventArgs e)
        {
            string inputJson = JsonInputTextBox.Text;
            try
            {
                string formattedJson = FormatJson(inputJson);
                FormattedJsonTextBox.Text = formattedJson;
            }
            catch (JsonReaderException ex)
            {
                MessageBox.Show($"Invalid JSON: {ex.Message}");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}");
            }
        }

        /// <summary>
        /// Formats the JSON string to a readable format.
        /// </summary>
        /// <param name="inputJson">The input JSON string.</param>
        /// <returns>The formatted JSON string.</returns>
        private string FormatJson(string inputJson)
        {
            if (string.IsNullOrWhiteSpace(inputJson))
            {
                throw new ArgumentException("Input JSON cannot be null or empty.");
            }

            try
            {
                JObject parsedJson = JObject.Parse(inputJson);
                return parsedJson.ToString(Formatting.Indented);
            }
            catch (JsonReaderException)
            {
                throw;
            }
        }
    }
}