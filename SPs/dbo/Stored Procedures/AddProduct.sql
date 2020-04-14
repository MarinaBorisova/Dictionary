CREATE PROCEDURE [dbo].[AddProduct]
	@ProductId NVARCHAR(50),
	@ProductName NVARCHAR(50)
AS
BEGIN 
	INSERT INTO Products (ProductId, ProductName) 
	VALUES (@ProductId, @ProductName);
END

