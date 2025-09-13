// 代码生成时间: 2025-09-14 01:52:58
using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;

namespace SortingAlgorithmApp
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

        private void SortButton_Click(object sender, RoutedEventArgs e)
        {
            List<int> numbers = GetNumbersFromTextBox();

            if (numbers == null)
            {
                MessageBox.Show("Please enter valid numbers separated by commas.");
                return;
            }

            try
            {
                // Perform sorting
                List<int> sortedNumbers = SortNumbers(numbers);

                // Display sorted numbers in the ResultsTextBox
                ResultsTextBox.Text = string.Join(",", sortedNumbers);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}");
            }
        }

        private List<int> GetNumbersFromTextBox()
        {
            string input = InputTextBox.Text;
            if (string.IsNullOrWhiteSpace(input))
            {
                return null;
            }

            string[] parts = input.Split(',');
            List<int> numbers = new List<int>();
            foreach (var part in parts)
            {
                if (int.TryParse(part.Trim(), out int number))
                {
                    numbers.Add(number);
                }
                else
                {
                    return null;
                }
            }
            return numbers;
        }

        private List<int> SortNumbers(List<int> numbers)
        {
            // You can implement different sorting algorithms here
            // For simplicity, we use the built-in List<T>.Sort method
            numbers.Sort();
            return numbers;
        }
    }
}