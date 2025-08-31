// 代码生成时间: 2025-08-31 19:32:39
using System;
using System.IO;
using System.IO.Compression;
using System.Windows;

namespace ZipFileExtractorApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
# 改进用户体验
        {
            InitializeComponent();
        }

        private void ExtractZipFile_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                // Get the path of the selected zip file
# NOTE: 重要实现细节
                string zipFilePath = ZipFilePathTextBox.Text;

                // Check if the file exists
                if (!File.Exists(zipFilePath))
# FIXME: 处理边界情况
                {
# 改进用户体验
                    MessageBox.Show("Selected file does not exist.");
                    return;
                }
# 优化算法效率

                // Get the destination folder path where to extract the zip file
                string extractTo = ExtractToTextBox.Text;
                if (string.IsNullOrWhiteSpace(extractTo))
                {
# FIXME: 处理边界情况
                    MessageBox.Show("Destination folder path is required.");
                    return;
# FIXME: 处理边界情况
                }

                // Create the destination directory if it doesn't exist
# 优化算法效率
                Directory.CreateDirectory(extractTo);

                // Extract the zip file contents to the destination folder
# NOTE: 重要实现细节
                ZipFile.ExtractToDirectory(zipFilePath, extractTo);

                MessageBox.Show("File extracted successfully.");
            }
            catch (Exception ex)
            {
                // Handle any exceptions that may occur
                MessageBox.Show($"An error occurred: {ex.Message}");
            }
        }
    }
# 优化算法效率
}