// 代码生成时间: 2025-08-19 20:39:24
using System;
using System.Net.NetworkInformation;
using System.Windows;

namespace NetworkCheckerApp
{
    // MainWindow.xaml.cs
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        // 检查网络连接状态的方法
        private async void CheckNetworkConnection_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                // 使用Ping来检查网络连接
                Ping ping = new Ping();
                PingReply reply = await ping.SendPingAsync("www.google.com");

                // 根据Ping结果更新UI
                if (reply.Status == IPStatus.Success)
                {
                    MessageBox.Show("网络连接正常");
                }
                else
                {
                    MessageBox.Show("网络连接失败");
                }
            }
            catch (PingException ex)
            {
                // 捕获Ping异常
                MessageBox.Show($"Ping请求失败: {ex.Message}");
            }
            catch (Exception ex)
            {
                // 捕获其他异常
                MessageBox.Show($"发生错误: {ex.Message}");
            }
        }
    }
}
