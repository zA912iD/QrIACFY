// 代码生成时间: 2025-08-21 23:14:45
 * Features:
 * - Directory selection
 * - File rename with prefix and incremental numbers
 * - Error handling
 * - Comments and documentation
 */
using System;
using System.IO;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using Microsoft.Win32;
using System.Windows.Input;

namespace BatchFileRenamerApp
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        // Handles the directory selection button click event.
        private void SelectDirectory_Click(object sender, RoutedEventArgs e)
        {
            var dialog = new FolderBrowserDialog();
            if (dialog.ShowDialog() == true)
            {
                DirectoryPath.Text = dialog.SelectedPath;
            }
        }

        // Handles the rename button click event.
        private void RenameFiles_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(DirectoryPath.Text) || string.IsNullOrEmpty(Prefix.Text))
            {
                MessageBox.Show("Please select a directory and provide a prefix.");
                return;
            }

            string directoryPath = DirectoryPath.Text;
            string prefix = Prefix.Text;
            int startNumber = 1; // Starting number for renaming

            try
            {
                // Get all files in the selected directory.
                var files = Directory.GetFiles(directoryPath).Select(Path.GetFileName).ToList();
                int totalFiles = files.Count;
                for (int i = 0; i < totalFiles; i++)
                {
                    string oldName = files[i];
                    string newName = $