// 代码生成时间: 2025-09-20 10:58:25
using System;
using System.Windows;
using System.Windows.Controls;

// 定义用户类
public class User
{
    public string Username { get; set; }
    public string Password { get; set; }
}

// 定义用户验证服务类
public class UserAuthService
{
    public bool ValidateUser(User user)
    {
        // 假设我们有一个硬编码的用户凭据，实际应用中应该从数据库或其他存储中检索
        User validUser = new User() { Username = "admin", Password = "password123" };

        // 检查用户名和密码是否匹配
        if (user.Username == validUser.Username && user.Password == validUser.Password)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}

// 主窗口类
public partial class MainWindow : Window
{
    private UserAuthService _authService;

    public MainWindow()
    {
        InitializeComponent();
        _authService = new UserAuthService();
    }

    private void LoginButton_Click(object sender, RoutedEventArgs e)
    {
        // 获取用户输入
        string username = UsernameTextBox.Text;
        string password = PasswordTextBox.Password;

        // 创建用户对象
        User user = new User() { Username = username, Password = password };

        // 验证用户凭据
        bool isValid = _authService.ValidateUser(user);

        if (isValid)
        {
            MessageBox.Show("Login successful!");
        }
        else
        {
            MessageBox.Show("Invalid username or password.");
        }
    }
}

// XAML 代码（MainWindow.xaml）
// <Window x:Class="UserLoginSystem.MainWindow"
//         xmlns="http://schemas.microsoft.com/winfx/2006/xaml/presentation"
//         xmlns:x="http://schemas.microsoft.com/winfx/2006/xaml"
//         Title="User Login System" Height="200" Width="300">
//     <Grid>
//         <Grid.RowDefinitions>
//             <RowDefinition Height="Auto"/>
//             <RowDefinition Height="Auto"/>
//             <RowDefinition Height="Auto"/>
//         </Grid.RowDefinitions>
//         <Label Content="Username:" Grid.Row="0"/>
//         <TextBox x:Name="UsernameTextBox" Grid.Row="1"/>
//         <Label Content="Password:" Grid.Row="2"/>
//         <PasswordBox x:Name="PasswordTextBox" Grid.Row="3"/>
//         <Button Content="Login" Grid.Row="4" Click="LoginButton_Click"/>
//     </Grid>
// </Window>