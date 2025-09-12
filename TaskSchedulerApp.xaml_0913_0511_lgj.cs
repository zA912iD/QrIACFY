// 代码生成时间: 2025-09-13 05:11:18
// Required namespaces
using System;
using System.Threading;
using System.Windows;
using System.Windows.Threading;

namespace TaskSchedulerApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private DispatcherTimer dispatcherTimer;
        private DateTime nextExecutionTime;
        private Action scheduledTask;

        public MainWindow()
        {
            InitializeComponent();
            InitializeTimer();
        }

        /// <summary>
        /// Initialize the dispatcher timer and set the initial time.
        /// </summary>
        private void InitializeTimer()
        {
            dispatcherTimer = new DispatcherTimer();
            dispatcherTimer.Tick += DispatcherTimer_Tick;
            dispatcherTimer.Interval = TimeSpan.FromSeconds(1); // Set timer interval to 1 second
            dispatcherTimer.Start();

            // Set the next execution time to now
            nextExecutionTime = DateTime.Now;
        }

        /// <summary>
        /// Event handler for the dispatcher timer tick.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The event arguments.</param>
        private void DispatcherTimer_Tick(object sender, EventArgs e)
        {
            if (DateTime.Now >= nextExecutionTime && scheduledTask != null)
            {
                try
                {
                    // Execute the scheduled task
                    scheduledTask();
                }
                catch (Exception ex)
                {
                    // Handle any error that occurs during task execution
                    MessageBox.Show($"Error executing task: {ex.Message}");
                }
            }
        }

        /// <summary>
        /// Schedule a task to be executed at a specific time.
        /// </summary>
        /// <param name="task">The task to be executed.</param>
        /// <param name="executionTime">The time at which the task should be executed.</param>
        public void ScheduleTask(Action task, DateTime executionTime)
        {
            if (task == null) throw new ArgumentNullException(nameof(task));
            if (executionTime < DateTime.Now) throw new ArgumentException("Execution time must be in the future.");

            scheduledTask = task;
            nextExecutionTime = executionTime;
        }

        /// <summary>
        /// Cancels any scheduled tasks.
        /// </summary>
        public void CancelScheduledTask()
        {
            scheduledTask = null;
            nextExecutionTime = DateTime.MinValue;
        }
    }
}
