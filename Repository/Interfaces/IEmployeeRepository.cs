using PROG7311_ST10339829_P2.Models;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Data;            
using PROG7311_ST10339829_P2.Data;
using PROG7311_ST10339829_P2.Repository.Interfaces;


namespace PROG7311_ST10339829_P2.Repository.Interfaces
{
    public interface IEmployeeRepository
    {
        Task<IEnumerable<Employee>> GetAllEmployeesAsync();
        Task<Employee> GetEmployeeByUserIdAsync(string userId);
        Task AddEmployeeAsync(Employee employee);
    }
}
