// 代码生成时间: 2025-08-15 08:49:02
using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using LiveCharts;
using LiveCharts.Wpf;
using LiveCharts.Defaults;

namespace InteractiveChartGenerator
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

        private void GenerateChartButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                // Clear the existing chart series.
                MyChart.Series.Clear();

                // Create a new chart series with random data.
                var series = new LineSeries
                {
                    Title = "Random Data",
                    Values = new ChartValues<double> { 4, 4, 3.5, 4.9, 6, 7, 9, 1 }
                };

                // Add the series to the chart.
                MyChart.Series.Add(series);
            }
            catch (Exception ex)
            {
                // Handle any exceptions that occur during chart generation.
                MessageBox.Show($"Error generating chart: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}

// XAML for MainWindow.xaml
// <Window x:Class="InteractiveChartGenerator.MainWindow"
//         xmlns="http://schemas.microsoft.com/winfx/2006/xaml/presentation"
//         xmlns:x="http://schemas.microsoft.com/winfx/2006/xaml"
//         xmlns:local="clr-namespace:InteractiveChartGenerator"
//         Title="Interactive Chart Generator" Height="450" Width="800">
//     <Grid>
//         <Grid.RowDefinitions>
//             <RowDefinition Height="Auto"/>
//             <RowDefinition Height="*"/>
//         </Grid.RowDefinitions>
//         <Button Content="Generate Chart" Click="GenerateChartButton_Click" Grid.Row="0" HorizontalAlignment="Center" VerticalAlignment="Center"/>
//         <local:MyChart x:Name="MyChart" Grid.Row="1"/>
//     </Grid>
// </Window>