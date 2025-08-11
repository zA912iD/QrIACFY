// 代码生成时间: 2025-08-11 17:43:21
using System;
using System.Net.Http;
using System.Threading.Tasks;
using System.Windows;

namespace WebContentGrabberApp
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

        private async void GrabContentButton_Click(object sender, RoutedEventArgs e)
        {
            var urlTextBox = this.FindName("UrlTextBox") as TextBox;
            var contentTextBox = this.FindName("ContentTextBox") as TextBox;
            if (urlTextBox != null && contentTextBox != null)
            {
                string url = urlTextBox.Text;
                try
                {
                    string content = await FetchWebContentAsync(url);
                    contentTextBox.Text = content;
                }
                catch (HttpRequestException httpEx)
                {
                    MessageBox.Show("HTTP request failed: " + httpEx.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("An error occurred: " + ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }

        /// <summary>
        /// Fetches the content from the specified URL asynchronously.
        /// </summary>
        /// <param name="url">The URL to fetch content from.</param>
        /// <returns>The content fetched from the URL.</returns>
        private async Task<string> FetchWebContentAsync(string url)
        {
            using (var httpClient = new HttpClient())
            {
                HttpResponseMessage response = await httpClient.GetAsync(url);
                response.EnsureSuccessStatusCode();
                return await response.Content.ReadAsStringAsync();
            }
        }
    }
}
