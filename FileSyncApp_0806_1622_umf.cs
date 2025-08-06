// 代码生成时间: 2025-08-06 16:22:02
using System;
using System.IO;
# TODO: 优化性能
using System.Threading.Tasks;
# 优化算法效率
using System.Windows;

namespace FileSyncApp
{
# NOTE: 重要实现细节
    // MainWindow.xaml.cs
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private async void BackupAndSync_Click(object sender, RoutedEventArgs e)
# NOTE: 重要实现细节
        {
            try
            {
                // 获取源目录和目标目录
                string sourcePath = SourceTextBox.Text;
                string targetPath = TargetTextBox.Text;
# 添加错误处理

                // 调用备份和同步方法
                await BackupAndSyncDirectory(sourcePath, targetPath);
                MessageBox.Show("备份和同步完成！", "操作成功", MessageBoxButton.OK, MessageBoxImage.Information);
            }
# TODO: 优化性能
            catch (Exception ex)
            {
                MessageBox.Show($"发生错误：{ex.Message}", "错误", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        // 备份和同步目录
        private async Task BackupAndSyncDirectory(string sourcePath, string targetPath)
        {
            // 确保源目录和目标目录存在
            if (!Directory.Exists(sourcePath))
            {
# NOTE: 重要实现细节
                throw new DirectoryNotFoundException($"源目录不存在：{sourcePath}");
# 添加错误处理
            }
            if (!Directory.Exists(targetPath))
            {                
                Directory.CreateDirectory(targetPath);
            }

            // 获取源目录和目标目录中的所有文件
            var sourceFiles = Directory.GetFiles(sourcePath, "*", SearchOption.AllDirectories);
# FIXME: 处理边界情况
            var targetFiles = Directory.GetFiles(targetPath, "*", SearchOption.AllDirectories);

            // 同步文件
            foreach (var sourceFile in sourceFiles)
            {
                var targetFile = Path.Combine(targetPath, sourceFile.Substring(sourcePath.Length + 1));
                if (!File.Exists(targetFile) || File.GetLastWriteTime(sourceFile) > File.GetLastWriteTime(targetFile))
                {
                    // 复制文件到目标目录
                    await CopyFileAsync(sourceFile, targetFile);
                }
            }
        }

        // 异步复制文件
        private static async Task CopyFileAsync(string sourceFile, string destFile)
        {
# 扩展功能模块
            using (var sourceStream = new FileStream(sourceFile, FileMode.Open, FileAccess.Read))
            {
                using (var destStream = new FileStream(destFile, FileMode.Create, FileAccess.Write))
# 添加错误处理
                {
                    await sourceStream.CopyToAsync(destStream);
                }
            }
        }
# 改进用户体验
    }
}
