// 代码生成时间: 2025-08-08 15:24:23
using System;
using System.IO;
using System.Windows;
using Microsoft.Office.Interop.Word;
using System.Runtime.InteropServices;

// 文档格式转换器的WPF应用
namespace DocumentConverterApp
{
    public partial class MainWindow : Window
    {
        // 构造函数
        public MainWindow()
        {
            InitializeComponent();
        }

        // 将Word文档转换为PDF
        private void ConvertToPdfButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                // 获取Word文件路径
                var wordFilePath = txtWordFilePath.Text;
                if (string.IsNullOrEmpty(wordFilePath))
                {
                    MessageBox.Show("Please enter a valid Word file path.");
                    return;
                }

                // 获取PDF文件路径
                var pdfFilePath = txtPdfFilePath.Text;
                if (string.IsNullOrEmpty(pdfFilePath))
                {
                    MessageBox.Show("Please enter a valid PDF file path.");
                    return;
                }

                // 检查文件是否存在
                if (!File.Exists(wordFilePath))
                {
                    MessageBox.Show("The specified Word file does not exist.");
                    return;
                }

                // 创建Word应用程序实例
                Application wordApp = new Application();
                wordApp.Visible = false;

                // 打开Word文档
                Document doc = wordApp.Documents.Open(wordFilePath);

                // 保存为PDF
                doc.SaveAs2(pdfFilePath, WdSaveFormat.wdFormatPDF);
                doc.Close();
                wordApp.Quit();

                // 提示用户转换成功
                MessageBox.Show("Conversion to PDF completed successfully.");
            }
            catch (COMException ex)
            {
                // 处理COM异常
                MessageBox.Show("Error occurred: " + ex.Message);
            }
            catch (Exception ex)
            {
                // 处理其他异常
                MessageBox.Show("An unexpected error occurred: " + ex.Message);
            }
        }
    }
}
