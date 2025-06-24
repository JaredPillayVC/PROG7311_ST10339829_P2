using Dapper;
using PROG7311_ST10339829_P2.Data;
using PROG7311_ST10339829_P2.Models;
using PROG7311_ST10339829_P2.Repository.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PROG7311_ST10339829_P2.Repository
{
    /// <summary>
    /// Repository for managing farmer data using Dapper.
    /// </summary>
    public class FarmerRepository : IFarmerRepository
    {
        private readonly DapperContext _context;
        /// <summary>
        /// Initializes a new instance of the <see cref="FarmerRepository"/> class.
        /// </summary>
        /// <param name="context">The Dapper context for database access.</param>
        public FarmerRepository(DapperContext context) => _context = context;

        /// <summary>
        /// Gets all farmers from the database.
        /// </summary>
        /// <returns>A collection of farmers.</returns>
        public async Task<IEnumerable<Farmer>> GetAllFarmersAsync()
        {
            using var con = _context.CreateConnection();
            return await con.QueryAsync<Farmer>("SELECT * FROM Farmers");
        }

        /// <summary>
        /// Gets a farmer by their ID.
        /// </summary>
        /// <param name="id">The farmer's ID.</param>
        /// <returns>The farmer entity or null if not found.</returns>
        public async Task<Farmer> GetFarmerByIdAsync(int id)
        {
            using var con = _context.CreateConnection();
            return await con.QuerySingleOrDefaultAsync<Farmer>(
                "SELECT * FROM Farmers WHERE FarmerId = @Id",
                new { Id = id });
        }

        /// <summary>
        /// Adds a new farmer to the database.
        /// </summary>
        /// <param name="farmer">The farmer to add.</param>
        public async Task AddFarmerAsync(Farmer farmer)
        {
            using var con = _context.CreateConnection();
            var sql = "INSERT INTO Farmers (Name, Contact, Location) VALUES (@Name, @Contact, @Location)";
            await con.ExecuteAsync(sql, farmer);
        }
    }
}
