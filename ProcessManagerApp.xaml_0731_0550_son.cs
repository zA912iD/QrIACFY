// 代码生成时间: 2025-07-31 05:50:39
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Windows;
using System.Windows.Controls;

namespace WpfProcessManager
{
    // MainWindow.xaml 的交互逻辑
    public partial class MainWindow : Window
    {
        private readonly Process[] _processes;
        private readonly List<ProcessInfo> _processList;

        public MainWindow()
        {
            InitializeComponent();
            _processList = new List<ProcessInfo>();
            _processes = Process.GetProcesses();
            RefreshProcessList();
        }

        // 刷新进程列表
        private void RefreshProcessList()
        {
            try
            {
                lstProcesses.Items.Clear();
                foreach (var process in _processes)
                {
                    var processInfo = new ProcessInfo
                    {
                        Id = process.Id,
                        Name = process.ProcessName,
                        StartTime = process.StartTime
                    };
                    _processList.Add(processInfo);
                    lstProcesses.Items.Add(processInfo);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error refreshing process list: {ex.Message}");
            }
        }

        // 单击“刷新”按钮时调用此方法
        private void btnRefresh_Click(object sender, RoutedEventArgs e)
        {
            RefreshProcessList();
        }

        // 单击“结束进程”按钮时调用此方法
        private void btnKillProcess_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (lstProcesses.SelectedItem is ProcessInfo processInfo)
                {
                    Process process = Process.GetProcessById(processInfo.Id);
                    process.Kill();
                    MessageBox.Show($"Process {processInfo.Name} with ID {processInfo.Id} has been terminated.");
                    RefreshProcessList();
                }
                else
                {
                    MessageBox.Show("Please select a process to terminate.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error terminating process: {ex.Message}");
            }
        }

        // 定义进程信息类
        private class ProcessInfo : IComparable<ProcessInfo>
        {
            public int Id { get; set; }
            public string Name { get; set; }
            public DateTime StartTime { get; set; }

            public int CompareTo(ProcessInfo other)
            {
                return Id.CompareTo(other.Id);
            }
        }
    }
}
