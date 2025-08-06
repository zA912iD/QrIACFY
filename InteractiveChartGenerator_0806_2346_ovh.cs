// 代码生成时间: 2025-08-06 23:46:34
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
        }

        private void GenerateChart(object sender, RoutedEventArgs e)
        {
            try
            {
                // 清除现有的图表数据
                var chart = (CartesianChart)sender;
                chart.Series.Clear();
                
                // 创建新的图表系列
                var series = new LineSeries
                {
                    Title = "Sample Data",
                    Values = new ChartValues<double> { 4, 5, 3, 8, 6, 2, 7, 4 }
                };
                
                // 将系列添加到图表中
                chart.Series.Add(series);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error generating chart: {ex.Message}", "Error");
            }
        }
    }
}

// XAML code for MainWindow.xaml
//<Window x:Class="InteractiveChartGenerator.MainWindow"
//        xmlns="http://schemas.microsoft.com/winfx/2006/xaml/presentation"
//        xmlns:x="http://schemas.microsoft.com/winfx/2006/xaml"
//        xmlns:local="clr-namespace:InteractiveChartGenerator"
//        Title="Interactive Chart Generator" Height="450" Width="800">
//    <Grid>
//        <CartesianChart Name="Chart"
//                       Width="600" Height="400"
//                       Margin="20"
//                       HorizontalAlignment="Center"
//                       VerticalAlignment="Top"
//                       MouseLeftButtonPressed="GenerateChart" />
//    </Grid>
//</Window>