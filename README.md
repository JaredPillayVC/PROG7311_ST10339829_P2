# Agri-Energy Connect Prototype

Agri-Energy Connect is a straightforward web application built with ASP .NET Core MVC and Dapper for fast, reliable data access. 

It supports two user roles:

Farmer: Logs in to add, view, and manage their own products—entering details like name, category, and production date—and see them in a clear, 
responsive list.

Employee: Logs in to register new farmers (capturing name, contact, location) and to browse the entire product catalog, 
using simple filters by farmer, category, and date range.

The interface is mobile-friendly thanks to Bootstrap 5 and a custom dark theme. Sample data is seeded on first run, 
so non-technical users can immediately log in as farmer@agri.com or employee@agri.com and experience both workflows without any setup.

---

## Tech Stack

- ASP .NET Core 6 (MVC + Razor Pages)  
- Dapper for lightweight data access  
- Entity Framework Core for Identity (authentication + roles)  
- SQL Server Express (.\\SQLEXPRESS)  
- Bootstrap 5 for responsive UI  
- Custom dark theme CSS

---

## Prerequisites

1. [.NET 6 SDK](https://dotnet.microsoft.com/download/dotnet/6.0)  
2. Visual Studio 2022 / VS Code  
3. SQL Server Express (instance named `SQLEXPRESS`)

---

## Getting Started

You can set up and run the prototype in two ways—either by cloning the Git repo, or by unpacking a ZIP and running it locally.

---

### Option 1: Clone from Git

1. Install prerequisites 
   - [.NET 6 SDK](https://dotnet.microsoft.com/download/dotnet/6.0)  
   - Visual Studio 2022 (or VS Code) with C# support  
   - SQL Server Express (instance name `SQLEXPRESS`)

2. Clone the repository 
   git clone https://github.com/JaredPillayVC/PROG7311_ST10339829_P2.git
   cd PROG7311_ST10339829_P2

3. Restore NuGet packages
	dotnet restore

4. Configure the database
	In appsettings.json, set: "DefaultConnection": "Server=.\\SQLEXPRESS;Database=AgriEnergyConnect;Trusted_Connection=True;Encrypt=False;MultipleActiveResultSets=true"

5.	Apply EF Core migrations
	dotnet ef database update
		
6. Run the app
	 dotnet run

### Option 2:  Install from ZIP

1. Download the ZIP
	Get AgriEnergyConnect.zip (includes the full VS solution, SQL script, README).

2. Extract
	Unzip into a folder, e.g. C:\Projects\AgriEnergyConnect.

3. Install prerequisites
	.NET 6 SDK
	Visual Studio 2022 (or VS Code)
	SQL Server Express (SQLEXPRESS)

4. Open the solution
	In Visual Studio: double-click PROG7311_ST10339829_P2.sln.
	In VS Code: code . in the extracted folder.

5. Restore packages
	Visual Studio will auto-restore, or run:
	dotnet restore

6. Set up the database
	Ensure your appsettings.json connection string points to your SQL Express instance.
	In Package Manager Console:
		Update-Database
	or terminal
		dotnet ef database update

7. Run the application
	In Visual Studio: press F5.
	
	In terminal:
	dotnet run

---

## Default Test Accounts

Farmer
Email: farmer@agri.com
Password: Farmer123!

Employee
Email: employee@agri.com
Password: Employee123!

Once up, browse to /Identity/Account/Login and sign in.

---

## Project Structure

/Controllers
HomeController.cs
FarmerController.cs
EmployeeController.cs

/Data
ApplicationDbContext.cs
DapperContext.cs
SeedData.cs

/Models
ApplicationUser.cs
Farmer.cs
Employee.cs
Product.cs
ProductFilter.cs
ProductWithFarmer.cs
ProductListViewModel.cs

/Repository
Interfaces
IFarmerRepository.cs
IEmployeeRepository.cs
IProductRepository.cs
FarmerRepository.cs
EmployeeRepository.cs
ProductRepository.cs

/Views
/Shared/_Layout.cshtml
/Farmer/*
/Employee/*
/Home/Index.cshtml

/wwwroot
/css
site.css
dark-theme.css
/images
logo.png
favicon.png

db-schema.sql ← SQL schema & seed script

appsettings.json
Program.cs
README.md


---

## Database Script

If you’d rather bypass EF migrations, you can initialize your domain tables and sample data directly
by running the `db-schema.sql`(./db-schema.sql) script:

bash
sqlcmd -S .\SQLEXPRESS -i db-schema.sql
 
 ---

 ## Screenshots

 ![alt text](image.png)

 ![alt text](image-1.png)
 
 ![alt text](image-2.png)

 ![alt text](image-3.png)

 ![alt text](image-4.png)

 ![alt text](image-5.png)

 ![alt text](image-6.png)

 ![alt text](image-7.png)

 ![alt text](image-8.png)

 ![alt text](image-9.png)

 ![alt text](image-10.png)

 ![alt text](image-11.png)

 ![alt text](image-12.png)

 ![alt text](image-13.png)

 ![alt text](image-14.png)

 ![alt text](image-15.png)

 ![alt text](image-16.png)

 ![alt text](image-17.png)

 ![alt text](image-18.png)

 ![alt text](image-19.png)

 ![alt text](image-20.png)

 ![alt text](image-21.png)

 ![alt text](image-22.png)