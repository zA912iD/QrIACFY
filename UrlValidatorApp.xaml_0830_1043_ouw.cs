// 代码生成时间: 2025-08-30 10:43:08
using System;
using System.Windows;
using System.Windows.Controls;
using System.Net.Http;

namespace UrlValidatorApp
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

        private async void ValidateUrlButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                // 获取URL文本框内容
                string url = UrlTextBox.Text;

                // 检查URL是否为空
                if (string.IsNullOrWhiteSpace(url))
                {
                    MessageBox.Show("Please enter a URL.", "Validation Error", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }

                // 验证URL格式
                if (!Uri.IsWellFormedUriString(url, UriKind.Absolute))
                {
                    MessageBox.Show("Invalid URL format.", "Validation Error", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }

                // 使用HttpClient发送HEAD请求以验证URL有效性
                HttpResponseMessage response = await _httpClient.SendAsync(new HttpRequestMessage(HttpMethod.Head, url));

                // 检查响应状态码
                if (response.IsSuccessStatusCode)
                {
                    MessageBox.Show($"The URL: {url} is valid.", "Validation Result", MessageBoxButton.OK, MessageBoxImage.Information);
                }
                else
                {
                    MessageBox.Show($"The URL: {url} is not valid.", "Validation Result", MessageBoxButton.OK, MessageBoxImage.Warning);
                }
            }
            catch (HttpRequestException ex)
            {
                // 处理网络异常
                MessageBox.Show($"An error occurred while validating the URL: {ex.Message}", "Network Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            catch (Exception ex)
            {
                // 处理其他异常
                MessageBox.Show($"An unexpected error occurred: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}