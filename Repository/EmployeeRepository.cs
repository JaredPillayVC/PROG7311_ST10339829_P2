using Dapper;
using PROG7311_ST10339829_P2.Data;
using PROG7311_ST10339829_P2.Models;
using PROG7311_ST10339829_P2.Repository.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PROG7311_ST10339829_P2.Repository
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly DapperContext _context;
        public EmployeeRepository(DapperContext context) => _context = context;

        public async Task<IEnumerable<Employee>> GetAllEmployeesAsync()
        {
            using var con = _context.CreateConnection();
            return await con.QueryAsync<Employee>("SELECT * FROM Employees");
        }

        public async Task<Employee> GetEmployeeByUserIdAsync(string userId)
        {
            using var con = _context.CreateConnection();
            return await con.QuerySingleOrDefaultAsync<Employee>(
                "SELECT * FROM Employees WHERE UserId = @UserId",
                new { UserId = userId });
        }

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
