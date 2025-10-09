// 代码生成时间: 2025-10-10 02:13:23
using System;
using System.Text.Json;
using System.Windows;
using System.Windows.Controls;

// Main application class
public partial class MainWindow : Window
{
    private readonly JsonSerializerOptions jsonOptions = new JsonSerializerOptions
    {
        WriteIndented = true
    };

    public MainWindow()
    {
        InitializeComponent();
    }

    // Method to convert JSON data from a TextBox and display the result
    private void ConvertJsonData(object sender, RoutedEventArgs e)
    {
        TextBox inputTextBox = (TextBox)sender;
        try
        {
            string inputData = inputTextBox.Text;
            string convertedJsonData = JsonSerializer.Serialize(JsonSerializer.Deserialize(inputData, typeof(object)), jsonOptions);
            // Display the converted JSON data in another TextBox
            jsonOutputTextBox.Text = convertedJsonData;
        }
        catch (JsonException ex)
        {
            MessageBox.Show("Invalid JSON data.
" + ex.Message);
        }
    }
}

// XAML code for the WPF application
public partial class MainWindow : Window
{
    private void InitializeComponent()
    {
        this.jsonInputTextBox = new TextBox();
        this.jsonOutputTextBox = new TextBox();
        this.convertButton = new Button();

        this.jsonInputTextBox.Margin = new Thickness(5);
        this.jsonInputTextBox.VerticalScrollBarVisibility = ScrollBarVisibility.Auto;
        this.jsonInputTextBox.AcceptsReturn = true;
        this.jsonInputTextBox.Text = "";
        this.jsonInputTextBox.TextWrapping = TextWrapping.Wrap;

        this.jsonOutputTextBox.Margin = new Thickness(5);
        this.jsonOutputTextBox.VerticalScrollBarVisibility = ScrollBarVisibility.Auto;
        this.jsonOutputTextBox.AcceptsReturn = true;
        this.jsonOutputTextBox.Text = "";
        this.jsonOutputTextBox.TextWrapping = TextWrapping.Wrap;
        this.jsonOutputTextBox.IsEnabled = false;

        this.convertButton.Content = "Convert";
        this.convertButton.Click += new RoutedEventHandler(this.ConvertJsonData);

        StackPanel stackPanel = new StackPanel();
        stackPanel.Orientation = Orientation.Vertical;
        stackPanel.Margin = new Thickness(5);

        stackPanel.Children.Add(this.jsonInputTextBox);
        stackPanel.Children.Add(this.convertButton);
        stackPanel.Children.Add(this.jsonOutputTextBox);

        this.Content = stackPanel;
    }

    private TextBox jsonInputTextBox;
    private TextBox jsonOutputTextBox;
    private Button convertButton;
}