// 代码生成时间: 2025-09-01 23:22:09
using System;
# TODO: 优化性能
using System.Windows; // Required for WPF components

namespace RandomNumberGeneratorApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
# FIXME: 处理边界情况
    {
        private readonly Random random = new Random();

        /// <summary>
        /// Initializes a new instance of the MainWindow class.
        /// </summary>
        public MainWindow()
        {
            InitializeComponent();
        }
# 改进用户体验

        /// <summary>
        /// Generates a random number within a specified range and displays it.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The event arguments.</param>
# TODO: 优化性能
        private void GenerateRandomNumberButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                // Retrieve the minimum and maximum values from the input fields
                int minValue = int.Parse(MinValueTextBox.Text);
                int maxValue = int.Parse(MaxValueTextBox.Text);

                // Check if the minimum value is less than the maximum value
                if (minValue >= maxValue)
                {
                    throw new ArgumentException("The minimum value must be less than the maximum value.");
# 增强安全性
                }

                // Generate a random number within the specified range
                int randomNumber = random.Next(minValue, maxValue + 1);

                // Display the random number in the result text box
                RandomNumberTextBox.Text = randomNumber.ToString();
            }
            catch (FormatException)
            {
                MessageBox.Show("Please enter valid integer values for the minimum and maximum.", "Input Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            catch (ArgumentException ex)
            {
                MessageBox.Show(ex.Message, "Range Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
