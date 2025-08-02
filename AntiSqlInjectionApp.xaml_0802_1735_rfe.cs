// 代码生成时间: 2025-08-02 17:35:49
using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows;

namespace AntiSqlInjectionApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private string connectionString = "Data Source=(local);Initial Catalog=YourDatabase;Integrated Security=True";

        public MainWindow()
        {
            InitializeComponent();
        }

        /// <summary>
        /// This method handles the button click event to demonstrate SQL query with parameterized queries.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The event arguments.</param>
        private void ExecuteQueryButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    string sqlQuery = "SELECT * FROM Users WHERE Username = @Username";
                    using (SqlCommand command = new SqlCommand(sqlQuery, connection))
                    {
                        command.Parameters.AddWithValue("@Username", "userInput"); // Using parameterized queries to prevent SQL injection

                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                // Process the data from the database
                                Console.WriteLine("User Data: " + reader["Username"] + " " + reader["Password"]);
                            }
                        }
                    }
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show("SQL Exception: " + ex.Message);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Exception: " + ex.Message);
            }
        }
    }
}