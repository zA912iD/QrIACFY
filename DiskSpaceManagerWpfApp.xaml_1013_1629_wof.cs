// 代码生成时间: 2025-10-13 16:29:45
using System;
using System.IO;
using System.Windows;

namespace DiskSpaceManagerWpfApp
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        // 加载窗口时调用，获取磁盘空间信息并更新UI
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            try
            {
                RefreshDiskSpaceInfo();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}");
            }
        }

        // 获取磁盘空间信息并更新UI
        private void RefreshDiskSpaceInfo()
        {
            var drives = DriveInfo.GetDrives();
            foreach (var drive in drives)
            {
                // 过滤掉网络驱动器和不可读驱动器
                if (drive.DriveType == DriveType.Fixed && drive.IsReady)
                {
                    var freeSpace = drive.AvailableFreeSpace;
                    var usedSpace = drive.TotalSize - freeSpace;
                    var totalSpace = drive.TotalSize;

                    // 将磁盘空间信息添加到UI控件中，例如ListBox
                    // 这里需要根据实际的UI布局来实现
                    // Example: diskInfoListBox.Items.Add($"Drive: {drive.Name}, Free: {freeSpace}, Used: {usedSpace}, Total: {totalSpace}");
                }
            }
        }
    }
}