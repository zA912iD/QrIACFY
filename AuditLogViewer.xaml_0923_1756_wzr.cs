// 代码生成时间: 2025-09-23 17:56:33
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows;
using System.Xml.Linq;

namespace AuditLogViewer
{
    /// <summary>
    /// Interaction logic for AuditLogViewer.xaml
    /// </summary>
    public partial class AuditLogViewer : Window
    {
        private const string LogFilePath = @".\logs\audit.log";
        private List<string> logEntries = new List<string>();

        public AuditLogViewer()
        {
            InitializeComponent();
            LoadLogEntries();
        }

        /// <summary>
        /// Loads log entries from the file into the UI.
        /// </summary>
        private void LoadLogEntries()
        {
            try
            {
                if (File.Exists(LogFilePath))
                {
                    logEntries = File.ReadAllLines(LogFilePath).ToList();
                    LogListBox.ItemsSource = logEntries;
                }
                else
                {
                    MessageBox.Show("Log file not found.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred while loading log entries: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        /// <summary>
        /// Saves the selected log entry to a new file.
        /// </summary>
        private void SaveLogEntry_Click(object sender, RoutedEventArgs e)
        {
            if (LogListBox.SelectedItem == null)
            {
                MessageBox.Show("Please select a log entry to save.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            var logEntry = (string)LogListBox.SelectedItem;
            try
            {
                using (var dialog = new Microsoft.Win32.SaveFileDialog())
                {
                    dialog.FileName = "LogEntry.txt";
                    if (dialog.ShowDialog() == true)
                    {
                        File.WriteAllText(dialog.FileName, logEntry);
                        MessageBox.Show("Log entry saved successfully.", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred while saving the log entry: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}