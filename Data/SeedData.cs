// Data/SeedData.cs
using System;
using System.Threading.Tasks;
using Dapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using PROG7311_ST10339829_P2.Models;

namespace PROG7311_ST10339829_P2.Data
{
    public static class SeedData
    {
        public static async Task InitializeAsync(IServiceProvider services)
        {
            var roleManager = services.GetRequiredService<RoleManager<IdentityRole>>();
            var userManager = services.GetRequiredService<UserManager<ApplicationUser>>();
            var dapper = services.GetRequiredService<DapperContext>();

            string[] roles = { "Farmer", "Employee" };
            foreach (var role in roles)
            {
                if (!await roleManager.RoleExistsAsync(role))
                    await roleManager.CreateAsync(new IdentityRole(role));
            }

            const string farmerEmail = "farmer@agri.com";
            var farmerUser = await userManager.FindByEmailAsync(farmerEmail);
            if (farmerUser == null)
            {
                farmerUser = new ApplicationUser
                {
                    UserName = farmerEmail,
                    Email = farmerEmail,
                    EmailConfirmed = true
                };
                await userManager.CreateAsync(farmerUser, "Farmer123!");
                await userManager.AddToRoleAsync(farmerUser, "Farmer");
            }

            if (farmerUser.FarmerId == null || farmerUser.FarmerId == 0)
            {
                using var conn = dapper.CreateConnection();
                var sql = @"
INSERT INTO Farmers (Name, Contact, Location)
VALUES (@Name, @Contact, @Location);
SELECT CAST(SCOPE_IDENTITY() AS INT);";
                var newFarmerId = await conn.QuerySingleAsync<int>(sql, new
                {
                    Name = "Seeded Farmer",
                    Contact = farmerEmail,
                    Location = "Seedville"
                });

                farmerUser.FarmerId = newFarmerId;
                await userManager.UpdateAsync(farmerUser);
            }

            const string employeeEmail = "employee@agri.com";
            var employeeUser = await userManager.FindByEmailAsync(employeeEmail);
            if (employeeUser == null)
            {
                employeeUser = new ApplicationUser
                {
                    UserName = employeeEmail,
                    Email = employeeEmail,
                    EmailConfirmed = true
                };
                await userManager.CreateAsync(employeeUser, "Employee123!");
                await userManager.AddToRoleAsync(employeeUser, "Employee");
            }

            
            if (employeeUser.EmployeeId == null || employeeUser.EmployeeId == 0)
            {
                using var conn = dapper.CreateConnection();
                var sqlEmp = @"
INSERT INTO Employees (UserId, FullName, ContactNumber, Department)
VALUES (@UserId, @FullName, @ContactNumber, @Department);
SELECT CAST(SCOPE_IDENTITY() AS INT);";
                var newEmployeeId = await conn.QuerySingleAsync<int>(sqlEmp, new
                {
                    UserId = employeeUser.Id,
                    FullName = "Seeded Employee",
                    ContactNumber = "012-345-6789",
                    Department = "Operations"
                });

                employeeUser.EmployeeId = newEmployeeId;
                await userManager.UpdateAsync(employeeUser);
            }
        }
    }
}
