// 代码生成时间: 2025-10-01 02:49:21
// AtomicExchangeProtocolWPFApp.xaml.cs
// 这个WPF应用程序实现了一个简单的原子交换协议示例，用于演示如何在C#中实现线程安全的原子交换操作。

using System;
using System.Threading;
using System.Windows;
using System.Windows.Controls;

namespace AtomicExchangeProtocolWPFApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private volatile int _value; // 用于原子交换的共享变量
        private readonly object _lock = new object(); // 锁对象用于同步

        public MainWindow()
        {
            InitializeComponent();
        }

        private void SwapButton_Click(object sender, RoutedEventArgs e)
        {
            // 获取输入值
            int newValue = Convert.ToInt32(TextBoxNewValue.Text);
            int oldValue = 0;
            try
            {
                // 执行原子交换操作
                oldValue = AtomicExchange(ref newValue);
            }
            catch (Exception ex)
            {
                MessageBox.Show($@