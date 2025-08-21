// 代码生成时间: 2025-08-21 19:23:12
using System;
using System.IO;
using System.IO.Compression;
using System.Windows;

namespace FileDecompressionTool
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        // Event handler for the Decompress button
        private async void DecompressButton_Click(object sender, RoutedEventArgs e)
        {
            // Ensure the file path is not empty
            if (string.IsNullOrEmpty(FilePathTextBox.Text))
            {
                MessageBox.Show("Please select a file to decompress.");
                return;
            }

            var filePath = FilePathTextBox.Text;
            var fileNameWithoutExtension = Path.GetFileNameWithoutExtension(filePath);
            var decompressedFolderPath = Path.Combine(Path.GetDirectoryName(filePath), fileNameWithoutExtension);

            try
            {
                // Decompress the file to the specified folder
                await Task.Run(() => DecompressFile(filePath, decompressedFolderPath));
                MessageBox.Show($"Decompressed successfully to: {decompressedFolderPath}");
            }
            catch (Exception ex)
            {
                // Handle any exceptions that occur during decompression
                MessageBox.Show($"An error occurred: {ex.Message}");
            }
        }

        // Method to decompress a file
        private void DecompressFile(string filePath, string decompressedFolderPath)
        {
            // Ensure the folder exists
            if (!Directory.Exists(decompressedFolderPath))
            {
                Directory.CreateDirectory(decompressedFolderPath);
            }

            // Decompress the file
            ZipFile.ExtractToDirectory(filePath, decompressedFolderPath);
        }
    }
}
