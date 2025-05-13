using System;
using System.Threading.Tasks;
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

            // 1) Ensure roles exist
            string[] roles = new[] { "Farmer", "Employee" };
            foreach (var role in roles)
            {
                if (!await roleManager.RoleExistsAsync(role))
                    await roleManager.CreateAsync(new IdentityRole(role));
            }

            // 2) Seed a test Farmer user
            var farmerEmail = "farmer@agri.com";
            if (await userManager.FindByEmailAsync(farmerEmail) == null)
            {
                var farmerUser = new ApplicationUser
                {
                    UserName = farmerEmail,
                    Email = farmerEmail,
                    EmailConfirmed = true
                };
                await userManager.CreateAsync(farmerUser, "Farmer123!");
                await userManager.AddToRoleAsync(farmerUser, "Farmer");
            }

            // 3) Seed a test Employee user
            var employeeEmail = "employee@agri.com";
            if (await userManager.FindByEmailAsync(employeeEmail) == null)
            {
                var employeeUser = new ApplicationUser
                {
                    UserName = employeeEmail,
                    Email = employeeEmail,
                    EmailConfirmed = true
                };
                await userManager.CreateAsync(employeeUser, "Employee123!");
                await userManager.AddToRoleAsync(employeeUser, "Employee");
            }
        }
    }
}

