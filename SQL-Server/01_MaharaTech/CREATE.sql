/* 1) Create Employee table with FirstName, LastName, SSN PK, BirthDate, City, Salary, 
	  superSSN FK, DepartmentNumber (Dno) FK.

   2) Create Department table with DepartmentName, DepartmentNumber PK, ManagerSSN FK, MGRStartDate.

   3) Create Projects table with ProjectName, ProjectNumber PK
*/

-- Create the Employee table
CREATE TABLE Employee
(
    Fname VARCHAR(10),
    Lname VARCHAR(10), 
    SSN INT PRIMARY KEY, 
    Bdate VARCHAR(10),
    City VARCHAR(10), 
    Salary FLOAT, 
    SuperSSN INT,                         -- Foreign Key
    E_DNO INT,                            -- Foreign Key
);

-- Create the Department table
CREATE TABLE Department
(
    D_Name VARCHAR(10) NOT NULL,
    DNO INT PRIMARY KEY,
    MGRSSN INT,                           -- Foreign Key
    MGRStartDate VARCHAR(10)
);


-- Create the Projects table
CREATE TABLE Projects 
(
    PNO INT PRIMARY KEY, 
    P_Name VARCHAR(50) NOT NULL
);

-- Create the WorkOn table as Many Employees may work on many projects
CREATE TABLE WorkOn
(
    W_SSN INT,                            -- Foreign Key
    W_PNO INT,                            -- Foreign Key
    PRIMARY KEY (W_SSN, W_PNO),
);