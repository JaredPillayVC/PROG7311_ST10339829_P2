using Dapper;
using PROG7311_ST10339829_P2.Data;
using PROG7311_ST10339829_P2.Models;
using PROG7311_ST10339829_P2.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PROG7311_ST10339829_P2.Repository
{
    /// <summary>
    /// Repository for managing product data using Dapper.
    /// </summary>
    public class ProductRepository : IProductRepository
    {
        private readonly DapperContext _context;
        /// <summary>
        /// Initializes a new instance of the <see cref="ProductRepository"/> class.
        /// </summary>
        /// <param name="context">The Dapper context for database access.</param>
        public ProductRepository(DapperContext context) => _context = context;

        /// <summary>
        /// Gets all products for a specific farmer.
        /// </summary>
        /// <param name="farmerId">The farmer's ID.</param>
        /// <returns>A collection of products.</returns>
        public async Task<IEnumerable<Product>> GetProductsByFarmerAsync(int farmerId)
        {
            using var con = _context.CreateConnection();
            // Query products by farmer ID
            return await con.QueryAsync<Product>(
                "SELECT * FROM Products WHERE FarmerId = @FarmerId",
                new { FarmerId = farmerId });
        }

        /// <summary>
        /// Gets all products with optional filtering and includes farmer details.
        /// </summary>
        /// <param name="farmerId">Optional farmer ID filter.</param>
        /// <param name="category">Optional category filter.</param>
        /// <param name="fromDate">Optional start date filter.</param>
        /// <param name="toDate">Optional end date filter.</param>
        /// <returns>A collection of products with farmer details.</returns>
        public async Task<IEnumerable<ProductWithFarmer>> GetAllProductsAsync(
            int? farmerId, string? category, DateTime? fromDate, DateTime? toDate)
        {
            using var con = _context.CreateConnection();
            // SQL query joins Products and Farmers for richer view model
            var sql = @"
SELECT 
  p.ProductId,
  p.Name,
  p.Category,
  p.ProductionDate,
  p.FarmerId,
  f.Name AS FarmerName
FROM Products p
JOIN Farmers f ON p.FarmerId = f.FarmerId
WHERE (@farmerId IS NULL OR p.FarmerId = @farmerId)
  AND (@category IS NULL OR p.Category = @category)
  AND (@fromDate  IS NULL OR p.ProductionDate >= @fromDate)
  AND (@toDate    IS NULL OR p.ProductionDate <= @toDate);";

            return await con.QueryAsync<ProductWithFarmer>(sql, new
            {
                farmerId,
                category,
                fromDate,
                toDate
            });
        }

        /// <summary>
        /// Gets all unique product categories.
        /// </summary>
        /// <returns>A collection of category names.</returns>
        public async Task<IEnumerable<string>> GetAllCategoriesAsync()
        {
            using var con = _context.CreateConnection();
            return await con.QueryAsync<string>(
                "SELECT DISTINCT Category FROM Products ORDER BY Category");
        }

        /// <summary>
        /// Adds a new product to the database.
        /// </summary>
        /// <param name="product">The product to add.</param>
        public async Task AddProductAsync(Product product)
        {
            using var con = _context.CreateConnection();
            var sql = @"
INSERT INTO Products (FarmerId, Name, Category, ProductionDate)
VALUES (@FarmerId, @Name, @Category, @ProductionDate);";

            await con.ExecuteAsync(sql, product);
        }
    }
}
