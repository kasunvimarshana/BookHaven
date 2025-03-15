# BookHavenDB Schema

## Database Creation
```sql
-- Create the BookHavenDB database
CREATE DATABASE BookHavenDB;
USE BookHavenDB;
```

## Users Table
Stores user credentials and roles.
```sql
-- Users table: Stores user credentials and roles
CREATE TABLE Users (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    Username NVARCHAR(50) UNIQUE NOT NULL,
    Password NVARCHAR(255) NOT NULL,
    FullName NVARCHAR(100) NOT NULL,
    Role NVARCHAR(20) CHECK (Role IN ('Admin', 'SalesClerk')) NOT NULL,
    Email NVARCHAR(100) UNIQUE NOT NULL,
    CreatedAt DATETIME DEFAULT GETDATE()
);
```

## Customers Table
Stores customer information.
```sql
-- Customers table: Stores customer information
CREATE TABLE Customers (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    FullName NVARCHAR(100) NOT NULL,
    Email NVARCHAR(100) UNIQUE NOT NULL,
    Phone NVARCHAR(15) UNIQUE NOT NULL,
    Address NVARCHAR(255),
    CreatedAt DATETIME DEFAULT GETDATE()
);
```

## Suppliers Table
Stores supplier information.
```sql
-- Suppliers table: Stores supplier information
CREATE TABLE Suppliers (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    Name NVARCHAR(100) NOT NULL,
    ContactPerson NVARCHAR(100),
    Phone NVARCHAR(15) UNIQUE NOT NULL,
    Email NVARCHAR(100) UNIQUE NOT NULL,
    Address NVARCHAR(255),
    CreatedAt DATETIME DEFAULT GETDATE()
);
```

## Books Table
Stores book inventory details.
```sql
-- Books table: Stores book inventory details
CREATE TABLE Books (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    Title NVARCHAR(255) NOT NULL,
    Author NVARCHAR(100) NOT NULL,
    Genre NVARCHAR(50),
    ISBN NVARCHAR(20) UNIQUE NOT NULL,
    Price DECIMAL(10,2) NOT NULL DEFAULT 0,
    StockQuantity INT CHECK (StockQuantity >= 0) NOT NULL DEFAULT 0,
    SupplierId INT NULL,
    CreatedAt DATETIME DEFAULT GETDATE(),
    FOREIGN KEY (SupplierId) REFERENCES Suppliers(Id) ON DELETE SET NULL
);
```

## Sales Table
Stores completed sales transactions.
```sql
-- Sales table: Stores completed sales transactions
CREATE TABLE Sales (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    CustomerId INT NOT NULL,
    UserId INT NOT NULL,
    TotalAmount DECIMAL(10,2) NOT NULL DEFAULT 0,
    Discount DECIMAL(5,2) DEFAULT 0,
    SaleDate DATETIME DEFAULT GETDATE(),
    FOREIGN KEY (CustomerId) REFERENCES Customers(Id) ON DELETE CASCADE,
    FOREIGN KEY (UserId) REFERENCES Users(Id) ON DELETE CASCADE
);
```

## SalesDetails Table
Stores books sold in each sale transaction.
```sql
-- SalesDetails table: Stores books sold in each sale transaction
CREATE TABLE SalesDetails (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    SaleId INT NOT NULL,
    BookId INT NOT NULL,
    Quantity INT CHECK (Quantity > 0) NOT NULL,
    Price DECIMAL(10,2) NOT NULL DEFAULT 0,
    Subtotal AS (Quantity * Price) PERSISTED,
    FOREIGN KEY (SaleId) REFERENCES Sales(Id) ON DELETE CASCADE,
    FOREIGN KEY (BookId) REFERENCES Books(Id) ON DELETE CASCADE
);
```

## Orders Table
Stores customer orders.
```sql
-- Orders table: Stores customer orders
CREATE TABLE Orders (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    SupplierId INT NOT NULL,
    OrderDate DATETIME DEFAULT GETDATE(),
    TotalAmount DECIMAL(10,2) NOT NULL DEFAULT 0,
    OrderStatus NVARCHAR(20) CHECK (OrderStatus IN ('Pending', 'Processing', 'Completed', 'Cancelled')) NOT NULL DEFAULT 'Pending',
    FOREIGN KEY (SupplierId) REFERENCES Suppliers(Id) ON DELETE CASCADE
);
```

## OrderDetails Table
Stores books ordered in each order.
```sql
-- OrderDetails table: Stores books ordered in each order
CREATE TABLE OrderDetails (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    OrderId INT NOT NULL,
    BookId INT NOT NULL,
    Quantity INT CHECK (Quantity > 0) NOT NULL,
    Price DECIMAL(10,2) NOT NULL DEFAULT 0,
    Subtotal AS (Quantity * Price) PERSISTED,
    FOREIGN KEY (OrderId) REFERENCES Orders(Id) ON DELETE CASCADE,
    FOREIGN KEY (BookId) REFERENCES Books(Id) ON DELETE CASCADE
);
```

## Indexes
Indexes for performance optimization.
```sql
-- Indexes for performance
CREATE INDEX IDX_Books_ISBN ON Books(ISBN);
CREATE INDEX IDX_Customers_Email ON Customers(Email);
CREATE INDEX IDX_Suppliers_Email ON Suppliers(Email);
CREATE INDEX IDX_Orders_OrderDate ON Orders(OrderDate);
```

```sql
-- Drop tables in reverse order to avoid foreign key constraint issues
DROP TABLE IF EXISTS OrderDetails;
DROP TABLE IF EXISTS Orders;
DROP TABLE IF EXISTS SalesDetails;
DROP TABLE IF EXISTS Sales;
DROP TABLE IF EXISTS Books;
DROP TABLE IF EXISTS Suppliers;
DROP TABLE IF EXISTS Customers;
DROP TABLE IF EXISTS Users;
```

```sql
-- Drop the database
DROP DATABASE IF EXISTS BookHavenDB;
```
