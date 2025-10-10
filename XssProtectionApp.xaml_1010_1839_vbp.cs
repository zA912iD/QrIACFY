// 代码生成时间: 2025-10-10 18:39:39
using System;
using System.Net;
using System.Text.RegularExpressions;
using System.Windows;

namespace XssProtectionApp
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

        private void CleanInput(string input)
        {
            try
            {
                // This regex pattern is a simple example of XSS protection
                // It removes all HTML tags and scripts.
                string cleanData = Regex.Replace(input, "<[^>]*>|script|on[a-zA-Z]+\s*=*|javascript:|vbscript:|expression\(|\b(alert|confirm|prompt)\b", string.Empty, RegexOptions.IgnoreCase | RegexOptions.Compiled);
                // Return the cleaned data
                return cleanData;
            }
            catch (Exception ex)
            {
                // Handle any exceptions that occur during cleaning
                MessageBox.Show("Error occurred while cleaning input: " + ex.Message);
                return string.Empty;
            }
        }

        private void CleanInputButton_Click(object sender, RoutedEventArgs e)
        {
            string userInput = UserInputTextBox.Text;
            string cleanUserInput = CleanInput(userInput);
            OutputTextBox.Text = cleanUserInput;
        }
    }
}
