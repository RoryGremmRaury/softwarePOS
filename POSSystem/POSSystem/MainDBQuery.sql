
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 11/16/2018 09:36:32
-- Generated from EDMX file: C:\Users\GabeyBaby\Documents\GitHub\softwarePOS\POSSystem\POSSystem\PosDB.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
--Create Database [pos_db];
GO
USE [pos_db];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------


-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[Category]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Category];
GO

IF OBJECT_ID(N'[dbo].[Customers]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Customers];
GO
IF OBJECT_ID(N'[dbo].[Products]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Products];
GO
IF OBJECT_ID(N'[dbo].[Orders]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Orders];
GO
IF OBJECT_ID(N'[dbo].[Users]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Users];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'Customers'
CREATE TABLE [dbo].[Customers] (
    [Name] varchar(50)  NOT NULL,
    [CustomerID] int  NOT NULL,
    [Email] varchar(50)  NULL
);
GO

-- Creating table 'Drinks'
CREATE TABLE [dbo].[Products] (
    [ItemID] int  NOT NULL,
    [Name] varchar(50)  NOT NULL,
    [Price] money  NOT NULL,
    [Year] int  NULL,
    [Brand] varchar(50)  NULL,
	[CategoryId] int not null, 
	[Ingredient_1] varchar(50) Not Null,
	[Ingredient_2] varchar(50) Null,
	[Ingredient_3] varchar(50) Null,
	[Ingredient_4] varchar(50) Null,
	[Ingredient_5] varchar(50) Null,
	[Ingredient_6] varchar(50) Null,
	[Ingredient_7] varchar(50) Null

);
GO

CREATE TABLE [dbo].[Category] (
	[CategoryId] int NOT NULL,
	[CategoryName] varchar(50) NULL,
);
GO

-- Creating table 'Orders'
CREATE TABLE [dbo].[Orders] (
    [OrderID] int  NOT NULL,
    [CustomerName] varchar(50)  NOT NULL,
	[OrderDate] date NOT NULL,
	[ItemID] varchar(50) NOT NULL,
    [Price] decimal(19,4)  NOT NULL
);
GO


-- Creating table 'Users'
CREATE TABLE [dbo].[Users] (
    [UserID] int  NOT NULL,
    [Username] nvarchar(50)  NOT NULL,
    [Password] nvarchar(50)  NOT NULL,
    [AccessLevel] int  NOT NULL
);
GO



-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [CustomerID] in table 'Customers'
ALTER TABLE [dbo].[Customers]
ADD CONSTRAINT [PK_Customers]
    PRIMARY KEY CLUSTERED ([Name] ASC);
GO

-- Creating primary key on [ItemID] in table 'Drinks'
ALTER TABLE [dbo].[Products]
ADD CONSTRAINT [PK_Products]
    PRIMARY KEY CLUSTERED ([ItemID] ASC);
GO
ALTER TABLE dbo.Category
Add COnstraint [PK_Category]
	Primary key clustered ([CategoryId] ASC);

GO


-- Creating primary key on [OrderNumber] in table 'Orders'
ALTER TABLE [dbo].[Orders]
ADD CONSTRAINT [PK_Orders]
    PRIMARY KEY CLUSTERED ([OrderID] ASC);
GO

-- Creating primary key on [UserID] in table 'Users'
ALTER TABLE [dbo].[Users]
ADD CONSTRAINT [PK_Users]
    PRIMARY KEY CLUSTERED ([UserID] ASC);
GO
-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

Alter Table dbo.Orders
ADD CONSTRAINT FK_ITEMID FOREIGN KEY (ItemID)
	references [dbo].[Products] (ItemID) ;

	
Alter Table dbo.Customers
ADD CONSTRAINT FK_CustID FOREIGN KEY (CustomerID)
	references [dbo].[Orders] (OrderID) ;


Alter Table dbo.Products
ADD CONSTRAINT FK_CatID FOREIGN KEY (CategoryID)
	references [dbo].[Category] (CategoryId) ;
-- --------------------------------------------------
-- Insert Into DB
-- --------------------------------------------------

INSERT INTO [dbo].[Category] ([CategoryId], [CategoryName]) VALUES (1, N'Drink')
INSERT INTO [dbo].[Category] ([CategoryId], [CategoryName]) VALUES (2, N'Food')
INSERT INTO [dbo].[Category] ([CategoryId], [CategoryName]) VALUES (3, N'Merch')

Insert into dbo.Products ([Name], [Price], [Year], [Brand], [CategoryId], [Ingredient_1], [Ingredient_2], [Ingredient_3], [Ingredient_4], [Ingredient_5], [Ingredient_6], [Ingredient_7]) VALUES ('Classic Manhattan', CAST(12.0000 AS Decimal(19, 4)), NULL, 'Whiskey', 1,'Evan Williams', 'Sweet Vermouth', 'Angostura', 'Cherry Garnish', NULL, NULL, NULL)
Insert into dbo.Products ([Name], [Price], [Year], [Brand], [CategoryId], [Ingredient_1], [Ingredient_2], [Ingredient_3], [Ingredient_4], [Ingredient_5], [Ingredient_6], [Ingredient_7]) VALUES ('Blanc Check', CAST(9.0000 AS Decimal(19, 4)), NULL, 'Whiskey', 1,'Sazerac ', 'Lillet Blanc', 'Sweet Vermouth', 'Lavendar Bitters', NULL, NULL, NULL)
Insert into dbo.Products ([Name], [Price], [Year], [Brand], [CategoryId], [Ingredient_1], [Ingredient_2], [Ingredient_3], [Ingredient_4], [Ingredient_5], [Ingredient_6], [Ingredient_7]) VALUES ('Brooklyn', CAST(8.0000 AS Decimal(19, 4)), NULL, 'Rye Whiskey', 1,'Wild Turkey Rye', 'Dry Vermouth', 'Sweet Vermouth', 'Orange Bitters', NULL, NULL, NULL)
Insert into dbo.Products ([Name], [Price], [Year], [Brand], [CategoryId], [Ingredient_1],[Ingredient_2], [Ingredient_3], [Ingredient_4], [Ingredient_5], [Ingredient_6], [Ingredient_7]) VALUES ('Up State', CAST(10.0000 AS Decimal(19, 4)), NULL, 'Rye Whiskey', 1,'Rittenhouse Rye', 'Sweet Vermouth', 'Orange Bitters', NULL, NULL, NULL, NULL)
Insert into dbo.Products ([Name], [Price], [Year], [Brand], [CategoryId], [Ingredient_1],[Ingredient_2], [Ingredient_3], [Ingredient_4], [Ingredient_5], [Ingredient_6], [Ingredient_7]) VALUES ('Contessa', CAST(9.0000 AS Decimal(19, 4)), NULL, 'Gin', 1,'Madam Pattrini', 'Dry Vermouth', 'Aperol', 'Lemon Garnish', NULL, NULL, NULL)
Insert into dbo.Products ([Name], [Price], [Year], [Brand], [CategoryId], [Ingredient_1],[Ingredient_2], [Ingredient_3], [Ingredient_4], [Ingredient_5], [Ingredient_6], [Ingredient_7]) VALUES ('Endless Summer', CAST(9.0000 AS Decimal(19, 4)), NULL, 'Gin', 1,'Tanqueray', 'Sweet Vermouth', 'Campari', 'Pineapple', 'OJ', NULL, NULL)
Insert into dbo.Products ([Name], [Price], [Year], [Brand], [CategoryId], [Ingredient_1],[Ingredient_2], [Ingredient_3], [Ingredient_4], [Ingredient_5], [Ingredient_6], [Ingredient_7]) VALUES ('Cablegram', CAST(8.0000 AS Decimal(19, 4)), NULL, 'Whiskey', 1,'1792 Small Batch', 'Lemon', 'Simple', 'Crabbies', NULL, NULL, NULL)
Insert into dbo.Products ([Name], [Price], [Year], [Brand], [CategoryId], [Ingredient_1],[Ingredient_2], [Ingredient_3], [Ingredient_4], [Ingredient_5], [Ingredient_6], [Ingredient_7]) VALUES ('Bourbon and Elder', CAST(9.0000 AS Decimal(19, 4)), NULL, 'Whiskey', 1,'Buffalo Trace', 'St.Germain', 'Bitters', NULL, NULL, NULL, NULL)
Insert into dbo.Products ([Name], [Price], [Year], [Brand], [CategoryId], [Ingredient_1],[Ingredient_2], [Ingredient_3], [Ingredient_4], [Ingredient_5], [Ingredient_6], [Ingredient_7]) VALUES ('Red Devil ', CAST(9.0000 AS Decimal(19, 4)), NULL, 'Whiskey', 1,'Wild Turkey', 'Aperol', 'Blackerry Brandy', 'Grapefruit', NULL, NULL, NULL)
Insert into dbo.Products ([Name], [Price], [Year], [Brand], [CategoryId] , [Ingredient_1],[Ingredient_2], [Ingredient_3], [Ingredient_4], [Ingredient_5], [Ingredient_6], [Ingredient_7]) VALUES ('Black Thorne', CAST(8.0000 AS Decimal(19, 4)), NULL, 'Whiskey', 1,'Jameson', 'Sweet Vermouth', 'Bitters', 'Absinthe wash', NULL, NULL, NULL)
Insert into dbo.Products ([Name], [Price], [Year], [Brand], [CategoryId] , [Ingredient_1],[Ingredient_2], [Ingredient_3], [Ingredient_4], [Ingredient_5], [Ingredient_6], [Ingredient_7]) VALUES ('The Margarita', CAST(8.0000 AS Decimal(19, 4)), NULL, 'Tequila', 1,'Hornitos Plata', 'Gran Gala', 'Honey', 'Lime', 'OJ', NULL, NULL)
Insert into dbo.Products ([Name], [Price], [Year], [Brand], [CategoryId] , [Ingredient_1],[Ingredient_2], [Ingredient_3], [Ingredient_4], [Ingredient_5], [Ingredient_6], [Ingredient_7]) VALUES ('Hemingway Daiquiri', CAST(8.0000 AS Decimal(19, 4)), NULL, 'Rum', 1,'Bacardi Silver', 'Luxardo', 'Sour', 'Grapefruit', NULL, NULL, NULL)
Insert into dbo.Products ([Name], [Price], [Year], [Brand], [CategoryId],[Ingredient_1], [Ingredient_2], [Ingredient_3], [Ingredient_4], [Ingredient_5], [Ingredient_6], [Ingredient_7]) VALUES ('Weeski', CAST(10.0000 AS Decimal(19, 4)), NULL, 'Whiskey', 1,'Tullamore Dew', 'Lillet Blanc', 'Triple Sec', 'Orange Bitters', NULL, NULL, NULL)
Insert into dbo.Products ([Name], [Price], [Year], [Brand], [CategoryId], [Ingredient_1],[Ingredient_2], [Ingredient_3], [Ingredient_4], [Ingredient_5], [Ingredient_6], [Ingredient_7]) VALUES ('Ramos Fizz', CAST(9.0000 AS Decimal(19, 4)), NULL, 'Gin', 1,'Sour', 'Cream ', 'Egg White', NULL, NULL, NULL, NULL)
Insert into dbo.Products ([Name], [Price], [Year], [Brand], [CategoryId], [Ingredient_1],[Ingredient_2], [Ingredient_3], [Ingredient_4], [Ingredient_5], [Ingredient_6], [Ingredient_7]) VALUES ('Juicy Pear', CAST(9.0000 AS Decimal(19, 4)), NULL, 'Vodka', 1,'Absolut Pear', 'Lemon', 'Simple', NULL, NULL, NULL, NULL)
Insert into dbo.Products ([Name], [Price], [Year], [Brand], [CategoryId],[Ingredient_1], [Ingredient_2], [Ingredient_3], [Ingredient_4], [Ingredient_5], [Ingredient_6], [Ingredient_7]) VALUES ('Juicy Lucy', CAST(10.0000 AS Decimal(19, 4)), NULL, 'Sandwhich', 2,'Grass Fed Angus Beef', NULL, NULL, NULL, NULL, NULL, NULL)
Insert into dbo.Products ([Name], [Price], [Year], [Brand], [CategoryId], [Ingredient_1],[Ingredient_2], [Ingredient_3], [Ingredient_4], [Ingredient_5], [Ingredient_6], [Ingredient_7]) VALUES ('Mac n Cheese', CAST(10.0000 AS Decimal(19, 4)), NULL, 'Plate', 2,'Macaroni', NULL, NULL, NULL, NULL, NULL, NULL)
Insert into dbo.Products ([Name], [Price], [Year], [Brand], [CategoryId], [Ingredient_1],[Ingredient_2], [Ingredient_3], [Ingredient_4], [Ingredient_5], [Ingredient_6], [Ingredient_7]) VALUES ('Steak n Frittes', CAST(12.0000 AS Decimal(19, 4)), NULL, 'Entry', 2,'10oz Free Range Steak', NULL, NULL, NULL, NULL, NULL, NULL)

INSERT INTO [dbo]. [Users] ([UserID], [Username], [Password], [AccessLevel])
VALUES (666, 666, 666, 666)
INSERT INTO [dbo]. [Users] ([UserID], [Username], [Password], [AccessLevel])
VALUES (1, 420, 420, 1)
INSERT INTO [dbo]. [Users] ([UserID], [Username], [Password], [AccessLevel])
VALUES (2, 69, 69, 0)



-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------