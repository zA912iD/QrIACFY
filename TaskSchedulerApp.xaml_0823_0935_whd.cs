// 代码生成时间: 2025-08-23 09:35:45
 * Description:
 * This file contains the code for a simple WPF application that acts as a task scheduler.
 * It allows users to schedule tasks to run at specified times.
 *
 * Usage:
 * The application will display a user interface where users can input task details
 * and schedule them to run at a specific time. The application will handle the scheduling
 * and execution of these tasks.
 */

using System;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Windows;

namespace TaskSchedulerApp
{
    // Define the TaskModel to represent a scheduled task.
    public class TaskModel
    {
        public string TaskName { get; set; }
        public DateTime ScheduleTime { get; set; }
        public Action TaskAction { get; set; }
    }

    public partial class TaskSchedulerApp : Window
    {
        private ObservableCollection<TaskModel> scheduledTasks = new ObservableCollection<TaskModel>();
        private System.Timers.Timer timer;

        public TaskSchedulerApp()
        {
            InitializeComponent();
            InitializeTimer();
        }

        // Method to initialize the timer.
        private void InitializeTimer()
        {
            timer = new System.Timers.Timer();
            timer.Elapsed += OnTimerElapsed;
            timer.AutoReset = true;
        }

        // Event handler for the timer's Elapsed event.
        private void OnTimerElapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            DateTime now = DateTime.Now;
            foreach (var task in scheduledTasks)
            {
                if (task.ScheduleTime <= now)
                {
                    // Execute the task.
                    task.TaskAction?.Invoke();
                    // Remove the task from the collection after execution.
                    scheduledTasks.Remove(task);
                }
            }
        }

        // Method to schedule a new task.
        public void ScheduleTask(string taskName, DateTime scheduleTime, Action taskAction)
        {
            var task = new TaskModel
            {
                TaskName = taskName,
                ScheduleTime = scheduleTime,
                TaskAction = taskAction
            };
            scheduledTasks.Add(task);
        }

        // Example of scheduling a task to run after 5 seconds.
        private void ScheduleExampleTask()
        {
            ScheduleTask("Example Task", DateTime.Now.AddSeconds(5), () => MessageBox.Show("Task executed!"));
        }

        // Start the timer.
        private void StartScheduler()
        {
            timer.Interval = 1000; // Set the interval to 1 second.
            timer.Start();
        }

        // Stop the timer.
        private void StopScheduler()
        {
            timer.Stop();
        }
    }
}
