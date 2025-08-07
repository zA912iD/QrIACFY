// 代码生成时间: 2025-08-08 05:54:54
using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Threading;

// SystemPerformanceMonitor.xaml.cs 是WPF应用程序的后台代码，用于实现系统性能监控工具
public partial class SystemPerformanceMonitor : Window
{
    // 定时器，用于定时更新性能数据
    private DispatcherTimer performanceTimer;

    // 构造函数，初始化WPF窗口和定时器
    public SystemPerformanceMonitor()
    {
        InitializeComponent();
        InitializePerformanceTimer();
    }

    // 初始化定时器，设置间隔为1秒
    private void InitializePerformanceTimer()
    {
        performanceTimer = new DispatcherTimer();
        performanceTimer.Tick += new EventHandler(PerformanceTimer_Tick);
        performanceTimer.Interval = TimeSpan.FromSeconds(1);
        performanceTimer.Start();
    }

    // 定时器事件处理程序，用于更新性能数据
    private void PerformanceTimer_Tick(object sender, EventArgs e)
    {
        try
        {
            // 获取CPU使用率
            float cpuUsage = GetCpuUsage();
            // 获取内存使用情况
            float memoryUsage = GetMemoryUsage();

            // 更新UI元素
            Dispatcher.Invoke(() =>
            {
                CpuUsageLabel.Content = $"CPU Usage: {cpuUsage}%";
                MemoryUsageLabel.Content = $"Memory Usage: {memoryUsage}%";
            });
        }
        catch (Exception ex)
        {
            // 错误处理
            MessageBox.Show($"Error: {ex.Message}");
        }
    }

    // 获取CPU使用率
    private float GetCpuUsage()
    {
        float cpuUsage = 0;
        using (var cpuCounter = new PerformanceCounter("Processor", "% Processor Time", "_Total"))
        {
            cpuUsage = (float)cpuCounter.NextValue();
        }
        return cpuUsage;
    }

    // 获取内存使用率
    private float GetMemoryUsage()
    {
        float memoryUsage = 0;
        using (var memoryCounter = new PerformanceCounter("Memory", "% Committed Bytes In Use"))
        {
            memoryUsage = (float)memoryCounter.NextValue();
        }
        return memoryUsage;
    }
}

// XAML代码位于SystemPerformanceMonitor.xaml文件中，包含UI元素如标签显示CPU和内存使用率
// 这里不包含XAML代码，因为它是WPF界面设计的标记语言，不是C#代码。