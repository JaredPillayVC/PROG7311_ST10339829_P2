
--1) Drop existing tables (if present)
IF OBJECT_ID('dbo.Products','U') IS NOT NULL DROP TABLE dbo.Products;
IF OBJECT_ID('dbo.Employees','U') IS NOT NULL DROP TABLE dbo.Employees;
IF OBJECT_ID('dbo.Farmers','U')   IS NOT NULL DROP TABLE dbo.Farmers;

-- 2) Create Farmers table
CREATE TABLE Farmers (
    FarmerId   INT IDENTITY(1,1) PRIMARY KEY,
    Name       NVARCHAR(100) NOT NULL,
    Contact    NVARCHAR(200) NOT NULL,
    Location   NVARCHAR(200) NOT NULL
);

-- 3) Create Employees table
CREATE TABLE Employees (
    EmployeeId    INT IDENTITY(1,1) PRIMARY KEY,
    UserId        NVARCHAR(450) NOT NULL,  -- FK to AspNetUsers(Id)
    FullName      NVARCHAR(200) NOT NULL,
    ContactNumber NVARCHAR(50)  NOT NULL,
    Department    NVARCHAR(100) NOT NULL,
    CONSTRAINT FK_Employees_AspNetUsers
        FOREIGN KEY(UserId) REFERENCES AspNetUsers(Id)
);

-- 4) Create Products table
CREATE TABLE Products (
    ProductId      INT IDENTITY(1,1) PRIMARY KEY,
    FarmerId       INT             NOT NULL,  -- FK to Farmers(FarmerId)
    Name           NVARCHAR(100)   NOT NULL,
    Category       NVARCHAR(100)   NOT NULL,
    ProductionDate DATE            NOT NULL,
    CONSTRAINT FK_Products_Farmers
        FOREIGN KEY(FarmerId) REFERENCES Farmers(FarmerId)
);

-- 5) Seed sample data into Farmers
INSERT INTO Farmers (Name, Contact, Location) VALUES
  ('Rikash Singh',   'rikash.singh@rsfarms.com',   'Durban'),
  ('Ashvir Munesar',   'ashvir.munesar@gmail.com',   'PE');

-- 6) Seed sample data into Products
INSERT INTO Products (FarmerId, Name, Category, ProductionDate) VALUES
  (1, 'Maize',    'Grain',     '2025-05-01'),
  (1, 'Wheat',    'Grain',     '2025-04-20'),
  (2, 'Tomato',   'Vegetable', '2025-05-10'),
  (2, 'Potato',   'Vegetable', '2025-05-03');

-- 7) (Optional) Seed a sample Employee row linked to the seeded user
--    Assumes the EF SeedData has created an AspNetUser with email 'employee@agri.com'
INSERT INTO Employees (UserId, FullName, ContactNumber, Department)
VALUES (
  (SELECT Id FROM AspNetUsers WHERE Email = 'employee@agri.com'),
  'Jack Employee', '032-356-6887', 'Operations'
);
