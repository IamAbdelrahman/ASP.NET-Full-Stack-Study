-- 1
SELECT COUNT(*) AS StudentsWithAge
FROM Student
WHERE St_Age IS NOT NULL;

-- 2
SELECT DISTINCT Ins_Name FROM Instructor

-- 3
SELECT s.St_Id AS Student_ID, ISNULL(s.St_Fname + ' ' + s.ST_Lname, 'No Name') AS Student_FullName,
ISNULL(d.Dept_Name, 'No Department') AS DepartmentName FROM Student s JOIN Department d ON d.Dept_Id = s.Dept_Id

-- 4
SELECT i.Ins_Name, d.Dept_Name FROM Instructor i LEFT JOIN Department d 
ON d.Dept_Id = i.Dept_Id

-- 5
SELECT s.St_Fname + ' ' + s.St_Lname AS Student_FullName, c.Crs_Name
FROM Student s JOIN Stud_Course sc ON s.St_Id = sc.St_Id
JOIN Course c ON c.Crs_Id = sc.Crs_Id
WHERE sc.Grade IS NOT NULL

-- 6
SELECT t.Top_Name , COUNT(c.Crs_Id) AS Courses 
FROM Course c JOIN Topic t ON t.Top_Id = c.Top_Id
GROUP BY t.Top_Name

-- 7
SELECT MAX(Salary) AS Max_Salary, MIN(Salary) AS Min_Salary FROM Instructor

-- 8
SELECT Ins_Name FROM Instructor 
WHERE Salary < (SELECT AVG(Salary) FROM Instructor) AND Salary IS NOT NULL

-- 9
SELECT d.Dept_Name, i.Salary 
FROM Department d JOIN Instructor i ON d.Dept_Id = i.Dept_Id  
WHERE i.Salary = (SELECT MIN(Salary) FROM Instructor WHERE Salary IS NOT NULL)

-- 10
SELECT TOP(2) Salary FROM Instructor
ORDER BY Salary DESC

-- 11
SELECT i.Ins_Name, COALESCE(CONVERT(VARCHAR(10), i.Salary), 'Bonus') AS Salary 
FROM Instructor i 

-- 12
SELECT AVG(Salary) AS Average_Salary FROM Instructor

-- 13
SELECT Child.St_Fname, Parent.* FROM Student Child 
INNER JOIN Student Parent ON Child.St_Super = Parent.St_Id 

-- 14
SELECT *
FROM (
    SELECT I.Ins_Name AS Instructor, 
    DENSE_RANK() OVER(PARTITION BY I.Dept_Id ORDER BY ISNULL(CONVERT(VARCHAR(10), I.Salary), 'No Salary') DESC) AS DR
    FROM Instructor I JOIN Department D ON I.Dept_Id = D.Dept_Id
    ) AS NewTable
WHERE DR <= 2

-- 15
SELECT *
FROM (
    SELECT St_Fname + ' ' + St_Lname AS FullName,
     ROW_NUMBER() OVER (PARTITION BY Dept_Id ORDER BY NEWID()) AS RN FROM Student
     WHERE St_Fname IS NOT NULL AND St_Lname IS NOT NULL
    ) AS NewTable
WHERE RN = 1

