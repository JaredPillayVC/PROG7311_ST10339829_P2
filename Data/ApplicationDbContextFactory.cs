using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using PROG7311_ST10339829_P2.Data;

namespace PROG7311_ST10339829_P2.Data
{
    public class ApplicationDbContextFactory
        : IDesignTimeDbContextFactory<ApplicationDbContext>
    {
        public ApplicationDbContext CreateDbContext(string[] args)
        {
            var builder = new DbContextOptionsBuilder<ApplicationDbContext>();
            builder.UseSqlServer(
                "Data Source=.\\SQLEXPRESS;Initial Catalog=AgriEnergyConnect;Integrated Security=True;MultipleActiveResultSets=true"
            );

            return new ApplicationDbContext(builder.Options);
        }
    }
}
