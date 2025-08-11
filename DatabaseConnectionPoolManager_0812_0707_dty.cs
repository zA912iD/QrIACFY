// 代码生成时间: 2025-08-12 07:07:49
using System;
using System.Collections.Concurrent;
using System.Data;
using System.Data.Common;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

// DatabaseConnectionPoolManager provides a pool of database connections for reusing.
public class DatabaseConnectionPoolManager
{
    private readonly ConcurrentBag<DbConnection> _connectionPool;
    private readonly string _connectionString;
    private readonly ILogger<DatabaseConnectionPoolManager> _logger;
    private readonly int _maxPoolSize;
    private readonly object _syncRoot = new object();
    private int _availableConnectionsCount;

    // Constructor for DatabaseConnectionPoolManager.
    public DatabaseConnectionPoolManager(IConfiguration configuration, ILogger<DatabaseConnectionPoolManager> logger)
    {
        _connectionPool = new ConcurrentBag<DbConnection>();
        _connectionString = configuration.GetConnectionString("DefaultConnection");
        _logger = logger;
        _maxPoolSize = int.Parse(configuration["MaxPoolSize"]);
        _availableConnectionsCount = 0;
    }

    // Get a database connection from the pool.
    public DbConnection GetConnection()
    {
        if (_connectionPool.TryTake(out var connection))
        {
            if (connection.State != ConnectionState.Open)
            {
                connection.Close();
                connection.Dispose();
            }
            else
            {
                return connection;
            }
        }

        // If no connection is available, create a new one.
        var newConnection = CreateNewConnection();
        return newConnection;
    }

    // Return a database connection to the pool.
    public void ReturnConnection(DbConnection connection)
    {
        if (connection != null && connection.State != ConnectionState.Closed)
        {
            connection.Close();
            if (_availableConnectionsCount < _maxPoolSize)
            {
                _connectionPool.Add(connection);
                _availableConnectionsCount++;
            }
            else
            {
                connection.Dispose();
            }
        }
    }

    // Creates a new database connection.
    private DbConnection CreateNewConnection()
    {
        try
        {
            var factory = DbProviderFactories.GetFactory("System.Data.SqlClient");
            var connection = factory.CreateConnection();
            connection.ConnectionString = _connectionString;
            connection.Open();
            _availableConnectionsCount++;
            return connection;
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Failed to create a new database connection.");
            throw;
        }
    }

    // Disposes of all connections in the pool.
    public void Dispose()
    {
        foreach (var connection in _connectionPool)
        {
            connection.Dispose();
        }
        _connectionPool.Clear();
    }
}
