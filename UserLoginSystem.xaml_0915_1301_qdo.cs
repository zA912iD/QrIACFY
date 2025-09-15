// 代码生成时间: 2025-09-15 13:01:12
using System;
using System.Windows;

namespace UserLoginSystem
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly IAuthenticationService _authenticationService;

        public MainWindow()
        {
            InitializeComponent();
            _authenticationService = new AuthenticationService();
        }

        private void LoginButton_Click(object sender, RoutedEventArgs e)
        {
            string username = UsernameTextBox.Text;
            string password = PasswordPasswordBox.Password;

            try
            {
                if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
                {
                    MessageBox.Show("Username or password cannot be empty.", "Input Error", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }

                bool isAuthenticated = _authenticationService.Authenticate(username, password);

                if (isAuthenticated)
                {
                    MessageBox.Show("Login successful!", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
                    // Navigate to the main application view
                }
                else
                {
                    MessageBox.Show("Invalid username or password.", "Login Failed", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }

    public interface IAuthenticationService
    {
        bool Authenticate(string username, string password);
    }

    public class AuthenticationService : IAuthenticationService
    {
        public bool Authenticate(string username, string password)
        {
            // This is a placeholder for actual authentication logic
            // For demonstration purposes, it simply checks if the username and password are 'admin'
            return username == "admin" && password == "password123";
        }
    }
}
