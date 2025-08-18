// 代码生成时间: 2025-08-18 08:53:49
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows;

namespace LogFileParserApp
{
    // MainWindow.xaml 的代码后台文件
    public partial class MainWindow : Window
    {
        private const string LogFilePattern = @"\[(?<date>[^\]]+)\]\s+(?<level>[^\]]+)\s+(?<message>.*)";

        public MainWindow()
        {
            InitializeComponent();
        }

        private void BrowseButton_Click(object sender, RoutedEventArgs e)
        {
            // 使用文件对话框选择日志文件
            var dialog = new Microsoft.Win32.OpenFileDialog
            {
                Filter = "Log Files (*.log)|*.log"
            };

            if (dialog.ShowDialog() == true)
            {
                // 设置文本框路径
                FilePathTextBox.Text = dialog.FileName;
            }
        }

        private void ParseButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(FilePathTextBox.Text))
                {
                    throw new InvalidOperationException("Please select a log file.");
                }

                var logLines = File.ReadAllLines(FilePathTextBox.Text);
                var parsedLogs = ParseLogFile(logLines);

                // 将解析后的日志显示在界面上
                LogsListBox.ItemsSource = parsedLogs;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error parsing log file: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private IEnumerable<LogEntry> ParseLogFile(string[] lines)
        {
            var regex = new Regex(LogFilePattern);
            foreach (var line in lines)
            {
                var match = regex.Match(line);
                if (match.Success)
                {
                    yield return new LogEntry
                    {
                        Date = DateTime.Parse(match.Groups["date"].Value),
                        Level = match.Groups["level"].Value,
                        Message = match.Groups["message"].Value
                    };
                }
            }
        }

        private void ClearButton_Click(object sender, RoutedEventArgs e)
        {
            LogsListBox.ItemsSource = null;
            FilePathTextBox.Clear();
        }
    }

    // Log entry class to hold parsed log data
    public class LogEntry
    {
        public DateTime Date { get; set; }
        public string Level { get; set; }
        public string Message { get; set; }
    }
}
