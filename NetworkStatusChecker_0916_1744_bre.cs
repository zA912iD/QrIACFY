// 代码生成时间: 2025-09-16 17:44:05
using System;
using System.Net.NetworkInformation;
using System.Windows;

namespace NetworkStatusCheckerApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            NetworkChange.NetworkAddressChanged += NetworkAddressChanged; // 注册网络状态变化事件
        }

        private void NetworkAddressChanged(object sender, EventArgs e)
        {
            Ping pingSender = new Ping();
            try
            {
                PingReply reply = pingSender.Send("www.google.com"); // 发送ping请求检查网络连接
                if (reply.Status == IPStatus.Success)
                {
                    MessageBox.Show("Network is connected."); // 显示网络已连接的消息
                }
                else
                {
                    MessageBox.Show("Network is not connected."); // 显示网络未连接的消息
                }
            }
            catch (PingException ex)
            {
                MessageBox.Show($"Ping failed with error: {ex.Message}"); // 处理Ping异常
            }
        }
    }
}
