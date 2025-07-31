// 代码生成时间: 2025-07-31 23:49:32
using System;
using System.Windows;

// 定义用户登录验证的ViewModel
public class LoginViewModel
{
    private string username;
    private string password;

    // 用户名属性
    public string Username
    {
        get { return username; }
        set { username = value; }
    }

    // 密码属性
    public string Password
    {
        get { return password; }
        set { password = value; }
    }

    // 登录验证方法
    public bool Login(string username, string password)
    {
        // 这里使用简单的硬编码用户名和密码作为示例，实际应用中应从数据库或其他安全方式获取
        const string validUsername = "admin";
        const string validPassword = "password123";

        if (username == validUsername && password == validPassword)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}

// 定义WPF窗口的代码后台
public partial class MainWindow : Window
{
    private readonly LoginViewModel loginViewModel;

    public MainWindow()
    {
        InitializeComponent();
        loginViewModel = new LoginViewModel();
    }

    private void LoginButton_Click(object sender, RoutedEventArgs e)
    {
        try
        {
            string username = UsernameTextBox.Text;
            string password = PasswordPasswordBox.Password;

            bool isValid = loginViewModel.Login(username, password);

            if (isValid)
            {
                MessageBox.Show("Login successful!", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else
            {
                MessageBox.Show("Invalid username or password!", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
        catch (Exception ex)
        {
            MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
        }
    }
}
