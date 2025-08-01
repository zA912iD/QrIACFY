// 代码生成时间: 2025-08-02 03:20:48
using System;
# TODO: 优化性能
using System.IO;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Imaging;

namespace ImageResizerApp
{
    public partial class MainWindow : Window
    {
        public MainWindow()
# 扩展功能模块
        {
            InitializeComponent();
        }

        private void BrowseButton_Click(object sender, RoutedEventArgs e)
# TODO: 优化性能
        {
            var dialog = new Microsoft.Win32.OpenFileDialog();
            dialog.Filter = "Image files (*.jpg;*.jpeg;*.png;*.gif)|*.jpg;*.jpeg;*.png;*.gif";

            if (dialog.ShowDialog().Value)
            {
# 优化算法效率
                string[] selectedFiles = dialog.FileNames;
                foreach (string filePath in selectedFiles)
                {
                    try
                    {
                        ResizeImage(filePath, "C:\Output\");
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Error processing file: {ex.Message}");
                    }
                }
            }
        }

        private void ResizeImage(string imagePath, string outputDirectory)
        {
            // Load the original image
            var bitmap = new BitmapImage(new Uri(imagePath));

            // Define the new size
            int newWidth = 800; // New width
# 扩展功能模块
            int newHeight = 600; // New height
# NOTE: 重要实现细节

            // Create a new bitmap to hold the resized image
            RenderTargetBitmap resizedImage = new RenderTargetBitmap(newWidth, newHeight, 96, 96, PixelFormats.Pbgra32);
# NOTE: 重要实现细节

            // Scale the image to the new size
            resizedImage.Render(bitmap);

            // Save the resized image
# TODO: 优化性能
            string fileName = Path.GetFileName(imagePath);
            string outputFilePath = Path.Combine(outputDirectory, "Resized_" + fileName);
# TODO: 优化性能
            BitmapEncoder encoder = new PngBitmapEncoder();
            encoder.Frames.Add(BitmapFrame.Create(resizedImage));
            using (var fileStream = new FileStream(outputFilePath, FileMode.Create))
            {
                encoder.Save(fileStream);
            }
        }
# FIXME: 处理边界情况
    }
}