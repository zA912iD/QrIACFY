// 代码生成时间: 2025-08-27 14:55:00
using System;
# TODO: 优化性能
using System.IO;
# 扩展功能模块
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media.Imaging;

namespace ImageResizerApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void BrowseButton_Click(object sender, RoutedEventArgs e)
        {
# FIXME: 处理边界情况
            // Open file dialog to select images
            Microsoft.Win32.OpenFileDialog openFileDialog = new Microsoft.Win32.OpenFileDialog
# 添加错误处理
            {
                Filter = "Image Files|*.png;*.jpg;*.jpeg;*.bmp;*.gif;*.tif;*.tiff"
            };

            if (openFileDialog.ShowDialog() == true)
            {
                foreach (string filename in openFileDialog.FileNames)
                {
                    try
                    {
                        // Resize the image
                        ResizeImage(filename);
                    }
# FIXME: 处理边界情况
                    catch (Exception ex)
                    {
# 增强安全性
                        MessageBox.Show($"Error resizing image {filename}: {ex.Message}", "Error");
                    }
                }
            }
        }

        private void ResizeImage(string filePath)
        {
            // Define the target size
            int targetWidth = 800; // Width
            int targetHeight = 600; // Height

            // Create a new bitmap image
# 添加错误处理
            using (BitmapImage newImage = new BitmapImage())
            {
# 添加错误处理
                // Decode the image
                using (FileStream stream = new FileStream(filePath, FileMode.Open, FileAccess.Read))
                {
                    newImage.BeginInit();
                    newImage.CacheOption = BitmapCacheOption.OnLoad;
# 添加错误处理
                    newImage.UriSource = null;
# 增强安全性
                    newImage.StreamSource = stream;
                    newImage.EndInit();
# FIXME: 处理边界情况
                }

                // Calculate the scaling factor
                double scaleX = targetWidth / newImage.Width;
                double scaleY = targetHeight / newImage.Height;
                double scale = Math.Min(scaleX, scaleY);

                // Resize the image
                int newWidth = Convert.ToInt32(newImage.Width * scale);
                int newHeight = Convert.ToInt32(newImage.Height * scale);
                RenderTargetBitmap resizedImage = new RenderTargetBitmap(
                    newWidth, newHeight, 96, 96, PixelFormats.Pbgra32);
                resizedImage.Render(newImage);

                // Save the resized image
# TODO: 优化性能
                string directory = Path.GetDirectoryName(filePath);
# NOTE: 重要实现细节
                string fileNameWithoutExtension = Path.GetFileNameWithoutExtension(filePath);
                string newFileName = $