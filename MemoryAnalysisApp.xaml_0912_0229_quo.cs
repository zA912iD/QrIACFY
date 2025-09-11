// 代码生成时间: 2025-09-12 02:29:43
using System;
using System.Diagnostics;
using System.Windows;

// MemoryAnalysisApp.xaml.cs
// This file contains the code behind the main window of the Memory Analysis application

namespace MemoryAnalysisApp
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            SetupMemoryAnalysis();
        }

        private void SetupMemoryAnalysis()
        {
            // This method sets up the application to analyze memory usage
            try
            {
                // Assuming that MemoryUsageText is a TextBlock where the memory usage will be displayed
                MemoryUsageText.Text = AnalyzeMemoryUsage().ToString();
            }
            catch (Exception ex)
            {
                // Handle any exceptions that occur during memory analysis
                MessageBox.Show($"Error analyzing memory usage: {ex.Message}");
            }
        }

        // AnalyzeMemoryUsage method calculates the total memory used by the process
        private long AnalyzeMemoryUsage()
        {
            // Get the current process
            Process currentProcess = Process.GetCurrentProcess();

            // Calculate the total memory used by the process
            long memoryUsed = currentProcess.WorkingSet64;

            // Return the memory used in bytes
            return memoryUsed;
        }
    }
}