// 代码生成时间: 2025-08-02 10:19:22
using System;
using System.IO;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;

// 图片尺寸批量调整器应用程序
namespace ImageResizerApp
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private async void ResizeImages_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                // 获取用户选择的文件夹路径
                string folderPath = FolderPathTextBox.Text;
                if (string.IsNullOrEmpty(folderPath))
                {
                    MessageBox.Show("Please select a folder path.");
                    return;
                }

                // 获取目标尺寸
                int targetWidth = int.Parse(TargetWidthTextBox.Text);
                int targetHeight = int.Parse(TargetHeightTextBox.Text);

                // 获取所有图片文件
                var files = Directory.GetFiles(folderPath, "*.*", SearchOption.AllDirectories)
                    .Where(file => file.EndsWith(".jpg") || file.EndsWith(".png") || file.EndsWith(".jpeg"))
                    .ToList();

                // 调整图片尺寸
                await ResizeImagesAsync(files, folderPath, targetWidth, targetHeight);

                MessageBox.Show("Images resized successfully.");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}");
            }
        }

        private async Task ResizeImagesAsync(List<string> files, string folderPath, int targetWidth, int targetHeight)
        {
            foreach (var file in files)
            {
                try
                {
                    // 读取图片文件
                    BitmapImage bitmap = new BitmapImage();
                    using (FileStream stream = new FileStream(file, FileMode.Open, FileAccess.Read))
                    {
                        bitmap.BeginInit();
                        bitmap.CacheOption = BitmapCacheOption.OnLoad;
                        bitmap.UriSource = null;
                        bitmap.StreamSource = stream;
                        bitmap.EndInit();
                    }

                    // 创建新图像并在目标尺寸下绘制原始图像
                    RenderTargetBitmap renderTargetBitmap = new RenderTargetBitmap(
                        targetWidth, targetHeight, 96, 96, PixelFormats.Pbgra32);
                    renderTargetBitmap.Render(bitmap);

                    // 将新图像保存为文件
                    PngBitmapEncoder encoder = new PngBitmapEncoder();
                    encoder.Frames.Add(BitmapFrame.Create(renderTargetBitmap));
                    using (FileStream pngStream = new FileStream(file, FileMode.Create, FileAccess.Write))
                    {
                        encoder.Save(pngStream);
                    }

                    await Task.Delay(100); // 稍作延迟以便观察
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error resizing image {file}: {ex.Message}");
                }
            }
        }
    }
}
