// 代码生成时间: 2025-08-22 21:04:15
using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Threading.Tasks;
using System.Windows;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace ApiResponseFormatterTool
{
    /// <summary>
    /// Interaction logic for ApiResponseFormatterTool.xaml
    /// </summary>
    public partial class ApiResponseFormatterTool : Window
    {
        private HttpClient httpClient = new HttpClient();

        public ApiResponseFormatterTool()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Handles the button click event to fetch and format API response.
        /// </summary>
        private async void FormatApiResponseButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var apiUrl = ApiUrlTextBox.Text;
                if (string.IsNullOrWhiteSpace(apiUrl))
                {
                    MessageBox.Show("Please enter a valid API URL.", "Input Error", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }

                var response = await httpClient.GetAsync(apiUrl);
                response.EnsureSuccessStatusCode();
                var content = await response.Content.ReadAsStringAsync();

                var formattedJson = FormatJson(content);
                FormattedJsonTextBox.Text = formattedJson;
            }
            catch (HttpRequestException httpRequestException)
            {
                MessageBox.Show($"Error fetching data: {httpRequestException.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An unexpected error occurred: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        /// <summary>
        /// Formats the JSON string to a nicely formatted JSON.
        /// </summary>
        /// <param name="json">The JSON string to be formatted.</param>
        /// <returns>The formatted JSON string.</returns>
        private string FormatJson(string json)
        {
            try
            {
                var parsedJson = JToken.Parse(json);
                return parsedJson.ToString(Formatting.Indented);
            }
            catch (JsonReaderException jsonReaderException)
            {
                MessageBox.Show($"Error parsing JSON: {jsonReaderException.Message}", "JSON Parsing Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return json;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An unexpected error occurred: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return json;
            }
        }
    }
}