// 代码生成时间: 2025-08-18 14:01:19
using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;
using LiveCharts;
using LiveCharts.Wpf;
using System.Collections.Generic;

namespace InteractiveChartGenerator
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private ChartValues<ObservableValue> chartValues = new ChartValues<ObservableValue>();

        public MainWindow()
        {
            InitializeComponent();
            InitializeChart();
        }

        /// <summary>
        /// Initializes the chart with sample data and series.
        /// </summary>
        private void InitializeChart()
        {
            chartValues.Add(new ObservableValue(4));
            chartValues.Add(new ObservableValue(3));
            chartValues.Add(new ObservableValue(6));
            chartValues.Add(new ObservableValue(7));

            var series = new SeriesCollection
            {
                new LineSeries
                {
                    Values = chartValues,
                    Stroke = Brushes.Red
                }
            };

            MyChart.Series = series;
        }

        /// <summary>
        /// Adds a new random value to the chart.
        /// </summary>
        private void AddValueButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                // Generate a random value between 1 and 10.
                int randomValue = new Random().Next(1, 11);
                chartValues.Add(new ObservableValue(randomValue));
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error adding value: {ex.Message}");
            }
        }

        /// <summary>
        /// Removes the last value from the chart.
        /// </summary>
        private void RemoveValueButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (chartValues.Count > 0)
                {
                    chartValues.RemoveAt(chartValues.Count - 1);
                }
                else
                {
                    MessageBox.Show("No values to remove.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error removing value: {ex.Message}");
            }
        }
    }
}
