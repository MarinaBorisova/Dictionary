CREATE PROCEDURE [dbo].[GetProductById]
	@ProductId NVARCHAR (50)

AS
BEGIN
	SELECT * from Products
	WHERE ProductId = @ProductId;
END