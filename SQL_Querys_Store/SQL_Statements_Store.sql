USE Chinook;

SELECT CustomerId,FirstName, LastName , Country, PostalCode,Phone, Email FROM dbo.Customer;

SELECT CustomerId,FirstName, LastName , Country, PostalCode,Phone, Email FROM Customer WHERE CustomerId = 1;

SELECT * FROM dbo.Customer WHERE FirstName LIKE '%' AND LastName LIKE 'Jon%';

SELECT Country, COUNT(CustomerId) NumberOfCustomers FROM dbo.Customer GROUP BY Country ORDER BY NumberOfCustomers DESC;

SELECT CustomerId, SUM(Total) TotalAmount FROM Invoice GROUP BY CustomerId ORDER BY TotalAmount DESC;
 
SELECT Genre.Name,  COUNT(Genre.GenreId) PopularGenre
	FROM Invoice 
	INNER JOIN InvoiceLine on Invoice.InvoiceId = InvoiceLine.InvoiceId
	INNER JOIN Track on InvoiceLine.TrackId = Track.TrackId
	INNER JOIN Genre on Track.GenreId = Genre.GenreId
	WHERE CustomerId = 12
	GROUP BY Genre.Name
	ORDER BY PopularGenre DESC;


SELECT * FROM InvoiceLine;

SELECT * FROM Invoice;

SELECT * FROM Track;

SELECT * FROM Genre;