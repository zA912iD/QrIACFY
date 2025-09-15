// 代码生成时间: 2025-09-15 22:02:48
// DocumentConverterApp.xaml.cs
// 这是一个使用WPF框架创建的文档格式转换器应用

using System;
using System.IO;
using System.Windows;
using System.Windows.Controls;
# 增强安全性
using System.Windows.Input;
using Microsoft.Office.Interop.Excel;
using Microsoft.Office.Interop.Word;

namespace DocumentConverterApp
# 添加错误处理
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
# 优化算法效率
    /// </summary>
    public partial class MainWindow : Window
# 扩展功能模块
    {
# FIXME: 处理边界情况
        public MainWindow()
        {
            InitializeComponent();
        }

        private void ConvertToPDF_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                // 获取要转换的文件路径
                string filePath = FileToConvertTextBox.Text;
                if (string.IsNullOrEmpty(filePath))
                {
                    MessageBox.Show("Please select a file to convert.", "Error");
                    return;
                }

                // 检查文件是否存在
                if (!File.Exists(filePath))
                {
                    MessageBox.Show("The file does not exist.", "Error");
                    return;
                }

                // 确定输出路径
                string outputPath = Path.ChangeExtension(filePath, ".pdf");

                // 根据文件类型进行转换
# 添加错误处理
                ConvertDocumentToPdf(filePath, outputPath);

                // 显示转换成功的消息
                MessageBox.Show("Conversion to PDF completed successfully.", "Success");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}", "Error");
            }
# 增强安全性
        }

        private void ConvertDocumentToPdf(string sourcePath, string outputPath)
# 改进用户体验
        {
            // 根据文件的扩展名确定转换方法
            switch (Path.GetExtension(sourcePath).ToLower())
            {
                case ".docx":
                    ConvertWordToPdf(sourcePath, outputPath);
                    break;
                case ".xlsx":
                    ConvertExcelToPdf(sourcePath, outputPath);
                    break;
                default:
                    throw new NotSupportedException($"The file type {Path.GetExtension(sourcePath)} is not supported.");
# 扩展功能模块
            }
        }

        private void ConvertWordToPdf(string sourcePath, string outputPath)
        {
            // 使用Microsoft Office Interop Word进行转换
            Application wordApp = new Application();
            Document wordDoc = wordApp.Documents.Open(sourcePath);
            wordDoc.SaveAs(outputPath, WdSaveFormat.wdFormatPDF);
            wordDoc.Close();
            wordApp.Quit();
        }

        private void ConvertExcelToPdf(string sourcePath, string outputPath)
        {
            // 使用Microsoft Office Interop Excel进行转换
            Application excelApp = new Application();
            Workbook excelBook = excelApp.Workbooks.Open(sourcePath);
            excelBook.ExportAsFixedFormat(XlFixedFormatType.xlTypePDF, outputPath);
            excelBook.Close();
            excelApp.Quit();
        }
    }
}
