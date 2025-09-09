// 代码生成时间: 2025-09-09 09:15:29
using System;
using System.IO;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Controls;

namespace LogParserApp
{
    // MainWindow.xaml 的代码后台
    public partial class MainWindow : Window
    {
        private const string LogEntryPattern = "^(\d{4}-\d{2}-\d{2} \d{2}:\d{2}:\d{2}) \[(INFO|WARNING|ERROR)\] (.*)"; // 日志条目的正则表达式

        public MainWindow()
        {
            InitializeComponent();
        }

        // 解析日志文件的按钮点击事件处理程序
        private void ParseLogButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var logFilePath = LogFilePathTextBox.Text;
                if (string.IsNullOrWhiteSpace(logFilePath) || !File.Exists(logFilePath))
                {
                    MessageBox.Show("Please provide a valid log file path.", "Error");
                    return;
                }

                var logEntries = ParseLogFile(logFilePath);
                DisplayParsedLogEntries(logEntries);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}", "Error");
            }
        }

        // 解析日志文件
        private string[] ParseLogFile(string filePath)
        {
            var logEntries = new List<string>();
            var logEntryRegex = new Regex(LogEntryPattern);
            using (var reader = new StreamReader(filePath))
            {
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    var match = logEntryRegex.Match(line);
                    if (match.Success)
                    {
                        logEntries.Add(match.Value);
                    }
                }
            }
            return logEntries.ToArray();
        }

        // 显示解析后的日志条目
        private void DisplayParsedLogEntries(string[] logEntries)
        {
            foreach (var entry in logEntries)
            {
                LogOutputTextBlock.Text += entry + Environment.NewLine;
            }
        }
    }
}