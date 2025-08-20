// 代码生成时间: 2025-08-21 03:29:16
using System;
using System.Data.SqlClient;
using System.IO;
using System.Windows;
using System.Windows.Controls;

namespace DatabaseMigrationTool
{
    // MainWindow.xaml.cs 是WPF应用程序的主窗口代码文件
    public partial class MainWindow : Window
    {
        // 构造函数
        public MainWindow()
        {
            InitializeComponent();
        }

        // 按钮点击事件处理程序，用于执行迁移操作
        private async void MigrateButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                // 获取用户输入的源数据库和目标数据库连接字符串
                string sourceConnectionString = SourceConnectionStringTextBox.Text;
                string targetConnectionString = TargetConnectionStringTextBox.Text;

                // 创建数据库迁移服务实例
                DatabaseMigrationService migrationService = new DatabaseMigrationService();

                // 执行迁移操作
                await migrationService.MigrateAsync(sourceConnectionString, targetConnectionString);

                // 显示迁移成功的信息
                MessageBox.Show("Migration completed successfully!", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            catch (SqlException ex)
            {
                // 处理数据库相关的异常
                MessageBox.Show($"Database operation failed: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            catch (Exception ex)
            {
                // 处理其他类型的异常
                MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }

    // DatabaseMigrationService.cs 是数据库迁移服务的代码文件
    public class DatabaseMigrationService
    {
        // 异步方法，用于执行数据库迁移操作
        public async Task MigrateAsync(string sourceConnectionString, string targetConnectionString)
        {
            // 打开源数据库连接
            using (SqlConnection sourceConnection = new SqlConnection(sourceConnectionString))
            {
                // 打开目标数据库连接
                using (SqlConnection targetConnection = new SqlConnection(targetConnectionString))
                {
                    // 打开源数据库命令
                    using (SqlCommand sourceCommand = new SqlCommand())
                    {
                        // 设置源数据库游标，获取所有数据
                        sourceCommand.CommandText = "SELECT * FROM [YourTable]";
                        sourceCommand.Connection = sourceConnection;

                        // 打开目标数据库命令
                        using (SqlCommand targetCommand = new SqlCommand())
                        {
                            // 设置目标数据库游标，插入数据
                            targetCommand.CommandText = "INSERT INTO [YourTable] ([Column1], [Column2]) VALUES (@value1, @value2)";
                            targetCommand.Connection = targetConnection;

                            // 打开数据读取器
                            using (SqlDataReader reader = await sourceCommand.ExecuteReaderAsync())
                            {
                                // 准备目标数据库的参数
                                SqlParameter[] parameters = targetCommand.Parameters.Cast<SqlParameter>().ToArray();

                                // 循环读取源数据库数据，并插入到目标数据库
                                while (await reader.ReadAsync())
                                {
                                    // 设置参数值
                                    for (int i = 0; i < parameters.Length; i++)
                                    {
                                        parameters[i].Value = reader.GetValue(i);
                                    }

                                    // 执行插入操作
                                    await targetCommand.ExecuteNonQueryAsync();
                                }
                            }
                        }
                    }
                }
            }
        }
    }
}
