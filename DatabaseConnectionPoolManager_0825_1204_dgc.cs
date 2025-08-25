// 代码生成时间: 2025-08-25 12:04:28
 * Features:
 * - Connection Pool Initialization
 * - Connection Retrieval and Release
 * - Error Handling
 * - Thread Safety
 *
 */
using System;
using System.Collections.Concurrent;
using System.Data.Common;
using System.Data.SqlClient;

namespace ConnectionPoolDemo
{
    public class DatabaseConnectionPoolManager
    {
        // The pool of connections
        private ConcurrentBag<DbConnection> connectionPool;
        private readonly string connectionString;
        private readonly int poolSize;

        // Lock object for thread safety
        private readonly object lockObject = new object();

        public DatabaseConnectionPoolManager(string connectionString, int poolSize)
        {
            this.connectionString = connectionString;
            this.poolSize = poolSize;
            this.connectionPool = new ConcurrentBag<DbConnection>();

            // Initialize the connection pool
            InitializePool();
        }

        // Initialize the connection pool with the specified size
        private void InitializePool()
        {
            if (string.IsNullOrEmpty(connectionString))
            {
                throw new ArgumentException("Connection string cannot be null or empty.");
            }

            for (int i = 0; i < poolSize; i++)
            {
                DbConnection connection = new SqlConnection(connectionString);
                connection.Open();
                connectionPool.Add(connection);
            }
        }

        // Retrieve a connection from the pool
        public DbConnection GetConnection()
        {
            if (connectionPool.Count == 0)
            {
                throw new InvalidOperationException("No available connections in the pool.");
            }

            // Try to retrieve a connection from the pool
            return connectionPool.Take();
        }

        // Release a connection back to the pool
        public void ReleaseConnection(DbConnection connection)
        {
            if (connection == null)
            {
                throw new ArgumentNullException("Connection cannot be null.");
            }

            // Ensure the connection is closed before returning it to the pool
            connection.Close();
            connectionPool.Add(connection);
        }
    }
}
