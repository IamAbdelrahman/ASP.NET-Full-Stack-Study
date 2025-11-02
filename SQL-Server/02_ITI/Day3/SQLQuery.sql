-- 1
SELECT D.Dnum, D.Dname, D.MGRSSN, E.Fname + ' ' + E.Lname AS FullName
FROM Departments AS D INNER JOIN Employee AS E
ON D.MGRSSN = E.SSN;

--2
SELECT Dname, Pname 
FROM Departments AS D INNER JOIN Project AS P
ON D.Dnum = P.Dnum

--3
SELECT D.* , E.Fname + ' ' + E.Lname AS FullName
FROM Dependent AS D INNER JOIN Employee AS E
ON D.ESSN = E.SSN;

--4
SELECT Pnumber, Pname, Plocation
FROM Project
WHERE City IN ('Cairo', 'Alex');

--5
SELECT * FROM Project
WHERE Pname LIKE 'a%'

--6

--7

--8

--9

--10

--11

--12

--13

--14

--15