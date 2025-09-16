// 代码生成时间: 2025-09-17 00:14:26
using System;
using System.IO;
using System.IO.Compression;
using System.Windows;

namespace FileDecompressionTool
{
    // Main window for the WPF application
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private async void DecompressFileButton_Click(object sender, RoutedEventArgs e)
        {
            string sourceFilePath = txtSourceFile.Text;
            string destinationFolderPath = txtDestinationFolder.Text;

            // Check if source file path is not empty
            if (string.IsNullOrEmpty(sourceFilePath))
            {
                MessageBox.Show("Please provide a source file path.");
                return;
            }

            // Check if destination folder path is not empty
            if (string.IsNullOrEmpty(destinationFolderPath))
            {
                MessageBox.Show("Please provide a destination folder path.");
                return;
            }

            try
            {
                // Ensure the destination folder exists
                Directory.CreateDirectory(destinationFolderPath);

                // Compress the file
                await Task.Run(() => ZipFile.ExtractToDirectory(sourceFilePath, destinationFolderPath));

                MessageBox.Show("Decompression completed successfully.");
            }
            catch (Exception ex)
            {
                // Handle exceptions and show an error message
                MessageBox.Show($"An error occurred: {ex.Message}");
            }
        }
    }
}
