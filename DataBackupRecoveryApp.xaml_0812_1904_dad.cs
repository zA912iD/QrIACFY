// 代码生成时间: 2025-08-12 19:04:46
using System;
using System.IO;
using System.Windows; // Required for WPF

namespace DataBackupRecoveryApp
{
    // MainWindow class which represents the main window of the WPF application
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        // Method to backup data
        private void BackupData()
        {
            try
            {
                // Define the source and backup file paths
                string sourcePath = @"C:\Data\originalFile.txt";
                string backupPath = @"C:\Backup\backupFile.txt";

                // Check if the source file exists
                if (!File.Exists(sourcePath))
                {
                    MessageBox.Show("Source file does not exist.");
                    return;
                }

                // Copy the source file to the backup location
                File.Copy(sourcePath, backupPath, true); // Overwrite if already exists
                MessageBox.Show("Backup completed successfully.");
            }
            catch (Exception ex)
            {
                // Handle any exceptions that occur during the backup process
                MessageBox.Show($"An error occurred: {ex.Message}");
            }
        }

        // Method to restore data
        private void RestoreData()
        {
            try
            {
                // Define the backup and restore file paths
                string backupPath = @"C:\Backup\backupFile.txt";
                string restorePath = @"C:\Data\originalFile.txt";

                // Check if the backup file exists
                if (!File.Exists(backupPath))
                {
                    MessageBox.Show("Backup file does not exist.");
                    return;
                }

                // Copy the backup file to the restore location
                File.Copy(backupPath, restorePath, true); // Overwrite if already exists
                MessageBox.Show("Restore completed successfully.");
            }
            catch (Exception ex)
            {
                // Handle any exceptions that occur during the restore process
                MessageBox.Show($"An error occurred: {ex.Message}");
            }
        }
    }
}
