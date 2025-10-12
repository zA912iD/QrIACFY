// 代码生成时间: 2025-10-13 00:00:21
using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Windows; // For WPF

namespace DuplicateFileDetector
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

        private void DetectDuplicatesButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                // Get the directory path from the user
                string directoryPath = DirectoryPathTextBox.Text;
                if (string.IsNullOrWhiteSpace(directoryPath))
                {
                    MessageBox.Show("Please enter a directory path.");
                    return;
                }

                // Check if the directory exists
                if (!Directory.Exists(directoryPath))
                {
                    MessageBox.Show("The specified directory does not exist.");
                    return;
                }

                List<Tuple<string, long>> filesWithSize = new List<Tuple<string, long>>();

                // Get all files in the directory and their sizes
                foreach (string file in Directory.GetFiles(directoryPath))
                {
                    FileInfo fileInfo = new FileInfo(file);
                    filesWithSize.Add(Tuple.Create(fileInfo.FullName, fileInfo.Length));
                }

                // Find and display duplicate files
                var duplicates = FindDuplicates(filesWithSize);
                DisplayDuplicates(duplicates);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}");
            }
        }

        private List<string> FindDuplicates(List<Tuple<string, long>> filesWithSize)
        {
            // Group files by size and filter out groups with more than one file
            var duplicates = filesWithSize
                .GroupBy(file => file.Item2)
                .Where(group => group.Count() > 1)
                .SelectMany(group => group.Select(file => file.Item1))
                .ToList();

            return duplicates;
        }

        private void DisplayDuplicates(List<string> duplicates)
        {
            if (!duplicates.Any())
            {
                MessageBox.Show("No duplicates found.");
                return;
            }

            string message = "Duplicate files found:
";
            foreach (var file in duplicates)
            {
                message += file + "
";
            }

            MessageBox.Show(message);
        }
    }
}