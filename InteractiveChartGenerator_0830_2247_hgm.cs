// 代码生成时间: 2025-08-30 22:47:41
 * InteractiveChartGenerator.cs
 *
 * This file is part of the WPF application for interactive chart generation.
 * It provides a basic structure for creating and displaying charts.
 */

using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using LiveCharts;
using LiveCharts.Wpf;

namespace InteractiveChartGenerator
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            // Initialize the chart with some default data.
            InitializeChart();
        }

        // Initialize the chart with default data.
        private void InitializeChart()
        {
            try
            {
                var series = new SeriesCollection
                {
                    new LineSeries
                    {
                        Title = "Series 1",
                        Values = new ChartValues<double> { 4, 5, 3, 8, 6 }
                    }
                };

                var chart = new CartesianChart
                {
                    Series = series,
                    // Set some basic configurations for the chart.
                    AxisX = new Axis
                    {
                        Title = "X Axis",
                        Labels = new List<string> { "Jan