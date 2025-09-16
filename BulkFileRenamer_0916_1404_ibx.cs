// 代码生成时间: 2025-09-16 14:04:40
using System;
using System.IO;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace BulkFileRenamer
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void BrowseButton_Click(object sender, RoutedEventArgs e)
        {
            // Open a folder browser dialog to select the directory containing files to be renamed.
            var dialog = new System.Windows.Forms.FolderBrowserDialog();
            if (dialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                DirectoryTextBox.Text = dialog.SelectedPath;
            }
        }

        private void RenameButton_Click(object sender, RoutedEventArgs e)
        {
            // Get the directory path and the new file name pattern from the user input.
            string directoryPath = DirectoryTextBox.Text;
            string newFileNamePattern = NewFileNameTextBox.Text;
            try
            {
                // Validate the directory path and the new file name pattern.
                if (string.IsNullOrWhiteSpace(directoryPath) || !Directory.Exists(directoryPath))
                {
                    MessageBox.Show("Please select a valid directory.");
                    return;
                }
                if (string.IsNullOrWhiteSpace(newFileNamePattern))
                {
                    MessageBox.Show("Please enter a new file name pattern.");
                    return;
                }

                // Rename the files in the directory based on the new file name pattern.
                RenameFiles(directoryPath, newFileNamePattern);
                MessageBox.Show("Files have been renamed successfully.");
            }
            catch (Exception ex)
            {
                // Show an error message if any exception occurs during the renaming process.
                MessageBox.Show($"An error occurred: {ex.Message}");
            }
        }

        private void RenameFiles(string directoryPath, string newFileNamePattern)
        {
            // Get the files in the directory and rename them based on the new file name pattern.
            string[] files = Directory.GetFiles(directoryPath);
            int fileNumber = 1;
            foreach (var file in files)
            {
                string newFileName = $