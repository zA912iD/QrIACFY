// 代码生成时间: 2025-09-02 05:20:33
using System;
using System.Windows;
using System.Security.Cryptography;
using System.IO;
using System.Text;

namespace HashCalculatorWpfApp
{
    public partial class HashCalculatorWpfApp : Window
    {
        public HashCalculatorWpfApp()
        {
            InitializeComponent();
        }

        // Event handler for the Calculate button click
        private void CalculateButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                // Get the input text from the TextBox
                string inputText = InputTextBox.Text;
                
                // Check if the input is empty
                if (string.IsNullOrEmpty(inputText))
                {
                    MessageBox.Show("Please enter some text to calculate its hash.");
                    return;
                }
                
                // Calculate the hash for the given input using SHA256
                string hash = CalculateHash(inputText);
                
                // Display the hash result in the result TextBox
                ResultTextBox.Text = hash;
            }
            catch (Exception ex)
            {
                // Display an error message in case of any exceptions
                MessageBox.Show($"An error occurred: {ex.Message}");
            }
        }

        // Method to calculate the hash of a given input using SHA256
        private string CalculateHash(string input)
        {
            using (SHA256 sha256 = SHA256.Create())
            {
                // Convert the input string to a byte array and compute the hash
                byte[] bytes = Encoding.UTF8.GetBytes(input);
                byte[] hashBytes = sha256.ComputeHash(bytes);
                
                // Convert the byte array to a hexadecimal string
                StringBuilder sb = new StringBuilder();
                foreach (byte b in hashBytes)
                {
                    sb.Append(b.ToString("x2"));
                }
                return sb.ToString();
            }
        }
    }
}