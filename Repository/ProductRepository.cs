// Repository/ProductRepository.cs
using Dapper;
using PROG7311_ST10339829_P2.Data;
using PROG7311_ST10339829_P2.Models;
using PROG7311_ST10339829_P2.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PROG7311_ST10339829_P2.Repository
{
    public class ProductRepository : IProductRepository
    {
        private readonly DapperContext _context;
        public ProductRepository(DapperContext context) => _context = context;

        public async Task<IEnumerable<Product>> GetProductsByFarmerAsync(int farmerId)
        {
            using var con = _context.CreateConnection();
            return await con.QueryAsync<Product>(
                "SELECT * FROM Products WHERE FarmerId = @FarmerId",
                new { FarmerId = farmerId });
        }

        public async Task<IEnumerable<Product>> GetAllProductsAsync(string category, DateTime? fromDate, DateTime? toDate)
        {
            using var con = _context.CreateConnection();
            var sql = @"
                SELECT p.*, f.Name AS FarmerName
                  FROM Products p
                  JOIN Farmers f ON p.FarmerId = f.FarmerId
                 WHERE (@category IS NULL OR p.Category = @category)
                   AND (@fromDate IS NULL OR p.ProductionDate >= @fromDate)
                   AND (@toDate IS NULL OR p.ProductionDate <= @toDate)";
            return await con.QueryAsync<Product>(sql, new { category, fromDate, toDate });
        }

        public async Task AddProductAsync(Product product)
        {
            using var con = _context.CreateConnection();
            var sql = @"
                INSERT INTO Products (FarmerId, Name, Category, ProductionDate)
                VALUES (@FarmerId, @Name, @Category, @ProductionDate)";
            await con.ExecuteAsync(sql, product);
        }
    }
}
