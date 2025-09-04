// 代码生成时间: 2025-09-05 03:35:11
using System;
using System.IO;
using System.Linq;
using System.Collections.Generic;
using System.Windows;

namespace FolderOrganizerApp
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

        private void OrganizeFolders(string sourcePath)
        {
            // Check if the path exists
            if (!Directory.Exists(sourcePath))
            {
                MessageBox.Show("Source path does not exist.", "Error");
                return;
            }

            try
            {
                // Get all the files from the source directory
                var files = Directory.GetFiles(sourcePath);

                // Create a dictionary to hold file extensions and their corresponding list of files
                Dictionary<string, List<string>> fileDictionary = new Dictionary<string, List<string>>();

                foreach (var file in files)
                {
                    var fileInfo = new FileInfo(file);
                    var extension = fileInfo.Extension;

                    if (!fileDictionary.ContainsKey(extension))
                    {
                        fileDictionary[extension] = new List<string>();
                    }

                    fileDictionary[extension].Add(file);
                }

                // Organize files into their respective folders based on extension
                foreach (var fileGroup in fileDictionary)
                {
                    var directoryPath = Path.Combine(sourcePath, fileGroup.Key.TrimStart('.'));
                    Directory.CreateDirectory(directoryPath); // Create directory if it doesn't exist

                    foreach (var file in fileGroup.Value)
                    {
                        // Move file to the new directory
                        File.Move(file, Path.Combine(directoryPath, Path.GetFileName(file)));
                    }
                }

                MessageBox.Show("Folders have been organized successfully.", "Success");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}", "Error");
            }
        }
    }
}

// Note: This code assumes that the MainWindow.xaml contains a method or event handler
// that will call the OrganizeFolders method with the appropriate source path.