// 代码生成时间: 2025-09-12 13:19:16
using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace FileBackupAndSyncTool
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

        private async void BackupAndSyncButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string sourcePath = SourcePathTextBox.Text;
                string targetPath = TargetPathTextBox.Text;

                if (string.IsNullOrEmpty(sourcePath) || string.IsNullOrEmpty(targetPath))
                {
                    MessageBox.Show("Source and target paths cannot be empty.");
                    return;
                }

                if (!Directory.Exists(sourcePath))
                {
                    MessageBox.Show("Source path does not exist.");
                    return;
                }

                await BackupAndSyncAsync(sourcePath, targetPath);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}");
            }
        }

        private async Task BackupAndSyncAsync(string sourcePath, string targetPath)
        {
            await Task.Run(() =>
            {
                DirectoryInfo sourceDir = new DirectoryInfo(sourcePath);
                DirectoryInfo targetDir = new DirectoryInfo(targetPath);

                // Create target directory if it does not exist
                if (!targetDir.Exists)
                {
                    targetDir.Create();
                }

                foreach (FileInfo file in sourceDir.GetFiles())
                {
                    string targetFilePath = Path.Combine(targetDir.FullName, file.Name);

                    // Check if the file exists in the target directory
                    if (File.Exists(targetFilePath))
                    {
                        // If the file exists, check if it needs to be updated
                        if (file.LastWriteTime > File.GetLastWriteTime(targetFilePath))
                        {
                            File.Copy(file.FullName, targetFilePath, true); // Overwrite
                        }
                    }
                    else
                    {
                        File.Copy(file.FullName, targetFilePath); // Copy if not exists
                    }
                }

                foreach (DirectoryInfo dir in sourceDir.GetDirectories())
                {
                    string targetDirPath = Path.Combine(targetDir.FullName, dir.Name);
                    DirectoryInfo targetSubDir = new DirectoryInfo(targetDirPath);

                    // Recursively sync subdirectories
                    if (targetSubDir.Exists)
                    {
                        await BackupAndSyncAsync(dir.FullName, targetDirPath);
                    }
                    else
                    {
                        targetSubDir.Create();
                        await BackupAndSyncAsync(dir.FullName, targetDirPath);
                    }
                }
            });

            MessageBox.Show("Backup and sync completed successfully.");
        }
    }
}
