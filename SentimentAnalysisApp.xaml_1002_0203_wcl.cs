// 代码生成时间: 2025-10-02 02:03:01
using System;
using System.Windows;
using Newtonsoft.Json.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Windows.Controls;

// MainWindow.xaml.cs is the code-behind for MainWindow.xaml
// It's the main entry point for our WPF application
public partial class MainWindow : Window
{
    private readonly HttpClient _httpClient;

    public MainWindow()
    {
        InitializeComponent();
        _httpClient = new HttpClient();
    }

    // This method is called when the user clicks the 'Analyze' button
    private async void AnalyzeSentimentButton_Click(object sender, RoutedEventArgs e)
    {
        string textToAnalyze = InputTextBox.Text;
        if (string.IsNullOrWhiteSpace(textToAnalyze))
        {
            MessageBox.Show("Please enter some text to analyze.");
            return;
        }

        try
        {
            string sentimentResult = await GetSentimentAsync(textToAnalyze);
            ResultTextBlock.Text = sentimentResult;
        }
        catch (Exception ex)
        {
            MessageBox.Show($"Error analyzing sentiment: {ex.Message}");
        }
    }

    // This method sends the text to a sentiment analysis endpoint and returns the result
    private async Task<string> GetSentimentAsync(string text)
    {
        // Replace with your actual API endpoint
        string url = "https://api.example.com/sentiment";
        var content = new StringContent($"{{"text": "{text}"}}", System.Text.Encoding.UTF8, "application/json");

        HttpResponseMessage response = await _httpClient.PostAsync(url, content);
        response.EnsureSuccessStatusCode();

        var jsonResponse = await response.Content.ReadAsStringAsync();
        JObject result = JObject.Parse(jsonResponse);

        // Extract sentiment from the response (structure may vary depending on the API)
        string sentiment = result["sentiment"].ToString();

        return $"The sentiment of the text is: {sentiment}";
    }
}
