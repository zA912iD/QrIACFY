// 代码生成时间: 2025-09-16 07:34:11
using System;
using System.IO;
using System.Text;
using System.Windows;

namespace ErrorLogCollectorApp
{
    /// <summary>
    /// Interaction logic for ErrorLogCollectorApp.xaml
    /// </summary>
    public partial class ErrorLogCollectorApp : Window
    {
        private const string LogFilePath = ".\error_log.txt";

        public ErrorLogCollectorApp()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Captures the unhandled exceptions and logs them to a file.
        /// </summary>
        private void AppDomain_CurrentDomain_UnhandledException(object sender, UnhandledExceptionEventArgs e)
        {
            Exception ex = (Exception)e.ExceptionObject;
            string logMessage = $"Date: {DateTime.Now} - Exception: {ex.Message}
Stack Trace: {ex.StackTrace}";
            LogError(logMessage);
        }

        /// <summary>
        /// Writes the error message to the log file.
        /// </summary>
        /// <param name="errorMessage">The error message to log.</param>
        private void LogError(string errorMessage)
        {
            try
            {
                using (StreamWriter writer = new StreamWriter(LogFilePath, true, Encoding.UTF8))
                {
                    writer.WriteLine(errorMessage);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Failed to write to log file: {ex.Message}");
            }
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            // Attach the event handler for unhandled exceptions
            AppDomain.CurrentDomain.UnhandledException += AppDomain_CurrentDomain_UnhandledException;
        }
    }
}