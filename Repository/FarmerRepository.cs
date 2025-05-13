using Dapper;
using PROG7311_ST10339829_P2.Data;
using PROG7311_ST10339829_P2.Models;
using PROG7311_ST10339829_P2.Repository.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PROG7311_ST10339829_P2.Repository
{
    public class FarmerRepository : IFarmerRepository
    {
        private readonly DapperContext _context;
        public FarmerRepository(DapperContext context) => _context = context;

        public async Task<IEnumerable<Farmer>> GetAllFarmersAsync()
        {
            using var con = _context.CreateConnection();
            return await con.QueryAsync<Farmer>("SELECT * FROM Farmers");
        }

        public async Task<Farmer> GetFarmerByIdAsync(int id)
        {
            using var con = _context.CreateConnection();
            return await con.QuerySingleOrDefaultAsync<Farmer>(
                "SELECT * FROM Farmers WHERE FarmerId = @Id",
                new { Id = id });
        }

        public async Task AddFarmerAsync(Farmer farmer)
        {
            using var con = _context.CreateConnection();
            var sql = "INSERT INTO Farmers (Name, Contact, Location) VALUES (@Name, @Contact, @Location)";
            await con.ExecuteAsync(sql, farmer);
        }
    }
}
