// 代码生成时间: 2025-09-01 10:00:46
// LogFileParserWpfApp.xaml.cs
// 文件解析工具的逻辑部分
using System;
using System.IO;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace LogFileParserApp
{
    public partial class LogFileParserWpfApp : UserControl
    {
        public LogFileParserWpfApp()
        {
            InitializeComponent();
        }

        // 当用户选择文件并点击解析按钮时触发此方法
        private void ParseLogFileButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                // 获取选择的文件路径
                string selectedFile = LogFilePathTextbox.Text;

                // 验证文件路径是否有效
                if (string.IsNullOrEmpty(selectedFile) || !File.Exists(selectedFile))
                {
                    MessageBox.Show("Please select a valid log file.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }

                // 解析日志文件
                ParseLogFile(selectedFile);
            }
            catch (Exception ex)
            {
                // 捕获并显示任何异常
                MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        // 解析日志文件的方法
        private void ParseLogFile(string filePath)
        {
            // 使用正则表达式匹配日志条目（示例模式）
            string pattern = @"^(\d{4}-\d{2}-\d{2} \d{2}:\d{2}:\d{2}) - (INFO|ERROR|WARNING) - (.*)$";
            Regex regex = new Regex(pattern);

            // 读取文件内容
            string[] lines = File.ReadAllLines(filePath);

            // 遍历每一行并用正则表达式匹配
            foreach (string line in lines)
            {
                Match match = regex.Match(line);
                if (match.Success)
                {
                    // 将匹配结果添加到结果列表中
                    LogEntry logEntry = new LogEntry
                    {
                        Timestamp = match.Groups[1].Value,
                        Level = match.Groups[2].Value,
                        Message = match.Groups[3].Value
                    };
                    ResultsListBox.Items.Add(logEntry);
                }
            }
        }

        // 用于存储日志条目的数据模型
        public class LogEntry
        {
            public string Timestamp { get; set; }
            public string Level { get; set; }
            public string Message { get; set; }
        }
    }
}
