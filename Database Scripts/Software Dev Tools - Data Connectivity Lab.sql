USE Northwind

CREATE PROCEDURE BLapp1.GetCustomersByCountry
	@Country VARCHAR(30) = NULL
AS
DECLARE @ReturnCode INT
SET @ReturnCode = 0

IF @Country IS NULL
	RAISERROR('BLapp1.GetCustomersByCountry: Country cannot be null', 16, 1)
ELSE
	BEGIN
		SELECT	CustomerID, 
				CompanyName, 
				ContactName, 
				ContactTitle, 
				Address, 
				City, 
				Region, 
				PostalCode, 
				Phone, 
				Fax
		FROM Customers
		WHERE Country = @Country
		IF @@ERROR = 0
			SET @ReturnCode = 0
		ELSE
			BEGIN
				SET @ReturnCode = 1
				RAISERROR('BLapp1.GetCustomersByCountry: Select Error on the Customers table', 16, 1)
			END
	END
RETURN @ReturnCode

SELECT	CustomerID, 
		CompanyName, 
		ContactName, 
		ContactTitle, 
		Address, 
		City, 
		Region, 
		PostalCode, 
		Phone, 
		Fax
FROM Customers
WHERE Country = 'Canada'
SP_HELP Customers
-- CustomerID, CompanyName, ContactName, ContactTitle, Address, City, Region, PostalCode, Phone, Fax

CREATE PROCEDURE BLapp1.GetCategory
	@CategoryID INT = NULL
AS
DECLARE @ReturnCode INT
SET @ReturnCode = 0

IF @CategoryID IS NULL
	RAISERROR('BLapp1.GetCategory: CategoryID Cannot be null', 16, 1)
ELSE
	SELECT	CategoryID, 
			CategoryName, 
			Description
	FROM Categories
	WHERE CategoryID = @CategoryID
	IF @@ERROR = 0
		SET @ReturnCode = 0
	ELSE
		BEGIN
			SET @ReturnCode = 1
			RAISERROR('BLapp1.GetCategory: Select error on Categories table', 16, 1)
		END
RETURN @ReturnCode


SELECT CategoryID, CategoryName, Description
FROM Categories
WHERE CategoryID = 1
SP_Help Categories
-- CategoryID, CategoryName, Description


CREATE PROCEDURE BLapp1.GetProductsByCategory
	@CategoryID INT = NULL
AS
DECLARE @ReturnCode INT
SET @ReturnCode = 0

IF @CategoryID IS NULL
	RAISERROR('BLapp1.GetProductsByCategory: Category ID cannot be null', 16 ,1)
ELSE
	SELECT	ProductID, 
			ProductName, 
			Suppliers.CompanyName, 
			QuantityPerUnit, 
			UnitsInStock,
			UnitPrice,
			UnitsOnOrder, 
			ReorderLevel, 
			Discontinued
	FROM Products
	INNER JOIN Suppliers
	ON Products.SupplierID = Suppliers.SupplierID
	INNER JOIN Categories
	ON Products.CategoryID = Categories.CategoryID
	WHERE Categories.CategoryID = @CategoryID
	IF @@ERROR = 0
		SET @ReturnCode = 0
	ELSE
		BEGIN
			SET @ReturnCode = 1
			RAISERROR('BLapp1.GetProductsByCategory: Select error on products table', 16, 1)
		END
RETURN @ReturnCode



SP_HELP Products
SP_HELP Suppliers
--inner join on category
--inner join on supploer