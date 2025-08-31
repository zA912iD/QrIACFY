// 代码生成时间: 2025-09-01 03:22:03
using System;
using System.Windows;
using OxyPlot;
using OxyPlot.Series;
using OxyPlot.Wpf;

namespace InteractiveChartGenerator
{
    public partial class MainWindow : Window
    {
        private PlotModel plotModel;

        public MainWindow()
        {
            InitializeComponent();
            InitializePlotModel();
        }

        private void InitializePlotModel()
        {
            plotModel = new PlotModel
            {
                Title = "Interactive Chart Generator"
            };

            // Initialize series
            LineSeries lineSeries = new LineSeries();
            plotModel.Series.Add(lineSeries);

            // Data binding
            DataContext = plotModel;
        }

        private void AddDataPointButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                // Get input from user
                string xInput = XInputTextBox.Text;
                string yInput = YInputTextBox.Text;

                // Convert input to double
                double x = double.Parse(xInput);
                double y = double.Parse(yInput);

                // Add data point to series
                plotModel.Series[0].Points.Add(new DataPoint(x, y));
            }
            catch (Exception ex)
            {
                MessageBox.Show("Invalid input. Please enter valid numbers.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                Console.WriteLine(ex.Message);
            }
        }
    }
}
