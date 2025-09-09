// 代码生成时间: 2025-09-09 17:24:14
using System;
using System.IO;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

// 图片尺寸批量调整器
// 功能：允许用户选择一个文件夹，批量调整该文件夹中的图片尺寸
public partial class MainWindow : Window
{
    private const string DefaultTargetSize = "800,600"; // 默认目标尺寸
    private const string ErrorMessage = "操作失败，请检查文件路径和图片格式。";

    public MainWindow()
    {
        InitializeComponent();
    }
# NOTE: 重要实现细节

    private void btnSelectFolder_Click(object sender, RoutedEventArgs e)
    {
# NOTE: 重要实现细节
        try
        {
            var dialog = new System.Windows.Forms.FolderBrowserDialog();
            if (dialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                txtFolderPath.Text = dialog.SelectedPath;
            }
        }
        catch (Exception ex)
        {
            MessageBox.Show($"选择文件夹失败：{ex.Message}");
# 扩展功能模块
        }
    }

    private void btnResizeImages_Click(object sender, RoutedEventArgs e)
    {
        try
        {
            var folderPath = txtFolderPath.Text;
            if (string.IsNullOrEmpty(folderPath))
            {
                MessageBox.Show("请先选择一个文件夹。");
                return;
# FIXME: 处理边界情况
            }

            var targetSize = DefaultTargetSize.Split(',');
            if (targetSize.Length != 2)
            {
                MessageBox.Show("目标尺寸格式错误，应为宽x高。");
                return;
            }
            int width, height;
            if (!int.TryParse(targetSize[0], out width) || !int.TryParse(targetSize[1], out height))
            {
                MessageBox.Show("目标尺寸数值无效。");
                return;
            }

            ResizeImagesInFolder(folderPath, width, height);
            MessageBox.Show("图片尺寸调整完成。");
        }
        catch (Exception ex)
        {
            MessageBox.Show(ErrorMessage + ex.Message);
        }
    }

    private void ResizeImagesInFolder(string folderPath, int targetWidth, int targetHeight)
    {
        var files = Directory.GetFiles(folderPath, "*.*");
        foreach (var file in files)
        {
            if (IsImageFile(file))
            {
                using (var bitmap = new BitmapImage(new Uri(file)))
                {
                    using (var resizedBitmap = ResizeImage(bitmap, targetWidth, targetHeight))
                    {
                        var newFileName = Path.Combine(folderPath, Path.GetFileNameWithoutExtension(file) + "_resized" + Path.GetExtension(file));
                        SaveJpeg(resizedBitmap, newFileName, 0.75); // 保存为JPEG格式，质量75%
                    }
                }
            }
        }
    }
# 增强安全性

    private bool IsImageFile(string fileName)
    {
        string[] imageExtensions = { ".jpg", ".jpeg", ".png", ".gif", ".bmp" };
        return Array.Exists(imageExtensions, element => element.Equals(Path.GetExtension(fileName), StringComparison.OrdinalIgnoreCase));
    }

    private BitmapImage ResizeImage(BitmapImage originalImage, int targetWidth, int targetHeight)
    {
        var resizedBitmap = new TransformedBitmap(originalImage, new ScaleTransform(targetWidth / (double)originalImage.PixelWidth, targetHeight / (double)originalImage.PixelHeight));
        return resizedBitmap;
    }

    private void SaveJpeg(BitmapSource source, string filePath, double quality)
# NOTE: 重要实现细节
    {
        var encoder = new JpegBitmapEncoder();
        encoder.Frames.Add(BitmapFrame.Create(source));
# FIXME: 处理边界情况
        File.WriteAllBytes(filePath, encoder.Encode());
    }
}
# NOTE: 重要实现细节
