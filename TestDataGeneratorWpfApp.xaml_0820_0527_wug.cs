// 代码生成时间: 2025-08-20 05:27:49
using System;
using System.Collections.Generic;
using System.Windows;

namespace TestDataGeneratorApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly Random _random = new Random();

        public MainWindow()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Generates a list of random test data and shows it in a MessageBox.
        /// </summary>
        private void GenerateTestData_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                List<string> testData = GenerateTestData(10); // Generate 10 test data entries
                string dataToShow = string.Join(
", testData);
                MessageBox.Show(dataToShow, "Generated Test Data");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}", "Error");
            }
        }

        /// <summary>
        /// Generates a list of random strings to serve as test data.
        /// </summary>
        /// <param name="count">The number of test data entries to generate.</param>
        /// <returns>A list of test data entries.</returns>
        private List<string> GenerateTestData(int count)
        {
            var testData = new List<string>();

            for (int i = 0; i < count; i++)
            {
                testData.Add($"Test Data Entry {_random.Next(1000)}"); // Generate a random data entry
            }

            return testData;
        }
    }
}
