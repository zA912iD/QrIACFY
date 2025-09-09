// 代码生成时间: 2025-09-09 21:39:48
using System;
using System.IO;
using System.Windows;
using System.Windows.Controls;

namespace DataBackupRecoveryApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private const string BackupFolder = @"C:\BackupFolder";
        private const string DataFolder = @"C:\DataFolder";

        public MainWindow()
        {
            InitializeComponent();
        }

        private void BackupData_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                // Ensure backup folder exists
                Directory.CreateDirectory(BackupFolder);

                // Create a new timestamped backup folder
                string backupPath = Path.Combine(BackupFolder, $"Backup_{DateTime.Now:yyyyMMddHHmmss}");
                Directory.CreateDirectory(backupPath);

                // Copy files from data folder to backup folder
                CopyDirectory(DataFolder, backupPath);

                MessageBox.Show("Data backup completed successfully.");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error during backup: {ex.Message}");
            }
        }

        private void RestoreData_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                // Get the path of the backup folder to restore from
                string backupPath = GetBackupPath();
                if (string.IsNullOrEmpty(backupPath)) return;

                // Clear existing data folder
                Directory.Delete(DataFolder, true);

                // Copy files from backup folder to data folder
                CopyDirectory(backupPath, DataFolder);

                MessageBox.Show("Data restore completed successfully.");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error during restore: {ex.Message}");
            }
        }

        private string GetBackupPath()
        {
            // Use a folder browser dialog to select the backup folder
            Microsoft.Win32.OpenFileDialog openFileDialog = new Microsoft.Win32.OpenFileDialog
            {
                DefaultExt = ".",
                Filter = "Folders|*.*",
                Multiselect = false
            };

            if (openFileDialog.ShowDialog() == true)
            {
                return openFileDialog.FileName;
            }

            return null;
        }

        private void CopyDirectory(string sourceDir, string destinationDir)
        {
            // Check if the source directory exists
            if (!Directory.Exists(sourceDir))
            {
                throw new DirectoryNotFoundException($"Source directory does not exist or could not be found: {sourceDir}");
            }

            // Check if the destination directory exists
            if (!Directory.Exists(destinationDir))
            {
                Directory.CreateDirectory(destinationDir);
            }

            // Copy each file into it
            foreach (string file in Directory.GetFiles(sourceDir))
            {
                File.Copy(file, Path.Combine(destinationDir, Path.GetFileName(file)), true);
            }

            // Copy subdirectories
            foreach (string directory in Directory.GetDirectories(sourceDir))
            {
                string tempPath = Path.Combine(destinationDir, Path.GetFileName(directory));
                CopyDirectory(directory, tempPath);
            }
        }
    }
}
