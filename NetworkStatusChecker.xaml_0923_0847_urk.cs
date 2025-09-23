// 代码生成时间: 2025-09-23 08:47:02
using System;
using System.Net.NetworkInformation;
using System.Windows;

namespace NetworkStatusCheckerApp
{
    public partial class NetworkStatusChecker : Window
    {
        public NetworkStatusChecker()
        {
            InitializeComponent();
        }

        // 检查网络连接状态
        private void CheckNetworkStatus()
        {
            try
            {
                // 使用Ping类检查网络连接
                Ping ping = new Ping();
                PingReply reply = ping.Send("www.google.com");

                if (reply.Status == IPStatus.Success)
                {
                    MessageBox.Show("网络连接正常");
                }
                else
                {
                    MessageBox.Show("网络连接异常");
                }
            }
            catch (PingException ex)
            {
                // 捕获Ping异常，可能是网络问题或目标主机不可达
                MessageBox.Show($"Ping异常: {ex.Message}");
            }
            catch (Exception ex)
            {
                // 捕获其他异常，例如网络配置问题等
                MessageBox.Show($"发生异常: {ex.Message}");
            }
        }
    }
}