// 代码生成时间: 2025-08-30 05:41:38
using System;
using System.IO;
using System.Text.RegularExpressions;
using System.Windows;

namespace LogFileParserApp
{
    // MainWindow.xaml.cs是WPF应用程序的主窗口类的代码文件
    public partial class MainWindow : Window
    {
        // MainWindow的构造函数
        public MainWindow()
        {
            InitializeComponent();
        }

        // 打开日志文件并解析内容的方法
        private void ParseLogFile(object sender, RoutedEventArgs e)
        {
            try
            {
                // 使用OpenFileDialog选择文件
                Microsoft.Win32.OpenFileDialog openFileDialog = new Microsoft.Win32.OpenFileDialog();
                openFileDialog.Filter = "Log Files|*.log";
                bool? result = openFileDialog.ShowDialog();
                
                if (result.HasValue && result.Value)
                {
                    string logFilePath = openFileDialog.FileName;
                    string logFileContent = File.ReadAllText(logFilePath);
                    Regex regex = new Regex("\/Date\((\d+)(\+|-)(\d{2}):(\d{2})\)\/");

                    // 使用正则表达式解析时间戳
                    var matches = regex.Matches(logFileContent);
                    foreach (Match match in matches)
                    {
                        long timestamp = long.Parse(match.Groups[1].Value);
                        string timeZone = match.Groups[2].Value + match.Groups[3].Value;
                        string timeOffset = match.Groups[4].Value;
                        
                        // 这里可以添加更多的解析逻辑
                        Console.WriteLine($"Timestamp: {timestamp}, TimeZone: {timeZone}, TimeOffset: {timeOffset}, LogEntry: {match.Value}");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error parsing log file: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}