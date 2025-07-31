// 代码生成时间: 2025-08-01 05:45:57
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace DataAnalysisApp
{
    /// <summary>
    /// Interaction logic for DataAnalyzerApp.xaml
    /// </summary>
    public partial class DataAnalyzerApp : Window
    {
        public DataAnalyzerApp()
        {
            InitializeComponent();
        }

        // Event handler for button click to start analysis
        private void AnalyzeDataButton_Click(object sender, RoutedEventArgs e)
        {
            string filePath = DataFilePathTextBox.Text;
            try
            {
                // Check if file path is valid
                if(string.IsNullOrEmpty(filePath) || !File.Exists(filePath))
                {
                    MessageBox.Show("Please provide a valid file path.", "Error");
                    return;
                }

                // Read file and perform analysis
                List<double> data = ReadDataFromFile(filePath);
                PerformAnalysis(data);
            }
            catch (Exception ex)
            {
                // Handle any exceptions that occur during the process
                MessageBox.Show($"An error occurred: {ex.Message}", "Error");
            }
        }

        // Method to read data from a file
        private List<double> ReadDataFromFile(string filePath)
        {
            var data = new List<double>();
            using (StreamReader reader = new StreamReader(filePath))
            {
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    if(double.TryParse(line, out double number))
                    {
                        data.Add(number);
                    }
                    else
                    {
                        MessageBox.Show($"Line '{line}' is not a valid number.", "Data Error");
                        return null;
                    }
                }
            }
            return data;
        }

        // Method to perform statistical analysis
        private void PerformAnalysis(List<double> data)
        {
            if(data == null || data.Count == 0)
            {
                MessageBox.Show("No data to analyze.", "Error");
                return;
            }

            // Calculate basic statistics
            double sum = data.Sum();
            double average = sum / data.Count;
            double max = data.Max();
            double min = data.Min();

            // Display results
            MessageBox.Show($"Average: {average}, Max: {max}, Min: {min}", "Analysis Results");
        }
    }
}