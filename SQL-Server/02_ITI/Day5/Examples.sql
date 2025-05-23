--------------------- TOP ------------------------------
SELECT TOP(3) * FROM Student
WHERE Student.St_Age >= 20 AND Student.St_Age <= 22

SELECT TOP(2) Salary FROM Instructor
ORDER BY Salary DESC

SELECT TOP(7) WITH TIES *
FROM Student ORDER BY St_Age

SELECT TOP(4) WITH TIES *
FROM Instructor ORDER BY Salary 

--------------------- Randomization ------------------------------
SELECT NEWID() AS GUID

SELECT TOP(3) * FROM Student 
ORDER BY NEWID() 

SELECT * 
FROM (
    SELECT St_Fname + ' ' + ST_Lname AS FullName
    FROM Student
    ) AS NewTable
WHERE FullName is NULL

SELECT * FROM Company.dbo.Project

SELECT Dname FROM Company.dbo.Departments
UNION ALL
Select Dept_Name FROM
Department

--------------------- Copy into a new table ------------------------------
SELECT * INTO Table2 FROM Student
SELECT * FROM Table2  

SELECT St_Id, St_FName INTO Table4 FROM Student 
WHERE 1=2

INSERT INTO Table4
VALUES (1, 'ALI') 

INSERT INTO Table4
SELECT St_Id, St_FName FROM Student

--------------------- Having Without GroupBy ------------------------------
SELECT SUM(Salary)
FROM Instructor
HAVING COUNT(Ins_Id) < 10
SELECT Ins_Id FROM Instructor

--------------------- Ranking Functions ------------------------------
-- ROW_Number() - Dense_Rank() - NTiles(Group) - Rank()

SELECT MAX(I.Salary) AS Max_Salary, D.Dept_Name
FROM Instructor I JOIN Department D ON I.Dept_Id = D.Dept_Id
GROUP BY Dept_Name


SELECT *
FROM (
    SELECT *, RANK() OVER (PARTITION BY Ins_Id ORDER BY Salary DESC) AS RN
    FROM Instructor
    ) AS NewTable
WHERE RN = 3

SELECT * ,ROW_NUMBER() OVER(PARTITION BY Dept_Id ORDER BY Dept_Id) AS RN,
    DENSE_RANK() OVER(PARTITION BY Dept_Id ORDER BY Dept_Id ) AS DN
FROM Instructor

SELECT *
FROM (
    SELECT *, RANK() OVER (PARTITION BY Ins_Id ORDER BY Salary DESC) AS RN
    FROM Instructor
    ) AS NewTable
WHERE RN = 3

SELECT * , DENSE_RANK() OVER(ORDER BY St_Age DESC) AS DN
FROM Student

SELECT *
FROM(
SELECT *, DENSE_RANK() OVER(PARTITION BY Dept_Id ORDER BY St_Age DESC) AS DN
FROM Student
WHERE St_Age IS NOT NULL AND Dept_Id IS NOT NULL
) AS NewTable
WHERE DN = 1

-- Ex: Divide Employees into 4 Groups and Get Minimum Salary from Each Group
SELECT MIN(Salary) AS MIN_Salary, G
FROM (
    SELECT *, NTILE(4) OVER(ORDER BY Salary) AS G 
    FROM Instructor
    WHERE Salary IS NOT NULL
) AS NewTable
GROUP BY G


SELECT * 
FROM (
    SELECT *, NTILE(4) OVER(ORDER BY Salary DESC) AS G
    FROM Instructor
) AS NewTable
WHERE G = 1

--Ex: Assign Row Numbers Within Each Department:-
SELECT *
FROM(
    SELECT *, ROW_NUMBER() OVER( PARTITION BY Dept_Id ORDER BY Salary DESC) AS RN
    FROM Instructor
)AS NewTable

--Ex: Assign Dense Ranks Within Each Department:-
SELECT *
FROM (
    SELECT *, DENSE_RANK() OVER( PARTITION BY Dept_Id ORDER BY St_Age DESC) AS DN
    FROM Student
    WHERE Dept_Id IS NOT NULL
)AS NewTable

-- Ex: Select Maximum Salary for Each Department (Using Row Number):-
SELECT *
FROM (
    SELECT *, ROW_NUMBER() OVER (PARTITION BY Dept_Id ORDER BY Salary DESC) AS RN
    FROM Instructor
) AS NewTable
WHERE RN = 1

SELECT *
FROM (
    SELECT *, ROW_NUMBER() OVER (PARTITION BY Dept_Id ORDER BY Salary DESC) AS DN
    FROM Instructor
) AS NewTable
WHERE DN = 1

-- EX: Select Top 2 Salaries in Each Department (Using Dense Rank):-
SELECT *
FROM (
    SELECT *, DENSE_RANK() OVER (PARTITION BY Dept_Id ORDER BY Salary DESC) AS DN 
    FROM Instructor
) AS NewTable
WHERE DN <= 2
--------------------- Data Types ------------------------------
-- tinyint - smallint - int - bigint - smallmoney - money 
-- real - float - decimal (dec) - char() - varchar() - nchar() - nvarchar()
-- nvarchar(max) -  date - time - time(7) - smalldatetime - datetime - datetime2(7)
-- datetimeoffset - 

-- Ex: This query categorizes instructor salaries into "low", "medium", and "high" based on the
-- salary value:
SELECT Ins_Name, Salary,
CASE WHEN Salary <= 7000 THEN 'LOW'
WHEN Salary <= 10000 THEN 'MEDIUM'
WHEN Salary <= 14000 THEN 'HIGH'
ELSE 'NO VALUE' END AS Criteria
FROM Instructor

UPDATE Instructor 
SET Salary = 
CASE WHEN Salary >= 3000 THEN Salary * 1.5
ELSE Salary * 1.8
END;

SELECT Ins_Name, Salary,
IIF(Salary >= 16000, 'HIGH', 'LOW') AS Criteria
FROM Instructor

-- Casting and Formatting
SELECT CONVERT(VARCHAR(20), GETDATE(), 106)
SELECT CAST (GETDATE() AS VARCHAR(20))
SELECT FORMAT(GETDATE(), 'G') AS DefaultFormat
SELECT FORMAT(GETDATE(), 'd') AS ShortDate
SELECT FORMAT(GETDATE(), 'D') AS LongDate
SELECT FORMAT(GETDATE(), 'F') AS FullDateTime 
SELECT FORMAT(GETDATE(), 't') AS ShortTime
SELECT FORMAT(GETDATE(), 'T') AS LongTime
SELECT FORMAT(GETDATE(), 'yyyy') AS Year
SELECT FORMAT(GETDATE(), 'MMMM') AS Month 
SELECT FORMAT(GETDATE(), 'dd') AS Day
SELECT FORMAT(GETDATE(), 'dd/MM/yyyy') AS CustomDate
SELECT FORMAT(GETDATE(), 'yyyy-MM-ddTHH:mm:ss') AS ISOFormat
SELECT FORMAT(GETDATE(), 'MM/dd/yyyy') AS MonthDayYear
SELECT FORMAT(GETDATE(), 'dd-MM-yyyy') AS DayMonthYear
SELECT FORMAT(GETDATE(), 'HH:mm:ss') AS Time24Hour
SELECT FORMAT(GETDATE(), 'dddd') AS DayOfWeek 
SELECT FORMAT(GETDATE(), 'MMMM d, yyyy') AS OrdinalDate
SELECT FORMAT(GETDATE(), 'C', 'en-US') AS CurrencyFormat
SELECT FORMAT(0.1234, 'P') AS PercentageFormat
SELECT FORMAT(12345.6789, 'N2') AS FixedPoint
SELECT FORMAT(GETDATE(), 'yyyy-MM-ddTHH:mm:ss.fff') AS ISODateTime;