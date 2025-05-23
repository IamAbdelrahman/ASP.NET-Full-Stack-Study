-- 1
SELECT SalesOrderID, ShipDate
FROM Sales.SalesOrderHeader
WHERE ShipDate BETWEEN '2002-07-28' and '2014-07-29';

-- 2
SELECT ProductID, Name
FROM Production.Product
WHERE StandardCost < 110.00;

-- 3
SELECT ProductID, Name
FROM Production.Product
WHERE Weight is null

-- 4
SELECT *
FROM Production.Product
WHERE Color in ('Silver', 'Black', 'Red')

-- 5
SELECT *
FROM Production.product
WHERE Name like 'B%'

-- 6
UPDATE Production.ProductDescription
SET Description = 'Chromoly steel_High of defects'
WHERE ProductDescriptionID = 3

SELECT *
FROM Production.ProductDescription
WHERE Description like '%[_]%'

-- 7
SELECT OrderDate, SUM(TotalDue) as TotalDue
FROM Sales.SalesOrderHeader
WHERE OrderDate BETWEEN '2001-07-01' and '2014-07-31'
group by OrderDate
order by OrderDate;


-- 8
SELECT distinct HireDate
FROM HumanResources.Employee

-- 9
SELECT AVG(distinct ListPrice) as Average
FROM Production.Product;

-- 10
SELECT CONCAT('The',Name,' is only!' ,ListPrice)
FROM Production.Product
WHERE ListPrice BETWEEN 100 and 120
order by ListPrice

-- 11
SELECT rowguid, Name, SalesPersonID, Demographics
into STORE_ARCHIVE
FROM Sales.Store;


SELECT COUNT(*) as total 
FROM STORE_ARCHIVE;


SELECT rowguid, Name, SalesPersonID, Demographics
into STORE_ARCHIVE_EMPTY
FROM Sales.Store
WHERE 1=0

-- 12
SELECT convert(varchar, GETDATE(), 101)
UNION
SELECT convert(varchar, GETDATE(), 103)             
UNION
SELECT format(GETDATE(), 'yyyy-MM-dd')


