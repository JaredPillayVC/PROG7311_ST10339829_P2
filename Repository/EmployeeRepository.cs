using Dapper;
using PROG7311_ST10339829_P2.Data;
using PROG7311_ST10339829_P2.Models;
using PROG7311_ST10339829_P2.Repository.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PROG7311_ST10339829_P2.Repository
{
    /// <summary>
    /// Repository for managing employee data using Dapper.
    /// </summary>
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly DapperContext _context;
        /// <summary>
        /// Initializes a new instance of the <see cref="EmployeeRepository"/> class.
        /// </summary>
        /// <param name="context">The Dapper context for database access.</param>
        public EmployeeRepository(DapperContext context) => _context = context;

        /// <summary>
        /// Gets all employees from the database.
        /// </summary>
        /// <returns>A collection of employees.</returns>
        public async Task<IEnumerable<Employee>> GetAllEmployeesAsync()
        {
            using var con = _context.CreateConnection();
            return await con.QueryAsync<Employee>("SELECT * FROM Employees");
        }

        /// <summary>
        /// Gets an employee by their user ID.
        /// </summary>
        /// <param name="userId">The user's ID.</param>
        /// <returns>The employee entity or null if not found.</returns>
        public async Task<Employee> GetEmployeeByUserIdAsync(string userId)
        {
            using var con = _context.CreateConnection();
            return await con.QuerySingleOrDefaultAsync<Employee>(
                "SELECT * FROM Employees WHERE UserId = @UserId",
                new { UserId = userId });
        }

        /// <summary>
        /// Adds a new employee to the database.
        /// </summary>
        /// <param name="employee">The employee to add.</param>
        public async Task AddEmployeeAsync(Employee employee)
        {
            using var con = _context.CreateConnection();
            var sql = @"
                INSERT INTO Employees (UserId, FullName, ContactNumber, Department)
                VALUES (@UserId, @FullName, @ContactNumber, @Department)";
            await con.ExecuteAsync(sql, employee);
        }
    }
}
