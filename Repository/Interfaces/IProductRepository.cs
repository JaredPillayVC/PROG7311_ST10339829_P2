﻿using PROG7311_ST10339829_P2.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Data;           
using Dapper;                  
using PROG7311_ST10339829_P2.Data;
using PROG7311_ST10339829_P2.Repository.Interfaces;


namespace PROG7311_ST10339829_P2.Repository.Interfaces
{
    public interface IProductRepository
    {
        Task<IEnumerable<Product>> GetProductsByFarmerAsync(int farmerId);
        Task<IEnumerable<ProductWithFarmer>> GetAllProductsAsync(
            int? farmerId, string? category, DateTime? fromDate, DateTime? toDate);
        Task<IEnumerable<string>> GetAllCategoriesAsync();

        Task AddProductAsync(Product product);
    }
}
