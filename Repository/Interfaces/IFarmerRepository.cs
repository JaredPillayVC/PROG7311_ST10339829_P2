using PROG7311_ST10339829_P2.Models;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Data;            
using Dapper;                  
using PROG7311_ST10339829_P2.Data;
using PROG7311_ST10339829_P2.Repository.Interfaces;


namespace PROG7311_ST10339829_P2.Repository.Interfaces
{
    public interface IFarmerRepository
    {
        Task<IEnumerable<Farmer>> GetAllFarmersAsync();
        Task<Farmer> GetFarmerByIdAsync(int id);
        Task AddFarmerAsync(Farmer farmer);
    }
}
