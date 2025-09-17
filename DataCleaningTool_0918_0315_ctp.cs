// 代码生成时间: 2025-09-18 03:15:58
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows;

// 数据清洗和预处理工具
public partial class DataCleaningTool : Window
{
    // 构造函数
    public DataCleaningTool()
    {
        InitializeComponent();
    }

    // 读取文件方法
    private void LoadFile_Click(object sender, RoutedEventArgs e)
    {
        try
        {
            using (var openFileDialog = new Microsoft.Win32.OpenFileDialog())
            {
                // 设置过滤器
                openFileDialog.Filter = "Text Files (*.txt)|*.txt|CSV Files (*.csv)|*.csv|All Files (*.*)|*.*";

                // 显示打开文件对话框
                if (openFileDialog.ShowDialog() == true)
                {
                    // 获取文件路径
                    string filePath = openFileDialog.FileName;

                    // 读取文件内容
                    string fileContent = File.ReadAllText(filePath);

                    // 显示文件内容
                    FileContentTextBox.Text = fileContent;
                }
            }
        }
        catch (Exception ex)
        {
            // 错误处理
            MessageBox.Show($"Error loading file: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
        }
    }

    // 清洗数据方法
    private void CleanData_Click(object sender, RoutedEventArgs e)
    {
        try
        {
            // 获取文本框中的文件内容
            string fileContent = FileContentTextBox.Text;

            // 使用正则表达式清洗数据
            string cleanData = Regex.Replace(fileContent, @"[^\w\s,.;:-]+", "").Trim();

            // 显示清洗后的数据
            CleanedDataTextBox.Text = cleanData;
        }
        catch (Exception ex)
        {
            // 错误处理
            MessageBox.Show($"Error cleaning data: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
        }
    }

    // 保存文件方法
    private void SaveFile_Click(object sender, RoutedEventArgs e)
    {
        try
        {
            using (var saveFileDialog = new Microsoft.Win32.SaveFileDialog())
            {
                // 设置过滤器
                saveFileDialog.Filter = "Text Files (*.txt)|*.txt|CSV Files (*.csv)|*.csv|All Files (*.*)|*.*";

                // 显示保存文件对话框
                if (saveFileDialog.ShowDialog() == true)
                {
                    // 获取文件路径
                    string filePath = saveFileDialog.FileName;

                    // 保存数据到文件
                    File.WriteAllText(filePath, CleanedDataTextBox.Text);
                }
            }
        }
        catch (Exception ex)
        {
            // 错误处理
            MessageBox.Show($"Error saving file: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
        }
    }
}

// XAML 代码
// <Window x:Class="DataCleaningTool.DataCleaningTool"
//         xmlns="http://schemas.microsoft.com/winfx/2006/xaml/presentation"
//         xmlns:x="http://schemas.microsoft.com/winfx/2006/xaml"
//         Title="Data Cleaning Tool" Height="450" Width="800">
//     <Grid>
//         <TextBox x:Name="FileContentTextBox" Height="200" Margin="10,10,10,0" TextWrapping="Wrap" VerticalScrollBarVisibility="Auto"/>
//         <Button x:Name="LoadFileButton" Content="Load File" Margin="10" VerticalAlignment="Top" Click="LoadFile_Click"/>
//         <Button x:Name="CleanDataButton" Content="Clean Data" Margin="10" VerticalAlignment="Top" Click="CleanData_Click"/>
//         <Button x:Name="SaveFileButton" Content="Save File" Margin="10" VerticalAlignment="Top" Click="SaveFile_Click"/>
//         <TextBox x:Name="CleanedDataTextBox" Height="200" Margin="10,10,10,0" TextWrapping="Wrap" VerticalScrollBarVisibility="Auto"/>
//     </Grid>
// </Window>