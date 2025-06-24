using System.Data;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;

namespace PROG7311_ST10339829_P2.Data
{
    /// <summary>
    /// Provides a Dapper context for database connections.
    /// </summary>
    public class DapperContext
    {
        private readonly IConfiguration _configuration;
        private readonly string _connectionString;

        /// <summary>
        /// Initializes a new instance of the <see cref="DapperContext"/> class.
        /// </summary>
        /// <param name="configuration">The application configuration.</param>
        public DapperContext(IConfiguration configuration)
        {
            _configuration = configuration;
            _connectionString = _configuration.GetConnectionString("DefaultConnection");
        }

        /// <summary>
        /// Creates and returns a new SQL database connection.
        /// </summary>
        /// <returns>An open IDbConnection.</returns>
        public IDbConnection CreateConnection()
            => new SqlConnection(_connectionString);
    }
}
