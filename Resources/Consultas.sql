--sales date prediction

WITH Diferencias AS (
    SELECT 
        O.custid,
        DATEDIFF(DAY, LAG(O.orderdate) OVER (PARTITION BY O.custid ORDER BY O.orderdate), O.orderdate) AS diferencia_dias
    FROM Sales.Orders O
)
SELECT DISTINCT
	C.custid,
    C.contactname AS ContactName,
    MAX(O.orderdate) AS LastOrderDate,
    DATEADD(DAY, AVG(Diferencias.diferencia_dias), MAX(O.orderdate)) AS NextPredictedDate
FROM Sales.Orders O  
JOIN Sales.Customers C ON O.custid = C.custid
LEFT JOIN Diferencias ON O.custid = Diferencias.custid
WHERE Diferencias.diferencia_dias IS NOT NULL
GROUP BY C.contactname, C.custid;

--get client orders

SELECT 
	O.orderid,
	O.requireddate,
	O.shippeddate,
	O.shipname,
	O.shipaddress,
	O.shipcity
FROM Sales.Orders O
JOIN Sales.Customers C ON O.custid = C.custid
WHERE C.custid = @custId

--get employees

SELECT 
	empid,
	CONCAT(firstname, ' ', lastname) FullName
FROM HR.Employees

--get shippers

SELECT 
	shipperid,
	companyname
FROM Sales.Shippers

--get products

SELECT 
	productid,
	productname
FROM Production.Products

--add new order Width Product

DECLARE @RowsAffected INT = 0;

BEGIN TRY
BEGIN TRANSACTION;

INSERT INTO Sales.Orders (empid, shipperid, shipname, shipaddress, shipcity, orderdate, requireddate, shippeddate, freight, shipcountry)
VALUES (@EmpID, @ShipperID, @ShipName, @ShipAddress, @ShipCity, @OrderDate, @RequiredDate, @ShippedDate, @Freight, @ShipCountry);

DECLARE @NewOrderID INT = SCOPE_IDENTITY();

INSERT INTO Sales.OrderDetails (orderid, productid, unitprice, qty, discount)
VALUES (@NewOrderID, @ProductID, @UnitPrice, @Qty, @Discount);

COMMIT TRANSACTION;

SET @RowsAffected = 1;
END TRY
BEGIN CATCH
ROLLBACK TRANSACTION;
SET @RowsAffected = 0;
THROW;
END CATCH;

SELECT @RowsAffected AS RowsAffected;
        