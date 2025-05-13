using PROG7311_ST10339829_P2.Models;
using PROG7311_ST10339829_P2.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using PROG7311_ST10339829_P2.Repository.Interfaces;
using PROG7311_ST10339829_P2.Repository;

var builder = WebApplication.CreateBuilder(args);


AppContext.SetSwitch("System.Diagnostics.PerformanceCounter.UseNetCore", false);


builder.Services.AddDbContext<ApplicationDbContext>(opts =>
    opts.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));


builder.Services
    .AddDefaultIdentity<ApplicationUser>(options =>
    {
        options.SignIn.RequireConfirmedAccount = true;
        options.Password.RequiredLength = 8;
        options.Password.RequireDigit = true;
        options.User.RequireUniqueEmail = true;
    })
    .AddRoles<IdentityRole>()
    .AddEntityFrameworkStores<ApplicationDbContext>()
    .AddDefaultTokenProviders()
    .AddDefaultUI();


builder.Services.AddControllersWithViews();
builder.Services.AddRazorPages();
builder.Services.AddScoped<DapperContext>();
builder.Services.AddScoped<IFarmerRepository, FarmerRepository>();
builder.Services.AddScoped<IProductRepository, ProductRepository>();
builder.Services.AddScoped<IEmployeeRepository, EmployeeRepository>();

var app = builder.Build();


app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    "default",
    "{controller=Home}/{action=Index}/{id?}");
app.MapRazorPages();

using var scope = app.Services.CreateScope();
await SeedData.InitializeAsync(scope.ServiceProvider);

app.Run();
