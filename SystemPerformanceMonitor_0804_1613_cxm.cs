// 代码生成时间: 2025-08-04 16:13:27
using System;
using System.Windows;
using System.Diagnostics;
using System.Threading;
using System.Windows.Threading;

// SystemPerformanceMonitor.xaml.cs is the code-behind for the WPF window
// It contains the implementation of the system performance monitoring tool.
public partial class SystemPerformanceMonitor : Window
{
    // Timer that will be used to update the system performance data
    private Timer performanceTimer;

    public SystemPerformanceMonitor()
    {
        InitializeComponent();
        InitializePerformanceTimer();
    }

    // Initialize the timer to update system performance data at a regular interval
    private void InitializePerformanceTimer()
    {
        performanceTimer = new Timer(UpdateSystemPerformanceData,
            null, 0, 1000); // Timer interval set to 1 second
    }

    // Method to update system performance data
    private void UpdateSystemPerformanceData(object state)
    {
        if (Dispatcher.CheckAccess())
        {
            // Update UI directly if on the UI thread
            UpdateUI(GetCurrentPerformanceData());
        }
        else
        {
            // Use the Dispatcher to update UI from a non-UI thread
            Dispatcher.Invoke(DispatcherPriority.Normal,
                new Action(() => UpdateUI(GetCurrentPerformanceData())));
        }
    }

    // Get current system performance data
    private PerformanceData GetCurrentPerformanceData()
    {
        PerformanceData data = new PerformanceData();
        data.CPUUsage = CalculateCpuUsage();
        data.MemoryUsage = CalculateMemoryUsage();
        return data;
    }

    // Calculate CPU usage
    private float CalculateCpuUsage()
    {
        float cpuUsage = 0;
        try
        {
            cpuUsage = Process.GetCurrentProcess().TotalProcessorTime.TotalSeconds /
                (Environment.ProcessorCount * TimeSpan.FromSeconds(1).TotalSeconds) * 100;
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error calculating CPU usage: " + ex.Message);
        }
        return cpuUsage;
    }

    // Calculate memory usage
    private float CalculateMemoryUsage()
    {
        float memoryUsage = 0;
        try
        {
            memoryUsage = (float)Process.GetCurrentProcess().WorkingSet64 /
                (float)(Environment.TotalPhysicalMemory / (1024 * 1024));
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error calculating memory usage: " + ex.Message);
        }
        return memoryUsage;
    }

    // Update the UI with the current system performance data
    private void UpdateUI(PerformanceData data)
    {
        // Update UI elements with the new data here
        // Example: CpuUsageLabel.Content = data.CPUUsage.ToString("N2") + "%";
        // Example: MemoryUsageLabel.Content = data.MemoryUsage.ToString("N2") + " MB";
    }

    // Nested class to hold system performance data
    private class PerformanceData
    {
        public float CPUUsage { get; set; }
        public float MemoryUsage { get; set; }
    }
}
