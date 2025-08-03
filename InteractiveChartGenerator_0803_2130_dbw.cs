// 代码生成时间: 2025-08-03 21:30:35
 * InteractiveChartGenerator.cs
 * 
 * 这是一个交互式图表生成器的CSHARP和WPF框架程序。
 * 它提供了一个简单的用户界面，用户可以通过选择不同的图表类型和数据点来生成图表。
 */
using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Collections.Generic;
using OxyPlot;
using OxyPlot.Series;
using System.Linq;

namespace InteractiveChartGenerator
{
    public partial class MainWindow : Window
    {
        // 存储图表的数据点
        private List<DataPoint> dataPoints = new List<DataPoint>();

        public MainWindow()
        {
            InitializeComponent();
            // 初始化图表控件
            InitializePlot();
        }

        // 初始化图表的方法
        private void InitializePlot()
        {
            var plot = new PlotModel { Title = "Interactive Chart Generator" };
            // 创建一个线性图表系列
            var lineSeries = new LineSeries { MarkerType = MarkerType.Circle };
            plot.Series.Add(lineSeries);
            // 绑定图表控件与模型
            plotView1.Model = plot;
        }

        // 添加数据点的方法
        private void AddDataPoint_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                // 获取用户输入的数据
                string xValue = xInput.Text;
                string yValue = yInput.Text;
                // 将输入转换为double类型
                double x = Convert.ToDouble(xValue);
                double y = Convert.ToDouble(yValue);
                // 创建新的数据点并添加到列表
                dataPoints.Add(new DataPoint(x, y));
                // 更新图表
                UpdatePlot();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        // 更新图表的方法
        private void UpdatePlot()
        {
            var lineSeries = (LineSeries)plotView1.Model.Series[0];
            lineSeries.Points.Clear();
            // 将数据点添加到图表系列中
            foreach (var point in dataPoints)
            {
                lineSeries.Points.Add(point);
            }
        }

        // 清除数据点的方法
        private void ClearDataPoints_Click(object sender, RoutedEventArgs e)
        {
            dataPoints.Clear();
            UpdatePlot();
        }

        // 更改图表类型的方法
        private void ChangeChartType_Click(object sender, RoutedEventArgs e)
        {
            // 根据用户选择更新图表类型
            var selectedType = chartTypeComboBox.SelectedItem.ToString();
            switch (selectedType)
            {
                case "Line":
                    InitializePlot();
                    break;
                // 可以根据需要添加更多的图表类型
                // case "Scatter":
                //     ScatterPlot();
                //     break;
                default:
                    MessageBox.Show("Unsupported chart type");
                    break;
            }
        }
    }
}
