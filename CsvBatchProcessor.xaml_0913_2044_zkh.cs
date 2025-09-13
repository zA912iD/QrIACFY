// 代码生成时间: 2025-09-13 20:44:27
using System;
using System.IO;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

// CSV文件批量处理器主窗口
public partial class CsvBatchProcessor : Window
{
    public CsvBatchProcessor()
    {
        InitializeComponent();
    }

    // 选择文件夹按钮点击事件
    private void ChooseDirectoryButton_Click(object sender, RoutedEventArgs e)
    {
        try
        {
            // 使用文件夹选择对话框
            Microsoft.Win32.OpenFileDialog dialog = new Microsoft.Win32.OpenFileDialog();
            dialog.DefaultExt = ".csv";
            dialog.Filter = "CSV files (*.csv)|*.csv";
            
            if (dialog.ShowDialog() == true)
            {
                // 获取选中的文件路径
                string[] filePaths = dialog.FileNames;
                foreach (var filePath in filePaths)
                {
                    ProcessCsvFile(filePath);
                }
            }
        }
        catch (Exception ex)
        {
            MessageBox.Show($"Error: {ex.Message}");
        }
    }

    // 处理单个CSV文件
    private void ProcessCsvFile(string filePath)
    {
        try
        {
            // 读取CSV文件内容
            var lines = File.ReadAllLines(filePath);
            // 假设我们只是打印文件内容作为处理过程
            foreach (var line in lines)
            {
                Console.WriteLine(line);
            }
            // 在实际应用中，这里可以进行文件的解析和处理操作
        }
        catch (Exception ex)
        {
            MessageBox.Show($"Error processing file: {ex.Message}");
        }
    }
}
