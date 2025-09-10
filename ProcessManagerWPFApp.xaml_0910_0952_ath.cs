// 代码生成时间: 2025-09-10 09:52:18
using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Controls;
using System.Collections.Generic;

namespace ProcessManagerApp
{
    // MainWindow.xaml 的代码部分
    public partial class MainWindow : Window
    {
        private List<Process> runningProcesses;

        public MainWindow()
        {
            InitializeComponent();
            runningProcesses = new List<Process>();
            RefreshProcessList();
        }

        // 刷新进程列表
        private void RefreshProcessList()
        {
            try
            {
                runningProcesses = new List<Process>(Process.GetProcesses());
                processDataGrid.ItemsSource = runningProcesses;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error while refreshing process list: {ex.Message}");
            }
        }

        // 启动进程
        private void StartProcessButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var processName = processNameTextBox.Text;
                if (string.IsNullOrEmpty(processName))
                {
                    MessageBox.Show("Please enter a process name.");
                    return;
                }

                Process.Start(processName);
                RefreshProcessList();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error while starting process: {ex.Message}");
            }
        }

        // 结束进程
        private void EndProcessButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var selectedProcess = (Process)processDataGrid.SelectedItem;
                if (selectedProcess == null)
                {
                    MessageBox.Show("Please select a process to end.");
                    return;
                }

                selectedProcess.Kill();
                RefreshProcessList();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error while ending process: {ex.Message}");
            }
        }
    }
}
