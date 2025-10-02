// 代码生成时间: 2025-10-02 19:13:25
using System;
using System.Windows;
using System.Windows.Controls;
using System.Net;
using System.Text;
using System.Security.Cryptography;

namespace CsrfProtectionApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        // Generate a random token
        private string GenerateToken()
        {
            using (var rng = new RNGCryptoServiceProvider())
            {
                var tokenBytes = new byte[16];
                rng.GetBytes(tokenBytes);
                return Convert.ToBase64String(tokenBytes);
            }
        }

        // Verify the token
        private bool VerifyToken(string token)
        {
            // Here you would check the token against the one stored in your session or cookie
            // For demonstration, we'll just regenerate the token and compare
            string storedToken = GenerateToken();
            return token == storedToken;
        }

        public MainWindow()
        {
            InitializeComponent();
        }

        private void SubmitButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string token = txtToken.Text;
                if (!VerifyToken(token))
                {
                    MessageBox.Show("Invalid CSRF token. Please try again.");
                    return;
                }

                // Your form submission logic here
                MessageBox.Show("Form submitted successfully!");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}");
            }
        }
    }
}
