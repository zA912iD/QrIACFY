// 代码生成时间: 2025-09-03 19:09:50
using System;
using System.Net.Http;
using System.Threading.Tasks;
using System.Windows;

namespace HttpHandlerWpfApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly HttpClient _httpClient;

        public MainWindow()
        {
            InitializeComponent();
            _httpClient = new HttpClient();
        }

        /// <summary>
        /// Handles the Click event of the SendRequest button.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="RoutedEventArgs"/> instance containing the event data.</param>
        private async void SendRequestButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string url = UriTextBox.Text;
                HttpResponseMessage response = await _httpClient.GetAsync(url);
                if (response.IsSuccessStatusCode)
                {
                    string result = await response.Content.ReadAsStringAsync();
                    ResultTextBox.Text = result;
                }
                else
                {
                    ResultTextBox.Text = "Error: " + response.StatusCode;
                }
            }
            catch (Exception ex)
            {
                ResultTextBox.Text = "Error: " + ex.Message;
            }
        }
    }
}