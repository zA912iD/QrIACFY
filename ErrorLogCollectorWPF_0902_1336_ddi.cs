// 代码生成时间: 2025-09-02 13:36:22
using System;
using System.IO;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Threading;

// ErrorLogCollectorWPF.xaml的代码后台
public partial class ErrorLogCollectorWPF : Window
{
    private readonly DispatcherTimer _errorLogTimer;
    private string _logFilePath;

    public ErrorLogCollectorWPF()
    {
        InitializeComponent();

        // 初始化定时器，用于定期写入错误日志
        _errorLogTimer = new DispatcherTimer { Interval = TimeSpan.FromSeconds(10) };
        _errorLogTimer.Tick += WriteErrorLogs;
        _errorLogTimer.Start();

        // 设置错误日志文件路径
        _logFilePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "ErrorLog.txt");
    }

    // 捕获未处理的异常
    protected override void OnContentRendered(EventArgs e)
    {
        base.OnContentRendered(e);

        Application.Current.DispatcherUnhandledException += OnDispatcherUnhandledException;
        AppDomain.CurrentDomain.UnhandledException += OnUnhandledException;
    }

    // 处理未处理的异常
    private void OnDispatcherUnhandledException(object sender, System.Windows.Threading.DispatcherUnhandledExceptionEventArgs e)
    {
        try
        {
            // 将异常信息写入日志文件
            LogError(e.Exception.Message);
        }
        catch (Exception ex)
        {
            // 如果日志记录失败，则尝试在控制台输出
            Console.WriteLine($"Error logging exception: {ex.Message}");
        }
        finally
        {
            // 防止程序崩溃
            e.Handled = true;
        }
    }

    // 处理未处理的异常
    private void OnUnhandledException(object sender, UnhandledExceptionEventArgs e)
    {
        try
        {
            // 将异常信息写入日志文件
            LogError(e.ExceptionObject?.ToString() ?? "Unknown exception");
        }
        catch (Exception ex)
        {
            // 如果日志记录失败，则尝试在控制台输出
            Console.WriteLine($"Error logging exception: {ex.Message}");
        }
    }

    // 定时写入错误日志到文件
    private void WriteErrorLogs(object sender, EventArgs e)
    {
        // 此处可以添加代码以决定何时写入日志文件
        // 例如，可以添加一个队列来存储日志条目，并在定时器事件中写入文件
    }

    // 将错误信息写入日志文件
    private void LogError(string errorMessage)
    {
        try
        {
            File.AppendAllText(_logFilePath, $"{DateTime.Now}: {errorMessage}
");
        }
        catch (Exception ex)
        {
            // 如果写入失败，尝试在控制台输出错误
            Console.WriteLine($"Error writing to log file: {ex.Message}");
        }
    }
}
